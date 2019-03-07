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

Imports System.ComponentModel

Public Class SalesEntryC

#Region "Properties/Fields"

    <DisplayName("Invoice Date")>
    Property InvoiceDate As Date

    <DisplayName("Invoice Number")>
    Property InvoiceNo As String

    <DisplayName("Invoice Value")>
    Property InvoiceValue As Double

    <DisplayName("Taxable Value @ 5%")>
    Property TaxableValue_5 As Double

    <DisplayName("Taxable Value @ 5%")>
    Property TaxableValue_12 As Double

    <DisplayName("Taxable Value @ 5%")>
    Property TaxableValue_18 As Double

    <DisplayName("Taxable Value @ 5%")>
    Property TaxableValue_28 As Double

    <DisplayName("Exempted Value")>
    Property ExemptedValue As Double

    Property Discount As Double

    <DisplayName("Bank Charges")>
    Property BankCharges As Double

    <DisplayName("Place Of Supply")>
    Property PlaceOfSupply As State

    <DisplayName("Custom Bank Ledger Name")>
    Property CustomBankLedger As String

    <DisplayName("Custom Sales Ledger Name")>
    Property CustomSalesLedger As String
#End Region

#Region "Constructors"
    Sub New()
        Me.InvoiceDate = Now
        Me.InvoiceNo = ""
        Me.InvoiceValue = 0
        Me.TaxableValue_5 = 0
        Me.TaxableValue_12 = 0
        Me.TaxableValue_18 = 0
        Me.TaxableValue_28 = 0
        Me.ExemptedValue = 0
        Me.Discount = 0
        Me.BankCharges = 0
        Me.PlaceOfSupply = State.GetStateByCode(Utils.Settings.Load.StateCode)
        Me.CustomSalesLedger = ""
        Me.CustomBankLedger = ""
    End Sub

    Sub New(ByVal InvoiceDate As Date, ByVal InvoiceNo As String, ByVal InvoiceValue As Double,
            ByVal TaxableValue_5 As Double, ByVal TaxableValue_12 As Double,
            ByVal TaxableValue_18 As Double, ByVal TaxableValue_28 As Double,
            ByVal ExemptedValue As Double, ByVal Discount As Double, ByVal BankCharges As Double,
            ByVal PlaceOfSupply As State, ByVal CustomBankLedger As String,
            ByVal CustomSalesLedger As String)
        Me.InvoiceDate = InvoiceDate
        Me.InvoiceNo = InvoiceNo
        Me.InvoiceValue = InvoiceValue
        Me.TaxableValue_5 = TaxableValue_5
        Me.TaxableValue_12 = TaxableValue_12
        Me.TaxableValue_18 = TaxableValue_18
        Me.TaxableValue_28 = TaxableValue_28
        Me.ExemptedValue = ExemptedValue
        Me.Discount = Discount
        Me.BankCharges = BankCharges
        Me.PlaceOfSupply = PlaceOfSupply
        Me.CustomSalesLedger = CustomSalesLedger
        Me.CustomBankLedger = CustomBankLedger
    End Sub
#End Region

End Class