<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/MyDocus.Master" AutoEventWireup="true" CodeBehind="wf_Danhsachphieudaduocky.aspx.cs" Inherits="iOffice.presentationLayer.ApproveUser.wf_Danhsachphieudaduocky" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery.min.js"></script>
    <script src="../../Scripts/jquery-ui.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <p>
        <asp:Label ID="Label1" runat="server" Text="Danh sách phiếu đã duyệt 已经审核名单"></asp:Label></p>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" PageSize="25" OnRowDeleting="GridView1_RowDeleting" Width="1069px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />

                <asp:CommandField DeleteText="Details" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="abtypes" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblCustID" runat="server" Text='<%#Eval("abtype") %>'></asp:Label>
                  </ItemTemplate>
              </asp:TemplateField>
                <asp:BoundField DataField="abname" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Label ID="lblpdno" runat="server" Text='<%#Eval("pdno") %>'></asp:Label>
                    </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="mytitle" />
                <asp:BoundField DataField="YnName" />
                <asp:BoundField DataField="NameABC" />
                <asp:BoundField DataField="USERNAME" />
                 <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="LblIDdep" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="DepName" />
                
                

            </Columns>
            <HeaderStyle BackColor="Tomato" CssClass="FixedHeader"></HeaderStyle>
        </asp:GridView>
         
    </div>
</asp:Content>
