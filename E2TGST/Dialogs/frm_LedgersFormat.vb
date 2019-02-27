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

Public Class frm_LedgersFormat

#Region "Subs"
    Sub LoadSettings()
        txt_CESSLedger.Properties.Items.Clear()
        txt_DiscountLedger.Properties.Items.Clear()
        txt_RoundOffLedger.Properties.Items.Clear()
        txt_TaxLedgers.Properties.Items.Clear()
        txt_SalesLedger.Properties.Items.Clear()

        txt_CESSLedger.Properties.Items.AddRange(Utils.Settings.Load.CESSLedgerHistory)
        txt_DiscountLedger.Properties.Items.AddRange(Utils.Settings.Load.DiscountLedgerHistory)
        txt_RoundOffLedger.Properties.Items.AddRange(Utils.Settings.Load.RoundOffLedgerHistory)
        txt_TaxLedgers.Properties.Items.AddRange(Utils.Settings.Load.TaxLedgerHistory)
        txt_SalesLedger.Properties.Items.AddRange(Utils.Settings.Load.SalesLedgerHistory)

        txt_CESSLedger.Text = Utils.Settings.Load.CESSLedger
        txt_DiscountLedger.Text = Utils.Settings.Load.DiscountLedger
        txt_RoundOffLedger.Text = Utils.Settings.Load.RoundOffLedger
        txt_TaxLedgers.Text = Utils.Settings.Load.TaxLedger
        txt_SalesLedger.Text = Utils.Settings.Load.SalesLedger
    End Sub

    Sub SaveSettings()
        Utils.Settings.Load.CESSLedger = txt_CESSLedger.Text
        If Not Utils.Settings.Load.CESSLedgerHistory.Contains(txt_CESSLedger.Text) Then Utils.Settings.Load.CESSLedgerHistory.Add(txt_CESSLedger.Text)

        Utils.Settings.Load.DiscountLedger = txt_DiscountLedger.Text
        If Not Utils.Settings.Load.DiscountLedgerHistory.Contains(txt_DiscountLedger.Text) Then Utils.Settings.Load.DiscountLedgerHistory.Add(txt_DiscountLedger.Text)

        Utils.Settings.Load.RoundOffLedger = txt_RoundOffLedger.Text
        If Not Utils.Settings.Load.RoundOffLedgerHistory.Contains(txt_RoundOffLedger.Text) Then Utils.Settings.Load.RoundOffLedgerHistory.Add(txt_RoundOffLedger.Text)

        Try
            txt_Preview_TaxLedger.Text = String.Format(txt_TaxLedgers.Text, "Input", "IGST", 5)
            Utils.Settings.Load.TaxLedger = txt_TaxLedgers.Text
            If Not Utils.Settings.Load.TaxLedgerHistory.Contains(txt_TaxLedgers.Text) Then Utils.Settings.Load.TaxLedgerHistory.Add(txt_TaxLedgers.Text)
        Catch ex As Exception

        End Try

        Try
            txt_Preview_SalesLedger.Text = String.Format(txt_SalesLedger.Text, 5)
            Utils.Settings.Load.SalesLedger = txt_SalesLedger.Text
            If Not Utils.Settings.Load.SalesLedgerHistory.Contains(txt_SalesLedger.Text) Then Utils.Settings.Load.SalesLedgerHistory.Add(txt_SalesLedger.Text)
        Catch ex As Exception

        End Try

        Utils.Settings.Load.Save()
    End Sub
#End Region

#Region "Events"
    Private Sub txt_TaxLedgers_EditValueChanged(sender As Object, e As EventArgs) Handles txt_TaxLedgers.EditValueChanged
        Try
            txt_Preview_TaxLedger.Text = String.Format(txt_TaxLedgers.Text, "Input", "IGST", 5)
        Catch ex As Exception
            txt_Preview_TaxLedger.Text = "Invalid Format!"
        End Try
    End Sub

    Private Sub frm_TaxLedgersFormat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        SaveSettings()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txt_SalesLedger_EditValueChanged(sender As Object, e As EventArgs) Handles txt_SalesLedger.EditValueChanged
        Try
            txt_Preview_SalesLedger.Text = String.Format(txt_SalesLedger.Text, 5)
        Catch ex As Exception
            txt_Preview_SalesLedger.Text = "Invalid Format!"
        End Try
    End Sub

    Private Sub btn_ResetDefaults_Click(sender As Object, e As EventArgs) Handles btn_ResetDefaults.Click
        Utils.Settings.Reset()
        LoadSettings()
    End Sub
#End Region

End Class