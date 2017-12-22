<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Page</title>
       <script>
           function validateLength(src, arg) { // src is the element that the control is validating, arg has 2 properties, Value and IsValid.
               if (arg.Value.length != 10) {
                   arg.IsValid = false;
               }
           }

           function validateID(src, arg) { // this function is unfinished
                   arg.IsValid = false;
           }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <!--Full Name-->
        <p>Full Name:</p>
        <asp:TextBox ID="fullNameTB" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="fullNameTB" runat="server" ErrorMessage="Please Enter Your Full Name" 
            style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--Address-->
        <p>Address:</p>
        <asp:TextBox ID="addressTB" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="addressTB" runat="server" ErrorMessage="Please Enter Your Address" 
            style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--E-Mail-->
        <p>E-Mail:</p>
        <asp:TextBox ID="Email_TB" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            ControlToValidate="Email_TB" runat="server" 
            ErrorMessage="Please Enter A Valid E-Mail Address" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            style="color: #FF0000"></asp:RegularExpressionValidator> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
            ControlToValidate="Email_TB" runat="server" ErrorMessage="Please Enter A E-Mail Address" 
            style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--Date For Shipment-->    
        <p>Date For Shipment:</p>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar> <br />
        <!--Bonus: Add A Validator On The Calendar-->
        
        <!--Payment--> 
        <p>Payment:</p>
        <asp:CheckBox ID="CreditCB" runat="server" OnCheckedChanged="CreditCB_CheckedChanged" />  With Credit Card 
        <asp:CheckBox ID="PhoneCB" runat="server" OnCheckedChanged="PhoneCB_CheckedChanged" /> With Telephone <br />

        <!--This is the hidden part of the page!--> 

        <!--Phone Number-->
        <p id="Phone_Number" style="visibility:hidden">Phone Number:</p>
        <asp:TextBox Visible="false" ID="phoneNumberTB" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="phoneNumberVLD" runat="server" 
            ControlToValidate="phoneNumberTB" ErrorMessage="You Must Enter A 10 Digits Number" ClientValidationFunction = "validateLength"
            style="color: #FF0000"></asp:CustomValidator><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
            ControlToValidate="phoneNumberTB" runat="server" ErrorMessage="Please Enter A Phone Number" 
            style="color: #FF0000"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please Enter Numbers Only"
            Type="Double" MinimumValue="0" MaximumValue="9999999999" ControlToValidate="phoneNumberTB" style="color: #FF0000"></asp:RangeValidator>

        <!--Number Of Payments-->
        <p id="Number_Of_Payments" style="visibility:hidden">Number Of Payments:</p>
        <asp:DropDownList Visible="false" ID="paymentsDDL" runat="server" >
            <asp:ListItem Enabled="true" Text="Select Payments" Value="-1"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
        </asp:DropDownList> <br />

        <!--Credit Card Number-->
        <p id="Credit_Card_Number" style="visibility:hidden">Credit Card Number:</p>
        <asp:TextBox Visible="false" ID="CreditCardTB" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
            ControlToValidate="CreditCardTB" runat="server" ErrorMessage="Please Enter Credit Card Number" 
            style="color: #FF0000"></asp:RequiredFieldValidator>

        <!--ID-->
        <p id="ID" style="visibility:hidden">ID:</p>
        <asp:TextBox Visible="false" ID="idTB" runat="server"></asp:TextBox> <br />
        <asp:CustomValidator ID="idVLD" runat="server" ControlToValidate="idTB" 
            ErrorMessage="Please Enter A Valid ID" ClientValidationFunction="validateID" style="color: #FF0000"></asp:CustomValidator>

        <!--Credit Card Type-->
        <p id="Credit_Card_Type" style="visibility:hidden">Credit Card Type:</p>
        <asp:DropDownList Visible="false" ID="creditTypeDDL" runat="server">
            <asp:ListItem Enabled="true" Text="Select Credit Card Type" Value="-1"></asp:ListItem>
            <asp:ListItem Text="Master Card" Value="1"></asp:ListItem>
            <asp:ListItem Text="Visa" Value="2"></asp:ListItem>
            <asp:ListItem Text="American Express" Value="3"></asp:ListItem>
        </asp:DropDownList> <br /> <br />
        <asp:Button ID="submit" runat="server" Text="Submit" />
        <br />

    </form>
</body>
</html>
