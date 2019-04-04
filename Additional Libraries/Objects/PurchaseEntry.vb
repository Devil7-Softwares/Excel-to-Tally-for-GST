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

Public Class PurchaseEntry

#Region "Properties/Fields"
    Property Party As Party
    Property PartyReference As String
    Property InvoiceNo As String
    Property InvoiceDate As Date = Now
    Property InvoiceValue As Double = 0
    Property GSTRate As Double = 0
    Property TaxableValue As Double = 0
    Property CESS As Double = 0
    Property LedgerName As String
    Property VoucherType As Enums.VoucherType
    Property PlaceOfSupply As State
    Property CustomNarration As String
#End Region

#Region "Constructors"
    Sub New()
        Me.Party = Nothing
        Me.PartyReference = ""
        Me.InvoiceNo = ""
        Me.InvoiceDate = Now
        Me.InvoiceValue = 0
        Me.GSTRate = 0
        Me.TaxableValue = 0
        Me.CESS = 0
        Me.LedgerName = ""
        Me.VoucherType = Enums.VoucherType.Purchase
        Me.PlaceOfSupply = State.GetStateByCode(Utils.Settings.Load.StateCode)
        Me.CustomNarration = ""
    End Sub

    Sub New(ByVal Party As Party, ByVal PartyReference As String, ByVal InvoiceNo As String,
                ByVal InvoiceDate As Date, ByVal InvoiceValue As Double, ByVal GSTRate As Double,
                ByVal TaxableValue As Double, ByVal CESS As Double, ByVal LedgerName As String,
                ByVal VoucherType As Enums.VoucherType, ByVal PlaceOfSupply As State, ByVal CustomNarration As String)
        Me.Party = Party
        Me.PartyReference = PartyReference
        Me.InvoiceNo = InvoiceNo
        Me.InvoiceDate = InvoiceDate
        Me.InvoiceValue = InvoiceValue
        Me.GSTRate = GSTRate
        Me.TaxableValue = TaxableValue
        Me.CESS = CESS
        Me.LedgerName = LedgerName
        Me.VoucherType = VoucherType
        Me.PlaceOfSupply = PlaceOfSupply
        Me.CustomNarration = CustomNarration
    End Sub
#End Region

End Class