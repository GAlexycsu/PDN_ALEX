<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="iOffice.presentationLayer.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/EX03Form1.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
       <table>
        <tr>
            <td style="width:150px">User Name</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Text="" Enabled="False" 
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="style1">Old Password:</td>
          <td class="style1">
              <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPass"  ValidationGroup="groupA" ErrorMessage="Please enter Current password"></asp:RequiredFieldValidator>
           </td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="groupA" ControlToValidate="txtNewPass" ErrorMessage="Please enter New password"></asp:RequiredFieldValidator>
             </td>
        </tr>
        <tr>
            <td>Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ValidationGroup="groupA" ControlToValidate="txtConfirmPass" ErrorMessage="Please enter Confirm  password"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="Password Mismatch"></asp:CompareValidator>
            </td>
        </tr>
   </table>
   
 </div>
        <br />
 <div class="button-wrap" style="width:470px;text-align:center;float:left">
       <asp:Button ID="btnAccept" runat="server" CssClass="button save" ValidationGroup="groupA" Text="Confirm"
           onclick="btnAccept_Click" Width="92px" />&nbsp;<asp:Button ID="btnCancel"
           runat="server" Text="Back" CssClass="button Cancel" onclick="btnCancel_Click" Width="67px" /> </div>
<p style="width:500px;text-align:center;float:left">
    <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label></p>
    </form>
</body>
</html>
