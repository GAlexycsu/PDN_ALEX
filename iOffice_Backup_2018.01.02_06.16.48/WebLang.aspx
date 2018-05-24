<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLang.aspx.cs" Inherits="iOffice.WebLang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table>
         <tr>
             <td>
                 ID
             </td>
             <td>
                 <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
             </td>
         </tr>
     </table>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
