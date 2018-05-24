<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="frmDetails.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.frmDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/JScriptabc.js"></script>
    <script src="../../Scripts/getComment.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-left:20px">
    <div style="border-style: solid; border-color: inherit; width:1098px; border-width:1px; margin-top: 10px;">
      <table style="width: 1070px;  overflow:hidden">
        <tr>
            <td style="height:12px" ><asp:Label ID="lbCty" runat="server" Text="Công ty TNHH Tỷ Hùng 億 雄 責 任 有 限 公 司"></asp:Label>
                <asp:Label ID="lbSoPhieu" runat="server" Text="" style="float:right"></asp:Label>
            </td>
        </tr>
      <tr>
          <td  style="height:12px; text-align:center " > <asp:Label ID="lbLoaiPhieu" runat="server" Text="" BorderColor="Red"></asp:Label>
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
            
            <div style="overflow:hidden; width:1054px">
                <asp:Label ID="lbNoiDung" runat="server" Text=""></asp:Label>
            </div>
        </td>
    </tr>
     <tr>
        <td style="text-align:left;">
           Nội dung dịch 翻译内容:&nbsp;&nbsp; 
            
            <div style="overflow:hidden; width:1051px">
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
			<td id="chunhiem1" runat="server" style="width:106px;height:30px;">
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
                  <EditItemTemplate>
                      <asp:TextBox ID="txtEditComment" runat="server" TextMode="MultiLine" Text='<%#Eval("lydokhongduyet") %>'></asp:TextBox>
                  </EditItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Answer">
                 <ItemTemplate>
                     <asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("QAmemo") %>'></asp:Label>
                 </ItemTemplate>
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
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:LinkButton ID="linkEditComment" runat="server" Text="" CommandName="Edit"><img src="../../Content/img/edit16x16.png" />Write Comment </asp:LinkButton>
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
</table>
          <div id="divUpload2" runat="server" style="text-align:center;margin-left:150px; width: 928px;">
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
               <asp:LinkButton ID="lnkDownload" runat="server" Text="" OnClick="lnkDownload_Click" > <img src="../../Content/Icon/download.png" />Download</asp:LinkButton>
            </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" />
            </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
    </div>
             <br />
             <br />
       </div>
    <br />
        <div class="button-wrap" style="width:1024px;text-align:center;float:none">
         <asp:Button ID="btnHuy" runat="server" BackColor="#F0CCFF" ForeColor="Blue" CssClass="button Cancel" OnClick="btnHuy_Click" Text="删除" Width="154px" /> &nbsp;&nbsp;
         <asp:Button ID="btnContinues" runat="server" Text="继续" BackColor="#F0CCFF" CssClass="button Continue" ForeColor="Blue" OnClick="btnContinues_Click" Width="89px" />&nbsp;&nbsp;
         </div>
     <div style="display:none">
             <div id="divShowComment" style="overflow:auto; max-height:500px" >
               
           </div>
    </div>
    </div>
</asp:Content>
