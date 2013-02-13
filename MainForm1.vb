Imports System.Data.SqlClient


Public Class MainForm1

    Private Sub signinButton_Click(sender As System.Object, e As System.EventArgs) Handles signinButton.Click

        If signinTextBox.Text = "" Then
            MessageBox.Show("Please Scan your card", "Love Inc")
        Else

            MainForm2.Show()

        End If

    End Sub

    Private Sub userButton_Click(sender As System.Object, e As System.EventArgs) Handles userButton.Click

        MainForm3.Show()

    End Sub

    Private Sub MainForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm5.Show()
        MainForm5.Focus()
    End Sub

    Private Sub signinTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles signinTextBox.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            signinButton.PerformClick()
            e.Handled = True
        End If

    End Sub

    
    Private Sub SignOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignOutToolStripMenuItem.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub
End Class


THIS IS SOME BULLSHIT I ADD TO SEE WHAT HAPPENS

