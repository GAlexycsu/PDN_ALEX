<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmchitietphieumuahang.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmchitietphieumuahang" %>
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
    <div style="margin-left:20px">
       <asp:Panel ID="pnlContents" runat="server" style="border-style: solid; border-color: inherit; border-width:1px;" Width="99%">
                 <table style="width: 1070px;  overflow:hidden">
        <tr>
            <td class="auto-style4" style="text-align:left"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                
            </td>
          
        </tr>
     <tr>
        <td>
            <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
        </td>
      
    </tr>
    
      <tr> <td style="float:right">
           <asp:Label ID="Label1Sophieucu" runat="server" Text="Số phiếu cũ"></asp:Label> <asp:Label ID="Label2cophieucu" runat="server" Text=""></asp:Label></td></tr>
     <tr>
         <td class="auto-style3" style="text-align:left; height:15px"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
              <asp:TextBox ID="TextBox1" runat="server" Width="16px"></asp:TextBox>
          </td>
      </tr>
   <tr>
      <td style="text-align:left;">Tiêu đề 题目:
         <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
      </td>
  </tr>
     
    
     <tr>
        <td style="text-align:left;">
            <asp:Label ID="lblLyDo" runat="server" Text=""></asp:Label></td>
    </tr>
     
   
   </table>
   <table style="float:left;width:1070px; border: 1px solid black;border-collapse: collapse; margin-bottom:-1px;" >
           <tr style="width:870px;">
               <td  style="border: 1px solid black;border-collapse: collapse; width:450px;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse; text-align:center">
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:870px;">
               <td colspan="2" style="text-align:left;border: 1px solid black;border-collapse: collapse;">
                   Mục đích sử dụng: <br />
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
  <div style="width:99%; float:left">
          <asp:GridView ID="GridView1" runat="server" Width="1070px" AutoGenerateColumns="False" style="margin-right: 0px">
               <Columns>
                 <asp:TemplateField HeaderText="STT &lt;br/&gt; 次序">
                      <ItemTemplate><%#GetSTT() %></ItemTemplate>
                     <ItemStyle Width="30px" />
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Cong ty" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="Ma Phieu" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblPDNO" runat="server" Text='<%#Eval("pdNO") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="Ma hang" Visible="false">
                       <ItemTemplate>
                           <asp:Label ID="lblCLBH" runat="server" Text='<%#Eval("CLBH") %>'></asp:Label>
                       </ItemTemplate>
                       
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" TÊN HÀNG">
                       <ItemTemplate>
                           <asp:Label ID="lblMemo0" runat="server" Text='<%#Eval("Memo0") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="450px" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" Size">
                       <ItemTemplate>
                           <asp:Label ID="lblSize" runat="server" Text='<%#Eval("Size") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField  HeaderText="QUY CÁCH - CHỦNG LOẠI 規格">
                       <ItemTemplate>
                           <asp:Label ID="lblDWBH" runat="server" Text='<%#Eval("dwbh") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="140px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText=" SỐ LƯỢNG 數量">
                       <ItemTemplate>
                           <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty","{0:0,0}") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>

                   <asp:TemplateField HeaderText="GHI CHÚ 備註">
                       <ItemTemplate>
                           <asp:Label ID="lblCLMemo" runat="server" Text='<%#Eval("CLmemo") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="300px" />
                   </asp:TemplateField>
                   
               </Columns>
           </asp:GridView>
       </div>

<table border="0" cellpadding="0" cellspacing="0" style="border-left: 1px solid black; border-right: 1px solid black; border-bottom: 1px solid black; border-collapse: collapse;width:1070px; float:left; border-top-style: hidden; border-top-color: inherit; border-top-width: medium;">
	<tbody>
		<tr>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style14">
                <p>Tổng giám đốc</p>
				
					总经理</p></td>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style15">
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style15">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style16">
                <p>Chủ quản 7 đơn vị</p>
				<p>
					七大部门主管</p>
			</td>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style17">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
			<td style="border: 1px solid black; border-collapse: collapse;" class="auto-style18">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="Image5" runat="server" /></p>
			</td>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="Image4" runat="server" /></p>
			</td>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="Image3" runat="server" /></p>
			</td>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="Image2" runat="server" /></p>
			</td>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="Image1" runat="server" /></p>
			</td>
			<td style="width:178px;height:41px;border: 1px solid black; border-collapse: collapse;">
				<p>
                    <asp:Image ID="ImageLevel0" runat="server" Height="106px" Width="118px" />
					</p>
				
				
				
			</td>
		</tr>
	</tbody>
</table>
 
  
    </asp:Panel>
  <div id="divUpload2" runat="server">
        <p style="width:771px; text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="FilePath" Width="446px">
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
               <asp:LinkButton ID="lnkDownload" runat="server" Text="" OnClick="lnkDownload_Click" ><img src="../../Content/Icon/download.png" /> Download</asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
    </div>
    </div>
</asp:Content>
