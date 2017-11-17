Imports System.IO
Imports System.Threading

Public Class frmMaster
    Dim tempMinNew As Integer
    Dim tempMaxNew As Integer
    Dim humidMinNew As Integer
    Dim humidMaxNew As Integer
    ' Khai báo biến trong bảng hiển thị
    Dim tempMinView As String
    Dim tempMaxView As String
    Dim hudmidMinView As String
    Dim hudmidMaxView As String
    Dim pathEmail As String = My.Application.Info.DirectoryPath & "\Setup\ListEmail.txt"
    Dim pathConfig As String = My.Application.Info.DirectoryPath & "\Setup\config.xml"
    Dim setting As SystemSetting
    Private Sub frmMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComponent()
    End Sub
    Private Sub LoadComponent()
        If Not File.Exists(pathConfig) Then Common.SaveInitSystem(setting, pathConfig)
        SystemSetting.ReadXML(Of SystemSetting)(setting, pathConfig)
        txtTempMin.Text = setting._tempMin
        txtTempMax.Text = setting._tempMax
        txtHumidMin.Text = setting._humidMin
        txtHumidMax.Text = setting._humidMax
        txtDaily.Text = setting._resetLog
        txtMp3.Text = setting._mp3
        nReloadWeb.Value = setting._reloadWebInterval / 1000
        nCreateLog.Value = setting._createLogInterval / 1000
        nConnection.Value = setting._connectionWarning + 1
        Dim lstEmail As List(Of String) = Common.FindEmail(pathEmail)
        For Each email In lstEmail
            rtbEmail.Text &= email & vbCrLf
        Next
        WebBrowser1.DocumentText = "<h2 style='color: red; text-align: Top'><marquee>Contact: quyetphamit@gmail.com/ 0972089889</marquee></h2>"
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
        ElseIf Not Common.IsTime(txtDaily.Text) Then
            MessageBox.Show("Thời gian reset log sai định dạng!", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'Save data
        Try
            setting._tempMin = tempMinNew
            setting._tempMax = tempMaxNew
            setting._humidMin = humidMinNew
            setting._humidMax = humidMaxNew
            setting._reloadWebInterval = nReloadWeb.Value * 1000
            setting._resetLog = txtDaily.Text
            setting._connectionWarning = nConnection.Value - 1
            setting._createLogInterval = nCreateLog.Value * 1000
            setting._mp3 = txtMp3.Text
            SystemSetting.WriteXML(Of SystemSetting)(setting, pathConfig)
            Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(pathEmail, False)
            For Each mail In rtbEmail.Lines
                outFile.WriteLine(mail)
            Next
            outFile.Close()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim odf As OpenFileDialog = New OpenFileDialog
        odf.Title = "Select mp3 file"
        odf.Filter = "All file (*mp3)|*.mp3"
        If odf.ShowDialog() = DialogResult.OK Then
            txtMp3.Text = odf.FileName
        End If
    End Sub
End Class