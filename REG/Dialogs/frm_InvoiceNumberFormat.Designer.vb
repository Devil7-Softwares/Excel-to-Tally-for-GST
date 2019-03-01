<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_InvoiceNumberFormat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_InvoiceNumberFormat))
        Me.lbl_Format = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Format = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Elements = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Elements = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Preview = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Preview = New DevExpress.XtraEditors.LabelControl()
        Me.btn_Ok = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_MoreInfo = New DevExpress.XtraEditors.HyperlinkLabelControl()
        CType(Me.txt_Format.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Format
        '
        Me.lbl_Format.Location = New System.Drawing.Point(18, 15)
        Me.lbl_Format.Name = "lbl_Format"
        Me.lbl_Format.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Format.TabIndex = 0
        Me.lbl_Format.Text = "Format :"
        '
        'txt_Format
        '
        Me.txt_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Format.Location = New System.Drawing.Point(65, 12)
        Me.txt_Format.Name = "txt_Format"
        Me.txt_Format.Size = New System.Drawing.Size(177, 20)
        Me.txt_Format.TabIndex = 1
        '
        'lbl_Elements
        '
        Me.lbl_Elements.Location = New System.Drawing.Point(12, 38)
        Me.lbl_Elements.Name = "lbl_Elements"
        Me.lbl_Elements.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Elements.TabIndex = 2
        Me.lbl_Elements.Text = "Elements:"
        '
        'txt_Elements
        '
        Me.txt_Elements.Location = New System.Drawing.Point(65, 38)
        Me.txt_Elements.Name = "txt_Elements"
        Me.txt_Elements.Size = New System.Drawing.Size(148, 65)
        Me.txt_Elements.TabIndex = 3
        Me.txt_Elements.Text = "{0} - Invoice Number (Integer)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{1} - Year (YYYY)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{2} - Year (YY)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{3} - Month" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "{4} - Day"
        '
        'lbl_Preview
        '
        Me.lbl_Preview.Location = New System.Drawing.Point(18, 109)
        Me.lbl_Preview.Name = "lbl_Preview"
        Me.lbl_Preview.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Preview.TabIndex = 4
        Me.lbl_Preview.Text = "Preview :"
        '
        'txt_Preview
        '
        Me.txt_Preview.Location = New System.Drawing.Point(69, 109)
        Me.txt_Preview.Name = "txt_Preview"
        Me.txt_Preview.Size = New System.Drawing.Size(4, 13)
        Me.txt_Preview.TabIndex = 5
        Me.txt_Preview.Text = "-"
        '
        'btn_Ok
        '
        Me.btn_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Ok.Location = New System.Drawing.Point(167, 135)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_Ok.TabIndex = 6
        Me.btn_Ok.Text = "OK"
        '
        'lbl_MoreInfo
        '
        Me.lbl_MoreInfo.Location = New System.Drawing.Point(12, 141)
        Me.lbl_MoreInfo.Name = "lbl_MoreInfo"
        Me.lbl_MoreInfo.Size = New System.Drawing.Size(47, 13)
        Me.lbl_MoreInfo.TabIndex = 7
        Me.lbl_MoreInfo.Text = "More Info"
        '
        'frm_InvoiceNumberFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 166)
        Me.Controls.Add(Me.lbl_MoreInfo)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.txt_Preview)
        Me.Controls.Add(Me.lbl_Preview)
        Me.Controls.Add(Me.txt_Elements)
        Me.Controls.Add(Me.lbl_Elements)
        Me.Controls.Add(Me.txt_Format)
        Me.Controls.Add(Me.lbl_Format)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_InvoiceNumberFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice Number Format"
        CType(Me.txt_Format.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Format As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Format As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Elements As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Elements As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Preview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Preview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_MoreInfo As DevExpress.XtraEditors.HyperlinkLabelControl
End Class
