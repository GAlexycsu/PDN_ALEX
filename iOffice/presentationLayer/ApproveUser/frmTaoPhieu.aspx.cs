using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using iOffice.Share;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmTaoPhieu : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                LayDuLieuNgonNgu();
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(1, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                HienThiBoPhan();
                HienThiDropDonvi();
                HienThiLoaiPhieu();
                divPhieuDeNghi.Visible = true;
                divPhieuMuaHang.Visible = false;
                // GridView1.Rows[0].Visible = false;
            }


      
            
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            // Try to use parameterized inline query/sp to protect sql injection
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " dwbh FROM clzl where dwbh!='NULL' and dwbh  LIKE '" + prefixText + "%'", conn);
            SqlDataReader oReader;
            conn.Open();
            List<string> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["dwbh"].ToString());
            return CompletionSet.ToArray();
        }
        public override void GanNgonNguVaoConTrol()
        {
            try
            {
                btnTiepTu.Text = hasLanguege["btnTiepTu"].ToString();
                btnLuuTam.Text = hasLanguege["btnLuuTam"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void HienThiBoPhan()
        {
            string congty = Session["congty"].ToString();
            DropDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropDonVi.DataValueField = "ID";
            DropDonVi.DataTextField = "DepName";
            DropDonVi.DataBind();
        }
        private void HienThiDropDonvi()
        {
            string congty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            BDepartment bp = BDepartmentDAO.LayBoPhanTheoMaNguoiDuyet(user, congty);
            if (bp != null)
            {
                DropDonVi.SelectedValue = bp.ID;
            }
        }
        private void HienThiLoaiPhieu()
        {
            string ngonngu = Session["languege"].ToString();
            DropLoaiPhieu.DataSource = abillBUS.ListBill();
            DropLoaiPhieu.DataValueField = "abtype";
            if (ngonngu == "lbl_VN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropLoaiPhieu.DataTextField = "abnameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }

            DropLoaiPhieu.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            //string dem = (pdnaBUS.DemSoLuongVanBan() + 1).ToString();
            //string maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMMdd") + "00" + dem;
            string maphieu = "";
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();

            if (dt.Rows.Count != 0 && aa != "")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();

            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;
            string bp = DropDonVi.SelectedItem.Text;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string macongty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            //string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
            //string idphieu = Session["maphieu"].ToString();
            string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();

            if (loaiphieu != "PDN2")
            {
                Busers2 timnguoitao = UserBUS.TimNhanVienTheoMa(user, macongty);
                if (timnguoitao.IDCapDuyet >= 12)
                {
                    string madonvi = "CBCC";
                    Session["bp"] = madonvi;
                    BDepartment bd = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, madonvi, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, madonvi, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.pdno = maphieu;

                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.Abtype = loaiphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Today;
                                phieun.CFMID0 = user;
                                phieun.USERID = user;
                                phieun.dagui = false;
                                phieun.bixoa = false;

                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;

                            Session["noidung"] = noidung;
                            //Session["ngaytao"] = DateTime;
                            Session["tieude"] = tieude;
                            Response.Redirect("FrmViewCB.aspx");

                        }
                        Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        if (usertao != null && usertao.IDCapDuyet > 12)
                        {
                            Response.Redirect("FrmViewCB.aspx");
                        }
                        else
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            }

                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.pdno = maphieu;

                            phieun.GSBH = macongty;
                            phieun.pdno = maphieu;
                            phieun.Abtype = loaiphieu;
                            phieun.pddepid = bophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Today;
                            phieun.CFMID0 = user;
                            phieun.USERID = user;
                            phieun.dagui = false;
                            phieun.bixoa = false;

                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;

                        Session["noidung"] = noidung;
                        //Session["ngaytao"] = ngaythang;
                        Session["tieude"] = tieude;
                        Response.Redirect("FrmViewCB.aspx");

                    }
                }
                else
                {
                    BDepartment bd = BDepartmentBUS.TimMaDonVi(bophan, macongty);
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, bophan, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, bophan, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.pdno = maphieu;

                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.Abtype = loaiphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Today;
                                phieun.CFMID0 = user;
                                phieun.USERID = user;
                                phieun.dagui = false;
                                phieun.bixoa = false;

                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;

                            Session["noidung"] = noidung;
                            //Session["ngaytao"] = ngaythang;
                            Session["tieude"] = tieude;
                            Response.Redirect("FrmViewCB.aspx");


                        }

                        Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        if (usertao != null && usertao.IDCapDuyet > 12)
                        {

                        }
                        else
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bp;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bp;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bp;
                            }

                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.pdno = maphieu;

                            phieun.GSBH = macongty;
                            phieun.pdno = maphieu;
                            phieun.Abtype = loaiphieu;
                            phieun.pddepid = bophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Today;
                            phieun.CFMID0 = user;
                            phieun.USERID = user;
                            phieun.dagui = false;
                            phieun.bixoa = false;

                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;

                        Session["noidung"] = noidung;
                        //Session["ngaytao"] = ngaythang;
                        Session["tieude"] = tieude;
                        Response.Redirect("FrmViewCB.aspx");

                    }
                }
                
            }
            else
            {
                Response.Redirect("FrmViewCB.aspx");
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void DropDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bophan = DropDonVi.SelectedValue.ToString();
            string tenbophan = DropDonVi.SelectedIndex.ToString();
            Session["bophan"] = bophan;
        }

        protected void DropLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = DropLoaiPhieu.SelectedValue.ToString();
            string tenloaiphieu = DropLoaiPhieu.SelectedIndex.ToString();
            Session["loaiphieu"] = loai;
            if (loai == "PDN2")
            {
                divPhieuMuaHang.Visible = true;
                divPhieuDeNghi.Visible = false;
                btnLuuTam.Enabled = false;
                btnTiepTu.Enabled = false;
            }
            else
            {
                divPhieuMuaHang.Visible = false;
                divPhieuDeNghi.Visible = true;
            }
        }

        protected void btnLuuTam_Click(object sender, EventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            //string dem = (pdnaBUS.DemSoLuongVanBan() + 1).ToString();
            //string maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMMdd") + "00" + dem;
            string maphieu = "";
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();

            if (dt.Rows.Count != 0 && aa != "")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();
            string bp = DropDonVi.SelectedItem.Text;
            string congty = Session["congty"].ToString();
            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;

            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string macongty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
            //string idphieu = Session["maphieu"].ToString();
            string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();

            if (loaiphieu != "PDN2")
            {
                Busers2 timnguoitao = UserDAO.TimNhanVienTheoMa(user, congty);
                if (timnguoitao.IDCapDuyet >= 12)
                {
                    string mabophan = "CBCC";
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, mabophan, macongty);
                    BDepartment bd = BDepartmentDAO.TimMaDonVi(mabophan, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, bophan, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.pdno = maphieu;

                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.Abtype = loaiphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Parse(ngaythang);
                                phieun.CFMID0 = user;
                                phieun.USERID = user;
                                phieun.dagui = false;
                                phieun.bixoa = false;

                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();

                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["noidung"] = noidung;
                            Session["ngaytao"] = ngaythang;
                            Session["tieude"] = tieude;

                            Response.Redirect("Danhsachphieumoikhoitao.aspx");

                        }
                        Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        if (usertao != null && usertao.IDCapDuyet > 12)
                        {
                            Response.Redirect("FrmViewCB.aspx");
                        }
                        else
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bp;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bp;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bp;
                            }

                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.GSBH = congty;
                            phieun.pdno = maphieu;
                            phieun.pddepid = mabophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Parse(ngaythang);
                            phieun.USERID = user;
                            phieun.Abtype = DropLoaiPhieu.SelectedValue;
                            phieun.bixoa = false;
                            phieun.CFMID0 = user;
                            phieun.YN = 5;
                            phieun.USERDATE = DateTime.Parse(ngaythang);
                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();

                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["noidung"] = noidung;
                        Session["ngaytao"] = ngaythang;
                        Session["tieude"] = tieude;

                        Response.Redirect("Danhsachphieumoikhoitao.aspx");

                    }
                }// cap chu quan 7 don vi tro len
                else
                {
                    BDepartment bd = BDepartmentDAO.TimMaDonVi(bophan, macongty);
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, bophan, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, bophan, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.pdno = maphieu;

                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.Abtype = loaiphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Parse(ngaythang);
                                phieun.CFMID0 = user;
                                phieun.USERID = user;
                                phieun.dagui = false;
                                phieun.bixoa = false;

                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();

                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["noidung"] = noidung;
                            Session["ngaytao"] = ngaythang;
                            Session["tieude"] = tieude;

                            Response.Redirect("Danhsachphieumoikhoitao.aspx");

                        }
                        Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        if (usertao != null && usertao.IDCapDuyet > 12)
                        {
                            Response.Redirect("Danhsachphieumoikhoitao.aspx");
                        }
                        else
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bp;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bp;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bp;
                            }

                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.GSBH = congty;
                            phieun.pdno = maphieu;
                            phieun.pddepid = bophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Parse(ngaythang);
                            phieun.USERID = user;
                            phieun.Abtype = DropLoaiPhieu.SelectedValue;
                            phieun.bixoa = false;
                            phieun.CFMID0 = user;
                            phieun.YN = 5;
                            phieun.USERDATE = DateTime.Parse(ngaythang);
                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();

                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["noidung"] = noidung;
                        Session["ngaytao"] = ngaythang;
                        Session["tieude"] = tieude;

                        Response.Redirect("Danhsachphieumoikhoitao.aspx");

                    }
                }

            }
            else
            {
                Response.Redirect("Danhsachphieumoikhoitao.aspx");
            }
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            //string dem = (pdnaBUS.DemSoLuongVanBan() + 1).ToString();
            //string maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMMdd") + "00" + dem;
            string maphieu = "";
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();

            if (dt.Rows.Count != 0 && aa != "")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();

            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;
            string bp = DropDonVi.SelectedItem.Text;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string macongty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
            //string idphieu = Session["maphieu"].ToString();
            string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();
     
            
                Busers2 timnguoitao = UserBUS.TimNhanVienTheoMa(user, macongty);
                if (timnguoitao.IDCapDuyet >= 12)
                {
                    string madonvi = "CBCC";
                    Session["bp"] = madonvi;
                    BDepartment bd = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, madonvi, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, madonvi, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;

                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                            
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Parse(ngaythang);
                                phieun.USERID = user;
                                phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                phieun.bixoa = false;
                                phieun.CFMID0 = user;
                                phieun.YN = 5;
                                phieun.bixoa = false;
                                phieun.USERDATE = DateTime.Parse(ngaythang);
                                phieun.UseIntent = txtMucDich.Text;

                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();
                            string tenhang = txtTenHang.Text;
                            string donvitinh = txtdonvitinh.Text;
                            string soluong = txtSoLuong.Text;
                            string ghichu = txtGhiChu.Text;
                            BOfSupply hang = new BOfSupply();
                            hang.GSBH = macongty;
                            hang.pdno = maphieu;
                            hang.OfSuppliesName = tenhang;
                            hang.BUnit = donvitinh;
                            hang.BNumber = int.Parse(soluong);
                            hang.BCommnent = ghichu;
                            SuppliesDAO.ThemVatTu(hang);
                            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'"));
                            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'");
                            GridView1.DataBind();
                          
                            btnLuuTam.Enabled = true;
                            btnTiepTu.Enabled = true;

                        }
                        Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        if (usertao != null && usertao.IDCapDuyet > 12)
                        {
                            Response.Redirect("FrmViewCB.aspx");
                        }
                        else
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }

                        }
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.GSBH = macongty;
                            phieun.pdno = maphieu;
                            phieun.pddepid = bophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Parse(ngaythang);
                            phieun.USERID = user;
                            phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                            phieun.bixoa = false;
                            phieun.CFMID0 = user;
                            phieun.YN = 5;
                            phieun.bixoa = false;
                            phieun.USERDATE = DateTime.Parse(ngaythang);
                            phieun.UseIntent = txtMucDich.Text;

                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();
                        string tenhang = txtTenHang.Text;
                        string donvitinh = txtdonvitinh.Text;
                        string soluong = txtSoLuong.Text;
                        string ghichu = txtGhiChu.Text;
                        BOfSupply hang = new BOfSupply();
                        hang.GSBH = macongty;
                        hang.pdno = maphieu;
                        hang.OfSuppliesName = tenhang;
                        hang.BUnit = donvitinh;
                        hang.BNumber = int.Parse(soluong);
                        hang.BCommnent = ghichu;
                        SuppliesDAO.ThemVatTu(hang);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'"));
                        GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'");
                        GridView1.DataBind();
                      
                        btnLuuTam.Enabled = true;
                        btnTiepTu.Enabled = true;
                    }
                }
                else
                {
                    BDepartment bd = BDepartmentBUS.TimMaDonVi(bophan, macongty);
                    Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, bophan, macongty);
                    if (us == null)
                    {
                        Busers2 kiemtra = UserDAO.TimNhanVienQuanLyDonVi(user, bophan, macongty);
                        if (kiemtra == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                               
                                btnLuuTam.Enabled = false;
                                btnTiepTu.Enabled = false;
                            }
                        }
                        else
                        {
                            pdna phieun = new pdna();
                            {
                                phieun.GSBH = macongty;
                                phieun.pdno = maphieu;
                                phieun.pddepid = bophan;
                                phieun.mytitle = tieude;
                                phieun.pdmemovn = noidung;
                                phieun.CFMDate0 = DateTime.Parse(ngaythang);
                                phieun.USERID = user;
                                phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                phieun.bixoa = false;
                                phieun.CFMID0 = user;
                                phieun.YN = 5;
                                phieun.bixoa = false;
                                phieun.USERDATE = DateTime.Parse(ngaythang);
                                phieun.UseIntent = txtMucDich.Text;
                            }
                            db.pdnas.InsertOnSubmit(phieun);
                            db.SubmitChanges();
                            string tenhang = txtTenHang.Text.ToUpper();
                            string donvitinh = txtdonvitinh.Text.ToUpper();
                            string soluong = txtSoLuong.Text;
                            string ghichu = txtGhiChu.Text;
                            BOfSupply hang = new BOfSupply();
                            hang.GSBH = macongty;
                            hang.pdno = maphieu;
                            hang.OfSuppliesName = tenhang;
                            hang.BUnit = donvitinh;
                            hang.BNumber = int.Parse(soluong);
                            hang.BCommnent = ghichu;
                            SuppliesDAO.ThemVatTu(hang);
                            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'"));
                            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'");
                            GridView1.DataBind();
                           
                            btnLuuTam.Enabled = true;
                            btnTiepTu.Enabled = true;

                        }

                        //Busers2 usertao = UserBUS.TimNhanVienTheoMa(user, macongty);
                        //if (usertao != null && usertao.IDCapDuyet > 12)
                        //{

                        //}
                        //else
                        //{
                        //    if (ngonngu == "lbl_VN")
                        //    {
                        //        lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bp;
                        //    }
                        //    else if (ngonngu == "lbl_TW")
                        //    {
                        //        lbthongbao.Text = "该用户不属于部门 " + bp;
                        //    }
                        //    else if (ngonngu == "lbl_EN")
                        //    {
                        //        lbthongbao.Text = "The user does not belong to the department" + bp;
                        //    }

                        //}
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        {
                            phieun.GSBH = macongty;
                            phieun.pdno = maphieu;
                            phieun.pddepid = bophan;
                            phieun.mytitle = tieude;
                            phieun.pdmemovn = noidung;
                            phieun.CFMDate0 = DateTime.Parse(ngaythang);
                            phieun.USERID = user;
                            phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                            phieun.bixoa = false;
                            phieun.CFMID0 = user;
                            phieun.YN = 5;
                            phieun.bixoa = false;
                            phieun.USERDATE = DateTime.Parse(ngaythang);
                            phieun.UseIntent = txtMucDich.Text;

                        }
                        db.pdnas.InsertOnSubmit(phieun);
                        db.SubmitChanges();
                        string tenhang = txtTenHang.Text;
                        string donvitinh = txtdonvitinh.Text;
                        string soluong = txtSoLuong.Text;
                        string ghichu = txtGhiChu.Text;
                        BOfSupply hang = new BOfSupply();
                        hang.GSBH = macongty;
                        hang.pdno = maphieu;
                        hang.OfSuppliesName = tenhang;
                        hang.BUnit = donvitinh;
                        hang.BNumber = int.Parse(soluong);
                        hang.BCommnent = ghichu;
                        SuppliesDAO.ThemVatTu(hang);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'"));
                        GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'");
                        GridView1.DataBind();
                       
                        btnLuuTam.Enabled = true;
                        btnTiepTu.Enabled = true;
                    }
                }
            // them vat tu
                
                Session["bp"] = bophan;
                Session["bophan"] = bp;
                Session["loaiP"] = loaiP;
                Session["loaiphieu"] = loaiphieu;
                Session["maphieu"] = maphieu;

                Session["noidung"] = noidung;
                Session["ngaytao"] = ngaythang;
                Session["tieude"] = tieude;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string macongty = Session["congty"].ToString();
                string tieude = Session["tieude"].ToString();
                string maphieu = Session["maphieu"].ToString();
                
                TextBox tenhang = (TextBox)GridView1.FooterRow.FindControl("txtAddOfSuppliesName");
                TextBox donvitinh = (TextBox)GridView1.FooterRow.FindControl("txtAddBUnit");
                TextBox soluong = (TextBox)GridView1.FooterRow.FindControl("txtAddBNumber");
                TextBox ghichu = (TextBox)GridView1.FooterRow.FindControl("txtAddBCommnent");
                BOfSupply hang = new BOfSupply();
                hang.GSBH = macongty;
                hang.pdno = maphieu;
                hang.OfSuppliesName = tenhang.Text.ToUpper();
                hang.BUnit = donvitinh.Text.ToUpper();
                hang.BNumber = int.Parse(soluong.Text);
                hang.BCommnent = ghichu.Text;
                SuppliesDAO.ThemVatTu(hang);
                GridView1.EditIndex = -1;
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'"));
                GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + macongty + "'");
                GridView1.DataBind();
                tenhang.Focus();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();

            string congty = Session["congty"].ToString();
            Label lbmahang = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCustID");
            int mahang = int.Parse(lbmahang.Text.ToString());

            SuppliesDAO.XoaVatTu(mahang);
            GridView1.EditIndex = -1;
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'"));
            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'");
            GridView1.DataBind();
            if (pnaDAO.LayPhieuMuaHang(maphieu, congty).Count() == 0)
            {
                
                btnLuuTam.Enabled = false;
                btnTiepTu.Enabled = false;
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();

            string congty = Session["congty"].ToString();
            Label lblmahang = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCustID");
            TextBox tenhang = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtOfSuppliesName");
            TextBox donvi = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBUnit");
            TextBox soluong = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBNumber");
            TextBox ghichu = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBCommnent");
            BOfSupply vattu = new BOfSupply();
            vattu.IDOfSupplies = int.Parse(lblmahang.Text.ToString());
            vattu.OfSuppliesName = tenhang.Text.ToUpper();
            vattu.BUnit = donvi.Text.ToUpper();
            vattu.BNumber = int.Parse(soluong.Text.ToString());
            vattu.BCommnent = ghichu.Text;
            SuppliesDAO.SuaVatTu(vattu);
            GridView1.EditIndex = -1;
            //GridView1.DataSource = pnaDAO.LayPhieuMuaHang(maphieu, congty);
            //GridView1.DataBind();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'"));
            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'");
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string maphieu = Session["maphieu"].ToString();

            string congty = Session["congty"].ToString();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'"));
            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'");
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            string maphieu = Session["maphieu"].ToString();
            string congty = Session["congty"].ToString();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'"));
            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + maphieu + "' and b.GSBH='" + congty + "'");
            GridView1.DataBind();
        }

        protected void DropDonVi_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lbthongbao.Text = "";
        }
    }

}