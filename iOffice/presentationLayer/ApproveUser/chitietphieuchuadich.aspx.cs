using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.Share;
using iOffice.BUS;
using System.Configuration;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class chitietphieuchuadich : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal = new dalPDN();
        userDAL dalUser = new userDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DropDownNguoiDich.Enabled = false;
            
            // string ngaythang = DateTime.Parse(phieu.CFMDate0.ToString("dd/MM/yyyy"));
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(32, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                btnLuu.Attributes.Add("opacity", "0.3");
                btnLuu.Enabled = false;
                GanNgonNguVaoConTrol();
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                DataTable dt = dal.TimPhieuTheoMaNguoiTao(maphieu, macongty, manguoidung);
              if (dt.Rows.Count>0)
              {
                  string madonvi = dt.Rows[0]["pddepid"].ToString();
                  string maloaiphieu = dt.Rows[0]["Abtype"].ToString();

                  BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                  abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);

                  string tenloaiphieuVN = loaiphieu.abname;
                  string tenloaiphieuTW = loaiphieu.abnameTW;
                  txtTieuDe.Text = dt.Rows[0]["mytitle"].ToString();
                  lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                  lbBoPhan.Text = bophan.DepName;
                  lbSoPhieu.Text = dt.Rows[0]["pdno"].ToString();
                  string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                  string thang = dinhdang.Substring(3, 2);
                  string ngay = dinhdang.Substring(0, 2);
                  string nam = dinhdang.Substring(6, 4);
                  lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                  //lbNgay.Text = ;
                  CKEditorControl1.Text = dt.Rows[0]["pdmemovn"].ToString();
                 
                
              }
                DropDownNguoiDich.Enabled = false;
                CKEditorControl1.Enabled = false;
               
                HienThiNguoiDich();
            }
           
            
            
           
        }
        private void HienThiNguoiDich()
        {
            string ngonngu = Session["languege"].ToString();

           
            string donvi = ConfigurationManager.AppSettings["DepartIDPD"].ToString();
            DataTable dt = dalUser.QryNguoiDich(congty, donvi);
            if (dt.Rows.Count > 0)
            {

                if (ngonngu == "lbl_VN")
                {
                    DropDownNguoiDich.DataSource = dt;
                    DropDownNguoiDich.DataValueField = "USERID";
                    DropDownNguoiDich.DataTextField = "USERNAME";
                    DropDownNguoiDich.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDownNguoiDich.DataSource = dt;
                    DropDownNguoiDich.DataValueField = "USERID";
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                    DropDownNguoiDich.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDownNguoiDich.DataSource = dt;
                    DropDownNguoiDich.DataValueField = "USERID";
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                    DropDownNguoiDich.DataBind();
                }
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            CheckChon.Text = hasLanguege["CheckChon"].ToString();
            btnEdit.Text = hasLanguege["btnEdit"].ToString();
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
        }
        protected void CheckChon_CheckedChanged(object sender, EventArgs e)
        {
           
            if (CheckChon.Checked == true)
            {
                DropDownNguoiDich.Enabled = true;
            }
            else
            {
                DropDownNguoiDich.Enabled = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            pdna kiemtraphieu = pnaDAO.LayVanBanTheoNguoiTrinh(maphieu, macongty, manguoidung);
            if (kiemtraphieu.trangthaidich == true)
            {
                lbThongBao.Text = "Phiếu này đã được dịch rồi không thể sửa được nữa";
            }
            else
            {
               
                
                btnEdit.Enabled = false;
                btnEdit.Attributes.CssStyle.Add("opacity", "0.3");
                CKEditorControl1.Enabled = true;
                btnLuu.Enabled = true;
                btnLuu.Attributes.CssStyle.Add("opacity", "100");
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["user"].ToString();
            //string madonvi = Session["bp"].ToString();
            string nguoidich = "";
            Busers2 nguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
            BDepartment donvi = BDepartmentDAO.TimMaDonVi(nguoitao.BADEPID, macongty);
            DateTime date = DateTime.Now;
            string ngaydich = DateTime.Parse(date.ToShortDateString()).ToString("yyyy/MM/dd");

            try
            {
                pdna phieu = pnaDAO.LayVanBanChuaDichTheoNguoiTrinhKy(maphieu, macongty, manguoidung);
                if (phieu == null)
                {

                }
                else
                {

                    {

                        if (CheckChon.Checked == true)
                        {
                            string manguoidich = DropDownNguoiDich.SelectedValue.ToString();
                            if (manguoidich == phieu.IdnguoiDich)
                            {
                                nguoidich = manguoidich;
                            }
                            else
                            {
                               
                                nguoidich = DropDownNguoiDich.SelectedValue.ToString();
                                Busers2 nhanvientao = UserBUS.TimMaNhanVienTaoPhieu(manguoidung, macongty);
                                ABTranslator nhanviendich = NguoiDichDAO.TimMaNguoiDich(manguoidich);
                                String noidung2 = "Chào anh/chị. Tôi có 1 phiếu nhờ anh/chị dịch giúp với";
                                noidung2 += "- Mã văn bản: " + maphieu + "\n";
                                noidung2 += "- Tiêu đề: " + phieu.mytitle + "\n";

                                noidung2 += "- Ngày tạo: " + ngaydich + "\n";
                                noidung2 += "- Người nhờ dịch: " + nhanvientao.USERNAME + "\n";
                               // noidung2 += "Click on link " + "http://192.168.10.62/pdn/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx";
                                Until.SendMailNguoiDich(nhanvientao.EMAIL, nhanviendich.Email, "[Ty Hung-eOffice] Thông báo có phiếu cần dịch ", noidung2,nguoidich,macongty,ngonngu);
                                // LbThongBao.Text = "phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                            }
                        }
                        else
                        {
                            nguoidich = phieu.IdnguoiDich;
                        }

                    }
                    dal.CapNhatPhieuPDNDich(macongty, maphieu, CKEditorControl1.Text.Trim(), nguoidich,txtTieuDe.Text, false, 3);
                }

                DataTable dtPhieu = dal.TimPhieuGuiNguoiDich(maphieu, macongty, manguoidung);

                if (dtPhieu.Rows.Count > 0)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao.Text = "phiếu đã được gửi đến người dịch, bạn thường xuyên kiểm tra danh sách phiếu đã dịch để biết trạng thái của phiếu đã dịch xong chưa. Xin cảm ơn!";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao.Text = "资料已经转送翻译成中文（越文）。请巡查名单，并知本单的状态是否翻译完成。谢谢！";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao.Text = "Save Success.";
                    }
                    btnEdit.Enabled = true;
                    btnLuu.Enabled = false;
                    btnLuu.Attributes.CssStyle.Add("opacity", "0.3");
                    btnEdit.Attributes.CssStyle.Add("opacity", "100");
                    Response.Redirect("frmChiTietPhieuChuaDich.aspx");
                }
                //}
                // db.SubmitChanges();



            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyDocusRe.aspx");
        }
    }
}