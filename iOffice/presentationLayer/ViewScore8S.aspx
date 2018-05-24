<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewScore8S.aspx.cs" Inherits="iOffice.presentationLayer.ViewScore8S" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

     <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/FormatDiv.css" rel="stylesheet" />
    <link href="../Style/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery-1.7.2.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.19.custom.min.js"></script>
    <script src="../Scripts/formatdate1.js"></script>
    <script src="../Scripts/nhapso.js"></script>
   <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
   
    <script src="../Scripts/jquery.tooltip.min.js"></script>
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
</style>
    

</head>
<body>
    <form id="form1" runat="server">
       
    <div>
        <div >
         
               
            <table >
                <tr>
                    <td>Stype</td>
                     <td >
                      <asp:DropDownList ID="DropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDown_SelectedIndexChanged"></asp:DropDownList>
                   </td>
                </tr>
               <tr>
                   <td>
                       Content
                   </td>
                     <td >
                       <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </td>
               </tr>
                <tr>
                    <td>Details</td>
               
                    <td >
                        <asp:Label ID="lblChiTiet" runat="server" Text="" ForeColor="#0066ff"></asp:Label>
                    </td>
              </tr>
               <tr>
                   <td>
                       Benchmarking
                   </td>
                   <td>
                       <asp:TextBox ID="txtScoreMau" runat="server" BackColor="#CCFFFF" ForeColor="Blue" ReadOnly="True"></asp:TextBox>
                   </td>
               </tr>
                <tr  >
                    <td >
                        Memo
                    </td>
                    <td >
                           <asp:TextBox ID="txtMemoVN" runat="server" MaxLength="200" Width="900px" Rows="4" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="(*)" ControlToValidate="txtMemoVN" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                    </td>
                 
                </tr>
            </table>
          
            
            <div>
                 <table>
                     <tr>
                         <td>
                             Department Name
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownDonVi" runat="server"></asp:DropDownList>
                         </td>
                     </tr>
                 </table>
            </div>
            <table >
                <tr>
                    <td>From Date</td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div style="width:100%">
            <div class="left" style="float:left; width:50%; text-align:left;" >
                
                <asp:Image ID="Image1" runat="server"  class="gridViewToolTip"   Width="100px"  Height="100px" />
                <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image5" runat="server"  Width="600px" Height="500px" />
                            </td>
                        </tr>
                    </table>
                </div>
                 <table>
                     <tr>
                         <td>
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                         </td>
                         <td>
                             <asp:Button ID="btnUpload1" runat="server" Text="Upload File" OnClick="btnUpload1_Click" />
                         </td>
                     </tr>
                 </table>
              
                <table>
                    <tr>
                        <td>Score</td>
                        <td> <asp:TextBox ID="txtScore1" CssClass="groupOfTexbox" ClientIDMode="Static" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="CheckBox1" runat="server"   ToolTip="Ok then continues else 0 scrore" Checked="True"/> </td>
                        <td>OK</td>
                    </tr>
                    <tr>
                        <td> <asp:Button ID="Button1" runat="server" Text="Confirm" ValidationGroup="groupThem" OnClick="Button1_Click" /></td>
                    </tr>
                </table>
            </div>
            <div class="right" style="float:right; width:50%; text-align:left;">
              
                <asp:Image ID="Image2" runat="server" Class="gridViewToolTip" Width="100px" Height="100px" />
                <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image6" runat="server" Width="600px" Height="500px" />
                            </td>
                        </tr>
                    </table>
                </div>
                  <table>
                     <tr>
                         <td>
                              <asp:FileUpload ID="FileUpload2" runat="server" />
                         </td>
                         <td>
                             <asp:Button ID="Button3" runat="server" Text="Upload File" OnClick="Button3_Click" />
                         </td>
                     </tr>
                 </table>
                 
                <table>
                    <tr>
                        <td>
                            Score 
                        </td>
                        <td>
                             <asp:TextBox ID="txtScore2" CssClass="groupOfTexbox" runat="server" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="CheckBox2" runat="server"   ToolTip="Ok then continues else 0 scrore" Checked="True"/></td>
                        <td>OK</td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Button2" runat="server" Text="Confirm" /></td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" /></td>
                        
                    </tr>
                </table>
            </div>
        </div>
     <table style="width:99%;background-color:tomato">
         <tr>
             <th style="width:5%;text-align:center"> Edit</th>
             <th style="width:30%;text-align:center">Name VN</th>
             <th style="width:6%;text-align:center">Benchmarking</th>
             <th style="width:30%;text-align:center">
                 Memo
             </th>
             <th style="width:7%;text-align:center">
                 Picture 1
             </th>
             <th style="width:7%; text-align:center">Picture 2</th>
             <th style="width:7%;text-align:center">Score</th>
         </tr>
     </table>
 <div style="width:99%; overflow:scroll;">


            <asp:GridView ID="GridView1" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="99%" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkEdit" runat="server" CommandName="Select"><img src="../Content/Icon/edit.gif" /> Edit</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblS8date" runat="server" Text='<%#Eval("S8date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblsh" runat="server" Text='<%#Eval("sh") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblchecker" runat="server" Text='<%#Eval("checker") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbldepid" runat="server" Text='<%#Eval("depid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblSitemno" runat="server" Text='<%#Eval("Sitemno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblck1" runat="server" Text='<%#Eval("ck1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblck2" runat="server" Text='<%#Eval("ck2") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblck3" runat="server" Text='<%#Eval("ck3") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSnamevn" runat="server" Text='<%#Eval("Snamevn") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="32%" />
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
                        <ItemStyle Width="32%" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText=" Picture 0" >
                        <ItemTemplate>
                            <%--<a href="#" class="gridViewToolTip">
                                <asp:Image ID="Image4" runat="server" class="gridViewToolTip" Width="50px" Height="50px" ImageUrl='<%#Eval("QCpic0") %>' /></a>
                            <div id="tooltip" style="display:none">
                                 <asp:Image ID="Image3" runat="server" Width="100px" Height="100px" ImageUrl='<%#Eval("QCpic0") %>' />
                            </div>
                            --%>
                            
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
        <div style="display:none">
            <asp:TextBox ID="txtIDTemp" runat="server" Text=""></asp:TextBox>
            <asp:Label ID="lblImageTem1" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
