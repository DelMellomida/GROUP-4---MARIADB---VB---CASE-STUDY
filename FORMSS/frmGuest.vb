Imports MySql.Data.MySqlClient
Public Class frmGuest
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, x, btnClick As String
    Private Sub frmGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTheme()
        btnFalse()
        txtFalse()
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
            Dim validation = MsgBox("Want to delete?" + vbNewLine + vbNewLine + "Guest ID: " + txtID.Text + vbNewLine + "Name: " + txtName.Text, vbYesNo)
            If validation = vbYes Then
                sql = "DELETE FROM  guest WHERE guestid like '" & txtID.Text & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()
                Refresh()
                con.Close()
                btnTrue()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            con.Open()
            sql = "Select * from guest where guestid like '%" & txtSearch.Text & "%' OR Name like '%" & txtSearch.Text & "%' OR gender like '%" & txtSearch.Text & "%';"
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
                sql = "Insert into guest values ('" & txtID.Text & "', '" & cmbGender.Text & "' , '" & txtName.Text & "', '" & txtAddress.Text & "', '" & txtCountry.Text & "', '" & txtContact.Text & "', '" & txtEmail.Text & "')"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()
            ElseIf btnClick = "Edit" Then
                txtID.ReadOnly = True
                con.Open()
                sql = "UPDATE item set gender='" & cmbGender.Text & "', name='" & txtName.Text & "', address='" & txtAddress.Text & "', country='" & txtCountry.Text & "', contact='" & txtContact.Text & "'. email= '" & txtEmail.Text & "' where guestid ='" & txtID.Text & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()
                txtID.ReadOnly = False
            End If
            frmGuest_Load(sender, e)
            txtEmpty()
        Catch ex As Exception
            MsgBox("The input data already exist")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnFalse()
        txtFalse()
        txtEmpty()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Refresh()
    End Sub

    Private Sub dgvDisplay_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDisplay.CellClick
        Dim crow As DataGridViewRow
        Try
            crow = dgvDisplay.Rows(e.RowIndex)
            txtID.Text = crow.Cells(0).Value
            cmbGender.Text = crow.Cells(1).Value
            txtName.Text = crow.Cells(2).Value
            txtAddress.Text = crow.Cells(3).Value
            txtCountry.Text = crow.Cells(4).Value
            txtContact.Text = crow.Cells(5).Value
            txtEmail.Text = crow.Cells(6).Value
        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try
    End Sub

    Sub txtTrue()
        txtID.Enabled = True
        cmbGender.Enabled = True
        txtName.Enabled = True
        txtAddress.Enabled = True
        txtCountry.Enabled = True
        txtContact.Enabled = True
        txtEmail.Enabled = True
        txtSearch.Enabled = False
    End Sub

    Sub txtFalse()
        txtID.Enabled = False
        cmbGender.Enabled = False
        txtName.Enabled = False
        txtAddress.Enabled = False
        txtCountry.Enabled = False
        txtContact.Enabled = False
        txtEmail.Enabled = False
        txtSearch.Enabled = True
    End Sub

    Sub txtEmpty()
        txtID.Text = ""
        cmbGender.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtCountry.Text = ""
        txtContact.Text = ""
        txtEmail.Text = ""
        txtSearch.Text = ""
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

    Private Sub Refresh()
        dt.Clear()
        Try
            con.Open()
            sql = "Select * from guest"
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
End Class