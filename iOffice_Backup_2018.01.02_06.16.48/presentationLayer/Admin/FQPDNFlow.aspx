<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FQPDNFlow.aspx.cs" Inherits="iOffice.presentationLayer.Admin.FQPDNFlow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/Xacnhanxoa.js" type="text/javascript"></script>
     <link href="../../Style/GridviewScroll.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: 1075,
                height: 600
            });
        }
</script>

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <p><%=hasLanguege["lbQPDNFlow"].ToString() %></p>

     <table style="width:auto;  border-bottom-style: dotted; border-bottom-color: blue; border-bottom-width: thin;">
           <tr>
            <td>
                  <%=hasLanguege["lbCty"].ToString() %>          </td>
           <td> <asp:DropDownList ID="DropCty" runat="server">
                <asp:ListItem Value="LTY"></asp:ListItem>
            </asp:DropDownList></td>
             <td>
                <%=hasLanguege["lblLieuPhieu"].ToString() %>  </td>
            <td>
                <asp:DropDownList ID="DropDownLoaiPhieu" runat="server">
                    
                </asp:DropDownList>
            </td>
             <td>
                <%=hasLanguege["lbDonVi"].ToString() %>
               
            </td>
            <td>
                <asp:DropDownList ID="DropDownLDonVi" runat="server"></asp:DropDownList>
            </td>
            <td class="auto-style1">
                <asp:Button ID="Button2" runat="server" Text="Query" OnClick="Button2_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Back" OnClick="Button3_Click" />
            </td>
        </tr>
            
     </table>
              <table style="width: auto">

        <tr>
           
            <td class="auto-style1">
                <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" /></td>
            <td class="auto-style2">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Height="26px" Width="46px" /></td>
        </tr>

      
       <tr>
           <td><%=hasLanguege["lblBuocDuyet"].ToString() %></td>
           <td class="auto-style2">
               <asp:DropDownList ID="DropDownABStep" runat="server">
                   <asp:ListItem Value="1">Step 1</asp:ListItem>
                   <asp:ListItem Value="2">Step 2</asp:ListItem>
                   <asp:ListItem Value="3">Step 3</asp:ListItem>
                   <asp:ListItem Value="4">Step 4</asp:ListItem>
                   <asp:ListItem Value="5">Step 5</asp:ListItem>
                   <asp:ListItem Value="6">Step 6</asp:ListItem>
                   <asp:ListItem Value="7">Step 7</asp:ListItem>
                   <asp:ListItem Value="8">Step 8</asp:ListItem>
                   <asp:ListItem Value="9">Step 9</asp:ListItem>
               </asp:DropDownList>
                
               
           </td>
           <td class="auto-style1">並列審核者:&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropDownList ID="DropDownABPS" runat="server">
                   <asp:ListItem Value="1">ABPS 1</asp:ListItem>
                   <asp:ListItem Value="2">ABPS 2</asp:ListItem>
                   <asp:ListItem Value="3">ABPS 3</asp:ListItem>
                   <asp:ListItem Value="4">ABPS 4</asp:ListItem>
                   <asp:ListItem Value="5">ABPS 5</asp:ListItem>
               </asp:DropDownList>
           </td>
            <td>
                <%=hasLanguege["lbNguoiDuyet"].ToString() %>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtNguoiDuyet" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="groupThem" ControlToValidate="txtNguoiDuyet" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
       </tr>
        
    </table>
     <p style="width:841px; margin-left:100px">
        <asp:Button ID="Button1" runat="server" Text="Lưu" OnClick="Button1_Click" ValidationGroup="groupThem" style="height: 26px" />
    </p>
    <div>
        <p>
        <asp:Label ID="lbThongBao" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </div>

  
    <div style="width:1155px; overflow:auto;" >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="1070px" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="IDQuyTrinh" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="20">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Modify" HeaderText="Modify" />
               <asp:TemplateField HeaderText="Delete">
                    <%--<ItemTemplate>
                     <a href='XoaQuyTrinh.aspx?IDQuyTrinh=<%#Eval("IDQuyTrinh") %>' OnClientClick="javascript:return confirm('Are you sure you want to delete this event?');">Delete</a>
                    </ItemTemplate>--%>
                            <ItemTemplate> 
                                <asp:Button ID="Button1" runat="server" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 
                </asp:TemplateField>
               
                
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIDQuyTrinh" runat="server" Text='<%#Eval("IDQuyTrinh") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
          
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblabtype" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
                      <ItemTemplate>
                          <asp:Label ID="lblabtypenameTW" runat="server" Text='<%#Eval("abtypenameTW") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblBADEPID" runat="server" Text='<%#Eval("BADEPID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbltendonviTW" runat="server" Text='<%#Eval("tendonviTW") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="审核步骤">
                    <ItemTemplate>
                        <asp:Label ID="lblABstep" runat="server" Text='<%#Eval("ABstep") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="並列審核者">
                    <ItemTemplate>
                        <asp:Label ID="lblABPS" runat="server" Text='<%#Eval("ABPS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblNguoiDuyet" runat="server" Text='<%#Eval("NguoiDuyet") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIDChucVu" runat="server" Text='<%#Eval("IDChucVu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Label ID="lblTenChucVuTiengHoa" runat="server" Text='<%#Eval("TenChucVuTiengHoa") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIDCapDuyet" runat="server" Text='<%#Eval("IDCapDuyet") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblIDLoaiDonVi" runat="server" Text='<%#Eval("IDLoaiDonVi") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentTypeNameTW" runat="server" Text='<%#Eval("DepartmentTypeNameTW") %>'></asp:Label>
                    </ItemTemplate>
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
