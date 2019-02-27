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
'=========================================================================='

Public Class State

#Region "Variables"
        Private Shared ReadOnly AllStates As New List(Of State)({New State("Jammu And Kashmir", 1),
                                       New State("Himachal Pradesh", 2),
                                       New State("Punjab", 3),
                                       New State("Chandigarh", 4),
                                       New State("Uttarakhand", 5),
                                       New State("Haryana", 6),
                                       New State("Delhi", 7),
                                       New State("Rajasthan", 8),
                                       New State("Uttar  Pradesh", 9),
                                       New State("Bihar", 10),
                                       New State("Sikkim", 11),
                                       New State("Arunachal Pradesh", 12),
                                       New State("Nagaland", 13),
                                       New State("Manipur", 14),
                                       New State("Mizoram", 15),
                                       New State("Tripura", 16),
                                       New State("Meghlaya", 17),
                                       New State("Assam", 18),
                                       New State("West Bengal", 19),
                                       New State("Jharkhand", 20),
                                       New State("Odisha", 21),
                                       New State("Chattisgarh", 22),
                                       New State("Madhya Pradesh", 23),
                                       New State("Gujarat", 24),
                                       New State("Daman And Diu", 25),
                                       New State("Dadra And Nagar Haveli", 26),
                                       New State("Maharashtra", 27),
                                       New State("Andhra Pradesh (Before Division)", 28),
                                       New State("Karnataka", 29),
                                       New State("Goa", 30),
                                       New State("Lakshwadeep", 31),
                                       New State("Kerala", 32),
                                       New State("Tamil Nadu", 33),
                                       New State("Puducherry", 34),
                                       New State("Andaman And Nicobar Islands", 35),
                                       New State("Telangana", 36),
                                       New State("Andhra Pradesh (New)", 37)})
#End Region

#Region "Fields/Properties"
        ReadOnly Property Name As String
        ReadOnly Property Code As Integer
        ReadOnly Property NameWithCode As String
            Get
                Return String.Format("{0} ({1})", Name, Code)
            End Get
        End Property
#End Region

#Region "Constructors"
        Sub New()
            Me.Name = ""
            Me.Code = 0
        End Sub

        Sub New(ByVal Name As String, ByVal Code As String)
            Me.Name = Name
            Me.Code = Code
        End Sub
#End Region

#Region "Subs/Functions"
        Public Overrides Function ToString() As String
            Return Name.Split("(")(0)
        End Function

        Public Shared Function GetStateByCode(ByVal Code As Integer) As State
            Return AllStates(Code - 1)
        End Function

        Public Shared Function GetAllStates() As State()
            Return AllStates.ToArray
        End Function
#End Region

End Class