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
    Public Class SalesEntry

#Region "Properties"
        Property PartyLedgerName As String
        Property InvoiceDate As String
        Property InvoiceNumberRaw As Integer
        Property InvoiceNumber As String
        Property InvoiceValue As Double
        Property TaxRate As Integer
        Property TaxableValue As Double
        Property CESS As String
        Property PlaceOfSupply As Integer
        Property SalesLedgerName As String
#End Region

#Region "Constructor"
        Sub New(ByVal PartyLedgerName As String, ByVal InvoiceDate As String, ByVal InvoiceNumberRaw As Integer, ByVal InvoiceNumber As String, ByVal InvoiceValue As Double, ByVal TaxRate As Integer, ByVal TaxableValue As Double, ByVal CESS As String, ByVal PlaceOfSupply As Integer, ByVal SalesLedgerName As String)
            Me.PartyLedgerName = PartyLedgerName
            Me.InvoiceDate = InvoiceDate
            Me.InvoiceNumberRaw = InvoiceNumberRaw
            Me.InvoiceNumber = InvoiceNumber
            Me.InvoiceValue = InvoiceValue
            Me.TaxRate = TaxRate
            Me.TaxableValue = TaxableValue
            Me.CESS = CESS
            Me.PlaceOfSupply = PlaceOfSupply
            Me.SalesLedgerName = SalesLedgerName
        End Sub
#End Region

#Region "Comparer"
        Public Class Comparer : Implements IComparer(Of SalesEntry)
            Public Function Compare(x As SalesEntry, y As SalesEntry) As Integer Implements IComparer(Of SalesEntry).Compare
                If x.InvoiceDate <> y.InvoiceDate Then
                    Return x.InvoiceDate.CompareTo(y.InvoiceDate)
                End If
                If x.InvoiceNumber <> y.InvoiceNumber Then
                    Return x.InvoiceNumber.CompareTo(y.InvoiceNumber)
                End If
                Return 0
            End Function
        End Class
#End Region

    End Class
End Namespace