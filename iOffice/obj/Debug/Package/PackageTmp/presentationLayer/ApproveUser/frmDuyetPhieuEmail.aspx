﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDuyetPhieuEmail.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmDuyetPhieuEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:800px; text-align:center;margin-top:200px">
      
        <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>
          <p  style="width:500px;text-align:center;margin-left:200px">
              <asp:Button ID="btnDetail" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Details" OnClick="btnDetail_Click" /></p>
    </div>
    </form>
</body>
</html>
