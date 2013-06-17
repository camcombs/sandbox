    Protected Function GetPgmRid(ByVal pgmCode As String)
        Dim pgm As PgmEntity = New PgmEntity
        Dim pgmBLL As PgmBLL = New PgmBLL
        pgm.Code = pgmCode
        Dim res As Result
        res = pgmBLL.Read(pgm)
        pgm = res.Entity

        Return pgm.Rid
    End Function
	
	
	    Protected Sub ResetDropDownList(ByVal ddl As DropDownList)
        For x As Integer = ddl.Items.Count - 1 To 0 Step -1
            ddl.Items.RemoveAt(x)
        Next
    End Sub
	
	    Public Sub FillDocTypes(ByVal ddl As DropDownList, ByVal pgmCode As String)
        Dim result As Entities.Result
        Dim queryObj As QueryBLL = New QueryBLL()
        ' load doc cats and doc types
        Dim pgmDocCat As PgmCatTypeEntity = New PgmCatTypeEntity()
        pgmDocCat.PgmCode = pgmCode

        result = queryObj.ReadDocCategoriesByPgmCode(pgmDocCat)
        ResetDropDownList(ddl)

        For Each doccat As DocCatEntity In result.Entity
            For Each docType As DocTypeEntity In doccat.DocTypeCollection
                Dim item As New ListItem
                item.Text = docType.NameText
                item.Value = docType.Rid
                ddl.Items.Add(item)
            Next

        Next
    End Sub
	
	
	    Public Function GetProgramArea() As String
        Dim result As Entities.Result
        Dim queryObj As QueryBLL = New QueryBLL()
        Dim pgmEntity As PgmEntity = New PgmEntity

        pgmEntity.Code = docs(0).ProgramCode
        result = queryObj.ReadPgm(pgmEntity)
        If result.Success Then
            Return result.Entity.NameText()
        Else
            Return "Unknown"
        End If
    End Function
	
	   Public Function GetRouting(ByVal docId As String)
        Dim route As Boolean = False
        'TODO:
        Dim docBLL As DocumentBLL = New DocumentBLL
        Dim docEntt As DocEntity = New DocEntity
        docEntt.DocId = docId
        Dim result As Result
        result = docBLL.Read(docEntt)
        If result.Success Then
            docEntt = CType(result.Entity, DocEntity)
        End If
        route = docEntt.RouteFlag

        Return route
    End Function
	
	
	
	'  close window pattern aspx page
	<script>
	var requestRid;
    var doUnlock;
    requestRid = '<%= rqstRid %>';
    doUnlock = '<%= releaseLock %>';
    
    function OnUnload() {
        setScreenCookies(SCRN_REDACT, ON_UNLOAD_EVENT);
       // debugger;
        if (requestRid > 0) {
            if (doUnlock == 1) {
                UnlockRequest(requestRid);
            }
        }
    }

    function SetNoUnlock() {
       // debugger;
        doUnlock = 0;
        return true;
    }
	
	</script>
	...
	        <table style="width:100%">
            <tr>
                <td>
                    <asp:Button ID="btnApprove" runat="server" Text="Approve" ToolTip="Approve Redact Request" OnClientClick="javascript:SetNoUnlock()" />
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save Changes" OnClientClick="javascript:SetNoUnlock()" />
                </td>
                <td>
                    <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="Reject Redact Request" OnClientClick="javascript:SetNoUnlock()" />
                </td>
                <td>
                <button id="btnCloseM" title="Close" value="Close" onclick="CloseWindow()">
                </button>
                </td>
            </tr>
        </table>
		
---- code behind
-- global variables
    Public rqstRid As Integer          ' used in unlock javascript functions
    Public releaseLock As Integer = 1  ' true, used in javascript functions
	
	_load()
	if not ispostback
	            If action = "Request" Then
                releaseLock = 0
	
	...
	Else  'ispostback
	        Dim selDocManagementList As List(Of SelectedDocManagement) = Session("SelectedDocManagements")
            Dim selDocManagement As new SelectedDocManagement
            If selDocManagement IsNot Nothing Then
                selDocManagement = selDocManagementList(0)
                rqstRid = selDocManagement.DocManagementRequestRid
            End If
        End If

-- submit_click()

            If result.Success Then
                lblResultMsg.Text = "Redact Request Submitted"
                releaseLock = 0
                ClientScript.RegisterStartupScript(Page.GetType(), "Submit_DMSRedact", "window.close();", True)
            Else
                lblResultMsg.Text = result.Message
            End If

-- approve_click(), save_click(), reject_click()
            If myResult.Success Then
                lblResultMsg.Text = "Redact Request Approved"
                releaseLock = 0
                ClientScript.RegisterStartupScript(Page.GetType(), "Approve_DMSRedact", "window.close();", True)
            Else
                lblResultMsg.Text = myResult.Message
            End If
			

	