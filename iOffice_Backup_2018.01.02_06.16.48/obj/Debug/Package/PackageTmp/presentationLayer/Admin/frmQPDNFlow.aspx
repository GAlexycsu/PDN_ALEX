<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteUser.Master" AutoEventWireup="true" 
    CodeBehind="frmQPDNFlow.aspx.cs" Inherits="iOffice.presentationLayer.Admin.frmQPDNFlow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><%=hasLanguege["lbQPDNFlow"].ToString() %></p>

     
              <table>
        
        <tr>
            <td>
                  <%=hasLanguege["lbCty"].ToString() %>          </td>
           <td> <asp:DropDownList ID="DropCty" runat="server">
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
                <%=hasLanguege["lbLoaiDV"].ToString() %>
             
            </td>
            <td>
                <asp:DropDownList ID="DropDownLoaiDV" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbLoaiPhieu" runat="server" Text="Sử dụng loại phiếu riêng" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownLoaiPhieu" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lbDonVi"].ToString() %>
            </td>
            <td>
                <asp:DropDownList ID="DropDownLDonVi" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckThongQuaDonVi" runat="server" Text="Thông qua đơn vị" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownDonViThongQua" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lbNguoiDuyet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lbChucVu"].ToString() %>
            </td>
            <td>
                <asp:DropDownList ID="DropDownChucVu" runat="server"></asp:DropDownList>
            </td>
        </tr>
       
        
    </table>
   
    <div>
        <p>
        <asp:Label ID="lbThongBao" runat="server" Text=""></asp:Label>
        </p>
    </div>
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Lưu" OnClick="Button1_Click" />
            </td>
           
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IDQuyTrinh" HeaderText="ID" />
                <asp:BoundField DataField="GSBH" />
                <asp:BoundField DataField="abtype" />
                <asp:BoundField DataField="BADEPID" />
                <asp:BoundField DataField="DonViThongQua" />
                <asp:BoundField DataField="NguoiDuyet" />
                <asp:BoundField DataField="IDChucVu" />
                <asp:BoundField DataField="IDCapDuyet" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
