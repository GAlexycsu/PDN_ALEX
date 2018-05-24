<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMater/SiteUser.Master" AutoEventWireup="true" CodeBehind="frmViewPhieuNghiPhep.aspx.cs" Inherits="iOffice.presentationLayer.Users.frmViewPhieuNghiPhep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="../../Style/css/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="../../Style/css/bootstrap-theme.min.css" type="text/css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <style>        
        .border{border:1px solid #333}
        .height{height: 90px; padding-top: 10px;}
        .height_70{height: 70px; padding-top: 10px;}
        .text_center{text-align: center;}
        .no_border_top{border-top:none;}
        .no_border_right{border-right:none;}
        .no_border_bottom{border-bottom:none;}
        .no_border_left{border-left:none;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1000px; margin: 0 auto;">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-10">
                    <div class="container-fluid">
                        <div class="row" style="height: 30px;"></div>
                        
                        <div class="row" style="height: 70px;">
                            <div class="col-xs-6" style="text-transform: uppercase; font-size: 18px; font-weight: bold;">
                                công ty tnhh tỷ hùng
                            </div>
                            <div class="col-xs-6" style="text-transform: uppercase; font-size: 18px; font-weight: bold;">
                                đơn xin nghỉ
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-2 border height text_center no_border_right no_border_bottom">
                                Họ và tên người xin nghĩ                                
                            </div>
                            <div class="col-xs-5 border height no_border_right no_border_bottom"></div>
                            <div class="col-xs-2 border height text_center no_border_right no_border_bottom">
                                Đơn vị<br />
                                &nbsp;<br />
                                Tổ
                            </div>
                            <div class="col-xs-3 border height no_border_bottom"></div>
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-2 border height text_center no_border_right no_border_bottom">Loại nghỉ</div>
                            <div class="col-xs-3 border height no_border_right no_border_bottom"></div>
                            <div class="col-xs-2 border height no_border_right no_border_bottom" style="padding: 0px;">
                                <div style="border-bottom: 1px solid #333; height: 45px; padding: 10px; text-align: center;">Số thẻ</div>
                                <div class=""><br /></div>
                            </div>
                            <div class="col-xs-2 border height no_border_right no_border_bottom"><br />Người thay thế</div>
                            <div class="col-xs-3 border height no_border_bottom"></div>                            
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-2 border height text_center no_border_right no_border_bottom"><br />Lý do</div>
                            <div class="col-xs-10 border height no_border_bottom"></div>
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-12 border height_70 no_border_bottom">                            
                            Thời gian nghỉ từ năm tháng ngày giờ đến tháng năm ngày giờ ngưng tổng cộng ngày giờ
                            </div>                            
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-6 border height_70 no_border_right no_border_bottom">
                                <div style="width: 40%; float: left;">Điền đơn</div>
                                <div style="width: 60%; float: left;">ngày &nbsp;&nbsp;&nbsp; tháng &nbsp;&nbsp;&nbsp; năm</div>
                            </div>
                            <div class="col-xs-6 border height_70 no_border_bottom">Người điền đơn</div>                                                                                                          
                        </div>
                        
                        <div class="row">                            
                            <div class="col-xs-12 border height_70">Ghi chú</div>                                                                                                          
                        </div>
                        
                    </div>
                </div>
                <div class="col-xs-2">
                    <div style="height: 30px;"></div>
                    <div class="height">Tổ trưởng</div>
                    <div class="height">CQDV</div>
                    <div class="height">CQ 7 Đơn vị lớn</div>
                    <div class="height">P.Hiệp lý</div>
                    <div class="height">P.Tổng giám đốc</div>
                    <div class="height">Tổng giám đốc</div>
                    <div style="text-align: right;">NS-WM001-02A</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
