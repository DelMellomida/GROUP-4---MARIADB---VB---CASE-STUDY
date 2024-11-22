Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices
Public Class MAIN
    Dim con As New MySqlConnection("server = localhost; user = root; password =; database = cs_hotel_reservation;")
    Private curbtn As New Button
    Private rnd As New Random
    Private tmpInd As New Integer
    Private actfrm As Form
    Private _username As String

    Public Sub New(username As String)
        InitializeComponent()
        rnd = New Random()
        _username = username
    End Sub

    Private Function slctTMCR() As Color
        Dim index As Integer = rnd.Next(ThemeColor.ColorList.Count)
        While tmpInd = index
            index = rnd.Next(ThemeColor.ColorList.Count)
        End While
        tmpInd = index
        Dim color As String = ThemeColor.ColorList(index)
        Return ColorTranslator.FromHtml(color)
    End Function

    Private Sub actbtn(btnsender As Object)
        If btnsender IsNot Nothing Then
            If curbtn.Name <> CType(btnsender, Button).Name Then
                dsblbtn()
                Dim color As Color = slctTMCR()
                curbtn = CType(btnsender, Button)
                curbtn.BackColor = color
                curbtn.ForeColor = Color.White
                curbtn.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                ThemeColor.PrimaryColor = color
                ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3)
            End If
        End If
    End Sub

    Private Sub dsblbtn()
        For Each prvbtn As Control In panelMenu.Controls
            If prvbtn.GetType() = GetType(Button) Then
                prvbtn.BackColor = Color.FromArgb(64, 64, 64)
                prvbtn.ForeColor = Color.Gainsboro
                prvbtn.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If
        Next
    End Sub

    Private Sub opnFrm(opnfrm As Form, btnSender As Object)
        If actfrm IsNot Nothing Then actfrm.Close()
        actbtn(btnSender)
        actfrm = opnfrm
        opnfrm.TopLevel = False
        opnfrm.FormBorderStyle = FormBorderStyle.None
        opnfrm.Dock = DockStyle.Fill
        Me.panFrm.Controls.Add(opnfrm)
        Me.panFrm.Tag = opnfrm
        opnfrm.BringToFront()
        opnfrm.Show()
    End Sub

    Private Sub opnHome(opnfrm As Form, btnSender As Object)
        If actfrm IsNot Nothing Then actfrm.Close()
        actfrm = opnfrm
        dsblbtn()
        opnfrm.TopLevel = False
        opnfrm.FormBorderStyle = FormBorderStyle.None
        opnfrm.Dock = DockStyle.Fill
        Me.panFrm.Controls.Add(opnfrm)
        Me.panFrm.Tag = opnfrm
        opnfrm.BringToFront()
        opnfrm.Show()
    End Sub

    Private Sub btnData_Click(sender As Object, e As EventArgs) Handles btnData.Click
        opnFrm(New frmData(), sender)
    End Sub

    Private Sub btnHotel_Click(sender As Object, e As EventArgs) Handles btnHotel.Click
        opnFrm(New frmHotel(_username), sender)
    End Sub

    Private Sub btnGuest_Click(sender As Object, e As EventArgs) Handles btnGuest.Click
        opnFrm(New frmGuest(_username), sender)
    End Sub

    Private Sub btnReservation_Click(sender As Object, e As EventArgs) Handles btnReservation.Click
        opnFrm(New frmReservation(_username), sender)
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        opnFrm(New frmPayment(_username), sender)
    End Sub

    Private Sub btnRoom_Click(sender As Object, e As EventArgs) Handles btnRoom.Click
        opnFrm(New frmRoom(_username), sender)
    End Sub

    Private Sub btnBed_Click(sender As Object, e As EventArgs) Handles btnBed.Click
        opnFrm(New frmBed(_username), sender)
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        opnFrm(New frmSummary(_username), sender)
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        opnHome(New frmHome(), sender)
    End Sub

End Class