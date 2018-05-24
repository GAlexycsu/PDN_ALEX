<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportProject.aspx.cs" Inherits="iOffice.presentationLayer.ExportProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/XPForm.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/formatdate1.js"></script>

    <style type="text/css">
        .auto-style1 {
            width: 74px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <table>
           <tr>
            <td colspan="2" class="style1"> Date From
                <asp:TextBox ID="txtFromDate" runat="server" Height="22px"></asp:TextBox>  
            
            </td> 
            <td>   Date To<asp:TextBox ID="txtToDate" runat="server" Height="22px"></asp:TextBox></td>
            <td>
                &nbsp;</td>
           </tr>
            <tr>
                <td class="auto-style1">
                    <asp:RadioButton ID="RadExcel" runat="server" ToolTip="Export Excel" Checked="true" GroupName="GroupExport" /></td>
                <%--<td>
                    <asp:RadioButton ID="RadPDF" runat="server" ToolTip="Export PDF" GroupName="GroupExport" Text="PDF" /></td>--%>
                <td class="button-wrap">
                    <asp:Button ID="btnExport" runat="server"  CssClass="button export" Text="Export" Width="88px" OnClick="btnExport_Click" /> &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="back"  Text="Back" OnClick="btnBack_Click" /></td>
            </tr>
      </table>
    </div>
    </form>
</body>
</html>
