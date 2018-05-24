<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WF_ChangePassword.aspx.cs" Inherits="iOffice.presentationLayer.WF_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/EX03Form1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:500px;text-align:center;float:left">
   <table>
        <tr>
            <td>User Name</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Text="" Enabled="False" 
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="style1">Old Password:</td>
          <td class="style1">
              <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
   </table>
   
 </div>
 <p style="width:500px;text-align:center;float:left">
       <asp:Button ID="btnAccept" runat="server" Text="Confirm" 
           onclick="btnAccept_Click" style="height: 26px" />&nbsp;<asp:Button ID="btnCancel"
           runat="server" Text="Cancel" onclick="btnCancel_Click" /> </p>
<p style="width:500px;text-align:center;float:left">
    <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label></p>
    </div>
    </form>
</body>
</html>
