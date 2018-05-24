<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteAddmin.Master" AutoEventWireup="true" CodeBehind="QPDNFlow2.aspx.cs" Inherits="iOffice.presentationLayer.Admin.QPDNFlow2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
        <asp:Panel ID="Panel1" runat="server" Height="400px">
            <table style="text-align:left; margin:0px 0px 0px 30px; width: 800px;">
            <asp:Label ID="lbQuytrinh" runat="server" Text=" Quy Trình xét duyệt"></asp:Label>
            <tr style="text-align:left; width:200px" >
              <td style="width:170px"><asp:Label ID="lbLoaiPhieu" runat="server" Text="单别"  ></asp:Label></td>
                <td><asp:DropDownList ID="Droploaiphieu" runat="server"></asp:DropDownList></td>

            </tr>
            <tr>
               <td> <asp:Label ID="lbBoPhan" runat="server" Text="提议单位"></asp:Label></td>
                <td>
                    &nbsp;<asp:DropDownList ID="DropBoPhan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropBoPhan_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="float:left">
                    <asp:Button ID="btnQuery" runat="server" Text="Query" OnClick="btnQuery_Click" /></td>
            </tr>
            <tr style="border-color:red"> 
               <td> <asp:Label ID="lbThongBao" runat="server" Text="" ></asp:Label></td>
            </tr>
               <tr>
                   <td>
                       <asp:CheckBox ID="checktotruong" runat="server"  Text="Tổ trưởng"/>
                   </td>
               </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="checkchurquan" runat="server" Text="单位主管" ValidationGroup="Group1" Checked="True" /></td>
                    <td>
                        <asp:DropDownList ID="DropNguoiDuyet1" runat="server" Enabled="False"></asp:DropDownList>
                        <%--<asp:TextBox ID="txtChuQuan" runat="server" ReadOnly="true"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="checkchuquankhac" runat="server" Text="单位主管" /></td>
                    <td> <asp:DropDownList ID="DropNguoiDuyetKhac" runat="server" OnSelectedIndexChanged="DropNguoiDuyetKhac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> </td>
                    <td> <asp:Label ID="lbchuquan" runat="server" Text="单位主管: "></asp:Label></td>
                    <td>
                        <asp:Label ID="lbChuQuanKhac1" runat="server" Text=""></asp:Label></td>
                </tr>
                 <tr>
                    <td>
                        <asp:CheckBox ID="checkchuquankhac1" runat="server" Text="七大部门主管 " /></td>
                    <td> <asp:DropDownList ID="DropDownchuquankhac1" runat="server"></asp:DropDownList> </td>
                     
                </tr>
                 <tr>
                    <td>
                        <asp:CheckBox ID="checkchuquankhac2" runat="server" Text="七大部门主管 " /></td>
                    <td> <asp:DropDownList ID="DropDownchuquankhac2" runat="server"></asp:DropDownList> </td>
                    
                </tr>
                 <tr>
                    <td>
                        <asp:CheckBox ID="checkchuquankhac3" runat="server" Text="七大部门主管 " /></td>
                    <td> <asp:DropDownList ID="DropDownChuquankhac3" runat="server"></asp:DropDownList> </td>
                     
                </tr>
                 <tr>
                    <td>
                        <asp:CheckBox ID="Checkchuquankhac4" runat="server" Text="七大部门主管 " /></td>
                    <td> <asp:DropDownList ID="DropDownchuquankhac4" runat="server"></asp:DropDownList> </td>
                     
                </tr>
                <tr>
                    <td style="width:50px">
                        <asp:CheckBox ID="checkchuquan7" runat="server"  Text="七大部门主管" ValidationGroup="Group1" Checked="True"/></td>
                    <td>
                        <asp:DropDownList ID="DropNguoiDuyet2" runat="server" Height="16px" Width="190px"></asp:DropDownList></td>
                </tr>
                <tr>
                      <td>
                        <asp:CheckBox ID="checkhieply" runat="server" Text="协理" Checked="True" /></td>
                    <td>
                        <asp:DropDownList ID="DropNguoiDuyet3" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="checkphotong" runat="server" Text="副总经理" ValidationGroup="Group1" Checked="True" /></td>
                    <td>
                        <asp:DropDownList ID="DropNguoiDuyet4" runat="server"></asp:DropDownList></td>
                </tr>
                
                <tr>
                    
   
                      <td>
                        <asp:CheckBox ID="Checktonggd" runat="server" Text="总经理" ValidationGroup="Group1" Checked="True" /></td>
                    
                    <td>
                        <asp:DropDownList ID="DropNguoiDuyet5" runat="server"></asp:DropDownList></td>
                </tr>
                <tr style=" width:100px; text-align:center">
                    <td><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"></asp:Button></td>
                </tr>
            </table>
            
        </asp:Panel>
        
    </div>
    <br />
    <br />
    <div>
        <asp:Panel ID="Panel2" runat="server" Height="231px" style="margin-top: 0px">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20">
                <Columns>
                    <asp:TemplateField HeaderText="STT">
                      <%--  <ItemTemplate><%#GetSTT() %></ItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
        
</asp:Content>
