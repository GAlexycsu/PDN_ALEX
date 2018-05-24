<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmApproval.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" >
    <div  style="margin:0 auto; width:600px">    
        <asp:Panel ID="Panel1" runat="server"  >
          
            <p><%=hasLanguege["lbChoose"] %></p>
            <table>
                <tr>
                  
                    <td><asp:RadioButton ID="rdApproval" Text="" GroupName="ABC" runat="server" Checked="True" ForeColor="Blue" /></td>
                    <td>
                        <asp:RadioButton ID="rdNotApproval" Text="" GroupName="ABC" runat="server" ForeColor="Red" /></td>
                    <td>
                        <asp:RadioButton ID="rdNotYetAroval" runat="server" ForeColor="#cc6699" Text="Ý kiến khác" AutoPostBack="True" OnCheckedChanged="rdNotYetAroval_CheckedChanged" /></td>
                </tr>
                <tr>
                  <td>  <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Thumbsup.png" /></td>
                    <td> <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Thumbsdown.png" /></td>
                   
                </tr>
            </table>
            <p><asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label></p>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
              <%--<asp:Label ID="lbcomment" runat="server" Text="Step 2: Write Comment"></asp:Label>--%>

            <p><%=hasLanguege["lbcomment"] %></p>
            <table>
                <tr>
                    
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" Height="125px" TextMode="MultiLine" Width="410px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ForeColor="Red" ControlToValidate="txtComment" ValidationGroup="groupAcept" ErrorMessage=""></asp:RequiredFieldValidator>
                    </td>
                    
                    
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
           <%--<p><asp:Label ID="lbsecur" runat="server" Text="Step 3: Enter The Security Code"></asp:Label></p>--%>
            <p><%=hasLanguege["lbsecur"] %></p>
            <asp:TextBox ID="txtSecure" runat="server" Width="259px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ForeColor="Red" ValidationGroup="groupAcept" ControlToValidate="txtSecure"  ErrorMessage=""></asp:RequiredFieldValidator>
        </asp:Panel> &nbsp; <br />
       
        
        <asp:Button ID="btnAccep" runat="server" Text="" ValidationGroup="groupAcept" BackColor="#F0CCFF" ForeColor="Blue"  OnClick="btnAccep_Click" style="height: 26px" /> &nbsp;
   
        <asp:Button ID="btnCancel" runat="server" Text="" BackColor="#F0CCFF" ForeColor="Red" OnClick="btnCancel_Click" Width="167px" />  &nbsp;&nbsp;
        <asp:Button ID="btnPause" runat="server" Text="Gửi Ý Kiến Đến Người Tạo Phiếu" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnPause_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnDetails" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="" OnClick="btnDetails_Click" />

        <br />
        <br />
        
        <br />
        <br />
        <asp:Label ID="lbthongbaoLoi" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
    
</body>
</html>
