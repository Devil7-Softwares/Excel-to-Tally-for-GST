<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_LoadExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu_Excel = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btn_SaveFormat = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_XML_File_Parties = New DevExpress.XtraBars.BarButtonItem()
        Me.txt_TallyVersion = New DevExpress.XtraBars.BarEditItem()
        Me.txt_TallyVersion_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txt_CompanyName = New DevExpress.XtraBars.BarEditItem()
        Me.txt_CompanyName_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.rp_PurchaseEntries = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Purchase = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_Parties = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Parties = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_Tally = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.gc_Parties = New DevExpress.XtraGrid.GridControl()
        Me.gv_Parties = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.container_Tabs = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_PurchaseEntries = New DevExpress.XtraTab.XtraTabPage()
        Me.ProgressPanel_PurchaseEntries = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.gc_PurchaseEntries = New DevExpress.XtraGrid.GridControl()
        Me.gv_PurchaseEntries = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Parties = New DevExpress.XtraTab.XtraTabPage()
        Me.ProgressPanel_Parties = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.OpenFileDialog_Excel = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog_Excel = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog_XML = New System.Windows.Forms.SaveFileDialog()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TallyVersion_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CompanyName_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.container_Tabs.SuspendLayout()
        Me.tp_PurchaseEntries.SuspendLayout()
        CType(Me.gc_PurchaseEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_PurchaseEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Parties.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_LoadExcel, Me.btn_SaveFormat, Me.btn_XML_File_Parties, Me.txt_TallyVersion, Me.txt_CompanyName})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 7
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_PurchaseEntries, Me.rp_Parties, Me.rp_Tally})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txt_TallyVersion_Edit, Me.txt_CompanyName_Edit})
        Me.RibbonControl.Size = New System.Drawing.Size(442, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'btn_LoadExcel
        '
        Me.btn_LoadExcel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.btn_LoadExcel.Caption = "Import Excel"
        Me.btn_LoadExcel.DropDownControl = Me.PopupMenu_Excel
        Me.btn_LoadExcel.Id = 1
        Me.btn_LoadExcel.ImageOptions.SvgImage = CType(resources.GetObject("btn_LoadExcel.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_LoadExcel.Name = "btn_LoadExcel"
        '
        'PopupMenu_Excel
        '
        Me.PopupMenu_Excel.ItemLinks.Add(Me.btn_SaveFormat)
        Me.PopupMenu_Excel.Name = "PopupMenu_Excel"
        Me.PopupMenu_Excel.Ribbon = Me.RibbonControl
        '
        'btn_SaveFormat
        '
        Me.btn_SaveFormat.Caption = "Save Empty Format"
        Me.btn_SaveFormat.Id = 2
        Me.btn_SaveFormat.Name = "btn_SaveFormat"
        '
        'btn_XML_File_Parties
        '
        Me.btn_XML_File_Parties.Caption = "To File"
        Me.btn_XML_File_Parties.Id = 3
        Me.btn_XML_File_Parties.ImageOptions.SvgImage = CType(resources.GetObject("btn_XML_File_Parties.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_XML_File_Parties.Name = "btn_XML_File_Parties"
        '
        'txt_TallyVersion
        '
        Me.txt_TallyVersion.Caption = "Tally Version     "
        Me.txt_TallyVersion.Edit = Me.txt_TallyVersion_Edit
        Me.txt_TallyVersion.EditWidth = 150
        Me.txt_TallyVersion.Id = 4
        Me.txt_TallyVersion.Name = "txt_TallyVersion"
        '
        'txt_TallyVersion_Edit
        '
        Me.txt_TallyVersion_Edit.AutoHeight = False
        Me.txt_TallyVersion_Edit.Name = "txt_TallyVersion_Edit"
        '
        'txt_CompanyName
        '
        Me.txt_CompanyName.Caption = "Company Name"
        Me.txt_CompanyName.Edit = Me.txt_CompanyName_Edit
        Me.txt_CompanyName.EditWidth = 150
        Me.txt_CompanyName.Id = 5
        Me.txt_CompanyName.Name = "txt_CompanyName"
        '
        'txt_CompanyName_Edit
        '
        Me.txt_CompanyName_Edit.AutoHeight = False
        Me.txt_CompanyName_Edit.Name = "txt_CompanyName_Edit"
        '
        'rp_PurchaseEntries
        '
        Me.rp_PurchaseEntries.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Purchase})
        Me.rp_PurchaseEntries.Name = "rp_PurchaseEntries"
        Me.rp_PurchaseEntries.Text = "Purchase Entries"
        '
        'rpg_Items_Purchase
        '
        Me.rpg_Items_Purchase.ItemLinks.Add(Me.btn_LoadExcel)
        Me.rpg_Items_Purchase.Name = "rpg_Items_Purchase"
        Me.rpg_Items_Purchase.ShowCaptionButton = False
        Me.rpg_Items_Purchase.Text = "Items"
        '
        'rp_Parties
        '
        Me.rp_Parties.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Parties, Me.RibbonPageGroup1})
        Me.rp_Parties.Name = "rp_Parties"
        Me.rp_Parties.Text = "Parties"
        '
        'rpg_Items_Parties
        '
        Me.rpg_Items_Parties.ItemLinks.Add(Me.btn_LoadExcel)
        Me.rpg_Items_Parties.Name = "rpg_Items_Parties"
        Me.rpg_Items_Parties.ShowCaptionButton = False
        Me.rpg_Items_Parties.Text = "Items"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btn_XML_File_Parties)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.ShowCaptionButton = False
        Me.RibbonPageGroup1.Text = "Export"
        '
        'rp_Tally
        '
        Me.rp_Tally.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.rp_Tally.Name = "rp_Tally"
        Me.rp_Tally.Text = "Tally"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.txt_TallyVersion)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.txt_CompanyName)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Variables"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(442, 31)
        '
        'gc_Parties
        '
        Me.gc_Parties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Parties.Location = New System.Drawing.Point(0, 0)
        Me.gc_Parties.MainView = Me.gv_Parties
        Me.gc_Parties.MenuManager = Me.RibbonControl
        Me.gc_Parties.Name = "gc_Parties"
        Me.gc_Parties.Size = New System.Drawing.Size(436, 247)
        Me.gc_Parties.TabIndex = 2
        Me.gc_Parties.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Parties})
        '
        'gv_Parties
        '
        Me.gv_Parties.GridControl = Me.gc_Parties
        Me.gv_Parties.Name = "gv_Parties"
        '
        'container_Tabs
        '
        Me.container_Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.container_Tabs.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.container_Tabs.Location = New System.Drawing.Point(0, 143)
        Me.container_Tabs.Name = "container_Tabs"
        Me.container_Tabs.SelectedTabPage = Me.tp_PurchaseEntries
        Me.container_Tabs.Size = New System.Drawing.Size(442, 275)
        Me.container_Tabs.TabIndex = 3
        Me.container_Tabs.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_PurchaseEntries, Me.tp_Parties})
        '
        'tp_PurchaseEntries
        '
        Me.tp_PurchaseEntries.Controls.Add(Me.ProgressPanel_PurchaseEntries)
        Me.tp_PurchaseEntries.Controls.Add(Me.gc_PurchaseEntries)
        Me.tp_PurchaseEntries.Name = "tp_PurchaseEntries"
        Me.tp_PurchaseEntries.Size = New System.Drawing.Size(436, 247)
        Me.tp_PurchaseEntries.Text = "Purchase Entries"
        '
        'ProgressPanel_PurchaseEntries
        '
        Me.ProgressPanel_PurchaseEntries.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_PurchaseEntries.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_PurchaseEntries.BarAnimationElementThickness = 2
        Me.ProgressPanel_PurchaseEntries.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel_PurchaseEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel_PurchaseEntries.Location = New System.Drawing.Point(0, 0)
        Me.ProgressPanel_PurchaseEntries.Name = "ProgressPanel_PurchaseEntries"
        Me.ProgressPanel_PurchaseEntries.Size = New System.Drawing.Size(436, 247)
        Me.ProgressPanel_PurchaseEntries.TabIndex = 4
        Me.ProgressPanel_PurchaseEntries.Visible = False
        '
        'gc_PurchaseEntries
        '
        Me.gc_PurchaseEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_PurchaseEntries.Location = New System.Drawing.Point(0, 0)
        Me.gc_PurchaseEntries.MainView = Me.gv_PurchaseEntries
        Me.gc_PurchaseEntries.MenuManager = Me.RibbonControl
        Me.gc_PurchaseEntries.Name = "gc_PurchaseEntries"
        Me.gc_PurchaseEntries.Size = New System.Drawing.Size(436, 247)
        Me.gc_PurchaseEntries.TabIndex = 3
        Me.gc_PurchaseEntries.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_PurchaseEntries})
        '
        'gv_PurchaseEntries
        '
        Me.gv_PurchaseEntries.GridControl = Me.gc_PurchaseEntries
        Me.gv_PurchaseEntries.Name = "gv_PurchaseEntries"
        '
        'tp_Parties
        '
        Me.tp_Parties.Controls.Add(Me.ProgressPanel_Parties)
        Me.tp_Parties.Controls.Add(Me.gc_Parties)
        Me.tp_Parties.Name = "tp_Parties"
        Me.tp_Parties.Size = New System.Drawing.Size(436, 247)
        Me.tp_Parties.Text = "Parties"
        '
        'ProgressPanel_Parties
        '
        Me.ProgressPanel_Parties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_Parties.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_Parties.BarAnimationElementThickness = 2
        Me.ProgressPanel_Parties.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel_Parties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel_Parties.Location = New System.Drawing.Point(0, 0)
        Me.ProgressPanel_Parties.Name = "ProgressPanel_Parties"
        Me.ProgressPanel_Parties.Size = New System.Drawing.Size(436, 247)
        Me.ProgressPanel_Parties.TabIndex = 3
        Me.ProgressPanel_Parties.Visible = False
        '
        'OpenFileDialog_Excel
        '
        Me.OpenFileDialog_Excel.DefaultExt = "xlsx"
        Me.OpenFileDialog_Excel.Filter = "All Supported Excel Files|*.xlsx;*.xls"
        Me.OpenFileDialog_Excel.Title = "Select Excel File to Import"
        '
        'SaveFileDialog_Excel
        '
        Me.SaveFileDialog_Excel.DefaultExt = "xlsx"
        Me.SaveFileDialog_Excel.FileName = "*.xlsx"
        Me.SaveFileDialog_Excel.Filter = "Excel 2007 Files|*.xlsx"
        '
        'SaveFileDialog_XML
        '
        Me.SaveFileDialog_XML.DefaultExt = "xml"
        Me.SaveFileDialog_XML.FileName = "Parties.xml"
        Me.SaveFileDialog_XML.Filter = " Extensible Markup Language (XML) Files|*.xml"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 449)
        Me.Controls.Add(Me.container_Tabs)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "RibbonForm1"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TallyVersion_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CompanyName_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.container_Tabs.ResumeLayout(False)
        Me.tp_PurchaseEntries.ResumeLayout(False)
        CType(Me.gc_PurchaseEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_PurchaseEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Parties.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rp_PurchaseEntries As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpg_Items_Parties As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents rp_Parties As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpg_Items_Purchase As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents gc_Parties As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Parties As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents container_Tabs As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_PurchaseEntries As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tp_Parties As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btn_LoadExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenFileDialog_Excel As OpenFileDialog
    Friend WithEvents ProgressPanel_Parties As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents PopupMenu_Excel As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btn_SaveFormat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveFileDialog_Excel As SaveFileDialog
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_XML_File_Parties As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveFileDialog_XML As SaveFileDialog
    Friend WithEvents txt_TallyVersion As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txt_TallyVersion_Edit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txt_CompanyName As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txt_CompanyName_Edit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents rp_Tally As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ProgressPanel_PurchaseEntries As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents gc_PurchaseEntries As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_PurchaseEntries As DevExpress.XtraGrid.Views.Grid.GridView
End Class
