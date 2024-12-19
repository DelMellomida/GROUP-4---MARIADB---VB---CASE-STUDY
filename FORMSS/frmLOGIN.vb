Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports GROUP_4___MARIADB___VB___CASE_STUDY
Imports System.Net.Mail
Imports System.Net

Public Class frmLOGIN
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql As String
    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        Dim enteredCode As String = InputBox("Please enter the admin code to proceed with registration.", "Admin Code Required")

        If enteredCode = "admin123" Then
            Dim registerForm As New frmRegister()
            registerForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid code. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            WriteToAuditTrail("unknown", "Someone tried to access the register")
        End If
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Get username and password from textboxes
        Dim username As String = txtUname.Text
        Dim password As String = txtPassword.Text

        ' Check if both fields are filled
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Hash the password
        Dim hashedPassword As String = HashPassword(password)
        Try
            con.Open()

            ' Update query to fetch username, password, and role
            Dim sql As String = "SELECT * FROM users WHERE username = @username AND password = @password"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", hashedPassword)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Retrieve the role from the database
                Dim role As String = dt.Rows(0)("role").ToString()

                ' Update last login time
                Dim updateSql As String = "UPDATE users SET last_login = @last_login WHERE username = @username"
                cmd = New MySqlCommand(updateSql, con)
                cmd.Parameters.AddWithValue("@last_login", DateTime.Now)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.ExecuteNonQuery()

                ' Write successful login to audit trail
                WriteToAuditTrail(username, "Successful login")

                ' Pass username and role to the MAIN form
                Dim summaryForm As New MAIN(username, role)
                summaryForm.Show()
                Me.Hide()

            Else
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
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

    Public Sub WriteToAuditTrail(username As String, action As String)
        Dim logPath As String = "audit_log/audit_trail.txt"
        Dim logMessage As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {username} | Action: {action}"

        Try
            If Not IO.Directory.Exists("audit_log") Then
                IO.Directory.CreateDirectory("audit_log")
            End If

            MessageBox.Show($"Successful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

            IO.File.AppendAllText(logPath, logMessage & Environment.NewLine)
        Catch ex As Exception
            MessageBox.Show($"Error writing to audit trail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHidePassword_Click(sender As Object, e As EventArgs) Handles btnHidePassword.Click
        If txtPassword.PasswordChar = "●" Or btnHidePassword.Image Is My.Resources.hide Then
            txtPassword.PasswordChar = "" ' Set PasswordChar to 0 to show password
            btnHidePassword.Image = My.Resources.view ' Set an open-eye image (ensure you have the image in your resources)
        Else

            txtPassword.PasswordChar = "●" ' Hide password with asterisk
            btnHidePassword.Image = My.Resources.hide ' Set a closed-eye image
        End If
    End Sub

    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        pnlForgotPassword.Visible = True
        grpLogin.Enabled = False
    End Sub

    Private Sub lblBack_Click(sender As Object, e As EventArgs) Handles lblBack.Click
        pnlForgotPassword.Visible = False
        grpLogin.Enabled = True
    End Sub


End Class

