<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQuenmatkhau.aspx.cs" Inherits="iOffice.presentationLayer.frmQuenmatkhau" %>

<!DOCTYPE html>
<link href="../Style/EX03Form.css" rel="stylesheet" type="text/javascript" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 168px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width:600px">
    <div>

        <asp:Panel ID="Panel1" runat="server">
            <p style="width:170px"> <%=hasLanguege["lbNhapTT"] %> </p>
            <table style="width:350px">
                  <tr>
                    <td><%=hasLanguege["lbcongty"] %> </td>
                    <td class="auto-style1"><asp:DropDownList ID="DropCongTy" runat="server">
                        <asp:ListItem>LBT</asp:ListItem>
                        <asp:ListItem>LMY</asp:ListItem>
                        <asp:ListItem>LPM</asp:ListItem>
                        <asp:ListItem>LTY</asp:ListItem>
                        <asp:ListItem Value="LTB"></asp:ListItem>
                    </asp:DropDownList>
                       </td>
                </tr>
                <tr>
                    <td style="width:80px">
                       <%=hasLanguege["lbTenDangNhap"] %>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chưa nhập mã nhân viên" ControlToValidate="txtUserID" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                   </td>
                   
                </tr>
                <tr>
                    <td>
                        <%=hasLanguege["lbEmail"] %>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Chưa nhập mã nhân viên" ControlToValidate="txtEmail" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td> <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
            <p style="width:594px; height: 70px;"><asp:Label ID="lbThongBao2" runat="server" ForeColor="Red"></asp:Label></p>
            <table style="width:350px">
                <tr>
                    <td>
                        <asp:Button ID="btnSendMail" runat="server" Text="发送" OnClick="btnSendMail_Click" /></td>
                    <td>
                        <asp:Button ID="btnnHuy" runat="server" Text="删除" OnClick="btnnHuy_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
