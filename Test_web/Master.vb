Imports System.IO
Imports System.Threading

Public Class frmMaster
    Dim tempMin
    Dim tempMax
    Dim humidMin
    Dim humidMax
    Dim tempMinNew As Integer
    Dim tempMaxNew As Integer
    Dim humidMinNew As Integer
    Dim humidMaxNew As Integer
    ' Khai báo biến trong bảng hiển thị
    Dim tempMinView As String
    Dim tempMaxView As String
    Dim hudmidMinView As String
    Dim hudmidMaxView As String
    Dim filePath As String = My.Application.Info.DirectoryPath & "\Setup\DataConfig.txt"
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = My.Application.Info.DirectoryPath & "\Setup\DataConfig.txt"
        'Doc du lieu ve nhiet do
        Dim temp As String = Common.ReadTextFile(filePath, 3).Trim()
        Dim lstEmail As List(Of String) = Common.FindEmail(filePath)
        tempMin = Microsoft.VisualBasic.Left(temp, 2)
        tempMax = Microsoft.VisualBasic.Right(temp, 2)
        'Set temp to label
        txtTempMin.Text = tempMin
        txtTempMax.Text = tempMax
        For Each email In lstEmail
            rtbEmail.Text &= email & vbCrLf
        Next
        'Doc du lieu ve do am
        Dim humid As String = Common.ReadTextFile(filePath, 5).Trim()
        humidMin = Microsoft.VisualBasic.Left(humid, 2)
        humidMax = Microsoft.VisualBasic.Right(humid, 2)
        txtHumidMin.Text = humidMin
        txtHumidMax.Text = humidMax
        txtReload.Text = Common.ReadTextFile(filePath, 7)
        txtCreateLog.Text = Common.ReadTextFile(filePath, 9)
        txtDaily.Text = Common.ReadTextFile(filePath, 11)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Validate
        If txtTempMin.Text <> tempMinNew.ToString Or txtTempMax.Text <> tempMaxNew.ToString Or txtHumidMin.Text <> humidMinNew.ToString Or txtHumidMax.Text <> humidMaxNew.ToString Then
            MessageBox.Show("Dữ liệu không hợp lệ", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf tempMinNew >= tempMaxNew Then
            MessageBox.Show("Khoảng nhiệt độ không phù hợp!", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf humidMinNew >= humidMaxNew Then
            MessageBox.Show("Khoảng độ ẩm không hợp lệ!", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'Save data
        Try
            Dim filePath As String = My.Application.Info.DirectoryPath & "\Setup\DataConfig.txt"
            Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filePath, False)
            outFile.WriteLine("#1. UMC Standard")
            outFile.WriteLine("#2. Temp (Nhiet do - Do C)")
            outFile.WriteLine(tempMinNew & "-" & tempMaxNew)
            outFile.WriteLine("#3. Humid (Do am - %)")
            outFile.WriteLine(humidMinNew & "-" & humidMaxNew)
            outFile.WriteLine("#5. Time Reload Website")
            outFile.WriteLine(txtReload.Text)
            outFile.WriteLine("#6. Time auto create log")
            outFile.WriteLine(txtCreateLog.Text)
            outFile.WriteLine("#7. Time Reset Log")
            outFile.WriteLine(txtDaily.Text)
            outFile.WriteLine("#8. List mail auto send")
            For Each mail In rtbEmail.Lines
                outFile.WriteLine(mail)
            Next
            outFile.Close()
            'If File.Exists("D:\view.html") = True Then
            '    File.Delete("D:\view.html")
            'End If
            Dim tempRange = Microsoft.VisualBasic.Left(Common.ReadTextFile(filePath, 3), 2) & "C - " & Microsoft.VisualBasic.Right(Common.ReadTextFile(filePath, 3), 2) & " C"
            Dim humidRange = Microsoft.VisualBasic.Left(Common.ReadTextFile(filePath, 5), 2) & "% - " & Microsoft.VisualBasic.Right(Common.ReadTextFile(filePath, 5), 2) & "%"
            'Common.CreateHtml("D:\view.html", tempRange, humidRange, Nothing)
            Close()
            My.Forms.frmMaster.Close()
            My.Forms.frmMain.Close()
        Catch ex As Exception
            MessageBox.Show("Errors")
        End Try
    End Sub

    Private Sub txtTempMin_TextChanged(sender As Object, e As EventArgs) Handles txtTempMin.TextChanged
        Try
            tempMinNew = txtTempMin.Text.Trim
            ptbOK1.Visible = True
            ptbNG1.Visible = False
            tempMinView = tempMinNew
        Catch ex As Exception
            ptbOK1.Visible = False
            ptbNG1.Visible = True
            tempMinView = "NaN"
        End Try
        lblTempView.Text = tempMinView & " C - " & tempMaxView & " C"
    End Sub
    Private Sub txtTempMax_TextChanged(sender As Object, e As EventArgs) Handles txtTempMax.TextChanged
        Try
            tempMaxNew = txtTempMax.Text.Trim
            ptbOK2.Visible = True
            ptbNG2.Visible = False
            tempMaxView = tempMaxNew
        Catch ex As Exception
            ptbOK2.Visible = False
            ptbNG2.Visible = True
            tempMaxView = "NaN"
        End Try
        lblTempView.Text = tempMinView & " C - " & tempMaxView & " C"
    End Sub

    Private Sub txtHumidMin_TextChanged(sender As Object, e As EventArgs) Handles txtHumidMin.TextChanged
        Try
            humidMinNew = txtHumidMin.Text.Trim
            ptbOK3.Visible = True
            ptbNG3.Visible = False
            hudmidMinView = humidMinNew
        Catch ex As Exception
            ptbOK3.Visible = False
            ptbNG3.Visible = True
            hudmidMinView = "NaN"
        End Try
        lblHumidView.Text = hudmidMinView & " % - " & hudmidMaxView & " %"
    End Sub

    Private Sub txtHumidMax_TextChanged(sender As Object, e As EventArgs) Handles txtHumidMax.TextChanged
        Try
            humidMaxNew = txtHumidMax.Text.Trim
            ptbOK4.Visible = True
            ptbNG4.Visible = False
            hudmidMaxView = humidMaxNew
        Catch ex As Exception
            ptbOK4.Visible = False
            ptbNG4.Visible = True
            hudmidMaxView = "NaN"
        End Try
        lblHumidView.Text = hudmidMinView & " % - " & hudmidMaxView & " %"
    End Sub

    'Private Sub frmMaster_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    '    If File.Exists("D:\view.html") = True Then
    '        File.Delete("D:\view.html")
    '    End If
    '    Dim tempRange = Microsoft.VisualBasic.Left(Common.ReadTextFile(filePath, 3), 2) & "C - " & Microsoft.VisualBasic.Right(Common.ReadTextFile(filePath, 3), 2) & " C"
    '    Dim humidRange = Microsoft.VisualBasic.Left(Common.ReadTextFile(filePath, 5), 2) & "% - " & Microsoft.VisualBasic.Right(Common.ReadTextFile(filePath, 5), 2) & "%"
    '    Common.CreateHtml("D:\view.html", tempRange, humidRange, Nothing)
    'End Sub
End Class