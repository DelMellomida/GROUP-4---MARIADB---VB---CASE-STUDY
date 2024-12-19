<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVerification))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnResend = New Guna.UI2.WinForms.Guna2Button()
        Me.btnVerify = New Guna.UI2.WinForms.Guna2Button()
        Me.txtCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblRegister = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVerification = New System.Windows.Forms.Label()
        Me.lblResend = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.lblResend)
        Me.GroupBox1.Controls.Add(Me.btnResend)
        Me.GroupBox1.Controls.Add(Me.btnVerify)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.lblRegister)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Controls.Add(Me.lblVerification)
        Me.GroupBox1.Location = New System.Drawing.Point(229, 112)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(513, 382)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnResend
        '
        Me.btnResend.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnResend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnResend.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnResend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnResend.FillColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.btnResend.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.btnResend.ForeColor = System.Drawing.Color.White
        Me.btnResend.Location = New System.Drawing.Point(142, 249)
        Me.btnResend.Name = "btnResend"
        Me.btnResend.Size = New System.Drawing.Size(229, 45)
        Me.btnResend.TabIndex = 10
        Me.btnResend.Text = "Resend"
        '
        'btnVerify
        '
        Me.btnVerify.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnVerify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnVerify.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnVerify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnVerify.FillColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.btnVerify.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.btnVerify.ForeColor = System.Drawing.Color.White
        Me.btnVerify.Location = New System.Drawing.Point(142, 198)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(229, 45)
        Me.btnVerify.TabIndex = 9
        Me.btnVerify.Text = "Verify"
        '
        'txtCode
        '
        Me.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCode.DefaultText = ""
        Me.txtCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCode.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.txtCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCode.Location = New System.Drawing.Point(142, 143)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCode.PlaceholderText = ""
        Me.txtCode.SelectedText = ""
        Me.txtCode.Size = New System.Drawing.Size(229, 48)
        Me.txtCode.TabIndex = 8
        Me.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.lblRegister.Location = New System.Drawing.Point(231, 274)
        Me.lblRegister.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(0, 19)
        Me.lblRegister.TabIndex = 6
        Me.lblRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.lblTitle.Location = New System.Drawing.Point(105, 65)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(327, 19)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Check your email for 6-digit verification code"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVerification
        '
        Me.lblVerification.AutoSize = True
        Me.lblVerification.Font = New System.Drawing.Font("Tahoma", 9.25!)
        Me.lblVerification.Location = New System.Drawing.Point(203, 122)
        Me.lblVerification.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVerification.Name = "lblVerification"
        Me.lblVerification.Size = New System.Drawing.Size(129, 19)
        Me.lblVerification.TabIndex = 0
        Me.lblVerification.Text = "Verification Code"
        Me.lblVerification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblResend
        '
        Me.lblResend.AutoSize = True
        Me.lblResend.Location = New System.Drawing.Point(232, 310)
        Me.lblResend.Name = "lblResend"
        Me.lblResend.Size = New System.Drawing.Size(0, 17)
        Me.lblResend.TabIndex = 11
        '
        'frmVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(983, 554)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmVerification"
        Me.Text = "Verification:"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblRegister As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblVerification As Label
    Friend WithEvents btnVerify As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnResend As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblResend As Label
End Class
