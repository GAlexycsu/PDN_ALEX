<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmChiTietPhieuChuaDich.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmChiTietPhieuChuaDich" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="margin-left:20px">
       &nbsp;<table style="width: 99%; height: 206px;">
        <tr>
            <td class="" style="height:20px" ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style3" style= "height:20px; text-align:center";> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td class="auto-style4" style="height:20px"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> 
             <asp:TextBox ID="TextBox1" runat="server" Width="16px" Visible="false"></asp:TextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style5" style="height:20px">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
         
    
   <tr>
       <td> Nội dung 内容:
           <br />
           <asp:Label ID="lblNoiDung" runat="server" Text=""></asp:Label>
       </td>
   </tr>
            <tr style="height:10px">
          <td  style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
       </tr>
   </table>
    <div class="button-wrap" style="float:none;width:1024px;text-align:center">
        <asp:Button ID="Button1" runat="server" CssClass="button Cancel" Text="Button" BackColor="#F0CCFF" ForeColor="Blue" OnClick="Button1_Click" Width="124px" />
    </div>
    </div>
</asp:Content>
