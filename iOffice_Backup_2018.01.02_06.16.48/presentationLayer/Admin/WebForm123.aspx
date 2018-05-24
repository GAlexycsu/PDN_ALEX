<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WebForm123.aspx.cs" Inherits="iOffice.presentationLayer.Admin.WebForm123" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div style="margin-left:50px">
          <table>
            <tr>
                <td>From Date : <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox></td>
                <td> To Date :<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox> </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>UserID : </td>
                <td>
                    <asp:TextBox ID="txtTimKiem" placeholder="All" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:CheckBox ID="cbOk" runat="server" Text="Ok" /></td>
                <td>
                    <asp:CheckBox ID="cbNoOk" runat="server" Text="No ok" /></td>
                <td>
                    <asp:Button ID="btnQuery" runat="server" Text="Query" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnQuery_Click" Width="73px" />
                   
                </td>
                <td>
                    <asp:Button ID="btnBack" runat="server" Text="Back" BackColor="#F0CCFF" ForeColor="Blue" OnClick="btnBack_Click" Width="74px" />
                </td>
            </tr>
        </table>
        
      <p style="width:800px;margin-left:100px;">
          <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
      </p>
    </div>
     <div id="divGrid1" runat="server" style="width:92%; overflow: auto;">
        
              <asp:GridView ID="GridView1" runat="server" Width="1080px" AutoGenerateColumns="False" style="margin-right: 0px">
                  <Columns>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblCFMID0" runat="server" Text='<%#Eval("CFMID0") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Creater">
                          <ItemTemplate>
                              <asp:Label ID="lblNguoiTao" runat="server" Text='<%#Eval("NguoiTao") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false" >
                          <ItemTemplate>
                              <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype")%>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单别">
                          <ItemTemplate>
                              <asp:Label ID="lblTenLoaiPhieu" runat="server" Text='<%#Eval("abname") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单号">
                          <ItemTemplate>
                              <asp:Label ID="lblSoPhieu" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="题目">
                          <ItemTemplate>
                              <asp:Label ID="lblTieuDe" runat="server" Text='<%#Eval("mytitle") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblTenDonVi" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblYn" runat="server" Text='<%#Eval("YN") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Status">
                          <ItemTemplate>
                              <asp:Label ID="lblYnName" runat="server" ForeColor="Red" Text='<%#Eval("YnName") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                       <asp:TemplateField HeaderText="审核步骤">
                          <ItemTemplate>
                              <asp:Label ID="lblAbStep" runat="server" Text='<%#Eval("LevelDoing") %>'></asp:Label>
                          </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Eval("CFMID1") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="审核员">
                          <ItemTemplate>
                              <asp:Label ID="lblAuditor" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Date">
                          <ItemTemplate>
                              <asp:Label ID="lblNgay" runat="server" Text='<%#Eval("CFMDate0","{0:yyyy/MM/dd}") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                  </Columns>
              </asp:GridView>
        
       
    </div>
    <div id="divGrid2" runat="server" style="width:1092px; overflow: auto;">
         
              <asp:GridView ID="GridView2" runat="server" Width="1081px" AutoGenerateColumns="False">
                  <Columns>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblCFMID0" runat="server" Text='<%#Eval("CFMID0") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Creater">
                          <ItemTemplate>
                              <asp:Label ID="lblNguoiTao" runat="server" Text='<%#Eval("NguoiTao") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaLoaiPhieu" runat="server" Text='<%#Eval("Abtype")%>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单别">
                          <ItemTemplate>
                              <asp:Label ID="lblTenLoaiPhieu" runat="server" Text='<%#Eval("abnameTW") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="单号">
                          <ItemTemplate>
                              <asp:Label ID="lblSoPhieu" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="题目">
                          <ItemTemplate>
                              <asp:Label ID="lblTieuDe" runat="server" Text='<%#Eval("mytitle") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblMaDonVi" runat="server" Text='<%#Eval("pddepid") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblTenDonVi" runat="server" Text='<%#Eval("DepName") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="lblYn" runat="server" Text='<%#Eval("YN") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Status">
                          <ItemTemplate>
                              <asp:Label ID="lblYnName" runat="server" ForeColor="Red" Text='<%#Eval("YnName") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                        <asp:TemplateField HeaderText="审核步骤">
                          <ItemTemplate>
                              <asp:Label ID="lblAbStep" runat="server" Text='<%#Eval("LevelDoing") %>'></asp:Label>
                          </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField Visible="false">
                          <ItemTemplate>
                              <asp:Label ID="Label3" runat="server" Text='<%#Eval("CFMID1") %>'></asp:Label>
                          </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="审核员">
                          <ItemTemplate>
                              <asp:Label ID="lblAuditor" runat="server" Text='<%#Eval("USERNAME") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Date">
                          <ItemTemplate>
                              <asp:Label ID="lblNgay" runat="server" Text='<%#Eval("CFMDate0","{0:yyyy/MM/dd}") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                      </asp:TemplateField>
                  </Columns>
              </asp:GridView>
         
   
    </div>
    <div style="width:1047px">
       <div style="float:left">
            <asp:Button ID="btnExportExcel" runat="server" Text="Export To Excel" OnClick="btnExportExcel_Click" />
       </div>
        <div style="float:right">
            <asp:Button ID="btnReject" runat="server" Text="System Reject" />
        </div>
    </div>
</asp:Content>
