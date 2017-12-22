<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertProducts.aspx.cs" Inherits="insertProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        * {
    font-family: sans-serif;
}
    </style>
</head>
<body dir="rtl">
    <form id="form1" runat="server" dir="rtl">
        <h1>הכנסת מוצר חדש למערכת</h1>
        <table style="width: 70%;">
            <tr>
                <td>שם המוצר:</td>
                <td><asp:TextBox ID="prodNameTB" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                      ControlToValidate="prodNameTB" runat="server" ErrorMessage="נא הזן שם מוצר"
                      Style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>מחיר:</td>
                <td><asp:TextBox ID="prodPriceTB" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                      ControlToValidate="prodPriceTB" runat="server" ErrorMessage="נא הזן מחיר מוצר"
                      Style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>תמונה:</td>
                <td><asp:FileUpload ID="imageUpload" runat="server" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                      ControlToValidate="prodPriceTB" runat="server" ErrorMessage="אנא העלה את תמונת המוצר"
                      Style="color: #FF0000"></asp:RequiredFieldValidator>
                </td>
                <td>
                     <asp:RegularExpressionValidator 
                     id="RegularExpressionValidator1" runat="server" 
                     ErrorMessage="אנא העלה קובץ תמונה" 
                     ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$" 
                     ControlToValidate="imageUpload" Style="color: #FF0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>בחר קטגוריה:</td>
                <td>
                    <asp:DropDownList ID="categoryDDL" runat="server">
                        <asp:ListItem Value="none" >בחר שם קטגוריה</asp:ListItem>
                        <asp:ListItem Value="1">chair</asp:ListItem>
                        <asp:ListItem Value="2">table</asp:ListItem>
                        <asp:ListItem Value="3">armchair</asp:ListItem>
                        <asp:ListItem Value="4">bed</asp:ListItem>
                        <asp:ListItem Value="5">carpet</asp:ListItem>
                        <asp:ListItem Value="6">shelf</asp:ListItem>
                        <asp:ListItem Value="7">sofa</asp:ListItem>
                        <asp:ListItem Value="8">stool</asp:ListItem>
                        <asp:ListItem Value="9">wardrobe</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="categoryRFL" InitialValue="none"
                        ControlToValidate="categoryDDL" ErrorMessage="אנא בחר את שם הקטגוריה" runat="server" Style="color: #FF0000" />
                </td>
            </tr>
            <tr>
                <td>בחר מלאי:</td>
                <td>
                    <asp:DropDownList ID="inventoryDDL" runat="server">
                        <asp:ListItem Value="none" >בחר כמות למלאי</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="none"
                     ControlToValidate="inventoryDDL" ErrorMessage="אנא בחר כמות למלאי" runat="server" Style="color: #FF0000" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td><asp:Button ID="submitButton" runat="server" Text="הוסף לרשימת המוצרים" OnClick="submitButton_Click" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:Label ID="prodMessage" runat="server" Text=""></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
