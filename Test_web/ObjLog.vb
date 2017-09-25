Public Class ObjLog
    Public Property _no As String
    Public Property _time As String
    Public Property _area As String
    Public Property _temp As String
    Public Property _humid As String
    Public Sub New(ByVal no As String, ByVal time As String, ByVal area As String, ByVal temp As String, ByVal humid As String)
        _no = no
        _time = time
        _area = area
        _temp = temp
        _humid = humid
    End Sub
    Public Sub New(ByVal area As String, ByVal temp As String, ByVal humid As String, ByVal time As String)
        _area = area
        _temp = temp
        _humid = humid
        _time = time
    End Sub
End Class
