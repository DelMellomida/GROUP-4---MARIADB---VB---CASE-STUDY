Imports MySql.Data.MySqlClient
Public Class frmPayment
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, x, btnClick As String
    Private _username As String
    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub
    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTheme()
        btnFalse()
        txtFalse()
        loadRID()
        Refresh()
        txtTotal.ReadOnly = True
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
            Dim validation = MsgBox("Want to delete?" + vbNewLine + vbNewLine + "Receipt ID:" + txtRPID.Text + vbNewLine + "Payment Method:" + cmbPayment.Text + vbNewLine + "Card Holder:" + txtHolder.Text + vbNewLine + "Total Expenses:" + txtTotal.Text, vbYesNo)
            If validation = vbYes Then
                sql = "DELETE FROM  payment WHERE paymentid like '" & txtRPID.Text & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()
                Refresh()
                con.Close()
                btnTrue()

                WriteToAuditTrail(_username, $"Deleted payment: {txtHolder.Text}, Reservation ID: {cmbRID.Text}, Reservation Payment ID: {txtRPID.Text}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            con.Open()
            sql = "Select * from payment where paymentid like '%" & txtSearch.Text & "%' OR reservationid like '%" & txtSearch.Text & "%' OR credit_holder_name like '%" & txtSearch.Text & "%';"
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
                If cmbPayment.Text = "VISA" Then
                    sql = "Insert into payment values ('" & txtRPID.Text &
                    "', '" & cmbRID.Text & "', '" & cmbPayment.Text &
                    "' ," & txtHolder.Text & "', '" & txtCard.Text &
                    "' ," & txtCVV.Text & "', '" & amount(cmbRID.Text) & "')"
                Else
                    sql = "Insert into payment(paymentid, reservationid, payment_method, amount) values ('" & txtRPID.Text &
                    "', '" & cmbRID.Text & "', '" & cmbPayment.Text & "', " & amount(cmbRID.Text) & ")"
                End If
                con.Open()
                    cmd.Connection = con
                    cmd.CommandText = sql
                    cmd.CommandType = CommandType.Text
                    x = cmd.ExecuteNonQuery
                con.Close()

                WriteToAuditTrail(_username, $"Added new payment: {txtHolder.Text}, Reservation ID: {cmbRID.Text}, Reservation Payment ID: {txtRPID.Text}")
            ElseIf btnClick = "Edit" Then
                    txtRPID.ReadOnly = True
                con.Open()
                sql = "UPDATE item set reservationid = '" & cmbRID.Text & "', payment_method = '" & cmbPayment.Text &
                    "', card_holder_name = '" & txtHolder.Text & "', credit_card_number = '" & txtCard.Text &
                    "', CVV = '" & txtCVV.Text & "' WHERE paymentid = '" & txtRPID.Text &
                    "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery
                con.Close()
                txtRPID.ReadOnly = False

                WriteToAuditTrail(_username, $"Updated payment: {txtHolder.Text}, Reservation ID: {cmbRID.Text}, Reservation Payment ID: {txtRPID.Text}")
            End If
            frmPayment_Load(sender, e)
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

    Private Sub dgvDisplay_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDisplay.CellClick
        Dim crow As DataGridViewRow
        Try
            crow = dgvDisplay.Rows(e.RowIndex)
            txtRPID.Text = crow.Cells(0).Value.ToString
            cmbRID.Text = crow.Cells(1).Value.ToString
            cmbPayment.Text = crow.Cells(2).Value.ToString
            txtHolder.Text = crow.Cells(3).Value.ToString
            txtCard.Text = crow.Cells(4).Value.ToString
            txtCVV.Text = crow.Cells(5).Value.ToString
            txtTotal.Text = "PHP " & crow.Cells(6).Value.ToString
        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try
    End Sub

    Sub txtTrue()
        txtRPID.Enabled = True
        cmbRID.Enabled = True
        cmbPayment.Enabled = True
        txtHolder.Enabled = True
        txtCard.Enabled = True
        txtCVV.Enabled = True
        txtTotal.Enabled = True
        txtSearch.Enabled = False
    End Sub

    Sub txtFalse()
        txtRPID.Enabled = False
        cmbRID.Enabled = False
        cmbPayment.Enabled = False
        txtHolder.Enabled = False
        txtCard.Enabled = False
        txtCVV.Enabled = False
        txtTotal.Enabled = False
        txtSearch.Enabled = True
    End Sub

    Sub txtEmpty()
        txtRPID.Text = ""
        cmbRID.Text = ""
        cmbPayment.Text = ""
        txtHolder.Text = ""
        txtCard.Text = ""
        txtCVV.Text = ""
        txtTotal.Text = ""
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
            sql = "Select * from payment"
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

    Function amount(ByVal rid As Integer) As Integer
        Dim total, addroom, rrate, brate, night, down, nroom As Double
        Dim cmd2 As New MySqlCommand
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter

        Try
            con.Open()
            dt2.Clear()
            MsgBox(rid)
            If (Not String.IsNullOrWhiteSpace(rid)) Then
                sql = "SELECT ROOM.ROOM_RATE, RESERVATION.NO_OF_NIGHTS, BED.BED_RATE, RESERVATION.NO_OF_ROOMS, ROOM.DOWNPAYMENT FROM RESERVATION 
                    JOIN BED ON RESERVATION.BED_REFERENCES_ID = BED.BED_REFERENCES_ID
                    JOIN ROOM ON RESERVATION.ROOM_TYPE_ID = ROOM.ROOM_TYPE_ID
                    WHERE RESERVATION.RESERVATIONID = " & rid & ";"
                With cmd2
                    .Connection = con
                    .CommandText = sql
                End With
                da2.SelectCommand = cmd2
                da2.Fill(dt2)

                con.Close()

                addroom = Double.Parse(dt2.Rows(0).ItemArray(3)) - 1.0 * 100.0
                rrate = Double.Parse(dt2.Rows(0).ItemArray(0))
                night = Double.Parse(dt2.Rows(0).ItemArray(1))
                brate = Double.Parse(dt2.Rows(0).ItemArray(2))
                down = Double.Parse(dt2.Rows(0).ItemArray(4))

                total = rrate * night + brate + addroom - down
                Return total
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return 0
    End Function

    Sub loadRID()
        cmbRID.Items.Clear()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT reservationid FROM reservation"
            With cmd2
                .Connection = con
                .CommandText = sql2
            End With
            da2.SelectCommand = cmd2
            da2.Fill(dt2)
            Dim items = dt2.AsEnumerable().Select(Function(d) DirectCast(d(0).ToString(), Object)).ToArray()
            cmbRID.Items.AddRange(items)
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