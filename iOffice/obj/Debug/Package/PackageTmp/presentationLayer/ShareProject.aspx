<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MasterPage2.Master" AutoEventWireup="true" CodeBehind="ShareProject.aspx.cs" Inherits="iOffice.presentationLayer.ShareProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:UpdatePanel ID="pnSHare" runat="server">
        <ContentTemplate>
    <div>
        <table>
            <tr>
                <td>System Name</td>
                <td>
                    <asp:DropDownList ID="DropDownsystem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownsystem_SelectedIndexChanged"></asp:DropDownList></td>
                <td>Sub System</td>
                <td>
                    <asp:DropDownList ID="DropDownSubsystem" runat="server"></asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnQuery" runat="server" Text="Query" ForeColor="#6600ff" OnClick="btnQuery_Click" /><asp:Button ID="btnShareU" runat="server" ForeColor="Blue" Text="Share with User" OnClick="btnShareU_Click" /></td>
            </tr>
        </table>
        <br />
        <br />
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblGSBH" runat="server" Text='<%#Eval("GSBH") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblJsysid" runat="server" Text='<%#Eval("Jsysid") %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="System Name">
                        <ItemTemplate>
                            <asp:Label ID="lblsysname" runat="server" Text='<%#Eval("SystemName") %>'></asp:Label>
                        </ItemTemplate>
                          <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblJsubid" runat="server" Text='<%#Eval("Jsubid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sub System Name">
                        <ItemTemplate>
                            <asp:Label ID="lbljsubname" runat="server" Text='<%#Eval("jsubname") %>'></asp:Label>
                        </ItemTemplate>
                          <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblJodid" runat="server" Text='<%#Eval("Jodid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Job Name">
                        <ItemTemplate>
                            <asp:Label ID="lbljobname" runat="server" Text='<%#Eval("jobname") %>'></asp:Label>
                        </ItemTemplate>
                          <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User ID Share">
                        <ItemTemplate>
                            <asp:Label ID="lblJuserid" runat="server" Text='<%#Eval("Juserid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note">
                        <ItemTemplate>
                            <asp:Label ID="lbljuamemo" runat="server" Text='<%#Eval("juamemo") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" ForeColor="Blue" CommandName="Select" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate> 
                                <asp:Button ID="btbxoagr3" runat="server" ForeColor="Red" CommandName="Delete" Text="Delete"  
                                    onclientclick="return confirm('Are you sure you want to delete this event?');" /> 
                            </ItemTemplate> 

                </asp:TemplateField>
                    
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    
    </div>
 </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
