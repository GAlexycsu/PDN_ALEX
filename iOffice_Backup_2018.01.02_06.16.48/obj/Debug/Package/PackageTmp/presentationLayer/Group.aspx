<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteGroup.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="iOffice.presentationLayer.Group" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/Site.css" rel="stylesheet" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <asp:UpdatePanel ID="udp" runat="server">
                           <ContentTemplate>

      <div class="form-left">
                          
                        <p > Group Name <asp:TextBox ID="txtWorkGroupName" runat="server" Width="568px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="txtWorkGroupName" ValidationGroup="groupThem" Text="(*)" ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        
                        <div>
                            <p>UserID <asp:TextBox runat="server" ID="txtKeySearch" onkeyup="txtKeySearch_OnChange();" CssClass="txt" Width="120px" Height="16px" OnTextChanged="txtKeySearch_TextChanged" AutoPostBack="True"></asp:TextBox>
                                 <asp:DropDownList runat="server" ID="ddlDepartment" Width="150px" Height="22px"  AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:LinkButton runat="server" ID="btnSearchUserProcess" Text="" CssClass="link-btn"
                                     OnClick="btnSearchUserProcess_Click" ><img src="../Images/Search-icon-small.gif" height="15px" width="15px" /> Search</asp:LinkButton>
                            </p>
                    
                          
                           <table>
                               <tr>
                                   <td valign="top">
                                        <asp:ListBox Height="114px" runat="server" ID="lsbUserTim" DataTextField="USERNAME"
                                                DataValueField="USERID" Width="250px" AutoPostBack="false" SelectionMode="Multiple">
                                            </asp:ListBox>
                                   </td>
                                   <td valign="top">
                                            <asp:LinkButton Width="125px" runat="server" ID="lnkAddUserProcess" CssClass="btn"
                                                OnClick="lnkAddUserProcess_Click"><img src="../Images/Forward.png" />Add</asp:LinkButton>
                                            <br />
                                            <br />
                                            <asp:LinkButton runat="server" ID="cmdDeleteUser" CssClass="btn" OnClick="cmdDeleteUser_Click"><img src="../Images/Erase.png" />Delete</asp:LinkButton>
                                    </td>
                                   <td valign="top"><asp:ListBox runat="server" ID="lbsUserXuLy" DataTextField="USERNAME" DataValueField="USERID"
                                                    Visible="false" Width="350px" AutoPostBack="false" Height="115px" SelectionMode="Multiple">
                                                </asp:ListBox></td>
                               </tr>
                           </table>
                            
                        </div>
                         
                        <p > Description&nbsp; <asp:TextBox ID="txtContent" runat="server"  Width="849px"  Height="22px"></asp:TextBox></p>
                        <p align="left"><asp:Button ID="btnInsert" runat="server"  BackColor="#F0CCFF"  ForeColor="Blue" Text="Save" CssClass="right link-btn"  ValidationGroup="groupThem" OnClick="btnInsert_Click"  /> &nbsp; &nbsp; &nbsp; 
                            <asp:LinkButton ID="LinkCreateMessage" runat="server" OnClick="LinkCreateMessage_Click"><img src="../Images/Create.png" /> Create Message</asp:LinkButton>
                        </p>
                    </div>                	
                    <div class="list" id="list-congvieccanlam">            	        
            	                  	        
            	        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="ugno,userid2"
                            CssClass="tbl-list" Width="100%" onrowcreated="grvWork_RowCreated" 
                            onrowdatabound="grvWork_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                            <Columns>
                                
                                <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                          <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>     
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblugno" runat="server" Text='<%#Eval("ugno") %>'></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>                           
                                <asp:TemplateField HeaderText="Group Share"> 
                                    <ItemTemplate>
                                      <%--  <asp:LinkButton runat="server" ID="lbtnForward" Text='<%# DataBinder.Eval(Container.DataItem,"UGtitle") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ugno")%>' OnClick="lbtnForward_Click"></asp:LinkButton>--%>
                                       
                                        <asp:Label ID="lblUGtitle" runat="server" Text='<%#Eval("UGtitle") %>'></asp:Label>
                                    </ItemTemplate> 
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUGtitle" runat="server" Text='<%#Eval("UGtitle") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                     <ItemStyle Width="40%" />  
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User ID Share" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserid2" runat="server" Text='<%#Eval("userid2") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtuserid2" runat="server" Text='<%#Eval("userid2") %>' OnTextChanged="txtuserid2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lbUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Note">
                                    <ItemTemplate >
                                        <asp:Label ID="lblUGmemo" runat="server" Text='<%#Eval("UGmemo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUGmemo" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" CommandName="Select" Text="Edit" Width="70px" />
                                    </ItemTemplate>
                                    <ItemStyle Width="8%" HorizontalAlign="Center" />
                                </asp:TemplateField>--%>

                                   <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="8%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" ><img src="../Content/Icon/edit.gif" /></asp:LinkButton>
                                     
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnUpdate" Text="Update" runat="server" CommandName="Update" ValidationGroup="groupsua" />
                                        <asp:LinkButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                                    </EditItemTemplate>
                                    
                                       <ItemStyle Width="15%" HorizontalAlign="Center" />
                                    
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="8%">
                                    <ItemTemplate>
                                       
                                        <span onclick="return confirm('Are you sure want to delete?')">
                                            <asp:LinkButton ID="btnDelete" Text="" runat="server" CommandName="Delete" ><img src="../Content/Icon/delete.png" /> Delete</asp:LinkButton>
                                        </span>
                                    </ItemTemplate>
                                   
                                       <ItemStyle Width="15%" HorizontalAlign="Center" />
                                    
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle ForeColor="#0072BC" />
                        </asp:GridView>                       
                       
                        <p  style="display:none">
                            <asp:TextBox ID="txtugno" runat="server"></asp:TextBox></p>
   
      
       
 </div>
      </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>
