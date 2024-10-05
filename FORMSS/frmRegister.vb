Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmRegister
    ' Use your MySQL connection string
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, btnClick As String

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim name As String = txtName.Text
        Dim username As String = txtUname.Text
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtCPassword.Text

        If String.IsNullOrEmpty(name) Or String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Or String.IsNullOrEmpty(confirmPassword) Then
            MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim hashedPassword As String = HashPassword(password)

        Try

            con.Open()

            sql = "INSERT INTO users (name, username, password, created_at) VALUES (@name, @username, @password, NOW())"

            cmd = New MySqlCommand(sql, con)

            cmd.Parameters.AddWithValue("@name", name)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", hashedPassword)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtUname.Clear()
            txtPassword.Clear()
            txtCPassword.Clear()

        Catch ex As MySqlException
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
