Public Class frmSignature
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        InkPicture1.Enabled = False
        InkPicture1.Ink.DeleteStrokes()
        InkPicture1.Enabled = True
    End Sub

End Class