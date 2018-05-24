<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="danhsachvanbankhongduockyNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.danhsachvanbankhongduockyNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                width: '100%',
                height: 600
            });
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<p>
        <%=hasLanguege["lbPhieuKhongduocduyet"] %></p>--%>

      
   <p><asp:Label ID="Label1" runat="server" Text="Danh sách phiếu không được duyệt 退件"></asp:Label></p> 
    <div style="margin-left:10px">
       
    <br />
      
     
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" PageSize="25" Width="99%">
        <Columns>
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                                <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                            </asp:LinkButton>
                        </ItemTemplate>
                 <ItemStyle Width="6%" />
                    </asp:TemplateField>
           
            <asp:TemplateField HeaderText="abtype" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblabtype" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="abname" ItemStyle-Width="20%" />
            <asp:BoundField DataField="pdno" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="mytitle" ItemStyle-Width="30%" />
            <asp:BoundField DataField="YnName" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="NameABC" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="USERNAME"  ItemStyle-HorizontalAlign="Center" />
            
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepName" />
        </Columns>
        <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
</asp:GridView>
          
        

    </div>
   
</asp:Content>
