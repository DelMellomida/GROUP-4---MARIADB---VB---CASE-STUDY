﻿Imports MySql.Data.MySqlClient
Public Class frmBed
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, x, btnClick As String
    Dim id As Integer = 0
    Private _username As String
    Private _role As String

    Public Sub New(username As String, role As String)
        InitializeComponent()
        _username = username
        _role = role
    End Sub
    Private Sub frmBed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTheme()
        btnFalse()
        txtFalse()
        Refresh()

        If _role = "cashier" Then
            ' Cashiers can only view and search hotels, but can't add, edit, or delete
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            txtSearch.Enabled = True
        ElseIf _role = "admin" Then
            ' Admins can perform all actions
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = True
            txtSearch.Enabled = True
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Refresh()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        txtTrue()
        btnTrue()
        txtEmpty()
        btnClick = "Add"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtTrue()
        btnClick = "Edit"
        btnTrue()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            con.Open()
            Dim validation = MsgBox("Want to delete?" + vbNewLine + vbNewLine + "Bed Reference:" + txtBed.Text + vbNewLine + "Bed Rate:" + txtRate.Text, vbYesNo)
            If validation = vbYes Then
                sql = "DELETE FROM bed WHERE bed_references_id like '" & id & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()
                Refresh()
                con.Close()
                btnTrue()

                WriteToAuditTrail(_username, _role, $"Deleted bed: {txtBed.Text}, Rate: {txtRate.Text}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            con.Open()
            sql = "Select * from bed where bed_references like '%" & txtSearch.Text & "%';"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            dgvDisplay.DataSource = dt
            con.Close()
            txtSearch.Text = ""
        Catch ex As Exception
            MsgBox("The data doesn't exist")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnClick = "Add" Then
                con.Open()
                sql = "Insert into bed(bed_references, bed_rate) values ('" & txtBed.Text & "','" & txtRate.Text & "')"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery

                WriteToAuditTrail(_username, _role, $"Added new bed: {txtBed.Text}, Rate: {txtRate.Text}")
            ElseIf btnClick = "Edit" Then
                con.Open()
                sql = "Update item set bed_references = '" & txtBed.Text & "', bed_rate ='" & txtRate.Text & "' WHERE bed_references_id = " & id & ";"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery

                WriteToAuditTrail(_username, _role, $"Edited bed: {txtBed.Text}, New Rate: {txtRate.Text}")
            End If
        Catch ex As Exception

        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnFalse()
        txtFalse()
        txtEmpty()
    End Sub

    Private Sub dgvDisplay_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDisplay.CellClick
        Dim crow As DataGridViewRow
        Try
            crow = dgvDisplay.Rows(e.RowIndex)
            id = crow.Cells(0).Value
            txtBed.Text = crow.Cells(1).Value
            txtRate.Text = crow.Cells(2).Value
        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try
    End Sub

    Sub txtTrue()
        txtBed.Enabled = True
        txtRate.Enabled = True
        txtSearch.Enabled = False
    End Sub

    Sub txtFalse()
        txtBed.Enabled = False
        txtRate.Enabled = False
        txtSearch.Enabled = True
    End Sub

    Sub txtEmpty()
        txtBed.Text = ""
        txtRate.Text = ""

    End Sub

    Sub btnTrue()
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnDelete.Enabled = False
        btnSearch.Enabled = False
    End Sub

    Sub btnFalse()
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnDelete.Enabled = True
        btnSearch.Enabled = True
    End Sub

    Public Sub Refresh()
        dt.Clear()
        Try
            con.Open()
            sql = "Select * from bed"
            With cmd
                .CommandText = sql
                .Connection = con
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            dgvDisplay.DataSource = dt
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadTheme()
        For Each btns As Control In Me.Controls
            If btns.[GetType]() = GetType(Button) Then
                Dim btn As Button = CType(btns, Button)
                btn.BackColor = ThemeColor.PrimaryColor
                btn.ForeColor = Color.White
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor
            End If
        Next
    End Sub

    Public Sub WriteToAuditTrail(username As String, role As String, action As String)
        ' Get the root directory of the project
        Dim projectRoot As String = IO.Path.GetFullPath(IO.Path.Combine(Application.StartupPath, "..\.."))
        Dim logDirectory As String = IO.Path.Combine(projectRoot, "audit_log")
        Dim logPath As String = IO.Path.Combine(logDirectory, "audit_trail.txt")
        Dim logMessage As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {username} | Role: {role} | Action: {action}"

        Try
            ' Ensure the directory exists
            If Not IO.Directory.Exists(logDirectory) Then
                IO.Directory.CreateDirectory(logDirectory)
            End If

            ' Append the log message to the file
            Using writer As New IO.StreamWriter(logPath, True)
                writer.WriteLine(logMessage)
            End Using

            MessageBox.Show("Audit trail updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error writing to audit trail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class