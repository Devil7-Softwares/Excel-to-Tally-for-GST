<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LedgersFormat
    Inherits Utils.XtraFormTemp

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LedgersFormat))
        Me.lbl_TaxLedgers = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Preview_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Preview_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Note_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_RoundOffLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_CessLedger = New DevExpress.XtraEditors.LabelControl()
        Me.btn_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_Preview_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Preview_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Note_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_TaxLedgers = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txt_RoundOffLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txt_CESSLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txt_SalesLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_DiscoundLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_DiscountLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btn_ResetDefaults = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_CardSalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_CardSalesLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_BankChargesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_BankChargesLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tc_Main = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_CustomLedgerNames = New DevExpress.XtraTab.XtraTabPage()
        Me.tp_LedgerNameFormats = New DevExpress.XtraTab.XtraTabPage()
        Me.lbl_BankLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_BankLedger = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_Narration = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Narration = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tp_TaxRates = New DevExpress.XtraTab.XtraTabPage()
        Me.lbl_TaxRate_0 = New DevExpress.XtraEditors.LabelControl()
        Me.txt_TaxRate_0 = New DevExpress.XtraEditors.SpinEdit()
        Me.txt_TaxRate_5 = New DevExpress.XtraEditors.SpinEdit()
        Me.txt_TaxRate_12 = New DevExpress.XtraEditors.SpinEdit()
        Me.txt_TaxRate_18 = New DevExpress.XtraEditors.SpinEdit()
        Me.txt_TaxRate_28 = New DevExpress.XtraEditors.SpinEdit()
        Me.lbl_TaxRate_5 = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_TaxRate_12 = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_TaxRate_18 = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_TaxRate_28 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txt_TaxLedgers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RoundOffLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CESSLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SalesLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_DiscountLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CardSalesLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BankChargesLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Main.SuspendLayout()
        Me.tp_CustomLedgerNames.SuspendLayout()
        Me.tp_LedgerNameFormats.SuspendLayout()
        CType(Me.txt_BankLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Narration.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_TaxRates.SuspendLayout()
        CType(Me.txt_TaxRate_0.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TaxRate_5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TaxRate_12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TaxRate_18.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TaxRate_28.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_TaxLedgers
        '
        Me.lbl_TaxLedgers.Location = New System.Drawing.Point(11, 90)
        Me.lbl_TaxLedgers.Name = "lbl_TaxLedgers"
        Me.lbl_TaxLedgers.Size = New System.Drawing.Size(133, 13)
        Me.lbl_TaxLedgers.TabIndex = 0
        Me.lbl_TaxLedgers.Text = "Tax Ledgers Name Format :"
        '
        'lbl_Preview_TaxLedger
        '
        Me.lbl_Preview_TaxLedger.Location = New System.Drawing.Point(150, 113)
        Me.lbl_Preview_TaxLedger.Name = "lbl_Preview_TaxLedger"
        Me.lbl_Preview_TaxLedger.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Preview_TaxLedger.TabIndex = 2
        Me.lbl_Preview_TaxLedger.Text = "Preview :-"
        '
        'txt_Preview_TaxLedger
        '
        Me.txt_Preview_TaxLedger.Location = New System.Drawing.Point(205, 113)
        Me.txt_Preview_TaxLedger.Name = "txt_Preview_TaxLedger"
        Me.txt_Preview_TaxLedger.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview_TaxLedger.TabIndex = 3
        Me.txt_Preview_TaxLedger.Text = "-"
        '
        'lbl_Note_TaxLedger
        '
        Me.lbl_Note_TaxLedger.Location = New System.Drawing.Point(165, 132)
        Me.lbl_Note_TaxLedger.Name = "lbl_Note_TaxLedger"
        Me.lbl_Note_TaxLedger.Size = New System.Drawing.Size(187, 52)
        Me.lbl_Note_TaxLedger.TabIndex = 4
        Me.lbl_Note_TaxLedger.Text = "Note :-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {0} - Tax Type (Input/Output)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {1} - Tax Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {2} - T" &
    "ax Percentage (Without '%')"
        '
        'lbl_RoundOffLedger
        '
        Me.lbl_RoundOffLedger.Location = New System.Drawing.Point(16, 14)
        Me.lbl_RoundOffLedger.Name = "lbl_RoundOffLedger"
        Me.lbl_RoundOffLedger.Size = New System.Drawing.Size(107, 13)
        Me.lbl_RoundOffLedger.TabIndex = 5
        Me.lbl_RoundOffLedger.Text = "Rounding Off Ledger :"
        '
        'lbl_CessLedger
        '
        Me.lbl_CessLedger.Location = New System.Drawing.Point(55, 40)
        Me.lbl_CessLedger.Name = "lbl_CessLedger"
        Me.lbl_CessLedger.Size = New System.Drawing.Size(68, 13)
        Me.lbl_CessLedger.TabIndex = 5
        Me.lbl_CessLedger.Text = "CESS Ledger :"
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.Location = New System.Drawing.Point(351, 244)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 7
        Me.btn_Save.Text = "Save"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.Location = New System.Drawing.Point(12, 244)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 8
        Me.btn_Cancel.Text = "Cancel"
        '
        'txt_Preview_SalesLedger
        '
        Me.txt_Preview_SalesLedger.Location = New System.Drawing.Point(205, 36)
        Me.txt_Preview_SalesLedger.Name = "txt_Preview_SalesLedger"
        Me.txt_Preview_SalesLedger.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview_SalesLedger.TabIndex = 12
        Me.txt_Preview_SalesLedger.Text = "-"
        '
        'lbl_Preview_SalesLedger
        '
        Me.lbl_Preview_SalesLedger.Location = New System.Drawing.Point(150, 36)
        Me.lbl_Preview_SalesLedger.Name = "lbl_Preview_SalesLedger"
        Me.lbl_Preview_SalesLedger.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Preview_SalesLedger.TabIndex = 11
        Me.lbl_Preview_SalesLedger.Text = "Preview :-"
        '
        'lbl_SalesLedger
        '
        Me.lbl_SalesLedger.Location = New System.Drawing.Point(9, 13)
        Me.lbl_SalesLedger.Name = "lbl_SalesLedger"
        Me.lbl_SalesLedger.Size = New System.Drawing.Size(135, 13)
        Me.lbl_SalesLedger.TabIndex = 9
        Me.lbl_SalesLedger.Text = "Sales Ledger Name Format :"
        '
        'lbl_Note_SalesLedger
        '
        Me.lbl_Note_SalesLedger.Location = New System.Drawing.Point(165, 55)
        Me.lbl_Note_SalesLedger.Name = "lbl_Note_SalesLedger"
        Me.lbl_Note_SalesLedger.Size = New System.Drawing.Size(187, 26)
        Me.lbl_Note_SalesLedger.TabIndex = 13
        Me.lbl_Note_SalesLedger.Text = "Note :-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {0} - Tax Percentage (Without '%')"
        '
        'txt_TaxLedgers
        '
        Me.txt_TaxLedgers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_TaxLedgers.Location = New System.Drawing.Point(150, 87)
        Me.txt_TaxLedgers.Name = "txt_TaxLedgers"
        Me.txt_TaxLedgers.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxLedgers.Size = New System.Drawing.Size(250, 20)
        Me.txt_TaxLedgers.TabIndex = 14
        '
        'txt_RoundOffLedger
        '
        Me.txt_RoundOffLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_RoundOffLedger.Location = New System.Drawing.Point(129, 11)
        Me.txt_RoundOffLedger.Name = "txt_RoundOffLedger"
        Me.txt_RoundOffLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_RoundOffLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_RoundOffLedger.TabIndex = 15
        '
        'txt_CESSLedger
        '
        Me.txt_CESSLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_CESSLedger.Location = New System.Drawing.Point(129, 37)
        Me.txt_CESSLedger.Name = "txt_CESSLedger"
        Me.txt_CESSLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_CESSLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_CESSLedger.TabIndex = 16
        '
        'txt_SalesLedger
        '
        Me.txt_SalesLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_SalesLedger.Location = New System.Drawing.Point(150, 10)
        Me.txt_SalesLedger.Name = "txt_SalesLedger"
        Me.txt_SalesLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_SalesLedger.Size = New System.Drawing.Size(250, 20)
        Me.txt_SalesLedger.TabIndex = 17
        '
        'lbl_DiscoundLedger
        '
        Me.lbl_DiscoundLedger.Location = New System.Drawing.Point(39, 66)
        Me.lbl_DiscoundLedger.Name = "lbl_DiscoundLedger"
        Me.lbl_DiscoundLedger.Size = New System.Drawing.Size(84, 13)
        Me.lbl_DiscoundLedger.TabIndex = 5
        Me.lbl_DiscoundLedger.Text = "Discount Ledger :"
        '
        'txt_DiscountLedger
        '
        Me.txt_DiscountLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_DiscountLedger.Location = New System.Drawing.Point(129, 63)
        Me.txt_DiscountLedger.Name = "txt_DiscountLedger"
        Me.txt_DiscountLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_DiscountLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_DiscountLedger.TabIndex = 16
        '
        'btn_ResetDefaults
        '
        Me.btn_ResetDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ResetDefaults.Location = New System.Drawing.Point(93, 244)
        Me.btn_ResetDefaults.Name = "btn_ResetDefaults"
        Me.btn_ResetDefaults.Size = New System.Drawing.Size(107, 23)
        Me.btn_ResetDefaults.TabIndex = 8
        Me.btn_ResetDefaults.Text = "Reset to Defaults"
        '
        'lbl_CardSalesLedger
        '
        Me.lbl_CardSalesLedger.Location = New System.Drawing.Point(29, 92)
        Me.lbl_CardSalesLedger.Name = "lbl_CardSalesLedger"
        Me.lbl_CardSalesLedger.Size = New System.Drawing.Size(94, 13)
        Me.lbl_CardSalesLedger.TabIndex = 5
        Me.lbl_CardSalesLedger.Text = "Card Sales Ledger :"
        '
        'txt_CardSalesLedger
        '
        Me.txt_CardSalesLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_CardSalesLedger.Location = New System.Drawing.Point(129, 89)
        Me.txt_CardSalesLedger.Name = "txt_CardSalesLedger"
        Me.txt_CardSalesLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_CardSalesLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_CardSalesLedger.TabIndex = 16
        '
        'lbl_BankChargesLedger
        '
        Me.lbl_BankChargesLedger.Location = New System.Drawing.Point(14, 118)
        Me.lbl_BankChargesLedger.Name = "lbl_BankChargesLedger"
        Me.lbl_BankChargesLedger.Size = New System.Drawing.Size(109, 13)
        Me.lbl_BankChargesLedger.TabIndex = 5
        Me.lbl_BankChargesLedger.Text = "Bank Charges Ledger :"
        '
        'txt_BankChargesLedger
        '
        Me.txt_BankChargesLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_BankChargesLedger.Location = New System.Drawing.Point(129, 115)
        Me.txt_BankChargesLedger.Name = "txt_BankChargesLedger"
        Me.txt_BankChargesLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_BankChargesLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_BankChargesLedger.TabIndex = 16
        '
        'tc_Main
        '
        Me.tc_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tc_Main.Location = New System.Drawing.Point(12, 12)
        Me.tc_Main.Name = "tc_Main"
        Me.tc_Main.SelectedTabPage = Me.tp_CustomLedgerNames
        Me.tc_Main.Size = New System.Drawing.Size(414, 226)
        Me.tc_Main.TabIndex = 18
        Me.tc_Main.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_CustomLedgerNames, Me.tp_LedgerNameFormats, Me.tp_TaxRates})
        '
        'tp_CustomLedgerNames
        '
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_Narration)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_Narration)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_BankLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_BankLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_RoundOffLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_CessLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_BankChargesLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_DiscoundLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_CardSalesLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_CardSalesLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_DiscountLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.lbl_BankChargesLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_CESSLedger)
        Me.tp_CustomLedgerNames.Controls.Add(Me.txt_RoundOffLedger)
        Me.tp_CustomLedgerNames.Name = "tp_CustomLedgerNames"
        Me.tp_CustomLedgerNames.Size = New System.Drawing.Size(408, 198)
        Me.tp_CustomLedgerNames.Text = "Ledger Names"
        '
        'tp_LedgerNameFormats
        '
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_SalesLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.txt_SalesLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_TaxLedgers)
        Me.tp_LedgerNameFormats.Controls.Add(Me.txt_TaxLedgers)
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_Preview_TaxLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_Note_SalesLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.txt_Preview_TaxLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.txt_Preview_SalesLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_Note_TaxLedger)
        Me.tp_LedgerNameFormats.Controls.Add(Me.lbl_Preview_SalesLedger)
        Me.tp_LedgerNameFormats.Name = "tp_LedgerNameFormats"
        Me.tp_LedgerNameFormats.Size = New System.Drawing.Size(408, 198)
        Me.tp_LedgerNameFormats.Text = "Ledger Name Formats"
        '
        'lbl_BankLedger
        '
        Me.lbl_BankLedger.Location = New System.Drawing.Point(63, 144)
        Me.lbl_BankLedger.Name = "lbl_BankLedger"
        Me.lbl_BankLedger.Size = New System.Drawing.Size(60, 13)
        Me.lbl_BankLedger.TabIndex = 17
        Me.lbl_BankLedger.Text = "Bank Leger :"
        '
        'txt_BankLedger
        '
        Me.txt_BankLedger.Location = New System.Drawing.Point(129, 141)
        Me.txt_BankLedger.Name = "txt_BankLedger"
        Me.txt_BankLedger.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_BankLedger.Size = New System.Drawing.Size(267, 20)
        Me.txt_BankLedger.TabIndex = 18
        '
        'lbl_Narration
        '
        Me.lbl_Narration.Location = New System.Drawing.Point(71, 170)
        Me.lbl_Narration.Name = "lbl_Narration"
        Me.lbl_Narration.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Narration.TabIndex = 19
        Me.lbl_Narration.Text = "Narration :"
        '
        'txt_Narration
        '
        Me.txt_Narration.Location = New System.Drawing.Point(129, 167)
        Me.txt_Narration.Name = "txt_Narration"
        Me.txt_Narration.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_Narration.Size = New System.Drawing.Size(267, 20)
        Me.txt_Narration.TabIndex = 18
        '
        'tp_TaxRates
        '
        Me.tp_TaxRates.Controls.Add(Me.lbl_TaxRate_28)
        Me.tp_TaxRates.Controls.Add(Me.lbl_TaxRate_18)
        Me.tp_TaxRates.Controls.Add(Me.lbl_TaxRate_12)
        Me.tp_TaxRates.Controls.Add(Me.lbl_TaxRate_5)
        Me.tp_TaxRates.Controls.Add(Me.txt_TaxRate_28)
        Me.tp_TaxRates.Controls.Add(Me.txt_TaxRate_18)
        Me.tp_TaxRates.Controls.Add(Me.txt_TaxRate_12)
        Me.tp_TaxRates.Controls.Add(Me.txt_TaxRate_5)
        Me.tp_TaxRates.Controls.Add(Me.txt_TaxRate_0)
        Me.tp_TaxRates.Controls.Add(Me.lbl_TaxRate_0)
        Me.tp_TaxRates.Name = "tp_TaxRates"
        Me.tp_TaxRates.Size = New System.Drawing.Size(408, 198)
        Me.tp_TaxRates.Text = "Tax Rates"
        '
        'lbl_TaxRate_0
        '
        Me.lbl_TaxRate_0.Location = New System.Drawing.Point(13, 14)
        Me.lbl_TaxRate_0.Name = "lbl_TaxRate_0"
        Me.lbl_TaxRate_0.Size = New System.Drawing.Size(43, 13)
        Me.lbl_TaxRate_0.TabIndex = 0
        Me.lbl_TaxRate_0.Text = "Exempt :"
        '
        'txt_TaxRate_0
        '
        Me.txt_TaxRate_0.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_TaxRate_0.Location = New System.Drawing.Point(62, 11)
        Me.txt_TaxRate_0.Name = "txt_TaxRate_0"
        Me.txt_TaxRate_0.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxRate_0.Properties.DisplayFormat.FormatString = "0.00"
        Me.txt_TaxRate_0.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_0.Properties.EditFormat.FormatString = "0.00"
        Me.txt_TaxRate_0.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_0.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txt_TaxRate_0.Size = New System.Drawing.Size(335, 20)
        Me.txt_TaxRate_0.TabIndex = 1
        '
        'txt_TaxRate_5
        '
        Me.txt_TaxRate_5.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_TaxRate_5.Location = New System.Drawing.Point(62, 37)
        Me.txt_TaxRate_5.Name = "txt_TaxRate_5"
        Me.txt_TaxRate_5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxRate_5.Properties.DisplayFormat.FormatString = "0.00"
        Me.txt_TaxRate_5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_5.Properties.EditFormat.FormatString = "0.00"
        Me.txt_TaxRate_5.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_5.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txt_TaxRate_5.Size = New System.Drawing.Size(335, 20)
        Me.txt_TaxRate_5.TabIndex = 1
        '
        'txt_TaxRate_12
        '
        Me.txt_TaxRate_12.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_TaxRate_12.Location = New System.Drawing.Point(62, 63)
        Me.txt_TaxRate_12.Name = "txt_TaxRate_12"
        Me.txt_TaxRate_12.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxRate_12.Properties.DisplayFormat.FormatString = "0.00"
        Me.txt_TaxRate_12.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_12.Properties.EditFormat.FormatString = "0.00"
        Me.txt_TaxRate_12.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_12.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txt_TaxRate_12.Size = New System.Drawing.Size(335, 20)
        Me.txt_TaxRate_12.TabIndex = 1
        '
        'txt_TaxRate_18
        '
        Me.txt_TaxRate_18.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_TaxRate_18.Location = New System.Drawing.Point(62, 89)
        Me.txt_TaxRate_18.Name = "txt_TaxRate_18"
        Me.txt_TaxRate_18.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxRate_18.Properties.DisplayFormat.FormatString = "0.00"
        Me.txt_TaxRate_18.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_18.Properties.EditFormat.FormatString = "0.00"
        Me.txt_TaxRate_18.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_18.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txt_TaxRate_18.Size = New System.Drawing.Size(335, 20)
        Me.txt_TaxRate_18.TabIndex = 1
        '
        'txt_TaxRate_28
        '
        Me.txt_TaxRate_28.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_TaxRate_28.Location = New System.Drawing.Point(62, 115)
        Me.txt_TaxRate_28.Name = "txt_TaxRate_28"
        Me.txt_TaxRate_28.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_TaxRate_28.Properties.DisplayFormat.FormatString = "0.00"
        Me.txt_TaxRate_28.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_28.Properties.EditFormat.FormatString = "0.00"
        Me.txt_TaxRate_28.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txt_TaxRate_28.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txt_TaxRate_28.Size = New System.Drawing.Size(335, 20)
        Me.txt_TaxRate_28.TabIndex = 1
        '
        'lbl_TaxRate_5
        '
        Me.lbl_TaxRate_5.Location = New System.Drawing.Point(32, 40)
        Me.lbl_TaxRate_5.Name = "lbl_TaxRate_5"
        Me.lbl_TaxRate_5.Size = New System.Drawing.Size(24, 13)
        Me.lbl_TaxRate_5.TabIndex = 2
        Me.lbl_TaxRate_5.Text = "5% :"
        '
        'lbl_TaxRate_12
        '
        Me.lbl_TaxRate_12.Location = New System.Drawing.Point(26, 66)
        Me.lbl_TaxRate_12.Name = "lbl_TaxRate_12"
        Me.lbl_TaxRate_12.Size = New System.Drawing.Size(30, 13)
        Me.lbl_TaxRate_12.TabIndex = 3
        Me.lbl_TaxRate_12.Text = "12% :"
        '
        'lbl_TaxRate_18
        '
        Me.lbl_TaxRate_18.Location = New System.Drawing.Point(26, 92)
        Me.lbl_TaxRate_18.Name = "lbl_TaxRate_18"
        Me.lbl_TaxRate_18.Size = New System.Drawing.Size(30, 13)
        Me.lbl_TaxRate_18.TabIndex = 4
        Me.lbl_TaxRate_18.Text = "18% :"
        '
        'lbl_TaxRate_28
        '
        Me.lbl_TaxRate_28.Location = New System.Drawing.Point(26, 118)
        Me.lbl_TaxRate_28.Name = "lbl_TaxRate_28"
        Me.lbl_TaxRate_28.Size = New System.Drawing.Size(30, 13)
        Me.lbl_TaxRate_28.TabIndex = 5
        Me.lbl_TaxRate_28.Text = "28% :"
        '
        'frm_LedgersFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 279)
        Me.Controls.Add(Me.tc_Main)
        Me.Controls.Add(Me.btn_ResetDefaults)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Save)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_LedgersFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ledger Names"
        CType(Me.txt_TaxLedgers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RoundOffLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CESSLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SalesLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_DiscountLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CardSalesLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BankChargesLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tc_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Main.ResumeLayout(False)
        Me.tp_CustomLedgerNames.ResumeLayout(False)
        Me.tp_CustomLedgerNames.PerformLayout()
        Me.tp_LedgerNameFormats.ResumeLayout(False)
        Me.tp_LedgerNameFormats.PerformLayout()
        CType(Me.txt_BankLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Narration.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_TaxRates.ResumeLayout(False)
        Me.tp_TaxRates.PerformLayout()
        CType(Me.txt_TaxRate_0.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TaxRate_5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TaxRate_12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TaxRate_18.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TaxRate_28.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl_TaxLedgers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Preview_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Preview_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Note_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_RoundOffLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_CessLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Preview_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Preview_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Note_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TaxLedgers As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txt_RoundOffLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txt_CESSLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txt_SalesLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_DiscoundLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_DiscountLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btn_ResetDefaults As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_CardSalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_CardSalesLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_BankChargesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_BankChargesLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tc_Main As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_CustomLedgerNames As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tp_LedgerNameFormats As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txt_BankLedger As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_BankLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Narration As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Narration As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tp_TaxRates As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lbl_TaxRate_28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_TaxRate_18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_TaxRate_12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_TaxRate_5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TaxRate_28 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txt_TaxRate_18 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txt_TaxRate_12 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txt_TaxRate_5 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txt_TaxRate_0 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbl_TaxRate_0 As DevExpress.XtraEditors.LabelControl
End Class
