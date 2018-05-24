<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="frmEditBoPhan.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmEditBoPhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lblSuaBoPhan"].ToString() %></p>
      <table style="margin-left:200px; width: 469px;">
        <tr>
               <td></td>
                 <td> <asp:DropDownList ID="DropCty" runat="server" Height="16px">
                <asp:ListItem Value="LTY"></asp:ListItem>
                <asp:ListItem>LBT</asp:ListItem>
                <asp:ListItem Value="LMY"></asp:ListItem>
                <asp:ListItem>LPM</asp:ListItem>
                <asp:ListItem Value="LYY"></asp:ListItem>
                <asp:ListItem Value="TST"></asp:ListItem>
            </asp:DropDownList></td>
           
        </tr>
        <tr>
           <td>
               <%=hasLanguege["lbDonVi"].ToString() %></td>
            <td>
                <asp:DropDownList ID="DropDownBoPhan" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td> <%=hasLanguege["lblLoaiDonVi"].ToString() %></td>
            <td>
                <asp:DropDownList ID="DropDownLoaiDonVi" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lblChuQuan"].ToString() %></td>
            <td>
                <asp:TextBox ID="txtChuQuan" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" /></td>
        </tr>
    </table>

</asp:Content>
