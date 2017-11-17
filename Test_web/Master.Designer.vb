<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMaster
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
        Me.txtTempMin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTempMax = New System.Windows.Forms.TextBox()
        Me.txtHumidMin = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ptbNG4 = New System.Windows.Forms.PictureBox()
        Me.ptbNG3 = New System.Windows.Forms.PictureBox()
        Me.ptbNG2 = New System.Windows.Forms.PictureBox()
        Me.txtHumidMax = New System.Windows.Forms.TextBox()
        Me.ptbOK2 = New System.Windows.Forms.PictureBox()
        Me.ptbOK3 = New System.Windows.Forms.PictureBox()
        Me.ptbOK4 = New System.Windows.Forms.PictureBox()
        Me.ptbOK1 = New System.Windows.Forms.PictureBox()
        Me.ptbNG1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTempView = New System.Windows.Forms.Label()
        Me.lblHumidView = New System.Windows.Forms.Label()
        Me.rtbEmail = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDaily = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtMp3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nReloadWeb = New System.Windows.Forms.NumericUpDown()
        Me.nCreateLog = New System.Windows.Forms.NumericUpDown()
        Me.nConnection = New System.Windows.Forms.NumericUpDown()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ptbNG4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbNG3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbNG2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOK2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOK3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOK4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOK1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbNG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.nReloadWeb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nCreateLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nConnection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTempMin
        '
        Me.txtTempMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempMin.Location = New System.Drawing.Point(195, 3)
        Me.txtTempMin.Name = "txtTempMin"
        Me.txtTempMin.Size = New System.Drawing.Size(99, 35)
        Me.txtTempMin.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Temp (min)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Temp (max)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 29)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Humid (max)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 29)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Humid (min)"
        '
        'txtTempMax
        '
        Me.txtTempMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTempMax.Location = New System.Drawing.Point(195, 63)
        Me.txtTempMax.Name = "txtTempMax"
        Me.txtTempMax.Size = New System.Drawing.Size(99, 35)
        Me.txtTempMax.TabIndex = 5
        '
        'txtHumidMin
        '
        Me.txtHumidMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHumidMin.Location = New System.Drawing.Point(195, 123)
        Me.txtHumidMin.Name = "txtHumidMin"
        Me.txtHumidMin.Size = New System.Drawing.Size(99, 35)
        Me.txtHumidMin.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(23, 548)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 50)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.38462!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.92308!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.10256!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.13869!))
        Me.TableLayoutPanel1.Controls.Add(Me.ptbNG4, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbNG3, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbNG2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHumidMin, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTempMin, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTempMax, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHumidMax, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbOK2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbOK3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbOK4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbOK1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ptbNG1, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(423, 240)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'ptbNG4
        '
        Me.ptbNG4.Image = Global.Test_web.My.Resources.Resources._1496843635_f_cross_256
        Me.ptbNG4.Location = New System.Drawing.Point(368, 183)
        Me.ptbNG4.Name = "ptbNG4"
        Me.ptbNG4.Size = New System.Drawing.Size(48, 48)
        Me.ptbNG4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbNG4.TabIndex = 20
        Me.ptbNG4.TabStop = False
        Me.ptbNG4.Visible = False
        '
        'ptbNG3
        '
        Me.ptbNG3.Image = Global.Test_web.My.Resources.Resources._1496843635_f_cross_256
        Me.ptbNG3.Location = New System.Drawing.Point(368, 123)
        Me.ptbNG3.Name = "ptbNG3"
        Me.ptbNG3.Size = New System.Drawing.Size(48, 48)
        Me.ptbNG3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbNG3.TabIndex = 19
        Me.ptbNG3.TabStop = False
        Me.ptbNG3.Visible = False
        '
        'ptbNG2
        '
        Me.ptbNG2.Image = Global.Test_web.My.Resources.Resources._1496843635_f_cross_256
        Me.ptbNG2.Location = New System.Drawing.Point(368, 63)
        Me.ptbNG2.Name = "ptbNG2"
        Me.ptbNG2.Size = New System.Drawing.Size(48, 48)
        Me.ptbNG2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbNG2.TabIndex = 18
        Me.ptbNG2.TabStop = False
        Me.ptbNG2.Visible = False
        '
        'txtHumidMax
        '
        Me.txtHumidMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHumidMax.Location = New System.Drawing.Point(195, 183)
        Me.txtHumidMax.Name = "txtHumidMax"
        Me.txtHumidMax.Size = New System.Drawing.Size(99, 35)
        Me.txtHumidMax.TabIndex = 12
        '
        'ptbOK2
        '
        Me.ptbOK2.Image = Global.Test_web.My.Resources.Resources._1496841297_f_check_256
        Me.ptbOK2.Location = New System.Drawing.Point(309, 63)
        Me.ptbOK2.Name = "ptbOK2"
        Me.ptbOK2.Size = New System.Drawing.Size(48, 37)
        Me.ptbOK2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbOK2.TabIndex = 14
        Me.ptbOK2.TabStop = False
        Me.ptbOK2.Visible = False
        '
        'ptbOK3
        '
        Me.ptbOK3.Image = Global.Test_web.My.Resources.Resources._1496841297_f_check_256
        Me.ptbOK3.Location = New System.Drawing.Point(309, 123)
        Me.ptbOK3.Name = "ptbOK3"
        Me.ptbOK3.Size = New System.Drawing.Size(48, 37)
        Me.ptbOK3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbOK3.TabIndex = 15
        Me.ptbOK3.TabStop = False
        Me.ptbOK3.Visible = False
        '
        'ptbOK4
        '
        Me.ptbOK4.Image = Global.Test_web.My.Resources.Resources._1496841297_f_check_256
        Me.ptbOK4.Location = New System.Drawing.Point(309, 183)
        Me.ptbOK4.Name = "ptbOK4"
        Me.ptbOK4.Size = New System.Drawing.Size(48, 37)
        Me.ptbOK4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbOK4.TabIndex = 16
        Me.ptbOK4.TabStop = False
        Me.ptbOK4.Visible = False
        '
        'ptbOK1
        '
        Me.ptbOK1.Image = Global.Test_web.My.Resources.Resources._1496841297_f_check_256
        Me.ptbOK1.Location = New System.Drawing.Point(309, 3)
        Me.ptbOK1.Name = "ptbOK1"
        Me.ptbOK1.Size = New System.Drawing.Size(48, 37)
        Me.ptbOK1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbOK1.TabIndex = 13
        Me.ptbOK1.TabStop = False
        Me.ptbOK1.Visible = False
        '
        'ptbNG1
        '
        Me.ptbNG1.Image = Global.Test_web.My.Resources.Resources._1496843635_f_cross_256
        Me.ptbNG1.Location = New System.Drawing.Point(368, 3)
        Me.ptbNG1.Name = "ptbNG1"
        Me.ptbNG1.Size = New System.Drawing.Size(48, 48)
        Me.ptbNG1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbNG1.TabIndex = 17
        Me.ptbNG1.TabStop = False
        Me.ptbNG1.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.63964!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.36036!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTempView, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblHumidView, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(395, 240)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.Location = New System.Drawing.Point(162, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(227, 75)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "UMC Standard"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 76)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Temp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 77)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Humid"
        '
        'lblTempView
        '
        Me.lblTempView.AutoSize = True
        Me.lblTempView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTempView.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempView.Location = New System.Drawing.Point(162, 81)
        Me.lblTempView.Name = "lblTempView"
        Me.lblTempView.Size = New System.Drawing.Size(227, 76)
        Me.lblTempView.TabIndex = 7
        Me.lblTempView.Text = "dataTemp"
        Me.lblTempView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHumidView
        '
        Me.lblHumidView.AutoSize = True
        Me.lblHumidView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHumidView.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHumidView.Location = New System.Drawing.Point(162, 160)
        Me.lblHumidView.Name = "lblHumidView"
        Me.lblHumidView.Size = New System.Drawing.Size(227, 77)
        Me.lblHumidView.TabIndex = 8
        Me.lblHumidView.Text = "dataHumid"
        Me.lblHumidView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbEmail
        '
        Me.rtbEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbEmail.Location = New System.Drawing.Point(3, 16)
        Me.rtbEmail.Name = "rtbEmail"
        Me.rtbEmail.Size = New System.Drawing.Size(389, 218)
        Me.rtbEmail.TabIndex = 12
        Me.rtbEmail.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 259)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setup"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Location = New System.Drawing.Point(467, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 259)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Preview Result"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rtbEmail)
        Me.GroupBox3.Location = New System.Drawing.Point(473, 290)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(395, 237)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Email send"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(229, 24)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Thời gian load Website (s)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(182, 24)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Thời gian tạo Log (s)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(247, 24)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Thời gian Reset (HH:mm:ss)"
        '
        'txtDaily
        '
        Me.txtDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaily.Location = New System.Drawing.Point(279, 107)
        Me.txtDaily.Name = "txtDaily"
        Me.txtDaily.Size = New System.Drawing.Size(119, 29)
        Me.txtDaily.TabIndex = 7
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.nConnection)
        Me.GroupBox4.Controls.Add(Me.nCreateLog)
        Me.GroupBox4.Controls.Add(Me.nReloadWeb)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtMp3)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtDaily)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 303)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(426, 221)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Extend"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 24)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Nhạc cảnh báo"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(187, 185)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 29)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Choose file"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtMp3
        '
        Me.txtMp3.Enabled = False
        Me.txtMp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMp3.Location = New System.Drawing.Point(279, 186)
        Me.txtMp3.Name = "txtMp3"
        Me.txtMp3.Size = New System.Drawing.Size(119, 29)
        Me.txtMp3.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(266, 24)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Thời gian cảnh báo kết nối (m)"
        '
        'nReloadWeb
        '
        Me.nReloadWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nReloadWeb.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nReloadWeb.Location = New System.Drawing.Point(278, 29)
        Me.nReloadWeb.Maximum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.nReloadWeb.Name = "nReloadWeb"
        Me.nReloadWeb.Size = New System.Drawing.Size(120, 29)
        Me.nReloadWeb.TabIndex = 17
        '
        'nCreateLog
        '
        Me.nCreateLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCreateLog.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nCreateLog.Location = New System.Drawing.Point(278, 72)
        Me.nCreateLog.Maximum = New Decimal(New Integer() {60000, 0, 0, 0})
        Me.nCreateLog.Name = "nCreateLog"
        Me.nCreateLog.Size = New System.Drawing.Size(120, 29)
        Me.nCreateLog.TabIndex = 18
        '
        'nConnection
        '
        Me.nConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nConnection.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nConnection.Location = New System.Drawing.Point(278, 145)
        Me.nConnection.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.nConnection.Name = "nConnection"
        Me.nConnection.Size = New System.Drawing.Size(120, 29)
        Me.nConnection.TabIndex = 19
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(191, 545)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(677, 53)
        Me.WebBrowser1.TabIndex = 17
        '
        'frmMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 610)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmMaster"
        Me.Text = "Master Setup"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.ptbNG4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbNG3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbNG2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOK2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOK3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOK4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOK1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbNG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.nReloadWeb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nCreateLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nConnection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtTempMin As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTempMax As TextBox
    Friend WithEvents txtHumidMin As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtHumidMax As TextBox
    Friend WithEvents ptbOK1 As PictureBox
    Friend WithEvents ptbOK2 As PictureBox
    Friend WithEvents ptbOK3 As PictureBox
    Friend WithEvents ptbOK4 As PictureBox
    Friend WithEvents ptbNG1 As PictureBox
    Friend WithEvents ptbNG4 As PictureBox
    Friend WithEvents ptbNG3 As PictureBox
    Friend WithEvents ptbNG2 As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTempView As Label
    Friend WithEvents lblHumidView As Label
    Friend WithEvents rtbEmail As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDaily As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtMp3 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents nReloadWeb As NumericUpDown
    Friend WithEvents nCreateLog As NumericUpDown
    Friend WithEvents nConnection As NumericUpDown
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
