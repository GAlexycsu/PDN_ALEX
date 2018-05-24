<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmChiTietDichND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmChiTietDichND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table style="width: 1069px;  overflow:hidden">
        <tr>
            <td class="auto-style4"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td  style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td style="text-align:left;"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td style="text-align:left;">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
    <tr>
        <td style="text-align:left;">Tiêu đề 题目:<br />
            <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:1035px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:1032px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td  style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
      </tr>
          
   
   </table>

    <div class="button-wrap" style="width:1000px;text-align:center">
         <asp:Button ID="btnUndo" runat="server" BackColor="#F0CCFF" CssClass="button Cancel" ForeColor="Blue" Text="Quay lại" OnClick="btnUndo_Click" Width="172px" />
    </div>
</asp:Content>
