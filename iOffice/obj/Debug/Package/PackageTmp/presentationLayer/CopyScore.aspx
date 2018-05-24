<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CopyScore.aspx.cs" Inherits="iOffice.presentationLayer.CopyScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../Style/GridviewScroll.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/FormatDate8S.js"></script>
         <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
        <script src="../Scripts/gridviewScroll.min.js"></script>
    
    <script  type="text/javascript">

        $(document).ready(function () {
            gridviewScroll();
        });
        function gridviewScroll() {
            $('#<%=GridView1.ClientID%>').gridviewScroll({
                        width: '100%',
                        height: 750
                    });
                }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                    <td>Ngày Chấm Điểm</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"></asp:TextBox></td>
                </tr>
        </table>
       <table>
           <tr>
               <td>Đơn Vị</td>
               <td>
                   <asp:DropDownList ID="DropDownDonViDau" runat="server"></asp:DropDownList></td>
               <td>Copy Điểm Tới</td>
               <td>
                   <asp:DropDownList ID="DropDownDonViCopy" runat="server"></asp:DropDownList></td>
               <td> <asp:Button ID="btnCopy" runat="server" Text="Copy Điểm" OnClick="btnCopy_Click" /></td>
               <td>
                   <asp:Button ID="btnQry" runat="server" Text="Lấy Danh Sách" OnClick="btnQry_Click" /></td>
           </tr>
       </table>
        <div>
            <asp:GridView ID="GridView1" runat="server"  ShowHeader="true" AutoGenerateColumns="False" Width="100%">
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
                      <asp:TemplateField HeaderText="S8Item">
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
                           
                            <asp:TextBox ID="txtScoreDB" runat="server" Text='<%#Eval("sub_score","{0:0}") %>' Width="28px" Height="28px"   AutoPostBack="true" ></asp:TextBox>
                          
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
             <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
            </asp:GridView>
        
        </div>
        <div id="divScore" runat="server">

             <table style="width:100%;background-color:#ba9d9d; height:50px">
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
     
      
    
    </div>
    </form>
</body>
</html>
