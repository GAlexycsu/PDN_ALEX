<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="MyDocusNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.MyDocusNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
        <script src="../../Scripts/gridviewScroll.min.js"></script>
    <script  type="text/javascript">

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
    <div style="margin-left:10px">
    <br />
    <br />
    
       <p style="display:none">
           <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
       </p>
    <div id="divGrid1" runat="server"  style="width:100%; overflow: auto;" >
       
              <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowDataBound="GridView1_RowDataBound"  >
                  <Columns>
                     <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                    <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                 
                      <asp:TemplateField Visible="false" >
                          <ItemTemplate>
                              <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype")%>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单别">
                          <ItemTemplate>
                              <asp:Label ID="lblTenLoaiPhieu" runat="server" Text='<%#Eval("abname") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Width="20%" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单号">
                          <ItemTemplate>
                              <asp:Label ID="lblSoPhieu" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="7%" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="题目">
                          <ItemTemplate>
                              <asp:Label ID="lblTieuDe" runat="server" Text='<%#Eval("mytitle") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Width="30%" />
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblTenDonVi" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
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
                          <ItemStyle HorizontalAlign="Center" Width="7%" />
                      </asp:TemplateField>
                       <asp:TemplateField HeaderText="审核步骤">
                          <ItemTemplate>
                              <asp:Label ID="lblAbStep" runat="server" Text='<%#Eval("LevelDoing") %>'></asp:Label>
                          </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="5%" />
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblABC" runat="server" Text='<%#Eval("ABC") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                          <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("NameABC") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle Width="7%" />
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Eval("CFMID1") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="审核员">
                          <ItemTemplate>
                              <asp:Label ID="lblAuditor" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                          </ItemTemplate>
                        
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Date">
                          <ItemTemplate>
                              <asp:Label ID="lblNgay" runat="server" Text='<%#Eval("CFMDate0","{0:yyyy/MM/dd}") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                  </Columns>
                  
              <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
              </asp:GridView>
        </div>
       
    
        </div>
   
</asp:Content>
