<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmChiTietDich.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmChiTietDich" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
<style type="text/css">
    .auto-style2 {
        width: 145px;
    }
    .auto-style3 {
        width: 145px;
        float: right;
    }
    .auto-style4 {
        width: 139px;
    }
    .auto-style5 {
        float: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left:20px">
        <table style="width: 1046px;  overflow:hidden">
        <tr>
            <td  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td>Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
    <tr>
        <td>
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:1079px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td>Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:1076px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td class="auto-style5" style="text-align:right;">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
      </tr>
          
   
   </table>
    <table>
        <tr>
            <td>
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div class="button-wrap" style="width:1024px;text-align:center;float:none"> 
        <asp:Button ID="btnUndo" runat="server" CssClass="button Cancel" Text="Quay lại" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnUndo_Click" Width="129px" />
    </div>
    </div>
</asp:Content>
