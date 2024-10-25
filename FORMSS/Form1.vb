﻿Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail

Public Class frmVerification
    Private _email As String
    Private _code As String

    ' Constructor to accept email and code
    Public Sub New(email As String, code As String)
        InitializeComponent()
        _email = email
        _code = code
    End Sub

    Private Sub btnResend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmailVerification()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If _code = txtCode.Text Then
            Dim summaryForm As New MAIN()
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
    End Sub

    Private Function GenerateCode() As String
        Using rng As New RNGCryptoServiceProvider()
            Dim randomNumber(5) As Byte
            rng.GetBytes(randomNumber)
            Return BitConverter.ToUInt32(randomNumber, 0) Mod 900000 + 100000 ' Generates a 6-digit number
        End Using
    End Function
End Class
