Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Public Class frmMain
    'Dim i As Integer = 0
    Dim pathEmail As String = My.Application.Info.DirectoryPath & "\Setup\ListEmail.txt"
    Dim lstObjLog As List(Of ObjLog) = New List(Of ObjLog)
    Dim no As Integer = 0
    Dim tempArea As List(Of String) = New List(Of String)
    Dim listEmail As List(Of String)
    Dim listArea As List(Of ObjLog)
    Dim flag(20) As Boolean
    Dim tempRange As String
    Dim humidRange As String
    Dim COUNT_ALARM As Integer
    Dim setting As SystemSetting
    Dim pathConfig As String = My.Application.Info.DirectoryPath & "\Setup\config.xml"
    Dim dicArea As Dictionary(Of String, ObjLog)
    Private Sub ReadfromWEB()
        Dim rContent As RichTextBox = New RichTextBox
        dicArea = New Dictionary(Of String, ObjLog)
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            rContent.Text = WebBrowser1.Document.Body.InnerText
            If (rContent.Lines(2) <> "Password") Then
                Dim element As HtmlElementCollection = Nothing
                Dim lsts = New List(Of String)

                element = WebBrowser1.Document.GetElementsByTagName("td")
                For Each item As HtmlElement In element
                    If item.GetAttribute("classname") = "upper" And item.OuterText <> "UMC" Then
                        lsts.Add(item.OuterHtml)
                    End If
                Next
                'Dim temp1 = lsts.GetRange(1, 3)
                listArea = New List(Of ObjLog)
                While lsts.Count > 0

                    tempArea = lsts.GetRange(0, 3)
                    Dim area = Common.getBetween(tempArea(0), ">", " <IMG")
                    Dim temp = Common.getBetween(tempArea(2), "[Temp]", "C").Trim
                    Dim humid = Common.getBetween(tempArea(2), "[Humid]", "%").Trim
                    Dim time = Common.GetTime(Common.getBetween(tempArea(1), "<br />", "')").Trim)
                    Dim objArea As ObjLog = New ObjLog(area, temp, humid, time)
                    dicArea.Add(area, objArea)
                    listArea.Add(objArea)
                    lsts.RemoveRange(0, 3)
                End While
                Try
                    lblMc1Temp.Text = dicArea.Item("MC")._temp & " C"
                    lblMc1Humid.Text = dicArea.Item("MC")._humid & " %"

                    lblPc1Temp.Text = dicArea.Item("PC")._temp & " C"
                    lblPc1Humid.Text = dicArea.Item("PC")._humid & " %"

                    lblPd1SmtTemp.Text = dicArea.Item("PD1_SMT")._temp & " C"
                    lblPd1SmtHumid.Text = dicArea.Item("PD1_SMT")._humid & " %"

                    lblMc2Temp.Text = dicArea.Item("MC2")._temp & " C"
                    lblMc2Humid.Text = dicArea.Item("MC2")._humid & " %"

                    lblPc2Temp.Text = dicArea.Item("PC2")._temp & " C"
                    lblPc2Humid.Text = dicArea.Item("PC2")._humid & " %"

                    lblPd2SmtTemp.Text = dicArea.Item("PD2_SMT")._temp & " C"
                    lblPd2SmtHumid.Text = dicArea.Item("PD2_SMT")._humid & " %"

                    lblPd2Pu11Temp.Text = dicArea.Item("PD2_PU1_1")._temp & " C"
                    lblPd2Pu11Humid.Text = dicArea.Item("PD2_PU1_1")._humid & " %"

                    lblPd2Pu12Temp.Text = dicArea.Item("PD2_PU1_2")._temp & " C"
                    lblPd2Pu12Humid.Text = dicArea.Item("PD2_PU1_2")._humid & " %"

                    lblPd1Fat1Temp.Text = dicArea.Item("PD1_FAT_1")._temp & " C"
                    lblPd1Fat1Humid.Text = dicArea.Item("PD1_FAT_1")._humid & " %"

                    lblPd1Fat2Temp.Text = dicArea.Item("PD1_FAT_2")._temp & " C"
                    lblPd1Fat2Humid.Text = dicArea.Item("PD1_FAT_2")._humid & " %"

                    lblPd1SpotTemp.Text = dicArea.Item("PD1_SPOT WEDING")._temp & " C"
                    lblPd1SpotHumid.Text = dicArea.Item("PD1_SPOT WEDING")._humid & " %"

                    lblPd1Print1Temp.Text = dicArea.Item("PD1_PRINT_1")._temp & " C"
                    lblPd1Print1Humid.Text = dicArea.Item("PD1_PRINT_1")._humid & " %"

                    lblPd1Print2Temp.Text = dicArea.Item("PD1_PRINT_2")._temp & " C"
                    lblPd1Print2Humid.Text = dicArea.Item("PD1_PRINT_2")._humid & " %"

                    lblPd1Print3Temp.Text = dicArea.Item("PD1_PRINT_3")._temp & " C"
                    lblPd1Print3Humid.Text = dicArea.Item("PD1_PRINT_3")._humid & " %"

                    lblPc12Temp.Text = dicArea.Item("PC1_2")._temp & " C"
                    lblPC12Humid.Text = dicArea.Item("PC1_2")._humid & " %"

                Catch ex As Exception
                    MessageBox.Show("Bạn đã thay đổi thông tin trên website", "Liên hệ Quyết LCA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Close()
                End Try

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
                element.SetAttribute("value", setting._username)
            End If

            If element.Name = "lpd" Then
                element.SetAttribute("value", setting._password)
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
        ' Sau 30p alarm 1 lan
        If COUNT_ALARM = 18 Then
            COUNT_ALARM = 0
        End If
        '-----------------------------------------------------------------------------------------------------------
        lblMc1Temp.ForeColor = If(dicArea.Item("MC")._temp >= setting._tempMin And dicArea.Item("MC")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblMc1Humid.ForeColor = If(dicArea.Item("MC")._humid >= setting._humidMin And dicArea.Item("MC")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblMc1Temp.ForeColor = Color.Blue And lblMc1Humid.ForeColor = Color.Blue Then
            PictureBox2.Image = Image.FromFile("OK.jpg")
            flag(1) = True
        Else
            PictureBox2.Image = Image.FromFile("NG.jpg")
            flag(1) = False
        End If

        '-----------------------------------------------------------------------------------------------------------
        lblPc1Temp.ForeColor = If(dicArea.Item("PC")._temp >= setting._tempMin And dicArea.Item("PC")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPc1Humid.ForeColor = If(dicArea.Item("PC")._humid >= setting._humidMin And dicArea.Item("PC")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPc1Temp.ForeColor = Color.Blue And lblPc1Humid.ForeColor = Color.Blue Then
            PictureBox4.Image = Image.FromFile("OK.jpg")
            flag(2) = True
        Else
            PictureBox4.Image = Image.FromFile("NG.jpg")
            flag(2) = False
        End If
        '...............................................................................................................
        lblPd1SmtTemp.ForeColor = If(dicArea.Item("PD1_SMT")._temp >= setting._tempMin And dicArea.Item("PD1_SMT")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd1SmtHumid.ForeColor = If(dicArea.Item("PD1_SMT")._humid >= setting._humidMin And dicArea.Item("PD1_SMT")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd1SmtTemp.ForeColor = Color.Blue And lblPd1SmtHumid.ForeColor = Color.Blue Then
            PictureBox6.Image = Image.FromFile("OK.jpg")
            flag(3) = True
        Else
            PictureBox6.Image = Image.FromFile("NG.jpg")
            flag(3) = False
        End If
        '---------------------------------------------------------------------------------------------------------------

        lblMc2Temp.ForeColor = If(dicArea.Item("MC2")._temp >= setting._tempMin And dicArea.Item("MC2")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblMc2Humid.ForeColor = If(dicArea.Item("MC2")._humid >= setting._humidMin And dicArea.Item("MC2")._humid <= setting._humidMax, Color.Blue, Color.Red)
        If lblMc2Temp.ForeColor = Color.Blue And lblMc2Humid.ForeColor = Color.Blue Then
            PictureBox3.Image = Image.FromFile("OK.jpg")
            flag(4) = True
        Else
            PictureBox3.Image = Image.FromFile("NG.jpg")
            flag(4) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPc2Temp.ForeColor = If(dicArea.Item("PC2")._temp >= setting._tempMin And dicArea.Item("PC2")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPc2Humid.ForeColor = If(dicArea.Item("PC2")._humid >= setting._humidMin And dicArea.Item("PC2")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPc2Temp.ForeColor = Color.Blue And lblPc2Humid.ForeColor = Color.Blue Then
            PictureBox5.Image = Image.FromFile("OK.jpg")
            flag(5) = True
        Else
            PictureBox5.Image = Image.FromFile("NG.jpg")
            flag(5) = False
        End If
        '---------------------------------------------------------------------------------------------------------------

        lblPd2SmtTemp.ForeColor = If(dicArea.Item("PD2_SMT")._temp >= setting._tempMin And dicArea.Item("PD2_SMT")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd2SmtHumid.ForeColor = If(dicArea.Item("PD2_SMT")._humid >= setting._humidMin And dicArea.Item("PD2_SMT")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd2SmtTemp.ForeColor = Color.Blue And lblPd2SmtHumid.ForeColor = Color.Blue Then
            PictureBox9.Image = Image.FromFile("OK.jpg")
            flag(6) = True
        Else
            PictureBox9.Image = Image.FromFile("NG.jpg")
            flag(6) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd2Pu11Temp.ForeColor = If(dicArea.Item("PD2_PU1_1")._temp >= setting._tempMin And dicArea.Item("PD2_PU1_1")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd2Pu11Humid.ForeColor = If(dicArea.Item("PD2_PU1_1")._humid >= setting._humidMin And dicArea.Item("PD2_PU1_1")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd2Pu11Temp.ForeColor = Color.Blue And lblPd2Pu11Humid.ForeColor = Color.Blue Then
            PictureBox10.Image = Image.FromFile("OK.jpg")
            flag(7) = True
        Else
            PictureBox10.Image = Image.FromFile("NG.jpg")
            flag(7) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd2Pu12Temp.ForeColor = If(dicArea.Item("PD2_PU1_2")._temp >= setting._tempMin And dicArea.Item("PD2_PU1_2")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd2Pu12Humid.ForeColor = If(dicArea.Item("PD2_PU1_2")._humid >= setting._humidMin And dicArea.Item("PD2_PU1_2")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd2Pu12Temp.ForeColor = Color.Blue And lblPd2Pu12Humid.ForeColor = Color.Blue Then
            PictureBox11.Image = Image.FromFile("OK.jpg")
            flag(8) = True
        Else
            PictureBox11.Image = Image.FromFile("NG.jpg")
            flag(8) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Fat1Temp.ForeColor = If(dicArea.Item("PD1_FAT_1")._temp >= setting._tempMin And dicArea.Item("PD1_FAT_1")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd1Fat1Humid.ForeColor = If(dicArea.Item("PD1_FAT_1")._humid >= setting._humidMin And dicArea.Item("PD1_FAT_1")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd1Fat1Temp.ForeColor = Color.Blue And lblPd1Fat1Humid.ForeColor = Color.Blue Then
            PictureBox7.Image = Image.FromFile("OK.jpg")
            flag(9) = True
        Else
            PictureBox7.Image = Image.FromFile("NG.jpg")
            flag(9) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Fat2Temp.ForeColor = If(dicArea.Item("PD1_FAT_2")._temp >= setting._tempMin And dicArea.Item("PD1_FAT_2")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd1Fat2Humid.ForeColor = If(dicArea.Item("PD1_FAT_2")._humid >= setting._humidMin And dicArea.Item("PD1_FAT_2")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd1Fat2Temp.ForeColor = Color.Blue And lblPd1Fat2Humid.ForeColor = Color.Blue Then
            PictureBox8.Image = Image.FromFile("OK.jpg")
            flag(10) = True
        Else
            PictureBox8.Image = Image.FromFile("NG.jpg")
            flag(10) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1SpotTemp.ForeColor = If(dicArea.Item("PD1_SPOT WEDING")._temp >= setting._tempMin And dicArea.Item("PD1_SPOT WEDING")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPd1SpotHumid.ForeColor = If(dicArea.Item("PD1_SPOT WEDING")._humid >= setting._humidMin And dicArea.Item("PD1_SPOT WEDING")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPd1SpotTemp.ForeColor = Color.Blue And lblPd1SpotHumid.ForeColor = Color.Blue Then
            PictureBox12.Image = Image.FromFile("OK.jpg")
            flag(11) = True
        Else
            PictureBox12.Image = Image.FromFile("NG.jpg")
            flag(11) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print1Temp.ForeColor = If(dicArea.Item("PD1_PRINT_1")._temp >= setting._printTempMin And dicArea.Item("PD1_PRINT_1")._temp <= setting._printTempMax, Color.Blue, Color.Red)
        lblPd1Print1Humid.ForeColor = If(dicArea.Item("PD1_PRINT_1")._humid >= setting._printHumidMin And dicArea.Item("PD1_PRINT_1")._humid <= setting._printHumidMax, Color.Blue, Color.Red)

        If lblPd1Print1Temp.ForeColor = Color.Blue And lblPd1Print1Humid.ForeColor = Color.Blue Then
            PictureBox13.Image = Image.FromFile("OK.jpg")
            flag(12) = True
        Else
            PictureBox13.Image = Image.FromFile("NG.jpg")
            flag(12) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print2Temp.ForeColor = If(dicArea.Item("PD1_PRINT_2")._temp >= setting._printTempMin And dicArea.Item("PD1_PRINT_2")._temp <= setting._printTempMax, Color.Blue, Color.Red)
        lblPd1Print2Humid.ForeColor = If(dicArea.Item("PD1_PRINT_2")._humid >= setting._printHumidMin And dicArea.Item("PD1_PRINT_2")._humid <= setting._printHumidMax, Color.Blue, Color.Red)

        If lblPd1Print2Temp.ForeColor = Color.Blue And lblPd1Print2Humid.ForeColor = Color.Blue Then
            PictureBox14.Image = Image.FromFile("OK.jpg")
            flag(13) = True
        Else
            PictureBox14.Image = Image.FromFile("NG.jpg")
            flag(13) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPd1Print3Temp.ForeColor = If(dicArea.Item("PD1_PRINT_3")._temp >= setting._printTempMin And dicArea.Item("PD1_PRINT_3")._temp <= setting._printTempMax, Color.Blue, Color.Red)
        lblPd1Print3Humid.ForeColor = If(dicArea.Item("PD1_PRINT_3")._humid >= setting._printHumidMin And dicArea.Item("PD1_PRINT_3")._humid <= setting._printHumidMax, Color.Blue, Color.Red)

        If lblPd1Print3Temp.ForeColor = Color.Blue And lblPd1Print3Humid.ForeColor = Color.Blue Then
            PictureBox15.Image = Image.FromFile("OK.jpg")
            flag(14) = True
        Else
            PictureBox15.Image = Image.FromFile("NG.jpg")
            flag(14) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        lblPc12Temp.ForeColor = If(dicArea.Item("PC1_2")._temp >= setting._tempMin And dicArea.Item("PC1_2")._temp <= setting._tempMax, Color.Blue, Color.Red)
        lblPC12Humid.ForeColor = If(dicArea.Item("PC1_2")._humid >= setting._humidMin And dicArea.Item("PC1_2")._humid <= setting._humidMax, Color.Blue, Color.Red)

        If lblPc12Temp.ForeColor = Color.Blue And lblPC12Humid.ForeColor = Color.Blue Then
            PictureBox17.Image = Image.FromFile("OK.jpg")
            flag(15) = True
        Else
            PictureBox17.Image = Image.FromFile("NG.jpg")
            flag(15) = False
        End If
        '---------------------------------------------------------------------------------------------------------------
        'Label36.Text = alarm_again
        If flag(1) = False Or flag(2) = False Or flag(3) = False Or flag(4) = False Or flag(5) = False Or flag(6) = False Or flag(7) = False Or flag(8) = False Or flag(9) = False Or flag(10) = False Or flag(11) = False Or flag(15) = False Then
            Label35.ForeColor = Color.Red
            Label35.Text = "Alarm"
            Timer2.Enabled = True
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
                If flag(15) = False Then
                    Dim objLog = New ObjLog(no, Now.ToString("dd-MM-yyyy HH:mm:ss"), lblPc12.Text, lblPc12Temp.Text, lblPC12Humid.Text)
                    lstObjLog.Add(objLog)
                    no = no + 1
                End If
                'quyet
                Dim content As StringBuilder = New StringBuilder
                For Each obj In lstObjLog
                    content.Append("<tr>")
                    content.Append(String.Format("<td>{0}</td>", obj._no))
                    content.Append(String.Format("<td>{0}</td>", obj._time))
                    content.Append(String.Format("<td>{0}</td>", obj._area))
                    If Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) < Convert.ToDouble(setting._tempMin) Or Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) > Convert.ToDouble(setting._tempMax) Then
                        content.Append(String.Format("<td style='background-color: Red'>{0}</td>", obj._temp))
                    Else
                        content.Append(String.Format("<td>{0}</td>", obj._temp))
                    End If
                    If Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) < Convert.ToInt32(setting._humidMin) Or Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) > Convert.ToInt32(setting._humidMax) Then
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
                        If Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) < Convert.ToDouble(setting._tempMin) Or Convert.ToDouble(Microsoft.VisualBasic.Left(obj._temp, 4)) > Convert.ToDouble(setting._tempMax) Then
                            sttTemp = "NG"
                        End If
                        If Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) < Convert.ToInt32(setting._humidMin) Or Convert.ToInt32(Microsoft.VisualBasic.Left(obj._humid, 3).Trim()) > Convert.ToInt32(setting._humidMax) Then
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
                    emailContent.Append("http://172.28.5.203:9999/")
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
                    SendListEmail(listEmail, emailContent)
                End If

                WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, content)
#End Region
            End If

        Else

            Label35.ForeColor = Color.Blue
            Label35.Text = "OK"
            Timer2.Enabled = False
            AxWindowsMediaPlayer1.Ctlcontrols.stop()

        End If
        COUNT_ALARM = COUNT_ALARM + 1

    End Sub
    Private Sub alarm()
        Label35.Text = If(Label35.Text = "Alarm", "", "Alarm")
    End Sub
    Private Sub Daily_log()
        'Declare Ca
        Dim ca As String
        ca = If(Now.Hour >= 8 And Now.Hour <= 20, "HC", "D")
#Region "Create Report"
        Dim outFile As IO.StreamWriter
        '**********************************************************************************************************************
        'MC1
        Dim csvFileMCbk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblMc1.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        ' Create Header
        If Not File.Exists(csvFileMCbk) Then
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
        'PD1_PRINT_3
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
        'PC12
        Dim csvFilePc12bk As String = My.Application.Info.DirectoryPath & "\Backup\" & lblPc12.Text & "_" & Now.ToString("yyyyMM") & "_backup.csv"
        If File.Exists(csvFilePc12bk) = False Then
            File.Create(csvFilePc12bk).Dispose()
            outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePc12bk, True)
            outFile.WriteLine("Area name:," & lblPc12.Text)
            outFile.WriteLine()
            outFile.WriteLine()
            outFile.WriteLine("Ca,Time,Temp,Humid")
            outFile.Close()
        End If
        If File.Exists(csvFilePc12bk) Then
            Try
                outFile = My.Computer.FileSystem.OpenTextFileWriter(csvFilePc12bk, True)
                outFile.WriteLine(ca & "," & Now.ToString("dd/MM/yyyy HH:mm:ss") & "," & lblPc12Temp.Text & "," & lblPC12Humid.Text)
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
        Dim csvFilePc12 As String = My.Application.Info.DirectoryPath & "\Log_Report\" & lblPc12.Text & "_" & Now.ToString("yyyyMM") & ".csv"
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
        If Common.CompareFiles(csvFilePc12, csvFilePc12bk) = False Then
            Try
                File.Copy(csvFilePc12bk, csvFilePc12, True)
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
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        alarm()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        lblDateJp.Text = Now.ToString("M月 d日")
        If Now.ToString("HH:mm:ss") = setting._resetLog Then
            check_alarm()
            lstObjLog = New List(Of ObjLog)
            WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, Nothing)
        End If

        'Daily_log()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.ScriptErrorsSuppressed = True
        If Not File.Exists(pathConfig) Then Common.SaveInitSystem(setting, pathConfig)
        If Not Directory.Exists("Log_Report") Then Directory.CreateDirectory("Log_Report")
        If Not Directory.Exists("Backup") Then Directory.CreateDirectory("Backup")
        If Not Directory.Exists("Log_Alarm") Then Directory.CreateDirectory("Log_Alarm")
        If Not Directory.Exists("Setup") Then Directory.CreateDirectory("Setup")
        LoadComponent()
    End Sub
    Private Sub LoadComponent()
        SystemSetting.ReadXML(Of SystemSetting)(setting, pathConfig)
        Timer1.Interval = setting._reloadWebInterval
        Timer4.Interval = setting._createLogInterval
        Timer5.Start()
        tempRange = setting._tempMin & " C - " & setting._tempMax & " C"
        humidRange = setting._humidMin & "% - " & setting._humidMax & "%"
        listEmail = Common.FindEmail(pathEmail)
        WebBrowser2.DocumentText = Common.CreateHTML(tempRange, humidRange, Nothing)
        AxWindowsMediaPlayer1.URL = setting._mp3
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Text = setting._title & My.Application.Info.Version.ToString()
    End Sub
    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        Dim pass = txtPass.Text
        If e.KeyCode = Keys.Enter Then
            If pass = setting._passConfig Then
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
            If Common.WaringConnect(item._time, 59) Then
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
            waringConnect.Append("http://172.28.5.203:9999/")
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
            SendListEmail(listEmail, waringConnect)
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
        Dim stream As StreamWriter
        Dim pathLog As String = Environment.CurrentDirectory & "\Html\data.txt"
        stream = My.Computer.FileSystem.OpenTextFileWriter(pathLog, False)
        stream.WriteLine("#1. MC standar, temp, humid, connection")
        stream.WriteLine(flag(1) & "," & dicArea.Item("MC")._temp & "," & dicArea.Item("MC")._humid & "," & Common.WaringConnect(dicArea.Item("MC")._time, setting._connectionWarning))
        stream.WriteLine("#2. PC standar, temp, humid, connection")
        stream.WriteLine(flag(2) & "," & dicArea.Item("PC")._temp & "," & dicArea.Item("PC")._humid & "," & Common.WaringConnect(dicArea.Item("PC")._time, setting._connectionWarning))
        stream.WriteLine("#3. PD1-SMT standar, temp, humid, connection")
        stream.WriteLine(flag(3) & "," & dicArea.Item("PD1_SMT")._temp & "," & dicArea.Item("PD1_SMT")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_SMT")._time, setting._connectionWarning))
        stream.WriteLine("#4. MC2 standar, temp, humid, connection")
        stream.WriteLine(flag(4) & "," & dicArea.Item("MC2")._temp & "," & dicArea.Item("MC2")._humid & "," & Common.WaringConnect(dicArea.Item("MC2")._time, setting._connectionWarning))
        stream.WriteLine("#5. PC2 standar, temp, humid, connection")
        stream.WriteLine(flag(5) & "," & dicArea.Item("PC2")._temp & "," & dicArea.Item("PC2")._humid & "," & Common.WaringConnect(dicArea.Item("PC2")._time, setting._connectionWarning))
        stream.WriteLine("#6. PD2-SMT standar, temp, humid, connection")
        stream.WriteLine(flag(6) & "," & dicArea.Item("PD2_SMT")._temp & "," & dicArea.Item("PD2_SMT")._humid & "," & Common.WaringConnect(dicArea.Item("PD2_SMT")._time, setting._connectionWarning))
        stream.WriteLine("#7. PD2-PU1-1 standar, temp, humid, connection")
        stream.WriteLine(flag(7) & "," & dicArea.Item("PD2_PU1_1")._temp & "," & dicArea.Item("PD2_PU1_1")._humid & "," & Common.WaringConnect(dicArea.Item("PD2_PU1_1")._time, setting._connectionWarning))
        stream.WriteLine("#8. PD2-PU1-2 standar, temp, humid, connection")
        stream.WriteLine(flag(8) & "," & dicArea.Item("PD2_PU1_2")._temp & "," & dicArea.Item("PD2_PU1_2")._humid & "," & Common.WaringConnect(dicArea.Item("PD2_PU1_2")._time, setting._connectionWarning))
        stream.WriteLine("#9. PD1-FAT-1 standar, temp, humid, connection")
        stream.WriteLine(flag(9) & "," & dicArea.Item("PD1_FAT_1")._temp & "," & dicArea.Item("PD1_FAT_1")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_FAT_1")._time, setting._connectionWarning))
        stream.WriteLine("#10. PD1-FAT-2 standar, temp, humid, connection")
        stream.WriteLine(flag(10) & "," & dicArea.Item("PD1_FAT_2")._temp & "," & dicArea.Item("PD1_FAT_2")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_FAT_2")._time, setting._connectionWarning))
        stream.WriteLine("#11. PD1-SPOT standar, temp, humid, connection")
        stream.WriteLine(flag(11) & "," & dicArea.Item("PD1_SPOT WEDING")._temp & "," & dicArea.Item("PD1_SPOT WEDING")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_SPOT WEDING")._time, setting._connectionWarning))
        stream.WriteLine("#12. PD1-PRINT-1 standar, temp, humid, connection")
        stream.WriteLine(flag(12) & "," & dicArea.Item("PD1_PRINT_1")._temp & "," & dicArea.Item("PD1_PRINT_1")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_PRINT_1")._time, setting._connectionWarning))
        stream.WriteLine("#13. PD1-PRINT-2 standar, temp, humid, connection")
        stream.WriteLine(flag(13) & "," & dicArea.Item("PD1_PRINT_2")._temp & "," & dicArea.Item("PD1_PRINT_2")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_PRINT_2")._time, setting._connectionWarning))
        stream.WriteLine("#14. PD1-PRINT-3 standar, temp, humid, connection")
        stream.WriteLine(flag(14) & "," & dicArea.Item("PD1_PRINT_3")._temp & "," & dicArea.Item("PD1_PRINT_3")._humid & "," & Common.WaringConnect(dicArea.Item("PD1_PRINT_3")._time, setting._connectionWarning))
        stream.WriteLine("#15. PC1_2 standar, temp, humid, connection")
        stream.WriteLine(flag(15) & "," & dicArea.Item("PC1_2")._temp & "," & dicArea.Item("PC1_2")._humid & "," & Common.WaringConnect(dicArea.Item("PC1_2")._time, setting._connectionWarning))
        stream.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New frmAbout
        frmAbout.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Sub SendListEmail(ByVal listEmail As List(Of String), ByVal content As StringBuilder)
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(setting._email, setting._emailPass)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            '--------------------------------------------  
            For Each email In listEmail
                e_mail = New MailMessage()
                e_mail.From = New MailAddress(setting._email)
                Dim emai = New MailAddress(email)
                e_mail.To.Add(emai)
                e_mail.Subject = "Alarm Temp and Humid in UMCVN"
                e_mail.IsBodyHtml = True
                e_mail.Body = content.ToString()
                Smtp_Server.Send(e_mail)
            Next

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub
End Class
