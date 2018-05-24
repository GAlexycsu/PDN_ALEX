<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taomoi.aspx.cs" Inherits="iOffice.presentationLayer.Users.taomoi" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p></p>
    <p><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng"></asp:Label></p>
     <p><asp:Label ID="Label2" runat="server" Text="PHIẾU ĐỀ NGHỊ"></asp:Label></p>
     <p><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 1"></asp:Label></p>
    <p> <asp:Label ID="Label1" runat="server" Text="Đơn vị đề nghị"></asp:Label> <asp:DropDownList ID="DropDonVi" runat="server"></asp:DropDownList></p>
    <p>
        <asp:Label ID="lbNoiDung" runat="server" Text="Nội Dung"></asp:Label></p>
    <div>
             <ckeditor:ckeditorcontrol id="CKEditorControl1" runat="server" Height="608px"></ckeditor:ckeditorcontrol>
            
     </div>
    </div>
    </form>
</body>
</html>
