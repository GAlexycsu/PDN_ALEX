using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Threading.Tasks;
using System.Linq.Expressions;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmTrinhDuyetCB : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();

        public static String MA_VB_CD = "VBCD";
        Busers2 nguoiduyet1 = new Busers2();
        string aa = "1";
        int dem = 0;
        
     
        List<QPDNFlow> lsquytrinh = new List<QPDNFlow>();
        List<QPDNFlow> lsQuytrinh1 = new List<QPDNFlow>();
      
        List<string> listnguoi = new List<string>();

       

        Dictionary<String, Abcon> ctxds = new Dictionary<String, Abcon>(); // Tạo mới ctxd
        // Dictionary<String, DetailsApproved> ctxds = new Dictionary<String, DetailsApproved>(); // Tạo mới ctxd
        //string a;
        //string cv;
        //string cv1;
        //string cv2;
        string ngonngudung;
        string strchucvu;
       
        List<string> nguoiduyettruoc = new List<string>();
        List<string> lstIdNguoiNhan = new List<string>();
        List<Busers2> dsduyet = new List<Busers2>();
        abconDAL dal = new abconDAL();
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
                LayngonNgu(3, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            
            if (!IsPostBack)
            {
                btnChiTiet.Enabled = false;
                btnChiTiet.Attributes.Add("opacity", "0.5");
                reloadTreeView();
                HienThiDoUuTien();
               
            }
            TreeView2.Enabled = false;
           
            
            // lstIdNguoiNhan = new List<string>();
         
        }
        private void HienThiDoUuTien()
        {
            string ngonngu = Session["languege"].ToString();
            DropUutien.DataSource = DoUuTienDAO.LayCapDoUuTien();
            DropUutien.DataValueField = "ABC";

            if (ngonngu == "lbl_VN")
            {
                DropUutien.DataTextField = "NameABC";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropUutien.DataTextField = "NameABCTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropUutien.DataTextField = "NameABC";
            }
            DropUutien.DataBind();
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnChiTiet.Text = hasLanguege["btnChiTiet"].ToString();
            btnTrinhDuyet.Text = hasLanguege["btnTrinhDuyet"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
        }

        #region huy
        //public void reloadTreeView()
        //{
        //    string maloai = Session["loaiphieu"].ToString();
        //    string mabophan = Session["bp"].ToString();
        //    string macongty = Session["congty"].ToString();
        //    string ngonngu = Session["languege"].ToString();
        //    // string idnguoiduyet = Session["idnguoiduyet"].ToString();
        //    if (ngonngu == "lbl_VN")
        //    {
        //        ngonngudung = "Danh sách người ký";
        //    }
        //    else if (ngonngu == "lbl_TW")
        //    {
        //        ngonngudung = "审核名单";
        //    }
        //    else if (ngonngu == "lbl_EN")
        //    {
        //        ngonngudung = "List Approval Users";
        //    }
        //    if (maloai == "PDN6" && mabophan == "VTY03")
        //    {
        //        string loaivanban = "PDN2";
        //        if (TreeView2.Nodes.Count == 0)
        //        {
        //            TreeNode parentNote = new TreeNode("List users browsing");
        //            parentNote.Text = "List users browsing";

        //        }


        //        TreeView2.Nodes.Clear();
        //        //lvb1 = ChiTietLoaiPhieuBUS.QryChiTietLoaiPhieu();

        //        lvb = ChiTietLoaiPhieuBUS.QryLoaiChiTietTheoMaLoaiPhieu(loaivanban);


        //        TreeNode parentNode = new TreeNode("");

        //        parentNode.Text = ngonngudung;
        //        TreeView2.Nodes.Add(parentNode);
        //        foreach (ChiTietLoaiPhieu loaivb in lvb)
        //        {

        //            ChucVu chucvu = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);

        //            TreeNode childNode = new TreeNode(loaivb.IDCT.ToString());
        //            childNode.Value = loaivb.IDCT.ToString();
        //            //childNode.Text = "Level" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);
        //            childNode.Text = "Chức vụ" + ":" + chucvu.TenChucVu;
        //            childNode.Target = loaivb.IDNguoiKy;
        //            parentNode.ChildNodes.Add(childNode);
        //            if (loaivb.DonViThongQua == null)
        //            {
        //                string madonvi = Session["bp"].ToString();
        //                //string macongty = "LTY";
        //                BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
        //                if (loaivb.IDLoaiNguoiKy == 2)
        //                {

        //                    Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);

        //                    TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                    tnChildNode.Text = nguoichuquan.USERNAME;
        //                    tnChildNode.Target = nguoichuquan.USERID;
        //                    tnChildNode.Value = aa;


        //                    if (a == null)
        //                    {
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                        a = tnChildNode.Target;
        //                    }
        //                    else
        //                    {
        //                        if (tnChildNode.Target == a)
        //                        {
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                            a = tnChildNode.Target;
        //                        }
        //                    }


        //                }
        //                if (loaivb.IDLoaiNguoiKy == 3)
        //                {
        //                    ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                    List<Buser> DanhSachNguoiDuyet = UserBUS.QryNguoiDuyetTheoMaChucVu(chuc.IDChucVu, macongty);
        //                    foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                    {
        //                        Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty, madonvi);
        //                        if (nguoiduyet1 == null)
        //                        {
        //                            Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, madonvi, macongty);
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                            tnChildNode.Text = nguoiduyet2.USERNAME;
        //                            tnChildNode.Target = nguoiduyet2.USERID;
        //                            tnChildNode.Value = aa;
        //                            if (cv2 == null)
        //                            {

        //                                nguoiduyettruoc.Add(nguoiduyet2.USERID);
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                cv2 = tnChildNode.Target;
        //                            }
        //                            else
        //                            {

        //                                if (tnChildNode.Target == cv2)
        //                                {
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    nguoiduyettruoc.Add(nguoiduyet2.USERID);
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    cv2 = tnChildNode.Target;
        //                                }

        //                            }


        //                        }
        //                        else
        //                        {
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                            tnChildNode.Text = nguoiduyet1.USERNAME;
        //                            tnChildNode.Target = nguoiduyet1.USERID;
        //                            tnChildNode.Value = aa;

        //                            lstIdNguoiNhan.Add(nguoiduyet1.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 4)
        //                {
        //                    Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                    tnChildNode.Target = nguoiduyet.USERID;
        //                    tnChildNode.Value = aa;

        //                    lstIdNguoiNhan.Add(nguoiduyet.USERID);
        //                    childNode.ChildNodes.Add(tnChildNode);
        //                }
        //            }
        //            else
        //            {
        //                // string macongty = "LTY";
        //                //string madonvi = "VTYL02";

        //                BDepartment bophan = BDepartmentBUS.TimMaDonVi(loaivb.DonViThongQua, macongty);
        //                if (loaivb.IDLoaiNguoiKy == 2)
        //                {
        //                    Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                    tnChildNode.Text = nguoichuquan.USERNAME;
        //                    tnChildNode.Target = nguoichuquan.USERID;
        //                    tnChildNode.Value = aa;
        //                    if (cv1 == null)
        //                    {
        //                        lstIdNguoiNhan.Add(nguoichuquan.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                        cv1 = tnChildNode.Target;
        //                    }
        //                    else
        //                    {
        //                        if (childNode.Target == cv1)
        //                        {
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            lstIdNguoiNhan.Add(nguoichuquan.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 3)
        //                {
        //                    ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                    List<Buser> DanhSachNguoiDuyet = UserBUS.QryNguoiDuyetTheoMaChucVu(chuc.IDChucVu, macongty);
        //                    foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                    {
        //                        Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty, bophan.ID);
        //                        if (nguoiduyet1 == null)
        //                        {
        //                            Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, loaivb.DonViThongQua, macongty);
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                            tnChildNode.Text = nguoiduyet2.USERNAME;
        //                            tnChildNode.Target = nguoiduyet2.USERID;
        //                            tnChildNode.Value = aa;
        //                            if (cv == null)
        //                            {
        //                                lstIdNguoiNhan.Add(nguoiduyet2.USERID);
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                cv = tnChildNode.Target;
        //                            }
        //                            else
        //                            {
        //                                if (tnChildNode.Target == cv)
        //                                {
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    lstIdNguoiNhan.Add(nguoiduyet2.USERID);
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                }
        //                            }

        //                        }
        //                        else
        //                        {
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                            tnChildNode.Text = nguoiduyet1.USERNAME;
        //                            tnChildNode.Target = nguoiduyet1.USERID;
        //                            tnChildNode.Value = aa;

        //                            lstIdNguoiNhan.Add(nguoiduyet1.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 4)
        //                {
        //                    Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                    tnChildNode.Target = nguoiduyet.USERID;
        //                    tnChildNode.Value = aa;

        //                    lstIdNguoiNhan.Add(nguoiduyet.USERID);
        //                    childNode.ChildNodes.Add(tnChildNode);
        //                }
        //            }

        //        }
        //        TreeView2.ExpandAll();
        //    }
        //    else
        //    {
        //        if (TreeView2.Nodes.Count == 0)
        //        {
        //            TreeNode parentNote = new TreeNode("List users browsing");
        //            parentNote.Text = "List users browsing";

        //        }


        //        TreeView2.Nodes.Clear();
        //        //lvb1 = ChiTietLoaiPhieuBUS.QryChiTietLoaiPhieu();

        //        lvb = ChiTietLoaiPhieuBUS.QryLoaiChiTietTheoMaLoaiPhieu(maloai);


        //        TreeNode parentNode = new TreeNode("");
        //        parentNode.Text = ngonngudung;
        //        TreeView2.Nodes.Add(parentNode);
        //        foreach (ChiTietLoaiPhieu loaivb in lvb)
        //        {

        //            ChucVu chucvu = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);

        //            TreeNode childNode = new TreeNode(loaivb.IDCT.ToString());
        //            childNode.Value = loaivb.IDCT.ToString();
        //            //childNode.Text = "Level" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);
        //            childNode.Text = "Chức vụ" + ":" + chucvu.TenChucVu;
        //            childNode.Target = loaivb.IDNguoiKy;
        //            parentNode.ChildNodes.Add(childNode);
        //            if (loaivb.DonViThongQua == null)
        //            {
        //                string madonvi = Session["bp"].ToString();
        //                //string macongty = "LTY";
        //                BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
        //                if (loaivb.IDLoaiNguoiKy == 2)
        //                {

        //                    Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);
        //                    Session["nguoiquanlychuquan"] = nguoichuquan.IdUserQuanLyTT;
        //                    TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                    tnChildNode.Text = nguoichuquan.USERNAME;
        //                    tnChildNode.Target = nguoichuquan.USERID;
        //                    tnChildNode.Value = aa;


        //                    if (a == null)
        //                    {
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                        a = tnChildNode.Target;
        //                    }
        //                    else
        //                    {
        //                        if (tnChildNode.Target == a)
        //                        {
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                            a = tnChildNode.Target;
        //                        }
        //                    }


        //                }
        //                if (loaivb.IDLoaiNguoiKy == 3)
        //                {
        //                    ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                    List<Buser> DanhSachNguoiDuyet = UserBUS.QryNguoiDuyetTheoMaChucVu(chuc.IDChucVu, macongty);
        //                    foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                    {

        //                        Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty, madonvi);
        //                        if (nguoiduyet1 == null)
        //                        {
        //                            Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, madonvi, macongty);
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                            tnChildNode.Text = nguoiduyet2.USERNAME;
        //                            tnChildNode.Target = nguoiduyet2.USERID;
        //                            tnChildNode.Value = aa;
        //                            if (cv2 == null)
        //                            {

        //                                nguoiduyettruoc.Add(nguoiduyet2.USERID);
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                cv2 = tnChildNode.Target;
        //                            }
        //                            else
        //                            {

        //                                if (tnChildNode.Target == cv2)
        //                                {
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    nguoiduyettruoc.Add(nguoiduyet2.USERID);
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    cv2 = tnChildNode.Target;
        //                                }

        //                            }


        //                        }
        //                        else
        //                        {
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                            tnChildNode.Text = nguoiduyet1.USERNAME;
        //                            tnChildNode.Target = nguoiduyet1.USERID;
        //                            tnChildNode.Value = aa;

        //                            lstIdNguoiNhan.Add(nguoiduyet1.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 4)
        //                {
        //                    Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                    tnChildNode.Target = nguoiduyet.USERID;
        //                    tnChildNode.Value = aa;

        //                    lstIdNguoiNhan.Add(nguoiduyet.USERID);
        //                    childNode.ChildNodes.Add(tnChildNode);
        //                }
        //            }
        //            else
        //            {
        //                // string macongty = "LTY";
        //                //string madonvi = "VTYL02";

        //                BDepartment bophan = BDepartmentBUS.TimMaDonVi(loaivb.DonViThongQua, macongty);
        //                if (loaivb.IDLoaiNguoiKy == 2)
        //                {
        //                    Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                    tnChildNode.Text = nguoichuquan.USERNAME;
        //                    tnChildNode.Target = nguoichuquan.USERID;
        //                    tnChildNode.Value = aa;
        //                    if (cv1 == null)
        //                    {
        //                        lstIdNguoiNhan.Add(nguoichuquan.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                        cv1 = tnChildNode.Target;
        //                    }
        //                    else
        //                    {
        //                        if (childNode.Target == cv1)
        //                        {
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            lstIdNguoiNhan.Add(nguoichuquan.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 3)
        //                {
        //                    ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                    List<Buser> DanhSachNguoiDuyet = UserBUS.QryNguoiDuyetTheoMaChucVu(chuc.IDChucVu, macongty);
        //                    foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                    {
        //                        Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty, bophan.ID);
        //                        if (nguoiduyet1 == null)
        //                        {
        //                            Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, loaivb.DonViThongQua, macongty);
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                            tnChildNode.Text = nguoiduyet2.USERNAME;
        //                            tnChildNode.Target = nguoiduyet2.USERID;
        //                            tnChildNode.Value = aa;
        //                            if (cv == null)
        //                            {
        //                                lstIdNguoiNhan.Add(nguoiduyet2.USERID);
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                cv = tnChildNode.Target;
        //                            }
        //                            else
        //                            {
        //                                if (tnChildNode.Target == cv)
        //                                {
        //                                    break;
        //                                }
        //                                else
        //                                {
        //                                    lstIdNguoiNhan.Add(nguoiduyet2.USERID);
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                }
        //                            }

        //                        }
        //                        else
        //                        {
        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                            tnChildNode.Text = nguoiduyet1.USERNAME;
        //                            tnChildNode.Target = nguoiduyet1.USERID;
        //                            tnChildNode.Value = aa;

        //                            lstIdNguoiNhan.Add(nguoiduyet1.USERID);
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                        }
        //                    }
        //                }
        //                if (loaivb.IDLoaiNguoiKy == 4)
        //                {
        //                    Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                    tnChildNode.Target = nguoiduyet.USERID;
        //                    tnChildNode.Value = aa;

        //                    lstIdNguoiNhan.Add(nguoiduyet.USERID);
        //                    childNode.ChildNodes.Add(tnChildNode);
        //                }
        //            }

        //        }
        //        TreeView2.ExpandAll();
        //    }




        //}
        #endregion
        #region Huy 2
        //public void reloadTreeView()
        //{
        //    string maloai = Session["loaiphieu"].ToString();
        //    string maloaiphieu = "PDN1";
        //    string mabophan = Session["bp"].ToString();
        //    string macongty = Session["congty"].ToString();
        //    string ngonngu = Session["languege"].ToString();
        //    string manguoidung = Session["user"].ToString();
        //    Busers2 nguoitaoP=UserDAO.TimNhanVienTheoMa(manguoidung,macongty);
        //    // string idnguoiduyet = Session["idnguoiduyet"].ToString();
        //    if (ngonngu == "lbl_VN")
        //    {
        //        ngonngudung = "Danh sách người ký";
        //        strchucvu = "Chức vụ";
        //    }
        //    else if (ngonngu == "lbl_TW")
        //    {
        //        ngonngudung = "审核名单";
        //        strchucvu = "职务";
        //    }
        //    else if (ngonngu == "lbl_EN")
        //    {
        //        ngonngudung = "List Approval Users";
        //        strchucvu = "Chức vụ";
        //    }

        //    if (TreeView2.Nodes.Count == 0)
        //    {
        //        TreeNode parentNote = new TreeNode("List users browsing");
        //        parentNote.Text = "List users browsing";

        //    }


        //    TreeView2.Nodes.Clear();

        //    TreeNode parentNode = new TreeNode("");

        //    parentNode.Text = ngonngudung;
        //    TreeView2.Nodes.Add(parentNode);
        //    Busers2 nguoitaophieu = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //    if (nguoitaophieu.IDCapDuyet >= 12)
        //    {
        //        string mabophancc="CBCC";
        //        listquytrinh2 = QPDNFlowCuaCanBoCaoCapDAO.QryQPDNFlowCuaCanBoCaoCap(macongty, mabophancc);
        //        if (listquytrinh2.Count() == 0)
        //        {

        //        }
        //        else
        //        {

        //            foreach (QPDNFlowCanBoCaoCap quytrinh in listquytrinh2)
        //            {
        //                if (quytrinh.abtype == "PDN1" && quytrinh.DonViThongQua == null || quytrinh.DonViThongQua.Trim() == "")
        //                {
        //                    if (quytrinh.IDCapDuyet > nguoitaophieu.IDCapDuyet)
        //                    {
        //                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nguoitaophieu.IdUserQuanLyTT, macongty);
        //                        if (manguoiky == null)
        //                        {
        //                            DateTime ngay = DateTime.Today;

        //                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.IdUserQuanLyTT, macongty);
        //                            if (nghi != null && nguoiduyet.IdUserQuanLyTT == nghi.IDNguoiDuyet && nguoitaophieu.USERID != nguoiduyet.USERID)
        //                            {
        //                                if (nghi.ThongQua == 1)
        //                                {
        //                                    Busers2 nguoiduyetqt = UserBUS.TimNhanVienTheoMa(nguoitaophieu.IdUserQuanLyTT, macongty);
        //                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyetqt.IDChucVu, macongty);

        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyetqt.USERNAME);
        //                                    tnChildNode.Text = nguoiduyetqt.USERNAME;
        //                                    tnChildNode.Target = nguoiduyetqt.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyetqt.USERID);
        //                                    nguoitieptheo = nguoiduyetqt.USERID;
        //                                    manguoiky = nguoiduyetqt.USERID;

        //                                }
        //                                else
        //                                {
        //                                    if (nghi.ThongQua == 2)
        //                                    {
        //                                        Busers2 nguoiduyetdcuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = nguoiduyet.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyetdcuyquyen.USERNAME);
        //                                        tnChildNode.Text = nguoiduyetdcuyquyen.USERNAME;
        //                                        tnChildNode.Target = nguoiduyetdcuyquyen.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyetdcuyquyen.USERID);
        //                                        nguoitieptheo = nguoiduyetdcuyquyen.USERID;
        //                                        manguoiky = nguoiduyetdcuyquyen.USERID;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 3)
        //                                        {

        //                                        }
        //                                    }
        //                                }

        //                            }// khong nghi phep
        //                            else
        //                            {
        //                                Busers2 nguoiduyetcodinh = UserBUS.TimNhanVienTheoMa(nguoitaophieu.IdUserQuanLyTT, macongty);
        //                                ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyetcodinh.IDChucVu, macongty);
        //                                if (nguoitaophieu.IDCapDuyet <= nguoiduyet.IDCapDuyet && nguoitaophieu.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                                {
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyetcodinh.USERNAME);
        //                                    tnChildNode.Text = nguoiduyetcodinh.USERNAME;
        //                                    tnChildNode.Target = nguoiduyetcodinh.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyetcodinh.USERID);
        //                                    nguoitieptheo = nguoiduyetcodinh.USERID;
        //                                    manguoiky = nguoiduyetcodinh.USERID;
        //                                }
        //                                else
        //                                { }
        //                            }
        //                        }// da co nguoi ky trong danh sach
        //                        else
        //                        {
        //                            Busers2 nguoiduyethientai = UserBUS.TimNhanVienTheoMa(manguoiky, macongty);
        //                            if (nguoiduyethientai.IDCapDuyet < 17)
        //                            {
        //                                Busers2 nguoiduyettieptheo = UserBUS.TimNhanVienTheoMa(nguoiduyethientai.IdUserQuanLyTT, macongty);
        //                                DateTime ngay = DateTime.Today;

        //                                ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyethientai.IdUserQuanLyTT, macongty);
        //                                if (nghi != null && nguoiduyettieptheo.IdUserQuanLyTT == nghi.IDNguoiDuyet && nguoiduyethientai.USERID != nguoiduyettieptheo.USERID)
        //                                {
        //                                    if (nghi.ThongQua == 1)
        //                                    {

        //                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyettieptheo.IDChucVu, macongty);

        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = quytrinh.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyettieptheo.USERNAME);
        //                                        tnChildNode.Text = nguoiduyettieptheo.USERNAME;
        //                                        tnChildNode.Target = nguoiduyettieptheo.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyettieptheo.USERID);
        //                                        nguoitieptheo = nguoiduyettieptheo.USERID;
        //                                        manguoiky = nguoiduyettieptheo.USERID;

        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 2)
        //                                        {
        //                                            Busers2 nguoiduyetdcuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                            ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                            childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                            if (ngonngu == "lbl_VN")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                            }
        //                                            else if (ngonngu == "lbl_TW")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                            }
        //                                            childNode.Target = nguoiduyet.IDChucVu;

        //                                            parentNode.ChildNodes.Add(childNode);



        //                                            TreeNode tnChildNode = new TreeNode("" + nguoiduyetdcuyquyen.USERNAME);
        //                                            tnChildNode.Text = nguoiduyetdcuyquyen.USERNAME;
        //                                            tnChildNode.Target = nguoiduyetdcuyquyen.USERID;
        //                                            tnChildNode.Value = aa;
        //                                            tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                            childNode.ChildNodes.Add(tnChildNode);
        //                                            listnguoi.Add(nguoiduyetdcuyquyen.USERID);
        //                                            nguoitieptheo = nguoiduyetdcuyquyen.USERID;
        //                                            manguoiky = nguoiduyetdcuyquyen.USERID;
        //                                        }
        //                                        else
        //                                        {
        //                                            if (nghi.ThongQua == 3)
        //                                            {

        //                                            }
        //                                        }
        //                                    }
        //                                }// khong nghi phep
        //                                else
        //                                {

        //                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyettieptheo.IDChucVu, macongty);

        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyettieptheo.USERNAME);
        //                                    tnChildNode.Text = nguoiduyettieptheo.USERNAME;
        //                                    tnChildNode.Target = nguoiduyettieptheo.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyettieptheo.USERID);
        //                                    nguoitieptheo = nguoiduyettieptheo.USERID;
        //                                    manguoiky = nguoiduyettieptheo.USERID;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                #region bo cai nay
        //                                //if (nguoiduyethientai.IDCapDuyet == 17)
        //                                //{
        //                                //    DateTime ngay = DateTime.Today;

        //                                //    ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyethientai.IdUserQuanLyTT, macongty);
        //                                //    if (nghi != null && nguoiduyethientai.IdUserQuanLyTT == nghi.IDNguoiDuyet )
        //                                //    {
        //                                //        if (nghi.ThongQua == 1)
        //                                //        {

        //                                //            ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyethientai.IDChucVu, macongty);

        //                                //            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                //            childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                //            if (ngonngu == "lbl_VN")
        //                                //            {
        //                                //                childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                //            }
        //                                //            else if (ngonngu == "lbl_TW")
        //                                //            {
        //                                //                childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                //            }
        //                                //            childNode.Target = quytrinh.IDChucVu;

        //                                //            parentNode.ChildNodes.Add(childNode);



        //                                //            TreeNode tnChildNode = new TreeNode("" + nguoiduyethientai.USERNAME);
        //                                //            tnChildNode.Text = nguoiduyethientai.USERNAME;
        //                                //            tnChildNode.Target = nguoiduyethientai.USERID;
        //                                //            tnChildNode.Value = aa;
        //                                //            tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                //            childNode.ChildNodes.Add(tnChildNode);
        //                                //            listnguoi.Add(nguoiduyethientai.USERID);
        //                                //            nguoitieptheo = nguoiduyethientai.USERID;
        //                                //            manguoiky = nguoiduyethientai.USERID;

        //                                //        }
        //                                //        else
        //                                //        {
        //                                //            if (nghi.ThongQua == 2)
        //                                //            {
        //                                //                Busers2 nguoiduyetdcuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                //                ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                //                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                //                childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                //                if (ngonngu == "lbl_VN")
        //                                //                {
        //                                //                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                //                }
        //                                //                else if (ngonngu == "lbl_TW")
        //                                //                {
        //                                //                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                //                }
        //                                //                childNode.Target = nguoiduyet.IDChucVu;

        //                                //                parentNode.ChildNodes.Add(childNode);



        //                                //                TreeNode tnChildNode = new TreeNode("" + nguoiduyetdcuyquyen.USERNAME);
        //                                //                tnChildNode.Text = nguoiduyetdcuyquyen.USERNAME;
        //                                //                tnChildNode.Target = nguoiduyetdcuyquyen.USERID;
        //                                //                tnChildNode.Value = aa;
        //                                //                tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                //                childNode.ChildNodes.Add(tnChildNode);
        //                                //                listnguoi.Add(nguoiduyetdcuyquyen.USERID);
        //                                //                nguoitieptheo = nguoiduyetdcuyquyen.USERID;
        //                                //                manguoiky = nguoiduyetdcuyquyen.USERID;
        //                                //            }
        //                                //            else
        //                                //            {
        //                                //                if (nghi.ThongQua == 3)
        //                                //                {

        //                                //                }
        //                                //            }
        //                                //        }
        //                                //    }// khong nghi phep
        //                                //    else
        //                                //    {

        //                                //        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyethientai.IDChucVu, macongty);

        //                                //        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                //        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                //        if (ngonngu == "lbl_VN")
        //                                //        {
        //                                //            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                //        }
        //                                //        else if (ngonngu == "lbl_TW")
        //                                //        {
        //                                //            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                //        }
        //                                //        childNode.Target = quytrinh.IDChucVu;

        //                                //        parentNode.ChildNodes.Add(childNode);



        //                                //        TreeNode tnChildNode = new TreeNode("" + nguoiduyethientai.USERNAME);
        //                                //        tnChildNode.Text = nguoiduyethientai.USERNAME;
        //                                //        tnChildNode.Target = nguoiduyethientai.USERID;
        //                                //        tnChildNode.Value = aa;
        //                                //        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                //        childNode.ChildNodes.Add(tnChildNode);
        //                                //        listnguoi.Add(nguoiduyethientai.USERID);
        //                                //        nguoitieptheo = nguoiduyethientai.USERID;
        //                                //        manguoiky = nguoiduyethientai.USERID;
        //                                //    }
        //                                //}
        //                                #endregion
        //                            }
        //                        }
        //                    }
        //                    else
        //                    { 
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        BDepartment bophantao = BDepartmentDAO.TimMaDonVi(mabophan, macongty);
        //        if (bophantao.ID == "IT011")
        //        {
        //            string iddonvi = "VTY03";
        //            lsquytrinh = QPDNFlowCuaCanBoDAO.QryQuyTrinhTheoDonViLoaiPhieu(iddonvi, macongty, maloai, int.Parse(bophantao.DepartmentTypeID.ToString()));
        //        }
        //        else
        //        {
        //            lsquytrinh = QPDNFlowCuaCanBoDAO.QryQuyTrinhTheoDonViLoaiPhieu(mabophan, macongty, maloai, int.Parse(bophantao.DepartmentTypeID.ToString()));
        //        }

        //        if (lsquytrinh.Count() == 0)// Kiem tra co theo phieu rieng khong
        //        {
        //            if (bophantao.ID == "IT011")
        //            {
        //                string iddonvi = "VTY03";
        //                lsQuytrinh1 = QPDNFlowCuaCanBoDAO.QryQuyTrinhTheoDonVi(iddonvi, macongty, maloaiphieu, int.Parse(bophantao.DepartmentTypeID.ToString()));
        //            }
        //            else
        //            {
        //                lsQuytrinh1 = QPDNFlowCuaCanBoDAO.QryQuyTrinhTheoDonVi(mabophan, macongty, maloaiphieu, int.Parse(bophantao.DepartmentTypeID.ToString()));
        //            }
        //            //lsQuytrinh1=db.QryQuyTrinhTheoDonVi(mabophan,macongty,maloai)
        //            foreach (QPDNFlowCuaCanBo quytrinh in lsQuytrinh1)
        //            {
        //                if (quytrinh.NguoiDuyet != "PDN1") // trong truong hop nhap vao la nguoi duyet tuong minh 
        //                {
        //                    ChucVu chucvu = ChucVuBUS.TimMaChucVu(quytrinh.IDChucVu, macongty);
        //                    // Buser nguoitrinhky = UserBUS.TimNhanVienTheoMa(Until.uNhanVien.USERID, macongty);
        //                    //Buser nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                    Busers2 nguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //                    DateTime ngay = DateTime.Today;

        //                    ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, quytrinh.NguoiDuyet, macongty);

        //                    if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
        //                    {

        //                        if (nghi.ThongQua == 1)
        //                        {
        //                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);

        //                            if (nguoitao.IDCapDuyet <= nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                            {
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                                nguoitieptheo = nguoiduyet.USERID;
        //                            }
        //                            else
        //                            { }
        //                        }
        //                        else
        //                        {
        //                            if (nghi.ThongQua == 2)
        //                            {
        //                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = nguoiduyet.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                                nguoitieptheo = nguoiduyet.USERID;
        //                            }
        //                            else
        //                            {
        //                                if (nghi.ThongQua == 3)
        //                                {

        //                                }
        //                            }
        //                        }

        //                    }// khong nghi phep
        //                    else
        //                    {
        //                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                        if (nguoitieptheo == null)
        //                        {
        //                            if (nguoitao.IDCapDuyet <= nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                            {
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                                nguoitieptheo = nguoiduyet.USERID;
        //                            }
        //                            else
        //                            { }
        //                        }
        //                        else
        //                        {
        //                            if (nguoitao.IDCapDuyet <= nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                            {
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                                nguoitieptheo = nguoiduyet.USERID;
        //                            }
        //                            else
        //                            { }
        //                        }
        //                    }
        //                }// khi ko co nguoi duyet ro rang ma chi biet chuc vu thi tim nguoi duyet khi biet chuc vu
        //                else
        //                {
        //                    ChucVu chuc = ChucVuBUS.TimMaChucVu(quytrinh.IDChucVu, macongty);
        //                    Busers2 nguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //                    if (nguoitao.IDChucVu == chuc.IDChucVu)
        //                    {

        //                    }
        //                    else
        //                    {

        //                        //List<Buser> DanhSachNguoiDuyet = UserDAO.QryNguoiDuyetTheoMaChucVu(chuc.IDChucVu, macongty);
        //                        //if (DanhSachNguoiDuyet.Count() !=0)
        //                        //{
        //                        //    foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                        //    {
        //                        //        if (nguoitieptheo == null)
        //                        //        {
        //                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nguoitao.IdUserQuanLyTT, macongty);
        //                        ChucVu chucvunguoiduyet = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                        if (nguoitao.IDCapDuyet < nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                        {
        //                            DateTime ngay = DateTime.Today;

        //                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.USERID, macongty);
        //                            if (nghi != null && nguoiduyet.USERID == nghi.IDNguoiDuyet)
        //                            {
        //                                if (nghi.ThongQua == 1)
        //                                {
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = chucvunguoiduyet.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                    nguoitieptheo = nguoiduyet.USERID;
        //                                }
        //                                else
        //                                {
        //                                    if (nghi.ThongQua == 2)
        //                                    {
        //                                        Busers2 nguoiduocuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduocuyquyen.IDChucVu, macongty);
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = chucvu1.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduocuyquyen.USERNAME);
        //                                        tnChildNode.Text = nguoiduocuyquyen.USERNAME;
        //                                        tnChildNode.Target = nguoiduocuyquyen.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvunguoiduyet.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduocuyquyen.USERID);
        //                                        nguoitieptheo = nguoiduyet.USERID;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 3)
        //                                        {
        //                                        }
        //                                    }
        //                                }
        //                            }// nguoc lai khong nghi phep
        //                            else
        //                            {
        //                                if (nguoitieptheo == null)
        //                                {
        //                                    if (nguoitao.IDCapDuyet < nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                                    {
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = chucvunguoiduyet.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                        tnChildNode.Text = nguoiduyet.USERNAME;
        //                                        tnChildNode.Target = nguoiduyet.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvunguoiduyet.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyet.USERID);
        //                                        nguoitieptheo = nguoiduyet.USERID;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    ///
        //                                    if (nguoitao.IDCapDuyet < nguoiduyet.IDCapDuyet && nguoitao.USERID != nguoiduyet.USERID && nguoiduyet.USERID != nguoitieptheo)
        //                                    {
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvunguoiduyet.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = chucvunguoiduyet.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                        tnChildNode.Text = nguoiduyet.USERNAME;
        //                                        tnChildNode.Target = nguoiduyet.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvunguoiduyet.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyet.USERID);
        //                                        nguoitieptheo = nguoiduyet.USERID;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {

        //                        }
        //                        #region abc
        //                        //}
        //                        //else
        //                        //{
        //                        //    Buser nguoiduyet = UserBUS.TimNhanVienTheoMa(nguoitieptheo, macongty);

        //                        //    DateTime ngay = DateTime.Today;

        //                        //    ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.USERID, macongty);
        //                        //    if (nghi != null)
        //                        //    {
        //                        //        if (nghi.ThongQua == 1)
        //                        //        {
        //                        //            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                        //            childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                        //            childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                        //            childNode.Target = quytrinh.IDChucVu;

        //                        //            parentNode.ChildNodes.Add(childNode);



        //                        //            TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                        //            tnChildNode.Text = nguoiduyet.USERNAME;
        //                        //            tnChildNode.Target = nguoiduyet.USERID;
        //                        //            tnChildNode.Value = aa;
        //                        //            tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                        //            childNode.ChildNodes.Add(tnChildNode);
        //                        //            listnguoi.Add(nguoiduyet.USERID);
        //                        //            nguoitieptheo = nguoiduyet.USERID;
        //                        //        }
        //                        //        else
        //                        //        {
        //                        //            if (nghi.ThongQua == 2)
        //                        //            {
        //                        //                Buser nguoiduocuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                        //                ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduocuyquyen.IDChucVu, macongty);
        //                        //                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                        //                childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                        //                childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                        //                childNode.Target = chucvu1.IDChucVu;

        //                        //                parentNode.ChildNodes.Add(childNode);



        //                        //                TreeNode tnChildNode = new TreeNode("" + nguoiduocuyquyen.USERNAME);
        //                        //                tnChildNode.Text = nguoiduocuyquyen.USERNAME;
        //                        //                tnChildNode.Target = nguoiduocuyquyen.USERID;
        //                        //                tnChildNode.Value = aa;
        //                        //                tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                        //                childNode.ChildNodes.Add(tnChildNode);
        //                        //                listnguoi.Add(nguoiduocuyquyen.USERID);
        //                        //                nguoitieptheo = nguoiduyet.USERID;
        //                        //            }
        //                        //            else
        //                        //            {
        //                        //                if (nghi.ThongQua == 3)
        //                        //                {
        //                        //                }
        //                        //            }
        //                        //        }
        //                        //    }// nguoc lai khong nghi phep
        //                        //    else
        //                        //    {
        //                        //        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                        //        childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                        //        childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                        //        childNode.Target = quytrinh.IDChucVu;

        //                        //        parentNode.ChildNodes.Add(childNode);



        //                        //        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                        //        tnChildNode.Text = nguoiduyet.USERNAME;
        //                        //        tnChildNode.Target = nguoiduyet.USERID;
        //                        //        tnChildNode.Value = aa;
        //                        //        tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
        //                        //        childNode.ChildNodes.Add(tnChildNode);
        //                        //        listnguoi.Add(nguoiduyet.USERID);
        //                        //        nguoitieptheo = nguoiduyet.USERID;
        //                        //    }
        //                        // }
        //                        #endregion
        //                        //  }

        //                        // }// co 2 nguoi cung chuc vu tro len


        //                    }

        //                }

        //            }
        //            TreeView2.ExpandAll();
        //        } // nguoc lai theo phieu rieng
        //        else
        //        {
        //            foreach (QPDNFlowCuaCanBo quytrinh in lsquytrinh)
        //            {
        //                //ChucVu chucvu = ChucVuBUS.TimMaChucVu(quytrinh.IDChucVu, macongty);
        //                if (quytrinh.NguoiDuyet != "MD" && quytrinh.NguoiDuyet!=nguoitaoP.USERID) // trong truong hop nhap vao la nguoi duyet tuong minh 
        //                {
        //                    if (listnguoi.Count() == 0)// dem so nguoi trong danh sach duyet de kiem tra co bi trung nhau khong
        //                    {
        //                        ChucVu chucvu = ChucVuBUS.TimMaChucVu(quytrinh.IDChucVu, macongty);
        //                        // Buser nguoitrinhky = UserBUS.TimNhanVienTheoMa(Until.uNhanVien.USERID, macongty);
        //                        //Buser nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                        DateTime ngay = DateTime.Today;

        //                        ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, quytrinh.NguoiDuyet, macongty);

        //                        if (nghi != null)// kiem tra co nghi phep khong
        //                        {

        //                            if (nghi.ThongQua == 1)
        //                            {
        //                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                            }
        //                            else
        //                            {
        //                                if (nghi.ThongQua == 2)
        //                                {
        //                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = nguoiduyet.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                }
        //                                else
        //                                {
        //                                    if (nghi.ThongQua == 3)
        //                                    {

        //                                    }
        //                                }
        //                            }

        //                        }// khong nghi phep
        //                        else
        //                        {
        //                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                            childNode.Value = quytrinh.IDQuyTrinh.ToString();

        //                            if (ngonngu == "lbl_VN")
        //                            {
        //                                childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
        //                            }
        //                            else if (ngonngu == "lbl_TW")
        //                            {
        //                                childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
        //                            }
        //                            childNode.Target = quytrinh.IDChucVu;

        //                            parentNode.ChildNodes.Add(childNode);



        //                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                            tnChildNode.Text = nguoiduyet.USERNAME;
        //                            tnChildNode.Target = nguoiduyet.USERID;
        //                            tnChildNode.Value = aa;
        //                            tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
        //                            childNode.ChildNodes.Add(tnChildNode);
        //                            listnguoi.Add(nguoiduyet.USERID);
        //                        }
        //                    }// danh sach nguoi duyet >1
        //                    else
        //                    {
        //                        DateTime ngay = DateTime.Today;

        //                        ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, quytrinh.NguoiDuyet, macongty);
        //                        if (nghi != null)
        //                        {

        //                            foreach (string nguoi in listnguoi)
        //                            {
        //                                if (quytrinh.NguoiDuyet == nguoi)
        //                                {
        //                                    manguoiduyet = nguoi;
        //                                    // break;
        //                                }
        //                                else
        //                                {

        //                                }
        //                            }
        //                            if (manguoiduyet == null)
        //                            {
        //                                if (nghi.ThongQua == 1)
        //                                {
        //                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                }
        //                                else
        //                                {
        //                                    if (nghi.ThongQua == 2)
        //                                    {
        //                                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = nguoiduyet.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                        tnChildNode.Text = nguoiduyet.USERNAME;
        //                                        tnChildNode.Target = nguoiduyet.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyet.USERID);
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 3)
        //                                        {

        //                                        }
        //                                    }
        //                                }

        //                            }

        //                        }// khong nghi phep
        //                        else
        //                        {
        //                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
        //                            ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
        //                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                            childNode.Value = quytrinh.IDQuyTrinh.ToString();
        //                            foreach (string nguoi in listnguoi)
        //                            {
        //                                if (quytrinh.NguoiDuyet == nguoi)
        //                                {
        //                                    manguoiduyet = nguoi;
        //                                    break;

        //                                }
        //                                else
        //                                {
        //                                    manguoiduyet = null;
        //                                }

        //                            }
        //                            if (manguoiduyet == null)
        //                            {

        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                            }
        //                        }

        //                    }
        //                }// trong truong hop chi nhap chuc vu 
        //                else
        //                {
        //                    Busers2 nguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //                    if (nguoitao.IDCapDuyet == quytrinh.IDCapDuyet && nguoitao.isSep == true && quytrinh.DonViThongQua == null || quytrinh.DonViThongQua == " ")
        //                    {

        //                    }
        //                    else
        //                    {
        //                        if (quytrinh.DonViThongQua != null || quytrinh.DonViThongQua != " ")
        //                        {
        //                            if (quytrinh.NguoiDuyet == "MD")
        //                            {
        //                                Busers2 timnguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //                                Busers2 nguoiduyet = UserDAO.TimNhanVienTheoMa(timnguoitao.IdUserQuanLyTT, macongty);
        //                                ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);

        //                                //Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaChucVuCongty(nguoi.IDChucVu, nguoi.USERID, macongty);
        //                                DateTime ngay = DateTime.Today;

        //                                ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.USERID, macongty);
        //                                if (nghi != null)
        //                                {
        //                                    if (nghi.ThongQua == 1)
        //                                    {
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = quytrinh.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                        tnChildNode.Text = nguoiduyet.USERNAME;
        //                                        tnChildNode.Target = nguoiduyet.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyet.USERID);
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 2)
        //                                        {
        //                                            Busers2 nguoiduocuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                            ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduocuyquyen.IDChucVu, macongty);
        //                                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                            childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                            if (ngonngu == "lbl_VN")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                            }
        //                                            else if (ngonngu == "lbl_TW")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                            }
        //                                            childNode.Target = chucvu1.IDChucVu;

        //                                            parentNode.ChildNodes.Add(childNode);



        //                                            TreeNode tnChildNode = new TreeNode("" + nguoiduocuyquyen.USERNAME);
        //                                            tnChildNode.Text = nguoiduocuyquyen.USERNAME;
        //                                            tnChildNode.Target = nguoiduocuyquyen.USERID;
        //                                            tnChildNode.Value = aa;
        //                                            tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                            childNode.ChildNodes.Add(tnChildNode);
        //                                            listnguoi.Add(nguoiduocuyquyen.USERID);
        //                                        }
        //                                        else
        //                                        {
        //                                            if (nghi.ThongQua == 3)
        //                                            {
        //                                            }
        //                                        }
        //                                    }
        //                                }// nguoc lai khong nghi phep
        //                                else
        //                                {
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                Busers2 nguoiduyet = UserDAO.TimNhanVienTheoMaVaBoPhan(quytrinh.NguoiDuyet, quytrinh.DonViThongQua, macongty);
        //                                ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);

        //                                //Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaChucVuCongty(nguoi.IDChucVu, nguoi.USERID, macongty);
        //                                DateTime ngay = DateTime.Today;

        //                                ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.USERID, macongty);
        //                                if (nghi != null && nguoiduyet.USERID == nghi.IDNguoiDuyet)
        //                                {
        //                                    if (nghi.ThongQua == 1)
        //                                    {
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = quytrinh.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                        tnChildNode.Text = nguoiduyet.USERNAME;
        //                                        tnChildNode.Target = nguoiduyet.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduyet.USERID);
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 2)
        //                                        {
        //                                            Busers2 nguoiduocuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                            ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduocuyquyen.IDChucVu, macongty);
        //                                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                            childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                            if (ngonngu == "lbl_VN")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                            }
        //                                            else if (ngonngu == "lbl_TW")
        //                                            {
        //                                                childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                            }
        //                                            childNode.Target = chucvu1.IDChucVu;

        //                                            parentNode.ChildNodes.Add(childNode);



        //                                            TreeNode tnChildNode = new TreeNode("" + nguoiduocuyquyen.USERNAME);
        //                                            tnChildNode.Text = nguoiduocuyquyen.USERNAME;
        //                                            tnChildNode.Target = nguoiduocuyquyen.USERID;
        //                                            tnChildNode.Value = aa;
        //                                            tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                            childNode.ChildNodes.Add(tnChildNode);
        //                                            listnguoi.Add(nguoiduocuyquyen.USERID);
        //                                        }
        //                                        else
        //                                        {
        //                                            if (nghi.ThongQua == 3)
        //                                            {
        //                                            }
        //                                        }
        //                                    }
        //                                }// nguoc lai khong nghi phep
        //                                else
        //                                {
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                }

        //                            }
                                   
        //                        }
        //                        else
        //                        {
        //                            Busers2 timnguoitao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
        //                            Busers2 nguoiduyet = UserDAO.TimNhanVienTheoMa(timnguoitao.IdUserQuanLyTT, macongty);
        //                            ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);

        //                            //Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaChucVuCongty(nguoi.IDChucVu, nguoi.USERID, macongty);
        //                            DateTime ngay = DateTime.Today;

        //                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, nguoiduyet.USERID, macongty);
        //                            if (nghi != null)
        //                            {
        //                                if (nghi.ThongQua == 1)
        //                                {
        //                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                    if (ngonngu == "lbl_VN")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                    }
        //                                    else if (ngonngu == "lbl_TW")
        //                                    {
        //                                        childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                    }
        //                                    childNode.Target = quytrinh.IDChucVu;

        //                                    parentNode.ChildNodes.Add(childNode);



        //                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                    tnChildNode.Text = nguoiduyet.USERNAME;
        //                                    tnChildNode.Target = nguoiduyet.USERID;
        //                                    tnChildNode.Value = aa;
        //                                    tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                    childNode.ChildNodes.Add(tnChildNode);
        //                                    listnguoi.Add(nguoiduyet.USERID);
        //                                }
        //                                else
        //                                {
        //                                    if (nghi.ThongQua == 2)
        //                                    {
        //                                        Busers2 nguoiduocuyquyen = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
        //                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduocuyquyen.IDChucVu, macongty);
        //                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                        if (ngonngu == "lbl_VN")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
        //                                        }
        //                                        else if (ngonngu == "lbl_TW")
        //                                        {
        //                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
        //                                        }
        //                                        childNode.Target = chucvu1.IDChucVu;

        //                                        parentNode.ChildNodes.Add(childNode);



        //                                        TreeNode tnChildNode = new TreeNode("" + nguoiduocuyquyen.USERNAME);
        //                                        tnChildNode.Text = nguoiduocuyquyen.USERNAME;
        //                                        tnChildNode.Target = nguoiduocuyquyen.USERID;
        //                                        tnChildNode.Value = aa;
        //                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
        //                                        childNode.ChildNodes.Add(tnChildNode);
        //                                        listnguoi.Add(nguoiduocuyquyen.USERID);
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nghi.ThongQua == 3)
        //                                        {
        //                                        }
        //                                    }
        //                                }
        //                            }// nguoc lai khong nghi phep
        //                            else
        //                            {
        //                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
        //                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


        //                                if (ngonngu == "lbl_VN")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chuc.TenChucVu;
        //                                }
        //                                else if (ngonngu == "lbl_TW")
        //                                {
        //                                    childNode.Text = strchucvu + ":" + chuc.TenChucVuTiengHoa;
        //                                }
        //                                childNode.Target = quytrinh.IDChucVu;

        //                                parentNode.ChildNodes.Add(childNode);



        //                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                                tnChildNode.Text = nguoiduyet.USERNAME;
        //                                tnChildNode.Target = nguoiduyet.USERID;
        //                                tnChildNode.Value = aa;
        //                                tnChildNode.ToolTip = chuc.IDCapDuyet.ToString();
        //                                childNode.ChildNodes.Add(tnChildNode);
        //                                listnguoi.Add(nguoiduyet.USERID);
        //                            }

        //                        }///
        //                    }

        //                }

        //            }
        //            TreeView2.ExpandAll();
        //        }
        //    }
           

        //}
        #endregion
        public void reloadTreeView()
        {
            string maloai = Session["loaiphieu"].ToString();
            string maloaiphieu = "PDN1";
            string mabophan = Session["bp"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["UserID"].ToString().Trim();
            // string idnguoiduyet = Session["idnguoiduyet"].ToString();
            int abstepTemp=0;int abpsTemp=0;
            if (ngonngu == "lbl_VN")
            {
                ngonngudung = "Danh sách người ký";
                strchucvu = "Chức vụ";
            }
            else if (ngonngu == "lbl_TW")
            {
                ngonngudung = "审核名单";
                strchucvu = "职务";
            }
            else if (ngonngu == "lbl_EN")
            {
                ngonngudung = "List Approval Users";
                strchucvu = "Chức vụ";
            }

            if (TreeView2.Nodes.Count == 0)
            {
                TreeNode parentNote = new TreeNode("List users browsing");
                parentNote.Text = "List users browsing";

            }


            TreeView2.Nodes.Clear();

            TreeNode parentNode = new TreeNode("");

            parentNode.Text = ngonngudung;
            TreeView2.Nodes.Add(parentNode);
            Busers2 timnguoitaotao = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
            BDepartment bophantao = BDepartmentDAO.TimMaDonVi(mabophan, macongty);
            QPDNFlow timNguoiTheoQT = QPDNFlowDAO.TimNguoiDuyetTrongQuyTrinh(mabophan, macongty, maloaiphieu, manguoidung);
            if (timNguoiTheoQT == null)// lay danh sach quy trinh theo quy trinh mau
            {
                lsquytrinh = QPDNFlowDAO.QryQuyTrinhTheoDonViLoaiPhieu(mabophan, macongty, maloai, int.Parse(bophantao.DepartmentTypeID.ToString()));
                if (lsquytrinh.Count > 0)
                {
                    foreach (QPDNFlow quytrinh in lsquytrinh)
                    {
                        DateTime ngay = DateTime.Today;

                        ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay,ngay, quytrinh.NguoiDuyet, macongty);
                        if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                        {
                            if (nghi.ThongQua == 1)
                            {
                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                if (ngonngu == "lbl_VN")
                                {
                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                }
                                else if (ngonngu == "lbl_TW")
                                {
                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                }
                                childNode.Target = quytrinh.IDChucVu;

                                parentNode.ChildNodes.Add(childNode);



                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                tnChildNode.Text = nguoiduyet.USERNAME;
                                tnChildNode.Target = nguoiduyet.USERID;
                                tnChildNode.Value = aa;
                                tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                childNode.ChildNodes.Add(tnChildNode);
                                listnguoi.Add(nguoiduyet.USERID);
                            }
                            else
                            {
                                if (nghi.ThongQua == 2)
                                {
                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                    if (ngonngu == "lbl_VN")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                    }
                                    else if (ngonngu == "lbl_TW")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                    }
                                    childNode.Target = nguoiduyet.IDChucVu;

                                    parentNode.ChildNodes.Add(childNode);



                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                    tnChildNode.Target = nguoiduyet.USERID;
                                    tnChildNode.Value = aa;

                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                    childNode.ChildNodes.Add(tnChildNode);
                                    listnguoi.Add(nguoiduyet.USERID);
                                }
                                else
                                {
                                    if (nghi.ThongQua == 3)
                                    {

                                    }
                                }
                            }
                        }// nguoc lai khi khong nghi phep
                        else
                        {
                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                            if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                            {
                                if (manguoidung != nguoiduyet.USERID.Trim())
                                {
                                    ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                    if (ngonngu == "lbl_VN")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                    }
                                    else if (ngonngu == "lbl_TW")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                    }
                                    childNode.Target = quytrinh.IDChucVu;

                                    parentNode.ChildNodes.Add(childNode);



                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                    tnChildNode.Target = nguoiduyet.USERID;
                                    tnChildNode.Value = aa;

                                    tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();

                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                    childNode.ChildNodes.Add(tnChildNode);
                                    listnguoi.Add(nguoiduyet.USERID);
                                }// neu bo qua thi nho lai
                                else
                                {
                                    abstepTemp = quytrinh.ABstep;
                                    if (quytrinh.ABPS > 1)
                                    {
                                        abpsTemp = quytrinh.ABPS;
                                    }
                                }
                            }
                            else
                            {
                                abstepTemp = quytrinh.ABstep;
                                if (quytrinh.ABPS > 1)
                                {
                                    abpsTemp = quytrinh.ABPS;
                                }   
                            }
                        }
                       
                    }
                }// neu Quy trinh khong co thi dung quy trinh All
                else
                {
                    string maDVAll = "All";
                    List<QPDNFlow> listAll = QPDNFlowDAO.QryQuyTrinhAll(maDVAll, macongty, maloai);
                    if (listAll.Count > 0)
                    {
                        foreach (QPDNFlow quytrinh in listAll)
                        {
                            if (quytrinh.NguoiDuyet == "ZZZZZZ")
                            {
                               
                                    Busers2 timCQ = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
                                    if (quytrinh.IDCapDuyet > timCQ.IDCapDuyet)
                                    {
                                    if (timCQ != null && timCQ.IDChucVu.Trim() != "CQDV")
                                    {
                                        Busers2 timnguoiduyet = UserBUS.TimNhanVienTheoMa(timCQ.IdUserQuanLyTT, macongty);
                                        if (timnguoiduyet != null && timnguoiduyet.USERID != manguoidung)
                                        {
                                            ChucVu chucvu = ChucVuBUS.TimMaChucVu(timnguoiduyet.IDChucVu, macongty);
                                            DateTime ngay = DateTime.Today;

                                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, timnguoiduyet.USERID, macongty);
                                            if (nghi != null)
                                            {
                                                if (nghi.ThongQua == 1)
                                                {
                                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                    //  ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                    if (ngonngu == "lbl_VN")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                    }
                                                    else if (ngonngu == "lbl_TW")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                    }
                                                    childNode.Target = quytrinh.IDChucVu;

                                                    parentNode.ChildNodes.Add(childNode);



                                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                                    tnChildNode.Target = nguoiduyet.USERID;
                                                    tnChildNode.Value = aa;
                                                    tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                    childNode.ChildNodes.Add(tnChildNode);
                                                    listnguoi.Add(nguoiduyet.USERID);
                                                }
                                                else
                                                {
                                                    if (nghi.ThongQua == 2)
                                                    {
                                                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                        if (ngonngu == "lbl_VN")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                        }
                                                        else if (ngonngu == "lbl_TW")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                        }
                                                        childNode.Target = nguoiduyet.IDChucVu;

                                                        parentNode.ChildNodes.Add(childNode);



                                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                                        tnChildNode.Target = nguoiduyet.USERID;
                                                        tnChildNode.Value = aa;
                                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                        childNode.ChildNodes.Add(tnChildNode);
                                                        listnguoi.Add(nguoiduyet.USERID);
                                                    }
                                                    else
                                                    {
                                                        if (nghi.ThongQua == 3)
                                                        {

                                                        }
                                                    }
                                                }
                                            }// nguoc  lai khong nghi phep
                                            else
                                            {
                                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(timnguoiduyet.USERID, macongty);
                                                if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                                {
                                                    if (manguoidung != nguoiduyet.USERID.Trim())
                                                    {
                                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                        if (ngonngu == "lbl_VN")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                        }
                                                        else if (ngonngu == "lbl_TW")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                        }
                                                        childNode.Target = quytrinh.IDChucVu;

                                                        parentNode.ChildNodes.Add(childNode);



                                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                                        tnChildNode.Target = nguoiduyet.USERID;
                                                        tnChildNode.Value = aa;
                                                        tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                        childNode.ChildNodes.Add(tnChildNode);
                                                        listnguoi.Add(nguoiduyet.USERID);
                                                    }
                                                    else
                                                    {
                                                        abstepTemp = quytrinh.ABstep;
                                                        if (quytrinh.ABPS > 1)
                                                        {
                                                            abpsTemp = quytrinh.ABPS;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    abstepTemp = quytrinh.ABstep;
                                                    if (quytrinh.ABPS > 1)
                                                    {
                                                        abpsTemp = quytrinh.ABPS;
                                                    }
                                                }
                                            }

                                        }
                                    }// neu bo qua thi nho lai
                                    else
                                    {
                                        abstepTemp = quytrinh.ABstep;
                                        if (quytrinh.ABPS > 1)
                                        {
                                            abpsTemp = quytrinh.ABPS;
                                        }
                                    }
                                }// nguoc lai thi nho lai
                                else
                                {
                                    abstepTemp = quytrinh.ABstep;
                                    if (quytrinh.ABPS > 1)
                                    {
                                        abpsTemp = quytrinh.ABPS;
                                    }    
                                }
                                // them vao day nua keke
                            }// Nguoc lai neu nguoi duyet khac ZZZZZZ
                            else
                            {
                                if (quytrinh.NguoiDuyet != manguoidung)
                                {
                                    DateTime ngay = DateTime.Today;

                                    ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, quytrinh.NguoiDuyet, macongty);
                                    if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                                    {
                                        if (nghi.ThongQua == 1)
                                        {
                                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                            ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                            TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                            childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                            if (ngonngu == "lbl_VN")
                                            {
                                                childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                            }
                                            else if (ngonngu == "lbl_TW")
                                            {
                                                childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                            }
                                            childNode.Target = quytrinh.IDChucVu;

                                            parentNode.ChildNodes.Add(childNode);



                                            TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                            tnChildNode.Text = nguoiduyet.USERNAME;
                                            tnChildNode.Target = nguoiduyet.USERID;
                                            tnChildNode.Value = aa;
                                            tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                            tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                            tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                            tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                            childNode.ChildNodes.Add(tnChildNode);
                                            listnguoi.Add(nguoiduyet.USERID);
                                        }
                                        else
                                        {
                                            if (nghi.ThongQua == 2)
                                            {
                                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                if (ngonngu == "lbl_VN")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                }
                                                else if (ngonngu == "lbl_TW")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                }
                                                childNode.Target = nguoiduyet.IDChucVu;

                                                parentNode.ChildNodes.Add(childNode);



                                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                tnChildNode.Text = nguoiduyet.USERNAME;
                                                tnChildNode.Target = nguoiduyet.USERID;
                                                tnChildNode.Value = aa;
                                                tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                childNode.ChildNodes.Add(tnChildNode);
                                                listnguoi.Add(nguoiduyet.USERID);
                                            }
                                            else
                                            {
                                                if (nghi.ThongQua == 3)
                                                {

                                                }
                                            }
                                        }
                                    }// nguoc lai khi khong nghi phep
                                    else
                                    {
                                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                        if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                        {
                                            if (manguoidung != nguoiduyet.USERID.Trim())
                                            {
                                                ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                if (ngonngu == "lbl_VN")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                }
                                                else if (ngonngu == "lbl_TW")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                }
                                                childNode.Target = quytrinh.IDChucVu;

                                                parentNode.ChildNodes.Add(childNode);



                                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                tnChildNode.Text = nguoiduyet.USERNAME;
                                                tnChildNode.Target = nguoiduyet.USERID;
                                                tnChildNode.Value = aa;
                                                tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                childNode.ChildNodes.Add(tnChildNode);
                                                listnguoi.Add(nguoiduyet.USERID);
                                            }
                                            else
                                            {
                                                abstepTemp = quytrinh.ABstep;
                                                if (quytrinh.ABPS > 1)
                                                {
                                                    abpsTemp = quytrinh.ABPS;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            abstepTemp = quytrinh.ABstep;
                                            if (quytrinh.ABPS > 1)
                                            {
                                                abpsTemp = quytrinh.ABPS;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    abstepTemp = quytrinh.ABstep;
                                    if (quytrinh.ABPS > 1)
                                    {
                                        abpsTemp = quytrinh.ABPS;
                                    }
                                }
                           }
                        }
                    }
                }
               

            }// nguoc lai lay  quy trinh > nguoi tao phieu
            else
            {
                if (timNguoiTheoQT.ABPS == 0)
                {
                    lsquytrinh = QPDNFlowDAO.QryQuyTrinhTheoDieuKien2(mabophan, macongty, maloai, int.Parse(bophantao.DepartmentTypeID.ToString()), timNguoiTheoQT.ABstep);
                    if (lsquytrinh.Count > 0)
                    {
                        foreach (QPDNFlow quytrinh in lsquytrinh)
                        {
                            DateTime ngay = DateTime.Today;

                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, quytrinh.NguoiDuyet, macongty);
                            if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                            {
                                if (nghi.ThongQua == 1)
                                {
                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                    ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                    if (ngonngu == "lbl_VN")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                    }
                                    else if (ngonngu == "lbl_TW")
                                    {
                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                    }
                                    childNode.Target = quytrinh.IDChucVu;

                                    parentNode.ChildNodes.Add(childNode);



                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                    tnChildNode.Target = nguoiduyet.USERID;
                                    tnChildNode.Value = aa;
                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                    tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                    childNode.ChildNodes.Add(tnChildNode);
                                    listnguoi.Add(nguoiduyet.USERID);
                                }
                                else
                                {
                                    if (nghi.ThongQua == 2)
                                    {
                                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                        if (ngonngu == "lbl_VN")
                                        {
                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                        }
                                        else if (ngonngu == "lbl_TW")
                                        {
                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                        }
                                        childNode.Target = nguoiduyet.IDChucVu;

                                        parentNode.ChildNodes.Add(childNode);



                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                        tnChildNode.Target = nguoiduyet.USERID;
                                        tnChildNode.Value = aa;
                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                        childNode.ChildNodes.Add(tnChildNode);
                                        listnguoi.Add(nguoiduyet.USERID);
                                    }
                                    else
                                    {
                                        if (nghi.ThongQua == 3)
                                        {

                                        }
                                    }
                                }
                            }// nguoc lai khi khong nghi phep
                            else
                            {
                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                {
                                    if (manguoidung != nguoiduyet.USERID.Trim())
                                    {
                                        ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                        if (ngonngu == "lbl_VN")
                                        {
                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                        }
                                        else if (ngonngu == "lbl_TW")
                                        {
                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                        }
                                        childNode.Target = quytrinh.IDChucVu;

                                        parentNode.ChildNodes.Add(childNode);



                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                        tnChildNode.Target = nguoiduyet.USERID;
                                        tnChildNode.Value = aa;
                                        tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                        childNode.ChildNodes.Add(tnChildNode);
                                        listnguoi.Add(nguoiduyet.USERID);
                                    }
                                    else
                                    {
                                        abstepTemp = quytrinh.ABstep;
                                        if (quytrinh.ABPS > 1)
                                        {
                                            abpsTemp = quytrinh.ABPS;
                                        }
                                    }
                                }
                                else
                                {
                                    abstepTemp = quytrinh.ABstep;
                                    if (quytrinh.ABPS > 1)
                                    {
                                        abpsTemp = quytrinh.ABPS;
                                    }
                                }
                            }
                        }
                    }// nguoc lai dung quy trinh mau
                    else
                    {
                        string maDVAll = "All";
                        List<QPDNFlow> listAll = QPDNFlowDAO.QryQuyTrinhAll(maDVAll, macongty, maloai);
                        if (listAll.Count > 0)
                        {
                            foreach (QPDNFlow quytrinh in listAll)
                            {
                                if (quytrinh.NguoiDuyet == "ZZZZZZ")
                                {

                                    Busers2 timCQ = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
                                    if (timCQ != null && timCQ.IDChucVu.Trim() != "CQDV")
                                    {
                                        Busers2 timnguoiduyet = UserBUS.TimNhanVienTheoMa(timCQ.IdUserQuanLyTT, macongty);
                                        if (timnguoiduyet != null && timnguoiduyet.USERID != manguoidung)
                                        {
                                            ChucVu chucvu = ChucVuBUS.TimMaChucVu(timnguoiduyet.IDChucVu, macongty);
                                            DateTime ngay = DateTime.Today;

                                            ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, timnguoiduyet.USERID, macongty);
                                            if (nghi != null)
                                            {
                                                if (nghi.ThongQua == 1)
                                                {
                                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                    //  ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                    if (ngonngu == "lbl_VN")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                    }
                                                    else if (ngonngu == "lbl_TW")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                    }
                                                    childNode.Target = quytrinh.IDChucVu;

                                                    parentNode.ChildNodes.Add(childNode);



                                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                                    tnChildNode.Target = nguoiduyet.USERID;
                                                    tnChildNode.Value = aa;
                                                    tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                    childNode.ChildNodes.Add(tnChildNode);
                                                    listnguoi.Add(nguoiduyet.USERID);
                                                }
                                                else
                                                {
                                                    if (nghi.ThongQua == 2)
                                                    {
                                                        Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                        ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                        if (ngonngu == "lbl_VN")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                        }
                                                        else if (ngonngu == "lbl_TW")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                        }
                                                        childNode.Target = nguoiduyet.IDChucVu;

                                                        parentNode.ChildNodes.Add(childNode);



                                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                                        tnChildNode.Target = nguoiduyet.USERID;
                                                        tnChildNode.Value = aa;
                                                        tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                        childNode.ChildNodes.Add(tnChildNode);
                                                        listnguoi.Add(nguoiduyet.USERID);
                                                    }
                                                    else
                                                    {
                                                        if (nghi.ThongQua == 3)
                                                        {

                                                        }
                                                    }
                                                }
                                            }// nguoc  lai khong nghi phep
                                            else
                                            {
                                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(timnguoiduyet.USERID, macongty);
                                                if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                                {
                                                    if (manguoidung != nguoiduyet.USERID.Trim())
                                                    {
                                                        TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                        childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                        if (ngonngu == "lbl_VN")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                        }
                                                        else if (ngonngu == "lbl_TW")
                                                        {
                                                            childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                        }
                                                        childNode.Target = quytrinh.IDChucVu;

                                                        parentNode.ChildNodes.Add(childNode);



                                                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                        tnChildNode.Text = nguoiduyet.USERNAME;
                                                        tnChildNode.Target = nguoiduyet.USERID;
                                                        tnChildNode.Value = aa;
                                                        tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                        tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                        tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                        childNode.ChildNodes.Add(tnChildNode);
                                                        listnguoi.Add(nguoiduyet.USERID);
                                                    }
                                                    else
                                                    {
                                                        abstepTemp = quytrinh.ABstep;
                                                        if (quytrinh.ABPS > 1)
                                                        {
                                                            abpsTemp = quytrinh.ABPS;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    abstepTemp = quytrinh.ABstep;
                                                    if (quytrinh.ABPS > 1)
                                                    {
                                                        abpsTemp = quytrinh.ABPS;
                                                    }
                                                }
                                            }
                                        }
                                    }// neu bo qua thi nho lai
                                    else
                                    {
                                        abstepTemp = quytrinh.ABstep;
                                        if (quytrinh.ABPS > 1)
                                        {
                                            abpsTemp = quytrinh.ABPS;
                                        }
                                    }
                                }// Nguoc lai neu nguoi duyet khac ZZZZZZ
                                else
                                {
                                    if (quytrinh.NguoiDuyet != manguoidung)
                                    {
                                        DateTime ngay = DateTime.Today;

                                        ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, quytrinh.NguoiDuyet, macongty);
                                        if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                                        {
                                            if (nghi.ThongQua == 1)
                                            {
                                                Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                if (ngonngu == "lbl_VN")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                }
                                                else if (ngonngu == "lbl_TW")
                                                {
                                                    childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                }
                                                childNode.Target = quytrinh.IDChucVu;

                                                parentNode.ChildNodes.Add(childNode);



                                                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                tnChildNode.Text = nguoiduyet.USERNAME;
                                                tnChildNode.Target = nguoiduyet.USERID;
                                                tnChildNode.Value = aa;
                                                tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                                tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                childNode.ChildNodes.Add(tnChildNode);
                                                listnguoi.Add(nguoiduyet.USERID);
                                            }
                                            else
                                            {
                                                if (nghi.ThongQua == 2)
                                                {
                                                    Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                    ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                    if (ngonngu == "lbl_VN")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                    }
                                                    else if (ngonngu == "lbl_TW")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                    }
                                                    childNode.Target = nguoiduyet.IDChucVu;

                                                    parentNode.ChildNodes.Add(childNode);



                                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                                    tnChildNode.Target = nguoiduyet.USERID;
                                                    tnChildNode.Value = aa;
                                                    tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                    childNode.ChildNodes.Add(tnChildNode);
                                                    listnguoi.Add(nguoiduyet.USERID);
                                                }
                                                else
                                                {
                                                    if (nghi.ThongQua == 3)
                                                    {

                                                    }
                                                }
                                            }
                                        }// nguoc lai khi khong nghi phep
                                        else
                                        {
                                            Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                            if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                            {
                                                if (manguoidung != nguoiduyet.USERID.Trim())
                                                {
                                                    ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                    TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                    childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                    if (ngonngu == "lbl_VN")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                    }
                                                    else if (ngonngu == "lbl_TW")
                                                    {
                                                        childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                    }
                                                    childNode.Target = quytrinh.IDChucVu;

                                                    parentNode.ChildNodes.Add(childNode);



                                                    TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                    tnChildNode.Text = nguoiduyet.USERNAME;
                                                    tnChildNode.Target = nguoiduyet.USERID;
                                                    tnChildNode.Value = aa;
                                                    tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                    tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                    tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                    childNode.ChildNodes.Add(tnChildNode);
                                                    listnguoi.Add(nguoiduyet.USERID);
                                                }// nguoc lai neu nho nguoi do
                                                else
                                                {
                                                    abstepTemp = quytrinh.ABstep;
                                                    if (quytrinh.ABPS > 1)
                                                    {
                                                        abpsTemp = quytrinh.ABPS;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                abstepTemp = quytrinh.ABstep;
                                                if (quytrinh.ABPS > 1)
                                                {
                                                    abpsTemp = quytrinh.ABPS;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        abstepTemp = quytrinh.ABstep;
                                        if (quytrinh.ABPS > 1)
                                        {
                                            abpsTemp = quytrinh.ABPS;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }// have multi people in abstep
                else
                {
                   lsquytrinh = QPDNFlowDAO.QryQuyTrinhTheoDieuKien(mabophan, macongty, maloai, int.Parse(bophantao.DepartmentTypeID.ToString()), timNguoiTheoQT.ABstep,int.Parse(timNguoiTheoQT.IDCapDuyet.ToString()));
                   if (lsquytrinh.Count > 0)
                   {
                       foreach (QPDNFlow quytrinh in lsquytrinh)
                       {
                           if (quytrinh != null)
                           {
                               DateTime ngay = DateTime.Today;

                               ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, quytrinh.NguoiDuyet, macongty);
                               if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                               {
                                   if (nghi.ThongQua == 1)
                                   {
                                       Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                       ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                       TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                       childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                       if (ngonngu == "lbl_VN")
                                       {
                                           childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                       }
                                       else if (ngonngu == "lbl_TW")
                                       {
                                           childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                       }
                                       childNode.Target = quytrinh.IDChucVu;

                                       parentNode.ChildNodes.Add(childNode);



                                       TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                       tnChildNode.Text = nguoiduyet.USERNAME;
                                       tnChildNode.Target = nguoiduyet.USERID;
                                       tnChildNode.Value = aa;
                                       tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                       tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                       tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                       tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                       childNode.ChildNodes.Add(tnChildNode);
                                       listnguoi.Add(nguoiduyet.USERID);
                                   }
                                   else
                                   {
                                       if (nghi.ThongQua == 2)
                                       {
                                           Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                           ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                           TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                           childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                           if (ngonngu == "lbl_VN")
                                           {
                                               childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                           }
                                           else if (ngonngu == "lbl_TW")
                                           {
                                               childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                           }
                                           childNode.Target = nguoiduyet.IDChucVu;

                                           parentNode.ChildNodes.Add(childNode);



                                           TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                           tnChildNode.Text = nguoiduyet.USERNAME;
                                           tnChildNode.Target = nguoiduyet.USERID;
                                           tnChildNode.Value = aa;
                                           tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                           tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                           tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                           tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                           childNode.ChildNodes.Add(tnChildNode);
                                           listnguoi.Add(nguoiduyet.USERID);
                                       }
                                       else
                                       {
                                           if (nghi.ThongQua == 3)
                                           {

                                           }
                                       }
                                   }
                               }// nguoc lai khi khong nghi phep
                               else
                               {
                                   Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                 
                                   if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                   {
                                       if (manguoidung != nguoiduyet.USERID.Trim())
                                       {
                                           int step =0;
                                           if (quytrinh.ABstep == 1)
                                           {
                                               step = quytrinh.ABstep;
                                           }
                                           else
                                           {
                                              step = (quytrinh.ABstep - abstepTemp);
                                           }
                                           int ps = (quytrinh.ABPS - abpsTemp);
                                           ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                           TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                           childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                           if (ngonngu == "lbl_VN")
                                           {
                                               childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                           }
                                           else if (ngonngu == "lbl_TW")
                                           {
                                               childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                           }
                                           childNode.Target = quytrinh.IDChucVu;

                                           parentNode.ChildNodes.Add(childNode);



                                           TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                           tnChildNode.Text = nguoiduyet.USERNAME;
                                           tnChildNode.Target = nguoiduyet.USERID;
                                           tnChildNode.Value = aa;
                                           tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();

                                           if (step == 0)
                                           {
                                               tnChildNode.NavigateUrl = "1";
                                           }
                                           else
                                           {
                                               tnChildNode.NavigateUrl = step.ToString();
                                           }
                                           if (ps > 1)
                                           {
                                               tnChildNode.ImageToolTip = "1";
                                               abpsTemp = 0;
                                           }
                                           else
                                           {
                                               if (ps == 0)
                                               {
                                                   tnChildNode.ImageToolTip = "1";
                                                   abpsTemp = 0;
                                               }
                                               else
                                               {
                                                   tnChildNode.ImageToolTip = ps.ToString();
                                                   abpsTemp = ps;
                                               }
                                           }
                                           
                                           tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                           childNode.ChildNodes.Add(tnChildNode);
                                           listnguoi.Add(nguoiduyet.USERID);

                                       }// nguoc lai neu nho nguoi do
                                       else
                                       {
                                           //abstepTemp = quytrinh.ABstep;
                                           //if (quytrinh.ABPS > 1)
                                           //{
                                           //    abpsTemp = quytrinh.ABPS;
                                           //}

                                           // 
                                           abstepTemp = quytrinh.ABstep;
                                           if (quytrinh.ABPS > 1)
                                           {
                                               abpsTemp = quytrinh.ABPS;
                                           }
                                       }
                                   }
                                   else
                                   {
                                       abstepTemp = quytrinh.ABstep;
                                       if (quytrinh.ABPS > 1)
                                       {
                                           abpsTemp = quytrinh.ABPS;
                                       }
                                   }
                               }
                           }
                       }
                   }// nguoc lai neu khong co dung quy trinh mau
                   else
                   {
                       string maDVAll = "All";
                       List<QPDNFlow> listAll = QPDNFlowDAO.QryQuyTrinhAll(maDVAll, macongty, maloai);
                       if (listAll.Count > 0)
                       {
                           foreach (QPDNFlow quytrinh in listAll)
                           {
                               if (quytrinh.NguoiDuyet == "ZZZZZZ")
                               {

                                   Busers2 timCQ = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
                                   if (timCQ != null && timCQ.IDChucVu.Trim() != "CQDV")
                                   {
                                       Busers2 timnguoiduyet = UserBUS.TimNhanVienTheoMa(timCQ.IdUserQuanLyTT, macongty);
                                       if (timnguoiduyet != null && timnguoiduyet.USERID != manguoidung)
                                       {
                                           ChucVu chucvu = ChucVuBUS.TimMaChucVu(timnguoiduyet.IDChucVu, macongty);
                                           DateTime ngay = DateTime.Today;

                                           ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, timnguoiduyet.USERID, macongty);
                                           if (nghi != null)
                                           {
                                               if (nghi.ThongQua == 1)
                                               {
                                                   Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                   //  ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                   TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                   childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                   if (ngonngu == "lbl_VN")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                   }
                                                   else if (ngonngu == "lbl_TW")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                   }
                                                   childNode.Target = quytrinh.IDChucVu;

                                                   parentNode.ChildNodes.Add(childNode);



                                                   TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                   tnChildNode.Text = nguoiduyet.USERNAME;
                                                   tnChildNode.Target = nguoiduyet.USERID;
                                                   tnChildNode.Value = aa;
                                                   tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                                   tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                   tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                   tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                   childNode.ChildNodes.Add(tnChildNode);
                                                   listnguoi.Add(nguoiduyet.USERID);
                                               }
                                               else
                                               {
                                                   if (nghi.ThongQua == 2)
                                                   {
                                                       Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                       ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                       TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                       childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                       if (ngonngu == "lbl_VN")
                                                       {
                                                           childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                       }
                                                       else if (ngonngu == "lbl_TW")
                                                       {
                                                           childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                       }
                                                       childNode.Target = nguoiduyet.IDChucVu;

                                                       parentNode.ChildNodes.Add(childNode);



                                                       TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                       tnChildNode.Text = nguoiduyet.USERNAME;
                                                       tnChildNode.Target = nguoiduyet.USERID;
                                                       tnChildNode.Value = aa;
                                                       tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                       tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                       tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                       tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                       childNode.ChildNodes.Add(tnChildNode);
                                                       listnguoi.Add(nguoiduyet.USERID);
                                                   }
                                                   else
                                                   {
                                                       if (nghi.ThongQua == 3)
                                                       {

                                                       }
                                                   }
                                               }
                                           }// nguoc  lai khong nghi phep
                                           else
                                           {
                                               Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(timnguoiduyet.USERID, macongty);
                                               if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                               {
                                                   if (manguoidung != nguoiduyet.USERID.Trim())
                                                   {
                                                       TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                       childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                       if (ngonngu == "lbl_VN")
                                                       {
                                                           childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                       }
                                                       else if (ngonngu == "lbl_TW")
                                                       {
                                                           childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                       }
                                                       childNode.Target = quytrinh.IDChucVu;

                                                       parentNode.ChildNodes.Add(childNode);



                                                       TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                       tnChildNode.Text = nguoiduyet.USERNAME;
                                                       tnChildNode.Target = nguoiduyet.USERID;
                                                       tnChildNode.Value = aa;
                                                       tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                       tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                       tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                       tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                       childNode.ChildNodes.Add(tnChildNode);
                                                       listnguoi.Add(nguoiduyet.USERID);
                                                   }
                                                   else
                                                   {
                                                       abstepTemp = quytrinh.ABstep;
                                                       if (quytrinh.ABPS > 1)
                                                       {
                                                           abpsTemp = quytrinh.ABPS;
                                                       }
                                                   }
                                               }
                                               else
                                               {
                                                   abstepTemp = quytrinh.ABstep;
                                                   if (quytrinh.ABPS > 1)
                                                   {
                                                       abpsTemp = quytrinh.ABPS;
                                                   }
                                               }
                                           }
                                       }
                                   }// neu bo qua thi nho lai
                                   else
                                   {
                                       abstepTemp = quytrinh.ABstep;
                                       if (quytrinh.ABPS > 1)
                                       {
                                           abpsTemp = quytrinh.ABPS;
                                       }
                                   }
                               }// Nguoc lai neu nguoi duyet khac ZZZZZZ
                               else
                               {
                                   if (quytrinh.NguoiDuyet != manguoidung)
                                   {
                                       DateTime ngay = DateTime.Today;

                                       ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay, ngay, quytrinh.NguoiDuyet, macongty);
                                       if (nghi != null && quytrinh.NguoiDuyet == nghi.IDNguoiDuyet)
                                       {
                                           if (nghi.ThongQua == 1)
                                           {
                                               Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                               ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                               TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                               childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                               if (ngonngu == "lbl_VN")
                                               {
                                                   childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                               }
                                               else if (ngonngu == "lbl_TW")
                                               {
                                                   childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                               }
                                               childNode.Target = quytrinh.IDChucVu;

                                               parentNode.ChildNodes.Add(childNode);



                                               TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                               tnChildNode.Text = nguoiduyet.USERNAME;
                                               tnChildNode.Target = nguoiduyet.USERID;
                                               tnChildNode.Value = aa;
                                               tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                               tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                               tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                               tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                               childNode.ChildNodes.Add(tnChildNode);
                                               listnguoi.Add(nguoiduyet.USERID);
                                           }
                                           else
                                           {
                                               if (nghi.ThongQua == 2)
                                               {
                                                   Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(nghi.IDNguoiDuocUyQuyen, macongty);
                                                   ChucVu chucvu1 = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                   TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                   childNode.Value = quytrinh.IDQuyTrinh.ToString();


                                                   if (ngonngu == "lbl_VN")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu1.TenChucVu;
                                                   }
                                                   else if (ngonngu == "lbl_TW")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu1.TenChucVuTiengHoa;
                                                   }
                                                   childNode.Target = nguoiduyet.IDChucVu;

                                                   parentNode.ChildNodes.Add(childNode);



                                                   TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                   tnChildNode.Text = nguoiduyet.USERNAME;
                                                   tnChildNode.Target = nguoiduyet.USERID;
                                                   tnChildNode.Value = aa;
                                                   tnChildNode.ToolTip = chucvu1.IDCapDuyet.ToString();
                                                   tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                   tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                   tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                   childNode.ChildNodes.Add(tnChildNode);
                                                   listnguoi.Add(nguoiduyet.USERID);
                                               }
                                               else
                                               {
                                                   if (nghi.ThongQua == 3)
                                                   {

                                                   }
                                               }
                                           }
                                       }// nguoc lai khi khong nghi phep
                                       else
                                       {
                                           Busers2 nguoiduyet = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                           if (nguoiduyet.IDCapDuyet >= timnguoitaotao.IDCapDuyet)
                                           {
                                               if (manguoidung != nguoiduyet.USERID.Trim())
                                               {
                                                   ChucVu chucvu = ChucVuBUS.TimMaChucVu(nguoiduyet.IDChucVu, macongty);
                                                   TreeNode childNode = new TreeNode(quytrinh.IDQuyTrinh.ToString());
                                                   childNode.Value = quytrinh.IDQuyTrinh.ToString();

                                                   if (ngonngu == "lbl_VN")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu.TenChucVu;
                                                   }
                                                   else if (ngonngu == "lbl_TW")
                                                   {
                                                       childNode.Text = strchucvu + ":" + chucvu.TenChucVuTiengHoa;
                                                   }
                                                   childNode.Target = quytrinh.IDChucVu;

                                                   parentNode.ChildNodes.Add(childNode);



                                                   TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
                                                   tnChildNode.Text = nguoiduyet.USERNAME;
                                                   tnChildNode.Target = nguoiduyet.USERID;
                                                   tnChildNode.Value = aa;
                                                   tnChildNode.ToolTip = quytrinh.IDCapDuyet.ToString();
                                                   tnChildNode.NavigateUrl = (quytrinh.ABstep - abstepTemp).ToString();
                                                   tnChildNode.ImageToolTip = (quytrinh.ABPS - abpsTemp).ToString();
                                                   tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                                   childNode.ChildNodes.Add(tnChildNode);
                                                   listnguoi.Add(nguoiduyet.USERID);
                                               }
                                               else
                                               {
                                                   abstepTemp = quytrinh.ABstep;
                                                   if (quytrinh.ABPS > 1)
                                                   {
                                                       abpsTemp = quytrinh.ABPS;
                                                   }
 
                                               }
                                           }
                                           else
                                           {
                                               abstepTemp = quytrinh.ABstep;
                                               if (quytrinh.ABPS > 1)
                                               {
                                                   abpsTemp = quytrinh.ABPS;
                                               }
                                           }
                                       }
                                   }
                                   else
                                   {
                                       abstepTemp = quytrinh.ABstep;
                                       if (quytrinh.ABPS > 1)
                                       {
                                           abpsTemp = quytrinh.ABPS;
                                       }
                                   }
                               }
                           }
                       }

                   }
                }
                TreeView2.ExpandAll();
            }

        }
        protected void btnTrinhDuyet_Click(object sender, EventArgs e)
        {
            if (TreeView2.Nodes[0].ChildNodes.Count > 0)
            {
                List<Abcon> ctxdlist = new List<Abcon>();


                pdna phieudn = new pdna();
                try
                {
                    // string maloai = Session["loaiphieu"].ToString();

                    string phieu = Session["maphieu"].ToString();
                    DateTime date = DateTime.Now;
                   // string ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");


                    string congty = Session["congty"].ToString();
                    string user = Session["user"].ToString();
                    string douutien = DropUutien.SelectedValue.ToString();
                   // Session["ngaythang"] = ngaythang;
                    // lvb1 = abill1BUS.LayDSLoaiVanBan_CapDuyet(maloai, bophan);
                    //string ngaytao = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                    pdna timvanban1 = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                    Busers2 timnguoitao = UserDAO.TimNhanVienTheoMa(user, congty);
                    try
                    {

                        
                       
                        for (int i = 0; i < TreeView2.Nodes[0].ChildNodes.Count; i++)
                        {
                            TreeNode tn = TreeView2.Nodes[0].ChildNodes[i];
                            

                            foreach (TreeNode nodecon in tn.ChildNodes)
                            {
                                dem = int.Parse(nodecon.Value) + dem;
                                int abstep = int.Parse(nodecon.NavigateUrl);
                                int abps = int.Parse(nodecon.ImageToolTip);
                                Busers2 user1 = UserBUS.TimNhanVienTheoMa(nodecon.Target, congty);

                                if (timnguoitao.IDCapDuyet >= 12)
                                {
                                    string bophan = "CBCC";
                                    pdna timvanban = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                                    Abcon kiemtrabangabcon = AbconDAO.KiemTraPhieuTrongBangAbcon(phieu, congty, nodecon.Target);
                                    if (kiemtrabangabcon == null)
                                    {


                                        Abcon vb = new Abcon();
                                        //vb.IDCT = MA_CTXetDuyet + (AbconBUS.DemSoLuongMaVanBan_CapDuyet() + 1).ToString();

                                        vb.Auditor = nodecon.Target;

                                        vb.pdno = phieu;
                                        vb.Gsbh = congty;
                                        vb.abtype = timvanban1.Abtype;
                                        vb.abps = int.Parse(nodecon.ImageToolTip);
                                        vb.cothutu = true;
                                        vb.Yn = 4;
                                        vb.abrult = false;
                                        vb.Maintitle = timvanban1.mytitle;
                                        vb.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                        vb.from_user = user;
                                        vb.from_depart = bophan;
                                        //vb.Abstep =int.Parse(chitiet.abstep.ToString());
                                        //vb.IDChiTiet = chitiet.IDChiTiet;
                                        //vb.kytoanbo = chitiet.KyToanBo;
                                        vb.Abstep = int.Parse(nodecon.NavigateUrl);
                                        vb.bixoa = false;
                                        vb.boqua = false;
                                        vb.IDCapDuyet = int.Parse(nodecon.ToolTip);
                                        //lstIdNguoiNhan.Add(node.Defuserid);
                                        // vb.Nhom = chitiet.Nhom;
                                        AbconBUS.ThemChiTiet(vb);
                                        ctxdlist.Add(vb);
                                    }
                                    else
                                    {
                                        Abcon vb = new Abcon();
                                        vb.IDCT = kiemtrabangabcon.IDCT;
                                        vb.Id_VB_CD = kiemtrabangabcon.Id_VB_CD;
                                        vb.Auditor = kiemtrabangabcon.Auditor;

                                        vb.pdno = kiemtrabangabcon.pdno;
                                        vb.Gsbh = kiemtrabangabcon.Gsbh;
                                        vb.abtype = kiemtrabangabcon.abtype;

                                        vb.cothutu = true;
                                        vb.Yn = 4;
                                        vb.abrult = false;
                                        vb.Maintitle = timvanban.mytitle;
                                        vb.ABC = kiemtrabangabcon.ABC;
                                        vb.from_user = kiemtrabangabcon.from_user;

                                        vb.from_depart = kiemtrabangabcon.from_depart;
                                        //vb.Abstep =int.Parse(chitiet.abstep.ToString());
                                        //vb.IDChiTiet = chitiet.IDChiTiet;
                                        //vb.kytoanbo = chitiet.KyToanBo;
                                        vb.Abstep = int.Parse(nodecon.NavigateUrl);
                                        vb.bixoa = false;
                                        vb.boqua = false;
                                        vb.abps = int.Parse(nodecon.ImageToolTip);
                                        vb.IDCapDuyet = kiemtrabangabcon.IDCapDuyet;
                                        AbconDAO.SuaChiTietXD(vb, true);
                                    }
                                }
                                else
                                {
                                    string bophan = Session["bp"].ToString();
                                    pdna timvanban = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                                    Abcon kiemtrabangabcon = AbconDAO.KiemTraPhieuTrongBangAbcon(phieu, congty, nodecon.Target);
                                    if (kiemtrabangabcon == null)
                                    {
                                        Abcon vb = new Abcon();

                                        //vb.IDCT = MA_CTXetDuyet + (AbconBUS.DemSoLuongMaVanBan_CapDuyet() + 1).ToString();
                                        //vb.Id_VB_CD = vbcd.ID;
                                        vb.Auditor = nodecon.Target;

                                        vb.pdno = phieu;
                                        vb.Gsbh = congty;
                                        vb.abtype = timvanban1.Abtype;
                                        vb.abps = int.Parse(nodecon.ImageToolTip);
                                        vb.cothutu = true;
                                        vb.Yn = 4;
                                        vb.abrult = false;
                                        vb.Maintitle = timvanban1.mytitle;
                                        vb.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                        vb.from_user = user;
                                        vb.from_depart = bophan;
                                        //vb.Abstep =int.Parse(chitiet.abstep.ToString());
                                        //vb.IDChiTiet = chitiet.IDChiTiet;
                                        //vb.kytoanbo = chitiet.KyToanBo;
                                        vb.Abstep = int.Parse(nodecon.NavigateUrl);
                                        vb.bixoa = false;
                                        vb.boqua = false;
                                        vb.IDCapDuyet = int.Parse(nodecon.ToolTip);
                                        //lstIdNguoiNhan.Add(node.Defuserid);
                                        // vb.Nhom = chitiet.Nhom;
                                        AbconBUS.ThemChiTiet(vb);
                                        ctxdlist.Add(vb);
                                    }
                                    else
                                    {
                                        Abcon vb = new Abcon();
                                        vb.IDCT = kiemtrabangabcon.IDCT;
                                        vb.Id_VB_CD = kiemtrabangabcon.Id_VB_CD;
                                        vb.Auditor = kiemtrabangabcon.Auditor;

                                        vb.pdno = kiemtrabangabcon.pdno;
                                        vb.Gsbh = kiemtrabangabcon.Gsbh;
                                        vb.abtype = kiemtrabangabcon.abtype;

                                        vb.cothutu = true;
                                        vb.Yn = 4;
                                        vb.abrult = false;
                                        vb.Maintitle = timvanban.mytitle;
                                        vb.ABC = kiemtrabangabcon.ABC;
                                        vb.from_user = kiemtrabangabcon.from_user;

                                        vb.from_depart = kiemtrabangabcon.from_depart;
                                        //vb.Abstep =int.Parse(chitiet.abstep.ToString());
                                        //vb.IDChiTiet = chitiet.IDChiTiet;
                                        //vb.kytoanbo = chitiet.KyToanBo;
                                        vb.Abstep = int.Parse(nodecon.NavigateUrl);
                                        vb.bixoa = false;
                                        vb.boqua = false;
                                        vb.abps = int.Parse(nodecon.ImageToolTip);
                                        vb.IDCapDuyet = kiemtrabangabcon.IDCapDuyet;
                                        AbconDAO.SuaChiTietXD(vb, true);
                                    }
                                }
                                // them chi tiet buoc ky
                                PDNSheetFlow chi = new PDNSheetFlow();
                                PDNSheetFlow chitiet = PDNSheetFlowDAO.TimMaPDNSheetFlow(phieu, congty, int.Parse(nodecon.NavigateUrl), int.Parse(nodecon.ImageToolTip));
                                if (chitiet == null)
                                {
                                    chi.pdno = phieu;
                                    chi.Yn = 4;
                                    chi.GSBH = congty;
                                    chi.ABPS = int.Parse(nodecon.ImageToolTip);
                                    chi.abstep = int.Parse(nodecon.NavigateUrl);
                                    chi.IdNguoiDuyet = nodecon.Target;
                                    PDNSheetFlowBUS.ThemPDNSheetFlow(chi);
                                }
                                else
                                { }
                                if (abstep == 1 && abps == 1)
                                {
                                   
                                    if (timnguoitao.IDCapDuyet >= 12)
                                    {
                                        string bophan = "CBCC";
                                        pdna timvanban = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                                        if (timvanban == null)
                                        {
                                            string noidung = Session["noidung"].ToString();
                                            string tieude = Session["tieude"].ToString();
                                            pdna phieun = new pdna();
                                            phieun.GSBH = congty;
                                            phieun.pdno = phieu;
                                            phieun.pddepid = bophan;
                                            phieun.mytitle = tieude;
                                            phieun.Abtype = timvanban1.Abtype;
                                            phieun.pdmemovn = noidung;
                                            phieun.CFMDate0 = DateTime.Today;
                                            phieun.USERID = user;
                                            //phieun.CFMID0 = user;
                                            phieun.CFMID0 = user;
                                            phieun.bixoa = false;
                                            phieun.dagui = true;
                                            phieun.YN = 4;
                                            phieun.USERDATE = DateTime.Today;
                                            phieun.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                            phieun.LevelDoing = 0;

                                            db.pdnas.InsertOnSubmit(phieun);
                                            db.SubmitChanges();
                                            //db.CapNhatPhieuTheoNguoiTao(phieun.pdno, phieun.GSBH, phieun.dagui, phieun.bixoa, phieun.YN, phieun.mytitle, phieun.pddepid, phieun.Abtype, phieun.pdmemovn, phieun.CFMDate0, phieun.USERID, phieun.CFMID0, phieun.USERDATE, phieun.ABC, phieun.LevelDoing);

                                            ABTrangThaiDuyet trangthai = new ABTrangThaiDuyet();
                                            trangthai.GSBH = congty;
                                            trangthai.pdno = phieu;
                                            trangthai.Yn = 4;
                                            TrangThaiDuyetDAO.ThemTrangThaiDuyet(trangthai);
                                        }
                                        else
                                        {
                                            pdna phieun = new pdna();
                                            phieun.GSBH = congty;
                                            phieun.pdno = phieu;
                                            phieun.pddepid = bophan;
                                            phieun.mytitle = timvanban.mytitle;
                                            phieun.Abtype = timvanban1.Abtype;
                                            phieun.pdmemovn = timvanban.pdmemovn;
                                            phieun.CFMDate0 = DateTime.Today;
                                            phieun.USERID = user;
                                            //phieun.CFMID0 = user;
                                            phieun.CFMID0 = user;
                                            phieun.bixoa = false;
                                            phieun.dagui = true;
                                            phieun.YN = 4;
                                            phieun.USERDATE = DateTime.Today;
                                            phieun.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                            phieun.LevelDoing = 0;
                                            phieun.CFMID1 = nodecon.Target;
                                            //pnaDAO.CapNhatVanBan(phieu, congty);
                                            db.CapNhatPhieuTheoNguoiTao(phieun.pdno, phieun.GSBH, phieun.dagui, phieun.bixoa, phieun.YN, phieun.mytitle, phieun.pddepid, phieun.Abtype, phieun.pdmemovn, phieun.CFMDate0, phieun.USERID, phieun.CFMID0, phieun.USERDATE, phieun.ABC, phieun.LevelDoing,phieun.CFMID1);
                                            DataTable dt = dal.KiemTraPhieutrongBangTrangThai(phieu, congty);
                                            if (dt.Rows.Count == 0)
                                            {
                                                ABTrangThaiDuyet trangthai = new ABTrangThaiDuyet();
                                                trangthai.GSBH = congty;
                                                trangthai.pdno = phieu;
                                                trangthai.Yn = 4;
                                                TrangThaiDuyetDAO.ThemTrangThaiDuyet(trangthai);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string bophan = Session["bp"].ToString();
                                        pdna timvanban = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                                        if (timvanban == null)
                                        {
                                            string noidung = Session["noidung"].ToString();
                                            string tieude = Session["tieude"].ToString();
                                            int abc = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                            pdna phieun = new pdna();
                                            phieun.GSBH = congty;
                                            phieun.pdno = phieu;
                                            phieun.pddepid = bophan;
                                            phieun.mytitle = tieude;
                                            phieun.Abtype = timvanban1.Abtype;
                                            phieun.pdmemovn = noidung;
                                            phieun.CFMDate0 = DateTime.Today;
                                            phieun.USERID = user;
                                            //phieun.CFMID0 = user;
                                            phieun.CFMID0 = user;
                                            phieun.bixoa = false;
                                            phieun.dagui = true;
                                            phieun.YN = 4;
                                            phieun.USERDATE = DateTime.Today;
                                            phieun.ABC = abc;
                                            phieun.LevelDoing = 0;

                                            db.pdnas.InsertOnSubmit(phieun);
                                            db.SubmitChanges();
                                            ABTrangThaiDuyet trangthai = new ABTrangThaiDuyet();
                                            trangthai.GSBH = congty;
                                            trangthai.pdno = phieu;
                                            trangthai.Yn = 4;
                                            TrangThaiDuyetDAO.ThemTrangThaiDuyet(trangthai);
                                        }
                                        else
                                        {
                                            int abc = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                            pdna phieun = new pdna();
                                            phieun.GSBH = congty;
                                            phieun.pdno = phieu;
                                            phieun.pddepid = bophan;
                                            phieun.mytitle = timvanban.mytitle;
                                            phieun.Abtype = timvanban1.Abtype;
                                            phieun.pdmemovn = timvanban.pdmemovn;
                                            phieun.CFMDate0 = DateTime.Today;
                                            phieun.USERID = user;
                                            //phieun.CFMID0 = user;
                                            phieun.CFMID0 = user;
                                            phieun.bixoa = false;
                                            phieun.dagui = true;
                                            phieun.YN = 4;
                                            phieun.USERDATE = DateTime.Today;
                                            phieun.ABC = abc;
                                            phieun.LevelDoing = 1;
                                            phieun.CFMID1 = nodecon.Target;
                                            db.CapNhatPhieuTheoNguoiTao(phieun.pdno, phieun.GSBH, phieun.dagui, phieun.bixoa, phieun.YN, phieun.mytitle, phieun.pddepid, phieun.Abtype, phieun.pdmemovn, phieun.CFMDate0, phieun.USERID, phieun.CFMID0, phieun.USERDATE, phieun.ABC, phieun.LevelDoing,phieun.CFMID1);
                                            //pnaDAO.CapNhatVanBan(phieu, congty);
                                            //pnaDAO.UpdatePDNA(phieun);

                                            DataTable dt = dal.KiemTraPhieutrongBangTrangThai(phieu, congty);
                                            if (dt.Rows.Count == 0)
                                            {
                                                ABTrangThaiDuyet trangthai = new ABTrangThaiDuyet();
                                                trangthai.GSBH = congty;
                                                trangthai.pdno = phieu;
                                                trangthai.Yn = 4;
                                                TrangThaiDuyetDAO.ThemTrangThaiDuyet(trangthai);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                   
                        pdna timphieun = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                        Busers2 timnhanvientao = UserBUS.TimNhanVienTheoMa(user, congty);
                        Task temp1 = Task.Factory.StartNew(() => Until.TrinhDuyet(timphieun.pdno, timphieun, timnhanvientao, congty));

                        //temp1.ContinueWith(t => HideProgressPanel(cutstr));
                        if (temp1 != null)
                        {
                            //lbThongBaoTrinhDuyet.Text = "审核成功，单据会寄到呈请人通过邮件及系统";
                            string ngonngu = Session["languege"].ToString();
                            // string idnguoiduyet = Session["idnguoiduyet"].ToString();
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBaoTrinhDuyet.Text = "Trình duyệt thành công, Hệ thống sẽ gửi tin nhắn qua mail cho người duyệt";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBaoTrinhDuyet.Text = "审核成功，单据会寄到呈请人通过邮件及系统";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBaoTrinhDuyet.Text = " Approval success";
                            }
                        }
                        temp1.Wait();
                        btnChiTiet.Enabled = true;
                        btnChiTiet.Attributes.Add("opacity", "0.5");
                        btnTrinhDuyet.Enabled = false;
                        Button1.Enabled = false;
                        btnTrinhDuyet.Attributes.CssStyle.Add("opacity", "0.5");

                    }
                    catch (TimeoutException )
                    {
                        //foreach (Abcon ct in ctxdlist)
                        //{
                        //    AbconBUS.XoaChiTiet(ct.IDCT, false);
                        //}


                        //pdnaBUS.XoaVanBan(phieudn, false);
                        // Until.WriteFileLogServer(Until.uNhanVien.USERNAME + "\tTạo văn bản\t" + phieudn.pdno + "\tThất bại.");
                        //LbThongBao.Text = "处理过程发生错误" + ex.Message;
                        throw;
                    }

                }


                catch (Exception )
                {
                    //foreach (Abcon ct in ctxdlist)
                    //{
                    //    AbconBUS.XoaChiTiet(ct.IDCT, false);
                    //}


                    //pdnaBUS.XoaVanBan(phieudn, false);
                    // Until.WriteFileLogServer(Until.uNhanVien.USERNAME + "\tTạo văn bản\t" + phieudn.pdno + "\tThất bại.");
                    //LbThongBao.Text = "处理过程发生错误" + ex.Message;
                    throw;
                }

            }
            else
            {
                LbThongBao.Text = "Error. Please setting PDN";
                btnChiTiet.Enabled = false;
                btnTrinhDuyet.Enabled = false;
                Button1.Enabled = true;
                btnTrinhDuyet.Attributes.CssStyle.Add("opacity", "0.5");
            }
        }

        protected void btnChiTiet_Click(object sender, EventArgs e)
        {
            
            string maloaiphieu = Session["loaiphieu"].ToString();
            if (maloaiphieu != null && maloaiphieu == "PDN2")
            {
                Response.Redirect("frmchitietphieumuahang.aspx");
            }
            else
            {
                Response.Redirect("frmChiTiet.aspx");
            }
        }

        protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                //TreeNode aa = e.Node;
                TreeNode nutgoc = new TreeNode("审核名单");


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmViewCB.aspx");
        }
    }
}