<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.txtCPassword = New System.Windows.Forms.TextBox()
        Me.txtUname = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblCPassword = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SandyBrown
        Me.GroupBox1.Controls.Add(Me.cmbRole)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.lblRole)
        Me.GroupBox1.Controls.Add(Me.lblError)
        Me.GroupBox1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblLogin)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Controls.Add(Me.btnRegister)
        Me.GroupBox1.Controls.Add(Me.txtCPassword)
        Me.GroupBox1.Controls.Add(Me.txtUname)
        Me.GroupBox1.Controls.Add(Me.lblUsername)
        Me.GroupBox1.Controls.Add(Me.lblCPassword)
        Me.GroupBox1.Location = New System.Drawing.Point(145, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 387)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'cmbRole
        '
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"admin", "cashier"})
        Me.cmbRole.Location = New System.Drawing.Point(294, 136)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(173, 21)
        Me.cmbRole.TabIndex = 17
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(60, 137)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(173, 20)
        Me.txtEmail.TabIndex = 16
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(57, 121)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblEmail.TabIndex = 15
        Me.lblEmail.Text = "Email:"
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(291, 121)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(32, 13)
        Me.lblRole.TabIndex = 13
        Me.lblRole.Text = "Role:"
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(96, 226)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(320, 82)
        Me.lblError.TabIndex = 12
        Me.lblError.Text = "Please input a valid password to properly proceed"
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(99, 360)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(3, 2)
        Me.Guna2HtmlLabel1.TabIndex = 11
        Me.Guna2HtmlLabel1.Text = Nothing
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(60, 84)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(173, 20)
        Me.txtName.TabIndex = 10
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(57, 68)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Name:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(60, 191)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(173, 20)
        Me.txtPassword.TabIndex = 8
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(57, 175)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Password:"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(245, 346)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(33, 13)
        Me.lblLogin.TabIndex = 6
        Me.lblLogin.Text = "Login"
        Me.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(203, 27)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(127, 25)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Hello Admin"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(176, 311)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(173, 23)
        Me.btnRegister.TabIndex = 4
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'txtCPassword
        '
        Me.txtCPassword.Location = New System.Drawing.Point(294, 191)
        Me.txtCPassword.Name = "txtCPassword"
        Me.txtCPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtCPassword.Size = New System.Drawing.Size(173, 20)
        Me.txtCPassword.TabIndex = 3
        '
        'txtUname
        '
        Me.txtUname.Location = New System.Drawing.Point(294, 84)
        Me.txtUname.Name = "txtUname"
        Me.txtUname.Size = New System.Drawing.Size(173, 20)
        Me.txtUname.TabIndex = 2
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(291, 68)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'lblCPassword
        '
        Me.lblCPassword.AutoSize = True
        Me.lblCPassword.Location = New System.Drawing.Point(291, 175)
        Me.lblCPassword.Name = "lblCPassword"
        Me.lblCPassword.Size = New System.Drawing.Size(94, 13)
        Me.lblCPassword.TabIndex = 1
        Me.lblCPassword.Text = "Confirm Password:"
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRegister"
        Me.Text = "frmRegister"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtCPassword As TextBox
    Friend WithEvents txtUname As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblCPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblError As Label
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents cmbRole As ComboBox
End Class
