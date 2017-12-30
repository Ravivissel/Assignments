<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/managerMaster.master" CodeFile="inventoryManagement.aspx.cs" Inherits="inventoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <script src="jquery-3.2.1.min.js">
    </script>
    <script>
        function isActiveValid(src, arg) {
            if (arg.Value == 'Yes' || arg.Value == 'No') {
                arg.IsValid = true;
            }
            else {
                arg.IsValid = false;
            }
        }
        function InventoryValid(src, arg) {
            if (arg.Value > 0) {
                arg.IsValid = true;
            }
            else
                arg.IsValid = false;
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource OnSelected="SqlDataSource1_Selected" ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:igroup82_test1ConnectionString %>"
        OldValuesParameterFormatString="original_{0}"
        SelectCommand="SELECT [ID], [Name], [Price], [isActive], [catID], [Inventory], [imgURL] FROM [productN]"
        UpdateCommand="UPDATE [productN] SET [isActive] = @isActive, [Inventory] = @Inventory WHERE [ID] = @original_ID">

        <UpdateParameters>
            <asp:Parameter Name="isActive" />
            <asp:Parameter Name="Inventory" Type="Int32" />
            <asp:Parameter Name="original_ID" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView CssClass="responstable" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" CancelImageUrl="~/images/cancel.png" EditImageUrl="~/images/edit-icon-png-24.png" UpdateImageUrl="~/images/confirm.png" ButtonType="Image" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ReadOnly="True" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" ReadOnly="True" />
            <asp:TemplateField HeaderText="isActive" SortExpression="isActive">
                <EditItemTemplate>
                    <asp:TextBox ID="isActiveTB" runat="server" Text='<%# Bind("isActive", "{0}") %>' Width="45px"></asp:TextBox>
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="isActiveValid" Style="color: #FF0000" ControlToValidate="isActiveTB" ErrorMessage="Must be Yes or No"></asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("isActive") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="catID" HeaderText="catID" SortExpression="catID" ReadOnly="True" />
            <asp:TemplateField HeaderText="Inventory" SortExpression="Inventory">
                <EditItemTemplate>
                    <asp:TextBox ID="InventoryTB" runat="server" Text='<%# Bind("Inventory") %>' Height="24px" Width="56px"></asp:TextBox>
                    <br />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please Enter Numbers Only"
                        Type="Double" MinimumValue="0" MaximumValue="9999999999" ControlToValidate="InventoryTB" Style="color: #FF0000"></asp:RangeValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Must be greater then 0" Style="color: #FF0000" ClientValidationFunction="InventoryValid" ControlToValidate="InventoryTB"></asp:CustomValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Inventory") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ImageField DataImageUrlField="imgURL" ControlStyle-CssClass="dataGridImages" ReadOnly="True" NullImageUrl="~/images/replacement.jpg">
                <ControlStyle CssClass="dataGridImages"></ControlStyle>
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
