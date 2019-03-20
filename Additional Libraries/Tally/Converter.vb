'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'                                                                          '
'=========================================================================='

Public Class Converter

#Region "Purchase Entries"
    Public Shared Function Purchase2Vouchers(ByVal PurchaseEntries As List(Of Objects.PurchaseEntry)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.PurchaseEntry)(PurchaseEntries)

        Do Until Tmp.Count = 0
            Dim TmpPurchaseEntries As New List(Of Objects.PurchaseEntry)
            Dim Entry1 As Objects.PurchaseEntry = Tmp(0)
            Tmp.RemoveAt(0)
            TmpPurchaseEntries.Add(Entry1)
            Dim MatchingEntries As List(Of Objects.PurchaseEntry) = Tmp.FindAll(Function(c)
                                                                                    Return (c.PartyReference.Replace(" ", "").Equals(Entry1.PartyReference.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) Or (c.Party IsNot Nothing AndAlso Entry1.Party IsNot Nothing AndAlso c.Party.Name.Equals(Entry1.Party.Name))) _
                                                                            And c.InvoiceDate.Equals(Entry1.InvoiceDate) _
                                                                            And c.InvoiceNo.Equals(Entry1.InvoiceNo, StringComparison.OrdinalIgnoreCase) _
                                                                            And c.InvoiceValue.Equals(Entry1.InvoiceValue) _
                                                                            And c.VoucherType.Equals(Entry1.VoucherType)
                                                                                End Function)
            If MatchingEntries IsNot Nothing AndAlso MatchingEntries.Count > 0 Then
                For Each i As Objects.PurchaseEntry In MatchingEntries
                    Tmp.Remove(i)
                Next
                TmpPurchaseEntries.AddRange(MatchingEntries)
            End If

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Entry1.VoucherType)
            Dim Narration As String = String.Format(Utils.Settings.Load.Narration, Entry1.InvoiceNo)
            Dim Entries As New List(Of Objects.VoucherEntry)

            For Each PurchaseEntry As Objects.PurchaseEntry In TmpPurchaseEntries
                Dim IGST As Double = Math.Round(PurchaseEntry.TaxableValue * PurchaseEntry.GSTRate / 100, 2)
                Dim CGST As Double = Math.Round(PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, 2)
                Dim SGST As Double = Math.Round(PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, 2)

                Entries.Add(New Objects.VoucherEntry(PurchaseEntry.LedgerName, Enums.Effect.Dr, Math.Round(PurchaseEntry.TaxableValue, 2))) ' Head - Eg. Purchase A/c or Expense A/c

                If PurchaseEntry.GSTRate > 0 Then
                    If PurchaseEntry.PlaceOfSupply.Code = Utils.Settings.Load.StateCode Then
                        Dim CGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Input", "CGST", PurchaseEntry.GSTRate / 2)
                        Dim SGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Input", "SGST", PurchaseEntry.GSTRate / 2)

                        Dim ExistingCGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = CGSTLedger)
                        Dim ExistingSGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SGSTLedger)
                        If ExistingCGSTEntry Is Nothing Then
                            Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Dr, Math.Round(CGST, 2))) 'CGST
                        Else
                            ExistingCGSTEntry.Amount = Math.Round(ExistingCGSTEntry.Amount + Math.Round(CGST, 2), 2)
                        End If
                        If ExistingSGSTEntry Is Nothing Then
                            Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Dr, Math.Round(SGST, 2))) 'SGST
                        Else
                            ExistingSGSTEntry.Amount = Math.Round(ExistingSGSTEntry.Amount + Math.Round(SGST, 2), 2)
                        End If
                    Else
                        Dim IGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Input", "IGST", PurchaseEntry.GSTRate)

                        Dim ExistingIGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = IGSTLedger)
                        If ExistingIGSTEntry Is Nothing Then
                            Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Dr, Math.Round(IGST, 2))) 'IGST
                        Else
                            ExistingIGSTEntry.Amount = Math.Round(ExistingIGSTEntry.Amount + Math.Round(IGST, 2), 2)
                        End If
                    End If
                End If

                If PurchaseEntry.CESS > 0 Then
                    Dim ExistingCESSEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = Utils.Settings.Load.CESSLedger)
                    If ExistingCESSEntry Is Nothing Then
                        Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.CESSLedger, Enums.Effect.Dr, Math.Round(PurchaseEntry.CESS, 2))) 'CESS
                    Else
                        ExistingCESSEntry.Amount = Math.Round(ExistingCESSEntry.Amount + Math.Round(PurchaseEntry.CESS, 2), 2)
                    End If
                End If
            Next

            Dim TotalValue_BR As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue_BR += i.Amount
            Next
            Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
            Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
            If RoundingOff <> 0 Then
                Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Dr, Enums.Effect.Cr), RoundingOff))
            End If

            Entries.Add(New Objects.VoucherEntry(If(Entry1.Party IsNot Nothing, Entry1.Party.Name, Entry1.PartyReference), Enums.Effect.Cr, TotalValue_AR)) ' Purchase Party

            If Entry1.VoucherType = Enums.VoucherType.DebitNote Then
                For Each i As Objects.VoucherEntry In Entries
                    i.Effect = If(i.Effect = Enums.Effect.Dr, Enums.Effect.Cr, Enums.Effect.Dr)
                Next
            End If

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, Entry1.InvoiceNo, Narration, Entries))
        Loop

        Return R
    End Function
#End Region

#Region "Sales Entries"
#Region "Common"
    Private Shared Sub AddSalesEntry(ByVal Entries As List(Of Objects.VoucherEntry), ByVal TaxableValue As Double, ByVal TaxRate As Double, ByVal PlaceOfSupply As Objects.State, ByVal CustomSalesLedger As String)
        Dim IGST As Double = TaxableValue * TaxRate / 100
        Dim CGST As Double = TaxableValue * (TaxRate / 2) / 100
        Dim SGST As Double = TaxableValue * (TaxRate / 2) / 100

        Dim SalesEntryLedgerName As String = If(CustomSalesLedger = "", If(TaxRate = 0, "Sales Exempted", String.Format(Utils.Settings.Load.SalesLedger, TaxRate)), CustomSalesLedger)
        Dim ExistingSalesEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SalesEntryLedgerName)
        If ExistingSalesEntry Is Nothing Then
            Entries.Add(New Objects.VoucherEntry(SalesEntryLedgerName, Enums.Effect.Cr, Math.Round(TaxableValue, 2)))
        Else
            ExistingSalesEntry.Amount = Math.Round(ExistingSalesEntry.Amount + Math.Round(TaxableValue, 2))
        End If

        If TaxRate > 0 Then
            If PlaceOfSupply.Code = Utils.Settings.Load.StateCode Then
                Dim CGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Output", "CGST", TaxRate / 2)
                Dim SGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Output", "SGST", TaxRate / 2)

                Dim ExistingCGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = CGSTLedger)
                Dim ExistingSGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SGSTLedger)
                If ExistingCGSTEntry Is Nothing Then
                    Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Cr, Math.Round(CGST, 2))) 'CGST
                Else
                    ExistingCGSTEntry.Amount = Math.Round(ExistingCGSTEntry.Amount + Math.Round(CGST, 2), 2)
                End If
                If ExistingSGSTEntry Is Nothing Then
                    Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Cr, Math.Round(SGST, 2))) 'SGST
                Else
                    ExistingSGSTEntry.Amount = Math.Round(ExistingSGSTEntry.Amount + Math.Round(SGST, 2), 2)
                End If
            Else
                Dim IGSTLedger As String = String.Format(Utils.Settings.Load.TaxLedger, "Output", "IGST", TaxRate)

                Dim ExistingIGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = IGSTLedger)
                If ExistingIGSTEntry Is Nothing Then
                    Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Cr, Math.Round(IGST, 2))) 'IGST
                Else
                    ExistingIGSTEntry.Amount = Math.Round(ExistingIGSTEntry.Amount + Math.Round(IGST, 2), 2)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Sales Entry A"
    Public Shared Function Sales2VouchersCombined(ByVal SalesEntries As List(Of Objects.SalesEntryA)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.SalesEntryA)(SalesEntries)
        Dim RegEx As New System.Text.RegularExpressions.Regex(Utils.Settings.Load.InvoiceNoRegex)

        Do Until Tmp.Count = 0
            Dim TmpSalesEntries As New List(Of Objects.SalesEntryA)
            Dim Entry1 As Objects.SalesEntryA = Tmp(0)
            Tmp.RemoveAt(0)
            TmpSalesEntries.Add(Entry1)

            Dim CurrentInvoiceNo As Integer = RegEx.Match(Entry1.InvoiceNo).Groups("invoice").Value
            Dim StartInvoiceNo As String = Entry1.InvoiceNo
            Dim EndInvoiceNo As String = Entry1.InvoiceNo

            For i As Integer = 0 To Tmp.Count - 1
                CurrentInvoiceNo += 1
                Dim Entry2 As Objects.SalesEntryA = Tmp(i)
                Dim InvoiceNo As Integer = RegEx.Match(Entry2.InvoiceNo).Groups("invoice").Value

                If Entry1.InvoiceDate.Equals(Entry2.InvoiceDate) AndAlso Entry1.PartyReference.Trim.Equals(Entry2.PartyReference.Trim, StringComparison.OrdinalIgnoreCase) AndAlso InvoiceNo = CurrentInvoiceNo Then
                    TmpSalesEntries.Add(Entry2)
                    EndInvoiceNo = Entry2.InvoiceNo
                Else
                    Exit For
                End If
            Next

            For Each i As Objects.SalesEntryA In TmpSalesEntries
                Tmp.Remove(i)
            Next

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
            Dim VoucherRef As String = If(TmpSalesEntries.Count > 1, String.Format("{0} to {1}", StartInvoiceNo, EndInvoiceNo), Entry1.InvoiceNo)
            Dim Narration As String = String.Format("AS PER BILL NO{0}.: {1}", If(TmpSalesEntries.Count > 1, "s", ""), VoucherRef)
            Dim Entries As New List(Of Objects.VoucherEntry)

            For Each SalesEntry As Objects.SalesEntryA In TmpSalesEntries
                AddSalesEntry(Entries, SalesEntry.TaxableValue, SalesEntry.GSTRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)

                If SalesEntry.CESS > 0 Then
                    Dim ExistingCESSEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = Utils.Settings.Load.CESSLedger)
                    If ExistingCESSEntry Is Nothing Then
                        Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.CESSLedger, Enums.Effect.Cr, Math.Round(SalesEntry.CESS, 2))) 'CESS
                    Else
                        ExistingCESSEntry.Amount = Math.Round(ExistingCESSEntry.Amount + Math.Round(SalesEntry.CESS, 2), 2)
                    End If
                End If
            Next

            Dim TotalValue_BR As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue_BR += i.Amount
            Next
            Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
            Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
            If RoundingOff <> 0 Then
                Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
            End If

            Entries.Insert(0, New Objects.VoucherEntry(If(Entry1.Party IsNot Nothing, Entry1.Party.Name, Entry1.PartyReference), Enums.Effect.Dr, TotalValue_AR)) ' Sales Party

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, VoucherRef, Narration, Entries))
        Loop

        Return R
    End Function

    Public Shared Function Sales2Vouchers(ByVal SalesEntries As List(Of Objects.SalesEntryA)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.SalesEntryA)(SalesEntries)

        Do Until Tmp.Count = 0
            Dim TmpSalesEntries As New List(Of Objects.SalesEntryA)
            Dim Entry1 As Objects.SalesEntryA = Tmp(0)
            Tmp.RemoveAt(0)
            TmpSalesEntries.Add(Entry1)
            Dim MatchingEntries As List(Of Objects.SalesEntryA) = Tmp.FindAll(Function(c)
                                                                                  Return (c.PartyReference.Replace(" ", "").Equals(Entry1.PartyReference.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) Or (c.Party IsNot Nothing AndAlso Entry1.Party IsNot Nothing AndAlso c.Party.Name.Equals(Entry1.Party.Name))) _
                                                                            And c.InvoiceDate.Equals(Entry1.InvoiceDate) _
                                                                            And c.InvoiceNo.Equals(Entry1.InvoiceNo, StringComparison.OrdinalIgnoreCase) _
                                                                            And c.InvoiceValue.Equals(Entry1.InvoiceValue)
                                                                              End Function)
            If MatchingEntries IsNot Nothing AndAlso MatchingEntries.Count > 0 Then
                For Each i As Objects.SalesEntryA In MatchingEntries
                    Tmp.Remove(i)
                Next
                TmpSalesEntries.AddRange(MatchingEntries)
            End If

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
            Dim Narration As String = String.Format(Utils.Settings.Load.Narration, Entry1.InvoiceNo)
            Dim Entries As New List(Of Objects.VoucherEntry)

            For Each SalesEntry As Objects.SalesEntryA In TmpSalesEntries
                AddSalesEntry(Entries, SalesEntry.TaxableValue, SalesEntry.GSTRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)

                If SalesEntry.CESS > 0 Then
                    Dim ExistingCESSEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = Utils.Settings.Load.CESSLedger)
                    If ExistingCESSEntry Is Nothing Then
                        Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.CESSLedger, Enums.Effect.Cr, Math.Round(SalesEntry.CESS, 2))) 'CESS
                    Else
                        ExistingCESSEntry.Amount = Math.Round(ExistingCESSEntry.Amount + Math.Round(SalesEntry.CESS, 2), 2)
                    End If
                End If
            Next

            Dim TotalValue_BR As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue_BR += i.Amount
            Next
            Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
            Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
            If RoundingOff <> 0 Then
                Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
            End If

            Entries.Insert(0, New Objects.VoucherEntry(If(Entry1.Party IsNot Nothing, Entry1.Party.Name, Entry1.PartyReference), Enums.Effect.Dr, TotalValue_AR)) ' Sales Party

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, Entry1.InvoiceNo, Narration, Entries))
        Loop

        Return R
    End Function
#End Region

#Region "Sales Entry B"
    Public Shared Function Sales2VouchersCombined(ByVal SalesEntries As List(Of Objects.SalesEntryB)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.SalesEntryB)(SalesEntries)
        Dim RegEx As New System.Text.RegularExpressions.Regex(Utils.Settings.Load.InvoiceNoRegex)

        Do Until Tmp.Count = 0
            Dim TmpSalesEntries As New List(Of Objects.SalesEntryB)
            Dim Entry1 As Objects.SalesEntryB = Tmp(0)
            Tmp.RemoveAt(0)
            TmpSalesEntries.Add(Entry1)

            Dim CurrentInvoiceNo As Integer = RegEx.Match(Entry1.InvoiceNo).Groups("invoice").Value
            Dim StartInvoiceNo As String = Entry1.InvoiceNo
            Dim EndInvoiceNo As String = Entry1.InvoiceNo

            For i As Integer = 0 To Tmp.Count - 1
                CurrentInvoiceNo += 1
                Dim Entry2 As Objects.SalesEntryB = Tmp(i)
                Dim InvoiceNo As Integer = RegEx.Match(Entry2.InvoiceNo).Groups("invoice").Value

                If Entry1.InvoiceDate.Equals(Entry2.InvoiceDate) AndAlso Entry1.PartyReference.Trim.Equals(Entry2.PartyReference.Trim, StringComparison.OrdinalIgnoreCase) AndAlso InvoiceNo = CurrentInvoiceNo Then
                    TmpSalesEntries.Add(Entry2)
                    EndInvoiceNo = Entry2.InvoiceNo
                Else
                    Exit For
                End If
            Next

            For Each i As Objects.SalesEntryB In TmpSalesEntries
                Tmp.Remove(i)
            Next

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
            Dim VoucherRef As String = If(TmpSalesEntries.Count > 1, String.Format("{0} to {1}", StartInvoiceNo, EndInvoiceNo), Entry1.InvoiceNo)
            Dim Narration As String = String.Format("AS PER BILL NO{0}.: {1}", If(TmpSalesEntries.Count > 1, "s", ""), VoucherRef)
            Dim Entries As New List(Of Objects.VoucherEntry)
            Dim Discount As Double = 0

            For Each SalesEntry As Objects.SalesEntryB In TmpSalesEntries
                If SalesEntry.ExemptedValue > 0 Then
                    AddSalesEntry(Entries, SalesEntry.ExemptedValue, Utils.Settings.Load.TaxWiseExemptedRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_5 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_5, Utils.Settings.Load.TaxWiseFiveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_12 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_12, Utils.Settings.Load.TaxWiseTwelveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_18 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_18, Utils.Settings.Load.TaxWiseEighteenRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_28 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_28, Utils.Settings.Load.TaxWiseTwentyEightRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                Discount += SalesEntry.Discount
            Next

            Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.DiscountLedger, If(Discount > 0, Enums.Effect.Cr, Enums.Effect.Dr), Discount)) 'Discount

            Dim TotalValue_BR As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue_BR += i.Amount
            Next
            Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
            Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
            If RoundingOff <> 0 Then
                Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
            End If

            Entries.Insert(0, New Objects.VoucherEntry(If(Entry1.Party IsNot Nothing, Entry1.Party.Name, Entry1.PartyReference), Enums.Effect.Dr, TotalValue_AR)) ' Sales Party

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, VoucherRef, Narration, Entries))
        Loop

        Return R
    End Function

    Public Shared Function Sales2Vouchers(ByVal SalesEntries As List(Of Objects.SalesEntryB)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.SalesEntryB)(SalesEntries)

        Do Until Tmp.Count = 0
            Dim TmpSalesEntries As New List(Of Objects.SalesEntryB)
            Dim Entry1 As Objects.SalesEntryB = Tmp(0)
            Tmp.RemoveAt(0)
            TmpSalesEntries.Add(Entry1)
            Dim MatchingEntries As List(Of Objects.SalesEntryB) = Tmp.FindAll(Function(c)
                                                                                  Return (c.PartyReference.Replace(" ", "").Equals(Entry1.PartyReference.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) Or (c.Party IsNot Nothing AndAlso Entry1.Party IsNot Nothing AndAlso c.Party.Name.Equals(Entry1.Party.Name))) _
                                                                            And c.InvoiceDate.Equals(Entry1.InvoiceDate) _
                                                                            And c.InvoiceNo.Equals(Entry1.InvoiceNo, StringComparison.OrdinalIgnoreCase) _
                                                                            And c.InvoiceValue.Equals(Entry1.InvoiceValue)
                                                                              End Function)
            If MatchingEntries IsNot Nothing AndAlso MatchingEntries.Count > 0 Then
                For Each i As Objects.SalesEntryB In MatchingEntries
                    Tmp.Remove(i)
                Next
                TmpSalesEntries.AddRange(MatchingEntries)
            End If

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
            Dim Narration As String = String.Format(Utils.Settings.Load.Narration, Entry1.InvoiceNo)
            Dim Entries As New List(Of Objects.VoucherEntry)
            Dim Discount As Double = 0

            For Each SalesEntry As Objects.SalesEntryB In TmpSalesEntries
                If SalesEntry.ExemptedValue > 0 Then
                    AddSalesEntry(Entries, SalesEntry.ExemptedValue, Utils.Settings.Load.TaxWiseExemptedRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_5 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_5, Utils.Settings.Load.TaxWiseFiveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_12 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_12, Utils.Settings.Load.TaxWiseTwelveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_18 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_18, Utils.Settings.Load.TaxWiseEighteenRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_28 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_28, Utils.Settings.Load.TaxWiseTwentyEightRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                Discount += SalesEntry.Discount
            Next

            Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.DiscountLedger, If(Discount > 0, Enums.Effect.Cr, Enums.Effect.Dr), Discount)) 'Discount

            Dim TotalValue_BR As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue_BR += i.Amount
            Next
            Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
            Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
            If RoundingOff <> 0 Then
                Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
            End If

            Entries.Insert(0, New Objects.VoucherEntry(If(Entry1.Party IsNot Nothing, Entry1.Party.Name, Entry1.PartyReference), Enums.Effect.Dr, TotalValue_AR)) ' Sales Party

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, Entry1.InvoiceNo, Narration, Entries))
        Loop

        Return R
    End Function
#End Region

#Region "Sales Entry C"
    Public Shared Function Sales2VouchersCombined(ByVal SalesEntries As List(Of Objects.SalesEntryC)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        ' Combined Entries Not Supported for SalesEntryC

        Return R
    End Function

    Public Shared Function Sales2Vouchers(ByVal SalesEntries As List(Of Objects.SalesEntryC)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        Dim Tmp As New List(Of Objects.SalesEntryC)(SalesEntries)

        Do Until Tmp.Count = 0
            Dim Entry1 As Objects.SalesEntryC = Tmp(0)
            Tmp.RemoveAt(0)

            Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
            Dim Narration As String = String.Format(Utils.Settings.Load.Narration, Entry1.InvoiceNo)
            Dim Entries As New List(Of Objects.VoucherEntry)
            Dim Discount As Double = 0

            Dim TmpSalesEntries As New List(Of Objects.SalesEntryC)
            If Not Utils.Settings.Load.DontJoinCardSales Then TmpSalesEntries.AddRange(Tmp.FindAll(Function(c) c.InvoiceDate = Entry1.InvoiceDate And c.InvoiceNo = Entry1.InvoiceNo And c.InvoiceValue = Entry1.InvoiceValue))
            TmpSalesEntries.Add(Entry1)

            For Each SalesEntry As Objects.SalesEntryC In TmpSalesEntries
                Tmp.Remove(SalesEntry)

                If SalesEntry.ExemptedValue > 0 Then
                    AddSalesEntry(Entries, SalesEntry.ExemptedValue, Utils.Settings.Load.TaxWiseExemptedRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_5 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_5, Utils.Settings.Load.TaxWiseFiveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_12 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_12, Utils.Settings.Load.TaxWiseTwelveRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_18 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_18, Utils.Settings.Load.TaxWiseEighteenRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                If SalesEntry.TaxableValue_28 > 0 Then
                    AddSalesEntry(Entries, SalesEntry.TaxableValue_28, Utils.Settings.Load.TaxWiseTwentyEightRate, SalesEntry.PlaceOfSupply, SalesEntry.CustomSalesLedger)
                End If

                Discount += SalesEntry.Discount
            Next

            Entries.Add(New Objects.VoucherEntry(Utils.Settings.Load.DiscountLedger, If(Discount > 0, Enums.Effect.Cr, Enums.Effect.Dr), Discount)) 'Discount

            Dim TotalValue As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                TotalValue += i.Amount
            Next

            Entries.Insert(0, New Objects.VoucherEntry(Utils.Settings.Load.CardSalesLedger, Enums.Effect.Dr, Math.Round(TotalValue, 2))) ' Sales Party

            R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, "", Narration, Entries))

            Dim CardSales2Bank As New List(Of Objects.VoucherEntry)
            CardSales2Bank.Add(New Objects.VoucherEntry(If(Entry1.CustomBankLedger <> "", Entry1.CustomBankLedger, Utils.Settings.Load.BankLedgerName), Enums.Effect.Dr, Math.Round(Math.Round(TotalValue, 2) - Math.Round(Entry1.BankCharges, 2), 2)))
            CardSales2Bank.Add(New Objects.VoucherEntry(Utils.Settings.Load.BankChargesLedger, Enums.Effect.Dr, Math.Round(Entry1.BankCharges, 2)))
            CardSales2Bank.Add(New Objects.VoucherEntry(Utils.Settings.Load.CardSalesLedger, Enums.Effect.Cr, Math.Round(TotalValue, 2)))

            R.Add(New Objects.Voucher([Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Receipt), Entry1.InvoiceDate, "", "", CardSales2Bank))
        Loop

        Return R
    End Function
#End Region
#End Region

#Region "Bank Entries"
    Public Shared Function Bank2Vouchers(ByVal BankEntries As List(Of Objects.BankEntry)) As List(Of Objects.Voucher)
        Dim R As New List(Of Objects.Voucher)

        For Each BankEntry As Objects.BankEntry In BankEntries
            Dim VoucherType As Enums.VoucherType = Enums.VoucherType.Contra
            Dim BankEffect As Enums.Effect = If(BankEntry.Withdrawals <> 0, Enums.Effect.Cr, Enums.Effect.Dr)
            Dim TotalAmount As Double = If(BankEntry.Withdrawals = 0, BankEntry.Deposits, BankEntry.Withdrawals)
            If BankEntry.LedgerName = "Cash" Or BankEntry.LedgerName.ToUpper.Contains("CASH") Then
                VoucherType = Enums.VoucherType.Contra
            Else
                If BankEntry.Withdrawals = 0 Then
                    VoucherType = Enums.VoucherType.Receipt
                Else
                    VoucherType = Enums.VoucherType.Payment
                End If
            End If
            Dim Narration As String = ""
            If BankEntry.Ref <> "" Then
                Narration = $"Cheque/Ref. No.: {BankEntry.Ref}"
            End If
            If BankEntry.Description <> "" AndAlso Utils.Settings.Load.IncludeDesc Then
                Narration &= If(Narration = "", "", vbNewLine & vbNewLine) & BankEntry.Description
            End If

            Dim BankVoucherEntry As New Objects.VoucherEntry(Utils.Settings.Load.BankLedgerName, BankEffect, TotalAmount)
            Dim Entries As New List(Of Objects.VoucherEntry)
            If BankEntry.LedgerName.Contains(";") AndAlso BankEntry.LedgerName.Contains("=") Then
                For Each TmpLedgerName As String In BankEntry.LedgerName.Split(";")
                    Dim LedgerName As String = TmpLedgerName.Split("=")(0).Trim
                    Dim Amount As Double = 0
                    Try
                        Amount = Double.Parse(TmpLedgerName.Split("=")(1).Trim)
                    Catch ex As Exception

                    End Try
                    Entries.Add(New Objects.VoucherEntry(LedgerName, If(BankEffect = Enums.Effect.Dr, Enums.Effect.Cr, Enums.Effect.Dr), Amount))
                Next
            Else
                Entries.Add(New Objects.VoucherEntry(BankEntry.LedgerName, If(BankEffect = Enums.Effect.Dr, Enums.Effect.Cr, Enums.Effect.Dr), TotalAmount))
            End If
            If BankEffect = Enums.Effect.Dr Then
                Entries.Insert(0, BankVoucherEntry)
            Else
                Entries.Add(BankVoucherEntry)
            End If
            Dim Cr As Double = 0
            Dim Dr As Double = 0
            For Each i As Objects.VoucherEntry In Entries
                If i.Effect = Enums.Effect.Dr Then
                    Dr += i.Amount
                Else
                    Cr += i.Amount
                End If
            Next
            If Not Dr.Equals(Cr) Then
                Throw New Exception(String.Format("Debit & Credit Amount Not Matching in Entry Dated {0} and Rs.{1} {2}.", BankEntry.ValueDate.ToString("dd-MM-yyyy"), TotalAmount.ToString, If(BankEffect = Enums.Effect.Dr, "Deposited", "Withdrawn")))
            End If
            R.Add(New Objects.Voucher([Enum].GetName(GetType(Enums.VoucherType), VoucherType), BankEntry.ValueDate, "", Narration.Trim, Entries))
        Next

        Return R
    End Function
#End Region

End Class