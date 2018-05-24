<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site8S.Master" AutoEventWireup="true" CodeBehind="bantin8S.aspx.cs" Inherits="iOffice.presentationLayer.bantin8S" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link href="../Content/Site.css" rel="stylesheet" />
  
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/formatdate1.js"></script>
     
        <script type="text/javascript">
            function InitializeToolTip() {
                $(".gridViewToolTip").tooltip({
                    track: true,
                    delay: 0,
                    showURL: false,
                    fade: 100,
                    bodyHandler: function () {
                        return $($(this).next().html());
                    },
                    showURL: false
                });
            }
</script>
<script type="text/javascript">
    $(function () {
        InitializeToolTip();
    })
</script>
    <style type="text/css">
#tooltip {
position: fixed;
z-index: 15000;
border: 1px solid #111;
background-color: #FEFFFF;
padding: 5px;
opacity: 1.55;
}
#tooltip h3, #tooltip div { margin: 0; }
        .auto-style1 {
            height: 26px;
        }
    </style>
    
   
    <script src="../Scripts/jquery.tooltip.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div>
                 <table>
                     <tr>
                         <td class="auto-style1">
                             <%=hasLanguege["lblDonVi"].ToString() %>
                         </td>
                         <td class="auto-style1">
                             <asp:DropDownList ID="DropDownDonVi" runat="server"></asp:DropDownList>
                         </td>
                     </tr>
                 </table>
            </div>
        <table >
                <tr>
                    <td><%=hasLanguege["lblTuNgay"].ToString() %></td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        <%=hasLanguege["lblDenNgay"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td class="button-wrap">
                        <asp:Button ID="btnQuery" runat="server" Text="Query" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass="button find" OnClick="btnQuery_Click" />
                    </td> 
                   
                </tr>
            </table>
    <br />
      <table style="width:99%;background-color:tomato">
         <tr>
             <th>DePartment ID</th>
             <th style="width:10%;text-align:center">
                 <%=hasLanguege["lblDonVi"].ToString() %>
             </th>
             <th><%=hasLanguege["lblMaSo"].ToString() %></th>
             <th style="width:28%;text-align:center">  <%=hasLanguege["lblVanDe"].ToString() %></th>
             <th style="width:6%;text-align:center"> <%=hasLanguege["lblDiemChuan"].ToString() %></th>
             <th style="width:29%;text-align:center">
                <%=hasLanguege["lblGhiChu"].ToString() %>
             </th>
             
             <th style="width:7%;text-align:center">
                 <%=hasLanguege["lblHinhAnh1"].ToString() %>
             </th>
             <th style="width:7%; text-align:center"><%=hasLanguege["lblHinhAnh2"].ToString() %></th>
             <th style="width:7%;text-align:center"><%=hasLanguege["lblDiem"].ToString() %></th>
         </tr>
     </table>
     <div style="width:99%;overflow:scroll">


            <asp:GridView ID="GridView1" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblDepartID" runat="server" Text='<%#Eval("depid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="lblDepart" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            
                             <asp:Label ID="lblSitemno1" runat="server" Text='<%#Eval("Sitemno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSnamevn" runat="server" Text='<%#Eval("Snamevn") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="29%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Benchmarking">
                        <ItemTemplate>
                            <asp:Label ID="lblDiemChuan" runat="server" Text='<%#Eval("Sitemscore") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="Memo" >
                        <ItemTemplate>
                            <asp:Label ID="lblQCmemo" runat="server" Text='<%#Eval("QCmemo") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="29%" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText=" Picture 0" >
                        <ItemTemplate>
                           
                            
                            <asp:Image ID="Image1" Width="40px" Height="40px" runat="server" class="gridViewToolTip" ImageUrl='<%#Eval("QCpic0") %>'  />
                            <div id="tooltip" style="display: none;">
                            <table>
                            <tr>
                    
                            <td><asp:Image ID="imgUserName" Width="600px" Height="500px" ImageUrl='<%#Eval("QCpic0") %>' runat="server" /></td>
                            </tr>
                            </table>
                            </div>
                        </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Picture 2" >
                        <ItemTemplate>
                            <%--<asp:Label ID="lblQApic" runat="server" Text='<%#Eval("QApic") %>'></asp:Label>--%>
                            <asp:Image ID="Image3" runat="server" Width="40px" Height="40px" Class="gridViewToolTip" ImageUrl='<%#Eval("QApic") %>' />
                            <div id="tooltip" style="display:none">
                                <table >
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image4" runat="server" Width="600px" Height="500px" ImageUrl='<%#Eval("QApic") %>' />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="7%"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Scrore">
                        <ItemTemplate>
                            <asp:Label ID="lblsub_score" runat="server" Text='<%#Eval("sub_score","{0:0,0}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    
                   <%-- <asp:ImageField DataImageUrlField = "QCpic0" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>
                    
                </Columns>
                 <HeaderStyle CssClass="GridviewScrollHeader" /> 
                <RowStyle CssClass="GridviewScrollItem" /> 
                <PagerStyle CssClass="GridviewScrollPager" /> 
               <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
            </asp:GridView>
     </div>

</asp:Content>