<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="showSales.aspx.cs" Inherits="showSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:DropDownList ID="DropDownList1"
        runat="server"
        DataSourceID="SqlDataSource2"
        AppendDataBoundItems="true"
        DataTextField="Name"
        DataValueField="Name" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="All">All</asp:ListItem>
    </asp:DropDownList>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:igroup82_test1ConnectionString %>" SelectCommand="SELECT * FROM [Sales]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:igroup82_test1ConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
    <asp:GridView CssClass="responstable" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Referance,prodID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Referance" HeaderText="Referance" InsertVisible="False" ReadOnly="True" SortExpression="Referance" />
            <asp:BoundField DataField="prodID" HeaderText="prodID" ReadOnly="True" SortExpression="prodID" />
            <asp:BoundField DataField="QTY" HeaderText="QTY" SortExpression="QTY" />
            <asp:BoundField DataField="custID" HeaderText="custID" SortExpression="custID" />
            <asp:BoundField DataField="DATE" HeaderText="DATE" SortExpression="DATE" />
            <asp:BoundField DataField="lineTotal" HeaderText="lineTotal" ReadOnly="True" SortExpression="lineTotal" />
            <asp:BoundField DataField="paymentType" HeaderText="paymentType" SortExpression="paymentType" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>

</asp:Content>
