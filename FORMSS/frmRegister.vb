﻿Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.Net.Mail


Public Class frmRegister
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
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

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txtName.Clear()
                txtUname.Clear()
                txtPassword.Clear()
                txtCPassword.Clear()
                txtEmail.Clear()
                cmbRole.SelectedIndex = -1
                txtPassword.Focus()

            Catch ex As MySqlException
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        Else
            MessageBox.Show("Somethign")
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


End Class
