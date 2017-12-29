<%@ Page Title="" Language="C#" MasterPageFile="~/customerMaster.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
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
   
           </td>
       </tr>

        
       <tr>
           <td>
   <!--Address-->
   <p>Address:</p>
   <asp:TextBox ID="addressTB" runat="server"></asp:TextBox>
   <br />
   
           </td>
       </tr>
       <tr>
           <td>
   <!--E-Mail-->
   <p>E-Mail:</p>
   <asp:TextBox ID="Email_TB" runat="server"></asp:TextBox>
   
   <br />
  
           </td>
       </tr>
       <tr>
           <td>
   <!--Date For Shipment-->
   <p>Date For Shipment:</p>
   <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
   

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
            <input type="checkbox" id="CreditCB" name="credit" onclick="credit_checked()" class="checkBoxClass" runat="server"/>
            With Credit Card  
         </td>
         <td>
            <input type="checkbox" id="PhoneCB" name="Phone" onclick="tel_checked()" class="checkBoxClass" runat="server"/>
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
           
            <br />
         </td>
         <td>
            <!--With Telephone-->

            <!--Phone Number-->
            <p id="Phone_Number" style="visibility: hidden">Phone Number:</p>
            <input type="text" id="phoneNumberTB" runat="server" style="visibility: hidden"  />
            
         </td>
      </tr>
      <tr>
         <td>
            <!--Credit Card Number-->
            <p id="Credit_Card_Number" style="visibility: hidden">Credit Card Number:</p>
            <input type="text" id="CreditCardTB" runat="server" style="visibility: hidden" />
            
            <br />
           
         </td>
      </tr>
      <tr>
         <td>
            <!--ID-->
            <p id="ID" style="visibility: hidden">ID:</p>
            <input type="text" id="idTB" runat="server" style="visibility: hidden" />
          
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
            
            <br />
            <br />
            <p id="sigImg">Signature Image:</p>
            <asp:FileUpload ID="imageUpload" runat="server" />
           
            <br />
            <asp:Image ID="imgsign" runat="server" /><br />
            <asp:Button runat="server" ID="submitBTN" Text="Submit" OnClick="submitBTN_Click1"/><br /><br />
            <br />
         </td>
      </tr>
   </table>
</asp:Content>

