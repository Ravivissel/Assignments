<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <script src="jquery-3.2.1.min.js"></script>


</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:igroup82_test1ConnectionString %>" DeleteCommand="DELETE FROM [productN] WHERE [ID] = @original_ID" InsertCommand="INSERT INTO [productN] ([Name], [Price], [isActive], [catID], [Inventory], [imgURL]) VALUES (@Name, @Price, @isActive, @catID, @Inventory, @imgURL)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Name], [Price], [isActive], [catID], [Inventory], [imgURL] FROM [productN]" UpdateCommand="UPDATE [productN] SET [isActive] = @isActive, [Inventory] = @Inventory WHERE [ID] = @original_ID">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" />
            <asp:Parameter Name="Price" />
            <asp:Parameter Name="isActive" Type="Int32" />
            <asp:Parameter Name="catID" />
            <asp:Parameter Name="Inventory" Type="Int32" />
            <asp:Parameter Name="imgURL" />
        </InsertParameters>
        <UpdateParameters>

            <asp:Parameter Name="isActive" Type="Int32" />
            <asp:Parameter Name="Inventory" Type="Int32" />

            <asp:Parameter Name="original_ID" />

        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView CssClass="responstable" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" CancelImageUrl="~/images/cancel.png" EditImageUrl="~/images/edit-icon-png-24.png"  UpdateImageUrl="~/images/confirm.png" ButtonType="Image"/>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ReadOnly="True" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ReadOnly="True" />
            <asp:BoundField DataField="isActive" HeaderText="isActive" SortExpression="isActive" />
            <asp:BoundField DataField="catID" HeaderText="catID" SortExpression="catID" ReadOnly="True" />
            <asp:BoundField DataField="Inventory" HeaderText="Inventory" SortExpression="Inventory" />
            <asp:ImageField DataImageUrlField="imgURL" ControlStyle-CssClass="dataGridImages" ReadOnly="True" NullImageUrl="~/images/replacement.jpg" >
            </asp:ImageField>
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
