<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmTrinhDuyetND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmTrinhDuyetND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div style="width:777px; float:none;text-align:center">
            <table style="width:500px;text-align:left;margin-left:300px">
                <tr>
                    <td>
                        <%=hasLanguege["lbUuTien"] %></td>
                    <td>
                        <asp:DropDownList ID="DropUutien" runat="server">
                            
                        </asp:DropDownList></td>
                </tr>
                
            </table>
        </div>
    <div style="width:700px; margin-left:200px">
        <asp:Label ID="lbThongBaoTrinhDuyet" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <table style="width:865px; float:none;text-align:center">
            <tr>
                <td style="width:450px"> </td>
                <td class="auto-style1">
                    <asp:TreeView ID="TreeView2" runat="server" OnSelectedNodeChanged="TreeView2_SelectedNodeChanged" Width="256px"></asp:TreeView>
                </td>
            </tr>
        </table>
    </div>
        <div>
           
        
        </div>
   
       <p style="width:1024px;float:none;text-align:center">
           <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Width="152px" /> &nbsp; &nbsp;
           <asp:Button ID="btnTrinhDuyet" runat="server" OnClick="btnTrinhDuyet_Click" Text="" style="height: 26px" /> &nbsp;&nbsp;
           <asp:Button ID="btnChiTiet" runat="server" Text="" OnClick="btnChiTiet_Click" /> &nbsp; &nbsp;
       </p>
        <br />
        <br />
        <asp:Label ID="LbThongBao" runat="server" ForeColor="Red"></asp:Label>
        <br />


</asp:Content>
