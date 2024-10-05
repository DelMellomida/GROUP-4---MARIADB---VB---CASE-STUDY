<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MAIN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.panelMenu = New System.Windows.Forms.Panel()
        Me.btnSummary = New System.Windows.Forms.Button()
        Me.btnBed = New System.Windows.Forms.Button()
        Me.btnRoom = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnReservation = New System.Windows.Forms.Button()
        Me.btnGuest = New System.Windows.Forms.Button()
        Me.btnHotel = New System.Windows.Forms.Button()
        Me.btnData = New System.Windows.Forms.Button()
        Me.panFrm = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panMenu.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelMenu.SuspendLayout()
        Me.panFrm.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panMenu.BackColor = System.Drawing.Color.Maroon
        Me.panMenu.Controls.Add(Me.btnHome)
        Me.panMenu.Controls.Add(Me.pbLogo)
        Me.panMenu.Location = New System.Drawing.Point(0, 0)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(1146, 51)
        Me.panMenu.TabIndex = 0
        '
        'btnHome
        '
        Me.btnHome.AutoSize = True
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnHome.Location = New System.Drawing.Point(59, -4)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(443, 68)
        Me.btnHome.TabIndex = 1
        Me.btnHome.Text = "HOTEL DE LUNA"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'pbLogo
        '
        Me.pbLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbLogo.Image = Global.GROUP_4___MARIADB___VB___CASE_STUDY.My.Resources.Resources.hotel__4__removebg_preview
        Me.pbLogo.Location = New System.Drawing.Point(-9, -10)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(75, 72)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbLogo.TabIndex = 0
        Me.pbLogo.TabStop = False
        '
        'panelMenu
        '
        Me.panelMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelMenu.Controls.Add(Me.btnSummary)
        Me.panelMenu.Controls.Add(Me.btnBed)
        Me.panelMenu.Controls.Add(Me.btnRoom)
        Me.panelMenu.Controls.Add(Me.btnPayment)
        Me.panelMenu.Controls.Add(Me.btnReservation)
        Me.panelMenu.Controls.Add(Me.btnGuest)
        Me.panelMenu.Controls.Add(Me.btnHotel)
        Me.panelMenu.Controls.Add(Me.btnData)
        Me.panelMenu.Location = New System.Drawing.Point(0, 51)
        Me.panelMenu.Name = "panelMenu"
        Me.panelMenu.Size = New System.Drawing.Size(1147, 52)
        Me.panelMenu.TabIndex = 1
        '
        'btnSummary
        '
        Me.btnSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSummary.FlatAppearance.BorderSize = 0
        Me.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSummary.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSummary.ForeColor = System.Drawing.Color.White
        Me.btnSummary.Location = New System.Drawing.Point(988, 0)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(159, 50)
        Me.btnSummary.TabIndex = 7
        Me.btnSummary.Text = "SUMMARY"
        Me.btnSummary.UseVisualStyleBackColor = False
        '
        'btnBed
        '
        Me.btnBed.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBed.FlatAppearance.BorderSize = 0
        Me.btnBed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBed.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBed.ForeColor = System.Drawing.Color.White
        Me.btnBed.Location = New System.Drawing.Point(849, 0)
        Me.btnBed.Name = "btnBed"
        Me.btnBed.Size = New System.Drawing.Size(139, 50)
        Me.btnBed.TabIndex = 6
        Me.btnBed.Text = "BED"
        Me.btnBed.UseVisualStyleBackColor = False
        '
        'btnRoom
        '
        Me.btnRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnRoom.FlatAppearance.BorderSize = 0
        Me.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoom.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoom.ForeColor = System.Drawing.Color.White
        Me.btnRoom.Location = New System.Drawing.Point(710, 0)
        Me.btnRoom.Name = "btnRoom"
        Me.btnRoom.Size = New System.Drawing.Size(139, 50)
        Me.btnRoom.TabIndex = 5
        Me.btnRoom.Text = "ROOM"
        Me.btnRoom.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnPayment.FlatAppearance.BorderSize = 0
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.White
        Me.btnPayment.Location = New System.Drawing.Point(571, 0)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(139, 52)
        Me.btnPayment.TabIndex = 4
        Me.btnPayment.Text = "PAYMENT"
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnReservation
        '
        Me.btnReservation.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnReservation.FlatAppearance.BorderSize = 0
        Me.btnReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReservation.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReservation.ForeColor = System.Drawing.Color.White
        Me.btnReservation.Location = New System.Drawing.Point(417, 0)
        Me.btnReservation.Name = "btnReservation"
        Me.btnReservation.Size = New System.Drawing.Size(154, 50)
        Me.btnReservation.TabIndex = 3
        Me.btnReservation.Text = "RESERVATION"
        Me.btnReservation.UseVisualStyleBackColor = False
        '
        'btnGuest
        '
        Me.btnGuest.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuest.FlatAppearance.BorderSize = 0
        Me.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuest.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuest.ForeColor = System.Drawing.Color.White
        Me.btnGuest.Location = New System.Drawing.Point(278, 0)
        Me.btnGuest.Name = "btnGuest"
        Me.btnGuest.Size = New System.Drawing.Size(139, 50)
        Me.btnGuest.TabIndex = 2
        Me.btnGuest.Text = "GUEST"
        Me.btnGuest.UseVisualStyleBackColor = False
        '
        'btnHotel
        '
        Me.btnHotel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnHotel.FlatAppearance.BorderSize = 0
        Me.btnHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHotel.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHotel.ForeColor = System.Drawing.Color.White
        Me.btnHotel.Location = New System.Drawing.Point(139, 0)
        Me.btnHotel.Name = "btnHotel"
        Me.btnHotel.Size = New System.Drawing.Size(139, 50)
        Me.btnHotel.TabIndex = 1
        Me.btnHotel.Text = "HOTEL"
        Me.btnHotel.UseVisualStyleBackColor = False
        '
        'btnData
        '
        Me.btnData.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnData.FlatAppearance.BorderSize = 0
        Me.btnData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnData.Font = New System.Drawing.Font("Century Gothic", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnData.ForeColor = System.Drawing.Color.White
        Me.btnData.Location = New System.Drawing.Point(0, 0)
        Me.btnData.Name = "btnData"
        Me.btnData.Size = New System.Drawing.Size(139, 50)
        Me.btnData.TabIndex = 0
        Me.btnData.Text = "DATA"
        Me.btnData.UseVisualStyleBackColor = False
        '
        'panFrm
        '
        Me.panFrm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panFrm.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.panFrm.Controls.Add(Me.PictureBox1)
        Me.panFrm.Location = New System.Drawing.Point(0, 99)
        Me.panFrm.Name = "panFrm"
        Me.panFrm.Size = New System.Drawing.Size(1147, 513)
        Me.panFrm.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.GROUP_4___MARIADB___VB___CASE_STUDY.My.Resources.Resources.hotel__5_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1122, 489)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1146, 610)
        Me.Controls.Add(Me.panFrm)
        Me.Controls.Add(Me.panelMenu)
        Me.Controls.Add(Me.panMenu)
        Me.DoubleBuffered = True
        Me.Name = "MAIN"
        Me.Text = "HOME "
        Me.panMenu.ResumeLayout(False)
        Me.panMenu.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelMenu.ResumeLayout(False)
        Me.panFrm.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents panelMenu As Panel
    Friend WithEvents btnSummary As Button
    Friend WithEvents btnBed As Button
    Friend WithEvents btnRoom As Button
    Friend WithEvents btnPayment As Button
    Friend WithEvents btnReservation As Button
    Friend WithEvents btnGuest As Button
    Friend WithEvents btnHotel As Button
    Friend WithEvents btnData As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents panFrm As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
