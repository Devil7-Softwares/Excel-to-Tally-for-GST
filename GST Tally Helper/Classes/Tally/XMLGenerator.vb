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

Imports System.Text
Imports System.Xml

Namespace Tally
    Public Class RequestXMLGenerator
#Region "Properties"
        Property TallyVersion As String
        Property CompanyName As String
#End Region

#Region "Constructors"
        Sub New(ByVal TallyVersion As String, ByVal CompanyName As String)
            Me.TallyVersion = TallyVersion
            Me.CompanyName = CompanyName
        End Sub
#End Region

        Function GenerateMasters(ByVal Parties As List(Of Objects.Party))
            Dim enc As New UnicodeEncoding
            Dim MemStream As New IO.MemoryStream
            ' Declare a XmlTextWriter-Object, with which we are going to write the config file
            Dim XMLobj As XmlTextWriter = New XmlTextWriter(MemStream, enc)

            With XMLobj
                .Formatting = Formatting.Indented
                .Indentation = 4
                .WriteStartDocument()
                .WriteStartElement("ENVELOPE") 'ENVELOPE
                .WriteStartElement("HEADER") 'HEADER
                .WriteStartElement("VERSION") 'VERSION
                .WriteString(If(TallyVersion <> "", TallyVersion, "1.0"))
                .WriteEndElement() 'VERSION
                .WriteStartElement("TALLYREQUEST") 'TALLYREQUEST
                .WriteString("Import")
                .WriteEndElement() 'TALLYREQUEST
                .WriteStartElement("TYPE") 'TYPE
                .WriteString("Data")
                .WriteEndElement() 'TYPE
                .WriteStartElement("ID") 'ID
                .WriteString("Vouchers")
                .WriteEndElement() 'ID
                .WriteEndElement() 'HEADER
                .WriteStartElement("BODY") 'BODY
                .WriteStartElement("DESC") 'DESC
                .WriteStartElement("REPORTNAME") 'REPORTNAME
                .WriteString("Vouchers")
                .WriteEndElement() 'REPORTNAME

                If CompanyName <> "" Then
                    .WriteStartElement("STATICVARIABLES") 'STATICVARIABLES
                    .WriteStartElement("SVCURRENTCOMPANY") 'SVCURRENTCOMPANY
                    .WriteString(CompanyName)
                    .WriteEndElement() 'SVCURRENTCOMPANY
                    .WriteEndElement() 'STATICVARIABLES
                End If

                .WriteEndElement() 'DESC
                .WriteStartElement("IMPORTDATA") 'IMPORTDATA
                .WriteStartElement("REQUESTDATA") 'REQUESTDATA

                For Each Party As Objects.Party In Parties
                    .WriteStartElement("TALLYMESSAGE") 'TALLYMESSAGE
                    .WriteAttributeString("xmlns:UDF", "TallyUDF")
                    .WriteStartElement("LEDGER") 'LEDGER
                    .WriteAttributeString("NAME", Party.Name)
                    .WriteAttributeString("RESERVEDNAME", "")
                    .WriteStartElement("MAILINGNAME.LIST") 'MAILINGNAME.LIST
                    .WriteAttributeString("TYPE", "String")
                    .WriteStartElement("MAILINGNAME") 'MAILINGNAME
                    .WriteString(Party.Name)
                    .WriteEndElement() 'MAILINGNAME
                    .WriteEndElement() 'MAILINGNAME.LIST
                    .WriteStartElement("COUNTRYNAME") 'COUNTRYNAME
                    .WriteString("India")
                    .WriteEndElement() 'COUNTRYNAME
                    If Party.RegType <> Enums.RegistrationType.Unknown Then
                        .WriteStartElement("GSTREGISTRATIONTYPE") 'GSTREGISTRATIONTYPE
                        .WriteString([Enum].GetName(GetType(Enums.RegistrationType), Party.RegType))
                        .WriteEndElement() 'GSTREGISTRATIONTYPE
                    End If
                    .WriteStartElement("PARENT") 'PARENT
                    Select Case Party.Group
                        Case Enums.PartyType.SundryDebtor
                            .WriteString("Sundry Debtors")
                        Case Enums.PartyType.SundryCreditor
                            .WriteString("Sundry Creditors")
                    End Select
                    .WriteEndElement() 'PARENT
                    .WriteStartElement("TAXTYPE") 'TAXTYPE
                    .WriteString("Others")
                    .WriteEndElement() 'TAXTYPE
                    .WriteStartElement("COUNTRYOFRESIDENCE") 'COUNTRYOFRESIDENCE
                    .WriteString("India")
                    .WriteEndElement() 'COUNTRYOFRESIDENCE
                    If Party.GSTIN <> "" Then
                        .WriteStartElement("PARTYGSTIN") 'PARTYGSTIN
                        .WriteString(Party.GSTIN)
                        .WriteEndElement() 'PARTYGSTIN
                    End If
                    If Party.State IsNot Nothing Then
                        .WriteStartElement("LEDSTATENAME") 'LEDSTATENAME
                        .WriteString(Party.State.Name)
                        .WriteEndElement() 'LEDSTATENAME
                    End If
                    .WriteStartElement("ISBILLWISEON") 'ISBILLWISEON
                    .WriteString("Yes")
                    .WriteEndElement() 'ISBILLWISEON
                    .WriteStartElement("LANGUAGENAME.LIST") 'LANGUAGENAME.LIST
                    .WriteStartElement("NAME.LIST") 'NAME.LIST
                    .WriteAttributeString("TYPE", "String")
                    .WriteStartElement("NAME") 'NAME
                    .WriteString(Party.Name)
                    .WriteEndElement() 'NAME
                    .WriteStartElement("NAME") 'NAME
                    .WriteString(Party.GSTIN)
                    .WriteEndElement() 'NAME
                    .WriteEndElement() 'NAME.LIST
                    .WriteEndElement() 'LANGUAGENAME.LIST
                    .WriteEndElement() 'LEDGER
                    .WriteEndElement() 'TALLYMESSAGE
                Next
                .WriteEndElement() 'REQUESTDATA
                .WriteEndElement() 'IMPORTDATA
                .WriteEndElement() 'BODY
                .WriteEndElement() 'ENVELOPE
                .WriteEndDocument()
                .Close()
            End With
            Return enc.GetString(MemStream.ToArray)
        End Function

    End Class
End Namespace