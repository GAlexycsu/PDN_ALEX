<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="frmchitietphieu1.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmchitietphieu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/JScriptabc.js"></script>
    <script src="../../Scripts/getComment.js"></script>
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


     <asp:Panel ID="pnlContents" runat="server" style="border-style: solid; border-color: inherit; border-width:1px; " Width="99%">
                 <table style="width: 1100px;  overflow:hidden">
        <tr>
            <td class="auto-style4" style="text-align:left"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                
            </td>
          
        </tr>
     <tr>
        <td>
            <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
        </td>
      
    </tr>
    
      
     <tr>
         <td class="auto-style3" style="text-align:left; height:15px"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
             <div  style="display:none">
                  <asp:TextBox ID="TextBox1" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox2" runat="server" Width="16px"  ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox3" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox4" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox5" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox6" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox7" runat="server"  Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox8" runat="server"  Width="33px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="TextBox9" runat="server" Width="16px" ClientIDMode="Static"></asp:TextBox>
                  <asp:TextBox ID="txtSoPhieu" runat="server" ClientIDMode="Static"></asp:TextBox>
                 <asp:TextBox ID="txtKhongDuyet" runat="server" ClientIDMode="Static"></asp:TextBox>
              </div>
          </td>
      </tr>
   
     
    <tr>
         <td style="text-align:left; " class="auto-style13">
            <asp:Label ID="lblNhanLyDo" runat="server" Text="Lý Do 原因:"></asp:Label>
        </td>
       
    </tr>
     <tr>
        <td style="text-align:left;">
            <asp:Label ID="lblLyDo" runat="server" Text=""></asp:Label></td>
    </tr>
     
   
   </table>
    <table style="float:left;width:1100px; border: 1px solid black;border-collapse: collapse; margin-bottom:-1px;" >
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
                   使用目的:
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
      <div style="width:1100px; float:left">
           <asp:GridView ID="GridView1" runat="server" Width="1100px" AutoGenerateColumns="False" style="margin-right: 0px">
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

<table border="0" cellpadding="0" style="border-left: 1px solid black; border-right: 1px solid black; border-bottom: 1px solid black; border-collapse: collapse; width:1100px; float:left; border-top-style: hidden; border-top-color: inherit; border-top-width: medium;">
	<tbody>
		<tr>
			<td class="auto-style5" style="border: 1px solid black; border-collapse: collapse;" >
                <p>Tổng giám đốc</p>
				
				<p>	总经理</p></td>
			<td class="auto-style6"style="border: 1px solid black; border-collapse: collapse;" >
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td class="auto-style6" style="border: 1px solid black; border-collapse: collapse;">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td class="auto-style1" style="border: 1px solid black; border-collapse: collapse;">
                <p>
                    <asp:Label ID="lbChucVu1VN" runat="server" Text="Chủ quản 7 đơn vị"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChucVu1TW" runat="server" Text="七大部门主管"></asp:Label></p>
			</td>
            
			<td id="chunhiem" runat="server" class="auto-style7" style="border: 1px solid black; border-collapse: collapse;">
                <p>Chủ nhiệm</p>
				<p>
					主任</p>
			</td>
            <td id="andi" runat="server" class="auto-style7" style="border: 1px solid black; border-collapse: collapse;">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7" style="border: 1px solid black; border-collapse: collapse;">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7" style="border: 1px solid black; border-collapse: collapse;">
                <p>
                    <asp:Label ID="lbChucVuTTVN" runat="server" Text="Tổ Trưởng"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChucVuTTTW" runat="server" Text="组长"></asp:Label>
					</p>
			</td>
			<td class="auto-style8" style="border: 1px solid black; border-collapse: collapse;">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
             <td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel7" runat="server" />
			</td>
            <td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel6" runat="server" />
			</td>
			<td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td class="auto-style2" style="width:120px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td id="chunhiem1" runat="server" class="auto-style4" style="border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel3" runat="server" />
			</td>
			<td id="andi1" runat="server" style="height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
			</td>
            <td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="Image1" runat="server" />
			</td>
			<td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel1" runat="server" />
			</td>
            
                 <td style="width:120px;height:30px;border: 1px solid black; border-collapse: collapse;">
                     <asp:Image ID="ImageLevel0" runat="server" />
                 </td>
            
		</tr>
	</tbody>
</table>
 
  
    </asp:Panel>
   <br />
  <div class="button-wrap" style="width:1024px;text-align:center;float:none">
      <asp:Button ID="Button1" runat="server" CssClass="button Cancel" Text="Button" BackColor="#F0CCFF" ForeColor="Blue" OnClick="Button1_Click" Width="100px" />
      &nbsp;
      <asp:Button ID="btnPrint" runat="server" CssClass="button print" Text="Print" BackColor="#F0CCFF" ForeColor="Blue" OnClientClick = "return PrintPanel();" Width="101px" />
  </div>
     <div style="display:none">
             <div id="divShowComment" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>    
    </div>
</asp:Content>
