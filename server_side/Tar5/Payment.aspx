<%@ Page Title="" Language="C#" MasterPageFile="~/customerMaster.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
      function validateLength(src, arg) { 
          if (arg.Value.length != 10) {
              arg.IsValid = false;
          }
      }
      
      function ID_Validation(src, arg) {
          id = arg.Value;
          if (id.length != 9) {
              arg.IsValid = false;
              return;
          }
          var n = Valid_Number(src, arg);
          if (n == 0) {
              arg.IsValid = false;
              return;
          }
          if (id[id.length] != (id % 7)) {
              arg.IsValid = false;
              return;
          }
          else
              arg.IsValid = true;
      }
      function Date_Validator(src, arg) {
          if(arg.SelectedDate< DateTime.Now())
              arg.IsValid = false;
          else
              arg.IsValid = true;
      }
      
      function Valid_Number(source, arguments) {
          var numbers = /^[0-9]+$/;
          if (arguments.Value.match(numbers)) {
              alert('The ID You Have Enterd Is Incorrect');
              return 0;
          }
          else
              return 1;
      }
      
      function tel_checked() {
          $("#CreditCB").prop('checked', false);
          if ($("#PhoneCB").prop('checked', true)) {
              document.getElementById("Phone_Number").style.visibility = "visible";
              document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("phoneNumberTB").ClientID %>').style.visibility = "visible";
              document.getElementById("Number_Of_Payments").style.visibility = "hidden";
              document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("paymentsDDL").ClientID %>').style.visibility = "hidden";
              document.getElementById("Credit_Card_Number").style.visibility = "hidden";
              document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("CreditCardTB").ClientID %>').style.visibility = "hidden";
              document.getElementById("ID").style.visibility = "hidden";
              document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("idTB").ClientID %>').style.visibility = "hidden";
              document.getElementById("Credit_Card_Type").style.visibility = "hidden";
              document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("creditTypeDDL").ClientID %>').style.visibility = "hidden";
          }
          }
      
       function credit_checked() {
           $("#PhoneCB").prop('checked', false);
           if ($("#CreditCB").prop('checked', true)) {
               document.getElementById("Number_Of_Payments").style.visibility = "visible";
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("paymentsDDL").ClientID %>').style.visibility = "visible";
               document.getElementById("Credit_Card_Number").style.visibility = "visible";
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("CreditCardTB").ClientID %>').style.visibility = "visible";
               document.getElementById("ID").style.visibility = "visible";
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("idTB").ClientID %>').style.visibility = "visible";
               document.getElementById("Credit_Card_Type").style.visibility = "visible";
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("creditTypeDDL").ClientID %>').style.visibility = "visible";
               document.getElementById("Phone_Number").style.visibility = "hidden";
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("PhoneNumberTB").ClientID %>').style.visibility = "hidden";              
               document.getElementById('<%= Page.Master.FindControl("ContentPlaceHolder1").FindControl("phoneNumberVLD").ClientID %>');           }
       }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="finalPrice" runat="server"></asp:Label><br /><br />
   <table>  
       <tr>
           <td>
   <!--Full Name-->
   <p>Full Name:</p>
   <asp:TextBox ID="fullNameTB" runat="server"></asp:TextBox>
   <br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
      ControlToValidate="fullNameTB" runat="server" ErrorMessage="Please Enter Your Full Name"
      Style="color: #FF0000"></asp:RequiredFieldValidator>
           </td>
       </tr>
       <tr>
           <td>
   <!--Address-->
   <p>Address:</p>
   <asp:TextBox ID="addressTB" runat="server"></asp:TextBox>
   <br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
      ControlToValidate="addressTB" runat="server" ErrorMessage="Please Enter Your Address"
      Style="color: #FF0000"></asp:RequiredFieldValidator>
           </td>
       </tr>
       <tr>
           <td>
   <!--E-Mail-->
   <p>E-Mail:</p>
   <asp:TextBox ID="Email_TB" runat="server"></asp:TextBox>
   <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
      ControlToValidate="Email_TB" runat="server"
      ErrorMessage="Please Enter A Valid E-Mail Address"
      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
      Style="color: #FF0000"></asp:RegularExpressionValidator>
   <br />
   <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
      ControlToValidate="Email_TB" runat="server" ErrorMessage="Please Enter A E-Mail Address"
      Style="color: #FF0000"></asp:RequiredFieldValidator>
           </td>
       </tr>
       <tr>
           <td>
   <!--Date For Shipment-->
   <p>Date For Shipment:</p>
   <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
      ControlToValidate="addressTB" runat="server" ErrorMessage="Please Enter Your Address"
      Style="color: #FF0000"></asp:RequiredFieldValidator>

   <!--Bonus: Add A Validator On The Calendar-->
   <br />
           </td>
       </tr>
       <tr>
           <td>
   <!--Payment-->
   <p>Payment:</p>
   <!--This is the hidden part of the page!-->
           </td>
       </tr>

      <tr>
         <td>
            <input type="checkbox" id="CreditCB" name="credit" onclick="credit_checked()" class="checkBoxClass"/>
            With Credit Card  
         </td>
         <td>
            <input type="checkbox" id="PhoneCB" name="Phone" onclick="tel_checked()" class="checkBoxClass" />
            With Telephone
            <br />
         </td>
      </tr>
      <tr>
          <td>
            <!--Credit Card Type-->
            <p id="Credit_Card_Type" style="visibility: hidden">Credit Card Type:</p>
            <select id="creditTypeDDL" name="Select Credit Card Type" runat="server" style="visibility: hidden">
               <option value="none" selected="selected" disabled="disabled">Select Credit Card Type</option>
               <option value="1">Master Card</option>
               <option value="2">Visa</option>
               <option value="3">American Express</option>
            </select>
            <br />
            <br />
            <asp:RequiredFieldValidator ID="creditRFL" InitialValue="none"
               ControlToValidate="creditTypeDDL" ErrorMessage="Please Choose Credit Card Type" runat="server" Style="color: #FF0000" />
            <br />
         </td>
         <td>
            <!--With Telephone-->

            <!--Phone Number-->
            <p id="Phone_Number" style="visibility: hidden">Phone Number:</p>
            <input type="text" id="phoneNumberTB" runat="server" style="visibility: hidden"  />
            <asp:CustomValidator  ID="phoneNumberVLD" runat="server" 
               ControlToValidate="phoneNumberTB" ErrorMessage="You Must Enter A 10 Digits Number" ClientValidationFunction="validateLength"
               Style="color: #FF0000"></asp:CustomValidator>
            <br />
            <asp:RequiredFieldValidator  ID="RequiredFieldValidator4" 
               ControlToValidate="phoneNumberTB" runat="server" ErrorMessage="Please Enter A Phone Number"
               Style="color: #FF0000"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please Enter Numbers Only" 
               Type="Double" MinimumValue="0" MaximumValue="9999999999" ControlToValidate="phoneNumberTB" Style="color: #FF0000"></asp:RangeValidator>
         </td>
      </tr>
      <tr>
         <td>
            <!--Credit Card Number-->
            <p id="Credit_Card_Number" style="visibility: hidden">Credit Card Number:</p>
            <input type="text" id="CreditCardTB" runat="server" style="visibility: hidden" />
            <asp:RegularExpressionValidator  ID="creditNumREV" ForeColor="Red" 
               runat="server" ControlToValidate="CreditCardTB"
               ValidationExpression="^((4\d{3})|(5[1-5]\d{2})|(6011))-?\d{4}-?\d{4}-?\d{4}|3[4,7][\d\s-]{13}$"
               ErrorMessage="Please enter  A Valid Number"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
               ControlToValidate="CreditCardTB" runat="server" ErrorMessage="Please Enter Credit Card Number"
               Style="color: #FF0000"></asp:RequiredFieldValidator>
         </td>
      </tr>
      <tr>
         <td>
            <!--ID-->
            <p id="ID" style="visibility: hidden">ID:</p>
            <input type="text" id="idTB" runat="server" style="visibility: hidden" />
            <asp:CustomValidator ControlToValidate="idTB"
               ID="idTBVLD" runat="server" ErrorMessage="Please Enter A Valid ID"
               ClientValidationFunction="ID_Validation" Style="color: #FF0000"></asp:CustomValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
               ControlToValidate="idTB" runat="server" ErrorMessage="Please Enter A 9 Digits ID"
               Style="color: #FF0000"></asp:RequiredFieldValidator>
         </td>
      </tr>
      <tr>
         <td>
            <!--With Credit Card-->

            <!--Number Of Payments-->
            <p id="Number_Of_Payments" style="visibility: hidden">Number Of Payments:</p>
            <select id="paymentsDDL" name="Select Payments" runat="server" style="visibility: hidden">
               <option value="none" selected="selected" disabled="disabled">Select Payments</option>
               <option value="1">1</option>
               <option value="2">2</option>
               <option value="3">3</option>
               <option value="4">4</option>
            </select>
            <br />
            <asp:RequiredFieldValidator ID="paymentsRFL" InitialValue="none" 
               ControlToValidate="paymentsDDL" ErrorMessage="Please Choose Number Of Payments" runat="server" Style="color: #FF0000" />
            <br />
            <br />
            <p id="sigImg">Signature Image:</p>
            <asp:FileUpload ID="imageUpload" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                ControlToValidate="imageUpload" ErrorMessage="Please upload your signature!" Style="color: #FF0000">
            </asp:RequiredFieldValidator>
            <br />
            <asp:Image ID="imgsign" runat="server" /><br />
            <asp:Button runat="server" ID="submitBTN" Text="Submit" OnClick="submitBTN_Click1"/><br /><br />
            <br />
         </td>
      </tr>
   </table>
</asp:Content>

