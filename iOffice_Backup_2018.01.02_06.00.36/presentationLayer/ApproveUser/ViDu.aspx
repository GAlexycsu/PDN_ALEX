<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViDu.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.ViDu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
     <style type="text/css">
         .auto-style1 {
             width: 135px;
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
             width: 115px;
         }
         .auto-style6 {
             height: 30px;
             width: 115px;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0">
	<tbody>
		<tr>
			<td style="width: 123px;">
                <p>Tổng giám đốc</p>
				
					总经理</p></td>
			<td style="width: 120px;">
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td class="auto-style5">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td class="auto-style1">
                <p>Chủ quản 7 đơn vị</p>
				<p>
					七大部门主管</p>
			</td>
            <td class="auto-style3">
                <p>
                    <asp:Label ID="lbChuQuanTKVN" runat="server" Text="Chủ quản Thông kê"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChuQuanTKTW" runat="server" Text="单位主管"></asp:Label></p>
			</td>
			<td style="width: 130px;">
                <p>
                    <asp:Label ID="lbChuNhiemVN" runat="server" Text="Chủ nhiệm"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChuNhiemTW" runat="server" Text="单位主管"></asp:Label></p>
			</td>
            
            <td style="width: 130px;">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td style="width: 130px;">
                <p>Tổ trưởng</p>
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
                <asp:Image ID="ImageLevel8" runat="server" />
			</td>
             <td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel7" runat="server" />
			</td>
            <td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel6" runat="server" />
			</td>
			<td class="auto-style6">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td class="auto-style2">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td class="auto-style4">
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
    </div>
    </form>
</body>
</html>
