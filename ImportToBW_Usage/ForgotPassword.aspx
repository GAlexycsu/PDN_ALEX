<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<link href="Styles/EX03Form.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
