Partial Public Class frmMain
    Inherits DevExpress.XtraEditors.XtraForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnSettings = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSignSelected = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.bsGridItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnitNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCompliant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSigPageCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.chkSelectCompliant = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSelectNonCompliant = New DevExpress.XtraEditors.CheckEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lcSelectCompliant = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsGridItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSelectCompliant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSelectNonCompliant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcSelectCompliant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnSettings)
        Me.LayoutControl1.Controls.Add(Me.btnSignSelected)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.chkSelectCompliant)
        Me.LayoutControl1.Controls.Add(Me.chkSelectNonCompliant)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1207, 699)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(16, 655)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(106, 28)
        Me.btnSettings.StyleController = Me.LayoutControl1
        Me.btnSettings.TabIndex = 9
        Me.btnSettings.Text = "Settings..."
        '
        'btnSignSelected
        '
        Me.btnSignSelected.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.btnSignSelected.Appearance.Options.UseFont = True
        Me.btnSignSelected.Location = New System.Drawing.Point(880, 655)
        Me.btnSignSelected.Name = "btnSignSelected"
        Me.btnSignSelected.Size = New System.Drawing.Size(311, 28)
        Me.btnSignSelected.StyleController = Me.LayoutControl1
        Me.btnSignSelected.TabIndex = 6
        Me.btnSignSelected.Text = "Sign Selected PDFs"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.bsGridItems
        Me.GridControl1.Location = New System.Drawing.Point(16, 44)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1175, 605)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'bsGridItems
        '
        Me.bsGridItems.AllowNew = False
        Me.bsGridItems.DataSource = GetType(SignatureTool.GridListItem)
        '
        'GridView1
        '
        Me.GridView1.ActiveFilterEnabled = False
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSelected, Me.colUnitNumber, Me.colCompliant, Me.colSigPageCount, Me.colFile})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowDetailButtons = False
        Me.GridView1.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colSelected
        '
        Me.colSelected.Caption = "Select"
        Me.colSelected.FieldName = "Selected"
        Me.colSelected.Name = "colSelected"
        Me.colSelected.OptionsFilter.AllowAutoFilter = False
        Me.colSelected.OptionsFilter.AllowFilter = False
        Me.colSelected.Visible = True
        Me.colSelected.VisibleIndex = 0
        Me.colSelected.Width = 54
        '
        'colUnitNumber
        '
        Me.colUnitNumber.FieldName = "UnitNumber"
        Me.colUnitNumber.Name = "colUnitNumber"
        Me.colUnitNumber.OptionsColumn.ReadOnly = True
        Me.colUnitNumber.OptionsFilter.AllowAutoFilter = False
        Me.colUnitNumber.OptionsFilter.AllowFilter = False
        Me.colUnitNumber.Visible = True
        Me.colUnitNumber.VisibleIndex = 1
        Me.colUnitNumber.Width = 165
        '
        'colCompliant
        '
        Me.colCompliant.FieldName = "Compliant"
        Me.colCompliant.Name = "colCompliant"
        Me.colCompliant.OptionsColumn.ReadOnly = True
        Me.colCompliant.OptionsFilter.AllowAutoFilter = False
        Me.colCompliant.OptionsFilter.AllowFilter = False
        Me.colCompliant.Visible = True
        Me.colCompliant.VisibleIndex = 2
        Me.colCompliant.Width = 122
        '
        'colSigPageCount
        '
        Me.colSigPageCount.FieldName = "SigPageCount"
        Me.colSigPageCount.Name = "colSigPageCount"
        Me.colSigPageCount.OptionsColumn.ReadOnly = True
        Me.colSigPageCount.OptionsFilter.AllowAutoFilter = False
        Me.colSigPageCount.OptionsFilter.AllowFilter = False
        Me.colSigPageCount.Visible = True
        Me.colSigPageCount.VisibleIndex = 3
        Me.colSigPageCount.Width = 122
        '
        'colFile
        '
        Me.colFile.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.colFile.FieldName = "File"
        Me.colFile.Name = "colFile"
        Me.colFile.OptionsFilter.AllowAutoFilter = False
        Me.colFile.OptionsFilter.AllowFilter = False
        Me.colFile.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        Me.colFile.Visible = True
        Me.colFile.VisibleIndex = 4
        Me.colFile.Width = 710
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'chkSelectCompliant
        '
        Me.chkSelectCompliant.Location = New System.Drawing.Point(16, 16)
        Me.chkSelectCompliant.Name = "chkSelectCompliant"
        Me.chkSelectCompliant.Properties.Caption = "Select All Compliant"
        Me.chkSelectCompliant.Size = New System.Drawing.Size(218, 22)
        Me.chkSelectCompliant.StyleController = Me.LayoutControl1
        Me.chkSelectCompliant.TabIndex = 10
        '
        'chkSelectNonCompliant
        '
        Me.chkSelectNonCompliant.Location = New System.Drawing.Point(240, 16)
        Me.chkSelectNonCompliant.Name = "chkSelectNonCompliant"
        Me.chkSelectNonCompliant.Properties.Caption = "Select All Non-Compliant"
        Me.chkSelectNonCompliant.Size = New System.Drawing.Size(228, 22)
        Me.chkSelectNonCompliant.StyleController = Me.LayoutControl1
        Me.chkSelectNonCompliant.TabIndex = 11
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1, Me.EmptySpaceItem4, Me.LayoutControlItem3, Me.EmptySpaceItem3, Me.LayoutControlItem6, Me.lcSelectCompliant})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1207, 699)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1181, 611)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnSignSelected
        Me.LayoutControlItem3.Location = New System.Drawing.Point(864, 639)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(317, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSettings
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 639)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(112, 34)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(112, 639)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(752, 34)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'lcSelectCompliant
        '
        Me.lcSelectCompliant.Control = Me.chkSelectCompliant
        Me.lcSelectCompliant.Location = New System.Drawing.Point(0, 0)
        Me.lcSelectCompliant.Name = "lcSelectCompliant"
        Me.lcSelectCompliant.Size = New System.Drawing.Size(224, 28)
        Me.lcSelectCompliant.TextSize = New System.Drawing.Size(0, 0)
        Me.lcSelectCompliant.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.chkSelectNonCompliant
        Me.LayoutControlItem1.Location = New System.Drawing.Point(224, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(234, 28)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(458, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(723, 28)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 699)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("frmMain.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toolbox Forms Signature Tool"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsGridItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSelectCompliant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSelectNonCompliant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcSelectCompliant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents bsGridItems As BindingSource
    Friend WithEvents colSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnitNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCompliant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSigPageCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents btnSignSelected As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnSettings As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkSelectCompliant As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSelectNonCompliant As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lcSelectCompliant As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem

#End Region

End Class
