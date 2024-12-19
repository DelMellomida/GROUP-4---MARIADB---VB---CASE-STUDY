Imports MySql.Data.MySqlClient
Public Class frmSummary
    Dim con As New MySqlConnection("server = localhost; user = root; password = ; database =  cs_hotel_reservation; convert zero datetime = true")
    Dim cmd As New MySqlCommand
    Dim dt As New DataTable
    Dim da As New MySqlDataAdapter
    Dim sql, x, btnClick As String
    Dim frmg As New frmGuest(_username, _role)
    Dim gid As String
    Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Private _username As String
    Private _role As String

    Public Sub New(username As String)
        InitializeComponent()
        _username = username
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGuestID()
        allFalse()
    End Sub

    Private Sub cmbRID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRID.SelectedIndexChanged
        Try
            dt.Clear()
            con.Open()
            sql = ("SELECT * FROM TOTALDATA WHERE GUESTID = " & gid & " AND RESERVATIONID = " & cmbRID.Text)
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)

            con.Close()
            txtSuperTotal.Text = "PHP " & Overall()
            txtName.Text = dt.Rows(0).ItemArray(0)
            cmbRID.Text = dt.Rows(0).ItemArray(7)
            txtHotelChoice.Text = dt.Rows(0).ItemArray(34)
            txtCheckInTime.Text = dt.Rows(0).ItemArray(11).ToString()
            txtCheckOutTime.Text = dt.Rows(0).ItemArray(12).ToString()
            txtCheckInDate.Text = dt.Rows(0).ItemArray(13)
            txtCheckOutDate.Text = dt.Rows(0).ItemArray(14)
            txtNoOfNights.Text = dt.Rows(0).ItemArray(15)
            txtRoomType.Text = dt.Rows(0).ItemArray(31)
            txtBedReference.Text = dt.Rows(0).ItemArray(29)
            txtNoOfRooms.Text = dt.Rows(0).ItemArray(18)
            txtExtra.Text = dt.Rows(0).ItemArray(19)
            txtNoOfChildren.Text = dt.Rows(0).ItemArray(20).ToString()
            txtNoOfAdults.Text = dt.Rows(0).ItemArray(21).ToString()
            txtTotalNoGuest.Text = dt.Rows(0).ItemArray(22).ToString()
            txtGender.Text = dt.Rows(0).ItemArray(1)
            txtAddress.Text = dt.Rows(0).ItemArray(3)
            txtCountry.Text = dt.Rows(0).ItemArray(4)
            txtContact.Text = dt.Rows(0).ItemArray(5)
            txtEmail.Text = dt.Rows(0).ItemArray(6)
            txtPaymentMethod.Text = dt.Rows(0).ItemArray(24)
            txtHolderName.Text = dt.Rows(0).ItemArray(25).ToString()
            txtCardNumber.Text = dt.Rows(0).ItemArray(26).ToString()
            txtCVV.Text = dt.Rows(0).ItemArray(27).ToString()
            txtTotalAmount.Text = "PHP " & dt.Rows(0).ItemArray(28).ToString()
            txtDownpayment.Text = "PHP " & dt.Rows(0).ItemArray(33).ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cmbGID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGID.SelectedIndexChanged

        cmbRID.Items.Clear()
        cmbRID.Text = ""
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()

            sql2 = "SELECT guestid FROM guest WHERE name = @name" ' Use a parameterized query

            With cmd2
                .Connection = con
                .CommandText = sql2
                .Parameters.AddWithValue("@name", cmbGID.Text) ' Set the parameter value
            End With
            Try
                Using reader As MySqlDataReader = cmd2.ExecuteReader()
                    If reader.Read() Then
                        gid = reader.GetInt32(0)
                    End If
                End Using ' Ensure reader is closed automatically
            Catch ex As MySqlException
                ' Handle database errors here
            End Try


            sql2 = "SELECT reservationID FROM reservation where guestid = " & gid
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

    Sub loadGuestID()
        Dim dt2 As New DataTable
        Dim da2 As New MySqlDataAdapter
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Try
            dt2.Clear()
            con.Open()
            sql2 = "SELECT name FROM guest"
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Sub allFalse()
        txtHotelChoice.ReadOnly = True
        txtCheckInTime.ReadOnly = True
        txtCheckOutTime.ReadOnly = True
        txtCheckInDate.ReadOnly = True
        txtCheckOutDate.ReadOnly = True
        txtNoOfNights.ReadOnly = True
        txtRoomType.ReadOnly = True
        txtBedReference.ReadOnly = True
        txtNoOfRooms.ReadOnly = True
        txtExtra.ReadOnly = True
        txtNoOfChildren.ReadOnly = True
        txtNoOfAdults.ReadOnly = True
        txtTotalNoGuest.ReadOnly = True
        txtGender.ReadOnly = True
        txtName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCountry.ReadOnly = True
        txtContact.ReadOnly = True
        txtEmail.ReadOnly = True
        txtPaymentMethod.ReadOnly = True
        txtHolderName.ReadOnly = True
        txtCardNumber.ReadOnly = True
        txtCVV.ReadOnly = True
        txtTotalAmount.ReadOnly = True
        txtDownpayment.ReadOnly = True
        txtSuperTotal.ReadOnly = True
    End Sub

    Function Overall()
        Dim cmd2 As New MySqlCommand
        Dim sql2 As String
        Dim exp As Double
        Try
            con.Open()

            sql2 = "SELECT SUM(AMOUNT) FROM EXPENSES WHERE guestid = @gid;" ' Use a parameterized query

            With cmd2
                .Connection = con
                .CommandText = sql2
                .Parameters.AddWithValue("@gid", gid) ' Set the parameter value
            End With
            Try
                Using reader As MySqlDataReader = cmd2.ExecuteReader()
                    If reader.Read() Then
                        exp = reader.GetInt32(0)
                    End If
                End Using ' Ensure reader is closed automatically
            Catch ex As MySqlException
                ' Handle database errors here
            End Try
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            con.Close()
        End Try
        Return exp
    End Function

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

