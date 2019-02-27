Public Class frm_Splash
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub Splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Utils.Settings.Load.Skin <> "" Then
            Try
                Me.Theme.LookAndFeel.SkinName = Utils.Settings.Load.Skin
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
