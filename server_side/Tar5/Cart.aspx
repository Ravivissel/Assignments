<%@ Page Title="" Language="C#" MasterPageFile="~/customerMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="msgLBL" runat="server"></asp:Label><br />
        <asp:PlaceHolder ID="ph" runat="server" />
        <asp:Label ID="finalPrice" runat="server"></asp:Label><br /><br />
        <asp:Button ID="confirm" runat="server" Text="Confirm" Visible="false" OnClick="confirm_Click" /><br /><br /><br />
    </div>
</asp:Content>

