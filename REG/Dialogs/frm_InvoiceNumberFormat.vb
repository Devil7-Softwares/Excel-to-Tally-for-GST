Public Class frm_InvoiceNumberFormat

#Region "Properties"
    Property InvoiceNumberFormat As String
        Get
            Return txt_Format.Text
        End Get
        Set(value As String)
            txt_Format.Text = value
        End Set
    End Property
#End Region

#Region "Button Events"
    Private Sub btn_Ok_Click(sender As Object, e As EventArgs) Handles btn_Ok.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub
#End Region

#Region "Other Events"
    Private Sub lbl_MoreInfo_Click(sender As Object, e As EventArgs) Handles lbl_MoreInfo.Click
        Process.Start("https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.strings.format")
    End Sub

    Private Sub txt_Format_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Format.EditValueChanged
        txt_Preview.Text = String.Format(txt_Format.Text, 1, 2019, 19, 12, 31)
    End Sub
#End Region

End Class