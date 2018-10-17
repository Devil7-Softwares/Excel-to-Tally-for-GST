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

Namespace Tally
    Public Class Converter

#Region "Functions"
        Public Shared Function Purchase2Vouchers(ByVal PurchaseEntries As List(Of Objects.PurchaseEntry)) As List(Of Objects.Voucher)
            Dim R As New List(Of Objects.Voucher)

            Dim Tmp As New List(Of Objects.PurchaseEntry)(PurchaseEntries)

            Do Until Tmp.Count = 0
                Dim TmpPurchaseEntries As New List(Of Objects.PurchaseEntry)
                Dim Entry1 As Objects.PurchaseEntry = Tmp(0)
                Tmp.RemoveAt(0)
                TmpPurchaseEntries.Add(Entry1)
                Dim MatchingEntries As List(Of Objects.PurchaseEntry) = Tmp.FindAll(Function(c)
                                                                                        Return c.GSTIN.Equals(Entry1.GSTIN, StringComparison.OrdinalIgnoreCase) _
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

                Dim PlaceOfSupply As Integer = My.Settings.StateCode
                Try
                    PlaceOfSupply = CInt(Entry1.GSTIN.Substring(0, 2))
                Catch ex As Exception

                End Try
                Dim ReceiverPlace As Integer = My.Settings.StateCode.Substring(0, 2)

                Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Entry1.VoucherType)
                Dim Narration As String = String.Format("AS PER BILL NO.: {0}", Entry1.InvoiceNo)
                Dim Entries As New List(Of Objects.VoucherEntry)

                Dim TotalValue_BR As Double = 0


                For Each PurchaseEntry As Objects.PurchaseEntry In TmpPurchaseEntries
                    Dim IGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * PurchaseEntry.GSTRate / 100, PurchaseEntry.IGST), 2)
                    Dim CGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, PurchaseEntry.CGST), 2)
                    Dim SGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, PurchaseEntry.SGST), 2)

                    TotalValue_BR = Math.Round(TotalValue_BR + PurchaseEntry.TaxableValue + If(PlaceOfSupply = ReceiverPlace, CGST + SGST, IGST) + PurchaseEntry.CESS, 2)

                    Entries.Add(New Objects.VoucherEntry(PurchaseEntry.LedgerName, Enums.Effect.Dr, PurchaseEntry.TaxableValue)) ' Head - Eg. Purchase A/c or Expense A/c

                    If PurchaseEntry.GSTRate > 0 Then
                        If PlaceOfSupply = ReceiverPlace Then
                            Dim CGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "CGST", PurchaseEntry.GSTRate / 2)
                            Dim SGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "SGST", PurchaseEntry.GSTRate / 2)

                            Dim ExistingCGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = CGSTLedger)
                            Dim ExistingSGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SGSTLedger)
                            If ExistingCGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Dr, Math.Round(If(My.Settings.CalculateValues, CGST, PurchaseEntry.CGST), 2))) 'CGST
                            Else
                                ExistingCGSTEntry.Amount = Math.Round(ExistingCGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, CGST, PurchaseEntry.CGST), 2), 2)
                            End If
                            If ExistingSGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Dr, Math.Round(If(My.Settings.CalculateValues, SGST, PurchaseEntry.SGST), 2))) 'SGST
                            Else
                                ExistingSGSTEntry.Amount = Math.Round(ExistingSGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, SGST, PurchaseEntry.SGST), 2), 2)
                            End If
                        Else
                            Dim IGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "IGST", PurchaseEntry.GSTRate)

                            Dim ExistingIGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = IGSTLedger)
                            If ExistingIGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Dr, Math.Round(If(My.Settings.CalculateValues, IGST, PurchaseEntry.IGST), 2))) 'IGST
                            Else
                                ExistingIGSTEntry.Amount = Math.Round(ExistingIGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, IGST, PurchaseEntry.IGST), 2), 2)
                            End If
                        End If
                    End If

                    If PurchaseEntry.CESS > 0 Then
                        Dim ExistingCESSEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = My.Settings.CESSLedger)
                        If ExistingCESSEntry Is Nothing Then
                            Entries.Add(New Objects.VoucherEntry(My.Settings.CESSLedger, Enums.Effect.Dr, Math.Round(PurchaseEntry.CESS, 2))) 'CESS
                        Else
                            ExistingCESSEntry.Amount = Math.Round(ExistingCESSEntry.Amount + Math.Round(PurchaseEntry.CESS, 2), 2)
                        End If
                    End If
                Next

                Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
                Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
                If RoundingOff <> 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Dr, Enums.Effect.Cr), RoundingOff))
                End If

                Entries.Add(New Objects.VoucherEntry(Entry1.GSTIN, Enums.Effect.Cr, TotalValue_AR)) ' Purchase Party

                R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, Entry1.InvoiceNo, Narration, Entries))
            Loop

            Return R
        End Function

        Public Shared Function Sales2Vouchers(ByVal SalesEntries As List(Of Objects.SalesEntry)) As List(Of Objects.Voucher)
            Dim R As New List(Of Objects.Voucher)

            Dim Tmp As New List(Of Objects.SalesEntry)(SalesEntries)

            Do Until Tmp.Count = 0
                Dim TmpSalesEntries As New List(Of Objects.SalesEntry)
                Dim Entry1 As Objects.SalesEntry = Tmp(0)
                Tmp.RemoveAt(0)
                TmpSalesEntries.Add(Entry1)
                Dim MatchingEntries As List(Of Objects.SalesEntry) = Tmp.FindAll(Function(c)
                                                                                     Return c.GSTIN.Equals(Entry1.GSTIN, StringComparison.OrdinalIgnoreCase) _
                                                                                And c.InvoiceDate.Equals(Entry1.InvoiceDate) _
                                                                                And c.InvoiceNo.Equals(Entry1.InvoiceNo, StringComparison.OrdinalIgnoreCase) _
                                                                                And c.InvoiceValue.Equals(Entry1.InvoiceValue)
                                                                                 End Function)
                If MatchingEntries IsNot Nothing AndAlso MatchingEntries.Count > 0 Then
                    For Each i As Objects.SalesEntry In MatchingEntries
                        Tmp.Remove(i)
                    Next
                    TmpSalesEntries.AddRange(MatchingEntries)
                End If

                Dim PlaceOfSupply As Integer = My.Settings.StateCode
                Try
                    PlaceOfSupply = CInt(Entry1.GSTIN.Substring(0, 2))
                Catch ex As Exception

                End Try
                Dim ReceiverPlace As Integer = My.Settings.StateCode.Substring(0, 2)

                Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
                Dim Narration As String = String.Format("AS PER BILL NO.: {0}", Entry1.InvoiceNo)
                Dim Entries As New List(Of Objects.VoucherEntry)

                Dim TotalValue_BR As Double = 0


                For Each SalesEntry As Objects.SalesEntry In TmpSalesEntries
                    Dim IGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * SalesEntry.GSTRate / 100, SalesEntry.IGST), 2)
                    Dim CGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * (SalesEntry.GSTRate / 2) / 100, SalesEntry.CGST), 2)
                    Dim SGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * (SalesEntry.GSTRate / 2) / 100, SalesEntry.SGST), 2)

                    TotalValue_BR = Math.Round(TotalValue_BR + SalesEntry.TaxableValue + If(PlaceOfSupply = ReceiverPlace, CGST + SGST, IGST) + SalesEntry.CESS, 2)

                    Dim SalesEntryLedgerName As String = If(SalesEntry.GSTRate = 0, "Sales Exempted", String.Format(My.Settings.SalesLedger, SalesEntry.GSTRate))
                    Dim ExistingSalesEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SalesEntryLedgerName)
                    If ExistingSalesEntry Is Nothing Then
                        Entries.Add(New Objects.VoucherEntry(SalesEntryLedgerName, Enums.Effect.Cr, SalesEntry.TaxableValue)) ' Head - Eg. Sales A/c
                    Else
                        ExistingSalesEntry.Amount = Math.Round(ExistingSalesEntry.Amount + SalesEntry.TaxableValue)
                    End If

                    If SalesEntry.GSTRate > 0 Then
                        If PlaceOfSupply = ReceiverPlace Then
                            Dim CGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "CGST", SalesEntry.GSTRate / 2)
                            Dim SGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "SGST", SalesEntry.GSTRate / 2)

                            Dim ExistingCGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = CGSTLedger)
                            Dim ExistingSGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = SGSTLedger)
                            If ExistingCGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Cr, Math.Round(If(My.Settings.CalculateValues, CGST, SalesEntry.CGST), 2))) 'CGST
                            Else
                                ExistingCGSTEntry.Amount = Math.Round(ExistingCGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, CGST, SalesEntry.CGST), 2), 2)
                            End If
                            If ExistingSGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Cr, Math.Round(If(My.Settings.CalculateValues, SGST, SalesEntry.SGST), 2))) 'SGST
                            Else
                                ExistingSGSTEntry.Amount = Math.Round(ExistingSGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, SGST, SalesEntry.SGST), 2), 2)
                            End If
                        Else
                            Dim IGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "IGST", SalesEntry.GSTRate)

                            Dim ExistingIGSTEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = IGSTLedger)
                            If ExistingIGSTEntry Is Nothing Then
                                Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Cr, Math.Round(If(My.Settings.CalculateValues, IGST, SalesEntry.IGST), 2))) 'IGST
                            Else
                                ExistingIGSTEntry.Amount = Math.Round(ExistingIGSTEntry.Amount + Math.Round(If(My.Settings.CalculateValues, IGST, SalesEntry.IGST), 2), 2)
                            End If
                        End If
                    End If

                    If SalesEntry.CESS > 0 Then
                        Dim ExistingCESSEntry As Objects.VoucherEntry = Entries.Find(Function(c) c.LedgerName = My.Settings.CESSLedger)
                        If ExistingCESSEntry Is Nothing Then
                            Entries.Add(New Objects.VoucherEntry(My.Settings.CESSLedger, Enums.Effect.Cr, Math.Round(SalesEntry.CESS, 2))) 'CESS
                        Else
                            ExistingCESSEntry.Amount = Math.Round(ExistingCESSEntry.Amount + Math.Round(SalesEntry.CESS, 2), 2)
                        End If
                    End If
                Next

                Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
                Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)
                If RoundingOff <> 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
                End If

                Entries.Insert(0, New Objects.VoucherEntry(Entry1.GSTIN, Enums.Effect.Dr, TotalValue_AR)) ' Sales Party

                R.Add(New Objects.Voucher(VoucherType, Entry1.InvoiceDate, Entry1.InvoiceNo, Narration, Entries))
            Loop

            Return R
        End Function

        Public Shared Function Bank2Vouchers(ByVal BankEntries As List(Of Objects.BankEntry)) As List(Of Objects.Voucher)
            Dim R As New List(Of Objects.Voucher)

            For Each BankEntry As Objects.BankEntry In BankEntries
                Dim VoucherType As Enums.VoucherType = Enums.VoucherType.Contra
                Dim BankEffect As Enums.Effect = If(BankEntry.Withdrawals <> 0, Enums.Effect.Cr, Enums.Effect.Dr)
                Dim Amount As Double = If(BankEntry.Withdrawals = 0, BankEntry.Deposits, BankEntry.Withdrawals)
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
                    Narration = "Cheque/Ref. No.: " & BankEntry.Ref
                End If
                If BankEntry.Description <> "" AndAlso My.Settings.IncludeDesc Then
                    Narration &= If(Narration = "", "", vbNewLine & vbNewLine) & BankEntry.Description
                End If

                Dim BankVoucherEntry As New Objects.VoucherEntry(My.Settings.BankLedgerName, BankEffect, Amount)
                Dim LedgerVoucherEntry As New Objects.VoucherEntry(BankEntry.LedgerName, If(BankEffect = Enums.Effect.Dr, Enums.Effect.Cr, Enums.Effect.Dr), Amount)
                Dim Entries As New List(Of Objects.VoucherEntry)
                If BankEffect = Enums.Effect.Dr Then
                    Entries.AddRange({BankVoucherEntry, LedgerVoucherEntry})
                Else
                    Entries.AddRange({LedgerVoucherEntry, BankVoucherEntry})
                End If
                R.Add(New Objects.Voucher([Enum].GetName(GetType(Enums.VoucherType), VoucherType), BankEntry.ValueDate, "", Narration.Trim, Entries))
            Next

            Return R
        End Function
#End Region

    End Class
End Namespace