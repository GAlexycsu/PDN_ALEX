<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteUser.Master" AutoEventWireup="true" CodeBehind="frmFirst.aspx.cs" Inherits="iOffice.presentationLayer.Users.frmFirst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width: 766px">
        <tr>
              
             <td> <asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label></td>
        </tr>
        <tr>
            
            <td class="auto-style1">
                <asp:Label ID="lbLoaiPhieu" runat="server" Text="Loại phiếu 单别:"></asp:Label><asp:DropDownList ID="DropLoaiPhieu" runat="server" OnSelectedIndexChanged="DropLoaiPhieu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbTrinhBanLD" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
            
        </tr>
        <tr>
            <%--<td><%=hasLanguege["lbDonVi"].ToString() %></td>--%>
            <td>
                &nbsp;&nbsp;
                <asp:Label ID="lbDonVi" runat="server" Text="Đơn vị đề nghị 提议单位 :"></asp:Label> <asp:DropDownList ID="DropDonVi" runat="server"></asp:DropDownList>
                <asp:Label ID="lbthongbao" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
           <%-- <td><%=hasLanguege["lbTieuDe"].ToString() %></td>--%>
            <td> <asp:Label ID="lbTieuDe" runat="server" Text="Tiêu đề 题目: "></asp:Label><asp:TextBox ID="txtTieuDe" runat="server" Width="447px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        
    </table>
    <p style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="Continues" OnClick="Button1_Click" /></p>
</asp:Content>
