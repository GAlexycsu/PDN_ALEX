<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FSualoaiphieu.aspx.cs" Inherits="iOffice.presentationLayer.Admin.FSualoaiphieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <p><%=hasLanguege["dsloaiphieu"].ToString() %>
        </p>
      <div style="margin-left:300px">
              <table>
                <tr>
                    <td class="auto-style1">
                      <%=hasLanguege["idloai"].ToString() %>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtMaLoai" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td>
                         <%=hasLanguege["tentiengviet"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenLoaiVN" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <%=hasLanguege["tentienghoa"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenLoaiTW" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    </td>
                </tr>
           </table>
      </div>
    <p style="width: 600px;margin-left:200px">
        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
