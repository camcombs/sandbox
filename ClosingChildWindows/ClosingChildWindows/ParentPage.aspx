<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ParentPage.aspx.vb" Inherits="ClosingChildWindows.ParentPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Opener() {
            window.open('childwindow.aspx', 'child');
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnOpenChild" runat="server" Text="Open Child" />
        <button id="btnOpen" title="OpenChild" onclick="Opener()"></button>
    </div>
    </form>
</body>
</html>
