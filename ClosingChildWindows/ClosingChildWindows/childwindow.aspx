<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="childwindow.aspx.vb" Inherits="ClosingChildWindows.childwindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Child Window</title>
    
    <script type="text/javascript">
        window.setInterval(function() {
            if (window.opener == null || window.opener.closed) { window.close(); }
        }, 50);
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>I am the child window</h2>
    </div>
    </form>
</body>
</html>
