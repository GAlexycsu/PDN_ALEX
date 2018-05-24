<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmTrinhDuyetCB.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmTrinhDuyetCB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
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
   
       <div class="button-wrap" style="width:1024px;float:none;text-align:center">
           <asp:Button ID="Button1" runat="server" Text="Button" BackColor="#F0CCFF" CssClass="button Cancel" ForeColor="Blue" OnClick="Button1_Click" Width="152px" style="height: 26px" /> &nbsp; &nbsp;
           <asp:Button ID="btnTrinhDuyet" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button approval" OnClick="btnTrinhDuyet_Click" Text="" Width="137px" /> &nbsp;&nbsp;
           <asp:Button ID="btnChiTiet" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Detail" Text="" OnClick="btnChiTiet_Click" Width="139px" /> &nbsp; &nbsp;
       </div>
        <br />
        <br />
      <p style="margin-left:200px;width:400px">
                  <asp:Label ID="LbThongBao" runat="server" ForeColor="Red"></asp:Label>
      </p>
        <br />
   
</asp:Content>
