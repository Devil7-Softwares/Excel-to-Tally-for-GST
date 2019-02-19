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
    Public Class SalesEntryA

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

        <DisplayName("GST Rate")>
        Property GSTRate As Integer

        <DisplayName("Taxable Value")>
        Property TaxableValue As Double
        Property CESS As Double

        <DisplayName("Place Of Supply")>
        Property PlaceOfSupply As State

        <DisplayName("Custom Sales Ledger Name")>
        Property CustomSalesLedger As String
#End Region

#Region "Constructors"
        Sub New()
            Me.Party = Nothing
            Me.PartyReference = ""
            Me.InvoiceDate = Now
            Me.InvoiceNo = ""
            Me.InvoiceValue = 0
            Me.GSTRate = 0
            Me.TaxableValue = 0
            Me.CESS = 0
            Me.PlaceOfSupply = State.GetStateByCode(My.Settings.StateCode)
            Me.CustomSalesLedger = ""
        End Sub

        Sub New(ByVal Party As Party, ByVal PartyReference As String, ByVal InvoiceDate As Date,
                ByVal InvoiceNo As String, ByVal InvoiceValue As Double, ByVal Rate As Integer,
                ByVal TaxableValue As Double, ByVal CESS As Double, ByVal PlaceOfSupply As State, ByVal CustomSalesLedger As String)
            Me.Party = Party
            Me.PartyReference = PartyReference
            Me.InvoiceDate = InvoiceDate
            Me.InvoiceNo = InvoiceNo
            Me.InvoiceValue = InvoiceValue
            Me.GSTRate = Rate
            Me.TaxableValue = TaxableValue
            Me.CESS = CESS
            Me.PlaceOfSupply = PlaceOfSupply
            Me.CustomSalesLedger = CustomSalesLedger
        End Sub
#End Region

    End Class
End Namespace