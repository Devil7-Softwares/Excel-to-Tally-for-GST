﻿Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraTab
Imports ExcelDataReader

Public Class frm_Main

#Region "Variables"
    Dim TallyIO As New Tally.IO
#End Region

#Region "Excel Reader Functions"
    Function GetString(ByVal Reader As IExcelDataReader, ByVal Index As Integer) As String
        If Not Reader.IsDBNull(Index) Then
            Try
                Return Reader.GetValue(Index).ToString.Trim
            Catch ex As Exception

            End Try
        End If
        Return ""
    End Function

    Function GetDouble(ByVal Reader As IExcelDataReader, ByVal Index As Integer) As Double
        Dim R As Double = 0
        If Not Reader.IsDBNull(Index) Then
            Dim Val As String = GetString(Reader, Index)
            If Val <> "" Then Double.TryParse(Val, R)
        End If
        Return R
    End Function

    Function GetDate(ByVal Reader As IExcelDataReader, ByVal Index As Integer) As Date
        Dim R As Date = Nothing
        If Not Reader.IsDBNull(Index) Then
            Dim Val As String = GetString(Reader, Index)
            If Val <> "" Then Date.TryParse(Val, R)
        End If
        Return R
    End Function
#End Region

#Region "Subs"
    Sub LoadSettings()
        txt_TallyHost.EditValue = Utils.Settings.Load.Host
        txt_TallyPort.EditValue = Utils.Settings.Load.Port
        txt_TallyVersion.EditValue = Utils.Settings.Load.TallyVersion
        txt_StateCode.EditValue = Utils.Settings.Load.StateCode
        txt_BankLedgerName.EditValue = Utils.Settings.Load.BankLedgerName
        chk_IncludeDesc.EditValue = Utils.Settings.Load.IncludeDesc
        chk_IgnoreDupParties.EditValue = Utils.Settings.Load.IgnoreDuplicateParties
        chk_UseInvoiceNoTag.EditValue = Utils.Settings.Load.UseInvoiceNumberTag
        chk_TallyOldVersion.EditValue = Utils.Settings.Load.TallyOldVersion
        chk_CombineSales.EditValue = Utils.Settings.Load.CombineSales
        chk_DontJoinCardSales.EditValue = Utils.Settings.Load.DontJoinCardSales
        txt_InvoiceNo_Regex.EditValue = Utils.Settings.Load.InvoiceNoRegex
        txt_TaxType.EditValue = If(Utils.Settings.Load.TaxType = 0, "GST", "VAT")
    End Sub

    Function CheckDependencies(ByVal Vouchers As List(Of Objects.Voucher)) As Boolean
        Dim MissingLedgers As New List(Of String)
        For Each voucher As Objects.Voucher In Vouchers
            For Each entry As Objects.VoucherEntry In voucher.Entries
                If entry.LedgerName.Contains(";") Then
                    Dim LedgerNames As String() = entry.LedgerName.Split(";")
                    For Each i As String In LedgerNames
                        If Not TallyIO.Ledgers.Contains(i.Split("=")(0).Trim, StringComparer.OrdinalIgnoreCase) And Not MissingLedgers.Contains(i.Split("=")(0).Trim) Then MissingLedgers.Add(i.Split("=")(0).Trim)
                    Next
                Else
                    If Not TallyIO.Ledgers.Contains(entry.LedgerName, StringComparer.OrdinalIgnoreCase) And Not MissingLedgers.Contains(entry.LedgerName) Then MissingLedgers.Add(entry.LedgerName)
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

    Function FindParty(ByVal Key As String) As Objects.Party
        Dim R As Objects.Party = Nothing

        If TallyIO IsNot Nothing AndAlso TallyIO.Parties IsNot Nothing Then
            R = TallyIO.Parties.Find(Function(c) c.Name.Replace(" ", "").Equals(Key.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) Or c.GSTIN.Trim.Equals(Key.Trim, StringComparison.OrdinalIgnoreCase))
        End If

        Return R
    End Function

    Async Function LoadParties(ByVal FileName As String) As Task
        Dim Skipped As Integer = 0
        Dim Loaded As Integer = 0
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_Parties.Caption = "Loading Entries from Excel..."
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
                                                   Dim Name As String = GetString(reader, 0)
                                                   If Name <> "" Then
                                                       Dim GSTIN As String = GetString(reader, 1)
                                                       Dim Type As Enums.PartyType = If(GetString(reader, 3) = "SundryCreditor", 1, 0)
                                                       Dim RegType As Enums.RegistrationType = Enums.RegistrationType.Unknown
                                                       Dim RegType_ As String = GetString(reader, 2)
                                                       If RegType_ = "Consumer" Then
                                                           RegType = Enums.RegistrationType.Consumer
                                                       ElseIf RegType_ = "Unregistered" Then
                                                           RegType = Enums.RegistrationType.Unregistered
                                                       ElseIf RegType_ = "Regular" Then
                                                           RegType = Enums.RegistrationType.Regular
                                                       ElseIf RegType_ = "Composition" Then
                                                           RegType = Enums.RegistrationType.Composition
                                                       End If
                                                       If R.Find(Function(c) c.Name = Name) IsNot Nothing Or (GSTIN.Trim <> "" AndAlso R.Find(Function(c) c.GSTIN = GSTIN) IsNot Nothing) Then
                                                           Skipped += 1
                                                       Else
                                                           R.Add(New Objects.Party(Name, GSTIN, RegType, Type))
                                                           Loaded += 1
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
                   ProgressPanel_PurchaseEntries.Caption = "Loading Entries from Excel..."
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
                                                   Dim PartyRef As String = GetString(reader, 0)
                                                   If PartyRef <> "" Then
                                                       Dim Party As Objects.Party = FindParty(PartyRef)
                                                       Dim InvoiceNo As String = GetString(reader, 1)
                                                       Dim InvoiceDate As Date = GetDate(reader, 2)
                                                       Dim InvoiceValue As Double = GetDouble(reader, 3)
                                                       Dim GSTRate As Double = GetDouble(reader, 4)
                                                       Dim TaxableValue As Double = GetDouble(reader, 5)
                                                       Dim CESS As Double = GetDouble(reader, 6)
                                                       Dim LedgerName As String = GetString(reader, 7)
                                                       Dim VoucherType_ As String = GetString(reader, 8)
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
                                                       ElseIf VoucherType_ = "Debit Note" Then
                                                           VoucherType = Enums.VoucherType.DebitNote
                                                       End If
                                                       Dim StateCode As Integer = Utils.Settings.Load.StateCode
                                                       Try
                                                           Dim TmpSC_ As String = GetString(reader, 9)
                                                           If TmpSC_.Contains("-") Then
                                                               StateCode = CInt(TmpSC_.Split("-")(0).Trim)
                                                           Else
                                                               StateCode = CInt(TmpSC_)
                                                           End If
                                                       Catch ex As Exception

                                                       End Try
                                                       Dim CustomNarration As String = GetString(reader, 10)
                                                       R.Add(New Objects.PurchaseEntry(Party, PartyRef, InvoiceNo, InvoiceDate, InvoiceValue, GSTRate, TaxableValue, CESS, LedgerName, VoucherType, Objects.State.GetStateByCode(StateCode), CustomNarration))
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

    Async Function LoadSalesEntriesA(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_SalesEntries.Caption = "Loading Entries from Excel..."
                   ProgressPanel_SalesEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.SalesEntryA)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "SalesEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim PartyRef As String = GetString(reader, 0)
                                                   Dim InvoiceDate As Date = GetDate(reader, 1)
                                                   If PartyRef <> "" Then
                                                       Dim Party As Objects.Party = FindParty(PartyRef)
                                                       Dim InvoiceNo As String = GetString(reader, 2)
                                                       Dim InvoiceValue As Double = GetDouble(reader, 3)
                                                       Dim GSTRate As Double = GetDouble(reader, 4)
                                                       Dim TaxableValue As Double = GetDouble(reader, 5)
                                                       Dim CESS As Double = GetDouble(reader, 6)
                                                       Dim StateCode As Integer = Utils.Settings.Load.StateCode
                                                       Try
                                                           Dim TmpSC_ As String = GetString(reader, 7)
                                                           If TmpSC_.Contains("-") Then
                                                               StateCode = CInt(TmpSC_.Split("-")(0).Trim)
                                                           Else
                                                               StateCode = CInt(TmpSC_)
                                                           End If
                                                       Catch ex1 As Exception
                                                           Try
                                                               If PartyRef <> "" Then
                                                                   StateCode = CInt(PartyRef.Substring(0, 2))
                                                               End If
                                                           Catch ex2 As Exception

                                                           End Try
                                                       End Try
                                                       Dim CustomSalesLedger As String = GetString(reader, 8)
                                                       R.Add(New Objects.SalesEntryA(Party, PartyRef, InvoiceDate, InvoiceNo, InvoiceValue, GSTRate, TaxableValue, CESS, If(Party Is Nothing, Objects.State.GetStateByCode(StateCode), Party.State), CustomSalesLedger))
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

                   Try
                       If Utils.Settings.Load.CombineSales Then
                           gv_SalesEntries.Columns.Item("RegexInvoiceNo").Visible = True
                       Else
                           gv_SalesEntries.Columns.Item("RegexInvoiceNo").Visible = False
                       End If
                   Catch ex As Exception

                   End Try
               End Sub)
    End Function

    Async Function LoadSalesEntriesB(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_SalesEntries.Caption = "Loading Entries from Excel..."
                   ProgressPanel_SalesEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.SalesEntryB)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "SalesEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim PartyRef As String = GetString(reader, 0)
                                                   Dim InvoiceDate As Date = GetDate(reader, 1)
                                                   If PartyRef <> "" Then
                                                       Dim Party As Objects.Party = FindParty(PartyRef)
                                                       Dim InvoiceNo As String = GetString(reader, 2)
                                                       Dim InvoiceValue As Double = GetDouble(reader, 3)
                                                       Dim TaxableValue_5 As Integer = GetDouble(reader, 4)
                                                       Dim TaxableValue_12 As Double = GetDouble(reader, 5)
                                                       Dim TaxableValue_18 As Double = GetDouble(reader, 6)
                                                       Dim TaxableValue_28 As Double = GetDouble(reader, 7)
                                                       Dim ExemptedValue As Double = GetDouble(reader, 8)
                                                       Dim Discount As Double = GetDouble(reader, 9)
                                                       Dim StateCode As Integer = Utils.Settings.Load.StateCode
                                                       Try
                                                           Dim TmpSC_ As String = GetString(reader, 10)
                                                           If TmpSC_.Contains("-") Then
                                                               StateCode = CInt(TmpSC_.Split("-")(0).Trim)
                                                           Else
                                                               StateCode = CInt(TmpSC_)
                                                           End If
                                                       Catch ex1 As Exception
                                                           Try
                                                               If PartyRef <> "" Then
                                                                   StateCode = CInt(PartyRef.Substring(0, 2))
                                                               End If
                                                           Catch ex2 As Exception

                                                           End Try
                                                       End Try
                                                       Dim CustomSalesLedger As String = GetString(reader, 11)
                                                       R.Add(New Objects.SalesEntryB(Party, PartyRef, InvoiceDate, InvoiceNo, InvoiceValue, TaxableValue_5, TaxableValue_12, TaxableValue_18, TaxableValue_28, ExemptedValue, Discount, If(Party Is Nothing, Objects.State.GetStateByCode(StateCode), Party.State), CustomSalesLedger))
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

                   Try
                       If Utils.Settings.Load.CombineSales Then
                           gv_SalesEntries.Columns.Item("RegexInvoiceNo").Visible = True
                       Else
                           gv_SalesEntries.Columns.Item("RegexInvoiceNo").Visible = False
                       End If
                   Catch ex As Exception

                   End Try
               End Sub)
    End Function

    Async Function LoadSalesEntriesC(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_SalesEntries.Caption = "Loading Entries from Excel..."
                   ProgressPanel_SalesEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.SalesEntryC)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "SalesEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim InvoiceDate As Date = GetDate(reader, 0)
                                                   If InvoiceDate.Year > 1 Then
                                                       Dim InvoiceNo As String = GetString(reader, 1)
                                                       Dim InvoiceValue As Double = GetDouble(reader, 2)
                                                       Dim TaxableValue_5 As Integer = GetDouble(reader, 3)
                                                       Dim TaxableValue_12 As Double = GetDouble(reader, 4)
                                                       Dim TaxableValue_18 As Double = GetDouble(reader, 5)
                                                       Dim TaxableValue_28 As Double = GetDouble(reader, 6)
                                                       Dim ExemptedValue As Double = GetDouble(reader, 7)
                                                       Dim Discount As Double = GetDouble(reader, 8)
                                                       Dim BankCharges As Double = GetDouble(reader, 9)
                                                       Dim StateCode As Integer = Utils.Settings.Load.StateCode
                                                       Try
                                                           Dim TmpSC_ As String = GetString(reader, 10)
                                                           If TmpSC_.Contains("-") Then
                                                               StateCode = CInt(TmpSC_.Split("-")(0).Trim)
                                                           Else
                                                               StateCode = CInt(TmpSC_)
                                                           End If
                                                       Catch ex1 As Exception

                                                       End Try
                                                       Dim CustomBankLedger As String = GetString(reader, 11)
                                                       Dim CustomSalesLedger As String = GetString(reader, 12)
                                                       R.Add(New Objects.SalesEntryC(InvoiceDate, InvoiceNo, InvoiceValue, TaxableValue_5, TaxableValue_12, TaxableValue_18, TaxableValue_28, ExemptedValue, Discount, BankCharges, Objects.State.GetStateByCode(StateCode), CustomBankLedger, CustomSalesLedger))
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

    Async Function LoadBankEntries(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadExcel.Enabled = False
                   ProgressPanel_BankEntries.Caption = "Loading Entries from Excel..."
                   ProgressPanel_BankEntries.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.BankEntry)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "BankEntries" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim ValueDate As Date = GetDate(reader, 0)
                                                   If ValueDate <> Nothing Then
                                                       Dim Description As String = GetString(reader, 1)
                                                       Dim Ref As String = GetString(reader, 2)
                                                       Dim Withdrawal As Double = GetDouble(reader, 3)
                                                       Dim Deposit As Double = GetDouble(reader, 4)
                                                       Dim LedgerName As String = GetString(reader, 5)
                                                       R.Add(New Objects.BankEntry(ValueDate, Description, Ref, Withdrawal, Deposit, LedgerName))
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_BankEntries.DataSource = R
                                          gc_BankEntries.RefreshDataSource()
                                      End Sub)
                           Catch ex As Exception
                               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                               Return False
                           End Try
                           Return True
                       End Function)
        Invoke(Sub()
                   btn_LoadExcel.Enabled = True
                   ProgressPanel_BankEntries.Visible = False
               End Sub)
    End Function

    Private Async Function Export(ByVal XML As String, ByVal Filename As String) As Task
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
                MsgBox("Errors on Exporting XML to Tally..! XML Response Saved to Desktop.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End If
        End If
    End Function

    Async Function ExportParties(ByVal FileName As String) As Task
        Invoke(Sub()
                   RibbonControl.Enabled = False
                   ProgressPanel_Parties.Caption = String.Format("Exporting Entries to {0}...", If(FileName = "", "Tally", "File"))
                   ProgressPanel_Parties.Visible = True
               End Sub)
        Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
        Dim XML As String = XMLGen.GenerateMasters(gc_Parties.DataSource, TallyIO.Ledgers)
        Await Export(XML, FileName)
        Invoke(Sub()
                   RibbonControl.Enabled = True
                   ProgressPanel_Parties.Visible = False
               End Sub)
    End Function

    Async Function ExportPurchase(ByVal Filename As String) As Task
        Invoke(Sub()
                   RibbonControl.Enabled = False
                   ProgressPanel_PurchaseEntries.Caption = String.Format("Exporting Entries to {0}...", If(Filename = "", "Tally", "File"))
                   ProgressPanel_PurchaseEntries.Visible = True
               End Sub)
        Dim Vouchers As List(Of Objects.Voucher) = Tally.Converter.Purchase2Vouchers(gc_PurchaseEntries.DataSource)
        If CheckDependencies(Vouchers) Then
            Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
            Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
            Await Export(XML, Filename)
        End If
        Invoke(Sub()
                   RibbonControl.Enabled = True
                   ProgressPanel_PurchaseEntries.Visible = False
               End Sub)
    End Function

    Async Function ExportSales(ByVal Filename As String) As Task
        Invoke(Sub()
                   RibbonControl.Enabled = False
                   ProgressPanel_SalesEntries.Caption = String.Format("Exporting Entries to {0}...", If(Filename = "", "Tally", "File"))
                   ProgressPanel_SalesEntries.Visible = True
               End Sub)
        Dim Vouchers As List(Of Objects.Voucher) = If(Utils.Settings.Load.CombineSales, Tally.Converter.Sales2VouchersCombined(gc_SalesEntries.DataSource), Tally.Converter.Sales2Vouchers(gc_SalesEntries.DataSource))
        If CheckDependencies(Vouchers) Then
            Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
            Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
            Await Export(XML, Filename)
        End If
        Invoke(Sub()
                   RibbonControl.Enabled = True
                   ProgressPanel_SalesEntries.Visible = False
               End Sub)
    End Function

    Async Function ExportBank(ByVal Filename As String) As Task

        Invoke(Sub()
                   RibbonControl.Enabled = False
                   ProgressPanel_BankEntries.Caption = String.Format("Exporting Entries to {0}...", If(Filename = "", "Tally", "File"))
                   ProgressPanel_BankEntries.Visible = True
               End Sub)
        Try
            Dim Vouchers As List(Of Objects.Voucher) = Tally.Converter.Bank2Vouchers(gc_BankEntries.DataSource)
            If CheckDependencies(Vouchers) Then
                Dim XMLGen As New Tally.RequestXMLGenerator(txt_TallyVersion.EditValue, txt_CompanyName.EditValue)
                Dim XML As String = XMLGen.GenerateVouchers(Vouchers)
                Await Export(XML, Filename)
            End If
        Catch ex As Exception
            Invoke(Sub() MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error"))
        End Try
        Invoke(Sub()
                   RibbonControl.Enabled = True
                   ProgressPanel_BankEntries.Visible = False
               End Sub)

    End Function

    Async Sub ExportParties()
        Await ExportParties("")
    End Sub

    Async Sub ExportPurchase()
        Await ExportPurchase("")
    End Sub

    Async Sub ExportSales()
        Await ExportSales("")
    End Sub

    Async Sub ExportBank()
        Await ExportBank("")
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
                Await LoadSalesEntriesA(OpenFileDialog_Excel.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
                Await LoadBankEntries(OpenFileDialog_Excel.FileName)
            End If
        End If
    End Sub

    Private Async Sub btn_XML_File_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_XML_File.ItemClick
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            If gc_PurchaseEntries.DataSource Is Nothing Then
                MsgBox("Import purchase entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            SaveFileDialog_XML.FileName = "Purchase Entries.xml"
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            If gc_Parties.DataSource Is Nothing Then
                MsgBox("Import parties list from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            SaveFileDialog_XML.FileName = "Parties.xml"
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            If gc_SalesEntries.DataSource Is Nothing Then
                MsgBox("Import sales entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            SaveFileDialog_XML.FileName = "Sales Entries.xml"
        ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
            If gc_BankEntries.DataSource Is Nothing Then
                MsgBox("Import bank entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
            SaveFileDialog_XML.FileName = "Bank Entries.xml"
        End If
        If SaveFileDialog_XML.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                Await ExportPurchase(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                Await ExportParties(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
                Await ExportSales(SaveFileDialog_XML.FileName)
            ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
                Await ExportBank(SaveFileDialog_XML.FileName)
            End If
        End If
    End Sub

    Private Sub txt_TallyVersion_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyVersion.EditValueChanged
        Utils.Settings.Load.TallyVersion = txt_TallyVersion.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
        PictureBox_Logo.Visible = False
        btn_LoadExcel.ButtonStyle = BarButtonStyle.Default
        btn_LoadExcel.DropDownControl = Nothing
        If RibbonControl.SelectedPage Is rp_Tally Then
            PictureBox_Logo.Visible = True
        ElseIf RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            container_Tabs.SelectedTabPage = tp_PurchaseEntries
            chk_UseInvoice.EditValue = Utils.Settings.Load.UseInvoicePurchase
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            container_Tabs.SelectedTabPage = tp_Parties
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            container_Tabs.SelectedTabPage = tp_SalesEntries
            chk_UseInvoice.EditValue = Utils.Settings.Load.UseInvoiceSales

            btn_LoadExcel.ButtonStyle = BarButtonStyle.DropDown
            btn_LoadExcel.DropDownControl = menu_LoadExcel
        ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
            container_Tabs.SelectedTabPage = tp_BankEntries
        End If
    End Sub

    Private Sub container_Tabs_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles container_Tabs.SelectedPageChanged
        If container_Tabs.SelectedTabPage Is tp_PurchaseEntries Then
            RibbonControl.SelectedPage = rp_PurchaseEntries
        ElseIf container_Tabs.SelectedTabPage Is tp_Parties Then
            RibbonControl.SelectedPage = rp_Parties
        ElseIf container_Tabs.SelectedTabPage Is tp_SalesEntries Then
            RibbonControl.SelectedPage = rp_SalesEntries
        ElseIf container_Tabs.SelectedTabPage Is tp_BankEntries Then
            RibbonControl.SelectedPage = rp_BankEntries
        End If
    End Sub

    Private Sub btn_Settings_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Settings.ItemClick
        Dim D As New frm_Settings
        D.ShowDialog()
    End Sub

    Private Sub txt_TallyHost_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyHost.EditValueChanged
        Utils.Settings.Load.Host = txt_TallyHost.EditValue.ToString
        Utils.Settings.Load.Save()
    End Sub

    Private Sub txt_TallyPort_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TallyPort.EditValueChanged
        Try
            Utils.Settings.Load.Port = CInt(txt_TallyPort.EditValue)
            Utils.Settings.Load.Save()
        Catch ex As Exception
            MsgBox("Only Numeric Values are Allowed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Async Sub btn_Sync_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Sync.ItemClick
        Invoke(Sub()
                   btn_Sync.Enabled = False
                   ProgressPanel_Main.Caption = "Synchronizing with Tally..."
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
                       rp_BankEntries.Visible = True
                       rp_Parties.Visible = True
                   End If
               End Sub)
    End Sub

    Private Sub gv_Parties_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv_Parties.CustomDrawCell
        If e.Column.FieldName = "Name" Then
            Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)
            Dim row As Objects.Party = gv_Parties.GetRow(e.RowHandle)

            If cellInfo IsNot Nothing Then
                If TallyIO IsNot Nothing AndAlso TallyIO.Ledgers IsNot Nothing AndAlso TallyIO.Ledgers.Count > 0 AndAlso (TallyIO.Ledgers.Contains(row.GSTIN, StringComparer.OrdinalIgnoreCase) Or TallyIO.Ledgers.Contains(row.Name, StringComparer.OrdinalIgnoreCase)) Then
                    cellInfo.ViewInfo.ErrorIconText = "Ledger Already Exists." & If(Utils.Settings.Load.IgnoreDuplicateParties = True, " Will be Ignored.", "")
                    cellInfo.ViewInfo.ShowErrorIcon = True
                End If
            End If
        End If
    End Sub

    Private Sub gv_Entries_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv_PurchaseEntries.CustomDrawCell, gv_SalesEntries.CustomDrawCell
        If e.Column.FieldName = "PartyReference" Or e.Column.FieldName = "LedgerName" Then
            Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)
            Dim row As Object = sender.GetRow(e.RowHandle)

            If cellInfo IsNot Nothing Then
                If TallyIO IsNot Nothing AndAlso TallyIO.Ledgers IsNot Nothing AndAlso TallyIO.Ledgers.Count > 0 Then
                    If e.Column.FieldName = "PartyReference" Then
                        Dim Error_ As String = "-"
                        If row.Party Is Nothing And Not TallyIO.Ledgers.Contains(row.PartyReference, StringComparer.OrdinalIgnoreCase) Then
                            Error_ = "Unable to Find any Party Ledger Using This Reference & No Ledger Account Exist in this Name!"
                        End If
                        If Error_ = "-" And row.PartyReference.Length > 8 AndAlso (New System.Text.RegularExpressions.Regex("\d{2}\D{1}.*")).IsMatch(row.PartyReference) Then
                            If Not Utils.GSTINValidator.IsValid(row.PartyReference, Error_) Then
                                Error_ = "Invalid GSTIN!"
                            End If
                        End If
                        If Error_ <> "-" Then
                            cellInfo.ViewInfo.ErrorIconText = Error_
                            cellInfo.ViewInfo.ShowErrorIcon = True
                        End If
                    ElseIf e.Column.FieldName = "LedgerName" AndAlso Not TallyIO.Ledgers.Contains(row.LedgerName, StringComparer.OrdinalIgnoreCase) Then
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
        ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
            gc_BankEntries.RefreshDataSource()
        End If
    End Sub

    Private Sub btn_XML_Tally_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_XML_Tally.ItemClick
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            If gc_PurchaseEntries.DataSource Is Nothing Then
                MsgBox("Import purchase entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
        ElseIf RibbonControl.SelectedPage Is rp_Parties Then
            If gc_Parties.DataSource Is Nothing Then
                MsgBox("Import parties list from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            If gc_SalesEntries.DataSource Is Nothing Then
                MsgBox("Import sales entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
        ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
            If gc_BankEntries.DataSource Is Nothing Then
                MsgBox("Import bank entries from Excel before clicking export button", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                Exit Sub
            End If
        End If
        If MsgBox("Are You Sure to Export XML to Tally...?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
                ExportPurchase()
            ElseIf RibbonControl.SelectedPage Is rp_Parties Then
                ExportParties()
            ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
                ExportSales()
            ElseIf RibbonControl.SelectedPage Is rp_BankEntries Then
                ExportBank()
            End If
        End If
    End Sub

    Private Sub btn_Template_Parties_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_Parties.ItemClick
        SaveFileDialog_Excel.FileName = "Parties.xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.Parties, False)
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
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.PurchaseEntries, False)
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
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.SalesEntriesA, False)
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

    Private Sub txt_StateCode_EditValueChanged(sender As Object, e As EventArgs) Handles txt_StateCode.EditValueChanged
        Utils.Settings.Load.StateCode = txt_StateCode.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub btn_Template_BankEntries_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_BankEntries.ItemClick
        SaveFileDialog_Excel.FileName = "Bank Entries.xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.BankEntries, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub txt_BankLedgerName_EditValueChanged(sender As Object, e As EventArgs) Handles txt_BankLedgerName.EditValueChanged
        Utils.Settings.Load.BankLedgerName = txt_BankLedgerName.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub chk_IncludeDesc_EditValueChanged(sender As Object, e As EventArgs) Handles chk_IncludeDesc.EditValueChanged
        Utils.Settings.Load.IncludeDesc = chk_IncludeDesc.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub gv_BankEntries_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv_BankEntries.CustomDrawCell
        If e.Column.FieldName = "LedgerName" Then
            Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = TryCast(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)
            Dim row As Objects.BankEntry = gv_BankEntries.GetRow(e.RowHandle)

            If cellInfo IsNot Nothing Then
                If row.LedgerName.Contains(";") Then
                    Dim LedgerNames As String() = row.LedgerName.Split(";")
                    Dim MissingLedger As String = ""
                    For Each i As String In LedgerNames
                        Dim LedgerName As String = i.Split("=")(0).Trim
                        If Not TallyIO.Ledgers.Contains(LedgerName, StringComparer.OrdinalIgnoreCase) Then
                            If MissingLedger = "" Then
                                MissingLedger = LedgerName
                            Else
                                MissingLedger &= " And " & LedgerName
                            End If
                        End If
                    Next
                    If MissingLedger <> "" Then
                        cellInfo.ViewInfo.ErrorIconText = MissingLedger & " Ledger(s) Doesn't Exist in Tally Ledgers!"
                        cellInfo.ViewInfo.ShowErrorIcon = True
                    End If
                Else
                    If Not TallyIO.Ledgers.Contains(row.LedgerName, StringComparer.OrdinalIgnoreCase) Then
                        cellInfo.ViewInfo.ErrorIconText = "Ledger Doesn't Exist in Tally Ledgers!"
                        cellInfo.ViewInfo.ShowErrorIcon = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Async Sub btn_Template_Parties_WithData_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_Parties_WithData.ItemClick
        Invoke(Sub()
                   Ribbon.Enabled = False
                   ProgressPanel_Main.Caption = "Saving Template with Data..."
                   ProgressPanel_Main.Visible = True
               End Sub)
        If TallyIO Is Nothing OrElse TallyIO.Parties Is Nothing Then
            Invoke(Sub() MsgBox("Please Sync With Tally to Use this Function.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error"))
        ElseIf TallyIO.Parties.Count < 0 Then
            Invoke(Sub() MsgBox("No Parties Available to Export/Save to Excel Template.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error"))
        Else
            SaveFileDialog_Excel.FileName = "Parties.xlsx"
            If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
                Try
                    Await Task.Run(Sub()
                                       Tally.MiscFunctions.WriteParties2Excel(TallyIO.Parties, SaveFileDialog_Excel.FileName)
                                   End Sub)
                    Invoke(Sub() MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done"))
                Catch ex As Exception
                    Invoke(Sub() MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error"))
                End Try
            End If
        End If
        Invoke(Sub()
                   Ribbon.Enabled = True
                   ProgressPanel_Main.Visible = False
               End Sub)
    End Sub

    Private Sub chk_IgnoreDupParties_EditValueChanged(sender As Object, e As EventArgs) Handles chk_IgnoreDupParties.EditValueChanged
        Utils.Settings.Load.IgnoreDuplicateParties = chk_IgnoreDupParties.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub gv_PurchaseEntries_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_PurchaseEntries.CustomRowCellEditForEditing
        If e.Column.FieldName = "LedgerName" Then
            e.RepositoryItem = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit With {.DataSource = TallyIO.Ledgers}
        End If
    End Sub

    Private Sub gv_BankEntries_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_BankEntries.CustomRowCellEditForEditing
        If e.Column.FieldName = "LedgerName" AndAlso Not (e.CellValue.ToString.Contains("=") Or e.CellValue.ToString.Contains(";")) Then
            e.RepositoryItem = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit With {.DataSource = TallyIO.Ledgers}
        End If
    End Sub

    Private Sub gv_SalesEntries_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles gv_SalesEntries.CustomRowCellEditForEditing
        If e.Column.FieldName = "GSTIN" Then
            e.RepositoryItem = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit With {
                .DataSource = TallyIO.Parties,
                .ValueMember = "GSTIN",
                .DisplayMember = "GSTIN",
                .PopupWidth = 800
            }
        End If
    End Sub

    Private Sub chk_UseInvoice_EditValueChanged(sender As Object, e As EventArgs) Handles chk_UseInvoice.EditValueChanged
        If RibbonControl.SelectedPage Is rp_PurchaseEntries Then
            Utils.Settings.Load.UseInvoicePurchase = chk_UseInvoice.EditValue
            Utils.Settings.Load.Save()
        ElseIf RibbonControl.SelectedPage Is rp_SalesEntries Then
            Utils.Settings.Load.UseInvoiceSales = chk_UseInvoice.EditValue
            Utils.Settings.Load.Save()
        End If
    End Sub

    Private Sub chk_UseInvoiceNoTag_EditValueChanged(sender As Object, e As EventArgs) Handles chk_UseInvoiceNoTag.EditValueChanged
        Utils.Settings.Load.UseInvoiceNumberTag = chk_UseInvoiceNoTag.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub RibbonToolTipController_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles RibbonToolTipController.HyperlinkClick
        Try
            Process.Start(e.Link)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_CustomRequest_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_CustomRequest.ItemClick
        Dim D As New frm_CustomRequest(TallyIO)
        D.ShowDialog()
    End Sub

    Private Sub chk_TallyOldVersion_EditValueChanged(sender As Object, e As EventArgs) Handles chk_TallyOldVersion.EditValueChanged
        Utils.Settings.Load.TallyOldVersion = chk_TallyOldVersion.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Sub chk_CombineSales_EditValueChanged(sender As Object, e As EventArgs) Handles chk_CombineSales.EditValueChanged
        Utils.Settings.Load.CombineSales = chk_CombineSales.EditValue
        Utils.Settings.Load.Save()
    End Sub

    Private Async Sub btn_LoadExcel_TaxWise_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_LoadExcel_TaxWise.ItemClick
        If OpenFileDialog_Excel.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_SalesEntries Then
                Await LoadSalesEntriesB(OpenFileDialog_Excel.FileName)
            End If
        End If
    End Sub

    Private Sub btn_Template_SalesEntries_TaxWise_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_SalesEntries_TaxWise.ItemClick
        SaveFileDialog_Excel.FileName = "Sales Entries (Tax-Wise).xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.SalesEntriesB, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Async Sub btn_LoadExcel_TaxWise_Card_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_LoadExcel_TaxWise_Card.ItemClick
        If OpenFileDialog_Excel.ShowDialog = DialogResult.OK Then
            If RibbonControl.SelectedPage Is rp_SalesEntries Then
                Await LoadSalesEntriesC(OpenFileDialog_Excel.FileName)
            End If
        End If
    End Sub

    Private Sub btn_Template_SalesEntries_TaxWise_Card_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_Template_SalesEntries_TaxWise_Card.ItemClick
        SaveFileDialog_Excel.FileName = "Card Sales Entries (Tax-Wise).xlsx"
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, Templates.My.Resources.SalesEntriesC, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
        End If
    End Sub

    Private Sub txt_TaxType_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TaxType.EditValueChanged
        Utils.Settings.Load.TaxType = If(txt_TaxType.EditValue = "GST", 0, 1)
        Utils.Settings.Load.Save()
    End Sub
#End Region

End Class