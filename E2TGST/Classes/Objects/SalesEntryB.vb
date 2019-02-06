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

Namespace Objects
    Public Class SalesEntryB

#Region "Properties/Fields"
        Property Party As Party

        <DisplayName("Party Reference")>
        Property PartyReference As String

        <DisplayName("Invoice Date")>
        Property InvoiceDate As Date

        <DisplayName("Invoice Number")>
        Property InvoiceNo As String

        <DisplayName("After RegEx")>
        ReadOnly Property RegexInvoiceNo As String
            Get
                Dim R As Integer = -1
                R = CInt((New System.Text.RegularExpressions.Regex(My.Settings.InvoiceNoRegex)).Match(InvoiceNo).Groups("invoice").Value)
                Return R
            End Get
        End Property

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

        <DisplayName("Place Of Supply")>
        Property PlaceOfSupply As State
#End Region

#Region "Constructors"
        Sub New()
            Me.Party = Nothing
            Me.PartyReference = ""
            Me.InvoiceDate = Now
            Me.InvoiceNo = ""
            Me.InvoiceValue = 0
            Me.TaxableValue_5 = 0
            Me.TaxableValue_12 = 0
            Me.TaxableValue_18 = 0
            Me.TaxableValue_28 = 0
            Me.ExemptedValue = 0
            Me.Discount = 0
            Me.PlaceOfSupply = State.GetStateByCode(My.Settings.StateCode)
        End Sub

        Sub New(ByVal Party As Party, ByVal PartyReference As String, ByVal InvoiceDate As Date,
ByVal InvoiceNo As String, ByVal InvoiceValue As Double, ByVal TaxableValue_5 As Double,
ByVal TaxableValue_12 As Double, ByVal TaxableValue_18 As Double, ByVal TaxableValue_28 As Double,
ByVal ExemptedValue As Double, ByVal Discount As Double, ByVal PlaceOfSupply As State)
            Me.Party = Party
            Me.PartyReference = PartyReference
            Me.InvoiceDate = InvoiceDate
            Me.InvoiceNo = InvoiceNo
            Me.InvoiceValue = InvoiceValue
            Me.TaxableValue_5 = TaxableValue_5
            Me.TaxableValue_12 = TaxableValue_12
            Me.TaxableValue_18 = TaxableValue_18
            Me.TaxableValue_28 = TaxableValue_28
            Me.ExemptedValue = ExemptedValue
            Me.Discount = Discount
            Me.PlaceOfSupply = PlaceOfSupply
        End Sub
#End Region

    End Class
End Namespace