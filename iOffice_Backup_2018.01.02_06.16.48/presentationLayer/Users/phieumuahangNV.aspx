<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="phieumuahangNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.phieumuahangNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/JScriptabc.js"></script>
    <script src="../../Scripts/getCommentNV.js"></script>
       <script type = "text/javascript">
           function PrintPanel() {
               var panel = document.getElementById("<%=pnlContents.ClientID %>");
               var printWindow = window.open('', '', 'height=800,width=870');
              
               
               document.getElementById("btnShowComment").style.display = "none";
               
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
      <asp:Panel ID="pnlContents" runat="server" style="border-style: solid; border-color: inherit; border-width:1px; margin-left:20px" Width="99%">

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
    
      
     <tr>
         <td class="auto-style3" style="text-align:left; height:15px"><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
      <tr>
          <td class="auto-style2" style="text-align:center"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
             
          </td>
      </tr>
   <tr>
        <td style="text-align:left;">Tiêu đề 题目:
            <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
         </td>
    </tr>
     
    <tr>
         <td style="text-align:left; " class="auto-style2">
            <asp:Label ID="lblNhanLyDo" runat="server" Text="Lý Do 原因:"></asp:Label>
        </td>
       
    </tr>
     <tr>
        <td style="text-align:left;">
            <asp:Label ID="lblLyDo" runat="server" Text=""></asp:Label></td>
    </tr>
     
   
   </table>
    <table style="float:left;width:1070px; border: 1px solid black;border-collapse: collapse; margin-bottom:-1px;" >
           <tr style="width:1070px;">
               <td  style="border: 1px solid black;border-collapse: collapse; width:450px;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse; text-align:center">
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:1070px;">
               <td colspan="2" style="text-align:left;border: 1px solid black;border-collapse: collapse;">
                   Mục đích sử dụng: <br />
                   使用目的:
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
      <div style="width:1070px; float:left">
           <asp:GridView ID="GridView1" runat="server" Width="1070px" ClientIDMode="Static" AutoGenerateColumns="False" style="margin-right: 0px">
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
                       <ItemStyle Width="500px" />
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
                       <ItemStyle Width="50px" />
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
                       <ItemStyle Width="340px" />
                   </asp:TemplateField>
                   
               </Columns>
           </asp:GridView>
       </div>
 
<table border="0" cellpadding="0" style="border: 1px solid black; border-collapse: collapse; width:1070px; float:left; border-top:hidden; ">
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
			<td class="auto-style2" style="border: 1px solid black;width:120px; border-collapse: collapse;">
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
        <br />
          <p style="width:800px;margin-left:150px">
              <asp:Button ID="btnShowComment" runat="server" ClientIDMode="Static" BackColor="#F0CCFF" ForeColor="Blue" Text="Show Coment" OnClick="btnShowComment_Click" /></p>
 <div id="divComment" runat="server" style="width:1000px">
     <asp:GridView ID="gridComment" runat="server" ClientIDMode="Static" AutoGenerateColumns="False" OnRowCancelingEdit="gridComment_RowCancelingEdit" OnRowEditing="gridComment_RowEditing" OnRowUpdating="gridComment_RowUpdating">
         <Columns>
             <asp:TemplateField HeaderText="Abstep">
                 <ItemTemplate>
                     <asp:Label ID="lblStep" runat="server" Text='<%#Eval("Abstep") %>'></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
              <asp:TemplateField HeaderText="ABPS">
                 <ItemTemplate>
                     <asp:Label ID="lblABPS" runat="server" Text='<%#Eval("abps") %>'></asp:Label>
                 </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Comment">
                 <ItemTemplate>
                     <asp:Label ID="lblCommet" runat="server" Text='<%#Eval("lydokhongduyet") %>'></asp:Label>
                 </ItemTemplate>
                 
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Answer">
                 <ItemTemplate>
                     <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QAmemo") %>'></asp:Label>
                 </ItemTemplate>
                   <EditItemTemplate>
                      <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" Text='<%#Eval("QAmemo") %>'></asp:TextBox>
                  </EditItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="" Visible="false">
                 <ItemTemplate>
                     <asp:Label ID="lblYn" runat="server" Text='<%#Eval("Yn") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Status">
                 <ItemTemplate>
                     <asp:Label ID="lblYnName" runat="server" Text='<%#Eval("YnName") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="User ID" Visible="false">
                 <ItemTemplate>
                     <asp:Label ID="lblAuditor" runat="server" Text='<%#Eval("Auditor") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Auditor">
                 <ItemTemplate>
                     <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField Visible="false">
                 <ItemTemplate>
                     <asp:Label ID="lblCreater" runat="server" Text='<%#Eval("from_user") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="linkEditComment" runat="server" ClientIDMode="Static" Text="Answer" CommandName="Edit"></asp:LinkButton>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:LinkButton ID="linkSaveComment" runat="server" ClientIDMode="Static" Text="Save" CommandName="Update"></asp:LinkButton>
                     <asp:LinkButton ID="linkCancelComment" runat="server" ClientIDMode="Static" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                 </EditItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
     <p style="width:800px;margin-left:150px">
              <asp:Button ID="btnHideComment" runat="server"  ClientIDMode="Static" Text="Hide Comment" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnHideComment_Click" /></p>
 </div>
  
    </asp:Panel>
     
    <p id="idButton" runat="server" style="width:1020px; text-align:center">
         <asp:Button ID="Button1" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Button" ToolTip=""  OnClick="Button1_Click" />  &nbsp;&nbsp; 
        <asp:Button ID="btnKhoiPhuc" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Button" OnClick="btnKhoiPhuc_Click" /> &nbsp;&nbsp; 
        <asp:Button ID="btnPrint" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Print" OnClientClick = "return PrintPanel();"  />
       
    &nbsp;
         <asp:Button ID="btnExport" runat="server" Text="Export PDN" OnClick="btnExport_Click" style="height: 26px" />
    </p>
    <p style="width:600px;margin-left:150px">
        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
    </p>
    <asp:Panel ID="idPanelExport" runat="server" >
          <div style="width:600px;height:400px; margin-left:250px;margin-top:100px">
             <br />
              <table>
                  <tr>
                      <td>
                           <asp:Label ID="Label1" runat="server" Text="Select Type"></asp:Label>
                      </td>
                      <td class="auto-style9">
                            <asp:DropDownList ID="dropTypePrint" runat="server" Height="16px" Width="127px">
                            <asp:ListItem Value="0">No Tilte</asp:ListItem>
                            <asp:ListItem Value="1">Title</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                     
                  </tr>
                  <tr>
                      <td>
                           <asp:Label ID="lblNhaCC" runat="server" ClientIDMode="Static" Text=""></asp:Label>
                      </td>
                      <td >
                            <asp:DropDownList ID="dropNhaCC" runat="server" Height="16px" Width="129px"></asp:DropDownList>
                      </td>
                      
                  </tr>
                  <tr>
                       <td>
                          <asp:Label ID="lblDDBH" runat="server" Text="DDBH:"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtDDBH" runat="server"></asp:TextBox>
                      </td>
                  </tr>
              </table>
         
             <p style="width: 390px; text-align:center">
                 <asp:Button ID="btnPrintPMH" runat="server" Text="Export" OnClick="btnPrintPMH_Click" />
             </p>
              <p style="width: 500px; text-align:left; margin-left:50px">
                  <asp:Label ID="lblThongbaoReport" runat="server" ForeColor="Red"></asp:Label>
              </p>
         </div>
    </asp:Panel>
     <div style="display:none">
             <div id="divShowComment" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>
</asp:Content>
