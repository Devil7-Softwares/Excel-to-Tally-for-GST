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

Namespace Objects
    Public Class PurchaseEntry

#Region "Properties/Fields"
        Property GSTIN As String
        Property InvoiceNo As String
        Property InvoiceDate As Date = Now
        Property InvoiceValue As Double = 0
        Property GSTRate As Integer = 0
        Property TaxableValue As Double = 0
        Property IGST As Double = 0
        Property CGST As Double = 0
        Property SGST As Double = 0
        Property CESS As Double = 0
        Property LedgerName As String
        Property VoucherType As Enums.VoucherType
#End Region

#Region "Constructors"
        Sub New()
            Me.GSTIN = ""
            Me.InvoiceNo = ""
            Me.InvoiceDate = Now
            Me.InvoiceValue = 0
            Me.GSTRate = 0
            Me.TaxableValue = 0
            Me.IGST = 0
            Me.CGST = 0
            Me.SGST = 0
            Me.CESS = 0
            Me.LedgerName = ""
            Me.VoucherType = Enums.VoucherType.Purchase
        End Sub

        Sub New(ByVal GSTIN As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal InvoiceValue As Double,
                ByVal GSTRate As Integer, ByVal TaxableValue As Double, ByVal IGST As Double, ByVal CGST As Double,
                ByVal SGST As Double, ByVal CESS As Double, ByVal LedgerName As String, ByVal VoucherType As Enums.VoucherType)
            Me.GSTIN = GSTIN
            Me.InvoiceNo = InvoiceNo
            Me.InvoiceDate = InvoiceDate
            Me.InvoiceValue = InvoiceValue
            Me.GSTRate = GSTRate
            Me.TaxableValue = TaxableValue
            Me.IGST = IGST
            Me.CGST = CGST
            Me.SGST = SGST
            Me.CESS = CESS
            Me.LedgerName = LedgerName
            Me.VoucherType = VoucherType
        End Sub
#End Region

    End Class
End Namespace