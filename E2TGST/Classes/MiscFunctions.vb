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

Imports DevExpress.Spreadsheet

Module MiscFunctions

#Region "Functions"
    Public Function GetTallyURL() As String
        Return String.Format("http://{0}:{1}", My.Settings.Host, My.Settings.Port)
    End Function

    Public Function ProcessString(ByVal Text As String) As String
        Dim R As String = Text
        R = R.Replace("&amp;", "&")
        Return R
    End Function
#End Region

#Region "Export Parties to Excel"
    Sub WriteParties2Excel(ByVal Parties As List(Of Objects.Party), ByVal Filename As String)
        Dim WB As New Workbook
        WB.LoadDocument(Templates.My.Resources.Parties)
        Dim PartiesSheet As Worksheet = WB.Worksheets("Parties")
        For i As Integer = 1 To Parties.Count
            Dim Party As Objects.Party = Parties(i - 1)
            Dim Row As Row = PartiesSheet.Rows(i)
            Row.Item(0).SetValue(Party.Name)
            Row.Item(1).SetValue(Party.GSTIN)
            Row.Item(2).SetValue([Enum].GetName(GetType(Enums.RegistrationType), Party.RegType))
            Row.Item(3).SetValue([Enum].GetName(GetType(Enums.PartyType), Party.Group))
        Next
        WB.SaveDocument(Filename)
    End Sub
#End Region

End Module
