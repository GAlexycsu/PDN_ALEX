<%@ Page Title="" Language="C#" MasterPageFile="~/SiteReport.Master" AutoEventWireup="true" CodeBehind="ReportPhieuMuaHang.aspx.cs" Inherits="iOffice.presentationLayer.Users.ReportPhieuMuaHang" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="overflow:auto">
       <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </div>
</asp:Content>
