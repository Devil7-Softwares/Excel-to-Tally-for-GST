<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_TaxLedgersFormat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_TaxLedgersFormat))
        Me.lbl_TaxLedgers = New DevExpress.XtraEditors.LabelControl()
        Me.txt_TaxLedgers = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Preview = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Preview = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Note = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_RoundOffLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_RoundOffLedger = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_CessLedger = New DevExpress.XtraEditors.LabelControl()
        Me.txt_CessLedger = New DevExpress.XtraEditors.TextEdit()
        Me.btn_Save = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txt_TaxLedgers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_RoundOffLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CessLedger.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_TaxLedgers
        '
        Me.lbl_TaxLedgers.Location = New System.Drawing.Point(12, 71)
        Me.lbl_TaxLedgers.Name = "lbl_TaxLedgers"
        Me.lbl_TaxLedgers.Size = New System.Drawing.Size(133, 13)
        Me.lbl_TaxLedgers.TabIndex = 0
        Me.lbl_TaxLedgers.Text = "Tax Ledgers Name Format :"
        '
        'txt_TaxLedgers
        '
        Me.txt_TaxLedgers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_TaxLedgers.Location = New System.Drawing.Point(151, 68)
        Me.txt_TaxLedgers.Name = "txt_TaxLedgers"
        Me.txt_TaxLedgers.Size = New System.Drawing.Size(207, 20)
        Me.txt_TaxLedgers.TabIndex = 1
        '
        'lbl_Preview
        '
        Me.lbl_Preview.Location = New System.Drawing.Point(151, 94)
        Me.lbl_Preview.Name = "lbl_Preview"
        Me.lbl_Preview.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Preview.TabIndex = 2
        Me.lbl_Preview.Text = "Preview :-"
        '
        'txt_Preview
        '
        Me.txt_Preview.Location = New System.Drawing.Point(206, 94)
        Me.txt_Preview.Name = "txt_Preview"
        Me.txt_Preview.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview.TabIndex = 3
        Me.txt_Preview.Text = "-"
        '
        'lbl_Note
        '
        Me.lbl_Note.Location = New System.Drawing.Point(166, 113)
        Me.lbl_Note.Name = "lbl_Note"
        Me.lbl_Note.Size = New System.Drawing.Size(187, 39)
        Me.lbl_Note.TabIndex = 4
        Me.lbl_Note.Text = "Note :-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {0} - Tax Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      {1} - Tax Percentage (Without '%')"
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
        Me.btn_Save.Location = New System.Drawing.Point(283, 165)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 7
        Me.btn_Save.Text = "Save"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(12, 165)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 8
        Me.btn_Cancel.Text = "Cancel"
        '
        'frm_TaxLedgersFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 200)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.txt_CessLedger)
        Me.Controls.Add(Me.txt_RoundOffLedger)
        Me.Controls.Add(Me.lbl_CessLedger)
        Me.Controls.Add(Me.lbl_RoundOffLedger)
        Me.Controls.Add(Me.lbl_Note)
        Me.Controls.Add(Me.txt_Preview)
        Me.Controls.Add(Me.lbl_Preview)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_TaxLedgers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TaxLedgers As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Preview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Preview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Note As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_RoundOffLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_RoundOffLedger As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_CessLedger As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_CessLedger As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_Save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancel As DevExpress.XtraEditors.SimpleButton
End Class
