<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteAddmin.Master" AutoEventWireup="true" CodeBehind="FQuyTrinhXetDuyetDanhChoCanBo.aspx.cs" Inherits="iOffice.presentationLayer.Admin.FQuyTrinhXetDuyetDanhChoCanBo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p><%=hasLanguege["lbQuytrinhXetDuyet"].ToString() %></p>

     
              <table style="width: 594px">
        
        <tr>
            <td>
                  <%=hasLanguege["lbCty"].ToString() %>          </td>
           <td> <asp:DropDownList ID="DropCty" runat="server">
                <asp:ListItem Value="LTY"></asp:ListItem>
                <asp:ListItem>LBT</asp:ListItem>
                <asp:ListItem Value="LMY"></asp:ListItem>
                <asp:ListItem>LPM</asp:ListItem>
                <asp:ListItem Value="LYY"></asp:ListItem>
                <asp:ListItem Value="TST"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
            
        <tr>
            <td><%=hasLanguege["lblLieuPhieu"].ToString() %> 
               </td>
            <td>
                <asp:DropDownList ID="DropDownLoaiPhieu" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Query" OnClick="Button2_Click" />
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Back" OnClick="Button3_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lbDonVi"].ToString() %>
            </td>
            <td>
                <asp:DropDownList ID="DropDownLDonVi" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" /></td>
            <td>
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckThongQuaDonVi" runat="server" Text="Thông qua đơn vị" AutoPostBack="True" OnCheckedChanged="CheckThongQuaDonVi_CheckedChanged" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownDonViThongQua" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <%=hasLanguege["lbNguoiDuyet"].ToString() %>
            </td>
            <td>
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox>
            </td>
        </tr>
        
       <tr>
           <td><%=hasLanguege["lblBuocDuyet"].ToString() %></td>
           <td>
               <asp:TextBox ID="txtBucoDuyet" runat="server"></asp:TextBox></td>
           <td>
               <%=hasLanguege["lblChuy"].ToString() %></td>
       </tr>
        
    </table>
   
    <div>
        <p>
        <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </div>
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Lưu" OnClick="Button1_Click" />
            </td>
           
        </tr>
    </table>
    <div style="width:800px; overflow:auto;" >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="1085px" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="IDQuyTrinh" AllowPaging="True" Height="777px" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:TemplateField HeaderText="Delete">
                    
                            <ItemTemplate> 
                                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 
                </asp:TemplateField>
                <asp:BoundField DataField="IDQuyTrinh" HeaderText="ID" />
                <asp:BoundField DataField="GSBH" />
                <asp:BoundField DataField="abtype" />
                <asp:BoundField DataField="abtypenameTW" />
                <asp:BoundField DataField="BADEPID" />
                <asp:BoundField DataField="tendonviTW" />
                <asp:BoundField DataField="DonViThongQua" />
                <asp:BoundField DataField="tendonvithongqua" />
                <asp:BoundField DataField="BuocDuyet" />
                <asp:BoundField DataField="NguoiDuyet" />
                <asp:BoundField DataField="USERNAME" />
                <asp:BoundField DataField="IDChucVu" />
                <asp:BoundField DataField="TenChucVuTiengHoa" />
                <asp:BoundField DataField="IDCapDuyet" />
                <asp:BoundField DataField="IDLoaiDonVi" />
                <asp:BoundField DataField="DepartmentTypeNameTW" />
                 <asp:TemplateField HeaderText="STT">
                     <ItemTemplate><%#GetSTT() %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </div>
</asp:Content>
