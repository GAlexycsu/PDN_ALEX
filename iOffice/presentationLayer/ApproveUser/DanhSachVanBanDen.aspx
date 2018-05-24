<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="DanhSachVanBanDen.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.DanhSachVanBanDen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: '99%',
            height: 700
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <p> <%=hasLanguege["LbDSVBDen"] %> </p>--%>
   
  <p>
      <asp:Label ID="Label1" runat="server" Text="Danh sách văn bản đến 资料名单"></asp:Label></p>
    <div style="height: 600px;  margin-left:10px"  >

       
    <asp:GridView ID="GridView2" runat="server" HeaderStyle-CssClass="FixedHeader" 
            ClientIDMode="Static" CellPadding="5" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" PageSize="25" Width="99%">
        <Columns>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                 <ItemStyle Width="6%" />
              </asp:TemplateField>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkNoiDung" runat="server" CommandName="Delete" ><img src="../../Images/Up.png" />
                                <asp:Label ID="lblNoiDung" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                       <ItemStyle Width="6%" />
                    </asp:TemplateField>
           
            <asp:TemplateField HeaderText="abtypes" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="abname" >
           
            </asp:BoundField>
            <%--<asp:BoundField DataField="pdno" >
           
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblpdno" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="35%" DataField="mytitle" >
           
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="7%" DataField="YnName" >
            
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="7%" DataField="NameABC" >
          
            </asp:BoundField>
            <asp:BoundField DataField="USERNAME" >
            
            </asp:BoundField>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="LblIDdep" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepName" >
            
            </asp:BoundField>
             <asp:TemplateField HeaderText="Date">
                   <ItemTemplate>
                      <asp:Label ID="lbnDate" runat="server" Text='<%#Eval("CFMDate0","{0:yyyy/MM/dd}") %>'></asp:Label>
                   </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>

<HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>

 
</div>
      
</asp:Content>
