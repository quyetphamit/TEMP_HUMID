Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Common
    Shared Function ReadTextFile(ByVal filePath As String, ByVal lineNumber As Integer) As String   ' nhap duong dan file va dong can doc
        Using file As New StreamReader(filePath)
            Dim line As String
            ' doc nhung Line trong text file khong can truy nhap'
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    line = " "
                End If
            Next
            'doc Line trong text file can truy nhap
            line = file.ReadLine()
            ' Succeded!
            Return line
            file.Close()
        End Using
    End Function
    Shared Function CounterlineTextFile(ByVal File_Path As String) As String    ' nhap duong dan file va dong can doc
        Dim counterLine As String = 0
        If System.IO.File.Exists(File_Path) = True Then                              ' xac nhan duong dan ton tai hay khong
            Dim objReader As New System.IO.StreamReader(File_Path)                   ' mo file theo duong dan
            While (objReader.ReadLine <> "")
                counterLine = counterLine + 1                                        ' doc theo tung dong file text
            End While
            objReader.Close()                                                        ' dong file text da mo
        Else
            MsgBox(File_Path & " Not found")
            End
        End If
        Return counterLine
    End Function
    Public Shared Function CompareFiles(ByVal file1FullPath As String, ByVal file2FullPath As String) As Boolean

        If Not File.Exists(file1FullPath) Or Not File.Exists(file2FullPath) Then
            'One or both of the files does not exist.
            Return False
        End If

        If file1FullPath = file2FullPath Then
            ' fileFullPath1 and fileFullPath2 points to the same file...
            Return True
        End If

        Try
            Dim file1Hash As String = hashFile(file1FullPath)
            Dim file2Hash As String = hashFile(file2FullPath)

            If file1Hash = file2Hash Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Function hashFile(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash() As Byte = md5.ComputeHash(reader)
                Return System.Text.Encoding.Unicode.GetString(hash)
            End Using
        End Using
    End Function
    Shared Function CreateHtml(ByVal filePath As String, ByVal tempRange As String, ByVal humidRange As String, ByVal content As StringBuilder) As Boolean
        Try
            Dim lobjWriter As New System.IO.StreamWriter(filePath, False)
            lobjWriter.WriteLine("<html>")
            lobjWriter.WriteLine("</head>")
            lobjWriter.WriteLine("<style>table, th, td {border: 1px solid black;border-collapse: collapse;font-size: 12px;}th, td {padding: 5px;}</style>")
            lobjWriter.WriteLine("</head>")
            lobjWriter.WriteLine("<body>")
            lobjWriter.WriteLine("<table width = '100%' ><tr style='background: #99CCFF'><th>No</th><th>Time</th><th>Area</th>")
            lobjWriter.WriteLine(String.Format("<th>{0}</th>", tempRange))
            lobjWriter.WriteLine(String.Format("<th>{0}</th>", humidRange))
            lobjWriter.WriteLine("</tr>")

            If content IsNot Nothing Then
                lobjWriter.WriteLine(content)
            End If
            lobjWriter.WriteLine("</table>")
            lobjWriter.WriteLine("</body></html>")
            lobjWriter.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Shared Function CreateHTML(ByVal tempRange As String, ByVal humidRange As String, ByVal content As StringBuilder) As String
        Dim buider As StringBuilder = New StringBuilder
        buider.Append("<html>
                <head>
                    <style>table, th, td {border: 1px solid black;border-collapse: collapse;font-size: 12px;}th, td {padding: 5px;}</style>
                </head>
                    <table width = '100%' ><tr style='background: #99CCFF'><th>No</th><th>Time</th><th>Area</th>")
        buider.Append(String.Format("<th>{0}</th>", tempRange))
        buider.Append(String.Format("<th>{0}</th>", humidRange))
        If content IsNot Nothing Then
            buider.Append(content)
        End If
        buider.Append("</table></body></html>")
        Return buider.ToString
    End Function
    Shared Function CreateCsvFile(ByVal filePath As String, ByVal header As String, ByVal apped As Boolean) As Boolean
        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filePath, apped)
        outFile.WriteLine(header)
        outFile.Close()
        Return True
    End Function
    Shared Function CreateCsvFile(ByVal filePath As String, ByVal apped As Boolean) As Boolean
        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filePath, apped)
        outFile.WriteLine("yes")
        outFile.Close()
        Return True
    End Function
    Shared Function getBetween(ByVal source As String, ByVal strStart As String, ByVal strEnd As String) As String
        Dim First As Integer
        Dim Last As Integer
        strStart = strStart.ToUpper
        strEnd = strEnd.ToUpper
        source = source.ToUpper
        If source.Contains(strStart) And source.Contains(strEnd) Then
            First = source.IndexOf(strStart, 0) + strStart.Length
            Last = source.IndexOf(strEnd, First)
            Return source.Substring(First, Last - First)
        Else
            Return ""
        End If
    End Function
    ''' <summary>
    ''' Cảnh báo không có kết nối
    ''' </summary>
    ''' <param name="time">Chuỗi thời gian đầu vào</param>
    ''' <param name="minute">Số phút giới hạn cảnh báo</param>
    ''' <returns>True nếu tới thời gian cảnh báo, False nếu chưa tới thời gian cảnh báo</returns>
    Shared Function WaringConnect(ByVal time As String, ByVal minute As Integer) As Boolean
        If Not time.Contains("minute") Then
            Return True
        ElseIf Convert.ToInt32(getBetween(time, "", "minute")) > minute Then
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' Check email
    ''' </summary>
    ''' <param name="email">Giá trị email cần check</param>
    ''' <returns>True nếu đó là emai, False nếu không phải là email</returns>
    Shared Function IsEmail(ByVal email As String) As Boolean
        'Regex email
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailExpression.IsMatch(email)
    End Function
    Shared Function IsTime(ByVal time As String) As Integer

        Static timeExpression As New Regex("^([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$")
        Return timeExpression.IsMatch(time)
    End Function
    ''' <summary>
    ''' Tìm kiếm email trong file text
    ''' </summary>
    ''' <param name="filePath">Đường dẫn lưu file</param>
    ''' <returns>List String email</returns>
    Shared Function FindEmail(ByVal filePath As String) As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        Try
            result = File.ReadAllLines(filePath).Where(Function(p) IsEmail(p)).ToList
        Catch ex As Exception
            MsgBox("Error " & ex.ToString)
        End Try
        Return result
    End Function
    Shared Function Translate(ByVal input As String) As String
        If input.Contains("minute") Then
            Return " phút trước"
        ElseIf input.Contains(" hour") Then
            Return " giờ trước"
        ElseIf input.Contains("day") Then
            Return " ngày trước"
        Else
            Return "Dữ liệu cũ"
        End If
    End Function
    ''' <summary>
    ''' Lấy phần số trong 1 chuỗi
    ''' </summary>
    ''' <param name="value">Chuỗi đầu vào</param>
    ''' <returns>Trả về trống nếu chuỗi có kí tự older, ngược lại trả về số</returns>
    Shared Function GetNumber(ByVal value As String) As String
        Dim returnVal As String = String.Empty
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        If value.Contains("older") Then
            Return ""
        Else
            For Each m As Match In collection
                returnVal += m.ToString()
            Next
            Return returnVal
        End If
    End Function
    ''' <summary>
    ''' Tìm kết quả dựa vào từ khóa
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="keyword">Từ khóa</param>
    ''' <returns></returns>
    Shared Function Search(ByVal filePath As String, ByVal keyword As String) As String
        Dim result As String = String.Empty
        Try
            result = File.ReadLines(filePath).SkipWhile(Function(p) Not p.Contains(keyword)).Skip(1).SkipWhile(Function(q) q = "").Take(1).FirstOrDefault
        Catch ex As Exception
            MsgBox("Error" & ex.ToString)
        End Try
        Return result
    End Function
    Shared Function GetListnumber(ByVal input As String) As List(Of String)
        Dim result As List(Of String) = New List(Of String)
        Dim numbers As StringBuilder = New StringBuilder()
        Dim chars = input.ToCharArray()
        For Each c As Char In chars
            If (Char.IsNumber(c)) Then
                numbers.Append(c)
            End If
            If ((Char.IsNumber(c) = False And numbers.Length > 0) Or (Char.IsNumber(c) And c = chars.Last())) Then
                Console.WriteLine(input.IndexOf(c))
                Console.WriteLine(chars.Length - 1)
                result.Add(numbers.ToString)
                numbers = New StringBuilder
            End If
        Next
        Return result
    End Function
    Shared Function GetTime(ByVal input As String) As String
        Dim result As String = String.Empty
        Dim now As DateTime = DateTime.Now
        Dim time As DateTime = Convert.ToDateTime(input)
        Dim total As Double = (now - time).TotalSeconds
        If total < 60 Then
            result = "0 minute(s) ago"
        ElseIf total < 3600 Then
            result = String.Format("{0} minute(s) ago", Math.Round(total / 60, 0))
        ElseIf total < 86400 Then
            result = String.Format("{0} hour(s) ago", Math.Round(total / 3600, 0))
        Else
            result = "older data"
        End If
        Return result
    End Function
    Shared Function SaveInitSystem(ByVal setting As SystemSetting, ByVal path As String) As Integer
        setting = New SystemSetting()
        setting._tempMin = 15
        setting._tempMax = 29
        setting._humidMin = 40
        setting._humidMax = 70
        setting._reloadWebInterval = 100000
        setting._createLogInterval = 600000
        setting._resetLog = "08:00:00"
        setting._passConfig = "umcvn"
        setting._title = "UMC Electronics Viet Nam "
        setting._connectionWarning = 59
        setting._printTempMin = 22
        setting._printTempMax = 28
        setting._printHumidMin = 40
        setting._printHumidMax = 60
        setting._username = "tdgd9370"
        setting._password = "cuongadn90"
        setting._email = "UMCVN.Temp.Humi@gmail.com"
        setting._emailPass = "umcvn2017"
        setting._mp3 = "D:\1.mp3"
        setting._enableAlarmConnection = True
        SystemSetting.WriteXML(Of SystemSetting)(setting, path)
        Return 0
    End Function
End Class
