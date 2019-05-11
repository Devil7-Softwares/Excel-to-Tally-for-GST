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
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen

Public Class frm_Main

#Region "Properties"
    ReadOnly Property SalesEntries As List(Of Objects.SalesEntry)
        Get
            Return CType(gc_Sales_Entries.DataSource, List(Of Objects.SalesEntry))
        End Get
    End Property
#End Region

#Region "Functions"
    Private Function SplitValues(ByVal Value As Double, ByVal Days As Integer, ByVal MaxValue As Double) As Double()
        Dim AverageValue As Double = Value / Days
        Dim AveragePercent As Double = (AverageValue / Value) * 100
        Dim TolerancePercent As Integer = txt_Sales_Rate.Value * 100
        Dim Tolerance As Double = (AveragePercent * (TolerancePercent / 100))

        Dim RandomValues As New List(Of Double)
        Dim RandomMin As Double = (AveragePercent - Tolerance)
        Dim RandomMax As Double = (AveragePercent + Tolerance)
        Dim RandomTotal As Double = 0
        Dim RandomGenerator As New Random
        For i As Integer = 1 To Days
            Dim RandomValue As Double = ((RandomGenerator.NextDouble * (RandomMax - RandomMin)) + RandomMin)
            RandomValues.Add(RandomValue)
            RandomTotal += RandomValue
        Next

        Dim ReturnValue As New List(Of Double)
        For Each RandomValue As Double In RandomValues
            Dim ActualValue As Double = Math.Round((RandomValue / RandomTotal) * Value, CInt(txt_Sales_RoundingLimit.Value))
            If MaxValue = 0 Then
                ReturnValue.Add(ActualValue)
            Else
                Dim ActualValues As New List(Of Double)({ActualValue})
                Do Until ActualValues.Max <= MaxValue
                    Dim TmpActualValues As New List(Of Double)
                    Dim Limit As Integer = ActualValues.Count - 1
                    For i As Integer = 0 To Limit
                        Dim Val As Double = ActualValues(0)
                        ActualValues.RemoveAt(0)

                        If Val <= MaxValue Then
                            TmpActualValues.Add(Val)
                        Else
                            Dim RandomRatio As Integer = (New Random).Next(40, 60)
                            TmpActualValues.AddRange({Val * (RandomRatio / 100), Val * ((100 - RandomRatio) / 100)})
                        End If
                    Next
                    ActualValues.AddRange(TmpActualValues)
                Loop
                ReturnValue.AddRange(ActualValues)
            End If
        Next

        If CInt(rg_MultipicationOf.EditValue) <> 1 Then
            For i As Integer = 0 To ReturnValue.Count - 1
                ReturnValue(i) = Math.Round(ReturnValue(i), 0)
            Next
        End If

        Return ReturnValue.ToArray
    End Function

    Function GetInvoiceNumber(ByVal Format As String, ByVal InvoiceNumber As Integer, ByVal InvoiceDate As Date)
        Return String.Format(Format, InvoiceNumber, InvoiceDate.Year, CInt(InvoiceDate.ToString("yy")), InvoiceDate.Month, InvoiceDate.Day)
    End Function
#End Region

#Region "Subs"
    Private Sub LoadSettings()
        ' Sales
        txt_Sales_BeginningInvoiceNumber.Value = My.Settings.Sales_BeginningInvoice
        txt_Sales_EntriesMax.Value = My.Settings.Sales_EntriesMax
        txt_Sales_EntriesMin.Value = My.Settings.Sales_EntriesMin
        txt_Sales_From.DateTime = My.Settings.Sales_DateFrom
        txt_Sales_To.DateTime = My.Settings.Sales_DateTo
        txt_Sales_InvoiceNumberFormat.Text = My.Settings.Sales_InvoiceNumberFormat
        txt_Sales_Rate.Value = My.Settings.Sales_RateDifference
        txt_Sales_RoundingLimit.Value = My.Settings.Sales_Decimal
    End Sub

    Private Sub SaveSettings()
        ' Sales
        My.Settings.Sales_BeginningInvoice = txt_Sales_BeginningInvoiceNumber.Value
        My.Settings.Sales_EntriesMax = txt_Sales_EntriesMax.Value
        My.Settings.Sales_EntriesMin = txt_Sales_EntriesMin.Value
        My.Settings.Sales_DateFrom = txt_Sales_From.DateTime
        My.Settings.Sales_DateTo = txt_Sales_To.DateTime
        My.Settings.Sales_InvoiceNumberFormat = txt_Sales_InvoiceNumberFormat.Text
        My.Settings.Sales_RateDifference = txt_Sales_Rate.Value
        My.Settings.Sales_Decimal = txt_Sales_RoundingLimit.Value

        My.Settings.Save()
    End Sub

    Private Sub FixExcessCount(ByVal DatesAndCounts As List(Of Objects.DateAndCount), ByVal InvoiceValues As Double())
        Dim TotalCount As Integer = 0
        For Each DateAndCount As Objects.DateAndCount In DatesAndCounts
            TotalCount += DateAndCount.Count
        Next

        Dim ExcessCount As Integer = InvoiceValues.Count - TotalCount
        Dim Index As Integer = 0
        Do Until ExcessCount <= 0
            DatesAndCounts(Index).Count += 1
            ExcessCount -= 1
            Index += 1

            If Index >= DatesAndCounts.Count Then
                Index = 0
            End If
        Loop
    End Sub

    Private Sub FixDifference(ByVal TotalTaxableValue As Double, ByVal RandomEntry As Objects.RandomSalesEntry, ByVal SalesEntries As List(Of Objects.SalesEntry))
        Dim Difference As Double = RandomEntry.TotalTaxableAmount - TotalTaxableValue
        If Difference > 0 Then
            Dim SmallestEntry As Objects.SalesEntry = Nothing
            For Each Entry As Objects.SalesEntry In SalesEntries
                If SmallestEntry Is Nothing OrElse SmallestEntry.TaxableValue > Entry.TaxableValue Then
                    SmallestEntry = Entry
                End If
            Next
            SmallestEntry.TaxableValue += Difference
            Dim TaxValue As Double = (SmallestEntry.TaxableValue * (RandomEntry.TaxRate / 100))
            SmallestEntry.InvoiceValue = SmallestEntry.TaxableValue + TaxValue
        ElseIf Difference < 0 Then
            Dim BiggestEntry As Objects.SalesEntry = Nothing
            For Each Entry As Objects.SalesEntry In SalesEntries
                If BiggestEntry Is Nothing OrElse BiggestEntry.TaxableValue < Entry.TaxableValue Then
                    BiggestEntry = Entry
                End If
            Next
            BiggestEntry.TaxableValue += Difference
            Dim TaxValue As Double = (BiggestEntry.TaxableValue * (RandomEntry.TaxRate / 100))
            BiggestEntry.InvoiceValue = BiggestEntry.TaxableValue + TaxValue
        End If
    End Sub
#End Region

#Region "Progress Panel"
    Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Return SplashScreenManager.ShowOverlayForm(Me)
    End Function

    Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
#End Region

#Region "Button Events"
#Region "Generate"
    Private Sub btn_Sales_Generate_Click(sender As Object, e As EventArgs) Handles btn_Sales_Generate.Click
        Dim SalesEntries As New List(Of Objects.SalesEntry)

        Dim RandomCount As New Random
        Dim DatesAndCounts As New List(Of Objects.DateAndCount)
        Dim TotalCount As Integer = 0
        For i As Integer = 0 To (txt_Sales_To.DateTime - txt_Sales_From.DateTime).Days
            Dim [Date] As Date = txt_Sales_From.DateTime.AddDays(i)
            If lst_Sales_Days.Items([Date].DayOfWeek).CheckState = CheckState.Checked Then
                Dim Count As Integer = RandomCount.Next(txt_Sales_EntriesMin.Value, txt_Sales_EntriesMax.Value)
                DatesAndCounts.Add(New Objects.DateAndCount([Date], Count))
                TotalCount += Count
            End If
        Next

        For Each RandomEntry As Objects.RandomSalesEntry In gc_Sales_RandomEntries.DataSource
            Dim TotalTaxableValueTmp As Double = 0

            Dim TmpSalesEntries As New List(Of Objects.SalesEntry)
            Dim Index As Integer = 0
            Dim InvoiceNumberBase As Integer = RandomEntry.StartingInvoiceNumber
            Dim InvoiceValues As Double() = SplitValues((RandomEntry.TotalTaxableAmount / CInt(rg_MultipicationOf.EditValue)), TotalCount, RandomEntry.MaxInvoiceValue)
            FixExcessCount(DatesAndCounts, InvoiceValues)
            For Each DateAndCount As Objects.DateAndCount In DatesAndCounts
                Dim InvoiceDate As Date = DateAndCount.Date
                For i As Integer = 1 To DateAndCount.Count
                    Dim InvoiceNumber As String = If(cb_Sales_ContinuousInvoice.Checked, "", GetInvoiceNumber(txt_Sales_InvoiceNumberFormat.Text, InvoiceNumberBase + Index, InvoiceDate))
                    Dim TaxableValue As Double = InvoiceValues(Index) * CInt(rg_MultipicationOf.EditValue)
                    Dim TaxValue As Double = (TaxableValue * (RandomEntry.TaxRate / 100))
                    Dim InvoiceValue As Integer = TaxableValue + TaxValue
                    Dim CESS As Integer = 0
                    Dim PlaceOfSupply As Integer = 33
                    TmpSalesEntries.Add(New Objects.SalesEntry(RandomEntry.PartyLedgerName, InvoiceDate, InvoiceNumberBase + Index, InvoiceNumber, InvoiceValue, RandomEntry.TaxRate, TaxableValue, CESS, PlaceOfSupply, RandomEntry.SalesLedgerName))

                    TotalTaxableValueTmp += TaxableValue
                    Index += 1
                Next
            Next

            FixDifference(TotalTaxableValueTmp, RandomEntry, TmpSalesEntries)
            SalesEntries.AddRange(TmpSalesEntries)
        Next

        SalesEntries.Sort(New Objects.SalesEntry.Comparer)
        If cb_Sales_ContinuousInvoice.Checked Then
            Dim InvoiceNumberBase As Integer = txt_Sales_BeginningInvoiceNumber.Value
            For i As Integer = 0 To SalesEntries.Count - 1
                SalesEntries(i).InvoiceNumberRaw = InvoiceNumberBase + i
                SalesEntries(i).InvoiceNumber = GetInvoiceNumber(txt_Sales_InvoiceNumberFormat.Text, InvoiceNumberBase + i, SalesEntries(i).InvoiceDate)
            Next
        End If

        Dim TotalTaxableValue As Double = 0
        Dim TotalInvoiceValue As Double = 0
        For Each Entry As Objects.SalesEntry In SalesEntries
            TotalTaxableValue += Entry.TaxableValue
            TotalInvoiceValue += Entry.InvoiceValue
        Next
        txt_TotalInvoices_Count.Text = SalesEntries.Count
        txt_TotalInvoices_InvoiceSum.Text = TotalInvoiceValue
        txt_TotalInvoices_TaxableSum.Text = TotalTaxableValue

        gc_Sales_Entries.DataSource = SalesEntries
        container_Sales_Entries.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
    End Sub
#End Region

#Region "Export"
    Private Sub btn_Sales_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_Sales_ExportExcel.Click
        dlg_SaveExcel.FileName = String.Format("Sales Entries ({0} to {1}).xlsx", txt_Sales_From.DateTime.ToString("dd-MM-yyyy"), txt_Sales_To.DateTime.ToString("dd-MM-yyyy"))
        If dlg_SaveExcel.ShowDialog = DialogResult.OK Then
            Dim Handle As IOverlaySplashScreenHandle = Nothing

            Try
                Handle = ShowProgressPanel()

                Dim WB As New Workbook
                WB.LoadDocument(Templates.My.Resources.SalesEntriesA)
                Dim SalesSheet As Worksheet = WB.Worksheets("Sales Entries")
                For i As Integer = 1 To SalesEntries.Count
                    Dim SalesEntry As Objects.SalesEntry = SalesEntries(i - 1)
                    Dim Row As Row = SalesSheet.Rows(i)
                    Row.Item(0).SetValue(SalesEntry.PartyLedgerName)
                    Row.Item(1).SetValue(SalesEntry.InvoiceDate)
                    Row.Item(2).SetValue(SalesEntry.InvoiceNumber)
                    Row.Item(3).SetValue(SalesEntry.InvoiceValue)
                    Row.Item(4).SetValue(SalesEntry.TaxRate)
                    Row.Item(5).SetValue(SalesEntry.TaxableValue)
                    Row.Item(6).SetValue(SalesEntry.CESS)
                    Row.Item(7).SetValue(SalesEntry.PlaceOfSupply)
                    Row.Item(8).SetValue(SalesEntry.SalesLedgerName)
                Next
                WB.SaveDocument(dlg_SaveExcel.FileName)
                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully saved excel file!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Error on saving excel file!" & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CloseProgressPanel(Handle)
            End Try
        End If
    End Sub
#End Region

#Region "Random Entries Load/Save"
    Private Sub btn_Sales_LoadRandom_Click(sender As Object, e As EventArgs) Handles btn_Sales_LoadRandom.Click
        If dlg_OpenXML.ShowDialog = DialogResult.OK Then
            Try
                Dim XMLSerializer As New Xml.Serialization.XmlSerializer(GetType(BindingList(Of Objects.RandomSalesEntry)))
                Using Stream As New IO.FileStream(dlg_OpenXML.FileName, IO.FileMode.Open)
                    Dim Data As BindingList(Of Objects.RandomSalesEntry) = CType(XMLSerializer.Deserialize(Stream), BindingList(Of Objects.RandomSalesEntry))
                    Data.AllowEdit = True
                    Data.AllowNew = True
                    Data.AllowRemove = True
                    gc_Sales_RandomEntries.DataSource = Data
                    gc_Sales_RandomEntries.RefreshDataSource()
                End Using
                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully loaded combined items to file!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Error on loading combined items to file!" & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btn_Sales_SaveRandom_Click(sender As Object, e As EventArgs) Handles btn_Sales_SaveRandom.Click
        If gc_Sales_RandomEntries.DataSource IsNot Nothing AndAlso gc_Sales_RandomEntries.DataSource.Count > 0 Then
            If dlg_SaveXML.ShowDialog = DialogResult.OK Then
                Try
                    Dim XMLSerializer As New Xml.Serialization.XmlSerializer(GetType(BindingList(Of Objects.RandomSalesEntry)))
                    Using Stream As New IO.FileStream(dlg_SaveXML.FileName, IO.FileMode.Create)
                        XMLSerializer.Serialize(Stream, gc_Sales_RandomEntries.DataSource)
                    End Using
                    DevExpress.XtraEditors.XtraMessageBox.Show("Successfully saved combined items to file!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("Error on saving combined items to file!" & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
#End Region
#End Region

#Region "Form Events"
    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()

        gc_Sales_RandomEntries.DataSource = New BindingList(Of Objects.RandomSalesEntry) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}
        gc_Sales_Entries.DataSource = New List(Of Objects.SalesEntry)
    End Sub

    Private Sub frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings()
    End Sub
#End Region

#Region "Other Events"
    Private Sub txt_Sales_EntriesMin_EditValueChanged(sender As Object, e As EventArgs) Handles txt_Sales_EntriesMin.EditValueChanged
        txt_Sales_EntriesMax.Properties.MinValue = txt_Sales_EntriesMin.Value
    End Sub

    Private Sub cb_Sales_ContinuousInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sales_ContinuousInvoice.CheckedChanged
        txt_Sales_BeginningInvoiceNumber.Enabled = cb_Sales_ContinuousInvoice.Checked
    End Sub

    Private Sub txt_Sales_InvoiceNumberFormat_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txt_Sales_InvoiceNumberFormat.ButtonClick
        Dim D As New frm_InvoiceNumberFormat
        D.InvoiceNumberFormat = txt_Sales_InvoiceNumberFormat.Text
        If D.ShowDialog = DialogResult.OK Then
            txt_Sales_InvoiceNumberFormat.Text = D.InvoiceNumberFormat
            My.Settings.Sales_InvoiceNumberFormat = D.InvoiceNumberFormat
            My.Settings.Save()
        End If
    End Sub
#End Region

End Class
