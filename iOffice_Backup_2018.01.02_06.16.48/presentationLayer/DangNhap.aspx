<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="iOffice.presentationLayer.DangNhap" %>

<!DOCTYPE html>
<link href="../Style/EX03Form.css" rel="stylesheet"  type="text/javascript"/>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width:600px">
        <div style="height:350px; width:547px; text-align:left; margin:15px">
              
    <div style="width:50%; height:101px; margin-top:50px; text-align: left;" >
        <table style="height: 250px; width:450px">
            <tr >
              <%--<td style="width:100px"><%=hasLanguege["lbLanguege"].ToString() %></td>--%>
              <td>Languege</td>
               <td class="auto-style1">
                   <asp:DropDownList ID="DropDownLanguege" runat="server" OnSelectedIndexChanged="DropDownLanguege_SelectedIndexChanged" AutoPostBack="True">
                       <asp:ListItem Value="lbl_VN">VietNam</asp:ListItem>
                       <asp:ListItem Value="lbl_TW">Taiwan</asp:ListItem>
                       <asp:ListItem Value="lbl_EN">English</asp:ListItem>
                   </asp:DropDownList>
               </td>
               
            </tr>
             <tr>
               <%--<td><%=hasLanguege["lbCty"] %></td>--%>
               <td>Company</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropCongTy" runat="server">
                        <asp:ListItem Value="LTY">LTY</asp:ListItem>
                        <asp:ListItem Value="LBT">LBT</asp:ListItem>
                        <asp:ListItem Value="LTB"></asp:ListItem>
                    </asp:DropDownList>
               </td>
            </tr>
            <tr>
               <%-- <td><%=hasLanguege["lbtendangnhap"] %></td>--%>
                <td style="width: 100px; text-align: right;">
                    
                 
                    <asp:Label ID="lbtendangnhap" runat="server" Text="账号"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                
            <tr>
             <%--  <td><%=hasLanguege["lbMatKhau"] %></td>--%>
                <td style="width: 100px; text-align: right;">
                  
                <asp:Label ID="lbMatKhau" runat="server" Text="密码"></asp:Label></td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="148px"></asp:TextBox></td>
                
            </tr>
            <tr>
               
                <%--<td><%=hasLanguege["btnlogin"] %></td>--%>
                <td colspan="3" style="text-align: center">
                    <asp:Button ID="btnlogin" runat="server" Height="22px" Text="" Width="90px" OnClick="Button1_Click" ForeColor="DarkBlue" /></td>
               <%-- <td><%=hasLanguege["btnfogot"] %></td>--%>
                <td><asp:Button
                        ID="btnfogot" runat="server" Height="22px" Text="" Width="130px" PostBackUrl="~/presentationLayer/frmQuenmatkhau.aspx" ForeColor="DarkBlue" /></td>
                <td colspan="1" style="text-align: center">
                </td>
            </tr>
        </table>
        <asp:Label ID="lbltb" runat="server" Font-Bold="True" Font-Size="12pt" ForeColor="Red"></asp:Label></div>
        </div>

    
             
    </form>
</body>
</html>
