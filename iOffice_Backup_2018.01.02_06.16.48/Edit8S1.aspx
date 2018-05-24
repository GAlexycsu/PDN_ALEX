<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit8S1.aspx.cs" Inherits="iOffice.Edit8S1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div>
        <div >
         
               <asp:UpdatePanel ID="pn11"    runat="server">
                <ContentTemplate>         
            <table >
                <tr>
                    <td>
                        <%=hasLanguege["lblLoai8S"].ToString() %>
                    </td>
                     <td >
                      <asp:DropDownList ID="DropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDown_SelectedIndexChanged"></asp:DropDownList>
                   </td>
                </tr>
               <tr>
                   <td>
                      
                       <%=hasLanguege["lblMaSo"].ToString() %>
                   </td>
                     <td  class="button-wrap">
                       <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> 
                         &nbsp; &nbsp;<asp:Button ID="btnQuery" runat="server" Text="Query"  CssClass="button find" BackColor="#F0CCFF"  ForeColor="Blue"  OnClick="btnQuery_Click1" />
                    </td>
               </tr>
                <tr>
                    <td>
                          <%=hasLanguege["lblVanDe"].ToString() %>
                    </td>
               
                    <td >
                        <asp:Label ID="lblChiTiet" runat="server" Text="" ForeColor="#0066ff"></asp:Label>
                    </td>
              </tr>
               <tr>
                   <td>
                      
                         <%=hasLanguege["lblDiemChuan"].ToString() %>
                   </td>
                   <td>
                       <asp:TextBox ID="txtScoreMau" runat="server" BackColor="#CCFFFF" ForeColor="Blue" ReadOnly="True"></asp:TextBox>
                   </td>
               </tr>
                <tr  >
                    <td >
                       
                          <% %>
                    </td>
                    <td >
                           <asp:TextBox ID="txtMemoVN" runat="server" MaxLength="200" Width="900px" Rows="4" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Text="(*)" ControlToValidate="txtMemoVN" ValidationGroup="groupThem" ErrorMessage=""></asp:RequiredFieldValidator>
                    </td>
                 
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            <div>
                 <table>
                     <tr>
                         <td>
                             
                               <%=hasLanguege["lblDonVi"].ToString() %>
                         </td>
                         <td>
                             <asp:DropDownList ID="DropDownDonVi" runat="server"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="DropDownDonVi" Text="(*)" ForeColor="Red" ValidationGroup="groupThem" ></asp:RequiredFieldValidator>
                         </td>
                     </tr>
                 </table>
            </div>
          
          
        </div>
        

          

        <div style="width:100%">
            <div class="left" style="float:left; width:80%; text-align:left;" >
                <table>
                    <tr>
                        <td>
                       
                              <asp:Image ID="ImagePic1" runat="server"  class="gridViewToolTip"   Width="103px"  Height="86px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                       
                            <asp:Image ID="ImagePic2" runat="server" Class="gridViewToolTip" Width="100px" Height="100px" />
                        </td>
                    </tr>
                </table>
              
                <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="ImagePic1Tooltrip" runat="server"  Width="600px" Height="500px" />
                            </td>
                        </tr>
                       <tr>
                           <td>
                                <asp:Label ID="lblImagePic1" runat="server" Text="" ForeColor="#0066ff"></asp:Label>
                           </td>
                       </tr>
                    </table>
                </div>
                   <div class="tooltip" style="display:none">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="ImagePic2Tootrip" runat="server"  Width="600px" Height="500px" />
                            </td>
                        </tr>
                       <tr>
                            <asp:Label ID="lblImagePic2" runat="server" Text="" ForeColor="#0066ff"></asp:Label>
                       </tr>
                    </table>
                </div>
                 <table>
                     <tr>
                         <td>
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                         </td>
                         <td class="button-wrap">
                             <asp:Button ID="btnUpload1" runat="server" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass="button Up" Text="Upload File" OnClick="btnUpload1_Click" />
                         </td>
                     </tr>
                 </table>
              
                <table>
                    <tr>
                        <td>Score</td>
                        <td> <asp:TextBox ID="txtScore1" CssClass="groupOfTexbox"  ClientIDMode="Static" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="txtScore1" Text="(*)" ForeColor="Red" ValidationGroup="groupThem"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="CheckBox1" runat="server"   ToolTip="Ok then continues else 0 scrore" Checked="True"/> </td>
                        <td>OK</td>
                    </tr>
                    <tr>
                        <td> <asp:Button ID="Button1" runat="server" Text="Confirm" BackColor="#F0CCFF"  ForeColor="Blue"  ValidationGroup="groupThem" OnClick="Button1_Click" style="height: 26px" /></td>
                        <td>
                            <asp:Button ID="btnCancel1" runat="server" BackColor="#F0CCFF"  ForeColor="Blue"  Text="Cancel" OnClick="btnCancel1_Click" /></td>
                    </tr>
                </table>
            </div>
        
        </div>
    <p class="button-wrap" style="margin-left:200px; width:90%;float:left;">
        <asp:Button ID="btnBack" runat="server" BackColor="#F0CCFF"  ForeColor="Blue"  CssClass="button back" Text="Back" OnClick="btnBack_Click" />
    </p>
    <table style="width:99%;background-color:tomato">
         <tr>
             <th style="width:5%;text-align:center"> Edit</th>
             <th style="width:30%;text-align:center">  <%=hasLanguege["lblVanDe"].ToString() %></th>
             <th style="width:6%;text-align:center"> <%=hasLanguege["lblDiemChuan"].ToString() %></th>
             <th style="width:30%;text-align:center">
                <%=hasLanguege["lblGhiChu"].ToString() %>
             </th>
             <th style="width:7%;text-align:center">
                 <%=hasLanguege["lblHinhAnh1"].ToString() %>
             </th>
             <th style="width:7%; text-align:center"><%=hasLanguege["lblHinhAnh2"].ToString() %></th>
             <th style="width:7%;text-align:center"><%=hasLanguege["lblDiem"].ToString() %></th>
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
    </div>
    </form>
</body>
</html>
