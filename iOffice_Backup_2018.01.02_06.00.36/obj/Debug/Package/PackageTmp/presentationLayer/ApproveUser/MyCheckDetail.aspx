<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="MyCheckDetail.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyCheckDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .Gridview {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="border-style: solid; border-color: inherit; width:983px; border-width:1px; text-align:center; margin-left:115px">
      <table style="width: 957px;  overflow:hidden">
        <tr>
            <td style="height:12px" ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td  style="height:12px; text-align:center " > <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox2" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox3" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox4" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox5" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox6" runat="server" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
              <asp:TextBox ID="TextBox8" runat="server" ReadOnly="True" Visible="False" Width="33px"></asp:TextBox>
              <asp:TextBox ID="TextBox9" runat="server" Width="16px"></asp:TextBox>
          </td>
      </tr>
     <tr>
         <td style="height:12px"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td style="text-align:left;">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
     <tr>
                <td style="text-align:right;">Độ ưu tiên 单据状态:
                    <asp:Label ID="lblDoUutien" runat="server" Text=""></asp:Label>
                </td>
      </tr>
    <tr>
      <td style="text-align:left;">Tiêu đề 题目:
         <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
      </td>
  </tr>
    <tr>
        <td style="text-align:left;" >
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
        <td style="text-align:left;">
           Nội dung dịch 翻译内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:800px">
                <asp:Label ID="lbNoidungdich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
          <td  style="height:12px; text-align:right">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            
   
   </table>
<table border="0" cellpadding="0" cellspacing="0">
	<table border="0" cellpadding="0" cellspacing="0" style="width: 968px">
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
                    Chủ quản 7 đơn vị</p>
				<p>
                   七大部门主管</p>
			</td>
            
			<td id="chunhiem" runat="server" class="auto-style7">
                <p>Chủ nhiệm</p>
				<p>
					主任</p>
			</td>
            
            <td ID="andi" runat="server" class="auto-style7">
                <p ID="p1" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Chủ quản đơn vị"></asp:Label></p>
				<p id="p2" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="单位主管"></asp:Label></p>
               
			</td>
            <td  class="auto-style7"> 
                 <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7">
                <p>
                    Tổ Trưởng</p>
				<p>
                    组长
					</p>
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
			<td style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td id="chunhiem1" runat="server" style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel3" runat="server" />
			</td>
			<td id="andi1" runat="server" style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
			</td>
            <td  style="width:106px;height:30px;">
                <asp:Image ID="Image1" runat="server" />
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
</table>
          <div id="divUpload2" runat="server">
        <p style="width:400px;text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="FilePath" OnRowDeleting="gvDetails_RowDeleting" Width="441px">
            <HeaderStyle BackColor="#df5015" />
            <Columns>
                 <asp:TemplateField HeaderText="ID" Visible="false">
                     <ItemTemplate>
                        <asp:Label ID="lblIDAttactFile" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
            <asp:BoundField DataField="Filename" HeaderText="File Name" >
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                
                </asp:BoundField>
            <asp:TemplateField HeaderText="Download File">
            <ItemTemplate>
               <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click" ></asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
    </div>
             <br />
             <br />
       </div>
    <div style="margin-left:300px">
         <asp:Button ID="btnHuy" runat="server" OnClick="btnHuy_Click" Text="删除" Width="154px" /> &nbsp;

         
     <asp:Button ID="btnContinues" runat="server" Text="继续" OnClick="btnContinues_Click" Width="89px" />
        &nbsp;
    
      <asp:Button ID="btnBoQua" runat="server" Text="Không phải trách nhiệm của tôi" OnClick="btnBoQua_Click" />
         

    </div>
           

</asp:Content>
