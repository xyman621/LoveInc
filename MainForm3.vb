Imports MySql.Data.MySqlClient


Public Class MainForm3

    Dim myConnectionString = "User Id=root;Host=localhost;Database=loveinc"
    Dim myConn As New MySqlConnection(myConnectionString)

    Dim count As Integer = 1000
    


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim myAdapter As New MySqlDataAdapter("Select * from global", myConn)
        Dim mydatatable As New DataTable
        myAdapter.Fill(mydatatable)
        count = mydatatable.Rows(0).Item("IDcount")

        'ridiculously long if,then,else statement that should be able to be compacted but does the job for the time being
        'check to see if all the form information is filled out
        If TextBox2.Text = "" Then
            MessageBox.Show("Please input a First Name", "Love Inc")
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("Please input a Last Name", "Love Inc")
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("Please input a Date of Birth", "Love Inc")
        ElseIf TextBox5.Text = "" Then
            MessageBox.Show("Please input an Address", "Love Inc")
        ElseIf TextBox6.Text = "" Then
            MessageBox.Show("Please input a Phone Number", "Love Inc")
        ElseIf TextBox7.Text = "" Then
            MessageBox.Show("Please input an E-mail", "Love Inc")
        ElseIf TextBox8.Text = "" Then
            MessageBox.Show("Please input an Emergency Contact Name", "Love Inc")
        ElseIf TextBox9.Text = "" Then
            MessageBox.Show("Please input an Emergency Contact Number", "Love Inc")
        ElseIf TextBox10.Text = "" Then
            MessageBox.Show("Please input the Emergency Input Relation", "Love Inc")
        ElseIf TextBox14.Text = "" Then
            MessageBox.Show("Please input a City", "Love Inc")
        ElseIf TextBox15.Text = "" Then
            MessageBox.Show("Please input a State", "Love Inc")
        ElseIf TextBox17.Text = "" Then
            MessageBox.Show("Please input a Zip Code", "Love Inc")
        Else

            'concatenate address, city, state, zip
            Dim Address As String = TextBox5.Text + " " + TextBox14.Text + ", " + TextBox15.Text + " " + TextBox17.Text


            'My SQL inset statement
            Dim myInsertQuery As String = "INSERT INTO `volunteer` VALUES (" & count & ", '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & Address & "', '" & TextBox6.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "', '" & TextBox9.Text & "', '" & TextBox10.Text & "', '" & TextBox11.Text & "', '" & TextBox13.Text & "', '" & TextBox12.Text & "', '" & TextBox16.Text & "');"

            Dim myCommand As New MySqlCommand(myInsertQuery)
            myCommand.Connection = myConn
            myConn.Open()
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error:" & ex.Message, "Insert Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                myConn.Close()

                'updating global variable in database
                Dim myUpdateQuery As String = "UPDATE `global` SET IDcount = " & count + 1
                Dim myCommand1 As New MySqlCommand(myUpdateQuery)
                myCommand1.Connection = myConn
                myConn.Open()
                Try
                    myCommand1.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error:" & ex.Message, "Insert Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    myConn.Close()
                End Try


                Dim myAdapter1 As New MySqlDataAdapter("Select * from global", myConn)
                Dim mydatatable1 As New DataTable
                myAdapter1.Fill(mydatatable1)
                Dim countConf = mydatatable1.Rows(0).Item("IDcount")


                MessageBox.Show("Thank you for becoming a volunteer at Love Inc!" & vbNewLine & vbNewLine & "Your new volunteer ID is " & countConf - 1, "Love Inc")
                MainForm1.signinTextBox.Clear()
                Me.Close()
                MainForm1.Show()
                MainForm1.signinTextBox.Focus()

            End Try


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MainForm1.Show()
        Me.Close()
        MainForm1.signinTextBox.Focus()

    End Sub

    Private Sub MainForm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainForm1.Hide()
    End Sub
End Class
