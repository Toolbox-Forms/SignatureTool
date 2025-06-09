Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Xml.Serialization

Imports DevExpress.Drawing
Imports DevExpress.Pdf
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Imports Microsoft.WindowsAPICodePack.Dialogs

Partial Public Class frmMain

    Dim FileList As List(Of GridListItem)
    Property Settings As Settings

    Public Sub New()
        InitializeComponent()

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\wyupdate.exe") Then
            Dim p As New System.Diagnostics.Process()
            p.StartInfo.FileName = "wyupdate.exe"
            p.StartInfo.Arguments = "/quickcheck /justcheck /noerr"
            p.StartInfo.WorkingDirectory = My.Application.Info.DirectoryPath
            p.Start()
            p.WaitForExit()
            If p.ExitCode = 2 Then
                'Update Available
                p.StartInfo.Arguments = ""
                p.Start()
                End  'End this application. The updater will restart it.
            End If
        End If

        Settings = New Settings
        If File.Exists("Settings.xml") Then
            Dim ser As New XmlSerializer(GetType(Settings))
            Using rdr As New FileStream("Settings.xml", FileMode.Open)
                Settings = CType(ser.Deserialize(rdr), Settings)
                CheckSignaturePresent()
                RefreshGrid()
            End Using
        Else
            XtraMessageBox.Show("Settings file not found. Set the configuration using the Settings button before signing!", "Warning", MessageBoxButtons.OK)
        End If

        'Dim x = New frmProgress
        'x.Show()
        'x.ProgressBarControl1.Properties.Maximum = 33
        'For i = 1 To 33
        '    x.ProgressBarControl1.PerformStep()
        '    x.ProgressBarControl1.Update()
        '    System.Windows.Forms.Application.DoEvents()
        'Next
        'x.Close()
    End Sub

    Private Sub RefreshGrid()
        If Settings.SearchFolder <> "" Then
            If Directory.Exists(Settings.SearchFolder) Then
                Me.Cursor = Cursors.WaitCursor
                Dim frmProg = New frmProgress
                frmProg.Show()
                System.Windows.Forms.Application.DoEvents()

                'Search for files to place in grid
                Dim FoundFilesList As List(Of FileInfo) = New List(Of FileInfo)
                Dim searchDirQ As New Queue(Of DirectoryInfo)
                Dim searchFileQ As New Queue(Of DirectoryInfo)
                'Add in each directory specified in the Params. These are NOT check for the sub-folder search pattern
                searchDirQ.Enqueue(New DirectoryInfo(Settings.SearchFolder))
                searchFileQ.Enqueue(New DirectoryInfo(Settings.SearchFolder))
                'Create a list of sub-folder search patterns
                If Settings.SearchPattern = "" Then Settings.SearchPattern = "*.pdf"
                Dim searchDirPattern = Settings.SearchPattern
                'Add in subfolders
                If Settings.SearchSubfolders Then
                    'Process each folder in the queue
                    Do Until searchDirQ.Count = 0
                        Dim directory = searchDirQ.Dequeue
                        'Add any sub-folders within current folder
                        Dim dirs() As DirectoryInfo = Nothing
                        dirs = directory.GetDirectories
                        For Each sd In dirs
                            'Add this folder to list of folders to look in for subfolders
                            searchDirQ.Enqueue(sd)
                            For Each sfp In searchDirPattern
                                If sd.Name Like sfp Then
                                    'Add this folder to look for files in
                                    searchFileQ.Enqueue(sd)
                                End If
                            Next
                        Next
                    Loop
                End If
                'searchFileQ should now contain the initial params.ReadFolders, and (if selected) any subdirectories within those trees that match params.SubfolderSearchPattern.
                'Effectively, these are the folders we are going to look for files within.
                Do Until searchFileQ.Count = 0
                    Dim directory = searchFileQ.Dequeue
                    'Search for files in current dir
                    Dim flist As List(Of FileInfo) = New List(Of FileInfo)
                    flist = directory.GetFiles(Settings.SearchPattern).ToList
                    If flist.Count > 0 Then
                        FoundFilesList.AddRange(flist)
                    End If
                Loop

                frmProg.ProgressBarControl1.Properties.Maximum = FoundFilesList.Count

                'Process each found file
                FileList = New List(Of GridListItem)
                For Each fileInfo In FoundFilesList
                    frmProg.ProgressBarControl1.PerformStep()
                    frmProg.ProgressBarControl1.Update()
                    'System.Windows.Forms.Application.DoEvents()
                    Dim listItem As New GridListItem
                    'Strip to "U[xxxx]"
                    Dim _UString = fileInfo.Name.Split(CChar("_")).FirstOrDefault(Function(c) Strings.Left(c, 1) = "U")
                    'Strip to "xxxx"
                    If Len(_UString) >= 3 Then
                        listItem.UnitNumber = Mid(_UString, 3, Len(_UString) - 3).ToUpper.Trim
                    End If

                    Dim PDFProcessor = New PdfDocumentProcessor
                    Try
                        PDFProcessor.LoadDocument(fileInfo.FullName)
                    Catch ex As Exception
                        XtraMessageBox.Show("Error loading file '" & fileInfo.Name & "' as a PDF file. Skipping.", "Warning", MessageBoxButtons.OK)
                        Continue For
                    End Try
                    For i = 1 To PDFProcessor.Document.Pages.Count
                        Dim pageText = PDFProcessor.GetPageText(i, New PdfTextExtractionOptions With {.ClipToCropBox = False})
                        If i = 1 Then
                            listItem.File = fileInfo.Name
                            listItem.FullPath = fileInfo.DirectoryName
                            listItem.Selected = False
                            listItem.Compliant = "Unknown"
                            If pageText.IndexOf("NOT IN COMPLIANCE") > 0 Then
                                listItem.Compliant = "No"
                            ElseIf pageText.IndexOf("IS IN COMPLIANCE") > 0 Then
                                listItem.Compliant = "Yes"
                            End If
                        End If
                        If pageText.ToUpper.IndexOf("OWNER SIGNATURE") > 0 Then
                            listItem.SigPages.Add(i)
                        End If
                    Next
                    FileList.Add(listItem)
                Next
                bsGridItems.DataSource = FileList
                chkSelectCompliant.CheckState = CheckState.Unchecked
                chkSelectNonCompliant.CheckState = CheckState.Unchecked
                Me.Cursor = Cursors.Default
                frmProg.Close()
            End If
        End If
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim view As GridView = TryCast(GridView1, GridView)
        If view IsNot Nothing Then
            Dim fileName = CStr(view.GetFocusedRowCellValue("File"))
            Dim frm As New frmPDFViewer
            frm.PdfViewer1.LoadDocument(Settings.SearchFolder & "\" & fileName)
            frm.Show(Me)
        End If
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim frm As New frmSettings
        If frm.ShowDialog(Me) = DialogResult.OK Then
            Settings = frm.Settings
            CheckSignaturePresent()
            RefreshGrid()
        End If
        'frm.Close()
    End Sub

    Private Sub CheckSignaturePresent()
        If Settings.Signature.Length = 0 Then
            XtraMessageBox.Show("No signature is currently set. Please create a signature using the Settings button before signing files!", "Warning", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnSignSelected_Click(sender As Object, e As EventArgs) Handles btnSignSelected.Click
        Dim ToDoList As List(Of GridListItem) = New List(Of GridListItem)
        Dim CompliantCount As Integer = 0
        Dim NonCompliantCount As Integer = 0
        Dim OtherCount As Integer = 0
        For Each f In FileList
            If f.Selected Then
                ToDoList.Add(f)
                Select Case f.Compliant
                    Case "Yes"
                        CompliantCount += 1
                    Case "No"
                        NonCompliantCount += 1
                    Case Else
                        OtherCount = 1
                End Select
            End If
        Next
        Dim DoConfirm As Boolean = False
        If CompliantCount + NonCompliantCount + OtherCount > 0 Then
            Dim ConfirmMsg As String = "You are about to sign:"
            If CompliantCount > 0 Then
                ConfirmMsg &= vbCrLf & "  " & CompliantCount.ToString & " Compliant Unit Inspection"
                If CompliantCount > 1 Then ConfirmMsg &= "s"
            End If
            If NonCompliantCount > 0 Then
                ConfirmMsg &= vbCrLf & "  " & NonCompliantCount.ToString & " NON-Compliant Unit Inspection"
                If NonCompliantCount > 1 Then ConfirmMsg &= "s"
            End If
            If OtherCount > 0 Then
                ConfirmMsg &= vbCrLf & "  " & OtherCount.ToString & " UNKNOWN Status Unit Inspection"
                If OtherCount > 1 Then ConfirmMsg &= "s"
            End If
            If XtraMessageBox.Show(ConfirmMsg, "Confirm", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                DoConfirm = True
            End If
        Else
            XtraMessageBox.Show("No documents selected for signing.", "Warning", MessageBoxButtons.OK)
        End If

        If DoConfirm Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmProg = New frmProgress
            frmProg.lblDescription.Text = "Signing Documents..."
            frmProg.ProgressBarControl1.Properties.Maximum = ToDoList.Count
            frmProg.Show()
            System.Windows.Forms.Application.DoEvents()
            For Each f In ToDoList
                frmProg.ProgressBarControl1.PerformStep()
                frmProg.ProgressBarControl1.Update()
                Dim SaveOK As Boolean = False
                Using processor = New PdfDocumentProcessor
                    'Load PDF
                    processor.LoadDocument(f.FullPath & "\" & f.File)
                    'Apply the signature
                    Dim dateText As String = Format(Today, "Short Date")
                    Dim sigLocation As New RectangleF(450, 990, 200, 30)
                    Dim dateFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    Dim dateLocation As New PointF(692, 970)    'At 96 DPI
                    Dim dateBrush As New SolidBrush(Color.FromArgb(255, Color.Black))
                    Using gra As PdfGraphics = processor.CreateGraphics
                        gra.DrawString(dateText, dateFont, dateBrush, dateLocation)
                        gra.DrawImage(Settings.Signature, sigLocation)
                        For Each p In f.SigPages
                            Dim pge As PdfPage = processor.Document.Pages(p - 1)
                            'The DPI here doesn't change the resolution. It's to specify what resolution the source GIF is,
                            ' to achieve proper coordinate transformation ('world' coordinates to 'page' coordinates).
                            ' The InkPicture control uses whatever DPI Windows dictates, which is 96 DPI if Windows 'scaling' is set to 100%
                            gra.AddToPageForeground(pge, 96, 96)
                        Next
                    End Using
                    'Save it
                    processor.FlattenForm()
                    Dim SaveFilePath = Replace(Path.GetFullPath(f.FullPath), Settings.SearchFolder, Settings.MoveSignedTo)
                    If SaveFilePath = "" Then
                        'Saving in the same dir as original file
                        SaveFilePath = f.FullPath & "\"
                    Else
                        SaveFilePath &= "\"
                        If Not Directory.Exists(SaveFilePath) Then
                            Directory.CreateDirectory(SaveFilePath)
                        End If
                    End If
                    Dim SaveFileName = Path.GetFileNameWithoutExtension(f.File) & "_signed"
                    Dim x = SaveFilePath & SaveFileName & Path.GetExtension(f.File)
                    processor.SaveDocument(SaveFilePath & SaveFileName & Path.GetExtension(f.File))
                    SaveOK = True
                End Using
                If SaveOK Then
                    File.Delete(f.FullPath & "\" & f.File)
                End If
            Next
            Me.Cursor = Cursors.Default
            frmProg.Close()
            XtraMessageBox.Show("Signing complete", "Success", MessageBoxButtons.OK)
            RefreshGrid()
        End If
    End Sub

    Private Sub chkSelectCompliant_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectCompliant.CheckedChanged
        For Each i In FileList
            If i.Compliant = "Yes" Then
                i.Selected = chkSelectCompliant.Checked
            End If
        Next
        bsGridItems.ResetBindings(False)
    End Sub

    Private Sub chkSelectNonCompliant_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectNonCompliant.CheckedChanged
        For Each i In FileList
            If i.Compliant = "No" Then
                i.Selected = chkSelectNonCompliant.Checked
            End If
        Next
        bsGridItems.ResetBindings(False)
    End Sub
End Class

Friend Class GridListItem
    Property UnitNumber As String
    Property Compliant As String
    Property File As String
    Property FullPath As String
    Property SigPages As List(Of Integer) = New List(Of Integer)
    Property Selected As Boolean = False
    ReadOnly Property SigPageCount As Integer
        Get
            Return SigPages.Count
        End Get
    End Property
End Class

