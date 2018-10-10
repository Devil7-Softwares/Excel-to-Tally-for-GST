Imports DevExpress.XtraBars
Imports DevExpress.XtraTab
Imports ExcelDataReader

Public Class frm_Main

#Region "Variables"
    Dim TallyIO As New Tally.IO
#End Region

#Region "Subs"
    Sub LoadSettings()
        txt_TallyHost.EditValue = My.Settings.Host
        txt_TallyPort.EditValue = My.Settings.Port
        txt_TallyVersion.EditValue = My.Settings.TallyVersion
        chk_CalcValues.EditValue = My.Settings.CalculateValues
    End Sub

    Async Function LoadParties(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_Parties.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.Party)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "Parties" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim Name As String = reader.GetString(0).Trim
                                                   If Name <> "" Then
                                                       Dim GSTIN As String = reader.GetString(1).Trim
                                                       Dim Type As Enums.PartyType = If(reader.GetString(3) = "SundryCreditor", 1, 0)
                                                       Dim RegType As Enums.RegistrationType = Enums.RegistrationType.Unknown
                                                       Dim RegType_ As String = reader.GetString(2)
                                                       If RegType_ = "Consumer" Then
                                                           RegType = Enums.RegistrationType.Consumer
                                                       ElseIf RegType_ = "Unregistered" Then
                                                           RegType = Enums.RegistrationType.Unregistered
                                                       ElseIf RegType_ = "Regular" Then
                                                           RegType = Enums.RegistrationType.Regular
                                                       ElseIf RegType_ = "Composition" Then
                                                           RegType = Enums.RegistrationType.Composition
                                                       End If
                                                       R.Add(New Objects.Party(Name, GSTIN, RegType, Type))
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_Parties.DataSource = R
                                          gc_Parties.RefreshDataSource()
                                      End Sub)
                           Catch ex As Exception
                               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                               Return False
                           End Try
                           Return True
                       End Function)
        Invoke(Sub()
                   btn_LoadExcel.Enabled = True
                   ProgressPanel_Parties.Visible = False
               End Sub)
    End Function

    Async Function LoadPurchaseEntries(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_PurchaseEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.PurchaseEntry)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "PurchaseEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim GSTIN As String = reader.GetString(0).Trim
                                                   If GSTIN <> "" Then
                                                       Dim InvoiceNo As String = ""
                                                       Try
                                                           InvoiceNo = If(reader.IsDBNull(1), "", reader.GetDouble(1))
                                                       Catch e1 As Exception
                                                           Try
                                                               InvoiceNo = reader.GetString(1)
                                                           Catch e2 As Exception

                                                           End Try
                                                       End Try
                                                       Dim InvoiceDate As Date = If(reader.IsDBNull(2), Now, reader.GetDateTime(2))
                                                       Dim InvoiceValue As Double = If(reader.IsDBNull(3), 0, reader.GetDouble(3))
                                                       Dim GSTRate As Integer = If(reader.IsDBNull(4), 0, reader.GetDouble(4))
                                                       Dim TaxableValue As Double = If(reader.IsDBNull(5), 0, reader.GetDouble(5))
                                                       Dim IGST As Double = If(reader.IsDBNull(6), 0, reader.GetDouble(6))
                                                       Dim CGST As Double = If(reader.IsDBNull(7), 0, reader.GetDouble(7))
                                                       Dim SGST As Double = If(reader.IsDBNull(8), 0, reader.GetDouble(8))
                                                       Dim CESS As Double = If(reader.IsDBNull(9), 0, reader.GetDouble(9))
                                                       Dim LedgerName As String = If(reader.IsDBNull(10), 0, reader.GetString(10))
                                                       Dim VoucherType_ As String = If(reader.IsDBNull(11), 0, reader.GetString(11))
                                                       Dim VoucherType As Enums.VoucherType = Enums.VoucherType.Purchase
                                                       If VoucherType_ = "Payment" Then
                                                           VoucherType = Enums.VoucherType.Payment
                                                       ElseIf VoucherType_ = "Receipt" Then
                                                           VoucherType = Enums.VoucherType.Receipt
                                                       ElseIf VoucherType_ = "Purchase" Then
                                                           VoucherType = Enums.VoucherType.Purchase
                                                       ElseIf VoucherType_ = "Sales" Then
                                                           VoucherType = Enums.VoucherType.Sales
                                                       ElseIf VoucherType_ = "Journal" Then
                                                           VoucherType = Enums.VoucherType.Journal
                                                       End If
                                                       R.Add(New Objects.PurchaseEntry(GSTIN, InvoiceNo, InvoiceDate, InvoiceValue, GSTRate, TaxableValue, IGST, CGST, SGST, CESS, LedgerName, VoucherType))
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_PurchaseEntries.DataSource = R
                                          gc_PurchaseEntries.RefreshDataSource()
                                      End Sub)
                           Catch ex As Exception
                               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                               Return False
                           End Try
                           Return True
                       End Function)
        Invoke(Sub()
                   btn_LoadExcel.Enabled = True
                   ProgressPanel_PurchaseEntries.Visible = False
               End Sub)
    End Function

    Sub ExportParties(ByVal FileName As String)
        Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
        Dim XML As String = XMLGen.GenerateMasters(gc_Parties.DataSource)
        My.Computer.FileSystem.WriteAllText(FileName, XML, False)
        MsgBox("XML File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
    End Sub

    Sub ExportPurchase(ByVal Filename As String)
        Dim Vouchers As List(Of Objects.Voucher) = Tally.Converter.Purchase2Vouchers(gc_PurchaseEntries.DataSource)
        Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
        Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
        My.Computer.FileSystem.WriteAllText(Filename, XML, False)
        MsgBox("XML File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
    End Sub
#End Region

#Region "Events"
    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSettings()
    End Sub

    Private Async Sub btn_LoadExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_LoadExcel.ItemClick
        If OpenFileDialog_Excel.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                Await LoadPurchaseEntries(OpenFileDialog_Excel.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                Await LoadParties(OpenFileDialog_Excel.FileName)
            End If
        End If
    End Sub

    Private Sub btn_SaveFormat_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_SaveFormat.ItemClick
        Dim Data As Byte() = Nothing
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            Data = My.Resources.PurchaseEntries
            SaveFileDialog_Excel.FileName = "PurchaseEntries.xlsx"
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            Data = My.Resources.Parties
            SaveFileDialog_Excel.FileName = "Parties.xlsx"
        End If
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Data, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub btn_XML_File_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_XML_File.ItemClick
        If SaveFileDialog_XML.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                ExportPurchase(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                ExportParties(SaveFileDialog_XML.FileName)
            End If
        End If
    End Sub

    Private Sub txt_TallyVersion_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyVersion.EditValueChanged
        My.Settings.TallyVersion = txt_TallyVersion.EditValue
        My.Settings.Save()
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            container_Tabs.SelectedTabPage = tp_PurchaseEntries
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            container_Tabs.SelectedTabPage = tp_Parties
        End If
    End Sub

    Private Sub container_Tabs_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles container_Tabs.SelectedPageChanged
        If container_Tabs.SelectedTabPage Is tp_PurchaseEntries Then
            RibbonControl.SelectedPage = rp_PurchaseEntries
        ElseIf container_Tabs.SelectedTabPage Is tp_Parties Then
            RibbonControl.SelectedPage = rp_Parties
        End If
    End Sub

    Private Sub chk_CalcValues_EditValueChanged(sender As Object, e As EventArgs) Handles chk_CalcValues.EditValueChanged
        My.Settings.CalculateValues = chk_CalcValues.EditValue
        My.Settings.Save()
    End Sub

    Private Sub btn_LedgerNames_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_LedgerNames.ItemClick
        frm_TaxLedgersFormat.ShowDialog()
    End Sub

    Private Sub txt_TallyHost_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyHost.EditValueChanged
        My.Settings.Host = txt_TallyHost.EditValue.ToString
        My.Settings.Save()
    End Sub

    Private Sub txt_TallyPort_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyPort.EditValueChanged
        Try
            My.Settings.Port = CInt(txt_TallyPort.EditValue)
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Only Numric Values are Allowed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Async Sub btn_Sync_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Sync.ItemClick
        Invoke(Sub() btn_Sync.Enabled = False)
        If Not Await TallyIO.LoadAllMasters Then GoTo finish
finish:
            Invoke(Sub()
                       txt_CompanyName.EditValue = TallyIO.CompanyName
                       btn_Sync.Enabled = True
                       ProgressPanel_Main.Visible = False
                   End Sub)
            End Sub
#End Region

End Class