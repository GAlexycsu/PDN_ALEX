<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iOffice.presentationLayer.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
      <meta name="keyword" content="Ty Hung footgear " />
    <meta name="Description" content="Công ty THNN Tỷ Hùng - footgear chuyên sản xuất các loại dày xuất khẩu" />
    <link href="../Style/EX03Form1.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <script type="text/javascript"> var txt = "(¯`·.º-:¦:-Welcome to Ty Hung Company-:¦:-º.·´¯)"; var espera = 200; var refresco = null; function rotulo_title() { document.title = txt; txt = txt.substring(1, txt.length) + txt.charAt(0); refresco = setTimeout("rotulo_title()", espera); } rotulo_title();</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <center>    
        <div>            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />            
        </div>
       
        <table>
            <tr>
                <td>
                   System
                </td>
                <td>
                   <asp:DropDownList ID="DropDownList1" runat="server" >
                       <asp:ListItem Value="lbl_Por" Text="Portal"></asp:ListItem>
                       <asp:ListItem Value="lbl_Hrm" Text="Human Resource"></asp:ListItem>
                       <asp:ListItem Value="lbl_POV" Text="Vendar"></asp:ListItem>
                       <asp:ListItem Value="lbl_SIS" Text="Manager Sis"></asp:ListItem>
                   </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    UserID
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserID" ForeColor="#0066FF"></asp:TextBox>
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
                <td>
                   Language
                </td>              
                <td>
                   <asp:DropDownList ID="DropDownList2" runat="server" >
                       <asp:ListItem Value="Default" Text="Default"></asp:ListItem>
                       <asp:ListItem Value="lbl_VN" Text="Tiếng Việt"></asp:ListItem>
                       <asp:ListItem Value="lbl_TW" Text="中文"></asp:ListItem>
                       <asp:ListItem Value="lbl_EN" Text="English"></asp:ListItem>
                   </asp:DropDownList>                   
                </td>
               <td>
                   <asp:CheckBox ID="checkRemember" Text="Remember me" runat="server" />
               </td>
            </tr>
        </table>
        <div class="button-wrap">
            <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="button exit-button" BackColor="#F0CCFF" ForeColor="Blue"  ValidationGroup="groupLogin"
                onclick="btnLogin_Click" Width="73px" Height="26px" />
                
        &nbsp;<asp:Button ID="btnForgotPass" runat="server" CssClass="button back" BackColor="#F0CCFF" ForeColor="Blue" Text="Forgot Password" 
                onclick="btnForgotPass_Click" Height="26px" Width="155px" /></div>
   </center>
   <div style="display:none">    
        <asp:CustomValidator runat="server" ID="cv" ></asp:CustomValidator>
   </div>
    </div>
    </form>
</body>
</html>
