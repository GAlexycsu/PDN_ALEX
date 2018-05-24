<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteApproved.Master" AutoEventWireup="true" CodeBehind="frmreview1.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmreview1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 829px; height: 450px; overflow:hidden">
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
	<%--	<tr>
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
		</tr>--%>
		
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
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel3" runat="server" />
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
</asp:Content>
