using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;

namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmKhongDuyet : System.Web.UI.Page
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDetail.Visible = false;
                string UserID = (string)Request["UserID"];
                string macongty = (string)Request["GSBH"];
                string pdno = (string)Request["pdno"];
                string ngonngu = (string)Request["languege"];
                if (UserID != null && macongty != null && pdno != null && ngonngu != null)
                {
                    Session["user"] = UserID.ToString().Trim();
                    Session["UserID"] = UserID.ToString().Trim();
                    Session["maphieu"] = pdno.ToString().Trim();
                    Session["congty"] = macongty.ToString().Trim();
                    Session["languege"] = ngonngu.ToString().Trim();
                }
                string ghichu = "";
                int Yn=2;
                bool duyet = false;
                 Abcon timmaphieu = AbconDAO.TimPhieuTheoNguoiTao(pdno, macongty, UserID);
                 if (timmaphieu != null && timmaphieu.Yn == 4)
                 {
                     Dictionary<bool, Abcon> capDangDuyet = pnaDAO.LayCapDangDuyetCuaVanBanQuaMail(pdno, UserID, macongty, true, true);
                     Abcon cd = capDangDuyet.First().Value;
                     pdna vb = pnaDAO.TimVanBanTheoMa(pdno, macongty, true);
                     Busers2 nvkt = UserDAO.LayNhanVienKhoiTaoCuaVanBan(pdno, true);
                     Busers2 nvduyet = UserDAO.TimNhanVienTheoMa(UserID, macongty);
                     AbconDAO.SuaChiTiet1(cd, UserID, ghichu, duyet, true);
                     PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(pdno, cd.abps);
                     PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                     ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                     TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                     dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                     string beginDiv = "<div style=\"border-style: solid; border-color: inherit; width:600px; border-width:1px;\"" + "><br/>";
                     string endDiv = "</div> <br/>";
                     string thongtin = duyet ? "ĐÃ ĐƯỢC DUYỆT 已经审核" : "KHÔNG ĐƯỢC DUYỆT 未签" +"<br/>";
                     string noidung = "Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为" + "<br/>";
                     noidung += thongtin + "<br/>";
                     noidung = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                     noidung += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                     noidung += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                     noidung += "- Người duyệt 审核者: " + nvduyet.USERNAME + "<br/>";
                    
                     Until.SendMailNguoiTao(nvduyet.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] ",beginDiv+ thongtin+ noidung+ endDiv);

                     btnDetail.Visible = true;
                     lblThongBao.Text = "Bạn đã không xét duyệt phiếu này - 本单未审核";
                     Session["maloaiphieutam"] = timmaphieu.abtype.Trim();
                 }
                 else
                 {

                     Abcon timphieu = AbconDAO.TimPhieuTheoNguoiTao(pdno, macongty, UserID);
                     if (timphieu != null)
                     {
                         if (timphieu.Yn == 2 && timphieu.abrult == false)
                         {

                             btnDetail.Visible = true;
                             Session["maloaiphieutam"] = timphieu.abtype.Trim();
                             lblThongBao.Text = "Bạn đã duyệt phiếu này rồi - 您已经审核";
                         }
                         else
                         {
                             if (timphieu.Yn == 1 && timphieu.abrult == false)
                             {
                                 btnDetail.Visible = true;
                                 Session["maloaiphieutam"] = timphieu.abtype.Trim();
                                 lblThongBao.Text = "Bạn đã duyệt phiếu này rồi - 您已经审核";
                             }
                         }
                     }
                 }
               
            }
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            string maloaiphieutam = (string)Session["maloaiphieutam"];
            if (maloaiphieutam != null)
            {

                if (maloaiphieutam == "PDN2")
                {
                    Response.Redirect("phieumuahangD.aspx");
                }
                else
                {
                    Response.Redirect("frmDetails2D.aspx");
                }
            }
        }
    }
}