<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StyleProcess.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/nhapso.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui-1.8.19.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/formatDate.js" type="text/javascript"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/gridviewScroll.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="Styles/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/bootstrap-multiselect.js" type="text/javascript"></script>
     <script type="text/javascript">
         function ShowProgress() {

             setTimeout(function () {
                 var modal = $('<div />');
                 modal.addClass("modal");
                 $('body').append(modal);
                 var loading = $(".loading");
                 loading.show();
                 var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                 var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                 loading.css({ top: top, left: left });
             }, 200);
         }
    
</script>
  <script type="text/javascript">
      $(document).ready(function () {

          gridviewScroll();
      });

      function gridviewScroll() {

          $('#<%=GridView1.ClientID%>').gridviewScroll({
              width: 1524,
              height: 700
          });

      }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
  <table id="idquery" runat="server">
    <tr> 
       
        <td >&nbsp; XieXing:&nbsp;&nbsp;
            <asp:TextBox ID="txtXieXing" runat="server"></asp:TextBox>
            <asp:AutoCompleteExtender ID="txtXieXing_AutoCompleteExtender" runat="server" 
                DelimiterCharacters="" Enabled="True" ServiceMethod="GetXieXing" 
                ServicePath="" TargetControlID="txtXieXing" UseContextKey="True" MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" CompletionSetCount="25">
             </asp:AutoCompleteExtender>
            
        </td>
        <td> &nbsp; SheHao &nbsp; 
            <asp:TextBox ID="txtSheHao" runat="server"></asp:TextBox>
               <asp:AutoCompleteExtender ID="txtSheHao_AutoCompleteExtender" runat="server" 
                DelimiterCharacters="" Enabled="True" ServiceMethod="GetSheHao" 
                ServicePath="" TargetControlID="txtSheHao" UseContextKey="True" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="15">
             </asp:AutoCompleteExtender>
            
        </td>
          <td>
            <asp:Button ID="btnQuery" runat="server" Text="Query"  ValidationGroup="groupA"
                onclick="btnQuery_Click" Width="64px" OnClientClick="ShowProgress()" />&nbsp;&nbsp; 
              <asp:Button ID="btnBack" runat="server" 
                Text="Back" onclick="btnBack_Click" Width="60px" /> &nbsp; &nbsp;<asp:Button 
                  ID="btnPrint" runat="server" Text="Print" 
        onclick="btnPrint_Click" Width="51px" /> </td>
    </tr>
   <tr>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtXieXing" ValidationGroup="groupA" ErrorMessage="Press enter XieXing" ForeColor="Red" Text="Please enter XieXing"></asp:RequiredFieldValidator>
        </td>
        <td>
               
        </td>
   </tr>
</table>
<div id="ShowGrid" runat="server" style="overflow:auto;width:1124px">

    <asp:GridView ID="GridView1" runat="server"  CellPadding="4" ForeColor="#333333"  
        Width="1124px">
    </asp:GridView>
</div>
<div class="loading" align="center">
            Loading. Please wait.<br />
            <br />
            <img src="Image/loader.gif" alt="Loading. Please wait." />
    </div>
</asp:Content>

