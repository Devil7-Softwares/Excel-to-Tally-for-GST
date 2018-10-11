Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
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
        txt_StateCode.EditValue = My.Settings.StateCode
    End Sub

    Function CheckDependencies(ByVal Vouchers As List(Of Objects.Voucher)) As Boolean
        Dim MissingLedgers As New List(Of String)
        For Each voucher As Objects.Voucher In Vouchers
            For Each entry As Objects.VoucherEntry In voucher.Entries
                If Not TallyIO.Ledgers.Contains(entry.LedgerName) Then
                    If Not MissingLedgers.Contains(entry.LedgerName) Then MissingLedgers.Add(entry.LedgerName)
                End If
            Next
        Next

        If MissingLedgers.Count > 0 Then
            MsgBox(String.Format("The following ledgers are missing in tally:{0}{0}{0}{1}{0}{0}Create them and Sync again to continue.", vbNewLine, String.Join(vbNewLine, MissingLedgers)), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Aborting...")
            Return False
        Else
            Return True
        End If
    End Function

    Async Function LoadParties(ByVal FileName As String) As Task
        Dim Skipped As Integer = 0
        Dim Loaded As Integer = 0
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
                                                       If R.Find(Function(c) c.GSTIN = GSTIN) Is Nothing AndAlso R.Find(Function(c) c.Name = Name) Is Nothing Then
                                                           R.Add(New Objects.Party(Name, GSTIN, RegType, Type))
                                                           Loaded += 1
                                                       Else
                                                           Skipped += 1
                                                       End If
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_Parties.DataSource = R
                                          gc_Parties.RefreshDataSource()
                                          Dim msg As String = ""
                                          If Loaded = 0 Then
                                              msg = "No Entries Loaded"
                                          Else
                                              msg = "{0} Entries Loaded"
                                          End If
                                          If Skipped = 0 Then
                                              msg &= "."
                                          Else
                                              msg &= " And {1} Duplicate Entries Skipped."
                                          End If
                                          MsgBox(String.Format(msg, Loaded, Skipped), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
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

    Async Function LoadSalesEntries(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_SalesEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.SalesEntry)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "SalesEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim GSTIN As String = reader.GetString(0).Trim
                                                   Dim InvoiceDate As Date = If(reader.IsDBNull(1), Now, reader.GetDateTime(1))
                                                   If GSTIN <> "" Then
                                                       Dim InvoiceNo As String = ""
                                                       Try
                                                           InvoiceNo = If(reader.IsDBNull(2), "", reader.GetDouble(2))
                                                       Catch e1 As Exception
                                                           Try
                                                               InvoiceNo = reader.GetString(2)
                                                           Catch e2 As Exception

                                                           End Try
                                                       End Try
                                                       Dim InvoiceValue As Double = If(reader.IsDBNull(3), 0, reader.GetDouble(3))
                                                       Dim GSTRate As Integer = If(reader.IsDBNull(4), 0, reader.GetDouble(4))
                                                       Dim TaxableValue As Double = If(reader.IsDBNull(5), 0, reader.GetDouble(5))
                                                       Dim IGST As Double = If(reader.IsDBNull(6), 0, reader.GetDouble(6))
                                                       Dim CGST As Double = If(reader.IsDBNull(7), 0, reader.GetDouble(7))
                                                       Dim SGST As Double = If(reader.IsDBNull(8), 0, reader.GetDouble(8))
                                                       Dim CESS As Double = If(reader.IsDBNull(9), 0, reader.GetDouble(9))
                                                       R.Add(New Objects.SalesEntry(GSTIN, InvoiceDate, InvoiceNo, InvoiceValue, GSTRate, TaxableValue, IGST, CGST, SGST, CESS))
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_SalesEntries.DataSource = R
                                          gc_SalesEntries.RefreshDataSource()
                                      End Sub)
                           Catch ex As Exception
                               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                               Return False
                           End Try
                           Return True
                       End Function)
        Invoke(Sub()
                   btn_LoadExcel.Enabled = True
                   ProgressPanel_SalesEntries.Visible = False
               End Sub)
    End Function

    Private Async Sub Export(ByVal XML As String, ByVal Filename As String)
        If Filename <> "" Then
            My.Computer.FileSystem.WriteAllText(Filename, XML, False)
            MsgBox("XML File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
        Else
            Dim Response As Objects.Response = Await TallyIO.SendRequestToTally(XML)
            If Response.Status Then
                MsgBox("Successfully Exported XML to Tally.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Else
                Dim XMLRes As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, String.Format("TallyExport_{0}.xml", Now.ToString("ddMMyyyy_hhmmss")))
                My.Computer.FileSystem.WriteAllText(XMLRes, XML, False)
                MsgBox("Errors on Exporting XML to Tally..! XML Respose Saved to Desktop.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End If
        End If
    End Sub

    Sub ExportParties(ByVal FileName As String)
        Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
        Dim XML As String = XMLGen.GenerateMasters(gc_Parties.DataSource, TallyIO.Ledgers)
        Export(XML, FileName)
    End Sub

    Sub ExportPurchase(ByVal Filename As String)
        Dim Vouchers As List(Of Objects.Voucher) = Tally.Converter.Purchase2Vouchers(gc_PurchaseEntries.DataSource)
        If CheckDependencies(Vouchers) Then
            Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
            Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
            Export(XML, Filename)
        End If
    End Sub

    Sub ExportSales(ByVal Filename As String)
        Dim Vouchers As List(Of Objects.Voucher) = Tally.Converter.Sales2Vouchers(gc_SalesEntries.DataSource)
        If CheckDependencies(Vouchers) Then
            Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
            Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
            Export(XML, Filename)
        End If
    End Sub

    Sub ExportParties()
        ExportParties("")
    End Sub

    Sub ExportPurchase()
        ExportPurchase("")
    End Sub

    Sub ExportSales()
        ExportSales("")
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
            ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
                Await LoadSalesEntries(OpenFileDialog_Excel.FileName)
            End If
        End If
    End Sub

    Private Sub btn_XML_File_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_XML_File.ItemClick
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            SaveFileDialog_XML.FileName = "Purchase Entries.xml"
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            SaveFileDialog_XML.FileName = "Parties.xml"
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            SaveFileDialog_XML.FileName = "Sales Entries.xml"
        End If
        If SaveFileDialog_XML.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                ExportPurchase(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                ExportParties(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
                ExportSales(SaveFileDialog_XML.FileName)
            End If
        End If
    End Sub

    Private Sub txt_TallyVersion_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyVersion.EditValueChanged
        My.Settings.TallyVersion = txt_TallyVersion.EditValue
        My.Settings.Save()
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
        PictureBox_Logo.Visible = False
        If RibbonControl.SelectedPage Is rp_Tally Then
            PictureBox_Logo.Visible = True
        ElseIf RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            container_Tabs.SelectedTabPage = tp_PurchaseEntries
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            container_Tabs.SelectedTabPage = tp_Parties
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            container_Tabs.SelectedTabPage = tp_SalesEntries
        End If
    End Sub

    Private Sub container_Tabs_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles container_Tabs.SelectedPageChanged
        If container_Tabs.SelectedTabPage Is tp_PurchaseEntries Then
            RibbonControl.SelectedPage = rp_PurchaseEntries
        ElseIf container_Tabs.SelectedTabPage Is tp_Parties Then
            RibbonControl.SelectedPage = rp_Parties
        ElseIf container_Tabs.SelectedTabPage Is tp_SalesEntries Then
            RibbonControl.SelectedPage = rp_SalesEntries
        End If
    End Sub

    Private Sub chk_CalcValues_EditValueChanged(sender As Object, e As EventArgs) Handles chk_CalcValues.EditValueChanged
        My.Settings.CalculateValues = chk_CalcValues.EditValue
        My.Settings.Save()
    End Sub

    Private Sub btn_LedgerNames_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_LedgerNames.ItemClick
        frm_LedgersFormat.ShowDialog()
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
        Invoke(Sub()
                   btn_Sync.Enabled = False
                   ProgressPanel_Main.Visible = True
               End Sub)
        If Not Await TallyIO.LoadAllMasters Then GoTo finish
finish:
        Invoke(Sub()
                   txt_CompanyName.EditValue = TallyIO.CompanyName
                   btn_Sync.Enabled = True
                   ProgressPanel_Main.Visible = False
                   If TallyIO.CompanyName <> "" Then
                       rp_PurchaseEntries.Visible = True
                       rp_SalesEntries.Visible = True
                       rp_Parties.Visible = True
                   End If
               End Sub)
    End Sub

    Private Sub gv_Parties_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv_Parties.CustomDrawCell
        If e.Column.FieldName = "Name" Then
            Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)
            Dim row As Objects.Party = gv_Parties.GetRow(e.RowHandle)

            If cellInfo IsNot Nothing Then
                If TallyIO IsNot Nothing AndAlso TallyIO.Ledgers IsNot Nothing AndAlso TallyIO.Ledgers.Count > 0 AndAlso (TallyIO.Ledgers.Contains(row.GSTIN) Or TallyIO.Ledgers.Contains(row.Name)) Then
                    cellInfo.ViewInfo.ErrorIconText = "Ledger Already Exists. Will be Ignored."
                    cellInfo.ViewInfo.ShowErrorIcon = True
                End If
            End If
        End If
    End Sub

    Private Sub gv_PurchaseEntries_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv_PurchaseEntries.CustomDrawCell
        If e.Column.FieldName = "GSTIN" Or e.Column.FieldName = "LedgerName" Then
            Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)
            Dim row As Objects.PurchaseEntry = gv_PurchaseEntries.GetRow(e.RowHandle)

            If cellInfo IsNot Nothing Then
                If TallyIO IsNot Nothing AndAlso TallyIO.Ledgers IsNot Nothing AndAlso TallyIO.Ledgers.Count > 0 Then
                    If e.Column.FieldName = "GSTIN" AndAlso Not TallyIO.Ledgers.Contains(row.GSTIN) Then
                        cellInfo.ViewInfo.ErrorIconText = "Party Doesn't Exist in Tally Ledgers!"
                        cellInfo.ViewInfo.ShowErrorIcon = True
                    ElseIf e.Column.FieldName = "LedgerName" AndAlso Not TallyIO.Ledgers.Contains(row.LedgerName) Then
                        cellInfo.ViewInfo.ErrorIconText = "Ledger Doesn't Exist in Tally Ledgers!"
                        cellInfo.ViewInfo.ShowErrorIcon = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_Refresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Refresh.ItemClick
        If RibbonControl.SelectedPage Is rp_Parties Then
            gc_Parties.RefreshDataSource()
        ElseIf RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            gc_PurchaseEntries.RefreshDataSource()
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            gc_SalesEntries.RefreshDataSource()
        End If
    End Sub

    Private Sub btn_XML_Tally_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_XML_Tally.ItemClick
        If MsgBox("Are You Sure to Export XML to Tally...?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                ExportPurchase()
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                ExportParties()
            ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
                ExportSales()
            End If
        End If
    End Sub

    Private Sub btn_Template_Parties_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_Parties.ItemClick
        SaveFileDialog_Excel.FileName = "Parties.xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, My.Resources.Parties, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub btn_Template_PurchaseEntries_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_PurchaseEntries.ItemClick
        SaveFileDialog_Excel.FileName = "Purchase Entries.xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, My.Resources.PurchaseEntries, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub btn_Template_SalesEntries_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_SalesEntries.ItemClick
        SaveFileDialog_Excel.FileName = "Sales Entries.xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, My.Resources.SalesEntries, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub btn_About_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_About.ItemClick
        frm_About.ShowDialog()
    End Sub

    Private Sub frm_Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If My.Settings.FirstRun Then
            My.Settings.FirstRun = False
            My.Settings.Save()
            frm_About.ShowDialog()
        End If
    End Sub

    Private Sub txt_StateCode_ItemClick(sender As Object, e As ItemClickEventArgs) Handles txt_StateCode.ItemClick

    End Sub

    Private Sub txt_StateCode_EditValueChanged(sender As Object, e As EventArgs) Handles txt_StateCode.EditValueChanged
        My.Settings.StateCode = txt_StateCode.EditValue
        My.Settings.Save()
    End Sub
#End Region

End Class