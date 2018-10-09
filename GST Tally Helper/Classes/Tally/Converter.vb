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

        Public Shared Function Purchase2Vouchers(ByVal PurchaseEntries As List(Of Objects.PurchaseEntry)) As List(Of Objects.Voucher)
            Dim R As New List(Of Objects.Voucher)

            For Each PurchaseEntry As Objects.PurchaseEntry In PurchaseEntries
                Dim VoucherType As String = [Enum].GetName(GetType(Enums.VoucherType), PurchaseEntry.VoucherType)
                Dim Narration As String = String.Format("AS PER BILL NO.: {0}", PurchaseEntry.InvoiceNo)
                Dim Entries As New List(Of Objects.VoucherEntry)

                Dim Tax As Double = PurchaseEntry.TaxableValue * PurchaseEntry.GSTRate / 100
                Dim TotalValue_BR As Double = If(My.Settings.CalculateValues, PurchaseEntry.TaxableValue + Tax + PurchaseEntry.CESS, PurchaseEntry.InvoiceValue)
                Dim TotalValue_AR As Double = Math.Round(TotalValue_BR)
                Dim RoundingOff As Double = TotalValue_AR - TotalValue_BR

                Entries.Add(New Objects.VoucherEntry(PurchaseEntry.LedgerName, Enums.Effect.Dr, TotalValue_AR)) ' Head - Eg. Purchase A/c or Expense A/c
                Entries.Add(New Objects.VoucherEntry(PurchaseEntry.GSTIN, Enums.Effect.Cr, PurchaseEntry.TaxableValue)) ' Purchase Party

                If PurchaseEntry.GSTRate > 0 AndAlso My.Settings.GSTIN <> "" AndAlso Tax > 0 Then
                    Dim PlaceOfSupply As Integer = 33 ' Should be removed
                    Dim ReceiverPlace As Integer = My.Settings.GSTIN.Substring(0, 2)

                    If PlaceOfSupply = ReceiverPlace Then
                        Dim CGSTLedger As String = String.Format("CGST @ {0}%", PurchaseEntry.GSTRate / 2)
                        Dim SGSTLedger As String = String.Format("SGST @ {0}%", PurchaseEntry.GSTRate / 2)

                        Entries.Add(New Objects.VoucherEntry(CGSTLedger, Enums.Effect.Cr, If(My.Settings.CalculateValues, Tax / 2, PurchaseEntry.CGST))) 'CGST
                        Entries.Add(New Objects.VoucherEntry(SGSTLedger, Enums.Effect.Cr, If(My.Settings.CalculateValues, Tax / 2, PurchaseEntry.SGST))) 'SGST
                    Else
                        Dim IGSTLedger As String = String.Format("IGST @ {0}%", PurchaseEntry.GSTRate)
                        Entries.Add(New Objects.VoucherEntry(IGSTLedger, Enums.Effect.Cr, If(My.Settings.CalculateValues, Tax, PurchaseEntry.IGST))) 'IGST
                    End If
                End If

                If PurchaseEntry.CESS > 0 Then
                    Entries.Add(New Objects.VoucherEntry("CESS", Enums.Effect.Cr, PurchaseEntry.CESS)) 'CESS
                End If

                If RoundingOff <> 0 Then
                    Entries.Add(New Objects.VoucherEntry("Rounding Off", If(RoundingOff > 0, Enums.Effect.Cr, Enums.Effect.Dr), RoundingOff))
                End If

                R.Add(New Objects.Voucher(VoucherType, PurchaseEntry.InvoiceDate, PurchaseEntry.InvoiceNo, Narration, Entries))
            Next

            Return R
        End Function

    End Class
End Namespace