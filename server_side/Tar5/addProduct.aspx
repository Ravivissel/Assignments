<%@ Page Title="" Language="C#" MasterPageFile="~/managerMaster.master" AutoEventWireup="true" CodeFile="addProduct.aspx.cs" Inherits="addProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        body{
            background-color: #f2f2f2;
        }
    </style>
    <script>

            function checkNum(src, arg) {
                price = document.getElementById('<%= PriceTB.ClientID %>').value;
            var num = /^[-+]?[0-9]+\.[0-9]+$/;
            if (price.match(num)) {
                arg.IsValid = true;
                return;
            }
            else {
                arg.IsValid = false;
                return;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div>

        <!--Product Name -->
        <p>Enter product name:</p>
        <asp:TextBox ID="NameTB" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
          ControlToValidate="NameTB" runat="server" ErrorMessage="Please enter the product name"
          Style="color: #FF0000"></asp:RequiredFieldValidator>
        
        <!--Product Price -->
        <p>Enter the price without VAT:</p>
        <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
        <asp:CustomValidator ControlToValidate="PriceTB" ID="PriceTBVLD" runat="server" 
          ErrorMessage="Please Enter a decimal number" ClientValidationFunction="checkNum" Style="color: #FF0000"></asp:CustomValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
          ControlToValidate="PriceTB" runat="server" ErrorMessage="Please enter the price without VAT:"
          Style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--Product Category -->
        <p>Select a category:</p>
        <asp:DropDownList ID="categoryDDL" runat="server" DataSourceID="SqlDataSource2"
            AppendDataBoundItems="true"
            DataTextField="Name"
            DataValueField="ID">
        <asp:ListItem Value="none" >Select Category</asp:ListItem>
        </asp:DropDownList><br />
        <asp:RequiredFieldValidator ID="categoryRFL" InitialValue="none"
            ControlToValidate="categoryDDL" ErrorMessage="Please select a category" runat="server" Style="color: #FF0000" />

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:igroup82_test1ConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>

        <!--Product Inventory -->
        <p>Enter the product inventory:</p>
        <asp:TextBox ID="InventoryTB" runat="server"></asp:TextBox>
          <asp:RegularExpressionValidator ID="REVinvemtory" runat="server"
            ControlToValidate="InventoryTB" ValidationExpression="\d+" Display="Static"
            EnableClientScript="true" ErrorMessage="Please enter numbers only" Style="color: #FF0000"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RFVinventory" ControlToValidate="InventoryTB"
             ErrorMessage="Please enter inventory amount" runat="server" Style="color: #FF0000"/> 

        <!--Product Active -->
        <p>Is product active on shop?</p>
        <asp:TextBox ID="activeTB" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
          ControlToValidate="activeTB" runat="server" ErrorMessage="Please enter the product status: Yes or No"
          Style="color: #FF0000"></asp:RequiredFieldValidator><br />

          <p>Upload product image</p>
          <asp:FileUpload ID="imageUpload" runat="server" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
              ControlToValidate="imageUpload" ErrorMessage="Please upload product image" Style="color: #FF0000">
          </asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator 
              id="RegularExpressionValidator1" runat="server" 
              ErrorMessage="please upload an image file" 
              ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif|.jpeg)$" 
              ControlToValidate="imageUpload" Style="color: #FF0000"></asp:RegularExpressionValidator><br />

        <asp:Button runat="server" ID="submitBTN" Text="Submit" OnClick="submitBTN_Click"/><br /><br />
        <asp:Label ID="outLBL" runat="server" Style="color: #FF0000"></asp:Label>
    </div>
</asp:Content>

