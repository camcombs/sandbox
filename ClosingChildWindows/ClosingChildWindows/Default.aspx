<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="ClosingChildWindows._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    

<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <button id="open">Open</button>
    <button id="open2">Open2</button>
    <button id="close">Close</button>
    
    <asp:HiddenField runat="server" ID="numWin" Value="2"/>
    
    </form>
</body>
<script type="text/javascript" >
    var nameOfWindow = "myTestWindow";
    var nameofSecondWindow = "secondwindow";

    $(document).ready(function() {
//        $('#open').click(function() {
//            window.open("childwindow.aspx", nameOfWindow);
//            document.cookie = "num" + "=" + "0";
//        });

        $('#open2').click(function() {
            window.open("http://coderincomplete.com/", nameofSecondWindow);
            document.cookie = "num" + "=" + "1";
        });
        
        $('#close').click(function() {
            window.close;
            }
        

//        $('#close').click(function() {
//            var fld = document.getElementById("numWin");
//            var num = fld.value;
//            for (var x = 0; x < num - 1; x++) {
//                var key = x.toString();
//                var nom = getcookie(key);

//            }
//            var closer = window.open("", nameOfWindow);
//            closer.close();
//            closer = window.open("", "secondwindow");
//            closer.close();
//        });
    });

   
     
    </script>
</html>
