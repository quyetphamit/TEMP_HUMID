Imports System.IO
Imports System.Xml.Serialization

<Serializable(), XmlRoot("configuration")>
Public Class SystemSetting
    Private m__tempMin As String
    Private m__tempMax As String
    Private m__humidMin As String
    Private m__humidMax As String
    Private m__reloadWebInterval As String
    Private m__createLogInterval As String
    Private m__resetLog As String
    Private m__passConfig As String
    Private m__title As String
    Private m__connectionWarning As String
    Private m__printTempMin As String
    Private m__printTempMax As String
    Private m__printHumidMin As String
    Private m__printHumidMax As String
    Private m__username As String
    Private m__password As String
    Private m__email As String
    Private m__emailPass As String
    Private m__mp3 As String
    <XmlElement("tempMin")>
    Public Property _tempMin() As String
        Get
            Return m__tempMin
        End Get
        Set
            m__tempMin = Value
        End Set
    End Property
    <XmlElement("tempMax")>
    Public Property _tempMax() As String
        Get
            Return m__tempMax
        End Get
        Set
            m__tempMax = Value
        End Set
    End Property
    <XmlElement("humidMin")>
    Public Property _humidMin As String
        Get
            Return m__humidMin
        End Get
        Set
            m__humidMin = Value
        End Set
    End Property
    <XmlElement("humidMax")>
    Public Property _humidMax As String
        Get
            Return m__humidMax
        End Get
        Set
            m__humidMax = Value
        End Set
    End Property
    <XmlElement("reloadWebInterval")>
    Public Property _reloadWebInterval As String
        Get
            Return m__reloadWebInterval
        End Get
        Set
            m__reloadWebInterval = Value
        End Set
    End Property
    <XmlElement("createLogInterval")>
    Public Property _createLogInterval As String
        Get
            Return m__createLogInterval
        End Get
        Set
            m__createLogInterval = Value
        End Set
    End Property
    <XmlElement("resetLog")>
    Public Property _resetLog As String
        Get
            Return m__resetLog
        End Get
        Set
            m__resetLog = Value
        End Set
    End Property
    <XmlElement("passConfig")>
    Public Property _passConfig As String
        Get
            Return m__passConfig
        End Get
        Set
            m__passConfig = Value
        End Set
    End Property
    <XmlElement("title")>
    Public Property _title As String
        Get
            Return m__title
        End Get
        Set
            m__title = Value
        End Set
    End Property
    <XmlElement("connectionWaring")>
    Public Property _connectionWarning As String
        Get
            Return m__connectionWarning
        End Get
        Set
            m__connectionWarning = Value
        End Set
    End Property
    <XmlElement("printTempMin")>
    Public Property _printTempMin As String
        Get
            Return m__printTempMin
        End Get
        Set
            m__printTempMin = Value
        End Set
    End Property
    <XmlElement("printTempMax")>
    Public Property _printTempMax As String
        Get
            Return m__printTempMax
        End Get
        Set
            m__printTempMax = Value
        End Set
    End Property
    <XmlElement("printHumidMin")>
    Public Property _printHumidMin As String
        Get
            Return m__printHumidMin
        End Get
        Set
            m__printHumidMin = Value
        End Set
    End Property
    <XmlElement("printHumidMax")>
    Public Property _printHumidMax As String
        Get
            Return m__printHumidMax
        End Get
        Set
            m__printHumidMax = Value
        End Set
    End Property
    <XmlElement("username")>
    Public Property _username As String
        Get
            Return m__username
        End Get
        Set
            m__username = Value
        End Set
    End Property
    <XmlElement("password")>
    Public Property _password As String
        Get
            Return m__password
        End Get
        Set
            m__password = Value
        End Set
    End Property
    <XmlElement("email")>
    Public Property _email As String
        Get
            Return m__email
        End Get
        Set
            m__email = Value
        End Set
    End Property
    <XmlElement("emailPass")>
    Public Property _emailPass As String
        Get
            Return m__emailPass
        End Get
        Set
            m__emailPass = Value
        End Set
    End Property
    <XmlElement("mp3")>
    Public Property _mp3 As String
        Get
            Return m__mp3
        End Get
        Set
            m__mp3 = Value
        End Set
    End Property
    Public Shared Function ReadXML(Of Type)(ByRef pClass As Type, pPath As String) As Integer
        Dim serializer As New XmlSerializer(GetType(Type))
        Using stream As New FileStream(pPath, FileMode.Open)
            pClass = DirectCast(serializer.Deserialize(stream), Type)
        End Using
        Return 0
    End Function

    Public Shared Function WriteXML(Of Type)(pClass As Type, pPath As String) As Integer
        Dim serializer As New XmlSerializer(GetType(Type))
        Using stream As New FileStream(pPath, FileMode.Create)
            serializer.Serialize(DirectCast(stream, Stream), pClass)
        End Using
        Return 0
    End Function
End Class
