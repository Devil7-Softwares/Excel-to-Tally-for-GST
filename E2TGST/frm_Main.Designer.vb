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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_LoadExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_XML_File = New DevExpress.XtraBars.BarButtonItem()
        Me.txt_TallyVersion = New DevExpress.XtraBars.BarEditItem()
        Me.txt_TallyVersion_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txt_CompanyName = New DevExpress.XtraBars.BarEditItem()
        Me.txt_CompanyName_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.chk_CalcValues = New DevExpress.XtraBars.BarEditItem()
        Me.chk_CalcValues_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btn_LedgerNames = New DevExpress.XtraBars.BarButtonItem()
        Me.txt_TallyHost = New DevExpress.XtraBars.BarEditItem()
        Me.txt_TallyHost_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txt_TallyPort = New DevExpress.XtraBars.BarEditItem()
        Me.txt_TallyPort_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btn_Sync = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Refresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_XML_Tally = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Template_Parties = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Template_PurchaseEntries = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Template_SalesEntries = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_About = New DevExpress.XtraBars.BarButtonItem()
        Me.rp_Tally = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Sync = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Templates = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_PurchaseEntries = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Purchase = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Export_Purchase = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_SalesEntries = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Sales = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Export_Sales = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_Parties = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Parties = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Export_Parties = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.gc_Parties = New DevExpress.XtraGrid.GridControl()
        Me.gv_Parties = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.container_Tabs = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_PurchaseEntries = New DevExpress.XtraTab.XtraTabPage()
        Me.ProgressPanel_PurchaseEntries = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.gc_PurchaseEntries = New DevExpress.XtraGrid.GridControl()
        Me.gv_PurchaseEntries = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_SalesEntries = New DevExpress.XtraTab.XtraTabPage()
        Me.ProgressPanel_SalesEntries = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.gc_SalesEntries = New DevExpress.XtraGrid.GridControl()
        Me.gv_SalesEntries = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tp_Parties = New DevExpress.XtraTab.XtraTabPage()
        Me.ProgressPanel_Parties = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.OpenFileDialog_Excel = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog_Excel = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog_XML = New System.Windows.Forms.SaveFileDialog()
        Me.ProgressPanel_Main = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.PictureBox_Logo = New System.Windows.Forms.PictureBox()
        Me.txt_StateCode = New DevExpress.XtraBars.BarEditItem()
        Me.txt_StateCode_Edit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TallyVersion_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CompanyName_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chk_CalcValues_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TallyHost_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TallyPort_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.container_Tabs.SuspendLayout()
        Me.tp_PurchaseEntries.SuspendLayout()
        CType(Me.gc_PurchaseEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_PurchaseEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_SalesEntries.SuspendLayout()
        CType(Me.gc_SalesEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_SalesEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Parties.SuspendLayout()
        CType(Me.PictureBox_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_StateCode_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_LoadExcel, Me.btn_XML_File, Me.txt_TallyVersion, Me.txt_CompanyName, Me.chk_CalcValues, Me.btn_LedgerNames, Me.txt_TallyHost, Me.txt_TallyPort, Me.btn_Sync, Me.btn_Refresh, Me.btn_XML_Tally, Me.btn_Template_Parties, Me.btn_Template_PurchaseEntries, Me.btn_Template_SalesEntries, Me.btn_About, Me.txt_StateCode})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 19
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_Tally, Me.rp_PurchaseEntries, Me.rp_SalesEntries, Me.rp_Parties})
        Me.RibbonControl.QuickToolbarItemLinks.Add(Me.btn_About, "ABOUT")
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txt_TallyVersion_Edit, Me.txt_CompanyName_Edit, Me.chk_CalcValues_Edit, Me.txt_TallyHost_Edit, Me.txt_TallyPort_Edit, Me.txt_StateCode_Edit})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowCategoryInCaption = False
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(810, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btn_LoadExcel
        '
        Me.btn_LoadExcel.Caption = "Import Excel"
        Me.btn_LoadExcel.Id = 1
        Me.btn_LoadExcel.ImageOptions.SvgImage = CType(resources.GetObject("btn_LoadExcel.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_LoadExcel.Name = "btn_LoadExcel"
        '
        'btn_XML_File
        '
        Me.btn_XML_File.Caption = "To File"
        Me.btn_XML_File.Id = 3
        Me.btn_XML_File.ImageOptions.SvgImage = CType(resources.GetObject("btn_XML_File.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_XML_File.Name = "btn_XML_File"
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
        'chk_CalcValues
        '
        Me.chk_CalcValues.Caption = "Calculate Values"
        Me.chk_CalcValues.Edit = Me.chk_CalcValues_Edit
        Me.chk_CalcValues.Id = 7
        Me.chk_CalcValues.Name = "chk_CalcValues"
        '
        'chk_CalcValues_Edit
        '
        Me.chk_CalcValues_Edit.AutoHeight = False
        Me.chk_CalcValues_Edit.Name = "chk_CalcValues_Edit"
        '
        'btn_LedgerNames
        '
        Me.btn_LedgerNames.Caption = "Edit Ledger Names"
        Me.btn_LedgerNames.Id = 8
        Me.btn_LedgerNames.ImageOptions.SvgImage = CType(resources.GetObject("btn_LedgerNames.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_LedgerNames.Name = "btn_LedgerNames"
        Me.btn_LedgerNames.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'txt_TallyHost
        '
        Me.txt_TallyHost.Caption = "Tally Host Name"
        Me.txt_TallyHost.Edit = Me.txt_TallyHost_Edit
        Me.txt_TallyHost.EditWidth = 100
        Me.txt_TallyHost.Id = 9
        Me.txt_TallyHost.Name = "txt_TallyHost"
        '
        'txt_TallyHost_Edit
        '
        Me.txt_TallyHost_Edit.AutoHeight = False
        Me.txt_TallyHost_Edit.Name = "txt_TallyHost_Edit"
        '
        'txt_TallyPort
        '
        Me.txt_TallyPort.Caption = "                   Port"
        Me.txt_TallyPort.Edit = Me.txt_TallyPort_Edit
        Me.txt_TallyPort.EditWidth = 100
        Me.txt_TallyPort.Id = 10
        Me.txt_TallyPort.Name = "txt_TallyPort"
        '
        'txt_TallyPort_Edit
        '
        Me.txt_TallyPort_Edit.AutoHeight = False
        Me.txt_TallyPort_Edit.Name = "txt_TallyPort_Edit"
        '
        'btn_Sync
        '
        Me.btn_Sync.Caption = "Sync"
        Me.btn_Sync.Id = 11
        Me.btn_Sync.ImageOptions.SvgImage = CType(resources.GetObject("btn_Sync.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Sync.Name = "btn_Sync"
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Caption = "Refresh"
        Me.btn_Refresh.Id = 12
        Me.btn_Refresh.ImageOptions.SvgImage = CType(resources.GetObject("btn_Refresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Refresh.Name = "btn_Refresh"
        '
        'btn_XML_Tally
        '
        Me.btn_XML_Tally.Caption = "To Tally"
        Me.btn_XML_Tally.Id = 13
        Me.btn_XML_Tally.ImageOptions.SvgImage = CType(resources.GetObject("btn_XML_Tally.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_XML_Tally.Name = "btn_XML_Tally"
        '
        'btn_Template_Parties
        '
        Me.btn_Template_Parties.Caption = "Parties"
        Me.btn_Template_Parties.Id = 14
        Me.btn_Template_Parties.ImageOptions.SvgImage = CType(resources.GetObject("btn_Template_Parties.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_Template_Parties.Name = "btn_Template_Parties"
        '
        'btn_Template_PurchaseEntries
        '
        Me.btn_Template_PurchaseEntries.Caption = "Purchase Entries"
        Me.btn_Template_PurchaseEntries.Id = 15
        Me.btn_Template_PurchaseEntries.ImageOptions.LargeImage = CType(resources.GetObject("btn_Template_PurchaseEntries.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btn_Template_PurchaseEntries.Name = "btn_Template_PurchaseEntries"
        '
        'btn_Template_SalesEntries
        '
        Me.btn_Template_SalesEntries.Caption = "Sales Entries"
        Me.btn_Template_SalesEntries.Id = 16
        Me.btn_Template_SalesEntries.ImageOptions.LargeImage = CType(resources.GetObject("btn_Template_SalesEntries.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btn_Template_SalesEntries.Name = "btn_Template_SalesEntries"
        '
        'btn_About
        '
        Me.btn_About.Caption = "About"
        Me.btn_About.Id = 17
        Me.btn_About.ImageOptions.SvgImage = CType(resources.GetObject("btn_About.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_About.Name = "btn_About"
        '
        'rp_Tally
        '
        Me.rp_Tally.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.rpg_Sync, Me.rpg_Templates})
        Me.rp_Tally.Name = "rp_Tally"
        Me.rp_Tally.Text = "Tally"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.txt_TallyVersion)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.txt_CompanyName)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.txt_StateCode)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.chk_CalcValues, True)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_LedgerNames)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Variables"
        '
        'rpg_Sync
        '
        Me.rpg_Sync.ItemLinks.Add(Me.txt_TallyHost)
        Me.rpg_Sync.ItemLinks.Add(Me.txt_TallyPort)
        Me.rpg_Sync.ItemLinks.Add(Me.btn_Sync, True)
        Me.rpg_Sync.Name = "rpg_Sync"
        Me.rpg_Sync.ShowCaptionButton = False
        Me.rpg_Sync.Text = "Sync"
        '
        'rpg_Templates
        '
        Me.rpg_Templates.ItemLinks.Add(Me.btn_Template_Parties)
        Me.rpg_Templates.ItemLinks.Add(Me.btn_Template_PurchaseEntries)
        Me.rpg_Templates.ItemLinks.Add(Me.btn_Template_SalesEntries)
        Me.rpg_Templates.Name = "rpg_Templates"
        Me.rpg_Templates.ShowCaptionButton = False
        Me.rpg_Templates.Text = "Templates"
        '
        'rp_PurchaseEntries
        '
        Me.rp_PurchaseEntries.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Purchase, Me.rpg_Export_Purchase})
        Me.rp_PurchaseEntries.Name = "rp_PurchaseEntries"
        Me.rp_PurchaseEntries.Text = "Purchase Entries"
        Me.rp_PurchaseEntries.Visible = False
        '
        'rpg_Items_Purchase
        '
        Me.rpg_Items_Purchase.ItemLinks.Add(Me.btn_LoadExcel)
        Me.rpg_Items_Purchase.ItemLinks.Add(Me.btn_Refresh, True)
        Me.rpg_Items_Purchase.Name = "rpg_Items_Purchase"
        Me.rpg_Items_Purchase.ShowCaptionButton = False
        Me.rpg_Items_Purchase.Text = "Items"
        '
        'rpg_Export_Purchase
        '
        Me.rpg_Export_Purchase.ItemLinks.Add(Me.btn_XML_File)
        Me.rpg_Export_Purchase.ItemLinks.Add(Me.btn_XML_Tally)
        Me.rpg_Export_Purchase.Name = "rpg_Export_Purchase"
        Me.rpg_Export_Purchase.ShowCaptionButton = False
        Me.rpg_Export_Purchase.Text = "Export"
        '
        'rp_SalesEntries
        '
        Me.rp_SalesEntries.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Sales, Me.rpg_Export_Sales})
        Me.rp_SalesEntries.Name = "rp_SalesEntries"
        Me.rp_SalesEntries.Text = "Sales Entries"
        Me.rp_SalesEntries.Visible = False
        '
        'rpg_Items_Sales
        '
        Me.rpg_Items_Sales.ItemLinks.Add(Me.btn_LoadExcel)
        Me.rpg_Items_Sales.ItemLinks.Add(Me.btn_Refresh, True)
        Me.rpg_Items_Sales.Name = "rpg_Items_Sales"
        Me.rpg_Items_Sales.ShowCaptionButton = False
        Me.rpg_Items_Sales.Text = "Items"
        '
        'rpg_Export_Sales
        '
        Me.rpg_Export_Sales.ItemLinks.Add(Me.btn_XML_File)
        Me.rpg_Export_Sales.ItemLinks.Add(Me.btn_XML_Tally)
        Me.rpg_Export_Sales.Name = "rpg_Export_Sales"
        Me.rpg_Export_Sales.ShowCaptionButton = False
        Me.rpg_Export_Sales.Text = "Export"
        '
        'rp_Parties
        '
        Me.rp_Parties.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Parties, Me.rpg_Export_Parties})
        Me.rp_Parties.Name = "rp_Parties"
        Me.rp_Parties.Text = "Parties"
        Me.rp_Parties.Visible = False
        '
        'rpg_Items_Parties
        '
        Me.rpg_Items_Parties.ItemLinks.Add(Me.btn_LoadExcel)
        Me.rpg_Items_Parties.ItemLinks.Add(Me.btn_Refresh, True)
        Me.rpg_Items_Parties.Name = "rpg_Items_Parties"
        Me.rpg_Items_Parties.ShowCaptionButton = False
        Me.rpg_Items_Parties.Text = "Items"
        '
        'rpg_Export_Parties
        '
        Me.rpg_Export_Parties.ItemLinks.Add(Me.btn_XML_File)
        Me.rpg_Export_Parties.ItemLinks.Add(Me.btn_XML_Tally)
        Me.rpg_Export_Parties.Name = "rpg_Export_Parties"
        Me.rpg_Export_Parties.ShowCaptionButton = False
        Me.rpg_Export_Parties.Text = "Export"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(810, 31)
        '
        'gc_Parties
        '
        Me.gc_Parties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Parties.Location = New System.Drawing.Point(0, 0)
        Me.gc_Parties.MainView = Me.gv_Parties
        Me.gc_Parties.MenuManager = Me.RibbonControl
        Me.gc_Parties.Name = "gc_Parties"
        Me.gc_Parties.Size = New System.Drawing.Size(804, 278)
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
        Me.container_Tabs.Size = New System.Drawing.Size(810, 306)
        Me.container_Tabs.TabIndex = 3
        Me.container_Tabs.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_PurchaseEntries, Me.tp_SalesEntries, Me.tp_Parties})
        '
        'tp_PurchaseEntries
        '
        Me.tp_PurchaseEntries.Controls.Add(Me.ProgressPanel_PurchaseEntries)
        Me.tp_PurchaseEntries.Controls.Add(Me.gc_PurchaseEntries)
        Me.tp_PurchaseEntries.Name = "tp_PurchaseEntries"
        Me.tp_PurchaseEntries.Size = New System.Drawing.Size(804, 278)
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
        Me.ProgressPanel_PurchaseEntries.Size = New System.Drawing.Size(804, 278)
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
        Me.gc_PurchaseEntries.Size = New System.Drawing.Size(804, 278)
        Me.gc_PurchaseEntries.TabIndex = 3
        Me.gc_PurchaseEntries.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_PurchaseEntries})
        '
        'gv_PurchaseEntries
        '
        Me.gv_PurchaseEntries.GridControl = Me.gc_PurchaseEntries
        Me.gv_PurchaseEntries.Name = "gv_PurchaseEntries"
        '
        'tp_SalesEntries
        '
        Me.tp_SalesEntries.Controls.Add(Me.ProgressPanel_SalesEntries)
        Me.tp_SalesEntries.Controls.Add(Me.gc_SalesEntries)
        Me.tp_SalesEntries.Name = "tp_SalesEntries"
        Me.tp_SalesEntries.Size = New System.Drawing.Size(804, 278)
        Me.tp_SalesEntries.Text = "Sales Entries"
        '
        'ProgressPanel_SalesEntries
        '
        Me.ProgressPanel_SalesEntries.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_SalesEntries.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_SalesEntries.BarAnimationElementThickness = 2
        Me.ProgressPanel_SalesEntries.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel_SalesEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel_SalesEntries.Location = New System.Drawing.Point(0, 0)
        Me.ProgressPanel_SalesEntries.Name = "ProgressPanel_SalesEntries"
        Me.ProgressPanel_SalesEntries.Size = New System.Drawing.Size(804, 278)
        Me.ProgressPanel_SalesEntries.TabIndex = 5
        Me.ProgressPanel_SalesEntries.Visible = False
        '
        'gc_SalesEntries
        '
        Me.gc_SalesEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_SalesEntries.Location = New System.Drawing.Point(0, 0)
        Me.gc_SalesEntries.MainView = Me.gv_SalesEntries
        Me.gc_SalesEntries.MenuManager = Me.RibbonControl
        Me.gc_SalesEntries.Name = "gc_SalesEntries"
        Me.gc_SalesEntries.Size = New System.Drawing.Size(804, 278)
        Me.gc_SalesEntries.TabIndex = 4
        Me.gc_SalesEntries.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_SalesEntries})
        '
        'gv_SalesEntries
        '
        Me.gv_SalesEntries.GridControl = Me.gc_SalesEntries
        Me.gv_SalesEntries.Name = "gv_SalesEntries"
        '
        'tp_Parties
        '
        Me.tp_Parties.Controls.Add(Me.ProgressPanel_Parties)
        Me.tp_Parties.Controls.Add(Me.gc_Parties)
        Me.tp_Parties.Name = "tp_Parties"
        Me.tp_Parties.Size = New System.Drawing.Size(804, 278)
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
        Me.ProgressPanel_Parties.Size = New System.Drawing.Size(804, 278)
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
        Me.SaveFileDialog_XML.FileName = "*.xml"
        Me.SaveFileDialog_XML.Filter = " Extensible Markup Language (XML) Files|*.xml"
        '
        'ProgressPanel_Main
        '
        Me.ProgressPanel_Main.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_Main.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_Main.BarAnimationElementThickness = 2
        Me.ProgressPanel_Main.Caption = "Syncronizing with Tally..."
        Me.ProgressPanel_Main.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel_Main.Description = "This may take some minutes. Please Wait..."
        Me.ProgressPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel_Main.Location = New System.Drawing.Point(0, 143)
        Me.ProgressPanel_Main.Name = "ProgressPanel_Main"
        Me.ProgressPanel_Main.Size = New System.Drawing.Size(810, 306)
        Me.ProgressPanel_Main.TabIndex = 6
        Me.ProgressPanel_Main.Visible = False
        '
        'PictureBox_Logo
        '
        Me.PictureBox_Logo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_Logo.Image = Global.D7.Automation.E2TGST.My.Resources.Resources.devil7_logo
        Me.PictureBox_Logo.Location = New System.Drawing.Point(0, 143)
        Me.PictureBox_Logo.Name = "PictureBox_Logo"
        Me.PictureBox_Logo.Size = New System.Drawing.Size(810, 306)
        Me.PictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_Logo.TabIndex = 5
        Me.PictureBox_Logo.TabStop = False
        '
        'txt_StateCode
        '
        Me.txt_StateCode.Caption = "State Code       "
        Me.txt_StateCode.Edit = Me.txt_StateCode_Edit
        Me.txt_StateCode.EditWidth = 150
        Me.txt_StateCode.Id = 18
        Me.txt_StateCode.Name = "txt_StateCode"
        '
        'txt_StateCode_Edit
        '
        Me.txt_StateCode_Edit.AutoHeight = False
        Me.txt_StateCode_Edit.Name = "txt_StateCode_Edit"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 449)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.ProgressPanel_Main)
        Me.Controls.Add(Me.PictureBox_Logo)
        Me.Controls.Add(Me.container_Tabs)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(820, 450)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Excel to Tally for GST Entries"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TallyVersion_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CompanyName_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chk_CalcValues_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TallyHost_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TallyPort_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.container_Tabs.ResumeLayout(False)
        Me.tp_PurchaseEntries.ResumeLayout(False)
        CType(Me.gc_PurchaseEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_PurchaseEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_SalesEntries.ResumeLayout(False)
        CType(Me.gc_SalesEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_SalesEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Parties.ResumeLayout(False)
        CType(Me.PictureBox_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_StateCode_Edit, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SaveFileDialog_Excel As SaveFileDialog
    Friend WithEvents rpg_Export_Parties As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_XML_File As DevExpress.XtraBars.BarButtonItem
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
    Friend WithEvents rpg_Export_Purchase As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents chk_CalcValues As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chk_CalcValues_Edit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btn_LedgerNames As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpg_Sync As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txt_TallyHost As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txt_TallyHost_Edit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txt_TallyPort As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txt_TallyPort_Edit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btn_Sync As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ProgressPanel_Main As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents tp_SalesEntries As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ProgressPanel_SalesEntries As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents gc_SalesEntries As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_SalesEntries As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rp_SalesEntries As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpg_Items_Sales As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpg_Export_Sales As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Refresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_XML_Tally As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PictureBox_Logo As PictureBox
    Friend WithEvents rpg_Templates As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Template_Parties As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Template_PurchaseEntries As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Template_SalesEntries As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_About As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txt_StateCode As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txt_StateCode_Edit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
