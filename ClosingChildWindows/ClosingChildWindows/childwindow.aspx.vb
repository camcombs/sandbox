Public Partial Class childwindow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim test As String = "did I get here?"
        Me.Title = "Got In!"
    End Sub

End Class