Public Class Form_PartInfo_Submit
    Private Sub popup_Partinfo_input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nowYear As Integer
        Dim eventList(5) As String
        Dim directionList(1) As String

        cmb_Year.Refresh()
        cmb_Event.Refresh()
        cmb_Direction.Refresh()

        'Year Combo list setting - dynamic setting now +-3 year
        nowYear = Now.Year
        Debug.Print(nowYear)

        For i = -3 To 3
            cmb_Year.Items.Add("Y" & Strings.Right((nowYear + i), 2))
        Next i

        'Event Setting
        eventList = {"Pre-PP", "PP", "DV", "PV", "Pre-MP", "MP"}  'Pre-PP/PP/DV/PV/Pre-MP/MP
        cmb_Event.Items.AddRange(eventList)

        'Direction Setting
        directionList = {"Forward", "Backward"}
        cmb_Direction.Items.AddRange(directionList)
    End Sub


End Class