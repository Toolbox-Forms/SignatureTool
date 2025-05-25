Imports System.ComponentModel
Imports System.IO
Imports System.Text

Imports DevExpress.Pdf
Imports DevExpress.XtraGrid.Views.Grid

Imports Microsoft.WindowsAPICodePack.Dialogs

Partial Public Class frmMain

    Dim FileList As List(Of GridListItem)
    Dim frmsettings As New frmSettings
    Dim Settings As Settings = frmsettings.Settings

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub RefreshGrid()
        If Settings.SearchFolder <> "" Then
            If Directory.Exists(Settings.SearchFolder) Then
                Me.Cursor = Cursors.WaitCursor
                Dim fi = New DirectoryInfo(Settings.SearchFolder)
                FileList = New List(Of GridListItem)
                For Each fileInfo In fi.GetFiles(Settings.SearchPattern)
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

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim view As GridView = TryCast(GridView1, GridView)
        If view IsNot Nothing Then
            Dim fileName = CStr(view.GetFocusedRowCellValue("File"))
            Dim frm As New frmPDFViewer
            frm.PdfViewer1.LoadDocument(Settings.SearchFolder & "\" & fileName)
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

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim result = frmsettings.ShowDialog(Me)
        If result = DialogResult.OK Then
            MsgBox("Saved")
            RefreshGrid()
        End If
        frmsettings.Hide()
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

