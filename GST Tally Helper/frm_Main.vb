Imports DevExpress.XtraBars
Imports ExcelDataReader

Public Class frm_Main

#Region "Subs"
    Async Function LoadParties(ByVal FileName As String) As Task
        Invoke(Sub()
                   btn_LoadParties.Enabled = False
                   ProgressPanel_Parties.Visible = True
               End Sub)
        Await Task.Run(Function()
                           Try
                               Dim R As New List(Of Objects.Party)
                               Using stream As IO.FileStream = IO.File.Open(FileName, IO.FileMode.Open, IO.FileAccess.Read)
                                   Using reader = ExcelReaderFactory.CreateReader(stream)
                                       Dim Index As Integer = -1
                                       While reader.Read()
                                           If reader.CodeName = "Parties" AndAlso Not reader.IsDBNull(0) Then
                                               Index += 1
                                               If Index > 0 Then
                                                   Dim Name As String = reader.GetString(0).Trim
                                                   If Name <> "" Then
                                                       Dim GSTIN As String = reader.GetString(1).Trim
                                                       Dim Type As Enums.PartyType = If(reader.GetString(3) = "SundryCreditor", 1, 0)
                                                       Dim RegType As Enums.RegistrationType = Enums.RegistrationType.Unknown
                                                       Dim RegType_ As String = reader.GetString(2)
                                                       If RegType_ = "Consumer" Then
                                                           RegType = Enums.RegistrationType.Consumer
                                                       ElseIf RegType_ = "Unregistered" Then
                                                           RegType = Enums.RegistrationType.Unregistered
                                                       ElseIf RegType_ = "Regular" Then
                                                           RegType = Enums.RegistrationType.Regular
                                                       ElseIf RegType_ = "Composition" Then
                                                           RegType = Enums.RegistrationType.Composition
                                                       End If
                                                       R.Add(New Objects.Party(Name, GSTIN, RegType, Type))
                                                   End If
                                               End If
                                           End If
                                       End While
                                   End Using
                               End Using
                               Invoke(Sub()
                                          gc_Parties.DataSource = R
                                          gc_Parties.RefreshDataSource()
                                      End Sub)
                           Catch ex As Exception
                               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
                           Return False
                           End Try
                           Return True
                       End Function)
        Invoke(Sub()
                   btn_LoadParties.Enabled = True
                   ProgressPanel_Parties.Visible = False
               End Sub)
    End Function
#End Region

#Region "Events"
    Private Async Sub btn_LoadParties_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_LoadParties.ItemClick
        If OpenFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Await LoadParties(OpenFileDialog_Excel.FileName)
        End If
    End Sub

    Private Sub btn_SaveFormat_Parties_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btn_SaveFormat_Parties.ItemClick
        If SaveFileDialog_Excel.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllBytes(SaveFileDialog_Excel.FileName, My.Resources.Parties, False)
                MsgBox("File Successfully Saved to Selected Location.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Catch ex As Exception
                MsgBox("Unable to Save File :" & vbNewLine & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try

        End If
    End Sub
#End Region

End Class