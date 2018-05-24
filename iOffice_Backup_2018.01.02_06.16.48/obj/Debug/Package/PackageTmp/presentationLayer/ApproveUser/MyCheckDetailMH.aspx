<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="MyCheckDetailMH.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyCheckDetailMH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:Panel ID="pnlContents" runat="server" style="border-style: solid; border-color: inherit; width:99%; border-width:1px; margin-left:20px">
                 <table style="width: 90%;  overflow:hidden">
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
          <td style="text-align:left;">Tiêu đề 题目:
               <asp:Label ID="lblTieuDe" runat="server" Text=""></asp:Label>
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
    <table style="float:left;width:90%;border: 1px solid black;border-collapse: collapse; margin-bottom:-1px;" >
           <tr style="width:90%;">
               <td  style="border: 1px solid black;border-collapse: collapse; width:450px;">
                   Đơn vị đề nghị:<br />
                      提议单位 :
                    <asp:Label ID="lbldonvidenghi" runat="server" Text=""></asp:Label>
               </td>
              <td style="border: 1px solid black;border-collapse: collapse; text-align:center">
                  <asp:Label ID="lblNgaytao" runat="server" Text=""></asp:Label></td>
           </tr>
           <tr style="width:90%;">
               <td colspan="2" style="text-align:left;border: 1px solid black;border-collapse: collapse;">
                   Mục đích sử dụng: <br />
                   <asp:Label ID="lblMucDichSuDung" runat="server" Text=""></asp:Label>
               </td>
              
           </tr>
       </table>
       <div style="width:90%; float:left">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="Black"  >
           <Columns>
               <asp:TemplateField HeaderText="STT">
                      <ItemTemplate><%#GetSTT() %></ItemTemplate>
                      <HeaderStyle Width="30px" />
                   <ItemStyle  HorizontalAlign="Center"/>
                </asp:TemplateField>
               <asp:BoundField DataField="OfSuppliesName" HeaderText="TÊN HÀNG" >
               <HeaderStyle Width="400px" />
                  
               </asp:BoundField>
               <asp:BoundField DataField="BUnit" HeaderText="QUY CÁCH - CHỦNG LOẠI" >
               <HeaderStyle Width="99px" />
                   <ItemStyle  HorizontalAlign="Center"/>
               </asp:BoundField>
               <asp:BoundField DataField="BNumber" HeaderText="SỐ LƯỢNG" >
               <HeaderStyle Width="90px" />
                   <ItemStyle  HorizontalAlign="Center"/>
               </asp:BoundField>
               <asp:BoundField DataField="BCommnent" HeaderText="GHI CHÚ" >
               <HeaderStyle Width="250px" />
                  
               </asp:BoundField>
           </Columns>

               <EditRowStyle HorizontalAlign="Center" />

       </asp:GridView>
       </div>
 <table id="tabletam" runat="server" style="width:90%; float:left;border: 1px solid black;border-collapse: collapse; border-top:hidden;" >
          <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
         <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
             <tr >
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:30px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:400px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:100px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:90px;height:16px"></td>
              <td style="text-align:left;border: 1px solid black;border-collapse: collapse; width:250px;height:16px"></td>
          </tr>
      </table>

<table border="0" cellpadding="0" style="border: 1px solid black; border-collapse: collapse; width:90% ; float:left"  >
	<tbody>
		<tr>
			<td class="auto-style5" style="border: 1px solid black; border-collapse: collapse; text-align:center" >
                <p>Tổng giám đốc</p>
				
				<p>	总经理</p></td>
			<td class="auto-style6"style="border: 1px solid black; border-collapse: collapse;text-align:center" >
                <p>PT. Giám đốc</p>
				<p>
					副总经理</p>
			</td>
			<td class="auto-style6" style="border: 1px solid black; border-collapse: collapse;text-align:center">
                <p>Hiệp Lý</p>
				<p>
					协理</p>
			</td>
			<td class="auto-style1" style="border: 1px solid black; border-collapse: collapse;text-align:center">
                <p>
                    <asp:Label ID="lbChucVu1VN" runat="server" Text="Chủ quản 7 đơn vị"></asp:Label></p>
				<p>
                    <asp:Label ID="lbChucVu1TW" runat="server" Text="七大部门主管"></asp:Label></p>
			</td>
            
			<td id="chunhiem" runat="server" class="auto-style7" style="border: 1px solid black; border-collapse: collapse;text-align:center">
                <p>Chủ nhiệm</p>
				<p>
					主任</p>
			</td>
            <td id="andi" runat="server" class="auto-style7" style="border: 1px solid black; border-collapse: collapse;text-align:center">
                <p>Chủ quản đơn vị</p>
				<p>
					单位主管</p>
			</td>
            <td class="auto-style7" style="border: 1px solid black; border-collapse: collapse;text-align:center">
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
			<td class="auto-style8" style="border: 1px solid black; border-collapse: collapse;text-align:center">
                <p>Người lập biểu</p>
				<p>
					制表人</p>
			</td>
		</tr>
		
		<tr>
             <td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel7" runat="server" />
			</td>
            <td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel6" runat="server" />
			</td>
			<td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel5" runat="server" />
			</td>
			<td class="auto-style2" style="border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel4" runat="server" />
			</td>
			<td id="chunhiem1" runat="server" class="auto-style4" style="border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel3" runat="server" />
			</td>
			<td id="andi1" runat="server" style="width:106px;height:30px;">
                <asp:Image ID="ImageLevel2" runat="server" />
			</td>
            <td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="Image1" runat="server" />
			</td>
			<td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                <asp:Image ID="ImageLevel1" runat="server" />
			</td>
            
                 <td style="width:106px;height:30px;border: 1px solid black; border-collapse: collapse;">
                     <asp:Image ID="ImageLevel0" runat="server" />
                 </td>
            
		</tr>
	</tbody>
</table>
   <div id="divUpload2" runat="server" style="margin-left:20px">
        <p style="width:400px;text-align:center;" > Attact File </p>
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

    
    </asp:Panel>

    <br />
             <br />
             <br />
    <p style="margin-left:100px">
            <asp:Button ID="btnHuy" runat="server" OnClick="btnHuy_Click" Text="删除" Width="154px" /> &nbsp;

         
     <asp:Button ID="btnContinues" runat="server" Text="继续" OnClick="btnContinues_Click" Width="89px" />
&nbsp;
    
      <asp:Button ID="btnBoQua" runat="server" Text="Không phải trách nhiệm của tôi" OnClick="btnBoQua_Click" />
        </p>
</asp:Content>
