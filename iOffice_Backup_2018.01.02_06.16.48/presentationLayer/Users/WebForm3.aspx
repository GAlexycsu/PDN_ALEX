<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="iOffice.presentationLayer.Users.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 106px;
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 829px; height: 519px; overflow:hidden">
        <tr>
            <td class="auto-style2"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="Label2" runat="server" Text="PHIẾU ĐỀ NGHỊ" BorderColor="Red"></asp:Label></td>
      </tr>
     <tr>
         <td class="auto-style3"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng"></asp:Label> </td>
     </tr>
     <tr>
         <td class="auto-style2">Bộ phận : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
    <tr>
        <td class="auto-style2">
            Nội dung:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td class="auto-style2" style="text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
             <button onclick="myFunction()">Print this page</button> </tr>
   
   </table>
<table border="0" cellpadding="0" cellspacing="0">
	<tbody>
		<tr>
			<td style="width: 123px;">
				<p>
					Tổng giám đốc</p>
			</td>
			<td style="width: 120px;">
				<p>
					Phó giám đốc</p>
			</td>
			<td style="width: 120px;">
				<p>
					Hiệp lý</p>
			</td>
			<td style="width: 135px;">
				<p>
					Chủ quản 7 đơn vị</p>
			</td>
			<td style="width: 130px;">
				<p>
					Chủ quản đơn vị</p>
			</td>
			<td style="width: 114px;">
				<p>
					Lập biểu</p>
			</td>
		</tr>
		<tr>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
			<td class="auto-style1">
				<p>
					&nbsp;</p>
			</td>
		</tr>
		<tr>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
			</td>
			<td style="width:106px;height:41px;">
				<p>
					Image chữ ký</p>
				
				
				
			</td>
		</tr>
	</tbody>
</table>
   
 </form>
</body>
</html>
