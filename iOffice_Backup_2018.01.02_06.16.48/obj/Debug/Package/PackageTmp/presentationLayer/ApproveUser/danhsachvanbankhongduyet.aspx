<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="danhsachvanbankhongduyet.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.danhsachvanbankhongduyet" %>
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
                 width: '99%',
                 height: 700
             });
         }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <p><%=hasLanguege["lbVBKy10"] %></p>--%>
    <div style="margin-left:10px">

  
    <asp:Label ID="Label1" runat="server" Text="Danh sách phiếu gửi đến bạn mà  không  được duyệt  不核准单据（BY ME）"></asp:Label>
    <br />
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
            <asp:BoundField ItemStyle-Width="20%"  DataField="abname" />
            <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="pdno" />
            <asp:BoundField ItemStyle-Width="35%" DataField="mytitle" />
            <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="YnName" />
            <asp:BoundField ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" DataField="NameABC" />
            <asp:BoundField DataField="USERNAME" />
            
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
