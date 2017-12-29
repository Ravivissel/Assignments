<%@ Page Title="" Language="C#" MasterPageFile="~/customerMaster.master" AutoEventWireup="true" CodeFile="showProducts.aspx.cs" Inherits="showProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body{
            background-color: #f2f2f2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
            <h2>Welcome to The House Store</h2>
            <asp:Label ID="VeternCustomer" runat="server"></asp:Label><br />
            <asp:PlaceHolder ID="ph" runat="server" />
            <br />            
            <asp:Button ID="SubmitBT" runat="server" Text="Submit" OnClick="SubmitBT_Clicked" />            
            <asp:Button ID="BackBT" runat="server" Text="Back" OnClick="BackBT_Clicked" Visible="false" />
            <br />
            <asp:Label ID="Checkout_Lable" Text="<br/>The Selected Items Are:" runat="server" Visible="false"></asp:Label><br /><br />
<<<<<<< HEAD
            <asp:Button ID="proceedToPayment" runat="server" Text="Proceed To Cart" Visible="false" OnClick="proceedToPayment_Click" /><br /><br />
=======
            <asp:Button ID="proceedToPayment" runat="server" Text="Proceed To Cart" Visible="false" OnClick="proceedToPayment_Click" />
>>>>>>> 41d88bcaa961cf0316dc2ddf7278d5c2638f7a0b
        </div>
</asp:Content>

