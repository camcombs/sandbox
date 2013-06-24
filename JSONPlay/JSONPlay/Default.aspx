<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="JSONPlay._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" language="javascript">

    var DocCollection = { DocInfo: [
        {"DocID":"327099","DateReceived":"10/25/2012"},
        
        {"DocID":"327098","DateReceived":"12/05/2012"} 

        ]
    }

    function test() {
        var docList = '';  

        for (index = 0; index < DocCollection.DocInfo.length; index++) {
            docList = docList + DocCollection.DocInfo[index].DocID;            
        }
        alert('testing: ' + docList);

    }

    function AddData() {
        //var jsonString = 'DocCollection = { DocInfo: [{"DocID":"317029","DateReceived":"10/17/2012"}]}';

        //var jsonString = "DocCollection = { DocInfo: [{'DocID':'31452','DateReceived':'10/12/2012'}]}";
        
      var jsonString =  'DocCollection = { DocInfo: [{"DocID":"327099","DateReceived":"10/25/2012"},{"DocID":"327098","DateReceived":"12/05/2012"} ]}';


        var jsonObject = eval(jsonString);
        
//        var tbl = document.getElementById("tblData");
//        var rowcount = tbl.rows.length;
//        var row = table.insertRow(rowcount);        


//        for (index = 0; index < DocCollection.DocInfo.length; index++) {
//            var cell1 = row.insertCell(0);
//            cell1.innerHTML = DocCollection.DocInfo[index].DocID;
//            var cell2 = row.insertCell(1);
//            cell2.innerHTML = DocCollection.DocInfo[index].DateReceived;
//            
//        }

        for (index = 0; index < DocCollection.DocInfo.length; index++) {
            AddRow('tblData', DocCollection.DocInfo[index]);
        }
          
      
    }

    function AddRow(tableID, docInfo) {

        var table = document.getElementById(tableID);
        var rowcount = table.rows.length;
        var row = table.insertRow(rowcount);

        var cell1 = row.insertCell(0);
        cell1.innerHTML = docInfo.DocID;
        var cell2 = row.insertCell(1);
        cell2.innerHTML = docInfo.DateReceived;
    }


    

</script>
<head runat="server">
    <title></title>
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button2" type="button" value="Add Data" onclick="AddData()" />
        <input id="Button1" type="button" value="Test" onclick="test()" />
        <div id="divData">
            <table id="tblData" class="div_outline">
                <thead>
                    <tr>
                        <th>
                            DocID
                        </th>
                        <th>
                            Date Received
                        </th>
                    </tr>
                </thead>
            </table>
            <asp:Table ID="tblData2" runat="server">
            <asp:TableHeaderRow>
            <asp:TableCell>DocID</asp:TableCell>
            <asp:TableCell>Date Received</asp:TableCell>
            </asp:TableHeaderRow>
           
            </asp:Table>
            
            
        </div>


    </div>
    </form>
</body>
</html>
