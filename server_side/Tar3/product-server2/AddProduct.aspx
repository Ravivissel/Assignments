<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script>

            function checkNum(src, arg) {
                price = document.getElementById('<%= Price.ClientID %>').value;
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
          ControlToValidate="NameTB" runat="server" ErrorMessage="Please Enter the product Name"
          Style="color: #FF0000"></asp:RequiredFieldValidator>

        <!-- Product Id -->
        <p>Enter product Id:</p>
        <asp:TextBox ID="IdTB" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REVTBProductId" runat="server"
            ControlToValidate="IdTB" ValidationExpression="\d+" Display="Static"
            EnableClientScript="true" ErrorMessage="Please Enter numbers only" Style="color: #FF0000"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RFVTBProductId" runat="server" ControlToValidate="IdTB" 
            ErrorMessage="Please enter a product id" Style="color: #FF0000"></asp:RequiredFieldValidator>
        
        <!--Product Price -->
        <p>Enter the price without VAT:</p>
        <asp:TextBox ID="Price" runat="server"></asp:TextBox>
        <asp:CustomValidator ControlToValidate="Price" ID="PriceTBVLD" runat="server" 
          ErrorMessage="Please Enter a decimal number" ClientValidationFunction="checkNum" Style="color: #FF0000"></asp:CustomValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
          ControlToValidate="Price" runat="server" ErrorMessage="Please Enter the price without VAT:"
          Style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--Product Category -->
        <p>Select Category:</p>
        <asp:DropDownList ID="categoryDDL" runat="server">
        <asp:ListItem Value="none" >Select Category</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>  
        </asp:DropDownList><br />
        <asp:RequiredFieldValidator ID="categoryRFL" InitialValue="none"
            ControlToValidate="categoryDDL" ErrorMessage="Please select a category" runat="server" Style="color: #FF0000" />

        <!--Product Inventory -->
        <p>Enter product Inventory:</p>
        <asp:TextBox ID="InventoryTB" runat="server"></asp:TextBox>
          <asp:RegularExpressionValidator ID="REVinvemtory" runat="server"
            ControlToValidate="InventoryTB" ValidationExpression="\d+" Display="Static"
            EnableClientScript="true" ErrorMessage="Please enter numbers only" Style="color: #FF0000"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RFVinventory" ControlToValidate="InventoryTB"
             ErrorMessage="Please enter inventory amount" runat="server" Style="color: #FF0000"/> 
      

        <!--Product Description -->
        <p>Enter product description:</p>
        <asp:TextBox runat="server" ID="desc" Height="100px" Width="300px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
          ControlToValidate="desc" runat="server" ErrorMessage="Please Enter the product description"
          Style="color: #FF0000"></asp:RequiredFieldValidator><br />

        <asp:Button runat="server" ID="submitBTN" Text="Submit" OnClick="submitBTN_Click"/><br /><br />
        <asp:Label ID="outLBL" runat="server"></asp:Label>
    </div>
</asp:Content>

