<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDoiMatKhau.aspx.cs" Inherits="iOffice.presentationLayer.frmDoiMatKhau" %>

<!DOCTYPE html>
<link href="../Style/EX03Form.css" rel="stylesheet"  type="text/javascript"/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width:500px">
    <div style="height:350px; width:547px; text-align:left; margin:15px" >
            
        <div style="width:50%; height:101px; margin-top:50px; text-align: left;" >
         <%--   <p style="width:150px"> Nhập thông tin :</p>--%>
            <table style="height: 250px; width:450px">
                <tr>
                    <td><%=hasLanguege["lblCongty"].ToString() %></td>
                    <td style="width: 100px">
                    <asp:DropDownList ID="DropCongTy" runat="server">
                        <asp:ListItem>LBT</asp:ListItem>
                        <asp:ListItem>LMY</asp:ListItem>
                        <asp:ListItem>LPM</asp:ListItem>
                        <asp:ListItem>LTY</asp:ListItem>
                        <asp:ListItem Value="LTB"></asp:ListItem>
                    </asp:DropDownList>
               </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        <%=hasLanguege["lbtTaiKhoan"] %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                    </td>
                   <td> <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Label ID="lbMatKhauCu" runat="server" Text="旧密码:"></asp:Label>--%>
                        <%=hasLanguege["lbMatKhauCu"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassOld" runat="server" TextMode="Password" Height="22px"></asp:TextBox>
                    </td>
                    
                     <td> &nbsp;</td>
                </tr>
                <tr>
                    <td>
                       <%-- <asp:Label ID="lbMatKhauMoi" runat="server" Text="新密码:"></asp:Label>--%>
                        <%=hasLanguege["lbMatKhauMoi"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassNew" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td>
                       <%-- <asp:Label ID="lbConfirmPass" runat="server" Text="确认密码:"></asp:Label>--%>
                        <%=hasLanguege["lbConfirmPass"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnChangePass" runat="server" Text="同意" OnClick="btnChangePass_Click" /></td>
                    <td>
                        <asp:Button ID="btnHuy" runat="server" Text="删除" OnClick="btnHuy_Click" />
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td style="width:500px;">
                        <asp:Label ID="lblthongbaothanhcong" runat="server" ForeColor="#0099FF"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
