Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text

Public Class frmMain
    Dim Temp(20) As Double
    Dim humd(20) As Long
    Const ALARM_AG As Integer = 30
    'Dim time(3) As String
    Dim alarm_again As Integer = ALARM_AG
    Dim i As Integer = 0
    'Dim count As Integer = 0
    Dim tempMin As Double
    Dim tempMax As Double
    Dim humidMin As Integer
    Dim humidMax As Integer
    Dim filePath As String = My.Application.Info.DirectoryPath & "\Setup\DataConfig.txt"
    Dim lstObjLog As List(Of ObjLog) = New List(Of ObjLog)
    Dim no As Integer = 0
    Dim tempArea As List(Of String) = New List(Of String)
    Dim listEmail As List(Of String)
    Dim listArea As List(Of ObjLog)
    Dim flag(20) As Boolean
    Dim PRINT_TEMP_MIN As Integer = 22
    Dim PRINT_TEMP_MAX As Integer = 28
    Dim PRINT_HUMID_MIN As Integer = 40
    Dim PRINT_HUMID_MAX As Integer = 60
    Dim tempRange As String
    Dim humidRange As String
    Dim TIMEOUT As Integer = 59
    Dim COUNT_ALARM As Integer
    Private Sub ReadfromWEB()

        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            RichTextBox1.Text = WebBrowser1.Document.Body.InnerText

            If (RichTextBox1.Lines(2) <> "Password") Then
                Dim element As HtmlElementCollection = Nothing
                Dim lsts = New List(Of String)

                element = WebBrowser1.Document.GetElementsByTagName("td")
                For Each item As HtmlElement In element
                    If item.GetAttribute("classname") = "upper" And item.OuterText <> "" And item.OuterText <> "UMC" Then
                        lsts.Add(item.OuterText)
                    End If
                Next
                Dim temp1 = lsts.GetRange(1, 3)
                listArea = New List(Of ObjLog)
                While lsts.Count > 0

                    tempArea = lsts.GetRange(0, 3)
                    Dim area = Common.getBetween(tempArea(0), "", " ")
                    Dim temp = Common.getBetween(tempArea(2), "[Temp]", "c").Trim
                    Dim humid = Common.getBetween(tempArea(2), "[Humid]", "%").Trim
                    Dim time = tempArea(1)
                    Dim objArea As ObjLog = New ObjLog(area, temp, humid, time)

                    listArea.Add(objArea)
                    lsts.RemoveRange(0, 3)
                End While
                Try
                    lblMc1Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("MC"))._temp & " C"
                    lblMc1Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("MC"))._humid & " %"

                    lblPc1Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PC"))._temp & " C"
                    lblPc1Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PC"))._humid & " %"

                    lblPd1SmtTemp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SMT"))._temp & " C"
                    lblPd1SmtHumid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SMT"))._humid & " %"

                    lblMc2Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("MC2"))._temp & " C"
                    lblMc2Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("MC2"))._humid & " %"

                    lblPc2Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PC2"))._temp & " C"
                    lblPc2Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PC2"))._humid & " %"

                    lblPd2SmtTemp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_SMT"))._temp & " C"
                    lblPd2SmtHumid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_SMT"))._humid & " %"

                    lblPd2Pu11Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_1"))._temp & " C"
                    lblPd2Pu11Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_1"))._humid & " %"

                    lblPd2Pu12Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_2"))._temp & " C"
                    lblPd2Pu12Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_2"))._humid & " %"

                    lblPd1Fat1Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_1"))._temp & " C"
                    lblPd1Fat1Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_1"))._humid & " %"

                    lblPd1Fat2Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_2"))._temp & " C"
                    lblPd1Fat2Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_2"))._humid & " %"

                    lblPd1SpotTemp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SPOT"))._temp & " C"
                    lblPd1SpotHumid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SPOT"))._humid & " %"

                    lblPd1Print1Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_1"))._temp & " C"
                    lblPd1Print1Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_1"))._humid & " %"

                    lblPd1Print2Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_2"))._temp & " C"
                    lblPd1Print2Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_2"))._humid & " %"

                    lblPd1Print3Temp.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_3"))._temp & " C"
                    lblPd1Print3Humid.Text = listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_3"))._humid & " %"

                Catch ex As Exception
                    MessageBox.Show("Bạn đã thay đổi thông tin trên website", "Liên hệ Quyết LCA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Close()
                End Try
                'temp of MC1
                Temp(1) = Microsoft.VisualBasic.Left(lblMc1Temp.Text, 4)
                'temp of PC1
                Temp(2) = Microsoft.VisualBasic.Left(lblPc1Temp.Text, 4)
                'temp of PD1-1
                Temp(3) = Microsoft.VisualBasic.Left(lblPd1SmtTemp.Text, 4)
                'temp of MC2
                Temp(4) = Microsoft.VisualBasic.Left(lblMc2Temp.Text, 4)
                'temp of PC2
                Temp(5) = Microsoft.VisualBasic.Left(lblPc2Temp.Text, 4)
                'temp of PD2_SMT
                Temp(6) = Microsoft.VisualBasic.Left(lblPd2SmtTemp.Text, 4)
                'temp of PD2_PU1_1
                Temp(7) = Microsoft.VisualBasic.Left(lblPd2Pu11Temp.Text, 4)
                'temp of PD2_PU1_2
                Temp(8) = Microsoft.VisualBasic.Left(lblPd2Pu12Temp.Text, 4)
                'temp of PD1_FAT_1
                Temp(9) = Microsoft.VisualBasic.Left(lblPd1Fat1Temp.Text, 4)
                'temp of PD1_FAT_2
                Temp(10) = Microsoft.VisualBasic.Left(lblPd1Fat2Temp.Text, 4)
                'temp of PD1_SPOT
                Temp(11) = Microsoft.VisualBasic.Left(lblPd1SpotTemp.Text, 4)
                'temp of PD1_PRINT_1
                Temp(12) = Microsoft.VisualBasic.Left(lblPd1Print1Temp.Text, 4)
                'temp of PD1_PRINT_2
                Temp(13) = Microsoft.VisualBasic.Left(lblPd1Print2Temp.Text, 4)
                'temp of PD1_PRINT_3
                Temp(14) = Microsoft.VisualBasic.Left(lblPd1Print3Temp.Text, 4)

                humd(1) = Mid(lblMc1Humid.Text, 1, 3)
                humd(2) = Mid(lblPc1Humid.Text, 1, 3)
                humd(3) = Mid(lblPd1SmtHumid.Text, 1, 3)
                humd(4) = Mid(lblMc2Humid.Text, 1, 3)
                humd(5) = Mid(lblPc2Humid.Text, 1, 3)
                humd(6) = Mid(lblPd2SmtHumid.Text, 1, 3)
                humd(7) = Mid(lblPd2Pu11Humid.Text, 1, 3)
                humd(8) = Mid(lblPd2Pu12Humid.Text, 1, 3)
                humd(9) = Mid(lblPd1Fat1Humid.Text, 1, 3)
                humd(10) = Mid(lblPd1Fat2Humid.Text, 1, 3)
                humd(11) = Mid(lblPd1SpotHumid.Text, 1, 3)
                humd(12) = Mid(lblPd1Print1Humid.Text, 1, 3)
                humd(13) = Mid(lblPd1Print2Humid.Text, 1, 3)
                humd(14) = Mid(lblPd1Print3Humid.Text, 1, 3)

            Else
                login()
            End If

        End If

    End Sub
    Private Sub login()

        Dim doc As HtmlDocument = WebBrowser1.Document
        Dim elements As HtmlElementCollection = doc.GetElementsByTagName("input")

        For Each element As HtmlElement In elements
            If element.Name = "lid" Then
                element.SetAttribute("value", "tdgd9370")
            End If

            If element.Name = "lpd" Then
                element.SetAttribute("value", "cuongadn90")
            End If

            If element.Name = "" Then
                element.InvokeMember("click")
            End If
        Next

    End Sub
    Private Sub check_alarm()
        If lstObjLog.Count = 0 Then
            no = 1
        End If
        If COUNT_ALARM = 18 Then
            COUNT_ALARM = 0
        End If
        '-----------------------------------------------------------------------------------------------------------
        lblMc1Temp.ForeColor = If(Temp(1) >= tempMin And Temp(1) <= tempMax, Color.Blue, Color.Red)
        lblMc1Humid.ForeColor = If(humd(1) >= humidMin And humd(1) <= humidMax, Color.Blue, Color.Red)

        If lblMc1Temp.ForeColor = Color.Blue And lblMc1Humid.ForeColor = Color.Blue Then
            PictureBox2.Image = Image.FromFile("OK.jpg")
            flag(1) = True
        Else
            PictureBox2.Image = Image.FromFile("NG.jpg")
            flag(1) = False
        End If

        '-----------------------------------------------------------------------------------------------------------
        lblPc1Temp.ForeColor = If(Temp(2) >= tempMin And Temp(2) <= tempMax, Color.Blue, Color.Red)
        lblPc1Humid.ForeColor = If(humd(2) >= humidMin And humd(2) <= humidMax, Color.Blue, Color.Red)

        If lblPc1Temp.ForeColor = Color.Blue And lblPc1Humid.ForeColor = Color.Blue Then
            PictureBox4.Image = Image.FromFile("OK.jpg")
            flag(2) = True
        Else
            PictureBox4.Image = Image.FromFile("NG.jpg")
            flag(2) = False
        End If
        '...............................................................................................................
        lblPd1SmtTemp.ForeColor = If(Temp(3) >= tempMin And Temp(3) <= tempMax, Color.Blue, Color.Red)
        lblPd1SmtHumid.ForeColor = If(humd(3) >= humidMin And humd(3) <= humidMax, Color.Blue, Color.Red)

        If lblPd1SmtTemp.ForeColor = Color.Blue And lblPd1SmtHumid.ForeColor = Color.Blue Then
            PictureBox6.Image = Image.FromFile("OK.jpg")
            flag(3) = True
        Else
            PictureBox6.Image = Image.FromFile("NG.jpg")
            flag(3) = False
        End If
        '---------------------------------------------------------------------------------------------------------------

        lblMc2Temp.ForeColor = If(Temp(4) >= tempMin And Temp(4) <= tempMax, Color.Blue, Color.Red)
        lblMc2Humid.ForeColor = If(humd(4) >= humidMin And humd(4) <= humidMax, Color.Blue, Color.Red)
        If lblMc2Temp.ForeColor = Color.Blue And lblMc2Humid.ForeColor = Color.Blue Then
            PictureBox3.Image = Image.FromFile("OK.jpg")
            flag(4) = True
        Else
            PictureBox3.Image = Image.FromFile("NG.jpg")
            flag(4) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPc2Temp.ForeColor = If(Temp(5) >= tempMin And Temp(5) <= tempMax, Color.Blue, Color.Red)
        lblPc2Humid.ForeColor = If(humd(5) >= humidMin And humd(5) <= humidMax, Color.Blue, Color.Red)

        If lblPc2Temp.ForeColor = Color.Blue And lblPc2Humid.ForeColor = Color.Blue Then
            PictureBox5.Image = Image.FromFile("OK.jpg")
            flag(5) = True
        Else
            PictureBox5.Image = Image.FromFile("NG.jpg")
            flag(5) = False
        End If
        '---------------------------------------------------------------------------------------------------------------

        lblPd2SmtTemp.ForeColor = If(Temp(6) >= tempMin And Temp(6) <= tempMax, Color.Blue, Color.Red)
        lblPd2SmtHumid.ForeColor = If(humd(6) >= humidMin And humd(6) <= humidMax, Color.Blue, Color.Red)

        If lblPd2SmtTemp.ForeColor = Color.Blue And lblPd2SmtHumid.ForeColor = Color.Blue Then
            PictureBox9.Image = Image.FromFile("OK.jpg")
            flag(6) = True
        Else
            PictureBox9.Image = Image.FromFile("NG.jpg")
            flag(6) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd2Pu11Temp.ForeColor = If(Temp(7) >= tempMin And Temp(7) <= tempMax, Color.Blue, Color.Red)
        lblPd2Pu11Humid.ForeColor = If(humd(7) >= humidMin And humd(7) <= humidMax, Color.Blue, Color.Red)

        If lblPd2Pu11Temp.ForeColor = Color.Blue And lblPd2Pu11Humid.ForeColor = Color.Blue Then
            PictureBox10.Image = Image.FromFile("OK.jpg")
            flag(7) = True
        Else
            PictureBox10.Image = Image.FromFile("NG.jpg")
            flag(7) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd2Pu12Temp.ForeColor = If(Temp(8) >= tempMin And Temp(8) <= tempMax, Color.Blue, Color.Red)
        lblPd2Pu12Humid.ForeColor = If(humd(8) >= humidMin And humd(8) <= humidMax, Color.Blue, Color.Red)

        If lblPd2Pu12Temp.ForeColor = Color.Blue And lblPd2Pu12Humid.ForeColor = Color.Blue Then
            PictureBox11.Image = Image.FromFile("OK.jpg")
            flag(8) = True
        Else
            PictureBox11.Image = Image.FromFile("NG.jpg")
            flag(8) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Fat1Temp.ForeColor = If(Temp(9) >= tempMin And Temp(9) <= tempMax, Color.Blue, Color.Red)
        lblPd1Fat1Humid.ForeColor = If(humd(9) >= humidMin And humd(9) <= humidMax, Color.Blue, Color.Red)

        If lblPd1Fat1Temp.ForeColor = Color.Blue And lblPd1Fat1Humid.ForeColor = Color.Blue Then
            PictureBox7.Image = Image.FromFile("OK.jpg")
            flag(9) = True
        Else
            PictureBox7.Image = Image.FromFile("NG.jpg")
            flag(9) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Fat2Temp.ForeColor = If(Temp(10) >= tempMin And Temp(10) <= tempMax, Color.Blue, Color.Red)
        lblPd1Fat2Humid.ForeColor = If(humd(10) >= humidMin And humd(10) <= humidMax, Color.Blue, Color.Red)

        If lblPd1Fat2Temp.ForeColor = Color.Blue And lblPd1Fat2Humid.ForeColor = Color.Blue Then
            PictureBox8.Image = Image.FromFile("OK.jpg")
            flag(10) = True
        Else
            PictureBox8.Image = Image.FromFile("NG.jpg")
            flag(10) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1SpotTemp.ForeColor = If(Temp(11) >= tempMin And Temp(11) <= tempMax, Color.Blue, Color.Red)
        lblPd1SpotHumid.ForeColor = If(humd(11) >= humidMin And humd(11) <= humidMax, Color.Blue, Color.Red)

        If lblPd1SpotTemp.ForeColor = Color.Blue And lblPd1SpotHumid.ForeColor = Color.Blue Then
            PictureBox12.Image = Image.FromFile("OK.jpg")
            flag(11) = True
        Else
            PictureBox12.Image = Image.FromFile("NG.jpg")
            flag(11) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print1Temp.ForeColor = If(Temp(12) >= PRINT_TEMP_MIN And Temp(12) <= PRINT_TEMP_MAX, Color.Blue, Color.Red)
        lblPd1Print1Humid.ForeColor = If(humd(12) >= PRINT_HUMID_MIN And humd(12) <= PRINT_HUMID_MAX, Color.Blue, Color.Red)

        If lblPd1Print1Temp.ForeColor = Color.Blue And lblPd1Print1Humid.ForeColor = Color.Blue Then
            PictureBox13.Image = Image.FromFile("OK.jpg")
            flag(12) = True
        Else
            PictureBox13.Image = Image.FromFile("NG.jpg")
            flag(12) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print2Temp.ForeColor = If(Temp(13) >= PRINT_TEMP_MIN And Temp(13) <= PRINT_TEMP_MAX, Color.Blue, Color.Red)
        lblPd1Print2Humid.ForeColor = If(humd(13) >= PRINT_HUMID_MIN And humd(13) <= PRINT_HUMID_MAX, Color.Blue, Color.Red)

        If lblPd1Print2Temp.ForeColor = Color.Blue And lblPd1Print2Humid.ForeColor = Color.Blue Then
            PictureBox14.Image = Image.FromFile("OK.jpg")
            flag(13) = True
        Else
            PictureBox14.Image = Image.FromFile("NG.jpg")
            flag(13) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print3Temp.ForeColor = If(Temp(14) >= PRINT_TEMP_MIN And Temp(14) <= PRINT_TEMP_MAX, Color.Blue, Color.Red)
        lblPd1Print3Humid.ForeColor = If(humd(14) >= PRINT_HUMID_MIN And humd(14) <= PRINT_HUMID_MAX, Color.Blue, Color.Red)

        If lblPd1Print3Temp.ForeColor = Color.Blue And lblPd1Print3Humid.ForeColor = Color.Blue Then
            PictureBox15.Image = Image.FromFile("OK.jpg")
            flag(14) = True
        Else
            PictureBox15.Image = Image.FromFile("NG.jpg")
            flag(14) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        'Label36.Text = alarm_again
        If flag(1) = False Or flag(2) = False Or flag(3) = False Or flag(4) = False Or flag(5) = False Or flag(6) = False Or flag(7) = False Or flag(8) = False Or flag(9) = False Or flag(10) = False Or flag(11) = False Then
            Label35.ForeColor = Color.Red
            Label35.Text = "Alarm"
            Timer2.Enabled = True
            'If alarm_again <= 0 Then
            '    alarm_again = ALARM_AG
            'End If
            If COUNT_ALARM = 0 Then
                'i = i + 1
                AxWindowsMediaPlayer1.Ctlcontrols.play()


                If flag(1) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH: mm:ss"), lblMc1.Text, lblMc1Temp.Text, lblMc1Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If

                If flag(2) = False Then
                    'areaAlarm = areaAlarm & Microsoft.VisualBasic.Left(grPC.Text, 2) & " "
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPc1.Text, lblPc1Temp.Text, lblPc1Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(3) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Smt.Text, lblPd1SmtTemp.Text, lblPd1SmtHumid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                    'areaAlarm &= Microsoft.VisualBasic.Left(grPD1.Text, 3) & " "
                End If
                If flag(4) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblMc2.Text, lblMc2Temp.Text, lblMc2Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(5) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPc2.Text, lblPc2Temp.Text, lblPc2Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(6) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd2Smt.Text, lblPd2SmtTemp.Text, lblPd2SmtHumid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(7) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd2Pu11.Text, lblPd2Pu11Temp.Text, lblPd2Pu11Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(8) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd2Pu12.Text, lblPd2Pu12Temp.Text, lblPd2Pu12Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                If flag(9) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Fat1.Text, lblPd1Fat1Temp.Text, lblPd1Fat1Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If

                If flag(10) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Fat2.Text, lblPd1Fat2Temp.Text, lblPd1Fat2Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If

                If flag(11) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Spot.Text, lblPd1SpotTemp.Text, lblPd1SpotHumid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                'If flag(12) = False Then
                '    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Print1.Text, lblPd1Print1Temp.Text, lblPd1Print1Humid.Text)
                '    lstObjLog.Add(objLog)
                '    no = no + 1
                'End If
                'If flag(13) = False Then
                '    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Print2.Text, lblPd1Print2Temp.Text, lblPd1Print2Humid.Text)
                '    lstObjLog.Add(objLog)
                '    no = no + 1
                'End If
                'If flag(14) = False Then
                '    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPd1Print3.Text, lblPd1Print3Temp.Text, lblPd1Print3Humid.Text)
                '    lstObjLog.Add(objLog)
                '    no = no + 1
                'End If
                'quyet
                Dim content As StringBuilder = New StringBuilder
                For Each obj In lstObjLog
                    content.Append("<tr>")
                    content.Append(String.Format("<td>{0}</td>", obj._no))
                    content.Append(String.Format("<td>{0}</td>", obj._time))
                    content.Append(String.Format("<td>{0}</td>", obj._area))
                    If Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) < Convert.ToDouble(tempMin) Or Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) > Convert.ToDouble(tempMax) Then
                        content.Append(String.Format("<td style='background-color: Red'>{0}</td>", obj._temp))
                    Else
                        content.Append(String.Format("<td>{0}</td>", obj._temp))
                    End If
                    If Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) < Convert.ToInt32(humidMin) Or Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) > Convert.ToInt32(humidMax) Then
                        content.Append(String.Format("<td style='background-color: Red'>{0}</td>", obj._humid))
                    Else
                        content.Append(String.Format("<td>{0}</td>", obj._humid))
                    End If
                    content.Append("</tr>")
                Next
                ' Create log alarm
                Dim outFile As IO.StreamWriter
                Dim csvFileAlarmbk As String = My.Application.Info.DirectoryPath & "\Backup\" & Now.ToString("yyyyMM") & "_Alarm_backup.csv"

                Try
                    outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFileAlarmbk, True)
                    For Each obj In lstObjLog
                        Dim sttTemp As String = "OK"
                        Dim sttHumid As String = "OK"
                        If Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) < Convert.ToDouble(tempMin) Or Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) > Convert.ToDouble(tempMax) Then
                            sttTemp = "NG"
                        End If
                        If Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) < Convert.ToInt32(humidMin) Or Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) > Convert.ToInt32(humidMax) Then
                            sttHumid = "NG"
                        End If
                        outFile.WriteLine(Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & obj._area & "," & obj._temp & " (" & sttTemp & ")" & "," & obj._humid & " (" & sttHumid & ")")
                    Next
                    outFile.Close()
                Catch ex As Exception
                    MessageBox.Show("Đóng file backup để tiến hành ghi Log")
                End Try
                'Check file 
                Dim csvFileAlarm As String = My.Application.Info.DirectoryPath & "\Log_Alarm\" & Now.ToString("yyyyMM") & "_Alarm.csv"
                If Common.CompareFiles(csvFileAlarm, csvFileAlarmbk) = False Then
                    Try
                        File.Copy(csvFileAlarmbk, csvFileAlarm, True)
                    Catch ex As Exception
                        ' Hiển thị thông báo trong trường hợp file đang mở
                    End Try
                End If
                ' Send mail
#Region "Auto send mail"

                If content.Length <> 0 Then
                    Dim emailContent As New StringBuilder()
                    emailContent.Append("
                            <!DOCTYPE html>
                            <html>
                            <head>
                	        <style>
                                table, th, td {
                                    border: 1px solid black;
                                    border-collapse: collapse;
                                               }
                                th, td {
                                padding: 5px;
                                        }
                            </style>
                            </head>
                            <body>
                            <h3>Dear Mr.</h3>
                            <h4>The list alarm Temp and Humid in UMCVN</h4>
                            <h4>Danh sách cảnh báo nhiệt độ và độ ẩm tại UMCVN</h4>
                            <table width = '100%' >
                            <tr style='background: #99CCFF'>
                            <th>No</th>
                            <th>Time</th>
                            <th>Area</th>
                                            ")
                    emailContent.Append(String.Format("<th>{0}</th>", "Temp (Standar) " & tempRange))
                    emailContent.Append(String.Format("<th>{0}</th>", "Humid (Standar) " & humidRange))
                    emailContent.Append("</tr>")
                    'emailContent.Append(String.Format("<th>{0}</th>", content))
                    emailContent.Append(content)
                    emailContent.Append("</table>")
                    emailContent.Append("<h3>Chi tiết xem tại</h3>")
                    emailContent.Append("http://172.28.13.2:9999/")
                    emailContent.Append("<h5>Thanks and Best Regards!</h5>
                            <h5>--------------------------------</h5>
                            <h5>LCA - VN</h5>
                            <h3>UMC Electronics Vietnam Co., Ltd</h3>
                            <h5>Production Engineering Department</h5>
                            <h5>Add: Tan Truong IZ, Cam Giang Dist, Hai Duong Pro, Viet Nam</h5>
                            <h5>Tel: 0084-320-3570001</h5>")
                    emailContent.Append("
                            </body>
                            </html>")
                    Common.SendListEmail(listEmail, emailContent)
                End If

                WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, content)
#End Region
            End If
            'alarm_again = alarm_again - 1

        Else

            Label35.ForeColor = Color.Blue
            Label35.Text = "OK"
            Timer2.Enabled = False
            alarm_again = ALARM_AG               '30 phut alarm lai 1 lan/
            AxWindowsMediaPlayer1.Ctlcontrols.stop()

        End If
        COUNT_ALARM = COUNT_ALARM + 1

    End Sub
    Private Sub alarm()
        If Label35.Text = "Alarm" Then
            Label35.Text = ""
        Else
            Label35.Text = "Alarm"
        End If
    End Sub
    Private Sub Daily_log()
        'Declare Ca
        Dim ca As String
        ca = If(Now.Hour >= 8 And Now.Hour <= 20, "HC", "D")
        'Khai báo thư mục chứa file lưu STT
        'Dim textFile As String = My.Application.Info.DirectoryPath & "\Setup\State.txt"

        'Dim temp = Convert.ToInt32(Common.ReadTextFile(textFile, 2))
        ''Nếu file text chưa có giá trị thì tăng biến count
        'If temp = 0 Then
        '    count = count + 1
        'Else count = Convert.ToInt32(Common.ReadTextFile(textFile, 2)) + 1
        'End If
#Region "Create Report"
        Dim outFile As IO.StreamWriter
        '**********************************************************************************************************************
        'MC1
        Dim csvFileMCbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblMc1.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        ' Create Header
        If File.Exists(csvFileMCbk) = False Then
            File.Create(csvFileMCbk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFileMCbk, True)
            outFile.WriteLine("Area name:," & lblMc1.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()

        End If
        If File.Exists(csvFileMCbk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFileMCbk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblMc1Temp.Text & "," & lblMc1Humid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************

        'PC1
        Dim csvFilePCbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPc1.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePCbk) = False Then
            File.Create(csvFilePCbk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePCbk, True)
            outFile.WriteLine("Area name:," & lblPc1.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePCbk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePCbk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPc1Temp.Text & "," & lblPc1Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************

        'PD1-SMT
        Dim csvFilePd1Smtbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Smt.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Smtbk) = False Then
            File.Create(csvFilePd1Smtbk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Smtbk, True)
            outFile.WriteLine("Area name:," & lblPd1Smt.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Smtbk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Smtbk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1SmtTemp.Text & "," & lblPd1SmtHumid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'MC2
        Dim csvFileMC2bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblMc2.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFileMC2bk) = False Then
            File.Create(csvFileMC2bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFileMC2bk, True)
            outFile.WriteLine("Area name:," & lblMc2.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFileMC2bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFileMC2bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblMc2Temp.Text & "," & lblMc2Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PC2
        Dim csvFilePC2bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPc2.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePC2bk) = False Then
            File.Create(csvFilePC2bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePC2bk, True)
            outFile.WriteLine("Area name:," & lblPc2.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePC2bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePC2bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPc2Temp.Text & "," & lblPc2Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD2_SMT
        Dim csvFilePd2Smtbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd2Smt.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd2Smtbk) = False Then
            File.Create(csvFilePd2Smtbk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Smtbk, True)
            outFile.WriteLine("Area name:," & lblPd2Smt.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd2Smtbk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Smtbk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd2SmtTemp.Text & "," & lblPd2SmtHumid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        ' PD2_PU1_1
        Dim csvFilePd2Pu11bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd2Pu11.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd2Pu11bk) = False Then
            File.Create(csvFilePd2Pu11bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Pu11bk, True)
            outFile.WriteLine("Area name:," & lblPd2Pu11.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd2Pu11bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Pu11bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Fat1Temp.Text & "," & lblPd1Fat1Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD2_PU1_2
        Dim csvFilePd2Pu12bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd2Pu12.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd2Pu12bk) = False Then
            File.Create(csvFilePd2Pu12bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Pu12bk, True)
            outFile.WriteLine("Area name:," & lblPd2Pu12.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd2Pu12bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd2Pu12bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd2Pu12Temp.Text & "," & lblPd2Pu12Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_FAT_1
        Dim csvFilePd1Fat1bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Fat1.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Fat1bk) = False Then
            File.Create(csvFilePd1Fat1bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Fat1bk, True)
            outFile.WriteLine("Area name:," & lblPd1Fat1.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Fat1bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Fat1bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Fat1Temp.Text & "," & lblPd1Fat1Humid.Text)
                outFile.Close()

            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_FAT_2
        Dim csvFilePd1Fat2bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Fat2.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Fat2bk) = False Then
            File.Create(csvFilePd1Fat2bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Fat2bk, True)
            outFile.WriteLine("Area name:," & lblPd1Fat2.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Fat2bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Fat2bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Fat2Temp.Text & "," & lblPd1Fat2Humid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_SPOT
        Dim csvFilePd1Spotbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Spot.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Spotbk) = False Then
            File.Create(csvFilePd1Spotbk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Spotbk, True)
            outFile.WriteLine("Area name:," & lblPd1Spot.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Spotbk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Spotbk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1SpotTemp.Text & "," & lblPd1SpotHumid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_PRINT_1
        Dim csvFilePd1Print1bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Print1.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Print1bk) = False Then
            File.Create(csvFilePd1Print1bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print1bk, True)
            outFile.WriteLine("Area name:," & lblPd1Print1.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Print1bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print1bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Print1Temp.Text & "," & lblPd1Print1Humid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_PRINT_2
        Dim csvFilePd1Print2bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Print2.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Print2bk) = False Then
            File.Create(csvFilePd1Print2bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print2bk, True)
            outFile.WriteLine("Area name:," & lblPd1Print2.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Print2bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print2bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Print2Temp.Text & "," & lblPd1Print2Humid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        'PD1_PRINT_2
        Dim csvFilePd1Print3bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPd1Print3.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePd1Print3bk) = False Then
            File.Create(csvFilePd1Print3bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print3bk, True)
            outFile.WriteLine("Area name:," & lblPd1Print3.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePd1Print3bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePd1Print3bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPd1Print3Temp.Text & "," & lblPd1Print3Humid.Text)
                outFile.Close()
            Catch ex As Exception
                MessageBox.Show("Đóng file backup để tiến hành ghi Log")
            End Try
        End If
        '**********************************************************************************************************************
        Dim csvFileMC As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblMc1.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePC As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPc1.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd2Smt As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd2Smt.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFileMC2 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblMc2.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePC2 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPc2.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Smt As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Smt.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd2Pu11 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd2Pu11.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd2Pu12 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd2Pu12.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Fat1 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Fat1.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Fat2 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Fat2.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Spot As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Spot.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Print1 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Print1.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Print2 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Print2.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        Dim csvFilePd1Print3 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPd1Print3.Text & "_" & Now.ToString("yyyyMM") & ".csv"
        'Check file
        If Common.CompareFiles(csvFileMC, csvFileMCbk) = False Then
            Try
                File.Copy(csvFileMCbk, csvFileMC, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePC, csvFilePCbk) = False Then
            Try
                File.Copy(csvFilePCbk, csvFilePC, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Smt, csvFilePd1Smtbk) = False Then
            Try
                File.Copy(csvFilePd1Smtbk, csvFilePd1Smt, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFileMC2, csvFileMC2bk) = False Then
            Try
                File.Copy(csvFileMC2bk, csvFileMC2, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePC2, csvFilePC2bk) = False Then
            Try
                File.Copy(csvFilePC2bk, csvFilePC2, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd2Smt, csvFilePd2Smtbk) = False Then
            Try
                File.Copy(csvFilePd2Smtbk, csvFilePd2Smt, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd2Pu11, csvFilePd2Pu11bk) = False Then
            Try
                File.Copy(csvFilePd2Pu11bk, csvFilePd2Pu11, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd2Pu12, csvFilePd2Pu12bk) = False Then
            Try
                File.Copy(csvFilePd2Pu12bk, csvFilePd2Pu12, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Fat1, csvFilePd1Fat1bk) = False Then
            Try
                File.Copy(csvFilePd1Fat1bk, csvFilePd1Fat1, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Fat2, csvFilePd1Fat2bk) = False Then
            Try
                File.Copy(csvFilePd1Fat2bk, csvFilePd1Fat2, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Spot, csvFilePd1Spotbk) = False Then
            Try
                File.Copy(csvFilePd1Spotbk, csvFilePd1Spot, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Print1, csvFilePd1Print1bk) = False Then
            Try
                File.Copy(csvFilePd1Print1bk, csvFilePd1Print1, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Print2, csvFilePd1Print2bk) = False Then
            Try
                File.Copy(csvFilePd1Print2bk, csvFilePd1Print2, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        '-------------------------------------------------
        If Common.CompareFiles(csvFilePd1Print3, csvFilePd1Print3bk) = False Then
            Try
                File.Copy(csvFilePd1Print3bk, csvFilePd1Print3, True)
            Catch ex As Exception
                ' Hiển thị thông báo trong trường hợp file đang mở
            End Try
        End If
        'Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFile))
#End Region
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        ReadfromWEB()
        'Check login quyetpv
        If WebBrowser1.Url.OriginalString = "https://www.webstorage-service.com/system/" Then
            check_alarm()
            Timer4.Enabled = True
            WriteLogHtml()
            'quyetpham add 23/9
            'Timer6.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        alarm()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        lblDateVN.Text = Now.ToString("dd/MM/yyyy HH:mm:ss")
        lblDateJp.Text = Now.ToString("M月 d日")
        'Dim reset = Common.ReadTextFile(filePath, 11)
        Dim timeReset = Common.Search(filePath, "Reset Log")
        If Now.ToString("HH:mm:ss") = timeReset Then
            check_alarm()
            lstObjLog = New List(Of ObjLog)
            WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, Nothing)
        End If

        'Daily_log()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'WebBrowser2.Refresh()
        Me.Text = "UMC Electronics Viet Nam ver " & My.Application.Info.Version.ToString() & " Beta"
        AxWindowsMediaPlayer1.URL = "D:\1.mp3"
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        ' Quyetpv
        Timer1.Interval = Convert.ToDouble(Common.Search(filePath, "Reload"))
        Timer4.Interval = Convert.ToDouble(Common.Search(filePath, "create log"))
        Timer5.Start()
        WebBrowser1.ScriptErrorsSuppressed = True
        If Directory.Exists("Log_Report") = False Then Directory.CreateDirectory("Log_Report")
        If Directory.Exists("Backup") = False Then Directory.CreateDirectory("Backup")
        If Directory.Exists("Log_Alarm") = False Then Directory.CreateDirectory("Log_Alarm")
        If Directory.Exists("Setup") = False Then Directory.CreateDirectory("Setup")
        'Doc du lieu ve nhiet do
        Dim temp As String = Common.Search(filePath, "Temp").Trim()
        'tempMin = Convert.ToDouble(Common.GetListnumber(temp)(0))
        'tempMax = Convert.ToDouble(Common.GetListnumber(temp)(1))
        tempMin = Convert.ToDouble(Microsoft.VisualBasic.Left(temp, 2))
        tempMax = Convert.ToDouble(Microsoft.VisualBasic.Right(temp, 2))
        'Set temp to label
        'lblTemp.Text = tempMin & " C - " & tempMax & " C"
        tempRange = tempMin & " C - " & tempMax & " C"

        'Doc du lieu ve do am
        Dim humid As String = Common.Search(filePath, "Humid").Trim()
        humidMin = Convert.ToInt32(Microsoft.VisualBasic.Left(humid, 2))
        humidMax = Convert.ToInt32(Microsoft.VisualBasic.Right(humid, 2))
        ' Chua xu li duoc truong hop duplicate
        'humidMin = Convert.ToInt32(Common.GetListnumber(humid)(0))
        'humidMax = Convert.ToInt32(Common.GetListnumber(humid)(1))
        'lblHumid.Text = humidMin & "% - " & humidMax & "%"
        humidRange = humidMin & "% - " & humidMax & "%"
        listEmail = Common.FindEmail(filePath)
        'WebBrowser2.DocumentText = Common.CreateHTML(lblTemp.Text, lblHumid.Text, Nothing)
        WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, Nothing)
    End Sub
    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        Dim pass = txtPass.Text
        If e.KeyCode = Keys.Enter Then
            If pass = "umcvn" Then
                Dim frmMaster As New frmMaster()
                frmMaster.ShowDialog()
                frmMaster.StartPosition = FormStartPosition.CenterScreen
                txtPass.Clear()
            Else
                MessageBox.Show("Mật khẩu sai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPass.SelectAll()
            End If
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Daily_log()
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        ' Alarm power
        WebBrowser1.Refresh()
        ReadfromWEB()
        Dim lstTime As List(Of String) = New List(Of String)
        ' Mất kết nối 30p thì gửi mail cảnh báo
        For Each item In listArea
            If Common.WaringConnect(item._time, 30) Then
                lstTime.Add("Connection warnings in area " & item._area & " (" & "<span style='color: Red'>" & item._time.ToLower() & "</span>" & ")")
                lstTime.Add("Mất kết nối ở khu vực " & item._area & " (" & "<span style='color: Red'>" & Common.GetNumber(item._time) & Common.Translate(item._time) & "</span>" & ")")
                lstTime.Add("<hr>")
            End If
        Next
        lstTime.Add("<h4>Please check the connections !<h4>")
        lstTime.Add("<h4>Vui lòng kiểm tra lại kết nối !<h4>")
        If lstTime.Count > 2 Then
            Dim waringConnect As StringBuilder = New StringBuilder
            waringConnect.Append("
                  <!DOCTYPE html>
                            <html>
                            <body>
                            <h3>Dear Mr.</h3>
            ")
            For Each item In lstTime
                waringConnect.Append(String.Format("<h4>{0}</h4>", item))

            Next
            waringConnect.Append("<h3>Chi tiết xem tại</h3>")
            waringConnect.Append("http://172.28.13.2:9999/")
            waringConnect.Append("
                <h5>Thanks and Best Regards!</h5>
                            <h5>--------------------------------</h5>
                            <h5>LCA - VN</h5>
                            <h3>UMC Electronics Vietnam Co., Ltd</h3>
                            <h5>Production Engineering Department</h5>
                            <h5>Add: Tan Truong IZ, Cam Giang Dist, Hai Duong Pro, Viet Nam</h5>
                            <h5>Tel: 0084-320-3570001</h5>
                            </body>
                            </html>
            ")
            Common.SendListEmail(listEmail, waringConnect)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        WebBrowser1.Refresh()
        WebBrowser2.Refresh()
        ReadfromWEB()
        check_alarm()
        WriteLogHtml()
    End Sub

    Private Sub WriteLogHtml()
        ' quyetpham add 23/9
        Console.WriteLine(Now.ToString("HH:mm:ss"))
        Dim stream As StreamWriter
        Dim pathLog As String = Environment.CurrentDirectory & "\Html\data.txt"
        stream = My.Computer.FileSystem.OpenTextFileWriter(pathLog, False)
        stream.WriteLine("#1. MC standar, temp, humid, connection")
        stream.WriteLine(flag(1) & "," & Temp(1) & "," & humd(1) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("MC"))._time, TIMEOUT))
        stream.WriteLine("#2. PC standar, temp, humid, connection")
        stream.WriteLine(flag(2) & "," & Temp(2) & "," & humd(2) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PC"))._time, TIMEOUT))
        stream.WriteLine("#3. PD1-SMT standar, temp, humid, connection")
        stream.WriteLine(flag(3) & "," & Temp(3) & "," & humd(3) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SMT"))._time, TIMEOUT))
        stream.WriteLine("#4. MC2 standar, temp, humid, connection")
        stream.WriteLine(flag(4) & "," & Temp(4) & "," & humd(4) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("MC2"))._time, TIMEOUT))
        stream.WriteLine("#5. PC2 standar, temp, humid, connection")
        stream.WriteLine(flag(5) & "," & Temp(5) & "," & humd(5) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PC2"))._time, TIMEOUT))
        stream.WriteLine("#6. PD2-SMT standar, temp, humid, connection")
        stream.WriteLine(flag(6) & "," & Temp(6) & "," & humd(6) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_SMT"))._time, TIMEOUT))
        stream.WriteLine("#7. PD2-PU1-1 standar, temp, humid, connection")
        stream.WriteLine(flag(7) & "," & Temp(7) & "," & humd(7) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_1"))._time, TIMEOUT))
        stream.WriteLine("#8. PD2-PU1-2 standar, temp, humid, connection")
        stream.WriteLine(flag(8) & "," & Temp(8) & "," & humd(8) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD2_PU1_2"))._time, TIMEOUT))
        stream.WriteLine("#9. PD1-FAT-1 standar, temp, humid, connection")
        stream.WriteLine(flag(9) & "," & Temp(9) & "," & humd(9) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_1"))._time, TIMEOUT))
        stream.WriteLine("#10. PD1-FAT-2 standar, temp, humid, connection")
        stream.WriteLine(flag(10) & "," & Temp(10) & "," & humd(10) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_FAT_2"))._time, TIMEOUT))
        stream.WriteLine("#11. PD1-SPOT standar, temp, humid, connection")
        stream.WriteLine(flag(11) & "," & Temp(11) & "," & humd(11) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_SPOT"))._time, TIMEOUT))
        stream.WriteLine("#12. PD1-PRINT-1 standar, temp, humid, connection")
        stream.WriteLine(flag(12) & "," & Temp(12) & "," & humd(12) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_1"))._time, TIMEOUT))
        stream.WriteLine("#13. PD1-PRINT-2 standar, temp, humid, connection")
        stream.WriteLine(flag(13) & "," & Temp(13) & "," & humd(13) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_2"))._time, TIMEOUT))
        stream.WriteLine("#14. PD1-PRINT-3 standar, temp, humid, connection")
        stream.WriteLine(flag(14) & "," & Temp(14) & "," & humd(14) & "," & Common.WaringConnect(listArea.FirstOrDefault(Function(p) p._area.Equals("PD1_PRINT_3"))._time, TIMEOUT))
        stream.Close()
    End Sub
End Class
