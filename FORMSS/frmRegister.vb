Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.Net.Mail

Public Class frmRegister
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Public code As String
    Dim email As String
    Public veriEmail As String
    Dim sql, btnClick As String

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim name As String = txtName.Text
        Dim username As String = txtUname.Text
        Dim password As String = txtPassword.Text
        email = txtEmail.Text
        veriEmail = email
        Dim confirmPassword As String = txtCpassword.Text
        Dim role As String = cmbRole.Text

        If String.IsNullOrEmpty(name) Or String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Or String.IsNullOrEmpty(confirmPassword) Or String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(role) Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim passwordValidity = ValidatePassword(password)

        If passwordValidity = "Password is valid." Then
            Dim hashedPassword As String = HashPassword(password)
            ' Generate verification code and its expiry time (10 minutes from now)
            Dim code As String = GenerateCode()
            MsgBox(code)
            Dim codeExpiry As DateTime = DateTime.Now.AddMinutes(10)

            Try
                If con.State <> ConnectionState.Open Then
                    con.Open()
                End If

                ' Insert user into database along with the verification code and expiry
                sql = "INSERT INTO users (name, username, password, email, role, created_at, verification_code, verification_code_expiry) VALUES (@name, @username, @password, @email, @role, NOW(), @code, @expiry)"
                cmd = New MySqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@role", role)
                cmd.Parameters.AddWithValue("@code", code)
                cmd.Parameters.AddWithValue("@expiry", codeExpiry)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Registration successful! A verification email has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Send verification email
                EmailVerification(email, code)

                ' Clear input fields
                txtName.Clear()
                txtUname.Clear()
                txtPassword.Clear()
                txtCpassword.Clear()
                txtEmail.Clear()
                cmbRole.SelectedIndex = -1
                txtPassword.Focus()

                ' Show verification form
                Dim verificationForm As New frmVerification(email, code, username, role)
                verificationForm.Show()
                Me.Hide()

            Catch ex As MySqlException
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Ensure the connection is always closed
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        Else
            MessageBox.Show(passwordValidity, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lblLogin_Click(sender As Object, e As EventArgs) Handles lblLogin.Click
        Dim loginForm As New frmLOGIN()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)

            Dim hashBytes As Byte() = sha256.ComputeHash(bytes)

            Dim hashedPassword As New StringBuilder()

            For Each b As Byte In hashBytes
                hashedPassword.Append(b.ToString("x2"))
            Next

            Return hashedPassword.ToString()
        End Using
    End Function

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        Dim password As String = txtPassword.Text

        If String.IsNullOrWhiteSpace(password) Then
            lblError.Text = "Please input a valid password to properly proceed"
        Else
            If txtPassword.Text <> txtCpassword.Text = True Then
                lblPasswordMatch.Text = "Password doesn't match"
            Else
                lblPasswordMatch.Text = "/"
            End If
            Dim validationResult As String = ValidatePassword(password)
            lblError.Text = validationResult
        End If
    End Sub

    Private Function ValidatePassword(password As String) As String
        Dim errors As New List(Of String)
        If password.Length < 8 Then
            errors.Add("Password length must be at least 8 characters.")
        End If

        Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
        Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
        Dim hasSpecial As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

        If Not hasUpper Then
            errors.Add("Password must contain at least one uppercase letter.")
        End If
        If Not hasLower Then
            errors.Add("Password must contain at least one lowercase letter.")
        End If
        If Not hasDigit Then
            errors.Add("Password must contain at least one number.")
        End If
        If Not hasSpecial Then
            errors.Add("Password must contain at least one special character.")
        End If

        If errors.Any() Then
            Return String.Join(Environment.NewLine, errors)
        Else
            Return "Password is valid."
        End If
    End Function

    Public Sub EmailVerification(email As String, code As String)
        ' Generate the verification code

        ' Email setup
        Dim fromAddress As New MailAddress("noreply@hotelluna.com", "Hotel de Luna Verification")
        Dim toAddress As New MailAddress(txtEmail.Text) ' Use the email entered by the user during registration
        Dim subject As String = "Verify your email"
        Dim body As String = $"Your verification code is {code}. It will expire in 10 minutes."

        ' SMTP credentials (use your own email settings)
        Dim smtpUsername As String = "69420jhomello@gmail.com"
        Dim smtpPassword As String = "cjos bidx etll jpfe"

        Try
            ' Send the email using the SMTP client
            Using smtp As New SmtpClient("smtp.gmail.com", 587)
                smtp.Credentials = New NetworkCredential(smtpUsername, smtpPassword)
                smtp.EnableSsl = True

                Using message As New MailMessage(fromAddress, toAddress)
                    message.Subject = subject
                    message.Body = body
                    smtp.Send(message) ' Send the email with the verification code
                End Using
            End Using

            ' Optionally, store the code and expiration time in the database
            ' Update database with verification code and expiry time (if needed)
            Dim expiryTime As DateTime = DateTime.Now.AddMinutes(10)  ' Set expiration time for the code

            ' Open database connection
            sql = "UPDATE users SET verification_code = @code, verification_code_expiry = @expiry WHERE email = @Email"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@code", code)
            cmd.Parameters.AddWithValue("@expiry", expiryTime)
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text)  ' Use email entered during registration
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Verification code sent. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error in sending verification code: " & ex.Message)
        End Try
    End Sub


    Dim hidepass As Boolean = True
    Private Sub btnHidePassword_Click(sender As Object, e As EventArgs) Handles btnHidePassword.Click
        If txtPassword.PasswordChar = "●" Or btnHidePassword.Image Is My.Resources.hide Then
            txtPassword.PasswordChar = "" ' 
            btnHidePassword.Image = My.Resources.view ' 
        Else

            txtPassword.PasswordChar = "●" ' 
            btnHidePassword.Image = My.Resources.hide
        End If
    End Sub

    Private Sub txtHideCPassword_Click(sender As Object, e As EventArgs) Handles btnHideCpassword.Click
        If txtCpassword.PasswordChar = "●" Or btnHideCpassword.Image Is My.Resources.hide Then
            txtCpassword.PasswordChar = ""
            btnHideCpassword.Image = My.Resources.view
        Else
            txtCpassword.PasswordChar = "●"
            btnHideCpassword.Image = My.Resources.hide
        End If
    End Sub

    Private Function GenerateCode() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim randomNumber(5) As Byte
            rng.GetBytes(randomNumber)
            Return BitConverter.ToUInt32(randomNumber, 0) Mod 900000 + 100000
        End Using
    End Function
End Class