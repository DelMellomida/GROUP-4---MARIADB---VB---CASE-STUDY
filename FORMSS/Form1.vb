Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.Timers

Public Class frmVerification
    Dim con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation;convert zero datetime=true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Private _email As String
    Private _code As String
    Private _username As String
    Dim sql As String
    Private resendTimer As Timer
    Private codeGenerationTime As DateTime

    Public Sub New(email As String, code As String, username As String)
        InitializeComponent()
        _email = email
        _code = code
        _username = username
        InitializeTimer()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If _code = txtCode.Text Then
            Try
                con.Open()
                sql = "UPDATE users SET isVerified = @isVerified WHERE email = @Email"
                cmd = New MySqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@isVerified", 1)
                cmd.Parameters.AddWithValue("@email", _email)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Verification successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try

            Dim summaryForm As New MAIN(_username)
            summaryForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid verification code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub EmailVerification()
        Dim fromAddress As New MailAddress("noreply@hotelluna.com", "Hotel de Luna Verification")
        Dim toAddress As New MailAddress(_email)
        _code = GenerateCode()
        Dim subject As String = "Verify your email"
        Dim body As String = $"Your verification code is {_code}. It will expire in 10 minutes."

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
        codeGenerationTime = DateTime.Now
    End Sub

    Private Sub InitializeTimer()
        resendTimer = New Timer(60000)
        AddHandler resendTimer.Elapsed, AddressOf OnTimerElapsed
        resendTimer.Start()
    End Sub

    Private Sub OnTimerElapsed(sender As Object, e As ElapsedEventArgs)
        Dim elapsedTime As TimeSpan = DateTime.Now - codeGenerationTime
        If elapsedTime.TotalMinutes >= 10 Then
            EmailVerification()
        End If
    End Sub

    Private Function GenerateCode() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim randomNumber(5) As Byte
            rng.GetBytes(randomNumber)
            Return BitConverter.ToUInt32(randomNumber, 0) Mod 900000 + 100000
        End Using
    End Function

    Private Sub btnResend_Click_1(sender As Object, e As EventArgs) Handles btnResend.Click
        EmailVerification()
    End Sub
End Class
