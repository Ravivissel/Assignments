<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ShowProducts.aspx.cs" Inherits="ShowProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            <asp:Button ID="proceedToPayment" runat="server" Text="Proceed To Cart" Visible="false" OnClick="proceedToPayment_Click" />
        </div>
</asp:Content>

