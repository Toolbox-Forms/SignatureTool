Imports System.IO
Imports System.Xml.Serialization

Imports DevExpress.XtraEditors

Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class frmSettings
    Friend Property Settings As Settings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings = frmMain.Settings
        inkSignature.Ink.Load(Settings.Signature)
        bsSettings.DataSource = Settings
        inkSignature.DefaultDrawingAttributes.Width = 125
        inkSignature.DefaultDrawingAttributes.Height = 125
        'Dim x As Rectangle
        'inkSignature.GetWindowInputRectangle(x)
        'x.Height = 100
        'x.Width = 500
        'x.X = inkSignature.Location.X
        'x.Y = inkSignature.Location.Y
        'inkSignature.SetWindowInputRectangle(x)
        'MsgBox("Here")
    End Sub

    Private Sub btnSigClear_Click(sender As Object, e As EventArgs) Handles btnSigClear.Click
        inkSignature.Enabled = False
        inkSignature.Ink.DeleteStrokes()
        inkSignature.Enabled = True
    End Sub

    Private Sub teCopySignedTo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim fd As New CommonOpenFileDialog
        fd.IsFolderPicker = True
        Dim result = fd.ShowDialog
        If result = DialogResult.OK Then
            teCopySignedTo.Text = fd.FileName
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Settings.Signature = inkSignature.Ink.Save(Microsoft.Ink.PersistenceFormat.Gif)
        bsSettings.ResetBindings(False)
        Dim ser As XmlSerializer = New XmlSerializer(GetType(Settings))
        Dim writer As StreamWriter = New StreamWriter("Settings.xml")
        ser.Serialize(writer, Settings)
        writer.Close()
        btnOK.DialogResult = DialogResult.OK
    End Sub

    Private Sub teCopySignedTo_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles teCopySignedTo.Properties.ButtonClick
        Dim fd As New CommonOpenFileDialog
        fd.IsFolderPicker = True
        Dim result = fd.ShowDialog
        If result = DialogResult.OK Then
            teCopySignedTo.Text = fd.FileName
        End If
    End Sub

    Private Sub teCurrentFolder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles teCurrentFolder.ButtonClick
        Dim fd As New CommonOpenFileDialog
        fd.IsFolderPicker = True
        Dim result = fd.ShowDialog
        If result = DialogResult.OK Then
            teCurrentFolder.Text = fd.FileName
            Me.Select(True, True)
        End If
    End Sub
End Class

Public Class Settings
    Property SearchFolder As String
    Property SearchPattern As String
    Property SearchSubfolders As Boolean
    Property MoveSignedTo As String
    Property Signature As Byte()

    Public Sub New()
        SearchFolder = ""
        SearchPattern = "*.*"
        SearchSubfolders = False
        MoveSignedTo = ""
        Signature = New Byte() {}
    End Sub
End Class