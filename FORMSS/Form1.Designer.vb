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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnResend = New System.Windows.Forms.Button()
        Me.lblRegister = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblVerification = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.SandyBrown
        Me.GroupBox1.Controls.Add(Me.btnResend)
        Me.GroupBox1.Controls.Add(Me.lblRegister)
        Me.GroupBox1.Controls.Add(Me.lblTitle)
        Me.GroupBox1.Controls.Add(Me.btnLogin)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.lblVerification)
        Me.GroupBox1.Location = New System.Drawing.Point(208, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 256)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnResend
        '
        Me.btnResend.Location = New System.Drawing.Point(109, 213)
        Me.btnResend.Name = "btnResend"
        Me.btnResend.Size = New System.Drawing.Size(173, 23)
        Me.btnResend.TabIndex = 7
        Me.btnResend.Text = "Resend"
        Me.btnResend.UseVisualStyleBackColor = True
        '
        'lblRegister
        '
        Me.lblRegister.AutoSize = True
        Me.lblRegister.Location = New System.Drawing.Point(173, 223)
        Me.lblRegister.Name = "lblRegister"
        Me.lblRegister.Size = New System.Drawing.Size(0, 13)
        Me.lblRegister.TabIndex = 6
        Me.lblRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(136, 34)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(119, 25)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Verification"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(109, 187)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(173, 23)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Verify"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(109, 116)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(173, 20)
        Me.txtCode.TabIndex = 2
        '
        'lblVerification
        '
        Me.lblVerification.AutoSize = True
        Me.lblVerification.Location = New System.Drawing.Point(152, 99)
        Me.lblVerification.Name = "lblVerification"
        Me.lblVerification.Size = New System.Drawing.Size(87, 13)
        Me.lblVerification.TabIndex = 0
        Me.lblVerification.Text = "Verification Code"
        Me.lblVerification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmVerification"
        Me.Text = "Verification:"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblRegister As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtCode As TextBox
    Friend WithEvents lblVerification As Label
    Friend WithEvents btnResend As Button
End Class
