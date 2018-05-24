<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmQuenmatkhauxetduyet.aspx.cs" Inherits="iOffice.presentationLayer.FrmQuenmatkhauxetduyet" %>

<!DOCTYPE html>
<link href="../Style/EX03Form.css" rel="stylesheet"  type="text/javascript"/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width:600px;">
     <div>

        <asp:Panel ID="Panel1" runat="server">
            <p style="width:170px"> <%=hasLanguege["lbNhapTT"] %> :</p>
            <table style="width:350px">
                <tr>
                    <td><%=hasLanguege["lbcongty"] %></td>
                    <td><asp:DropDownList ID="DropCongTy" runat="server">
                        <asp:ListItem>LBT</asp:ListItem>
                        <asp:ListItem>LMY</asp:ListItem>
                        <asp:ListItem>LPM</asp:ListItem>
                        <asp:ListItem>LTY</asp:ListItem>
                        <asp:ListItem Value="LTB"></asp:ListItem>
                    </asp:DropDownList>
                       </td>
                </tr>
                <tr>
                    <td td style="width:80px"> 
                       <%=hasLanguege["lbTenDangNhap"] %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                   </td>
                   
                </tr>
                <tr>
                    <td>
                        <%=hasLanguege["lbEmail"] %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td> <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
            <p><asp:Label ID="lbThongBao2" runat="server" ForeColor="Red"></asp:Label></p>
            <table style="width:350px">
                <tr>
                    <td>
                        <asp:Button ID="btnSendMail" runat="server" Text="发送" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnSendMail_Click" /></td>
                    <td>
                        <asp:Button ID="btnnHuy" runat="server" Text="删除" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnnHuy_Click" Width="165px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
