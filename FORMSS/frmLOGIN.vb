Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports GROUP_4___MARIADB___VB___CASE_STUDY

Public Class frmLOGIN
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        Dim registerForm As New frmRegister()
        registerForm.Show()
        Me.Hide()
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

            Dim sql As String = "SELECT * FROM users WHERE username = @username AND password = @password"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", hashedPassword)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim updateSql As String = "UPDATE users SET last_login = @last_login WHERE username = @username"
                cmd = New MySqlCommand(updateSql, con)
                cmd.Parameters.AddWithValue("@last_login", DateTime.Now)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.ExecuteNonQuery()

                Dim summaryForm As New MAIN()
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
End Class
