<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="chitietphieugui2ND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.chitietphieugui2ND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
      <script type = "text/javascript">
          function PrintPanel() {
              var panel = document.getElementById("<%=pnlContents.ClientID %>");
               var printWindow = window.open('', '', 'height=800,width=870');
               // printWindow.document.write('<html><head><title>DIV Contents</title>');
               // printWindow.document.write('</head><body >');
               printWindow.document.write(panel.innerHTML);
               printWindow.document.write('</body></html>');
               printWindow.document.close();
               setTimeout(function () {
                   printWindow.print();
               }, 500);
               return false;
           }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="pnlContents" runat="server">
                 <table style="width: 1070px;  overflow:hidden">
        <tr>
            <td class="auto-style4" style="text-align:left"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style12" style="text-align:center;height:15px"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox2" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox3" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox4" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox5" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox6" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox8" runat="server" ReadOnly="True" Visible="False" Width="33px"></asp:TextBox>
          </td>
      </tr>
     <tr>
         <td class="auto-style10" style="text-align:left;height:15px"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td class="auto-style2" style="text-align:left;margin:10px">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
    <tr>
        <td class="auto-style2" style="text-align:left">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left;">
            <asp:Label ID="lblLyDo" runat="server" Text=""></asp:Label></td>
    </tr>
     <tr>
          <td class="auto-style2" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            
   
   </table>
<table border="0" cellpadding="0" cellspacing="0" style="width:1062px">
	<tbody>
		<tr>
			<td class="auto-style5">
                <p>Tổng giám đốc</p>
				
					总经理</p></td>
			<td class="auto-style6">
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td class="auto-style6">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td class="auto-style1">
                <p>
                    <asp:Label ID="lbChucVu1VN" runat="server" Text="Thống kê tổng hợp"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChucVu1TW" runat="server" Text="七大部门主管"></asp:Label></p>
			</td>
            
			<td class="auto-style7">
                <p>Chủ nhiệm</p>
				<p>
					主任</p>
			</td>
            
            <td class="auto-style7">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7">
                <p>
                    <asp:Label ID="lbChucVuTTVN" runat="server" Text="Tổ Trưởng"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChucVuTTTW" runat="server" Text="组长"></asp:Label>
					</p>
			</td>
			<td class="auto-style8">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
             <td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel7" runat="server" />
			</td>
            <td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel6" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel3" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel1" runat="server" />
			</td>
			<td style="width:130px;height:30px;">
                <asp:Image ID="ImageLevel0" runat="server" />
			</td>
		</tr>
	</tbody>
</table>
 
  
    </asp:Panel>
  
         <p style="width:1072px;text-align:center">
            <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#F0CCFF" ForeColor="Blue" OnClientClick = "return PrintPanel();" /></p>
</asp:Content>
