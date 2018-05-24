<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="frmDetailsND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.frmDetailsND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">

             <table style="width: 1070px;  overflow:hidden">
        <tr>
            <td class="auto-style2"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" ></asp:Label></td>
      </tr>
     <tr>
         <td class="auto-style3"><asp:Label ID="Label3" runat="server" Text="Trình ban lãnh đạo công ty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> 
             <asp:TextBox ID="TextBox1" runat="server" Width="16px" Visible="false"></asp:TextBox>
         </td>
     </tr>
     <tr>
         <td class="auto-style2">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
    <tr>
        <td style="text-align:left;">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td class="auto-style2" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            </tr>
   
   </table>
<table border="0" cellpadding="0" cellspacing="0" style="width:1070px">
	<tbody>
		<tr>
			<td style="width: 123px;">
                <p>Tổng giám đốc</p>
				
					总经理</p>
			</td>
			<td style="width: 120px;">
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td style="width: 120px;">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td style="width: 135px;">
                <p>Chủ quản 7 đơn vị</p>
				<p>
					七大部门主管</p>
			</td>
			<td style="width: 130px;">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
			<td style="width: 114px;">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="Image5" runat="server" /></p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="Image4" runat="server" /></p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="Image3" runat="server" /></p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="Image2" runat="server" /></p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="Image1" runat="server" /></p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
                    <asp:Image ID="ImageLevel0" runat="server" Height="106px" Width="110px" />
					</p>
				
				
				
			</td>
		</tr>
	</tbody>
</table>
    </asp:Panel>
</asp:Content>
