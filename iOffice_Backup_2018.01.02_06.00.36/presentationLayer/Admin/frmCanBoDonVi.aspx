<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteAddmin.Master" AutoEventWireup="true" CodeBehind="frmCanBoDonVi.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmCanBoDonVi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
               <td>
                   <asp:Label ID="Label3" runat="server" Text="Công ty"></asp:Label></td>
                 <td> <asp:DropDownList ID="DropCty" runat="server" AutoPostBack="True" Height="16px">
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
               <asp:Label ID="Label1" runat="server" Text="Đơn vị"></asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownBoPhan" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Cán bộ quản đơn vị"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtChuQuan" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" /></td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" />
                <asp:BoundField DataField="GSBH" />
                <asp:BoundField DataField="UserIDQLDonVi" />
                <asp:BoundField DataField="BADepID" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
