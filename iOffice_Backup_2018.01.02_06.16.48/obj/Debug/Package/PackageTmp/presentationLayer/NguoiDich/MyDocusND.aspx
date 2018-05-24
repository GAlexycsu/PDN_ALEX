<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocusND.Master" AutoEventWireup="true" CodeBehind="MyDocusND.aspx.cs" Inherits="iOffice.presentationLayer.NguoiDich.MyDocusND" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>

    <script src="../../Scripts/jquery-ui.min.js"></script>
        <script src="../../Scripts/gridviewScroll.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             gridviewScroll();
         });

         function gridviewScroll() {
             $('#<%=GridView1.ClientID%>').gridviewScroll({
                 width: '100%',
                 height: 700
             });
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        <div  style=" display: table-cell;  width:1070px; overflow: auto; "> 
              <asp:GridView ID="GridView1" runat="server" Width="1065px" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                  <Columns>
                      <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                   </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype")%>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="lblTenLoaiPhieu" runat="server" Text='<%#Eval("abname") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="lblSoPhieu" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="lblTieuDe" runat="server" Text='<%#Eval("mytitle") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField >
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="lblTenDV" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaNguoiGui" runat="server" Text='<%#Eval("CFMID0") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="lblTenNguoiGui" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="">
                          <ItemTemplate>
                              <asp:Label ID="lblNgayTao" runat="server" Text='<%#Eval("CFMDate0","{0:yyyy/MM/dd}") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblYn" runat="server" Text='<%#Eval("YN") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Status">
                          <ItemTemplate>
                              <asp:Label ID="lblYnName" runat="server" ForeColor="Red" Text='<%#Eval("YnName") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                           <ItemTemplate>
                               <asp:Label ID="lblisPause" runat="server" Text='<%#Eval("isPause") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                  </Columns>
                    <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
              </asp:GridView>
        </div>
         <%--<div  style=" background: #ddd; display: table-cell; width: 100px;">
               <p>Status:<asp:Label ID="lblTrangThai" runat="server" ForeColor="Red"></asp:Label></p>
              
         </div>--%>


</asp:Content>
