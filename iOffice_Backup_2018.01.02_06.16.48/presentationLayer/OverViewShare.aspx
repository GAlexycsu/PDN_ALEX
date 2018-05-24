<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage2.Master" AutoEventWireup="true" CodeBehind="OverViewShare.aspx.cs" Inherits="iOffice.presentationLayer.OverViewShare" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link href="../Style/formatMain.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    
    <script src="<%=ResolveUrl("~/Scripts/") %>jquery.min.js" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/") %>jquery-ui.min.js" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/") %>jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/Scripts/") %>formatdate1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
     <table>
               <tr>
                 <td>
                     User Name
                 </td>
                
                 <td>
                     <asp:DropDownList ID="DropDownUserName" runat="server" AutoPostBack="True"></asp:DropDownList>
                     <asp:Button ID="btnQuery" runat="server" BackColor="#F0CCFF"   ForeColor="Blue" Text="Query" OnClick="btnQuery_Click" Width="53px" />
                     &nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnExport" runat="server" BackColor="#F0CCFF"   ForeColor="Blue"  Text="Export To Excel" OnClick="btnExport_Click" />
                     &nbsp;&nbsp;
                     <asp:Button ID="btnBack" runat="server"  BackColor="#F0CCFF"   ForeColor="Blue" Text="Back" />


                 </td>
             </tr>
        </table>
    <table>
        <tr>
              <td>
                 edates
              </td>
              <td>
                  <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
              </td>
              <td>
                 edatee
              </td>
              <td>
                  <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
              </td>
           </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>
    </div>
</asp:Content>
