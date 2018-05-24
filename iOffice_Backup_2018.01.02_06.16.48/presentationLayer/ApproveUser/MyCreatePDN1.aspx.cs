using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Configuration;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class MyCreatePDN1 : LanguegeBus
    {
        int STT = 1;
        int demMH = 1;
        string demmahang = "";
         iOfficeDataContext db = new iOfficeDataContext();
         departDAL dal = new departDAL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //string UserID = "27276";
            //string congty = "LTY";
            //Session["UserID"] = UserID;
            //Session["user"] = UserID;
            //Session["congty"] = congty;
            //string languege = "lbl_TW";
            //Session["languege"] = languege;
           
            if (!Page.IsPostBack)
            {
                string UserID = (string)Session["UserID"];
                if (UserID==null)
                {
                    Response.Redirect("http://portal.footgear.com.vn/");
                }
               

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
             
                HienThiLoaiPhieu();
                txtMaHang.Attributes.Add("readonly", "readonly");
               
                divPhieuDeNghi.Visible = true;
                divPhieuMuaHang.Visible = false;
          
              
            }
        }
        [WebMethod]
        public static string[] GetCategory(string term)
        {
            List<string> retCategory = new List<string>();
          //  string ConnectionString = @"Data Source=192.168.11.15;Initial Catalog=LY_ERP;User ID=Programer;Password=P@ssw0rd";
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select  distinct top 20 ywpm, cldh  from clzl where ywpm like +@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", term);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retCategory.Add(string.Format("{0}^^{1}", dr["ywpm"], dr["cldh"]));

                    }
                    return retCategory.ToArray();
                }

            }
            //return retCategory.ToArray();
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
        [WebMethod]
        public static string[] DanhSachNhaCungUng(string dieukien)
        {
            try
            {
                List<string> list = new List<string>();
                //string str=@"Data Source =192.168.11.15;Initial Catalog=LY_ERP;User ID=Programer;Password=P@ssw0rd";
               // string str=@"Data Source =192.168.11.6;Initial Catalog=LY_ERP;User ID=sa;Password=tuan123";
                string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select  distinct top 20  zsywjc,zsdh  from zszl where zsywjc like +@SearchText+'%'",con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@SearchText", dieukien);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            list.Add(string.Format("{0}^^{1}", dr["zsywjc"], dr["zsdh"]));
                        }
                        return list.ToArray();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override void GanNgonNguVaoConTrol()
        {
            try
            {
                btnLuuTam.Text = hasLanguege["btnLuuTam"].ToString();
                btnTiepTu.Text = hasLanguege["btnTiepTu"].ToString();
             
                lblMucDich.Text = hasLanguege["lblMucDich"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void HienThiBoPhan()
        {
            string congty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            DataTable dt = dal.QryDonViTheoDieuKien(user, congty);
            if (dt.Rows.Count > 0)
            {
                DropDonVi.DataSource = dt;
                DropDonVi.DataValueField = "ID";
                DropDonVi.DataTextField = "DepName";
                DropDonVi.DataBind();
            }
            else
            {
                DropDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
                DropDonVi.DataValueField = "ID";
                DropDonVi.DataTextField = "DepName";
                DropDonVi.DataBind();
            }
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
            if (ngonngu == "lbl_VN")
            {
                DropLoaiPhieu.DataSource = abillBUS.ListBill();
                DropLoaiPhieu.DataValueField = "abtype";
                DropLoaiPhieu.DataTextField = "abname";
                DropLoaiPhieu.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                DropLoaiPhieu.DataSource = abillBUS.ListBill();
                DropLoaiPhieu.DataValueField = "abtype";
                DropLoaiPhieu.DataTextField = "abnameTW";
                DropLoaiPhieu.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                DropLoaiPhieu.DataSource = abillBUS.ListBill();
                DropLoaiPhieu.DataValueField = "abtype";
                DropLoaiPhieu.DataTextField = "abnameEng";
                DropLoaiPhieu.DataBind();
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
           
       
                
                dalPDN dal = new dalPDN();
                DateTime date = DateTime.Today;
                string ngonngu = Session["languege"].ToString();
                string ktmaphieu = (string)Session["ktmaphieu"];
                string mahangcu = (string)Session["mahangcu"];
                string sizecu = (string)Session["sizecu"];
                if (ktmaphieu == null)
                {
                    string maphieu = "";
                    DataTable dt = dal.DemSoLuongPhieu();
                    string aa = dt.Rows[0]["pdno"].ToString().Trim();
                    if (dt.Rows.Count != 0 && aa != "")
                    {
                        string dem = (int.Parse(aa) + 1).ToString();
                        maphieu = dem;
                    }
                    else
                    {
                        maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM")+"00" + 1;
                    }

                    string themhang = (string)Session["themhang"];

                    string bophan = DropDonVi.SelectedItem.Value.ToString();

                    string tieude = txtTieuDe.Text;
                    string noidung = CKEditorControl1.Text;
                    string bp = DropDonVi.SelectedItem.Text;
                    string loaiP = DropLoaiPhieu.SelectedItem.Text;
                    string macongty = Session["congty"].ToString();
                    string user = Session["user"].ToString();
                    string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd");
                    string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
                    string tenhang = txtAutoComplete.Text.Trim();
                    string donvitinh = txtdonvitinh.Text.ToUpper();
                    string soluong = txtSoLuong.Text.Trim();
                    string ghichu = txtGhiChu.Text.Trim();
                    
                    string Size = "";

                    string mahang = "";
                    if (txtSize.Text.Trim() == "")
                    {
                        Size = ".";
                    }
                    else
                    {
                        Size = txtSize.Text.Trim();
                    }
                    if (txtMaHang.Text.Trim() == "")
                    {
                        string a = (string)Session["demmahang"];
                        if (a == null && demMH == 1)
                        {
                            mahang = "z" + demMH;
                            demMH++;
                            demmahang = demMH.ToString();
                            Session["demmahang"] = demmahang;
                        }
                        else
                        {
                            int so = int.Parse(a);
                            mahang = "z" + so;
                            so++;
                            demmahang = so.ToString();
                            Session["demmahang"] = demmahang;
                        }

                    }
                    else
                    {
                        mahang = txtMaHang.Text;

                    }
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
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_TW")
                                {
                                    lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_EN")
                                {
                                    lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                            }
                            else
                            {
                                if (ktmaphieu == null && maphieu != ktmaphieu)
                                {
                                    pdna phieun = new pdna();
                                    {
                                        phieun.GSBH = macongty;
                                        phieun.pdno = maphieu;
                                        phieun.pddepid = bophan;
                                        phieun.mytitle = tieude;
                                        phieun.pdmemovn = noidung;
                                        phieun.CFMDate0 = DateTime.Today;

                                        phieun.USERID = user;
                                        phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                        phieun.bixoa = false;
                                        phieun.CFMID0 = user;
                                        phieun.YN = 5;
                                        phieun.bixoa = false;
                                        phieun.USERDATE = DateTime.Today;
                                        phieun.UseIntent = txtMucDich.Text;

                                    }
                                    pdnaBUS.InsertPDNA(phieun);
                                    Session["ktmaphieu"] = maphieu;
                                    Session["maphieu"] = maphieu;
                                }
                                else
                                {
                                    dal.CapNhatPhieuDeNghi(macongty, ktmaphieu, bophan, tieude, noidung, date, user, loaiphieu, user, txtMucDich.Text, false, 5, date);
                                    Session["ktmaphieu"] = ktmaphieu;
                                    Session["maphieu"] = ktmaphieu;
                                }

                                string maphieu1 = Session["maphieu"].ToString();
                                DataTable dtTim = dal.TimMaHangTrongPhieu(macongty, mahang, maphieu1);
                                if (themhang == null)
                                {
                                    if (ktmaphieu == null)
                                    {


                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }

                                        HienThiDanhSach();
                                    }
                                    else
                                    {
                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            //dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                        }


                                        HienThiDanhSach();
                                    }
                                }
                                else
                                {
                                    if (ktmaphieu == null)
                                    {



                                        if (mahangcu != null && mahangcu == mahang)
                                        {
                                            if (sizecu == Size)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                            else
                                            {
                                                dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, maphieu1, sizecu);
                                            // dal.XoaCGNOTrongBangCGZLS(congty, CGNO, mahangcu);
                                            if (dtTim.Rows.Count > 0)
                                            {
                                                dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                                //  dal.CapNhatCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong), date, Yn);
                                            }
                                            else
                                            {
                                                dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                                // dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                            }

                                            HienThiDanhSach();

                                        }
                                    }
                                    else
                                    {

                                        if (mahangcu != null && mahangcu == mahang)
                                        {
                                            if (sizecu == Size)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                            else
                                            {
                                                dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }

                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);

                                            if (dtTim.Rows.Count > 0)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                            }
                                            else
                                            {
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                            }

                                            HienThiDanhSach();

                                        }
                                        HienThiDanhSach();
                                        Session.Remove("themhang");
                                        Session.Remove("mahangcu");
                                        Session.Remove("sizecu");
                                    }
                                }

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
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_TW")
                                {
                                    lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_EN")
                                {
                                    lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }

                            }
                        }
                        else
                        {
                            if (ktmaphieu == null && ktmaphieu != maphieu)
                            {
                                pdna phieun = new pdna();
                                {
                                    phieun.GSBH = macongty;
                                    phieun.pdno = maphieu;
                                    phieun.pddepid = bophan;
                                    phieun.mytitle = tieude;
                                    phieun.pdmemovn = noidung;
                                    phieun.CFMDate0 = DateTime.Today;
                                    phieun.USERID = user;
                                    phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                    phieun.bixoa = false;
                                    phieun.CFMID0 = user;
                                    phieun.YN = 5;
                                    phieun.bixoa = false;
                                    phieun.USERDATE = DateTime.Today;
                                    phieun.UseIntent = txtMucDich.Text;

                                }
                                pdnaBUS.InsertPDNA(phieun);
                                Session["ktmaphieu"] = maphieu;
                                Session["maphieu"] = maphieu;
                            }
                            else
                            {
                                dal.CapNhatPhieuDeNghi(macongty, ktmaphieu, bophan, tieude, noidung, date, user, loaiphieu, user,txtMucDich.Text.Trim(), false, 5, date);
                                Session["maphieu"] = ktmaphieu;
                                Session["ktmaphieu"] = ktmaphieu;
                            }
                            string maphieu1 = Session["maphieu"].ToString();
                            DataTable dtTim = dal.TimMaHangTrongPhieu(macongty, mahang, maphieu1);
                            if (themhang == null)
                            {
                                if (ktmaphieu == null)
                                {


                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }

                                    HienThiDanhSach();
                                }
                                else
                                {
                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        //dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                    }


                                    HienThiDanhSach();
                                }
                            }
                            else
                            {
                                if (ktmaphieu == null)
                                {



                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, maphieu1, sizecu);
                                        // dal.XoaCGNOTrongBangCGZLS(congty, CGNO, mahangcu);
                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            //  dal.CapNhatCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong), date, Yn);
                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            // dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                        }

                                        HienThiDanhSach();

                                    }
                                }
                                else
                                {

                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }

                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);

                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }

                                        HienThiDanhSach();

                                    }
                                    HienThiDanhSach();
                                    Session.Remove("themhang");
                                    Session.Remove("mahangcu");
                                    Session.Remove("sizecu");
                                }
                            }
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
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_TW")
                                {
                                    lbthongbao.Text = "该用户不属于部门 " + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                                else if (ngonngu == "lbl_EN")
                                {
                                    lbthongbao.Text = "The user does not belong to the department" + bd.DepName;
                                    tablePMH.Visible = true;
                                    btnLuuTam.Enabled = false;
                                    btnTiepTu.Enabled = false;
                                }
                            }
                            else
                            {
                                if (ktmaphieu == null && ktmaphieu != maphieu)
                                {
                                    pdna phieun = new pdna();
                                    {
                                        phieun.GSBH = macongty;
                                        phieun.pdno = maphieu;
                                        phieun.pddepid = bophan;
                                        phieun.mytitle = tieude;
                                        phieun.pdmemovn = noidung;
                                        phieun.CFMDate0 = DateTime.Today;
                                        phieun.USERID = user;
                                        phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                        phieun.bixoa = false;
                                        phieun.CFMID0 = user;
                                        phieun.YN = 5;
                                        phieun.bixoa = false;
                                        phieun.USERDATE = DateTime.Today;
                                        phieun.UseIntent = txtMucDich.Text;
                                    }
                                    pdnaBUS.InsertPDNA(phieun);
                                    Session["ktmaphieu"] = maphieu;
                                    Session["maphieu"] = maphieu;
                                }
                                else
                                {
                                    dal.CapNhatPhieuDeNghi(macongty, ktmaphieu, bophan, tieude, noidung, date, user, loaiphieu, user, txtMucDich.Text.Trim(), false, 5, date);
                                    Session["ktmaphieu"] = ktmaphieu;
                                    Session["maphieu"] = ktmaphieu;
                                }
                                string maphieu1 = Session["maphieu"].ToString();
                                DataTable dtTim = dal.TimMaHangTrongPhieu(macongty, mahang, maphieu1);
                                if (themhang == null)
                                {
                                    if (ktmaphieu == null)
                                    {


                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }

                                        HienThiDanhSach();
                                    }
                                    else
                                    {
                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            //dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                        }


                                        HienThiDanhSach();
                                    }
                                }
                                else
                                {
                                    if (ktmaphieu == null)
                                    {



                                        if (mahangcu != null && mahangcu == mahang)
                                        {
                                            if (sizecu == Size)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                            else
                                            {
                                                dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, maphieu1, sizecu);
                                            // dal.XoaCGNOTrongBangCGZLS(congty, CGNO, mahangcu);
                                            if (dtTim.Rows.Count > 0)
                                            {
                                                dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                                //  dal.CapNhatCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong), date, Yn);
                                            }
                                            else
                                            {
                                                dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                                // dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                            }

                                            HienThiDanhSach();

                                        }
                                    }
                                    else
                                    {

                                        if (mahangcu != null && mahangcu == mahang)
                                        {
                                            if (sizecu == Size)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }
                                            else
                                            {
                                                dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            }

                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);

                                            if (dtTim.Rows.Count > 0)
                                            {
                                                dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                            }
                                            else
                                            {
                                                dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                            }

                                            HienThiDanhSach();

                                        }
                                        HienThiDanhSach();
                                        Session.Remove("themhang");
                                        Session.Remove("mahangcu");
                                        Session.Remove("sizecu");
                                    }
                                }

                                btnLuuTam.Enabled = true;
                                btnTiepTu.Enabled = true;

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
                            if (ktmaphieu == null && ktmaphieu != maphieu)
                            {
                                pdna phieun = new pdna();
                                {
                                    phieun.GSBH = macongty;
                                    phieun.pdno = maphieu;
                                    phieun.pddepid = bophan;
                                    phieun.mytitle = tieude;
                                    phieun.pdmemovn = noidung;
                                    phieun.CFMDate0 = DateTime.Today;
                                    phieun.USERID = user;
                                    phieun.Abtype = DropLoaiPhieu.SelectedValue.ToString();
                                    phieun.bixoa = false;
                                    phieun.CFMID0 = user;
                                    phieun.YN = 5;
                                    phieun.bixoa = false;
                                    phieun.USERDATE = DateTime.Today;
                                    phieun.UseIntent = txtMucDich.Text;

                                }
                                pdnaBUS.InsertPDNA(phieun);
                                Session["ktmaphieu"] = maphieu;
                                Session["maphieu"] = maphieu;
                            }
                            else
                            {
                                dal.CapNhatPhieuDeNghi(macongty, ktmaphieu, bophan, tieude, noidung, date, user, loaiphieu, user, txtMucDich.Text.Trim(), false, 5, date);
                                Session["ktmaphieu"] = ktmaphieu;
                                Session["maphieu"] = ktmaphieu;
                            }
                            string maphieu1 = Session["ktmaphieu"].ToString();
                            DataTable dtTim = dal.TimMaHangTrongPhieu(macongty, mahang, maphieu1);
                            if (themhang == null)
                            {
                                if (ktmaphieu == null)
                                {


                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }

                                    HienThiDanhSach();
                                }
                                else
                                {
                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        //dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                    }


                                    HienThiDanhSach();
                                }
                            }
                            else
                            {
                                if (ktmaphieu == null)
                                {



                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, maphieu1, sizecu);
                                        // dal.XoaCGNOTrongBangCGZLS(congty, CGNO, mahangcu);
                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            //  dal.CapNhatCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong), date, Yn);
                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            // dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                        }

                                        HienThiDanhSach();

                                    }
                                }
                                else
                                {

                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }

                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);

                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }

                                        HienThiDanhSach();

                                    }
                                    HienThiDanhSach();
                                    Session.Remove("themhang");
                                    Session.Remove("mahangcu");
                                    Session.Remove("sizecu");
                                }
                            }
                            btnLuuTam.Enabled = true;
                            btnTiepTu.Enabled = true;
                        }
                    }
                }// da ton tai ma phieu roi
                else
                {
                    string themhang = (string)Session["themhang"];

                    string bophan = DropDonVi.SelectedItem.Value.ToString();

                    string tieude = txtTieuDe.Text;
                    string noidung = CKEditorControl1.Text;
                    string bp = DropDonVi.SelectedItem.Text;
                    string loaiP = DropLoaiPhieu.SelectedItem.Text;
                    string macongty = Session["congty"].ToString();
                    string user = Session["user"].ToString();
                    string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd");
                    string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
                    string tenhang = txtAutoComplete.Text.Trim();
                    string donvitinh = txtdonvitinh.Text.ToUpper();
                    string soluong = txtSoLuong.Text.Trim();
                    string ghichu = txtGhiChu.Text.Trim();
                    string Size = "";

                    string mahang = "";
                    if (txtSize.Text.Trim() == "")
                    {
                        Size = "ZZZZZZ";
                    }
                    else
                    {
                        try
                        {
                            decimal sl = decimal.Parse(txtSize.Text.Trim());
                            Size = sl.ToString();
                        }
                        catch
                        {
                            Size = "ZZZZZZ";
                        }
                    }
                    if (txtMaHang.Text.Trim() == "")
                    {
                        string a = (string)Session["demmahang"];
                        if (a == null && demMH == 1)
                        {
                            mahang = "z" + demMH;
                            demMH++;
                            demmahang = demMH.ToString();
                            Session["demmahang"] = demmahang;
                        }
                        else
                        {
                            int so = int.Parse(a);
                            mahang = "z" + so;
                            so++;
                            demmahang = so.ToString();
                            Session["demmahang"] = demmahang;
                        }

                    }
                    else
                    {
                        mahang = txtMaHang.Text;

                    }
                    //string idphieu = Session["maphieu"].ToString();
                    string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();

                    dal.CapNhatPhieuDeNghi(macongty, ktmaphieu, bophan, tieude, noidung, date, user, loaiphieu, user,txtMucDich.Text.Trim(),false, 5, date);
                    string maphieu1 = Session["ktmaphieu"].ToString();
                            DataTable dtTim = dal.TimMaHangTrongPhieu(macongty, mahang, maphieu1);
                            if (themhang == null)
                            {
                                if (ktmaphieu == null)
                                {


                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }

                                    HienThiDanhSach();
                                }
                                else
                                {
                                    if (dtTim.Rows.Count > 0)
                                    {
                                        dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                    }
                                    else
                                    {
                                        dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        //dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                    }


                                    HienThiDanhSach();
                                }
                            }
                            else
                            {
                                if (ktmaphieu == null)
                                {



                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, maphieu1, sizecu);
                                        // dal.XoaCGNOTrongBangCGZLS(congty, CGNO, mahangcu);
                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            //  dal.CapNhatCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong), date, Yn);
                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, maphieu1, Size, decimal.Parse(soluong), tenhang, ghichu);
                                            // dal.ThemCGNOTrongBangCGZLS(congty, CGNO, mahang, user, decimal.Parse(soluong));
                                        }

                                        HienThiDanhSach();

                                    }
                                }
                                else
                                {

                                    if (mahangcu != null && mahangcu == mahang)
                                    {
                                        if (sizecu == Size)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }
                                        else
                                        {
                                            dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                                        }

                                    }
                                    else
                                    {
                                        dal.XoaHang(macongty, mahangcu, ktmaphieu, sizecu);

                                        if (dtTim.Rows.Count > 0)
                                        {
                                            dal.SuaHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }
                                        else
                                        {
                                            dal.ThemHang1(macongty, mahang, ktmaphieu, Size, decimal.Parse(soluong), tenhang, ghichu);

                                        }

                                        HienThiDanhSach();

                                    }
                                    HienThiDanhSach();
                                    Session.Remove("themhang");
                                    Session.Remove("mahangcu");
                                    Session.Remove("sizecu");
                                }
                            }
                    Session["bp"] = bophan;
                    Session["bophan"] = bp;
                    Session["loaiP"] = loaiP;
                    Session["loaiphieu"] = loaiphieu;
                    Session["maphieu"] = ktmaphieu;

                    Session["noidung"] = noidung;
                    Session["ngaytao"] = ngaythang;
                    Session["tieude"] = tieude;
                    btnLuuTam.Enabled = true;
                    btnTiepTu.Enabled = true;
                }
                // them vat tu

                
                txtAutoComplete.Text = "";
                txtMaHang.Text = "";
                txtSize.Text = "";
                txtdonvitinh.Text = "";
                txtAutoComplete.Enabled = true;
                txtdonvitinh.Enabled = true;
                txtMaHang.Enabled = false;
                txtSize.Enabled = true;
                
            
        }
        public void HienThiDanhSach()
        {
            dalPDN dal = new dalPDN();
            string maphieu = (string)Session["maphieu"];
            string macongty = (string)Session["congty"];
            if (maphieu != null && macongty != null)
            {
                GridView1.DataSource = dal.QryHangTheoMaHang(maphieu, macongty);
                GridView1.DataBind();
            }
        }
        protected void btnLuuTam_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            dalPDN dal = new dalPDN();
            string ngonngu = Session["languege"].ToString();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();
            int level = 0;
            string maphieu = "";
            if (dt.Rows.Count != 0 && aa!="")
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
            int ABC = 1;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string macongty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd");
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
                                phieun.CFMDate0 = DateTime.Today;
                                phieun.CFMID0 = user;
                                phieun.USERID = user;
                                phieun.YN = 5;
                                phieun.dagui = false;
                                phieun.bixoa = false;
                                phieun.LevelDoing = 0;
                            }
                            pdnaBUS.InsertPDNA(phieun);

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
                      
                        dal.ThemPhieuDeNghi(macongty, maphieu, mabophan, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);
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
                            dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);

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
                        dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);

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
            Session.Remove("ktmaphieu");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("ktmaphieu");
            DateTime date = DateTime.Today;
            dalPDN dal = new dalPDN();
            int level = 0;
            string ngonngu = Session["languege"].ToString();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();
            string maphieu = "";
            if (dt.Rows.Count != 0 && aa!="")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();
            int ABC = 1;
            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;
            string bp = DropDonVi.SelectedItem.Text;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string macongty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy/MM/dd");
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
                            dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;

                            Session["noidung"] = noidung;
                            Session["ngaytao"] = ngaythang;
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
                        dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;

                        Session["noidung"] = noidung;
                        Session["ngaytao"] = ngaythang;
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
                            dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);
                            Session["bp"] = bophan;
                            Session["bophan"] = bp;
                            Session["loaiP"] = loaiP;
                            Session["loaiphieu"] = loaiphieu;
                            Session["maphieu"] = maphieu;

                            Session["noidung"] = noidung;
                            Session["ngaytao"] = ngaythang;
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
                        dal.ThemPhieuDeNghi(macongty, maphieu, bd.ID, tieude, noidung, date, user, DropLoaiPhieu.SelectedValue, user, false, 5, date,level,ABC);
                        Session["bp"] = bophan;
                        Session["bophan"] = bp;
                        Session["loaiP"] = loaiP;
                        Session["loaiphieu"] = loaiphieu;
                        Session["maphieu"] = maphieu;

                        Session["noidung"] = noidung;
                        Session["ngaytao"] = ngaythang;
                        Session["tieude"] = tieude;
                        Response.Redirect("FrmViewCB.aspx");

                    }
                }

            }
            else
            {
                Response.Redirect("FrmViewCB.aspx");
            }
            Session.Remove("ktmaphieu");
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
                btnLuuTam.Enabled = true;
                btnTiepTu.Enabled = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string aa = txtMaHang.Text;
            string k = aa;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblMaCty1 = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGSBH");
            Label lbMaPhieu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblPDNO");
            Label lbMaHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLBH");
            Label lbTenHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblMemo0");
            Label lbSize = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblSize");
            Label lbDonVT = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblDWBH");
            Label lbGhiChu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLMemo");
            Label lbSoLuong = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblQty");
            
            Label lblZSBH = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblZSBH");
            txtAutoComplete.Text = lbTenHang.Text.Trim();
            txtdonvitinh.Text = lbDonVT.Text.Trim();
            txtMaHang.Text = lbMaHang.Text.Trim();
            txtSize.Text = lbSize.Text.Trim();
            txtSoLuong.Text = lbSoLuong.Text.Trim();
            txtGhiChu.Text = lbGhiChu.Text.Trim();
            //txtAutoComplete.Enabled = false;
            //txtMaHang.Enabled = false;
            //txtSize.Enabled = false;
            Session["congty"] = lblMaCty1.Text.Trim();
            
            Session["ZSBH"] = lblZSBH.Text.Trim();
            Session["maphieu"] = lbMaPhieu.Text.Trim();
            Session["themhang"] = "them";
            Session["mahangcu"] = lbMaHang.Text.Trim();
            Session["sizecu"] = lbSize.Text.Trim();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            Label lblMaCty = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGSBH");
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPDNO");
            Label lblMaHang = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCLBH");
            Label lblSize = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSize");
            dal.XoaHang(lblMaCty.Text.Trim(), lblMaHang.Text.Trim(), lblMaPhieu.Text.Trim(), lblSize.Text.Trim());
            HienThiDanhSach();
        }

        protected void btnChonNhaCC_Click(object sender, EventArgs e)
        {
            
                dalPDN dal = new dalPDN();
                DateTime date = DateTime.Today;
                int level = 0;
                string ngonngu = Session["languege"].ToString();
                string ktmaphieu = (string)Session["ktmaphieu"];
                string maloaiP = DropLoaiPhieu.SelectedValue.ToString().Trim();
                string maDV = DropDonVi.SelectedValue.ToString().Trim();
                string tieude = txtTieuDe.Text.Trim();
                int Yn = 5;
                if (ktmaphieu == null)
                {
                    DataTable dt = dal.DemSoLuongPhieu();
                    string aa = dt.Rows[0]["pdno"].ToString().Trim();
                    string maphieu = "";
                    if (dt.Rows.Count != 0 && aa!="")
                    {
                        string dem = (int.Parse(aa) + 1).ToString();
                        maphieu = dem;
                    }
                    else
                    {
                        maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
                    }
                    string bophan = DropDonVi.SelectedItem.Value.ToString();
                    string congty = Session["congty"].ToString();
                    string UserID = Session["UserID"].ToString();
                    int ABC = 1;
                    dal.ThemPhieuDeNghiTemp(congty, maphieu, UserID, date,level,txtMucDich.Text.Trim(),maloaiP,tieude,maDV,Yn,ABC);
                    Session["ktmaphieu"] = maphieu;
                    Session["maphieu"] = maphieu;
                       // dal.ThemCGNOTrongBangCGZL(congty, GSNO, txtMaNhaCC.Text.Trim(), UserID);
                       
                      
                        txtAutoComplete.Enabled = true;
                        txtdonvitinh.Enabled = true;
                        txtGhiChu.Enabled = true;
                        txtSize.Enabled = true;
                        txtSoLuong.Enabled = true;
                        Button1.Enabled = true;
                   
                }
            
        }
    }
}