<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
    <style type="text/css">
        #form1 {
            direction: ltr;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:prodctsDBConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [product]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="productId" HeaderText="productId" InsertVisible="False" ReadOnly="True" SortExpression="productId" />
                <asp:BoundField DataField="categoryId" HeaderText="categoryId" SortExpression="categoryId" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="inventory" HeaderText="inventory" SortExpression="inventory" />
                <asp:ImageField DataImageUrlField="imagePath" ReadOnly="True">
                    <ControlStyle Height="100px" />
                </asp:ImageField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
