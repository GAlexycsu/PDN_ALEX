<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="frmDanhsachphieubihuyNV.aspx.cs" Inherits="iOffice.presentationLayer.Users.frmDanhsachphieubihuyNV" %>
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
                width: 1100,
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
            width: 1100,
            height: 600
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:20px">
     <p><%=hasLanguege["lblDSBiHuy"].ToString() %></p>
        <asp:UpdatePanel ID="paneBiHuy1" runat="server">
            <ContentTemplate>

           
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" Width="1100px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
        <asp:BoundField DataField="abname" >
         <HeaderStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="pdno" >
         <HeaderStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="mytitle" >
         <HeaderStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="USERNAME" >
         <HeaderStyle HorizontalAlign="Center"  />
        </asp:BoundField>
         <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DepName" >
         <HeaderStyle HorizontalAlign="Center"  />
        </asp:BoundField>
       
    </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
     <HeaderStyle CssClass="GridviewScrollHeader" BackColor="#006699" Font-Bold="True" ForeColor="White" /> 
    <RowStyle CssClass="GridviewScrollItem" ForeColor="#000066" /> 
    <PagerStyle CssClass="GridviewScrollPager" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" /> 
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
  </asp:GridView>
     </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="paneBiHuy2" runat="server">
            <ContentTemplate>

           
     <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"  OnPageIndexChanging="GridView2_PageIndexChanging"  Width="1100px">
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
        <asp:BoundField DataField="abnameTW" />
        <asp:BoundField DataField="pdno" />
        <asp:BoundField DataField="mytitle" />
        <asp:BoundField DataField="USERNAME" />
        <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DepName" />
        
    </Columns>
     <HeaderStyle CssClass="GridviewScrollHeader" /> 
    <RowStyle CssClass="GridviewScrollItem" /> 
    <PagerStyle CssClass="GridviewScrollPager" /> 
</asp:GridView>
   </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView2" />
            </Triggers>
        </asp:UpdatePanel>
 </div>
</asp:Content>
