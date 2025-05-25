Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class frmSettings
    Friend Property Settings As Settings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings = New Settings
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
        Settings.Signature = inkSignature.Ink.Save()
        bsSettings.ResetBindings(False)
    End Sub

    Private Sub teCurrentFolder_Properties_Click(sender As Object, e As EventArgs) Handles teCurrentFolder.Properties.Click
        Dim fd As New CommonOpenFileDialog
        fd.IsFolderPicker = True
        Dim result = fd.ShowDialog
        If result = DialogResult.OK Then
            teCurrentFolder.Text = fd.FileName
        End If
    End Sub
End Class

Friend Class Settings
    Property SearchFolder As String
    Property SearchPattern As String
    Property SearchSubfolders As Boolean
    Property MoveSignedTo As String
    Property Signature As Byte()
End Class