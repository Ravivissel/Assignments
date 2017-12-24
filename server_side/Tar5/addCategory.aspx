<%@ Page Title="" Language="C#" MasterPageFile="~/managerMaster.master" AutoEventWireup="true" CodeFile="addCategory.aspx.cs" Inherits="addCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
            <!--Categories -->
            <p>Existing categories:</p>
            <asp:DropDownList ID="categoryDDL" runat="server"
            DataTextField="Name"
            DataValueField="Name">
            </asp:DropDownList><br /><br />

            <!--New Category -->
            <p>Enter a new category:</p>
            <asp:TextBox ID="categoryTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
             ControlToValidate="categoryTB" runat="server" ErrorMessage="Please enter the new category"
             Style="color: #FF0000"></asp:RequiredFieldValidator><br /><br />

            <asp:Button runat="server" ID="submitBTN" Text="Submit" OnClick="submitBTN_Click"/><br /><br />
    </div>
</asp:Content>

