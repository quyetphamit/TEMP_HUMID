Imports System.IO

Public Class frmAbout
    Private setting As SystemSetting
    Dim pathConfig As String = My.Application.Info.DirectoryPath & "\Setup\config.xml"
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.webstorage-service.com/system/")
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(pathConfig) Then Common.SaveInitSystem(setting, pathConfig)
        SystemSetting.ReadXML(Of SystemSetting)(setting, pathConfig)
        lblUsername.Text = setting._username
        lblPassword.Text = setting._password
    End Sub
End Class