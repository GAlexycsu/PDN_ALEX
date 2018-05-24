<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailGroup.aspx.cs" Inherits="iOffice.presentationLayer.DetailGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="ShowGrid">
         <table>
             <tr>
                 <td>Title</td>
                 <td>
                     <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></td>
             </tr>
             <tr>
                 <td>
                     Message
                 </td>
                 <td>
                     <asp:Label ID="lblMemo" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
         </table>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
