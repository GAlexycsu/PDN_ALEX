using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class Guinguoidich : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal = new dalPDN();
        userDAL dalUser = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null && Session["languege"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(34, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
               
                HienThiNguoiDich();
                HienThiDoUuTien();

               
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
            Button2.Text = hasLanguege["Button2"].ToString();
            string ngonngu = Session["languege"].ToString();

        }
        private void HienThiNguoiDich()
        {
            //string mabophan = "VTY0501D";
            //string macongty = Session["congty"].ToString();
            //DropDownNguoiDich.DataSource = UserBUS.HienThiDanhSachNguoiDich(mabophan,macongty);
            //DropDownNguoiDich.DataValueField = "USERID";
            //DropDownNguoiDich.DataTextField = "USERNAME";
            //DropDownNguoiDich.DataBind();
            string ngonngu = Session["languege"].ToString();
            //DropDownNguoiDich.DataSource = NguoiDichDAO.QryNguoiDich();
            //DropDownNguoiDich.DataValueField = "USERID";
            string congty = Session["congty"].ToString();
            string donvi = ConfigurationManager.AppSettings["DepartIDPD"].ToString();
            DataTable dt = dalUser.QryNguoiDich(congty, donvi);
            if (dt.Rows.Count > 0)
            {
                DropDownNguoiDich.DataSource = dt;
                DropDownNguoiDich.DataValueField = "USERID";
                if (ngonngu == "lbl_VN")
                {
                    DropDownNguoiDich.DataTextField = "USERNAME";
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                }
            }
            DropDownNguoiDich.DataBind();
        }
        private void HienThiDoUuTien()
        {
            string ngonngu = Session["languege"].ToString();
            DropDoUuTien.DataSource = DoUuTienDAO.LayCapDoUuTien();
            DropDoUuTien.DataValueField = "ABC";

            if (ngonngu == "lbl_VN")
            {
                DropDoUuTien.DataTextField = "NameABC";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDoUuTien.DataTextField = "NameABCTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDoUuTien.DataTextField = "NameABC";
            }
            DropDoUuTien.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string maloai = Session["loaiphieu"].ToString();
                string phieu = Session["maphieu"].ToString();


                string congty = Session["congty"].ToString();
                string user = Session["user"].ToString();

                string manguoiduyet = DropDownNguoiDich.SelectedValue.ToString();
                //pdna kiemtra = pnaDAO.LayPhieuTheoNguoiGui(phieu, user, congty);
                DataTable dtPhieu = dal.TimPhieuTheoMaNguoiTao(phieu, congty, user);
                if (dtPhieu.Rows.Count > 0)
                {
                    int yn = int.Parse(dtPhieu.Rows[0]["Yn"].ToString());
                    if (yn == 6)
                    {
                        string ngonngu = Session["languege"].ToString();
                        if (ngonngu == "lbl_VN")
                        {
                            LbThongBao.Text = "Phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                        }
                        else if (ngonngu == "lbl_TW")
                        {
                            LbThongBao.Text = "资料已经转送翻译成中文（越文）。请巡查名单，并知本单的状态是否翻译完成。谢谢！";
                        }
                        else if (ngonngu == "lbl_EN")
                        {
                            LbThongBao.Text = "Phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        phieun.GSBH = congty;
                        phieun.pdno = phieu;
                        phieun.pddepid = dtPhieu.Rows[0]["pddepid"].ToString();
                        phieun.Abtype = maloai;
                        phieun.mytitle = dtPhieu.Rows[0]["mytitle"].ToString();
                        phieun.pdmemovn = dtPhieu.Rows[0]["pdmemovn"].ToString();
                        phieun.CFMDate0 = DateTime.Parse(dtPhieu.Rows[0]["CFMDate0"].ToString());
                        phieun.USERID = user;
                        //phieun.CFMID0 = user;
                        phieun.CFMID0 = user;
                        phieun.bixoa = false;

                        phieun.USERDATE = DateTime.Today;
                        phieun.ABC = Convert.ToInt32(DropDoUuTien.SelectedValue.ToString());
                        phieun.LevelDoing = 0;
                        phieun.IdnguoiDich = manguoiduyet;
                        phieun.trangthaidich = false;
                        phieun.dagui = false;
                        phieun.YN = 3;
                        //pnaDAO.CapNhatPhieuTaoNhoDich(phieun, congty);
                        db.CapNhatPhieuTheoNguoiTaoNhoDich(phieun.pdno, phieun.GSBH, phieun.dagui, phieun.bixoa, phieun.YN, phieun.mytitle, phieun.pddepid, phieun.Abtype, phieun.pdmemovn, phieun.CFMDate0, phieun.USERID, phieun.CFMID0, phieun.USERDATE, phieun.ABC, phieun.LevelDoing, phieun.IdnguoiDich, phieun.trangthaidich);
                    }
                    
                }
                DataTable dt = dal.TimPhieuTheoMaNguoiTao(phieu, congty, user);
                if (dt.Rows.Count > 0)
                {
                
                    Busers2 nhanvientao = UserBUS.TimMaNhanVienTaoPhieu(user, congty);
                    Busers2 nhanviendich = UserBUS.TimMaNhanVienDich(manguoiduyet, congty);
                    if (nhanvientao != null && nhanviendich != null)
                    {
                        string ngonngu = Session["languege"].ToString();
                        String noidung2 = "Chào anh/chị. Tôi có 1 phiếu nhờ anh/chị dịch giúp với";
                        noidung2 += "- Mã văn bản: " + dtPhieu.Rows[0]["pdno"].ToString() + "\n";
                        noidung2 += "- Tiêu đề: " + dt.Rows[0]["mytitle"].ToString() + "\n";

                        noidung2 += "- Ngày tạo: " + dtPhieu.Rows[0]["CFMDate0"].ToString() + "\n";
                        noidung2 += "- Người nhờ dịch: " + nhanvientao.USERNAME + "\n";
                        //noidung2 += "Click on link " + "http://192.168.11.8/pdn/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx";
                        Until.SendMailNguoiDich(nhanvientao.EMAIL, nhanviendich.EMAIL, "[Ty Hung-eOffice] Thông báo có phiếu cần dịch ", noidung2,nhanviendich.USERID,congty,ngonngu);

                      
                        if (ngonngu == "lbl_VN")
                        {
                            LbThongBao.Text = "phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                        }
                        else if (ngonngu == "lbl_TW")
                        {
                            LbThongBao.Text = "资料已经转送翻译成中文（越文）。请巡查名单，并知本单的状态是否翻译完成。谢谢！";
                        }
                        else if (ngonngu == "lbl_EN")
                        {
                            LbThongBao.Text = "phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            Response.Redirect("MyDocusRe.aspx");
        }
    }
}