<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachphieucattrongkhoNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.danhsachphieucattrongkhoNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <link href="../../Style/GridviewScroll.css" rel="stylesheet" />
   <%-- <script src="../../Scripts/jquery-1.7.1.js"></script>--%>
   
    <script src="../../Scripts/jquery-1.9.1.js"></script>
     <script src="../../Scripts/jquery-ui.js"></script>
    <%--<script src="../../Scripts/jquery-ui-1.8.20.js"></script>--%>
    <script src="../../Scripts/ngay.js" type="text/javascript"></script>
     <script src="../../Scripts/NgayThang.js"></script>
    <script src="../../Scripts/NgayNghi.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             gridviewScroll();
         });

         function gridviewScroll() {
             $('#<%=GridView1.ClientID%>').gridviewScroll({
                width: 1000,
                height: 600
            });
        }
</script>
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: 1000,
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align:left;margin-left:100px; width:800px">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
      <table>
        <tr>
            
            <td> From date
                <asp:TextBox ID="txtFromDate" ClientIDMode="Static" runat="server" ></asp:TextBox>
            </td>
            <td> To date
                <asp:TextBox ID="txtToDate" ClientIDMode="Static" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnTimKiem" runat="server" Text="Query" OnClick="btnTimKiem_Click" /></td>
        </tr>
 </table>
       <div id="divGrid1" runat="server" style="width:1073px">
        <div  style=" display: table-cell; border: 1px solid red; width:900px; overflow: auto; "> 
              <asp:GridView ID="GridView1" runat="server" Width="900px" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                  <Columns>
                      <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                      <asp:CommandField DeleteText="Status" ShowDeleteButton="True" />
                      <asp:TemplateField>
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
                      </asp:TemplateField>
                      <asp:TemplateField ShowHeader="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
              </asp:GridView>
        </div>
         <div  style=" background: #ddd; display: table-cell; width: 150px;">
               <p>Status:<asp:Label ID="lblTrangThai" runat="server" ForeColor="Red"></asp:Label></p>
              
         </div>
    </div>
    <div id="divGrid2" runat="server" style="width:1073px">
          <div  style=" display: table-cell; border: 1px solid red; width:900px; overflow: auto; ">
              <asp:GridView ID="GridView2" runat="server" Width="900px" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                  <Columns>
                       <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                      <asp:CommandField DeleteText="Status" ShowDeleteButton="True" />
                      <asp:TemplateField>
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
                      </asp:TemplateField>
                      <asp:TemplateField ShowHeader="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                  </Columns>
                  <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
              </asp:GridView>
          </div>
        <div  style=" background: #ddd; display: table-cell; width: 150px;">
               <p>Status:<asp:Label ID="LblTrangThai1" runat="server" ForeColor="Red"></asp:Label></p>
              
         </div>
    </div>
</asp:Content>
