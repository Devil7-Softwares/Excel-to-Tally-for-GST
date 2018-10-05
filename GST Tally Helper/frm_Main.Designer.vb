<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.rp_PurchaseEntries = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Parties = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rp_Parties = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_Items_Purchase = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.gc_Parties = New DevExpress.XtraGrid.GridControl()
        Me.gv_Parties = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.container_Tabs = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_PurchaseEntries = New DevExpress.XtraTab.XtraTabPage()
        Me.tp_Parties = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.container_Tabs.SuspendLayout()
        Me.tp_Parties.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 1
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_PurchaseEntries, Me.rp_Parties})
        Me.RibbonControl.Size = New System.Drawing.Size(442, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'rp_PurchaseEntries
        '
        Me.rp_PurchaseEntries.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Purchase})
        Me.rp_PurchaseEntries.Name = "rp_PurchaseEntries"
        Me.rp_PurchaseEntries.Text = "Purchase Entries"
        '
        'rpg_Items_Parties
        '
        Me.rpg_Items_Parties.Name = "rpg_Items_Parties"
        Me.rpg_Items_Parties.ShowCaptionButton = False
        Me.rpg_Items_Parties.Text = "Items"
        '
        'rp_Parties
        '
        Me.rp_Parties.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_Items_Parties})
        Me.rp_Parties.Name = "rp_Parties"
        Me.rp_Parties.Text = "Parties"
        '
        'rpg_Items_Purchase
        '
        Me.rpg_Items_Purchase.Name = "rpg_Items_Purchase"
        Me.rpg_Items_Purchase.ShowCaptionButton = False
        Me.rpg_Items_Purchase.Text = "Items"
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
        Me.tp_PurchaseEntries.Name = "tp_PurchaseEntries"
        Me.tp_PurchaseEntries.Size = New System.Drawing.Size(436, 247)
        Me.tp_PurchaseEntries.Text = "Purchase Entries"
        '
        'tp_Parties
        '
        Me.tp_Parties.Controls.Add(Me.gc_Parties)
        Me.tp_Parties.Name = "tp_Parties"
        Me.tp_Parties.Size = New System.Drawing.Size(436, 247)
        Me.tp_Parties.Text = "Parties"
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
        CType(Me.gc_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Parties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.container_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.container_Tabs.ResumeLayout(False)
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
End Class
