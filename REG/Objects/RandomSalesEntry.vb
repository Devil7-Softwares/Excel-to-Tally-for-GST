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
    Public Class RandomSalesEntry

#Region "Properties"
        <DisplayName("Party Ledger Name")>
        Property PartyLedgerName As String

        <DisplayName("Sales Ledger Name")>
        Property SalesLedgerName As String

        <DisplayName("Tax Rate")>
        Property TaxRate As Integer

        <DisplayName("Total Taxable Amount")>
        Property TotalTaxableAmount As Double

        <DisplayName("Starting Invoice Number")>
        Property StartingInvoiceNumber As Integer
#End Region

#Region "Constructor"
        Sub New()
            Me.PartyLedgerName = ""
            Me.SalesLedgerName = ""
            Me.TaxRate = 0
            Me.TotalTaxableAmount = 0
            Me.StartingInvoiceNumber = 0
        End Sub
#End Region

    End Class
End Namespace