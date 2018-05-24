<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frChiTietKhongduyet.aspx.cs" Inherits="iOffice.presentationLayer.Users.frChiTietKhongduyet" %>
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
    
      <tr> <td style="float:right">
           <asp:Label ID="Label1Sophieucu" runat="server" Text="Số phiếu cũ"></asp:Label> <asp:Label ID="Label2cophieucu" runat="server" Text=""></asp:Label></td></tr>
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
         <td class="auto-style2" style="text-align:left;margin:10px">Đơn vị đề nghị 提议单位 : <asp:Label ID="lbBoPhan" runat="server" Text=""></asp:Label> </td>
     </tr>
 <tr>
       <td style="text-align:left;">Tiêu đề 题目:
                    <asp:Label ID="lblTieuDe" runat="server" Text="Apply by computer"></asp:Label>
       </td>
      </tr>
    <tr>
        <td class="auto-style2" style="text-align:left">
           Nội dung 内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:1042px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
         <tr>
        <td style="text-align:left;">Nội dung dịch 翻译内容 :&nbsp;&nbsp; 
            <div style="overflow:hidden; width:1040px">
                <asp:Label ID="LbNoiDungDich" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
         <td style="text-align:left; width:100px">
            <asp:Label ID="lblNhanLyDo" runat="server" Text="Lý Do 原因:"></asp:Label>
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
    <table border="0" cellpadding="0" cellspacing="0" style="width: 1070px">
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
                        <asp:Label ID="lbChucVu1VN" runat="server" Text="Chủ quản 7 đơn vị"></asp:Label></p>
				    <p>
                        <asp:Label ID="lbChucVu1TW" runat="server" Text="七大部门主管"></asp:Label></p>
			    </td>
            
			    <td id="chunhiem" runat="server" class="auto-style7">
                    <p>Chủ nhiệm</p>
				    <p>
					    主任</p>
			    </td>
                <td id="andi" runat="server" class="auto-style7">
                    <p>Chủ quản đơn vị</p>
				    <p>
					    单位主管</p>
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
                <td style="width:120px;height:30px;">
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
             </asp:TemplateField>
              <asp:TemplateField HeaderText="ABPS">
                 <ItemTemplate>
                     <asp:Label ID="lblABPS" runat="server" Text='<%#Eval("abps") %>'></asp:Label>
                 </ItemTemplate>
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
                     <asp:LinkButton ID="linkEditComment" runat="server" Text="" CommandName="Edit"><img src="../../Content/menu/exit-button.png" />Answer </asp:LinkButton>
                 </ItemTemplate>
                 <EditItemTemplate>
                     <asp:LinkButton ID="linkSaveComment" runat="server" Text="Save" CommandName="Update"></asp:LinkButton>
                     <asp:LinkButton ID="linkCancelComment" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                 </EditItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
     <p style="width:800px;margin-left:150px">
              <asp:Button ID="btnHideComment" runat="server" Text="Hide Comment" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnHideComment_Click" /></p>
 </div>
    </asp:Panel>
    <br />
    <div class="button-wrap" style="width:90%; text-align:center;margin-left:20px">
        <asp:Button ID="Button1" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel" Text="Button" OnClick="Button1_Click" Width="87px" />&nbsp;&nbsp;
        <asp:Button ID="btnKhoiPhuc" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button edit" Text="Sửa phiếu đã không được duyệt để gửi lại" OnClick="btnKhoiPhuc_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnPrint" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button print" Text="Print" OnClientClick = "return PrintPanel();" Width="95px" />
    </div>
    <div style="display:none; margin-left:20px">
             <div id="divShowComment" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>
</asp:Content>
