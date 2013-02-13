Imports MySql.Data.MySqlClient


Public Class MainForm2

    Dim myConnectionString = "User Id=root;Host=localhost;Database=loveinc"
    Dim myConn As New MySqlConnection(myConnectionString)

    Private Sub MainForm2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MainForm1.Hide()

        'My SQL select statement according to a Unique volunteerID
        Dim myAdapter As New MySqlDataAdapter("Select * from volunteer where volunteerID=" & MainForm1.signinTextBox.Text, myConn)
        Dim mydatatable As New DataTable
        myAdapter.Fill(mydatatable)

        'grab current time
        Dim time As Date
        time = TimeValue(Now)
        Label3.Text = time

        'Insert data from Database into labels
        If mydatatable.Rows.Count > 0 Then
            Label16.Text = mydatatable.Rows(0).Item("firstName")
            Label1.Text = mydatatable.Rows(0).Item("volunteerID")
            Label2.Text = mydatatable.Rows(0).Item("firstName")
            Label4.Text = mydatatable.Rows(0).Item("LastName")

        Else
            MsgBox("NOT FOUND")
            Me.Close()
            MainForm1.Show()
            MainForm1.signinTextBox.Clear()
            MainForm1.signinTextBox.Focus()

        End If

        'Button1 enable should be FALSE in MainForm2
        Dim myAdapter3 As New MySqlDataAdapter("Select * from session where volunteerID = '" & MainForm1.signinTextBox.Text & "' AND jobEnd IS NULL", myConn)
        Dim mydatatable4 As New DataTable
        myAdapter3.Fill(mydatatable4)

        If mydatatable4.Rows.Count = 0 Then

            Button1.Enabled = True
            Button2.Enabled = False
            Button2.BackColor = Color.Gray

        Else

            Button1.Enabled = False
            Button2.Enabled = True
            Button1.BackColor = Color.Gray

            GroupBox2.Enabled = False

        End If

        mydatatable4.Clear()

    End Sub

    Private Sub BackButton_Click(sender As System.Object, e As System.EventArgs) Handles BackButton.Click

        'Sends you back to mainform1
        MainForm1.Show()
        Me.Close()

        'clears the labels
        MainForm1.signinTextBox.Clear()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""

        MainForm1.signinTextBox.Focus()


    End Sub

    Public Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'Checks which radiobutton has been selected
        Dim location As String = ""
        If (RadioButton1.Checked = True) Then
            location = Label6.Text
        ElseIf (RadioButton2.Checked = True) Then
            location = Label7.Text
        ElseIf (RadioButton3.Checked = True) Then
            location = Label8.Text
        End If


        'My SQL inset statemento to insert the volunteerID, orgName, and StartTime of the person who is checking in
        Dim myInsertQuery As String = "INSERT INTO `session` (`volunteerID`, `orgName`, `jobStart`) VALUES ('" & Label1.Text & "', '" & location & "', '" & Label3.Text & "');"
        Dim myCommand As New MySqlCommand(myInsertQuery)
        myCommand.Connection = myConn
        myConn.Open()
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Insert Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally

            If location = "" Then
                MessageBox.Show("Error: Please select a Location", "Love Inc")
                myConn.Close()
            Else


                myConn.Close()
                MessageBox.Show("Check In Successful! " & vbNewLine & vbNewLine & "Check In Time: " & Label3.Text & "", "Love Inc")
                MainForm1.signinTextBox.Clear()
                MainForm1.Show()
                Me.Close()
                MainForm1.signinTextBox.Focus()

            End If
        End Try


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click


        'My SQL update statemento to insert the volunteerID, orgName, and StartTime of the person who is checking in
        Dim myUpdateQuery As String = "UPDATE `session` SET jobEnd = '" & Label3.Text & "' WHERE volunteerID = '" & Label1.Text & "' AND jobEnd IS NULL"
        Dim myCommand As New MySqlCommand(myUpdateQuery)
        myCommand.Connection = myConn
        myConn.Open()
        Try
            myCommand.ExecuteNonQuery()

            'Dim timeString As String = "0" & Label3.Text.Substring(0, 7)

            'Label9.Text = TimeString


        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Insert Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            myConn.Close()
            MessageBox.Show("Check Out Successful! " & vbNewLine & vbNewLine & "Check Out Time: " & Label3.Text & "", "Love Inc")

        End Try

        'experiment

        Dim autoID As Integer


        Try

            Dim myAdapter As New MySqlDataAdapter("select max(autoID) as id FROM session WHERE volunteerID = '" & MainForm1.signinTextBox.Text & "';", myConn)
            Dim mydatatable2 As New DataTable
            myAdapter.Fill(mydatatable2)
            If mydatatable2.Rows.Count > 0 Then

                autoID = mydatatable2.Rows(0).Item("id")

            End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)

        End Try

        Dim timeElapsed As String


        Try

            Dim myAdapter As New MySqlDataAdapter("select timediff(jobEnd, jobStart) as totalTime from session where autoID = '" & autoID & "';", myConn)
            Dim mydatatable1 As New DataTable
            myAdapter.Fill(mydatatable1)
            If mydatatable1.Rows.Count > 0 Then

                Label19.Text = mydatatable1.Rows(0).Item("totalTime").ToString()
            Else
                timeElapsed = ""

            End If

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)

        End Try

        Try

            'working label19
            Dim myUpdateQuery1 As String = "UPDATE `session` SET elapsedTime = '" & Label19.Text & "' WHERE volunteerID = '" & Label1.Text & "' and elapsedTime is null;"
            Dim myCommand1 As New MySqlCommand(myUpdateQuery1)
            myCommand1.Connection = myConn
            myConn.Open()
            myCommand1.ExecuteNonQuery()
            myConn.Close()
        Catch ex1 As Exception
            MessageBox.Show("Error:" & ex1.Message)

        End Try

        MainForm1.Show()
        MainForm1.signinTextBox.Clear()
        Me.Close()
        MainForm1.signinTextBox.Focus()


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged

        'Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.ForeColor = Color.Blue
        Label6.ForeColor = Color.Black
        Label8.ForeColor = Color.Black

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged

        Label7.ForeColor = Color.Black
        Label6.ForeColor = Color.Blue
        Label8.ForeColor = Color.Black

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged

        Label7.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label8.ForeColor = Color.Blue

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        MainForm1.Show()
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
