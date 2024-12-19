Imports MySql.Data.MySqlClient
Public Class frmHotel
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim dr As MySqlDataReader
    Dim sql, x, btnClick As String
    Dim id As Integer = 0
    Private _username As String
    Private _role As String

    Public Sub New(username As String, role As String)
        InitializeComponent()
        _username = username
        _role = role
    End Sub
    Private Sub frmHotel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTheme()
        btnFalse()
        txtFalse()
        Refresh()
        loadHotelType()

        ' Set controls based on user role
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
            If Not id = 0 Then
                Dim validation = MsgBox("Want to delete?" + vbNewLine + vbNewLine + "Hotel Name: " + txtName.Text + vbNewLine + "Hotel Type: " + cmbType.Text + vbNewLine + "Address: " + txtAddress.Text + vbNewLine + "Contact: " + txtContact.Text + vbNewLine + "Email: " + txtEmail.Text, vbYesNo)
                If validation = vbYes Then
                    sql = "DELETE FROM hotel WHERE hotel_choice_id = '" & id & "';"
                    cmd.Connection = con
                    cmd.CommandText = sql
                    cmd.CommandType = CommandType.Text
                    x = cmd.ExecuteNonQuery()
                    con.Close()
                    Refresh()
                    con.Close()
                    btnTrue()

                    WriteToAuditTrail(_username, $"Deleted hotel: {txtName.Text}, ID: {id}")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            sql = "Select * from hotel where hotel_choice like '%" & txtSearch.Text & "%' OR address like '%" & txtSearch.Text & "%' OR contact like '%" & txtSearch.Text & "%' OR email like '%" & txtSearch.Text & "%' or hotel_choice_id = '" & id & "';"
            con.Open()
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
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnClick = "Add" Then
                sql = "Insert into hotel(hotel_choice, hotel_type_id, address, contact, email) values ('" & txtName.Text & "', '" & getHotelTypeID(cmbType.Text) & "' , '" & txtAddress.Text & "', '" & txtContact.Text & "', '" & txtEmail.Text & "');"
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()

                WriteToAuditTrail(_username, $"Added new hotel: {txtName.Text}, Type: {cmbType.Text}")
            ElseIf btnClick = "Edit" Then
                If Not id = 0 Then
                    sql = "UPDATE hotel set hotel_type_id='" & getHotelTypeID(cmbType.Text) & "', address='" & txtAddress.Text & "', contact='" & txtContact.Text & "', Email= '" & txtEmail.Text & "' where hotel_choice_id ='" & id & "';"
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = sql
                    cmd.CommandType = CommandType.Text
                    x = cmd.ExecuteNonQuery
                    con.Close()

                    WriteToAuditTrail(_username, $"Edited hotel ID: {id}, New Name: {txtName.Text}, Type: {cmbType.Text}")
                Else
                    MsgBox("Please select first what you want to delete")
                End If
            End If
            frmHotel_Load(sender, e)
            txtEmpty()
        Catch ex As Exception
            MsgBox("The input data is already exist")
        Finally
            Refresh()
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
            txtName.Text = crow.Cells(1).Value
            cmbType.Text = getHotelType(crow.Cells(2).Value)
            txtAddress.Text = crow.Cells(3).Value
            txtContact.Text = crow.Cells(4).Value
            txtEmail.Text = crow.Cells(5).Value
        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try

    End Sub

    Sub txtTrue()
        txtName.Enabled = True
        cmbType.Enabled = True
        txtAddress.Enabled = True
        txtContact.Enabled = True
        txtEmail.Enabled = True
        txtSearch.Enabled = False
    End Sub

    Sub txtFalse()
        txtName.Enabled = False
        cmbType.Enabled = False
        txtAddress.Enabled = False
        txtContact.Enabled = False
        txtEmail.Enabled = False
        txtSearch.Enabled = True
    End Sub

    Sub txtEmpty()
        txtName.Text = ""
        cmbType.Text = ""
        txtAddress.Text = ""
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
            sql = "Select * from hotel"
            With cmd
                .CommandText = sql
                .Connection = con
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            dgvDisplay.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
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

    Function getHotelTypeID(ByVal name As String) As Integer
        Dim id As Integer
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(name)) Then
                cmd = New MySqlCommand("SELECT `hotel_type_id` FROM `hotel_type` WHERE `hotel_type_name` = @name", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", name)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("hotel_type_id")
                    Return id
                Else
                    MsgBox("No hotel type available")
                End If
            Else
                MsgBox("Please fill out the hotel type")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return 0
    End Function

    Function getHotelType(ByVal id As Integer) As String
        Dim name As String
        Try
            con.Open()
            If (Not id = 0) Then
                cmd = New MySqlCommand("SELECT `hotel_type_name` FROM `hotel_type` WHERE `hotel_type_id` = @id", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", id)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    name = dr.Item("hotel_type_name")
                    Return name
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return ""
    End Function

    Sub loadHotelType()
        cmbType.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT hotel_type_name FROM hotel_type"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmbType.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub WriteToAuditTrail(username As String, action As String)
        Dim logPath As String = "audit_log/audit_trail.txt"
        Dim logMessage As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | User: {username} | Action: {action}"

        Try
            If Not IO.Directory.Exists("audit_log") Then
                IO.Directory.CreateDirectory("audit_log")
            End If

            IO.File.AppendAllText(logPath, logMessage & Environment.NewLine)
        Catch ex As Exception
            MessageBox.Show($"Error writing to audit trail: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class