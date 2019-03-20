Public Class Settings

#Region "Variables"
    Private Shared SettingsFile As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "Settings.xml")
    Private Shared Settings As Settings = Nothing
#End Region

#Region "Properties"
    Property BankLedgerName As String = "Bank A/c"
    Property CESSLedger As String = "CESS"
    Property CombineSales As Boolean = False
    Property DontJoinCardSales As Boolean = False
    Property DiscountLedger As String = "Discount"
    Property BankChargesLedger As String = "Bank Charges"
    Property CardSalesLedger As String = "Card Sales"
    Property Host As String = "localhost"
    Property IgnoreDuplicateParties As Boolean = True
    Property IncludeDesc As Boolean = False
    Property InvoiceNoRegex As String = "(?<invoice>.*)"
    Property Port As Integer = 9000
    Property RoundOffLedger As String = "Rounding Off"
    Property SalesLedger As String = "Sales @ {0}%"
    Property Skin As String = ""
    Property StateCode As Integer = 33
    Property TallyOldVersion As Boolean = False
    Property TallyVersion As String = "1.0"
    Property TaxLedger As String = "{0} {1} @ {2}%"
    Property UseInvoiceNumberTag As Boolean = False
    Property UseInvoicePurchase As Boolean = False
    Property UseInvoiceSales As Boolean = False
    Property Narration As String = "AS PER BILL NO.: {0}"
    Property TaxWiseExemptedRate As Double = 0
    Property TaxWiseFiveRate As Double = 5
    Property TaxWiseTwelveRate As Double = 12
    Property TaxWiseEighteenRate As Double = 18
    Property TaxWiseTwentyEightRate As Double = 28

    Property TaxLedgerHistory As New List(Of String)({"{0} {1} @ {2}%"})
    Property SalesLedgerHistory As New List(Of String)({"Sales @ {0}%"})
    Property RoundOffLedgerHistory As New List(Of String)({"Rounding Off"})
    Property CESSLedgerHistory As New List(Of String)({"CESS"})
    Property DiscountLedgerHistory As New List(Of String)({"Discount"})
#End Region

#Region "Subs"
    Public Sub Save()
        Dim XML As New Xml.Serialization.XmlSerializer(GetType(Settings))
        Using Stream As New IO.FileStream(SettingsFile, IO.FileMode.Create)
            XML.Serialize(Stream, Me)
        End Using
    End Sub

    Public Shared Sub Reset()
        Dim S As New Settings
        S.Save()
    End Sub

    Public Shared Function Load() As Settings
        If Settings Is Nothing Then
            If My.Computer.FileSystem.FileExists(SettingsFile) Then
                Dim Xml As New Xml.Serialization.XmlSerializer(GetType(Settings))
                Using Stream As New IO.FileStream(SettingsFile, IO.FileMode.Open)
                    Settings = Xml.Deserialize(Stream)
                End Using
            Else
                Settings = New Settings
            End If
        End If
        Return Settings
    End Function
#End Region

End Class
