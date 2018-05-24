<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="importData.aspx.cs" Inherits="importData" EnableEventValidation="false" %>
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
         $(function () {
             $('[id*=ListBox1]').multiselect({
                 includeSelectAllOption: true
             });
         });
    </script>
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
    <div id="Div1" runat="server">
         <table>
             <tr>
               <td style="color:Red">Step 1: Select the file to Import
               </td>
               <td style="color:Blue">Step 2: Click Upload</td>
             </tr>
            <tr>
                <td> 
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnImport" runat="server" Text="Upload" 
                        onclick="btnImport_Click" style="height: 26px" />   
                </td>
            </tr>
        </table>
   </div>
<div id="Div2" runat="server">
        <table>
                <tr>
                   <td class="style1"><asp:Label ID="Label5" runat="server" Text="File Name"/>
                   </td>
                   <td class="style2"><asp:Label ID="lblFileName" runat="server" Text=""/><asp:Label ID="lblPart" runat="server"
                           Text=""></asp:Label>
                   </td>
                </tr>
                <tr>
                  <td style="color:Red">Step 3: Select sheet</td>
                  <td style="color:Blue">Step 4: Click button Read File</td>
                </tr>
                <tr>
                  <td> <asp:Label ID="Label2" runat="server" Text="Select Sheet" />
                  </td> 
                  <td class="style2"> <asp:DropDownList ID="ddlSheets" runat="server" AppendDataBoundItems = "true">
                </asp:DropDownList></td>
                <td>
                <asp:Button ID="btnSave" runat="server" Text="Read File" 
                            onclick="btnSave_Click" Width="70px" />
                  
                </td>
                </tr>
               

               
        </table>
        
</div>
<div id="Div3" runat="server">
   <table>
        <tr>
                  <td></td>
                 <td  style="color:Red">Step 5: Choose SheHao</td>
                <td style="color:Blue" colspan="2">Step 6 :Click import to transfer the data to the server </td>
        </tr>
       <tr>
                  <td >Choose SheHao</td>
                  <td>
                         <asp:ListBox ID="ListBox1" runat="server"  SelectionMode="Multiple" 
                             Height="64px" Width="77px">
                             </asp:ListBox>
                  </td>
                  <td>
                      <asp:Button ID="btnImportDT" runat="server" Text="Import" 
                          onclick="btnImportDT_Click" Width="57px" OnClientClick="ShowProgress()" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnFileKhac" runat="server" Text="Other File" 
                        onclick="btnFileKhac_Click" />
                  </td>
               </tr>
   </table>
</div>

       <table id="idquery" runat="server">
    <tr> 
       
        <td >&nbsp; XieXing:&nbsp;&nbsp;&nbsp;
            
        </td>
       <td><asp:TextBox ID="txtXieXing" runat="server" Width="134px"></asp:TextBox></td>
       <td id="idXieXing" runat="server">
           <asp:Button ID="btnQuery" runat="server" Text="Query" onclick="btnQuery_Click" 
               Width="74px" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button 
                  ID="btnPrint" runat="server" Text="Print" 
        onclick="btnPrint_Click" Width="51px" /></td>
    </tr>
</table>
        <p id="idCount" runat="server" style="width:550px;text-align:right;color:Red;"> Added :
            <asp:Label ID="lblRecord" runat="server" Text=""></asp:Label> Records</p>
<div id="ShowGrid" runat="server" 
        style="overflow:auto;width:1176px; height: 600px;">

    <asp:GridView ID="GridView1" runat="server"  CellPadding="4" 
        ForeColor="#333333"  ondatabound="GridView1_DataBound"  
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
        onrowediting="GridView1_RowEditing" onrowupdating="OnUpdating" 
        Width="1168px">
    </asp:GridView>
</div>
<div class="loading" align="center">
            Loading. Please wait.<br />
            <br />
            <img src="Image/loader.gif" alt="Loading. Please wait." />
    </div>
</asp:Content>

