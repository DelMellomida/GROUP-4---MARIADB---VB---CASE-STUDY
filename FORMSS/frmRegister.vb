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
    Dim sql, btnClick As String


    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim name As String = txtName.Text
        Dim username As String = txtUname.Text
        Dim password As String = txtPassword.Text
        Dim email As String = txtEmail.Text
        Dim confirmPassword As String = txtCPassword.Text
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

            Try
                con.Open()
                sql = "INSERT INTO users (name, username, password, email, role, created_at) VALUES (@name, @username, @password, @email, @role, NOW())"
                cmd = New MySqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", hashedPassword)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@role", role)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Registration successful! A verification email has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                EmailVerification()

                ' Clear fields
                txtName.Clear()
                txtUname.Clear()
                txtPassword.Clear()
                txtCPassword.Clear()
                txtEmail.Clear()
                cmbRole.SelectedIndex = -1
                txtPassword.Focus()

                Dim verificationForm As New frmVerification(email, code)
                verificationForm.Show()
                Me.Hide()

            Catch ex As MySqlException
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
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
        Using pbkdf2 As New Rfc2898DeriveBytes(password, 16, 100000)
            Return Convert.ToBase64String(pbkdf2.GetBytes(20))
        End Using
    End Function

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        Dim password As String = txtPassword.Text
        Dim validationResult As String = ValidatePassword(password)
        lblError.Text = validationResult
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

    Public Sub EmailVerification()
        Dim fromAddress As New MailAddress("noreply@hotelluna.com", "Hotel de Luna Verification")
        Dim toAddress As New MailAddress(txtEmail.Text)
        code = GenerateCode()
        Dim subject As String = "Verify your email"
        Dim body As String = $"Your verification code is {code}. It will expire in 10 minutes."

        Dim smtpUsername As String = "69420jhomello@gmail.com"
        Dim smtpPassword As String = "cjos bidx etll jpfe"

        Try
            Using smtp As New SmtpClient("smtp.gmail.com", 587)
                smtp.Credentials = New NetworkCredential(smtpUsername, smtpPassword)
                smtp.EnableSsl = True

                Using message As New MailMessage(fromAddress, toAddress)
                    message.Subject = subject
                    message.Body = body
                    smtp.Send(message)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error in sending verification code: " & ex.Message)
        End Try
    End Sub

    Private Function GenerateCode() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim randomNumber(5) As Byte
            rng.GetBytes(randomNumber)
            Return BitConverter.ToUInt32(randomNumber, 0) Mod 900000 + 100000
        End Using
    End Function
End Class