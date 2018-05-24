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
namespace iOffice.presentationLayer.Users
{
    public partial class frmTrinhDuyet : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();

     
        public static String MA_VB_CD = "VBCD";
        Busers2 nguoiduyet1 = new Busers2();
        string aa = "1";
        int dem = 0;
        int abstepTemp = 0;
        int abpsTemp = 0;
        List<QPDNFlow> lsquytrinh = new List<QPDNFlow>();
        List<QPDNFlow> lsQuytrinh1 = new List<QPDNFlow>();
      
        
        // List<ChiTietLoaiPhieu> lvb1 = new List<ChiTietLoaiPhieu>();
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
        quytrinhDal dal = new quytrinhDal();
        abconDAL dalP = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }

            if (!IsPostBack)
            {
                btnChiTiet.Enabled = false;
                btnChiTiet.Attributes.Add("opacity", "0.5");
                reloadTreeView();
                HienThiDoUuTien();
            }
            TreeView2.Enabled = false;
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
            string congty = Session["congty"].ToString();
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
        public void reloadTreeView()
        {
            string maloai = Session["loaiphieu"].ToString();
            string maloaiphieu = "PDN1";
            string mabophan = Session["bp"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["UserID"].ToString();
            // string idnguoiduyet = Session["idnguoiduyet"].ToString();
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
                        //DataTable dtNghi=dal.TimKiemKhiVangMat(
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
                                tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                            tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                            tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                            tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                            childNode.ChildNodes.Add(tnChildNode);
                            listnguoi.Add(nguoiduyet.USERID);
                        }
                    }
                }// Neu <0 thi dung quy trinh All
                else
                {
                    string maDVAll = "All";
                    List<QPDNFlow> listAll = QPDNFlowDAO.QryQuyTrinhAll(maDVAll, macongty, maloai);
                    if(listAll.Count>0)
                    {
                        foreach (QPDNFlow quytrinh in listAll)
                        {
                            if (quytrinh.NguoiDuyet == "ZZZZZZ")
                            {
                                Busers2 timCQ = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
                                if (timCQ != null)
                                {
                                    Busers2 timnguoiduyet = UserBUS.TimNhanVienTheoMa(timCQ.IdUserQuanLyTT, macongty);
                                    if (timnguoiduyet != null)
                                    {
                                        ChucVu chucvu = ChucVuBUS.TimMaChucVu(timnguoiduyet.IDChucVu, macongty);
                                        DateTime ngay = DateTime.Today;

                                        ABJobAgent nghi = NghiPhepDAO.KiemTraNguoiNghi(ngay,ngay, timnguoiduyet.USERID, macongty);
                                        if (nghi != null )
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
                                                tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                                tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                            tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                            tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                            tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                            childNode.ChildNodes.Add(tnChildNode);
                                            listnguoi.Add(nguoiduyet.USERID);
                                        }
                                    }
                                }
                            }// Nguoc lai neu nguoi duyet khac ZZZZZZ
                            else
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
                                        tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                        tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                        tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                            tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                            tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                    childNode.ChildNodes.Add(tnChildNode);
                                    listnguoi.Add(nguoiduyet.USERID);
                                }
                            }
                        }
                    }
                }

            }// nguoc lai lay  quy trinh > nguoi tao phieu
            else
            {
                if (timNguoiTheoQT.ABPS == 1)
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
                                    tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                        tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                        tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                        tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                childNode.ChildNodes.Add(tnChildNode);
                                listnguoi.Add(nguoiduyet.USERID);
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
                                        tnChildNode.ToolTip = chucvu.IDCapDuyet.ToString();
                                        tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                        tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                            tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                            tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
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
                                    tnChildNode.NavigateUrl = quytrinh.ABstep.ToString();
                                    tnChildNode.ImageToolTip = quytrinh.ABPS.ToString();
                                    tnChildNode.ImageUrl = quytrinh.DonViThongQua;
                                    childNode.ChildNodes.Add(tnChildNode);
                                    listnguoi.Add(nguoiduyet.USERID);
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
                
            }
            TreeView2.ExpandAll();
        }
        protected void TreeView1_SelectedNodeChanged(object sender, TreeNodeEventArgs e)
        {
            try
            {
                TreeNode aa = e.Node;
                TreeNode nutgoc = new TreeNode("审核名单");


            }
            catch (Exception)
            {

                throw;
            }
        }
        #region huy
        //protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
        //{

        //}

        //protected void OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = GridView1.SelectedRow;
        //    string manvchon = row.Cells[0].Text;
        //    string tennvchon = row.Cells[1].Text;
        //    string email = row.Cells[2].Text;
        //    string bophan = row.Cells[3].Text;
        //    string bp = Session["bp"].ToString();
        //    nguoiduyet1 = UserBUS.QryNguoiDuyetTheoBoPhanCapDuyet1(bp);
        //    string chucvuchon = row.Cells[4].Text;
        //    Session["manvchon"] = manvchon;
        //    string a="1";
        //    if (rdTaoMoiQuyTrinh.Checked ==true && m_DungMau==1)
        //    {
        //        if (ctxds.Keys.Contains("Người duyệt" + manvchon))
        //        {
        //            return;
        //        }
        //        if (TreeView1.Nodes.Count == 0)
        //        {
        //            TreeNode parentNote = new TreeNode(str13);
        //            parentNote.Text = "List users browsing";

        //        }
        //        TreeNode childNode = new TreeNode(str14 + (TreeView1.Nodes[0].ChildNodes.Count + 1) + "-" + chucvuchon);
        //        childNode.Text = "Level(浏览级别)" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);

        //        childNode.Value = (TreeView1.Nodes[0].ChildNodes.Count + 1).ToString();
        //        //if (childNode.Value == "1")
        //        //{
        //        //    TreeNode tnnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //        //    tnnChildNode.Text = nguoiduyet1.USERNAME;
        //        //    //tnChildNode.Target = Session["manvchon"].ToString();
        //        //    tnnChildNode.Value = a;

        //        //    lstIdNguoiNhan.Add(nguoiduyet1.USERID);
        //        //    childNode.ChildNodes.Add(tnnChildNode);
        //        //}
        //        TreeView1.Nodes[0].ChildNodes.Add(childNode);

        //        PDNA_ABDE vbcd = new PDNA_ABDE();
        //        vbcd.ABJOB = chucvuchon;
        //        vb_cds.Add(childNode.Text, vbcd);

        //        TreeNode tnChildNode = new TreeNode("" + tennvchon);
        //        tnChildNode.Text =  tennvchon;
        //        tnChildNode.Target = Session["manvchon"].ToString();
        //        tnChildNode.Value =a ;
        //       // tnChildNode.Value = (TreeView1.Nodes[0].ChildNodes.Count + 1).ToString();
        //        lstIdNguoiNhan.Add(manvchon);
        //        childNode.ChildNodes.Add(tnChildNode);
        //       // TreeView1.Nodes[0].ChildNodes.Add(tnChildNode);
        //        TreeView1.ExpandAll();
        //        Abcon ct = new Abcon();
        //        ct.Auditor = manvchon;
        //        ct.Abstep = 1;
        //        ctxds.Add(tnChildNode.Text, ct);

        //    }
        //    else if (rdDungQuyTrinhMau.Checked && m_DungMau==2)
        //    {
        //        if (ctxds.Keys.Contains("Người duyệt" + manvchon))
        //        {
        //            return;
        //        }
        //        if (TreeView2.Nodes.Count == 0)
        //        {
        //            TreeNode parrentNode = new TreeNode(str1);
        //            parrentNode.Text = "List users browsing";
        //            TreeView2.Nodes.Add(parrentNode);
        //        }
        //        TreeNode childNode = new TreeNode(tennvchon);
        //        childNode.Text = manvchon;
        //        lstIdNguoiNhan.Add(manvchon);
        //        TreeView2.Nodes[0].ChildNodes.Add(childNode);
        //        TreeView2.ExpandAll();
        //        if (TreeView1.Nodes.Count == 0)
        //        {
        //            TreeNode parrentNode = new TreeNode(str1 + "(0)");
        //            parrentNode.Text = "List users browsing";
        //            TreeView2.Nodes.Add(parrentNode);
        //        }
        //        else
        //            TreeView2.Nodes[0].Text = str1 + "(" + TreeView1.Nodes[0].ChildNodes.Count + ")";
        //    }


        //    #region ABC
        //    //foreach (string str in lstIdNguoiNhan)
        //    //{
        //    //    if (str.Equals(manvchon))
        //    //    {
        //    //        // MessageBox.Show(this, tenNhanVienChon + str38, Util.strThongBao, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //        return;
        //    //    }
        //    //}

        //    //if (TreeView1.Nodes.Count == 0)
        //    //{
        //    //    TreeNode parentNode = new TreeNode(str1);
        //    //    parentNode.Text = "parentNode";
        //    //    TreeView1.Nodes.Add(parentNode);
        //    //}
        //    //TreeNode childNode = new TreeNode(tennvchon);
        //    //childNode.Text = manvchon;
        //    ////childNode.Tag = idNhanVienChon;
        //    //lstIdNguoiNhan.Add(manvchon);
        //    //TreeView1.Nodes[0].ChildNodes.Add(childNode);
        //    //TreeView1.ExpandAll();
        //    //if (TreeView1.Nodes.Count == 0)
        //    //{
        //    //    TreeNode parentNode = new TreeNode(str1 + "(0)");
        //    //    parentNode.Text = "parentNode";
        //    //    TreeView1.Nodes.Add(parentNode);
        //    //}
        //    //else
        //    //    TreeView1.Nodes[0].Text = str1 + "(" + TreeView1.Nodes[0].ChildNodes.Count + ")";
        //    #endregion
        //}
        #endregion
        protected void btnTrinhDuyet_Click(object sender, EventArgs e)
        {
         
            List<Abcon> ctxdlist = new List<Abcon>();
          

            pdna phieudn = new pdna();
            try
            {
                if (TreeView2.Nodes[0].ChildNodes.Count > 0)
                {
                    string maloai = Session["loaiphieu"].ToString();
                    string phieu = Session["maphieu"].ToString();
                    DateTime date = DateTime.Now;
                    //string ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    string bophan = Session["bp"].ToString();

                    string congty = Session["congty"].ToString();
                    string user = Session["user"].ToString();

                    string douutien = DropUutien.SelectedValue.ToString();
                   // Session["ngaythang"] = ngaythang;

                   
                    try
                    {
                        
                        //for (int i = 0; i < TreeView2.Nodes[0].ChildNodes.Count; i++)
                        pdna timvanban = pnaDAO.TimVanBanTheoMa(phieu, congty, true);
                        pdna phieun = new pdna();
                        for (int i = 0; i < TreeView2.Nodes[0].ChildNodes.Count; i++)
                        {
                            TreeNode tn = TreeView2.Nodes[0].ChildNodes[i];


                            foreach (TreeNode nodecon in tn.ChildNodes)
                            {
                                dem = int.Parse(nodecon.Value) + dem;
                                int abstep=int.Parse(nodecon.NavigateUrl);
                                int abps=int.Parse(nodecon.ImageToolTip);
                                Busers2 user1 = UserBUS.TimNhanVienTheoMa(nodecon.Target, congty);

                                Abcon vb = new Abcon();

                                Abcon kiemtrabangabcon = AbconDAO.KiemTraPhieuTrongBangAbcon(phieu, congty, nodecon.Target);
                                if (kiemtrabangabcon == null)
                                {
                                    string tieude = timvanban.mytitle;
                                    //vb.IDCT = MA_CTXetDuyet + (AbconBUS.DemSoLuongMaVanBan_CapDuyet() + 1).ToString();
                                    // vb.Id_VB_CD = vbcd.ID;
                                    vb.Auditor = nodecon.Target;

                                    vb.pdno = phieu;
                                    vb.Gsbh = congty;
                                    vb.abtype = maloai;

                                    vb.cothutu = true;
                                    vb.Yn = 4;
                                    vb.abrult = false;
                                    vb.Maintitle = tieude;
                                    vb.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                    vb.from_user = user;
                                    vb.from_depart = bophan;
                                    //vb.Abstep =int.Parse(chitiet.abstep.ToString());
                                    //vb.IDChiTiet = chitiet.IDChiTiet;
                                    //vb.kytoanbo = chitiet.KyToanBo;
                                    vb.Abstep = int.Parse(nodecon.NavigateUrl);
                                    vb.bixoa = false;
                                    vb.boqua = false;
                                    vb.ncancel = 0;
                                    vb.abps = int.Parse(nodecon.ImageToolTip);
                                    //vb.Donvithongqua = nodecon.ImageUrl;
                                    vb.IDCapDuyet = int.Parse(nodecon.ToolTip);

                                    //lstIdNguoiNhan.Add(node.Defuserid);
                                    // vb.Nhom = chitiet.Nhom;
                                    AbconBUS.ThemChiTiet(vb);
                                    ctxdlist.Add(vb);
                                }
                                else
                                {
                                    vb.IDCT = kiemtrabangabcon.IDCT;
                                    //vb.Id_VB_CD = kiemtrabangabcon.Id_VB_CD;
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
                                    vb.ncancel = 0;
                                    vb.abps = int.Parse(nodecon.ImageToolTip);
                                    // vb.Donvithongqua = nodecon.ImageUrl;
                                    vb.IDCapDuyet = kiemtrabangabcon.IDCapDuyet;
                                    AbconDAO.SuaChiTietXD(vb, true);
                                }
                                // them chi tiet buoc ky
                                PDNSheetFlow chi = new PDNSheetFlow();
                                PDNSheetFlow chitiet = PDNSheetFlowDAO.TimMaPDNSheetFlow(phieu, congty, int.Parse(nodecon.NavigateUrl), int.Parse(nodecon.ImageToolTip));
                                if (chitiet == null)
                                {
                                    chi.pdno = phieu;
                                    chi.Yn = 4;
                                    chi.GSBH = congty;
                                    chi.abstep = int.Parse(nodecon.NavigateUrl);
                                    chi.ABPS = int.Parse(nodecon.ImageToolTip);
                                    chi.IdNguoiDuyet = nodecon.Target;
                                    PDNSheetFlowBUS.ThemPDNSheetFlow(chi);
                                }
                                else
                                {
                                    return;
                                }
                                // them bang van ban den 
                                if (abstep == 1 && abps == 1)
                                {
                                    
                                   
                                    if (timvanban == null)
                                    {
                                        string noidung = Session["noidung"].ToString();
                                        string tieude = Session["tieude"].ToString();
                                        phieun.GSBH = congty;
                                        phieun.pdno = phieu;
                                        phieun.pddepid = bophan;
                                        phieun.pdDate = DateTime.Today;
                                        phieun.mytitle = tieude;
                                        phieun.Abtype = maloai;
                                        phieun.pdmemovn = noidung;
                                        phieun.CFMDate0 = DateTime.Today;
                                        phieun.USERID = user;
                                        //phieun.CFMID0 = user;
                                        phieun.CFMID0 = user;
                                        phieun.bixoa = false;
                                        phieun.dagui = true;

                                        phieun.USERDATE = DateTime.Today;
                                        phieun.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                        phieun.LevelDoing = 1;
                                        phieun.CFMID1 = nodecon.Target;
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
                                        phieun.GSBH = timvanban.GSBH;
                                        phieun.pdno = timvanban.pdno;
                                        phieun.pddepid = bophan;
                                        phieun.pdDate = DateTime.Today;
                                        phieun.mytitle = timvanban.mytitle;
                                        phieun.Abtype = maloai;
                                        phieun.pdmemovn = timvanban.pdmemovn;

                                        phieun.NoiDungDich = timvanban.NoiDungDich;
                                        phieun.CFMDate0 = DateTime.Today;
                                        phieun.USERID = user;
                                        //phieun.CFMID0 = user;
                                        phieun.CFMID0 = user;
                                        phieun.bixoa = false;
                                        phieun.dagui = true;
                                        phieun.YN = 4;
                                        phieun.USERDATE = DateTime.Today;
                                        phieun.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                                        phieun.LevelDoing = 1;
                                        phieun.CFMID1 = nodecon.Target;
                                        //pnaDAO.UpdatePDNA(phieun);
                                        db.CapNhatPhieuTrinhDuyet(phieun.pdno, phieun.GSBH, phieun.dagui, phieun.bixoa, phieun.YN, phieun.mytitle, phieun.pddepid, phieun.Abtype, phieun.pdmemovn, phieun.CFMDate0, phieun.USERID, phieun.CFMID0, phieun.USERDATE, phieun.ABC, phieun.LevelDoing, phieun.NoiDungDich,phieun.CFMID1);
                                        //db.SubmitChanges();
                                        DataTable dt = dalP.KiemTraPhieutrongBangTrangThai(phieu, congty);
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

                        Busers2 timnhanvientao = UserBUS.TimNhanVienTheoMa(user, congty);
                        Task temp1 = Task.Factory.StartNew(() => Until.TrinhDuyet(phieun.pdno, phieun, timnhanvientao, congty));


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
                        // LbThongBao.Text = "处理过程发生错误" + ex.Message;
                        throw;
                    }
                }
                else
                {
                    
                    LbThongBao.Text = "Error. Please setting PDN";
                    btnChiTiet.Visible = false;
                    btnTrinhDuyet.Enabled = false;
                    btnTrinhDuyet.Attributes.CssStyle.Add("opacity", "0.5");
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
               // LbThongBao.Text = "处理过程发生错误" + ex.Message;
                throw;

            }
            
        }

        protected void btnChiTiet_Click(object sender, EventArgs e)
        {
          
            string maloaiphieu = Session["loaiphieu"].ToString();
            if (maloaiphieu != null && maloaiphieu == "PDN2")
            {
                Response.Redirect("frmchitietphieumuahangNV.aspx");
            }
            else
            {
                Response.Redirect("frmDetailsNV.aspx");
            }

        }

        protected void OnSelectedInexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmView.aspx");
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



    }
}