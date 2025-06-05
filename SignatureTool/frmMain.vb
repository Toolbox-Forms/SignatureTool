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
        Settings = New Settings
        If File.Exists("Settings.xml") Then
            Dim ser As New XmlSerializer(GetType(Settings))
            Using rdr As New FileStream("Settings.xml", FileMode.Open)
                Settings = CType(ser.Deserialize(rdr), Settings)
                CheckSignaturePresent()
                RefreshGrid()
            End Using
        Else
            XtraMessageBox.Show("Settings file not found. Be sure to set the configuration using the Settings button before signing!", "Warning", MessageBoxButtons.OK)
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
                Dim fi = New DirectoryInfo(Settings.SearchFolder)
                FileList = New List(Of GridListItem)
                If Settings.SearchPattern = "" Then Settings.SearchPattern = "*.*"
                Dim ToDoList = fi.GetFiles(Settings.SearchPattern)
                frmProg.ProgressBarControl1.Properties.Maximum = ToDoList.Count
                For Each fileInfo In ToDoList
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
                        MsgBox("Error loading " & fileInfo.Name)
                    End Try
                    For i = 1 To PDFProcessor.Document.Pages.Count
                        Dim pageText = PDFProcessor.GetPageText(i, New PdfTextExtractionOptions With {.ClipToCropBox = False})
                        If i = 1 Then
                            listItem.File = fileInfo.Name
                            listItem.FullPath = fileInfo.FullName
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
        For Each f In FileList
            If f.Selected Then
                Using processor = New PdfDocumentProcessor
                    processor.LoadDocument(f.FullPath)
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
                            ' The InkPicture control uses whatever DPI Windows dictates, which, if Windows 'scaling' is set to 100%, is 96 DPI.
                            gra.AddToPageForeground(pge, 96, 96)
                            'gra2.AddToPageForeground(pge, 72, 72)
                        Next
                    End Using
                    processor.FlattenForm()
                    processor.SaveDocument("c:\users\user\desktop\test.pdf")
                End Using
            End If
        Next
        MsgBox("Done")
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
    Property Selected As Boolean
    ReadOnly Property SigPageCount As Integer
        Get
            Return SigPages.Count
        End Get
    End Property
End Class

