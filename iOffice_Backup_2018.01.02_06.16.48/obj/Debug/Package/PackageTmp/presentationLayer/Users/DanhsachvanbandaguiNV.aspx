<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="DanhsachvanbandaguiNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.DanhsachvanbandaguiNV" %>
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
                 height: 600
             });
         }
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       
    <p><%=hasLanguege["lbDSPhieuDaGui"] %></p>
    <div style="margin-left:10px; ">
     
         
         <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" Width="99%" >
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
                    </asp:TemplateField>
                <asp:BoundField DataField="abname" ItemStyle-Width="20%" HeaderText="abname" />
                <asp:BoundField DataField="pdno" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" HeaderText="pdno" />
                <asp:BoundField DataField="mytitle"  HeaderText="mytitle" ItemStyle-Width="30%"/>
                <asp:BoundField DataField="NameABC" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" HeaderText="NameABC"/>
                <asp:BoundField DataField="USERNAME" HeaderText="USERNAME"/>
                <asp:BoundField DataField="DepName" HeaderText="DepName"/>
            </Columns>
             <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
        </asp:GridView>

    </div>

</asp:Content>
