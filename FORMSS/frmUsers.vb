Imports MySql.Data.MySqlClient
Public Class frmUsers
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

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define the query to fetch cashier data from the database
        dgvUsers.AutoGenerateColumns = True
        txtFalse()
        Dim query As String = "SELECT * from users"

        ' Open a connection to the database
        Using con As New MySqlConnection("server=localhost;user=root;password=;database=cs_hotel_reservation")
            Using cmd As New MySqlCommand(query, con)
                ' Create a DataAdapter to fill the DataTable
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()

                ' Fill the DataTable with the query result
                da.Fill(dt)

                ' Bind the DataTable to the DataGridView
                dgvUsers.DataSource = dt
            End Using
        End Using
    End Sub
    Public Sub Refresh()
        dt.Clear()
        Try
            con.Open()
            sql = "Select * from users"
            With cmd
                .CommandText = sql
                .Connection = con
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            dgvUsers.DataSource = dt
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Refresh()
    End Sub


    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        Dim crow As DataGridViewRow
        Try
            crow = dgvUsers.Rows(e.RowIndex)
            id = crow.Cells(0).Value
            txtCashierId.Text = crow.Cells(1).Value.ToString
            txtUsername.Text = crow.Cells(2).Value
            txtPassword.Text = crow.Cells(3).Value
            txtLastLogin.Text = crow.Cells(4).Value
            txtIsActive.Text = crow.Cells(5).Value
            txtEmail.Text = crow.Cells(6).Value
            txtName.Text = crow.Cells(7).Value
            txtCreated.Text = crow.Cells(8).Value
            txtRole.Text = crow.Cells(9).Value
            txtVerificationCode.Text = crow.Cells(10).Value
            txtVFE.Text = crow.Cells(11).Value
            txtIsVerified.Text = crow.Cells(12).Value

        Catch ex As Exception
            MsgBox("Please properly select within the table")
        End Try
    End Sub

    Sub txtTrue()
        txtCashierId.Enabled = True
        txtUsername.Enabled = True
        txtPassword.Enabled = True
        txtEmail.Enabled = True
        txtName.Enabled = True
        txtRole.Enabled = True
        txtLastLogin.Enabled = True
        txtIsActive.Enabled = True
        txtCreated.Enabled = True
        txtUpdated.Enabled = True
        txtVerificationCode.Enabled = True
        txtVFE.Enabled = True
        txtIsVerified.Enabled = True
    End Sub

    Sub txtFalse()
        txtCashierId.Enabled = False
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        txtEmail.Enabled = False
        txtName.Enabled = False
        txtRole.Enabled = False
        txtLastLogin.Enabled = False
        txtIsActive.Enabled = False
        txtCreated.Enabled = False
        txtUpdated.Enabled = False
        txtVerificationCode.Enabled = False
        txtVFE.Enabled = False
        txtIsVerified.Enabled = False
    End Sub

    Sub txtEmpty()
        txtCashierId.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtEmail.Text = ""
        txtName.Text = ""
        txtRole.Text = ""
        txtLastLogin.Text = ""
        txtIsActive.Text = ""
        txtCreated.Text = ""
        txtUpdated.Text = ""
        txtVerificationCode.Text = ""
        txtVFE.Text = ""
        txtIsVerified.Text = ""
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

            ' Prompt the user for confirmation
            Dim validation = MsgBox("Are you sure you want to delete this user?" + vbNewLine + vbNewLine +
                                 "Username: " + txtUsername.Text + vbNewLine +
                                 "Name: " + txtName.Text + vbNewLine +
                                 "Email: " + txtEmail.Text, vbYesNo)

            If validation = vbYes Then
                ' SQL query to delete the user record
                sql = "DELETE FROM users WHERE username = '" & txtUsername.Text & "';"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()

                ' Close the connection
                con.Close()

                ' Clear the textboxes after deletion
                txtEmpty()

                ' Optionally refresh the data grid or reload the user list
                Refresh()

                ' Optionally show a success message or update UI state
                MsgBox("User deleted successfully.")

                ' Log the deletion action (optional)
                WriteToAuditTrail(_username, $"Deleted user {txtUsername.Text}: Name - {txtName.Text}, Email - {txtEmail.Text}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub btnTrue()
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnDelete.Enabled = False
        btnSearch.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Check if the button click is for adding a new user or editing an existing one
            If btnClick = "Add" Then
                ' Add new user to the database
                con.Open()
                sql = "INSERT INTO users (username, password, email, name, role, isActive) " &
                  "VALUES ('" & txtUsername.Text & "', '" & txtPassword.Text & "', '" & txtEmail.Text & "', '" & txtName.Text & "', '" & txtRole.Text & "', 1)"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()

                ' Write to the audit trail
                WriteToAuditTrail(_username, $"Added new user: Username - {txtUsername.Text}, Name - {txtName.Text}, Email - {txtEmail.Text}, Role - {txtRole.Text}")

            ElseIf btnClick = "Edit" Then
                ' Update existing user details
                con.Open()
                sql = "UPDATE users SET " &
                  "username = '" & txtUsername.Text & "', " &
                  "password = '" & txtPassword.Text & "', " &
                  "email = '" & txtEmail.Text & "', " &
                  "name = '" & txtName.Text & "', " &
                  "role = '" & txtRole.Text & "', " &
                  "isActive = 1 " &
                  "WHERE cashier_id = " & id & ";"
                cmd.Connection = con
                cmd.CommandText = sql
                cmd.CommandType = CommandType.Text
                x = cmd.ExecuteNonQuery()
                con.Close()

                ' Write to the audit trail
                WriteToAuditTrail(_username, $"Updated user ID {id}: Username - {txtUsername.Text}, Name - {txtName.Text}, Email - {txtEmail.Text}, Role - {txtRole.Text}")
            End If

            ' Reload the form to reflect changes
            frmUsers_Load(sender, e)

            ' Clear textboxes after saving
            txtEmpty()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnFalse()
        txtFalse()
        txtEmpty()
    End Sub

    Sub btnFalse()
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnDelete.Enabled = True
        btnSearch.Enabled = True
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