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

Imports System.IO
Imports System.Text
Imports System.Xml

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

#Region "Parties"
    Function GenerateMasters(ByVal Parties As List(Of Objects.Party), Optional ByVal Ledgers As List(Of String) = Nothing)
        Dim enc As New UnicodeEncoding
        Dim MemStream As New MemoryStream
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
                If Utils.Settings.Load.IgnoreDuplicateParties AndAlso Ledgers IsNot Nothing AndAlso (Ledgers.Contains(Party.GSTIN) Or Ledgers.Contains(Party.Name)) Then
                    Continue For
                End If

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
                    If Utils.Settings.Load.TallyOldVersion Then
                        .WriteStartElement("SALESTAXNUMBER") 'SALESTAXNUMBER
                        .WriteString(Party.GSTIN)
                        .WriteEndElement() 'SALESTAXNUMBER
                    End If
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
#End Region

#Region "Vouchers"
    Function GenerateVouchers(ByVal Vouchers As List(Of Objects.Voucher)) As String
        Dim enc As New UnicodeEncoding
        Dim MemStream As New MemoryStream
        ' Declare a XmlTextWriter-Object, with which we are going to write the config file
        Dim XMLobj As XmlTextWriter = New XmlTextWriter(MemStream, enc)

        For Each Voucher As Objects.Voucher In Vouchers
            Voucher.Entries.Sort(New EntriesComparer(Voucher))
        Next

        With XMLobj
            .Formatting = Formatting.Indented
            .Indentation = 4
            .WriteStartDocument()
            .WriteStartElement("ENVELOPE") 'ENVELOPE
            .WriteStartElement("HEADER") 'HEADER
            .WriteStartElement("VERSION") 'VERSION
            .WriteString(Utils.Settings.Load.TallyVersion)
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
            .WriteStartElement("STATICVARIABLES") 'STATICVARIABLES
            .WriteStartElement("SVCURRENTCOMPANY") 'SVCURRENTCOMPANY
            .WriteString(CompanyName)
            .WriteEndElement() 'SVCURRENTCOMPANY
            .WriteEndElement() 'STATICVARIABLES
            .WriteEndElement() 'DESC
            .WriteStartElement("IMPORTDATA") 'IMPORTDATA
            .WriteStartElement("REQUESTDATA") 'REQUESTDATA
            WriteVouchers(Vouchers, XMLobj)
            .WriteEndElement() 'REQUESTDATA
            .WriteEndElement() 'IMPORTDATA
            .WriteEndElement() 'BODY
            .WriteEndElement() 'ENVELOPE
            .WriteEndDocument()
            .Close()
        End With
        Return enc.GetString(MemStream.ToArray).Replace("&amp;#13;&amp;#10;", "&#13;&#10;")
    End Function

    Private Sub WriteVouchers(ByVal Vouchers As List(Of Objects.Voucher), ByRef XMLWriter As XmlWriter)
        For Each i As Objects.Voucher In Vouchers
            With XMLWriter
                .WriteStartElement("TALLYMESSAGE") 'TALLYMESSAGE
                .WriteAttributeString("xmlns:UDF", "TallyUDF")
                .WriteStartElement("VOUCHER")
                .WriteAttributeString("VCHTYPE", i.VoucherType)
                .WriteAttributeString("ACTION", "CREATE")
                If (String.Compare(i.VoucherType, "Purchase", True) = 0 AndAlso Utils.Settings.Load.UseInvoicePurchase) Or (String.Compare(i.VoucherType, "Sales", True) = 0 AndAlso Utils.Settings.Load.UseInvoiceSales) Then
                    .WriteAttributeString("OBJVIEW", "Invoice Voucher View")
                End If
                .WriteStartElement("VOUCHERTYPENAME") 'VOUCHERTYPENAME
                .WriteString(i.VoucherType)
                .WriteEndElement() 'VOUCHERTYPENAME
                .WriteStartElement("DATE") 'DATE
                .WriteString(i.VoucherDate)
                .WriteEndElement() 'DATE
                .WriteStartElement("EFFECTIVEDATE") 'EFFECTIVEDATE
                .WriteString(i.VoucherDate)
                .WriteEndElement() 'EFFECTIVEDATE
                If (String.Compare(i.VoucherType, "Purchase", True) = 0 AndAlso Utils.Settings.Load.UseInvoicePurchase) Or (String.Compare(i.VoucherType, "Sales", True) = 0 AndAlso Utils.Settings.Load.UseInvoiceSales) Then
                    .WriteStartElement("PERSISTEDVIEW") 'PERSISTEDVIEW
                    .WriteString("Invoice Voucher View")
                    .WriteEndElement() 'PERSISTEDVIEW
                    .WriteStartElement("ISINVOICE") 'ISINVOICE
                    .WriteString("Yes")
                    .WriteEndElement() 'ISINVOICE
                End If
                .WriteStartElement(If(Utils.Settings.Load.UseInvoiceNumberTag, "INVOICENUMBER", "REFERENCE")) 'REFERENCE
                .WriteString(i.VoucherRef)
                .WriteEndElement() 'REFERENCE
                .WriteStartElement("NARRATION") 'NARRATION
                .WriteString(i.Narration)
                .WriteEndElement() 'NARRATION

                For Each entry As Objects.VoucherEntry In i.Entries
                    .WriteStartElement("ALLLEDGERENTRIES.LIST") 'ALLLEDGERENTRIES.LIST
                    .WriteStartElement("REMOVEZEROENTRIES") 'REMOVEZEROENTRIES
                    .WriteString("No")
                    .WriteEndElement() 'REMOVEZEROENTRIES
                    .WriteStartElement("ISDEEMEDPOSITIVE") 'ISDEEMEDPOSITIVE
                    If entry.Effect = Enums.Effect.Cr Then
                        .WriteString("No")
                    Else
                        .WriteString("Yes")
                    End If
                    .WriteEndElement() 'ISDEEMEDPOSITIVE
                    .WriteStartElement("LEDGERNAME") 'LEDGERNAME
                    .WriteString(entry.LedgerName)
                    .WriteEndElement() 'LEDGERNAME
                    .WriteStartElement("AMOUNT") 'AMOUNT
                    Dim AMT As Double = entry.Amount
                    If entry.Effect = Enums.Effect.Dr Then
                        AMT = Math.Abs(entry.Amount) * -1
                    Else
                        AMT = Math.Abs(entry.Amount)
                    End If
                    .WriteString(AMT)
                    .WriteEndElement() 'AMOUNT
                    .WriteEndElement() 'ALLLEDGERENTRIES.LIST
                Next

                .WriteEndElement() 'VOUCHER
                .WriteEndElement() 'TALLYMESSAGE
            End With
        Next
    End Sub
#End Region

End Class