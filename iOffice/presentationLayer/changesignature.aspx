<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changesignature.aspx.cs" Inherits="iOffice.changesignature" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table style="width:600px;text-align:center; float:left">
          <tr>
              <td><%=hasLanguege["lbMaNV"] %></td>
              <td style="text-align:left">
                  <asp:TextBox ID="txtUserID" runat="server" Text="" Enabled="False" ReadOnly="True"></asp:TextBox></td>
          </tr>
           <tr>
              <td><%=hasLanguege["lbTenNV"] %></td>
              <td style="text-align:left">
                  <asp:TextBox ID="txtUseName" runat="server" Text="" Enabled="False" ReadOnly="True"></asp:TextBox></td>
          </tr>
          <tr>
              <td><%=hasLanguege["signatue"] %></td>
              <td >
                  <asp:FileUpload ID="FileUpload1" runat="server" /></td>
          </tr>
      </table>
        <p style="width:600px;text-align:center;">
            <asp:Button ID="btnChange" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Change" OnClick="btnChange_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Cancel" OnClick="btnCancel_Click" /></p>
        <p style="width:600px;text-align:center;">
            <asp:Image ID="Image1" runat="server" /></p>
    </div>
    </form>
</body>
</html>
