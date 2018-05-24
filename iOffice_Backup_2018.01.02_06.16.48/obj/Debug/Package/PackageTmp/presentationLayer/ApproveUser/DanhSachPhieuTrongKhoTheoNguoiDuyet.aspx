<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="DanhSachPhieuTrongKhoTheoNguoiDuyet.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.DanhSachPhieuTrongKhoTheoNguoiDuyet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../Style/jquery-ui.css" rel="stylesheet" />
    <link href="../../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
   <%-- <script src="../../Scripts/jquery-1.7.1.js"></script>--%>
   
    <script src="../../Scripts/jquery-1.9.1.js"></script>
     <script src="../../Scripts/jquery-ui.js"></script>
    <%--<script src="../../Scripts/jquery-ui-1.8.20.js"></script>--%>
   
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
    <script src="../../Scripts/gridviewScroll.min.js"></script>
     <script src="../../Scripts/formatDate.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             gridviewScroll();
         });

         function gridviewScroll() {
             $('#<%=GridView1.ClientID%>').gridviewScroll({
                 width: 1070,
                 height: 700
             });
         }
</script>
<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll1();
    });

    function gridviewScroll1() {
        $('#<%=GridView2.ClientID%>').gridviewScroll({
            width: 1070,
            height: 700
        });
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<p><%=hasLanguege["lbDanhSachPhieuTrongKho29"] %></p>--%>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Danh sách phiếu đã duyệt lưu trong kho 历史资料 "></asp:Label></p>
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
      <div id="divgrid2" runat="server" style="width:1070px; display:inline;height:600px">
            <div  style=" display: table-cell; border: 1px solid red; width:900px; overflow: auto; "> 
                
                    <asp:GridView ID="GridView2" runat="server" HeaderStyle-CssClass="FixedHeader" 
            ClientIDMode="Static" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" PageSize="25" style="margin-right: 1px" Width="897px">
        <Columns>
            
            <asp:CommandField SelectText="Details" ShowSelectButton="True" >
            </asp:CommandField>
           <asp:CommandField ShowDeleteButton="True" DeleteText="Status">
            </asp:CommandField>
            <asp:TemplateField HeaderText="abtypes" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="abnameTW" >
           
            </asp:BoundField>
            <%--<asp:BoundField DataField="pdno" >
           
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblpdno" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="mytitle" >
           
            </asp:BoundField>
           
            <asp:BoundField DataField="NameABCTW" >
          
            </asp:BoundField>
             <asp:BoundField DataField="USERNAME" >
            
            </asp:BoundField>
             <asp:TemplateField HeaderText="UserID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="LblUserID" runat="server" Text='<%#Eval("from_user") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="LblIDdep" runat="server" Text='<%#Eval("from_depart") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepName" >
            
            </asp:BoundField>
             
        </Columns>

<HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
                <br />
                </div>

           
             <div  style=" background: #ddd; display: table-cell; width: 100px;">
               <p>Status:<asp:Label ID="lblTrangThai2" runat="server" ForeColor="Red"></asp:Label></p>
              
             </div>
        </div>
      <div id="divgrid1" runat="server" style="width:1070px; display:inline;height:600px">
            <div  style=" display: table-cell; border: 1px solid red; width:900px; overflow: auto; "> 
                
                    <asp:GridView ID="GridView1" runat="server" HeaderStyle-CssClass="FixedHeader" 
            ClientIDMode="Static" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowDataBound="GridView1_RowDataBound1" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" PageSize="25" style="margin-right: 1px" Width="899px">
        <Columns>
            
            <asp:CommandField SelectText="Details" ShowSelectButton="True" >
            </asp:CommandField>
           <asp:CommandField ShowDeleteButton="True" DeleteText="Status" >
            </asp:CommandField>
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
            <asp:BoundField DataField="mytitle" >
           
            </asp:BoundField>
           
            <asp:BoundField DataField="NameABC" >
          
            </asp:BoundField>
             <asp:BoundField DataField="USERNAME" >
            
            </asp:BoundField>
             <asp:TemplateField HeaderText="UserID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="LblUserID" runat="server" Text='<%#Eval("from_user") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="LblIDdep" runat="server" Text='<%#Eval("from_depart") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepName" >
            
            </asp:BoundField>
             
        </Columns>

<HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
                <br />
                </div>

           
             <div  style=" background: #ddd; display: table-cell; width: 100px;">
               <p>Status:<asp:Label ID="lblTrangThai1" runat="server" ForeColor="Red"></asp:Label></p>
              
             </div>
        </div>
</asp:Content>
