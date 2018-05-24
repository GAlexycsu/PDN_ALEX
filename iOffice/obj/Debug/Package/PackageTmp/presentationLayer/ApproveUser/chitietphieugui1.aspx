<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="chitietphieugui1.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.chitietphieudich1" %>
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
       <asp:Panel ID="pnlContents" runat="server" Width="1070px">
                 <table style="width: 1070px;  overflow:hidden">
        <tr>
            <td style="text-align:left" class="auto-style2"  ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td style="text-align:center" class="auto-style2"> <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
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
         <td class="auto-style2" style="text-align:left; "><asp:Label ID="Label3" runat="server" Text="Trình ban lảnh đạo Cty TNHH Tỷ Hùng 呈亿雄公司主管部"></asp:Label> </td>
     </tr>
     <tr>
         <td style="text-align:left;margin:10px" class="auto-style2">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
  <tr>
         <td style="text-align:right;" class="auto-style2">Độ ưu tiên 单据状态:
              <asp:Label ID="lblDoUutien" runat="server" Text=""></asp:Label>
         </td>
 </tr>
<tr>
      <td style="text-align:left;" class="auto-style2">Tiêu đề 题目:
         <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
      </td>
  </tr>
    <tr>
        <td style="text-align:left" class="auto-style2">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:972px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
        <td style="text-align:left;" class="auto-style2">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:966px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td style="text-align:left; " class="auto-style2">
            <asp:Label ID="lblNhanLyDo" runat="server" Text="Lý Do 原因: "></asp:Label></td>
        <td style="text-align:left;">
            <asp:Label ID="lblLyDo" runat="server" Text=""></asp:Label></td>
    </tr>
     <tr>
          <td style="text-align:right" class="auto-style2">  
         
             <asp:Label ID="lbNgay" runat="server" Text=""></asp:Label>
         
          </td>
  
            
   
   </table>
<table border="0" cellpadding="0" cellspacing="0" style="width:1070px">
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
            
			<td id="chunhiem" runat="server" style="text-align:center">
                <p>Chủ nhiệm</p>
				<p>
					主任</p>
			</td>
            
            <td id="andi" runat="server" >
                <p id="p1" runat="server">
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
             <td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel7" runat="server" />
                 
			</td>
            <td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel6" runat="server" />
              
			</td>
			<td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel5" runat="server" />
               
			</td>
			<td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel4" runat="server" />
              
			</td>
			<td id="chunhiem1" runat="server" style="height:30px;">
                <asp:Image ID="ImageLevel3" runat="server" />
               
			</td>
			<td id="andi1" runat="server" style="height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
                
			</td>
            <td  style="width:120px;height:30px;">
                <asp:Image ID="Image1" runat="server" />
             
			</td>
			<td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel1" runat="server" />
                
			</td>
			<td style="width:120px;height:30px;">
                <asp:Image ID="ImageLevel0" runat="server" />
			</td>
		</tr>
	</tbody>
</table>
 
   <br />
          <p style="width:800px;margin-left:150px">
              <asp:Button ID="btnShowComment" runat="server" BackColor="#F0CCFF" ForeColor="Blue" Text="Show Coment" OnClick="btnShowComment_Click" /></p>
 <div id="divComment" runat="server" style="width:1000px">
     <asp:GridView ID="gridComment" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gridComment_RowCancelingEdit" OnRowEditing="gridComment_RowEditing" OnRowUpdating="gridComment_RowUpdating">
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
                     <asp:LinkButton ID="linkEditComment" runat="server" Text="" CommandName="Edit"><img src="../../Content/menu/exit-button.png" /> Answer</asp:LinkButton>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:LinkButton ID="linkSaveComment" runat="server" Text="Save" CommandName="Update"></asp:LinkButton>
                     <asp:LinkButton ID="linkCancelComment" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                 </EditItemTemplate>
             </asp:TemplateField>
         </Columns>
         
<HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
     </asp:GridView>
     <p style="width:800px;margin-left:150px">
              <asp:Button ID="btnHideComment" runat="server" Text="Hide Comment" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnHideComment_Click" /></p>
 </div>
  
    </asp:Panel>
    
   <div id="divUpload2" runat="server" style="text-align:center;margin-left:150px; width: 914px;">
        <p style="width:587px; text-align:center;" > Attact File </p>
        <asp:GridView ID="gvDetails" CssClass="Gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="FilePath">
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
         <div class="button-wrap" style="width:942px; float:none;text-align:center">
             <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button Cancel" OnClick="btnBack_Click" BackColor="#F0CCFF" ForeColor="Blue" Width="99px" />&nbsp;&nbsp;
            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button print" OnClientClick = "return PrintPanel();" BackColor="#F0CCFF" ForeColor="Blue" Width="91px" />&nbsp;&nbsp;&nbsp <asp:Button ID="btnHuy" runat="server" Text="" CssClass="button delete" OnClick="btnHuy_Click" BackColor="#CCFFFF" ForeColor="Blue" Width="139px" /></div> 

    <div style="display:none">
             <div id="divShowComment" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>
</div>
</asp:Content>
