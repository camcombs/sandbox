Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            InitGrid(grdFirstGrid)
            InitGrid(grdSecondGrid)
        End If

    End Sub

    Protected Sub InitGrid(ByVal grid As GridView)
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("SourceTypeCode", GetType(System.Web.UI.WebControls.DropDownList)))
        dt.Columns.Add(New DataColumn("SourceID", GetType(System.Web.UI.WebControls.TextBox)))

        Dim gridRow As DataRow = dt.NewRow
        dt.Rows.Add(gridRow)

        grid.DataSource = dt
        grid.DataBind()
        ' in a real app, we'd be pulling information from a datasource
        Dim txt As TextBox = DirectCast(grid.Rows(0).FindControl("txtSourceID"), TextBox)
        txt.Text = "AA12345"
        Dim ddl As DropDownList = DirectCast(grid.Rows(0).FindControl("ddlSourceTypeCode"), DropDownList)
        FillDropDown(ddl)
        ddl.SelectedIndex = 0


    End Sub

#Region "adding a new row"
    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim gv As GridView = Nothing
        Dim ctl As Object = TryCast(sender, Control)
        While ctl IsNot Nothing
            If TypeOf ctl Is GridView Then
                gv = TryCast(ctl, GridView)
                Exit While
            End If
            ctl = ctl.Parent
        End While


        AddNewRowToGrid(gv)
    End Sub

    Private Sub AddNewRowToGrid(ByVal grid As GridView)

        Dim sourceList As List(Of Source) = SetSourceList(grid)

        Dim ddl As New DropDownList

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("SourceTypeCode", GetType(System.Web.UI.WebControls.DropDownList)))
        dt.Columns.Add(New DataColumn("SourceID", GetType(System.Web.UI.WebControls.TextBox)))
        Dim gridRow As DataRow
        Dim txt As New TextBox

        '' set up the datatable, add what we already have
        For x As Integer = 0 To sourceList.Count
            gridRow = dt.NewRow

            FillDropDown(ddl)
            ddl.SelectedIndex = 0
            txt.Text = ""
            gridRow.Item(0) = ddl
            gridRow.Item(1) = txt
            dt.Rows.Add(gridRow)
        Next

        grid.DataSource = dt
        grid.DataBind()

        Dim currentRow As Integer = 0
        For Each s As Source In sourceList
            ddl = DirectCast(grid.Rows(currentRow).Cells(0).FindControl("ddlSourceTypeCode"), DropDownList)

            FillDropDown(ddl)
            ddl.SelectedValue = s.SourceTypeCode

            txt = DirectCast(grid.Rows(currentRow).Cells(1).FindControl("txtSourceID"), TextBox)
            txt.Text = s.SourceID

            currentRow += 1
        Next

        ' plus one
        ddl = DirectCast(grid.Rows(currentRow).Cells(0).FindControl("ddlSourceTypeCode"), DropDownList)

        FillDropDown(ddl)

        ddl.SelectedIndex = 0

    End Sub

    Protected Function SetSourceList(ByVal grid As GridView) As List(Of Source)

        Dim sourceList As New List(Of Source)

        For Each row As GridViewRow In grid.Rows
            Dim source As New Source
            Dim ddl As DropDownList = DirectCast(row.FindControl("ddlSourceTypeCode"), DropDownList)
            source.SourceTypeCode = ddl.SelectedValue
            Dim txt As TextBox = DirectCast(row.FindControl("txtSourceID"), TextBox)

            source.SourceID = txt.Text.ToUpper
            sourceList.Add(source)
        Next

        Return sourceList

    End Function

    Protected Sub FillDropDown(ByVal ddl As DropDownList)
        Dim item1 As New ListItem
        Dim item2 As New ListItem
        Dim item3 As New ListItem

        item1.Value = "AA"
        item1.Text = "Alpha"
        ddl.Items.Add(item1)

        item2.Value = "BB"
        item2.Text = "Beta"
        ddl.Items.Add(item2)

        item3.Value = "OO"
        item3.Text = "Omega"
        ddl.Items.Add(item3)
    End Sub

#End Region

    Protected Sub btnSaveGrid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveGrid1.Click, btnSaveGrid2.Click
        Dim btn As Button = DirectCast(sender, Button)
        If btn.ID = "btnSaveGrid1" Then
            ' this is where we wire up to a database
        Else
            ' this is where we wire up to a database
        End If

    End Sub

    Private Sub grdReindex_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdFirstGrid.RowDeleting, grdSecondGrid.RowDeleting
        Dim keepList As New List(Of Source)
        Dim grid As GridView = DirectCast(sender, GridView)
        Dim delRow As GridViewRow = grid.Rows(e.RowIndex)

        For Each row As GridViewRow In grid.Rows
            If Not row.ClientID = delRow.ClientID Then
                Dim keep As New Source
                keep.SourceTypeCode = DirectCast(row.FindControl("ddlSourceTypeCode"), DropDownList).SelectedValue
                keep.SourceID = DirectCast(row.FindControl("txtSourceID"), TextBox).Text.ToUpper
                keepList.Add(keep)

            End If
        Next

        SetCurrentGrid(keepList, grid)

        ' when you use this for real, and don't want the last row to be deletable
        'If grid.Rows.Count = 1 Then
        '    Dim delButton As ImageButton = grid.Rows(0).FindControl("imgbtnDelete")
        '    delButton.Visible = False
        'End If

    End Sub

    Protected Sub SetCurrentGrid(ByVal keepList As List(Of Source), ByVal grid As GridView)
        Dim ddl As New DropDownList
        Dim gridRow As DataRow
        Dim txt As New TextBox
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("SourceTypeCode", GetType(System.Web.UI.WebControls.DropDownList)))
        dt.Columns.Add(New DataColumn("SourceID", GetType(System.Web.UI.WebControls.TextBox)))

        For x As Integer = 0 To keepList.Count - 1
            gridRow = dt.NewRow
            txt.Text = ""
            gridRow.Item(0) = ddl
            gridRow.Item(1) = txt
            dt.Rows.Add(gridRow)
        Next

        grid.DataSource = dt
        grid.DataBind()

        Dim currentRow As Integer = 0
        For Each s As Source In keepList
            ddl = DirectCast(grid.Rows(currentRow).Cells(0).FindControl("ddlSourceTypeCode"), DropDownList)

            FillDropDown(ddl)
            ddl.SelectedValue = s.SourceTypeCode

            txt = DirectCast(grid.Rows(currentRow).Cells(1).FindControl("txtSourceID"), TextBox)
            txt.Text = s.SourceID

            currentRow += 1
        Next


    End Sub
End Class