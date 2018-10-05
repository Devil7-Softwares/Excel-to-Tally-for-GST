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
    Public Class Party

#Region "Properties/Fields"
        Property Name As String
        Property GSTIN As String
        Property Type As Enums.PartyType
#End Region

#Region "Constructors"
        Sub New()
            Me.Name = ""
            Me.GSTIN = ""
            Me.Type = Enums.PartyType.SundryDebtor
        End Sub

        Sub New(ByVal Name As String, ByVal GSTIN As String, ByVal Type As Enums.PartyType)
            Me.Name = Name
            Me.GSTIN = GSTIN
            Me.Type = Type
        End Sub
#End Region

    End Class
End Namespace