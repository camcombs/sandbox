<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AddingRowsToGrids._Default" EnableEventValidation="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.6.3/jquery.min.js" type="text/javascript"></script>

    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.15/jquery-ui.min.js" type="text/javascript"></script><head runat="server">
    <title></title>
    <style type="text/css">
        .TextBoxUpperCase
        {
            text-transform: uppercase;
            color: Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnSaveGrid1" runat="server" Text="Save Changes" />
    </div>
    <div>
        <asp:GridView ID="grdFirstGrid" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:TemplateField HeaderText="Del">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete1"  CssClass="jqDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.png"
                            ToolTip="Delete" ></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Source Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSourceTypeCode" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Source ID">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSourceID" runat="server" CssClass="TextBoxUpperCase"></asp:TextBox>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="ButtonAdd1" UseSubmitBehavior="false" runat="server" Text="Add New Row"
                            OnClick="ButtonAdd_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="btnSaveGrid2" runat="server" Text="Save Changes" />
    </div>
    <div>
        <asp:GridView ID="grdSecondGrid" runat="server" AutoGenerateColumns="False" Width="100%"
            ShowFooter="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None"
            BorderWidth="1px" CellPadding="4">
            <RowStyle BackColor="White" ForeColor="#330099" />
            <Columns>
                <asp:TemplateField HeaderText="Del">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnDelete2"  CssClass="jqDelete" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.png"
                            ToolTip="Delete" >
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Source Type">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlSourceTypeCode" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Source ID">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSourceID" runat="server" CssClass="TextBoxUpperCase"></asp:TextBox>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="ButtonAdd2" UseSubmitBehavior="false" runat="server" Text="Add New Row"
                            OnClick="ButtonAdd_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:GridView>
    </div>
    </form>
              <script language="javascript" type="text/javascript">
              $(document).ready(function() {
                  $('.jqDelete').click(function() {
                      return confirm('OK to delete this information?');
                  });
              });
              </script>
             
</body>
</html>
