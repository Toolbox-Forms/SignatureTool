Imports System.IO
Imports System.Xml.Serialization

Imports DevExpress.XtraEditors

Imports Microsoft.Ink
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class frmSettings
    Friend Property Settings As Settings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings = frmMain.Settings
        inkSignature.Ink.Load(Settings.Signature)
        bsSettings.DataSource = Settings
        lblVersion.Text = "Version: " & FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion
        'inkSignature.DefaultDrawingAttributes.Width = 125
        'inkSignature.DefaultDrawingAttributes.Height = 125

        ''Dim x As New Rectangle With {.Location = New Point With {.X = inkSignature.Location.X,
        ''                                                         .Y = inkSignature.Location.Y},
        ''                             .Height = inkSignature.Height,
        ''                             .Width = inkSignature.Width}

        ''Dim x As New Rectangle With {.Location = New Point With {.X = 1,
        ''                                                         .Y = 1},
        ''                             .Height = 250,
        ''                             .Width = 250}

        ''inkSignature.GetWindowInputRectangle(x)
        ''x.Width = 500
        ''x.X = inkSignature.Location.X
        ''x.Y = inkSignature.Location.Y

        ''inkSignature.SetWindowInputRectangle(x)
        'inkSignature.DefaultDrawingAttributes = New DrawingAttributes With {.Height = 100, .Width = 100}

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
        If inkSignature.Ink.Strokes.Count = 0 Then
            Settings.Signature = New Byte() {}
        Else
            'The InkPicture collects strokes over the entire desktop. We need
            ' clip the ink to just what's contained in the Ink control.
            '
            'Need a Graphics opject for conversion from Pixels to InkSpace
            Dim g = inkSignature.CreateGraphics
            'Upper left clip point is 0,0
            'Lower right clip point, based on size of control
            Dim LRClip = New Point(CInt(g.VisibleClipBounds.Height), CInt(g.VisibleClipBounds.Width))
            'Convert the LRClip point to an Ink Space point
            inkSignature.Renderer.PixelToInkSpace(g, LRClip)
            'Clip the ink to the size of the control
            inkSignature.Ink.Clip(New Rectangle With {.X = 0,
                                                        .Y = 0,
                                                        .Height = LRClip.X,
                                                        .Width = LRClip.Y})
            If inkSignature.Ink.Strokes.Count = 0 Then
                Settings.Signature = New Byte() {}  'No signature, save an empty array
            Else
                Settings.Signature = inkSignature.Ink.Save(Microsoft.Ink.PersistenceFormat.Gif)
                Dim imagestream As MemoryStream
                imagestream = New MemoryStream(Settings.Signature)
            End If

        End If
        bsSettings.ResetBindings(False)
        Dim ser As XmlSerializer = New XmlSerializer(GetType(Settings))
        Dim writer As StreamWriter = New StreamWriter("Settings.xml")
        ser.Serialize(writer, Settings)
        writer.Close()
        DialogResult = DialogResult.OK
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

    Private Sub lblVersion_DoubleClick(sender As Object, e As EventArgs) Handles lblVersion.DoubleClick
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\wyupdate.exe") Then
            Dim p As New System.Diagnostics.Process()
            p.StartInfo.FileName = "wyupdate.exe"
            p.StartInfo.Arguments = "/quickcheck /justcheck /noerr"
            p.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath
            p.Start()
            p.WaitForExit()
            If p.ExitCode = 2 Then
                'Update Available
                p.StartInfo.Arguments = "/skipinfo"
                p.Start()
                End  'End this application. The updater will restart it.
            Else
                XtraMessageBox.Show("No Updates Found", "Update", MessageBoxButtons.OK)
            End If
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