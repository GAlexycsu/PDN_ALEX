<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Action_Group.aspx.cs" Inherits="iOffice.presentationLayer.Action_Group" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <script type="text/javascript">
          function CloseAndRebind(args) {
              GetRadWindow().BrowserWindow.refreshGrid(args);
              GetRadWindow().close();
          }

          function GetRadWindow() {
              var oWindow = null;
              if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
              else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

              return oWindow;
          }

          function CancelEdit() {
              GetRadWindow().close();
          }
        </script>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
          <div id="ShowGrid" style="width:700px">
         <table>
             <tr>
                 <td>Group Name</td>
                 <td>
                     <asp:Label ID="lblGroup" runat="server" Text=""></asp:Label></td>
             </tr>
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
         <table>
            <tr>
                <td>
                    Creater
                </td>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                 <td>
                     From Date
                 </td>
                 <td>
                     <asp:Label ID="lblFromDate" runat="server" Text=""></asp:Label>
                 </td>
                 <td>
                     To Date
                 </td>
                 <td>
                     <asp:Label ID="lblToDate" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
         </table>
              <br />
       
    <div id="divAttact" runat="server">
        <p style="width:700px; text-align:center;" > Attact File </p>
               <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server"  AutoGenerateColumns="False" DataKeyNames="FilePath" Width="622px">
            <HeaderStyle BackColor="#df5015" />
            <Columns>
                 <asp:TemplateField HeaderText="ID" Visible="false">
                     <ItemTemplate>
                        <asp:Label ID="lblIDAttactFile" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
            <asp:BoundField DataField="FileName" HeaderText="File Name" >
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                
                </asp:BoundField>
              <asp:TemplateField HeaderText="File Path" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblFilePath" runat="server" Text='<%#Eval("FilePath") %>'></asp:Label>
                       </ItemTemplate>
                      

 
                   </asp:TemplateField>
            <asp:TemplateField HeaderText="Download File">
            <ItemTemplate>
               <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click" ></asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
    <div style="display:none">
        <asp:TextBox ID="txtMaShare" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
