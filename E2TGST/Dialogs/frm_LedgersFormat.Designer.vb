<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LedgersFormat
    Inherits XtraFormTemp

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
        Me.txt_TaxLedgers = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Preview_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Preview_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Note_TaxLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_RoundOffLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_RoundOffLedger = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_CessLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_CessLedger = New DevExpress.XtraEditors.TextEdit()
        Me.btn_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_Preview_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Preview_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_SalesLedger = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Note_SalesLedger = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txt_TaxLedgers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RoundOffLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CessLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SalesLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_TaxLedgers
        '
        Me.lbl_TaxLedgers.Location = New System.Drawing.Point(12, 148)
        Me.lbl_TaxLedgers.Name = "lbl_TaxLedgers"
        Me.lbl_TaxLedgers.Size = New System.Drawing.Size(133, 13)
        Me.lbl_TaxLedgers.TabIndex = 0
        Me.lbl_TaxLedgers.Text = "Tax Ledgers Name Format :"
        '
        'txt_TaxLedgers
        '
        Me.txt_TaxLedgers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_TaxLedgers.Location = New System.Drawing.Point(151, 145)
        Me.txt_TaxLedgers.Name = "txt_TaxLedgers"
        Me.txt_TaxLedgers.Size = New System.Drawing.Size(207, 20)
        Me.txt_TaxLedgers.TabIndex = 1
        '
        'lbl_Preview_TaxLedger
        '
        Me.lbl_Preview_TaxLedger.Location = New System.Drawing.Point(151, 171)
        Me.lbl_Preview_TaxLedger.Name = "lbl_Preview_TaxLedger"
        Me.lbl_Preview_TaxLedger.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Preview_TaxLedger.TabIndex = 2
        Me.lbl_Preview_TaxLedger.Text = "Preview :-"
        '
        'txt_Preview_TaxLedger
        '
        Me.txt_Preview_TaxLedger.Location = New System.Drawing.Point(206, 171)
        Me.txt_Preview_TaxLedger.Name = "txt_Preview_TaxLedger"
        Me.txt_Preview_TaxLedger.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview_TaxLedger.TabIndex = 3
        Me.txt_Preview_TaxLedger.Text = "-"
        '
        'lbl_Note_TaxLedger
        '
        Me.lbl_Note_TaxLedger.Location = New System.Drawing.Point(166, 190)
        Me.lbl_Note_TaxLedger.Name = "lbl_Note_TaxLedger"
        Me.lbl_Note_TaxLedger.Size = New System.Drawing.Size(187, 52)
        Me.lbl_Note_TaxLedger.TabIndex = 4
        Me.lbl_Note_TaxLedger.Text = "Note :-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {0} - Tax Type (Input/Output)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {1} - Tax Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {2} - T" &
    "ax Percentage (Without '%')"
        '
        'lbl_RoundOffLedger
        '
        Me.lbl_RoundOffLedger.Location = New System.Drawing.Point(38, 19)
        Me.lbl_RoundOffLedger.Name = "lbl_RoundOffLedger"
        Me.lbl_RoundOffLedger.Size = New System.Drawing.Size(107, 13)
        Me.lbl_RoundOffLedger.TabIndex = 5
        Me.lbl_RoundOffLedger.Text = "Rounding Off Ledger :"
        '
        'txt_RoundOffLedger
        '
        Me.txt_RoundOffLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_RoundOffLedger.Location = New System.Drawing.Point(151, 16)
        Me.txt_RoundOffLedger.Name = "txt_RoundOffLedger"
        Me.txt_RoundOffLedger.Size = New System.Drawing.Size(207, 20)
        Me.txt_RoundOffLedger.TabIndex = 6
        '
        'lbl_CessLedger
        '
        Me.lbl_CessLedger.Location = New System.Drawing.Point(77, 45)
        Me.lbl_CessLedger.Name = "lbl_CessLedger"
        Me.lbl_CessLedger.Size = New System.Drawing.Size(68, 13)
        Me.lbl_CessLedger.TabIndex = 5
        Me.lbl_CessLedger.Text = "CESS Ledger :"
        '
        'txt_CessLedger
        '
        Me.txt_CessLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_CessLedger.Location = New System.Drawing.Point(151, 42)
        Me.txt_CessLedger.Name = "txt_CessLedger"
        Me.txt_CessLedger.Size = New System.Drawing.Size(207, 20)
        Me.txt_CessLedger.TabIndex = 6
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.Location = New System.Drawing.Point(283, 260)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 7
        Me.btn_Save.Text = "Save"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.Location = New System.Drawing.Point(12, 260)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 8
        Me.btn_Cancel.Text = "Cancel"
        '
        'txt_Preview_SalesLedger
        '
        Me.txt_Preview_SalesLedger.Location = New System.Drawing.Point(206, 94)
        Me.txt_Preview_SalesLedger.Name = "txt_Preview_SalesLedger"
        Me.txt_Preview_SalesLedger.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview_SalesLedger.TabIndex = 12
        Me.txt_Preview_SalesLedger.Text = "-"
        '
        'lbl_Preview_SalesLedger
        '
        Me.lbl_Preview_SalesLedger.Location = New System.Drawing.Point(151, 94)
        Me.lbl_Preview_SalesLedger.Name = "lbl_Preview_SalesLedger"
        Me.lbl_Preview_SalesLedger.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Preview_SalesLedger.TabIndex = 11
        Me.lbl_Preview_SalesLedger.Text = "Preview :-"
        '
        'txt_SalesLedger
        '
        Me.txt_SalesLedger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_SalesLedger.Location = New System.Drawing.Point(151, 68)
        Me.txt_SalesLedger.Name = "txt_SalesLedger"
        Me.txt_SalesLedger.Size = New System.Drawing.Size(207, 20)
        Me.txt_SalesLedger.TabIndex = 10
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 71)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(135, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Sales Ledger Name Format :"
        '
        'lbl_Note_SalesLedger
        '
        Me.lbl_Note_SalesLedger.Location = New System.Drawing.Point(166, 113)
        Me.lbl_Note_SalesLedger.Name = "lbl_Note_SalesLedger"
        Me.lbl_Note_SalesLedger.Size = New System.Drawing.Size(187, 26)
        Me.lbl_Note_SalesLedger.TabIndex = 13
        Me.lbl_Note_SalesLedger.Text = "Note :-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {0} - Tax Percentage (Without '%')"
        '
        'frm_TaxLedgersFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 295)
        Me.Controls.Add(Me.lbl_Note_SalesLedger)
        Me.Controls.Add(Me.txt_Preview_SalesLedger)
        Me.Controls.Add(Me.lbl_Preview_SalesLedger)
        Me.Controls.Add(Me.txt_SalesLedger)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.txt_CessLedger)
        Me.Controls.Add(Me.txt_RoundOffLedger)
        Me.Controls.Add(Me.lbl_CessLedger)
        Me.Controls.Add(Me.lbl_RoundOffLedger)
        Me.Controls.Add(Me.lbl_Note_TaxLedger)
        Me.Controls.Add(Me.txt_Preview_TaxLedger)
        Me.Controls.Add(Me.lbl_Preview_TaxLedger)
        Me.Controls.Add(Me.txt_TaxLedgers)
        Me.Controls.Add(Me.lbl_TaxLedgers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_TaxLedgersFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ledger Names"
        CType(Me.txt_TaxLedgers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_RoundOffLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CessLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SalesLedger.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_TaxLedgers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TaxLedgers As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Preview_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Preview_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Note_TaxLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_RoundOffLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_RoundOffLedger As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_CessLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_CessLedger As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Preview_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Preview_SalesLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_SalesLedger As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Note_SalesLedger As DevExpress.XtraEditors.LabelControl
End Class
