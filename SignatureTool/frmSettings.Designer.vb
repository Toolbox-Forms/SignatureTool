<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.inkSignature = New Microsoft.Ink.InkPicture()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSigClear = New DevExpress.XtraEditors.SimpleButton()
        Me.teCopySignedTo = New DevExpress.XtraEditors.ButtonEdit()
        Me.chkSearchSubdirectories = New DevExpress.XtraEditors.CheckEdit()
        Me.teFileNameSearch = New DevExpress.XtraEditors.TextEdit()
        Me.teCurrentFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.bsSettings = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.inkSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCopySignedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSearchSubdirectories.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teFileNameSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCurrentFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.inkSignature)
        Me.LayoutControl1.Controls.Add(Me.btnOK)
        Me.LayoutControl1.Controls.Add(Me.btnCancel)
        Me.LayoutControl1.Controls.Add(Me.btnSigClear)
        Me.LayoutControl1.Controls.Add(Me.teCopySignedTo)
        Me.LayoutControl1.Controls.Add(Me.chkSearchSubdirectories)
        Me.LayoutControl1.Controls.Add(Me.teFileNameSearch)
        Me.LayoutControl1.Controls.Add(Me.teCurrentFolder)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(564, 401)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'inkSignature
        '
        Me.inkSignature.BackColor = System.Drawing.Color.White
        Me.inkSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.inkSignature.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inkSignature.Location = New System.Drawing.Point(32, 201)
        Me.inkSignature.MaximumSize = New System.Drawing.Size(500, 100)
        Me.inkSignature.Name = "inkSignature"
        Me.inkSignature.Size = New System.Drawing.Size(500, 100)
        Me.inkSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.inkSignature.TabIndex = 8
        '
        'btnOK
        '
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(389, 357)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(73, 28)
        Me.btnOK.StyleController = Me.LayoutControl1
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(479, 357)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 28)
        Me.btnCancel.StyleController = Me.LayoutControl1
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'btnSigClear
        '
        Me.btnSigClear.Location = New System.Drawing.Point(458, 307)
        Me.btnSigClear.Name = "btnSigClear"
        Me.btnSigClear.Size = New System.Drawing.Size(74, 28)
        Me.btnSigClear.StyleController = Me.LayoutControl1
        Me.btnSigClear.TabIndex = 9
        Me.btnSigClear.Text = "Clear"
        '
        'teCopySignedTo
        '
        Me.teCopySignedTo.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bsSettings, "MoveSignedTo", True))
        Me.teCopySignedTo.Location = New System.Drawing.Point(148, 120)
        Me.teCopySignedTo.Name = "teCopySignedTo"
        Me.teCopySignedTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.teCopySignedTo.Size = New System.Drawing.Size(400, 32)
        Me.teCopySignedTo.StyleController = Me.LayoutControl1
        Me.teCopySignedTo.TabIndex = 7
        '
        'chkSearchSubdirectories
        '
        Me.chkSearchSubdirectories.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bsSettings, "SearchSubfolders", True))
        Me.chkSearchSubdirectories.Location = New System.Drawing.Point(148, 92)
        Me.chkSearchSubdirectories.Name = "chkSearchSubdirectories"
        Me.chkSearchSubdirectories.Properties.Caption = ""
        Me.chkSearchSubdirectories.Size = New System.Drawing.Size(400, 22)
        Me.chkSearchSubdirectories.StyleController = Me.LayoutControl1
        Me.chkSearchSubdirectories.TabIndex = 6
        '
        'teFileNameSearch
        '
        Me.teFileNameSearch.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bsSettings, "SearchPattern", True))
        Me.teFileNameSearch.Location = New System.Drawing.Point(148, 54)
        Me.teFileNameSearch.Name = "teFileNameSearch"
        Me.teFileNameSearch.Size = New System.Drawing.Size(400, 32)
        Me.teFileNameSearch.StyleController = Me.LayoutControl1
        Me.teFileNameSearch.TabIndex = 5
        '
        'teCurrentFolder
        '
        Me.teCurrentFolder.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bsSettings, "SearchFolder", True))
        Me.teCurrentFolder.Location = New System.Drawing.Point(148, 16)
        Me.teCurrentFolder.Name = "teCurrentFolder"
        Me.teCurrentFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.teCurrentFolder.Properties.EditValueChangedDelay = 1000
        Me.teCurrentFolder.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.teCurrentFolder.Size = New System.Drawing.Size(400, 32)
        Me.teCurrentFolder.StyleController = Me.LayoutControl1
        Me.teCurrentFolder.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlGroup1, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem2, Me.EmptySpaceItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(564, 401)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.teCurrentFolder
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Current Folder"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(538, 38)
        Me.LayoutControlItem1.Text = "Search Folder"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(116, 18)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.teFileNameSearch
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(538, 38)
        Me.LayoutControlItem2.Text = "Search Pattern"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(116, 18)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.chkSearchSubdirectories
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 76)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(538, 28)
        Me.LayoutControlItem3.Text = "Search Subfolders"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(116, 18)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.teCopySignedTo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(538, 38)
        Me.LayoutControlItem4.Text = "Move Signed To"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(116, 18)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 142)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(538, 199)
        Me.LayoutControlGroup1.Text = "Signature"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 106)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(426, 34)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSigClear
        Me.LayoutControlItem6.Location = New System.Drawing.Point(426, 106)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(80, 34)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.inkSignature
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(506, 106)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnCancel
        Me.LayoutControlItem7.Location = New System.Drawing.Point(463, 341)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(75, 34)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnOK
        Me.LayoutControlItem8.Location = New System.Drawing.Point(373, 341)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(79, 34)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 341)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(373, 34)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(452, 341)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(11, 34)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'bsSettings
        '
        Me.bsSettings.DataSource = GetType(SignatureTool.Settings)
        '
        'frmSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(564, 401)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("frmSettings.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        Me.LayoutControl1.PerformLayout()
        CType(Me.inkSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCopySignedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSearchSubdirectories.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teFileNameSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCurrentFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents teCopySignedTo As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents chkSearchSubdirectories As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents teFileNameSearch As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teCurrentFolder As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSigClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents inkSignature As Microsoft.Ink.InkPicture
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents bsSettings As BindingSource
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
