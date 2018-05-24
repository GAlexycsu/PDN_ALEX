<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="iOffice.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
           <link type="text/css" href="../Style/formatMain.css" rel="stylesheet" />
    <link type="text/css" href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="<%=ResolveClientUrl("~/Scripts/")%>jquery.min.js" type="text/javascript"></script>
     <script src="<%=ResolveClientUrl("~/Scripts/")%>jquery-ui.min.js" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/") %>jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/") %>JScriptabc.js" type="text/javascript"></script>
   <script src="<%=ResolveClientUrl("~/Scripts/") %>formatdate1.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
         <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
