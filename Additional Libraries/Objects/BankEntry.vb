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

Public Class BankEntry

#Region "Properties/Fields"
    Property ValueDate As Date
    Property Description As String
    Property Ref As String
    Property Withdrawals As Double
    Property Deposits As Double
    Property LedgerName As String
#End Region

#Region "Constructors"
    Sub New()
        Me.ValueDate = Now
        Me.Description = ""
        Me.Ref = ""
        Me.Withdrawals = 0
        Me.Deposits = 0
        Me.LedgerName = ""
    End Sub

    Sub New(ByVal ValueDate As Date, ByVal Description As String, ByVal Ref As String, ByVal Withdrawals As Double, ByVal Deposits As Double, ByVal LedgerName As String)
        Me.ValueDate = ValueDate
        Me.Description = Description
        Me.Ref = Ref
        Me.Withdrawals = Withdrawals
        Me.Deposits = Deposits
        Me.LedgerName = LedgerName
    End Sub
#End Region

End Class