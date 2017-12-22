<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ShowProductsNew.aspx.cs" Inherits="ShowProductsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
            <asp:PlaceHolder ID="ph" runat="server" />
            <asp:Button ID="SubmitBT" runat="server" Text="submit" OnClick="SubmitBT_Clicked" />
            <asp:Button ID="BackBT" runat="server" Text="Back" OnClick="BackBT_Clicked" Visible="false" />
            <asp:Label ID="Checkout_Lable" Text="<br/>Selected Items:" runat="server" Visible="false"></asp:Label>
        </div>
</asp:Content>

