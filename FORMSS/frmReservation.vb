Imports MySql.Data.MySqlClient
Public Class frmReservation
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, x, btnClick As String
    Dim dr As MySqlDataReader
    Private Sub frmReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTheme()
        btnFalse()
        txtFalse()
        Refresh()
        loadCmbRoom()
        loadCmbBed()
        load1stHotelChoice()
        loadGID()
        load2ndHotelChoice()
        txtChoice.ReadOnly = True
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
        txtRID.ReadOnly = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            con.Open()
            Dim validation = MsgBox("Want to delete?" + vbNewLine + vbNewLine + "GuestID: " + cmbGID.Text + vbNewLine + "Reservation ID: " + txtRID.Text + vbNewLine + "Hotel Choice: " + txtChoice.Text, vbYesNo)
            If validation = vbYes Then
                sql = "DELETE FROM reservation WHERE reservationID like '" & txtRID.Text & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()
                Refresh()
                btnTrue()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            con.Open()
            sql = "Select * from reservation where reservationid like '%" & txtSearch.Text & "%' OR guestid like '%" & txtSearch.Text & "%';"
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
                sql = "Insert into reservation(reservationid, guestid, first_choice_hotel,
                    second_choice_hotel, check_in_time, check_out_time, check_in_date, check_out_date,
                    room_type_id, bed_references_id, no_of_rooms, extra, no_of_children, 
                    no_of_adults) values ('" & txtRID.Text &
                    "','" & cmbGID.Text & "','" & cmb1st.Text &
                    "','" & cmb2nd.Text & "','" & txtTimeIn.Text &
                    "','" & txtTimeOut.Text &
                    "','" & dtpDateIn.Value.Date.ToString("yyyy-MM-dd") &
                    "','" & dtpDateOut.Value.Date.ToString("yyyy-MM-dd") &
                    "'," & getRoomId(cmbRType.Text) &
                    "," & getBedId(cmbBed.Text) & ", " & txtNroom.Text &
                    "," & getExtraValue() &
                    "," & txtNOC.Text &
                    ", " & txtNOA.Text & ");"
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()
            ElseIf btnClick = "Edit" Then
                txtRID.ReadOnly = True
                sql = "UPDATE reservation set guestid = '" & cmbGID.Text & "', First_choice_hotel = '" & cmb1st.Text &
                    "', second_choice_hotel = '" & cmb2nd.Text & "', check_in_time = '" & txtTimeIn.Text & "', check_out_time = '" & txtTimeOut.Text &
                    "', check_in_date = '" & dtpDateIn.Value.Date.ToString("yyyy-MM-dd") &
                    "', check_out_date = '" & dtpDateOut.Value.Date.ToString("yyyy-MM-dd") & "', room_type_id = '" & getRoomId(cmbRType.Text) &
                    "', bed_references_id = '" & getBedId(cmbBed.Text) & "', no_of_rooms = '" & txtNroom.Text &
                    "', extra = '" & getExtraValue() & "', no_of_children = '" & txtNOC.Text &
                    "', no_of_adults = '" & txtNOA.Text & "' WHERE reservationid = '" & txtRID.Text &
                    "';"
                con.Open()
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()
                txtRID.ReadOnly = False
            End If
            frmReservation_Load(sender, e)
            txtEmpty()
        Catch ex As Exception
            MsgBox("The input data already exist")
            MsgBox(ex.Message)
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
            txtRID.Text = crow.Cells(0).Value.ToString
            cmbGID.Text = crow.Cells(1).Value
            cmb1st.Text = crow.Cells(2).Value
            cmb2nd.Text = crow.Cells(3).Value
            txtChoice.Text = getHotelChoice(crow.Cells(4).Value)
            txtTimeIn.Text = crow.Cells(5).Value.ToString
            txtTimeOut.Text = crow.Cells(6).Value.ToString
            dtpDateIn.Value = crow.Cells(7).Value.ToString
            dtpDateOut.Value = crow.Cells(8).Value.ToString
            cmbRType.Text = getRoom(crow.Cells(10).Value)
            cmbBed.Text = getBed(crow.Cells(11).Value)
            txtNroom.Text = crow.Cells(12).Value
            clbExtra.Text = crow.Cells(13).Value
            txtNOC.Text = crow.Cells(14).Value
            txtNOA.Text = crow.Cells(15).Value
        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try
    End Sub

    Sub txtTrue()
        txtRID.Enabled = True
        cmbGID.Enabled = True
        cmb1st.Enabled = True
        cmb2nd.Enabled = True
        txtChoice.Enabled = True
        txtTimeIn.Enabled = True
        txtTimeOut.Enabled = True
        dtpDateIn.Enabled = True
        dtpDateOut.Enabled = True
        cmbRType.Enabled = True
        cmbBed.Enabled = True
        txtNroom.Enabled = True
        clbExtra.Enabled = True
        txtNOC.Enabled = True
        txtNOA.Enabled = True
        txtSearch.Enabled = False
    End Sub

    Sub txtFalse()
        txtRID.Enabled = False
        cmbGID.Enabled = False
        cmb1st.Enabled = False
        cmb2nd.Enabled = False
        txtChoice.Enabled = False
        txtTimeIn.Enabled = False
        txtTimeOut.Enabled = False
        dtpDateIn.Enabled = False
        dtpDateOut.Enabled = False
        cmbRType.Enabled = False
        cmbBed.Enabled = False
        txtNroom.Enabled = False
        clbExtra.Enabled = False
        txtNOC.Enabled = False
        txtNOA.Enabled = False
        txtSearch.Enabled = True
    End Sub

    Sub txtEmpty()
        txtRID.Text = ""
        cmbGID.Text = ""
        cmb1st.Text = ""
        cmb2nd.Text = ""
        txtChoice.Text = ""
        txtTimeIn.Text = ""
        txtTimeOut.Text = ""
        dtpDateIn.Text = Now
        dtpDateOut.Text = Now
        cmbRType.Text = ""
        cmbBed.Text = ""
        txtNroom.Text = ""
        clbExtra.Text = ""
        txtNOC.Text = ""
        txtNOA.Text = ""
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
            sql = "Select * from reservation"
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

    Sub loadCmbRoom()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        cmbRType.Items.Clear()
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT room_type FROM room"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmbRType.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub loadCmbBed()
        cmbBed.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT bed_references FROM bed"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmbBed.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Function getHotelChoice(ByVal hID As Integer) As String
        Dim id As String
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(hID)) Then
                cmd = New MySqlCommand("SELECT `hotel_choice` FROM `hotel` WHERE `hotel_choice_id` = @id", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", hID)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("hotel_choice")
                    Return id
                Else
                    MsgBox("No hotel choice available")
                End If
            Else
                MsgBox("Please fill out the hotel choice")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return ""
    End Function

    Function getRoom(ByVal rID As Integer) As String
        Dim id As String
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(rID)) Then
                cmd = New MySqlCommand("SELECT `room_type` FROM `room` WHERE `room_type_id` = @id", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", rID)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("room_type")
                    Return id
                Else
                    MsgBox("No room type available")
                End If
            Else
                MsgBox("Please fill out the room type")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return ""
    End Function

    Function getBed(ByVal bID As Integer) As String
        Dim id As String
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(bID)) Then
                cmd = New MySqlCommand("SELECT `bed_references` FROM `bed` WHERE `bed_references_id` = @id", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", bID)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("bed_references")
                    Return id
                Else
                    MsgBox("No bed references available")
                End If
            Else
                MsgBox("Please fill out the bed references")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return ""
    End Function

    Function getExtraValue() As Integer
        Dim value As Integer = 0
        If clbExtra.GetItemChecked(0) Then
            value += 1
        End If
        If clbExtra.GetItemChecked(1) Then
            value += 2
        End If
        If clbExtra.GetItemChecked(2) Then
            value += 4
        End If
        If clbExtra.GetItemChecked(3) Then
            value += 8
        End If
        Return value
    End Function

    Private Sub cmb1st_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb1st.SelectedIndexChanged
        load2ndHotelChoice()
        Dim re As String = cmb1st.Text
        cmb2nd.Items.Remove(re)
    End Sub

    Function getRoomId(ByVal room As String) As Integer
        Dim id As Integer
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(room)) Then
                cmd = New MySqlCommand("SELECT `room_type_id` FROM `room` WHERE `room_type` = @name", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", room)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("room_type_id")
                    Return id
                Else
                    MsgBox("No room type available")
                End If
            Else
                MsgBox("Please fill out the room type")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return 0
    End Function

    Function getBedId(ByVal bed As String) As Integer
        Dim id As Integer
        Try
            con.Open()
            If (Not String.IsNullOrWhiteSpace(bed)) Then
                cmd = New MySqlCommand("SELECT `bed_references_id` FROM `bed` WHERE `bed_references` = @name", con)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@name", bed)
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    id = dr.Item("bed_references_id")
                    Return id
                Else
                    MsgBox("No bed references available")
                End If
            Else
                MsgBox("Please fill out the bed references")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return 0
    End Function

    Sub load1stHotelChoice()
        cmb1st.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT hotel_choice FROM hotel"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmb1st.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub load2ndHotelChoice()
        cmb2nd.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT hotel_choice FROM hotel"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmb2nd.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub loadGID()
        cmbGID.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT guestid FROM guest"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmbGID.Items.AddRange(items)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class