<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap-multiselect.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(function () {
             $('[id*=ListBox1]').multiselect({
                 includeSelectAllOption: true
             });
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ListBox ID="ListBox1" runat="server"  SelectionMode="Multiple">
    </asp:ListBox>
    <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="Submit" />
</asp:Content>

