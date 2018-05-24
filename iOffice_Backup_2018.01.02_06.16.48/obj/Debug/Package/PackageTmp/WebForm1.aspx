<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="iOffice.WebForm1" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
        .auto-style2 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                      <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
    <p>
        Please Fill the Following to Send Mail.</p>
    <p>
        Your name:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
            ControlToValidate="YourName" ValidationGroup="save" /><br />
        <asp:TextBox ID="YourName" runat="server" Width="250px" /><br />
        Your email address:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
            ControlToValidate="YourEmail" ValidationGroup="save" /><br />
        <asp:TextBox ID="YourEmail" runat="server" Width="250px" />
        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator23"
            SetFocusOnError="true" Text="Example: username@gmail.com" ControlToValidate="YourEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
            ValidationGroup="save" /><br />
        Subject:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
            ControlToValidate="YourSubject" ValidationGroup="save" /><br />
        <asp:TextBox ID="YourSubject" runat="server" Width="400px" /><br />
        Your Question:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
            ControlToValidate="Comments" ValidationGroup="save" /><br />
        <asp:TextBox ID="Comments" runat="server" TextMode="MultiLine" Rows="10" Width="400px" />
        <asp:LinkButton ID="LinkButton1" runat="server">
             
        </asp:LinkButton>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" Text="Send" OnClick="Button1_Click" ValidationGroup="save" />
        
    </p>
</asp:Panel>
<p>
    <asp:Label ID="lblMsgSend" runat="server" Visible="false" />
</p> 
<p>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
</p>
    </div>
        <table>
            <tr>
                <td><a href=\"http://portal.footgear.com.vn\">Jon Doe</a></td>
                <td>
                    <a href=\"http://google.com.vn\"> nao ta duyet</a>
                </td>
            </tr>
        </table>
        
         <div style="border-style: solid; border-color: inherit; width:600px; border-width:1px;"><br/>ĐÃ ĐƯỢC DUYỆT 已经审核- Mã văn bản 单号: 201411150063<br/>- Tiêu đề 题目: Phiếu đề nghị mua máy tính<br/>- Ngày tạo 创建于: 15/11/2014<br/>- Người duyệt 审核者: SU YU CHOU<br/>- Nội dung phiếu:<p>
	svnsdnv&nbsp;<em style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium;"><a href="http://code.google.com/">Google Code</a>&nbsp;powered by&nbsp;<a href="http://subversion.apache.org/">Subversion</a></em></p>
<br />- Nội dung phiếu dịch:<br /></div> <br/>
         </form>
</body>
</html>
