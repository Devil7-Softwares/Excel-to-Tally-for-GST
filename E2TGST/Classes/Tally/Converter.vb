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

            For Each PurchaseEntry As Objects.PurchaseEntry In PurchaseEntries
                Dim PlaceOfSupply As Integer = 33
                Try
                    PlaceOfSupply = CInt(PurchaseEntry.GSTIN.Substring(0, 2))
                Catch ex As Exception

                End Try
                Dim ReceiverPlace As Integer = My.Settings.StateCode.Substring(0, 2)

                Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), PurchaseEntry.VoucherType)
                Dim Narration As String = String.Format("AS PER BILL NO.: {0}", PurchaseEntry.InvoiceNo)
                Dim Entries As New List(Of Objects.VoucherEntry)

                Dim IGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * PurchaseEntry.GSTRate / 100, PurchaseEntry.IGST), 2)
                Dim CGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, PurchaseEntry.CGST), 2)
                Dim SGST As Double = Math.Round(If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue * (PurchaseEntry.GSTRate / 2) / 100, PurchaseEntry.SGST), 2)
                Dim TotalValue_BR As Double = Math.Round(PurchaseEntry.TaxableValue + If(PlaceOfSupply = ReceiverPlace, CGST + SGST, IGST) + PurchaseEntry.CESS, 2)
                Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
                Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)

                Entries.Add(New Objects.VoucherEntry(PurchaseEntry.LedgerName, Enums.Effect.Dr, PurchaseEntry.TaxableValue)) ' Head - Eg. Purchase A/c or Expense A/c

                If PurchaseEntry.GSTRate > 0 Then
                    If PlaceOfSupply = ReceiverPlace Then
                        Dim CGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "CGST", PurchaseEntry.GSTRate / 2)
                        Dim SGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "SGST", PurchaseEntry.GSTRate / 2)

                        Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Dr, Math.Round(If(My.Settings.CalculateValues, CGST, PurchaseEntry.CGST), 2))) 'CGST
                        Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Dr, Math.Round(If(My.Settings.CalculateValues, SGST, PurchaseEntry.SGST), 2))) 'SGST
                    Else
                        Dim IGSTLedger As String = String.Format(My.Settings.TaxLedger, "Input", "IGST", PurchaseEntry.GSTRate)
                        Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Dr, If(My.Settings.CalculateValues, IGST, PurchaseEntry.IGST))) 'IGST
                    End If
                End If

                If PurchaseEntry.CESS > 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.CESSLedger, Enums.Effect.Dr, PurchaseEntry.CESS)) 'CESS
                End If

                If RoundingOff <> 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Dr, Enums.Effect.Cr), RoundingOff))
                End If

                Entries.Add(New Objects.VoucherEntry(PurchaseEntry.GSTIN, Enums.Effect.Cr, TotalValue_AR)) ' Purchase Party

                R.Add(New Objects.Voucher(VoucherType, PurchaseEntry.InvoiceDate, PurchaseEntry.InvoiceNo, Narration, Entries))
            Next

            Return R
        End Function

        Public Shared Function Sales2Vouchers(ByVal SalesEntries As List(Of Objects.SalesEntry)) As List(Of Objects.Voucher)
            Dim R As New List(Of Objects.Voucher)

            For Each SalesEntry As Objects.SalesEntry In SalesEntries
                Dim PlaceOfSupply As Integer = 33
                Try
                    PlaceOfSupply = CInt(SalesEntry.GSTIN.Substring(0, 2))
                Catch ex As Exception

                End Try
                Dim ReceiverPlace As Integer = My.Settings.StateCode.Substring(0, 2)

                Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), Enums.VoucherType.Sales)
                Dim Narration As String = String.Format("AS PER BILL NO.: {0}", SalesEntry.InvoiceNumber)
                Dim Entries As New List(Of Objects.VoucherEntry)

                Dim IGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * SalesEntry.Rate / 100, SalesEntry.IGST), 2)
                Dim CGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * (SalesEntry.Rate / 2) / 100, SalesEntry.CGST), 2)
                Dim SGST As Double = Math.Round(If(My.Settings.CalculateValues, SalesEntry.TaxableValue * (SalesEntry.Rate / 2) / 100, SalesEntry.SGST), 2)
                Dim TotalValue_BR As Double = Math.Round(SalesEntry.TaxableValue + If(PlaceOfSupply = ReceiverPlace, CGST + SGST, IGST) + SalesEntry.CESS, 2)
                Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
                Dim RoundingOff As Double = Math.Round(TotalValue_AR - TotalValue_BR, 2)

                Entries.Add(New Objects.VoucherEntry(SalesEntry.GSTIN, Enums.Effect.Dr, TotalValue_AR)) ' Sales Party
                Entries.Add(New Objects.VoucherEntry(If(SalesEntry.Rate = 0, "Sales Exempted", String.Format(My.Settings.SalesLedger, SalesEntry.Rate)), Enums.Effect.Cr, SalesEntry.TaxableValue)) ' Head - Eg. Sales A/c

                If SalesEntry.Rate > 0 Then
                    If PlaceOfSupply = ReceiverPlace Then
                        Dim CGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "CGST", SalesEntry.Rate / 2)
                        Dim SGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "SGST", SalesEntry.Rate / 2)

                        Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Cr, Math.Round(If(My.Settings.CalculateValues, CGST, SalesEntry.CGST), 2))) 'CGST
                        Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Cr, Math.Round(If(My.Settings.CalculateValues, SGST, SalesEntry.SGST), 2))) 'SGST
                    Else
                        Dim IGSTLedger As String = String.Format(My.Settings.TaxLedger, "Output", "IGST", SalesEntry.Rate)
                        Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Cr, If(My.Settings.CalculateValues, IGST, SalesEntry.IGST))) 'IGST
                    End If
                End If

                If SalesEntry.CESS > 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.CESSLedger, Enums.Effect.Cr, SalesEntry.CESS)) 'CESS
                End If

                If RoundingOff <> 0 Then
                    Entries.Add(New Objects.VoucherEntry(My.Settings.RoundOffLedger, If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
                End If

                R.Add(New Objects.Voucher(VoucherType, SalesEntry.InvoiceDate, SalesEntry.InvoiceNumber, Narration, Entries))
            Next

            Return R
        End Function
#End Region

    End Class
End Namespace