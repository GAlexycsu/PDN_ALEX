<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/Site8S.Master" AutoEventWireup="true" CodeBehind="page8SDetail.aspx.cs" Inherits="iOffice.presentationLayer.page8SDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
 
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/FormatDate8S.js"></script>
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
        .auto-style2 {
            height: 30px;
        }
    </style>
    
   
    <script src="../Scripts/jquery.tooltip.min.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <br />
    <br />

      
      <div>


     

      <table>
          <tr>
              <td>
                  Year
              </td>
              <td>
                  <asp:DropDownList ID="dropDownYear" runat="server"></asp:DropDownList>
              </td>
              <td>
                  Month
              </td>
              <td>
                  <asp:DropDownList ID="dropDownMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownMonth_SelectedIndexChanged"></asp:DropDownList>
              </td>
              <td>
                  Week
              </td>
              <td>
                  <asp:DropDownList ID="DropDownWeek" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownWeek_SelectedIndexChanged"></asp:DropDownList>
              </td>
          </tr>

      </table>
         
        <table>
                 <tr>
                    <td> <%=hasLanguege["lblTuNgay"].ToString() %></td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        
                         <%=hasLanguege["lblDenNgay"].ToString() %>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>Ngày Chấm Điểm</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                </tr>
        </table>

   </div>  
   <asp:UpdatePanel ID="pnDetail" runat="server">
        <ContentTemplate>
   
           
        <table>
             <tr>
                         <td class="auto-style2">
                             
                               <%=hasLanguege["lblDonVi"].ToString() %>
                         </td>
                         <td class="auto-style2">
                             <asp:DropDownList ID="DropDownDonVi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownDonVi_SelectedIndexChanged"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="groupQuery" ControlToValidate="txtBDepartID" ForeColor="Red" Text="(*)" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                         </td>
                         <td>
                             <asp:CheckBox ID="checkCreate" runat="server" Text="Created" AutoPostBack="true" OnCheckedChanged="checkCreate_CheckedChanged" />
                             <asp:CheckBox ID="checkConfirm" runat="server" Text="Confirmed" AutoPostBack="True" OnCheckedChanged="checkConfirm_CheckedChanged" />
                         </td>
                 
            </tr>
        </table>
        <table>
            <tr>
                <td class="button-wrap">
                        <asp:Button ID="btnQuery" runat="server" Text="Query" CssClass="button find" ValidationGroup="groupQuery" BackColor="#F0CCFF"  ForeColor="Blue" Width="165px"  OnClick="btnQuery_Click" />
                    </td>
                   <td style="text-align:left">
                        <asp:Button ID="btnExportDepart" runat="server" ValidationGroup="groupQuery"    BackColor="#F0CCFF"   ForeColor="Blue" Text="Export Department" OnClick="btnExportDepart_Click" />
                    </td> 
                    <td>
                        <asp:Button ID="btnAdd1Row" runat="server" Text="Add 1 Row"  CssClass="button add" BackColor="#F0CCFF"   ForeColor="Blue" OnClick="btnAdd1Row_Click" />
                    </td>
                    <td class="button-wrap">
                        <asp:Button ID="btnAdd" runat="server" CssClass="button add" BackColor="#F0CCFF" ValidationGroup="groupQuery"  ForeColor="Blue" Width="165px"  Text="Add 8 S All Row" OnClick="btnAdd_Click" />
                    </td>
                <td>
                    <asp:Button ID="btnGetData" runat="server" BackColor="#F0CCFF"  ForeColor="Blue" Text="Get 8S Not Yet OK" OnClick="btnGetData_Click" />
                </td>
                   <td class="button-wrap">
                            <asp:Button ID="btnConfirm" runat="server"  BackColor="#F0CCFF"  ForeColor="Blue" CssClass="approval" Text="Auditor Confirm" OnClick="btnConfirm_Click" Width="165px" /></td>
                <td>
                    <asp:Button ID="btnCopyDiem" runat="server" Text="Copy Điểm" OnClick="btnCopyDiem_Click" /></td>
            </tr>
        </table>
     <p style="text-align:left;margin-left:200px">
         <asp:Label ID="lblThongBao" runat="server" ForeColor="#CC00FF"></asp:Label></p>
     <table style="width:99%;background-color:#7dbed3">
         <tr>
             <th style="width:5%;text-align:center">Edit</th>
             <th style="width:7%;text-align:center">Date</th>
     <%--        <th style="width:4%;text-align:center">ID</th>
             <th style="width:5%;text-align:center">Department ID</th>--%>
             <th style="width:8%;text-align:center">
                 <%=hasLanguege["lblDonVi"].ToString() %>
             </th>
           
             <th style="width:11%;text-align:center">S8Item</th>
             <th  style="width:5%;text-align:center"><%=hasLanguege["lblMaSo"].ToString() %></th>
             <th style="width:46%;text-align:center">  <%=hasLanguege["lblVanDe"].ToString() %></th>
             <th style="width:6%;text-align:center"> <%=hasLanguege["lblDiemChuan"].ToString() %></th>
              <th style="width:7%;text-align:center"><%=hasLanguege["lblDiem"].ToString() %></th>
          <%--   <th style="width:13%;text-align:center">
                <%=hasLanguege["lblGhiChu"].ToString() %>
             </th>--%>
             
             <th style="width:7%;text-align:center">
                 <%=hasLanguege["lblHinhAnh1"].ToString() %>
             </th>
             <th style="width:7%; text-align:center"><%=hasLanguege["lblHinhAnh2"].ToString() %></th>
            
         </tr>
     </table>
   <asp:UpdatePanel ID="pn1" runat="server">
       <ContentTemplate>


        <div id="divGridView" runat="server" style="width:100%;max-height:550px; overflow:scroll">

            <asp:GridView ID="GridView1" runat="server"  ShowHeader="false" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                 <Columns>
                       <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkEdit" runat="server" CommandName="Select"><img src="../Content/Icon/edit.gif" /> Edit</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Label ID="lblDate" runat="server" Text='<%#Eval("S8date","{0:dd/MM/yyyy}") %>'></asp:Label>
                         </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                     </asp:TemplateField>
                      <asp:TemplateField HeaderText="ID" Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblsh" runat="server" Text='<%#Eval("sh") %>'></asp:Label>
                         
                        </ItemTemplate>
                          
                    </asp:TemplateField>
                     
                    <asp:TemplateField Visible="false">
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
                     <asp:TemplateField Visible="false">
                         <ItemTemplate>
                             <asp:Label ID="lblSitemtp" runat="server" Text='<%#Eval("Sitemtp") %>'></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                      <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Label ID="lblStpnamevn" runat="server" Text='<%#Eval("Stpnamevn") %>'></asp:Label>
                         </ItemTemplate>
                          <ItemStyle Width="10%" />
                     </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                             <asp:Label ID="lblSitemno" runat="server" Text='<%#Eval("Sitemno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSnamevn" runat="server" Text='<%#Eval("Snamevn") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="53%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Benchmarking">
                        <ItemTemplate>
                            <asp:Label ID="lblDiemChuan" runat="server" Text='<%#Eval("Sitemscore") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Scrore">
                        <ItemTemplate>
                           
                            <asp:TextBox ID="txtScoreDB" runat="server"  Text='<%#Eval("sub_score","{0:0}") %>' Width="28px" Height="28px"  OnTextChanged="txtScoreDB_TextChanged" AutoPostBack="true" ></asp:TextBox>
                          
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Memo"  Visible="false" >
                        <ItemTemplate>
                            <asp:Label ID="lblQCmemo" runat="server" Text='<%#Eval("QCmemo") %>'></asp:Label>
                        </ItemTemplate>
                       
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
                  
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblYn" runat="server" Text='<%#Eval("yn") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:ImageField DataImageUrlField = "QCpic0" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>--%>
                    
                </Columns>
                 <HeaderStyle CssClass="GridviewScrollHeader" /> 
                    <RowStyle CssClass="GridviewScrollItem" /> 
                    <PagerStyle CssClass="GridviewScrollPager" /> 
                   <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
            </asp:GridView>
        
        </div>
        <div id="divScore" runat="server">

             <table style="width:100%;background-color:#ba9d9d; height:40px">
                <tr>
             <th style="width:5%;text-align:center"></th>
             <th style="width:7%;text-align:center"></th>
         <%--    <th style="width:4%;text-align:center"></th>
             <th style="width:5%;text-align:center"> </th>--%>
             <th style="width:8%;text-align:center">
               
             </th>
           
             <th style="width:11%;text-align:center"></th>
             <th  style="width:5%;text-align:center"></th>
             <th style="width:44%;text-align:center">  </th>
             <th style="width:6%;text-align:center">
                 <asp:Label ID="lblDiemChuan" runat="server" Text=""></asp:Label> </th>
            <th style="width:7%;text-align:center">
                 <asp:Label ID="lblDiem" runat="server" Text=""></asp:Label></th>
             <%--<th style="width:25%;text-align:center">
               
             </th>--%>
             
             <th style="width:7%;text-align:center">
                
             </th>
             <th style="width:7%; text-align:center"></th>
             
         </tr>
     </table>
        </div>
          
        <div style="display:none">
            <asp:TextBox ID="txtIDTemp" runat="server" Text=""></asp:TextBox>
            <asp:Label ID="lblImageTem1" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblQuyen" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtBDepartID" runat="server"></asp:TextBox>
             
        </div>
     
       </ContentTemplate>
   </asp:UpdatePanel>
    </div>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
