<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Login.aspx.cs" Inherits="WF_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/EX03Form.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <center>    
        <div>            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />            
        </div>
       
        <table>
            <%--<tr>
                <td>
                   Language
                </td>
                <td>
                   <asp:DropDownList ID="DropDownLanguege" runat="server" >
                       <asp:ListItem Value="Default" Text="Default"></asp:ListItem>
                       <asp:ListItem Value="lbl_VN" Text="Tiếng Việt"></asp:ListItem>
                       <asp:ListItem Value="lbl_TW" Text="中文"></asp:ListItem>
                       <asp:ListItem Value="lbl_EN" Text="English"></asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td>
                    UserID
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="*" ControlToValidate="txtUserID" ValidationGroup="groupLogin" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Text="*" ControlToValidate="txtPassword" ValidationGroup="groupLogin" ErrorMessage=""></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
               <td>Remember me
               </td>
               <td>
                   <asp:CheckBox ID="checkRemember" runat="server" />
               </td>
            </tr>
        </table>
        <div>
            <asp:Button runat="server" ID="btnLogin" Text="Login"  ValidationGroup="groupLogin"
                onclick="btnLogin_Click" style="width: 47px" />
                
        &nbsp;<asp:Button ID="btnForgotPass" runat="server" Text="Forgot Password" 
                onclick="btnForgotPass_Click" /></div>
   </center>
   <div style="display:none">    
        <asp:CustomValidator runat="server" ID="cv" ></asp:CustomValidator>
   </div>
   <div>
       <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
   </div>
    </form>
</body>
</html>
