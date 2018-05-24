<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/testPage.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="iOffice.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table>
                  <tr>
                      <td>
                           <asp:Label ID="Label1" runat="server" Text="Select Type"></asp:Label>
                      </td>
                      <td class="auto-style9">
                            <asp:DropDownList ID="dropTypePrint" runat="server" Height="16px" Width="127px">
                            <asp:ListItem Value="0">No Tilte</asp:ListItem>
                            <asp:ListItem Value="1">Title</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                  </tr>
                  <tr>
                      <td>
                           <asp:Label ID="idNhaCC" runat="server" Text="Mã nhà cung ứng"></asp:Label>
                      </td>
                      <td >
                            <asp:DropDownList ID="dropNhaCC" runat="server" Height="16px" Width="129px"></asp:DropDownList>
                      </td>
                  </tr>
              </table>
</asp:Content>
