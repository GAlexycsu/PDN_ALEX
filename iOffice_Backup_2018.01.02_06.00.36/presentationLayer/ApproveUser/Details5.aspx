<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteApproved.Master" AutoEventWireup="true" CodeBehind="Details5.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.Details5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
     <style type="text/css">
         .auto-style1 {
             width: 135px;
             height: 77px;
         }
         .auto-style2 {
             height: 30px;
             width: 135px;
         }
         .auto-style3 {
             width: 130px;
         }
         .auto-style4 {
             height: 30px;
             width: 130px;
         }
         .auto-style5 {
             width: 123px;
             height: 77px;
         }
         .auto-style6 {
             width: 120px;
             height: 77px;
         }
         .auto-style7 {
             width: 130px;
             height: 77px;
         }
         .auto-style8 {
             width: 114px;
             height: 77px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="pnlContents" runat="server">
                 <table style="width: 829px; height: 600px; overflow:hidden">
        <tr>
            <td class="auto-style4" style="text-align:left"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
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
         <td class="auto-style3" style="text-align:left"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
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
          <td class="auto-style2" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            
   
   </table>
<table border="0" cellpadding="0" cellspacing="0">
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
                <p>Chủ quản 7 đơn vị</p>
				<p>
					七大部门主管</p>
			</td>
           <td class="auto-style7">
                <p>Chủ nhiệm</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7">
                <p>Tổ trưởng</p>
				<p>
					单位主管</p>
			</td>
			<td class="auto-style8">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
             <td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel7" runat="server" />
			</td>
            <td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel6" runat="server" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td class="auto-style2">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td class="auto-style4">
                <asp:Image ID="ImageLevel3" runat="server" Height="16px" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel1" runat="server" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel0" runat="server" />
			</td>
		</tr>
	</tbody>
</table>
 
  
    </asp:Panel>
  
         <p style="width:30px;float:none">
            <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#F0CCFF" ForeColor="Blue" OnClientClick = "return PrintPanel();" />
</asp:Content>
