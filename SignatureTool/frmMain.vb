Imports System.ComponentModel
Imports System.IO
Imports System.Text

Imports DevExpress.Pdf
Imports DevExpress.XtraGrid.Views.Grid

Partial Public Class frmMain

    Dim FileList As List(Of GridListItem)
    Public Sub New()
        InitializeComponent()
        Dim f As New frmSignature
        Dim result = f.ShowDialog(Me)
        If result = DialogResult.OK Then
            MsgBox("Sig Saved")
        End If
    End Sub

    Private Sub RefreshGrid()
        If teCurrentFolder.Text <> "" Then
            If Directory.Exists(teCurrentFolder.Text) Then
                Me.Cursor = Cursors.WaitCursor
                Dim fi = New DirectoryInfo(teCurrentFolder.Text)
                FileList = New List(Of GridListItem)
                For Each f In fi.GetFiles
                    Dim listItem As New GridListItem
                    'Strip to "U[xxxx]"
                    Dim _UString = f.Name.Split(CChar("_")).FirstOrDefault(Function(c) Strings.Left(c, 1) = "U")
                    'Strip to "xxxx"
                    If Len(_UString) >= 3 Then
                        listItem.UnitNumber = Mid(_UString, 3, Len(_UString) - 3).ToUpper.Trim
                    End If

                    Dim PDFProcessor = New PdfDocumentProcessor
                    Try
                        PDFProcessor.LoadDocument(f.FullName)
                    Catch ex As Exception
                        MsgBox("Error loading " & f.Name)
                    End Try
                    For i = 1 To PDFProcessor.Document.Pages.Count
                        Dim pageText = PDFProcessor.GetPageText(i, New PdfTextExtractionOptions With {.ClipToCropBox = False})
                        If i = 1 Then
                            listItem.File = f.Name
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
            End If
        End If
    End Sub

    Private Sub teCurrentFolder_Leave(sender As Object, e As EventArgs) Handles teCurrentFolder.Leave
        If teCurrentFolder.IsModified Then
            RefreshGrid()
        End If
    End Sub

    Private Sub teCurrentFolder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles teCurrentFolder.ButtonClick
        Dim fd As New FolderBrowserDialog
        Dim result = fd.ShowDialog
        If result = DialogResult.OK Then
            teCurrentFolder.Text = fd.SelectedPath
        End If

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim view As GridView = TryCast(GridView1, GridView)
        If view IsNot Nothing Then
            Dim x = CStr(view.GetFocusedRowCellValue("File"))
            Dim frm As New frmPDFViewer
            frm.PdfViewer1.LoadDocument(teCurrentFolder.Text & "\" & x)
            frm.Show(Me)
        End If
    End Sub

    Private Sub btnSelectCompliant_CheckedChanged(sender As Object, e As EventArgs) Handles btnSelectCompliant.CheckedChanged
        For Each i In FileList
            If i.Compliant = "Yes" Then
                i.Selected = btnSelectCompliant.Checked
            End If
        Next
        bsGridItems.ResetBindings(False)
        Select Case btnSelectCompliant.Checked
            Case True
                btnSelectCompliant.Text = "Unselect All Compliant Units"
            Case Else
                btnSelectCompliant.Text = "Select All Compliant Units"
        End Select
    End Sub
End Class

Friend Class GridListItem
    Property UnitNumber As String
    Property Compliant As String
    Property File As String
    Property SigPages As List(Of Integer) = New List(Of Integer)
    Property Selected As Boolean
    ReadOnly Property SigPageCount As Integer
        Get
            Return SigPages.Count
        End Get
    End Property
End Class