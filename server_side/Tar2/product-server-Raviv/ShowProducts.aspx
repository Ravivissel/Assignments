<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="ph" runat="server" />
            <asp:Button ID="SubmitBT" runat="server" Text="submit" OnClick="SubmitBT_Clicked" />
            <asp:Button ID="BackBT" runat="server" Text="Back" OnClick="BackBT_Clicked" Visible="false" />
            <asp:Label ID="Checkout_Lable" Text="<br/>Selected Items:" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
