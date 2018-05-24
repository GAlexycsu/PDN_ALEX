<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site1.Master" AutoEventWireup="true" CodeBehind="MyCheckPDN.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.MyCheckPDN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="../../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <link href="../../Style/formatMain.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>

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
    <%--  <div style="width:1148px; height:83px; float:left; margin-bottom: 0px; margin-left:7px;">
            <table style="width: 1156px; height: 66px; margin-bottom: 0px;text-align:left">
                <tr>
                  
                    <td class="auto-style3">
                        <asp:CheckBox ID="checkWaitMe" runat="server" Text="" Checked="True" Font-Size="Larger" />
                        <asp:LinkButton ID="LinkButton1" runat="server">Danh sach van ban den</asp:LinkButton>
                    </td>
                    <td class="auto-style4">
                        <asp:CheckBox ID="CheckOk" runat="server" Text=" " Font-Size="Larger" />
                        <asp:LinkButton ID="LinkButton2" runat="server">Danh sach Phieu da duyet</asp:LinkButton>
                    </td>
                    <td class="auto-style1">
                        <asp:CheckBox ID="CheckNoOk" runat="server" Text="" Font-Size="Larger" />
                        <asp:LinkButton ID="LinkButton3" runat="server">Danh sach Phieu Khong duyet</asp:LinkButton>
                    </td>
                   <td>
                       <asp:CheckBox ID="checkKho" runat="server" Text="Storehouse" Font-Size="Larger" />
                       <asp:LinkButton ID="LinkButton4" runat="server">Kho phieu</asp:LinkButton>
                   </td>
                </tr>
                <tr>
                    <td class="auto-style3" > From Date :<asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox></td>
                    <td class="auto-style4" > To Date: <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox></td>
                    <td class="auto-style6">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                    <td class="auto-style7"></td>
                </tr>
            </table>
        </div>--%>


      
     <div id="DivGrid2" runat="server" style="width:99%; display:inline;height:600px">
            <div  style=" display: table-cell; border: 1px solid red; width:99%; overflow: auto; "> 
                
                    <asp:GridView ID="GridView2" runat="server" HeaderStyle-CssClass="FixedHeader" 
            ClientIDMode="Static" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowDataBound="GridView2_RowDataBound" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting" PageSize="25" style="margin-right: 1px" Width="99%">
        <Columns>
            
          <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="linkDeTails" runat="server" CommandName="Select" ><img src="../../Images/View.png" />
                    <asp:Label ID="lblDeTails" runat="server" Text=""></asp:Label>
                </asp:LinkButton>
            </ItemTemplate>
              <ItemStyle Width="6%" />
        </asp:TemplateField>
        <%--   <asp:CommandField ShowDeleteButton="True" DeleteText="Status" >
            
            </asp:CommandField>--%>
            <asp:TemplateField HeaderText="abtypes" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="20%" DataField="abname" >
           
            </asp:BoundField> 
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblpdno" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="7%" />
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="30%" DataField="mytitle" >
           
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
             <asp:TemplateField Visible="false">
                 <ItemTemplate>
                     <asp:Label ID="lblYn" runat="server" Text='<%#Eval("YN") %>'></asp:Label>
                 </ItemTemplate>
                 <ItemStyle Width="7%" HorizontalAlign="Center" />
             </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblYNName" runat="server" ForeColor="Red" Text='<%#Eval("YnName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                   <ItemTemplate>
                      <asp:Label ID="lbnDate" runat="server" Text='<%#Eval("CFMDate0","{0:dd/MM/yyyy}") %>'></asp:Label>
                   </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>

       <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
    </asp:GridView>
                <br />
                </div>

           
            <%-- <div  style=" background: #ddd; display: table-cell; width: 100px;">
               <p>Status:<asp:Label ID="lblTrangThai2" runat="server" ForeColor="Red"></asp:Label></p>
              
             </div>--%>
        </div>
  

     
      
     
</asp:Content>
