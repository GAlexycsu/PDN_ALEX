<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotPassword.aspx.cs" Inherits="iOffice.presentationLayer.forgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/EX03Form1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
      <table>
         <tr>
               <td> 
                   User Name:
               </td>
               <td> 
                   <asp:TextBox ID="txtUser" runat="server" Width="214px"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="GroupA" ControlToValidate="txtUser" runat="server" ErrorMessage="" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
               </td>
         </tr>
        
      </table>
    </div>
     <p style="width:380px;text-align:center;float:left">
         <asp:Button ID="btnSend" runat="server" ValidationGroup="GroupA" Text="Sent Request" 
             onclick="btnSend_Click" /> &nbsp; 
         <asp:Button ID="btnCancel" runat="server" Text="Back" 
             onclick="btnCancel_Click" /></p>
    <p style="width:500px;text-align:center;float:left">
        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
    </p>
    </form>
</body>
</html>
