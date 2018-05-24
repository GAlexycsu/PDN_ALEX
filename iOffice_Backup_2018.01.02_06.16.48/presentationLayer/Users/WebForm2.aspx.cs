using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Users
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<ChiTietLoaiPhieu> lvb = new List<ChiTietLoaiPhieu>();
        List<ChiTietLoaiPhieu> lvb1 = new List<ChiTietLoaiPhieu>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // reloadTreeView();
            }
        }
        //public void reloadTreeView()
        //{
        //    //string maloai = Session["loaiphieu"].ToString();
        //    //string phieu = Session["maphieu"].ToString();
        //    //string bophan = Session["bp"].ToString();
        //    //string congty = Session["congty"].ToString();
        //    string maloai = "PDN1";
        //    string a = "1";
        //     string macongty = "LTY";
        //    // string idnguoiduyet = Session["idnguoiduyet"].ToString();
        //    if (TreeView2.Nodes.Count == 0)
        //    {
        //        TreeNode parentNote = new TreeNode("List users browsing");
        //        parentNote.Text = "List users browsing";

        //    }



        //    TreeView2.Nodes.Clear();
        //    lvb1 = ChiTietLoaiPhieuBUS.LayDanhSachChiTietLoaiPhieu();
        //    #region and
        //    lvb = ChiTietLoaiPhieuBUS.LayDanhSachLoaiChiTietTheoMaLoaiPhieu(maloai);


        //    TreeNode parentNode = new TreeNode("");
        //    parentNode.Text = "审核名单";
        //    TreeView2.Nodes.Add(parentNode);
        //    foreach (ChiTietLoaiPhieu loaivb in lvb)
        //    {
        //        ChucVu chucvu = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);

        //        TreeNode childNode = new TreeNode(loaivb.IDCT.ToString());
        //        childNode.Value = loaivb.IDCT.ToString();
        //        //childNode.Text = "Level" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);
        //        childNode.Text = "Level" + ":" + chucvu.TenChucVu;
        //        childNode.Target = loaivb.IDNguoiKy;
        //        parentNode.ChildNodes.Add(childNode);
        //        if (loaivb.DonViThongQua == null)
        //        {
        //            string madonvi = "VTY03";
        //            //string macongty = "LTY";
        //            BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
        //            if (loaivb.IDLoaiNguoiKy == 2)
        //            {
        //                Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);
        //                TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                tnChildNode.Text = nguoichuquan.USERNAME;
        //                tnChildNode.Target = nguoichuquan.USERID;
        //                tnChildNode.Value = a;

        //                //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                childNode.ChildNodes.Add(tnChildNode);
        //            }
        //            if (loaivb.IDLoaiNguoiKy == 3)
        //            {
        //                ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                List<Buser> DanhSachNguoiDuyet = UserBUS.LayDanhSachNguoiDuyetTheoMaChucVu(chuc.IDChucVu);
        //                foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                {
        //                    Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty);
        //                    if (nguoiduyet1 == null)
        //                    {
        //                        Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, madonvi, macongty);
        //                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                        tnChildNode.Text = nguoiduyet2.USERNAME;
        //                        tnChildNode.Target = nguoiduyet2.USERID;
        //                        tnChildNode.Value = a;

        //                        //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                    }
        //                    else
        //                    {
        //                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                        tnChildNode.Text = nguoiduyet1.USERNAME;
        //                        tnChildNode.Target = nguoiduyet1.USERID;
        //                        tnChildNode.Value = a;

        //                        //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                    }
        //                }
        //            }
        //            if (loaivb.IDLoaiNguoiKy == 4)
        //            {
        //                Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                tnChildNode.Text = nguoiduyet.USERNAME;
        //                tnChildNode.Target = nguoiduyet.USERID;
        //                tnChildNode.Value = a;

        //                //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                childNode.ChildNodes.Add(tnChildNode);
        //            }
        //        }
        //        else
        //        {
        //           // string macongty = "LTY";
        //            //string madonvi = "VTYL02";
                    
        //            BDepartment bophan = BDepartmentBUS.TimMaDonVi(loaivb.DonViThongQua,macongty);
        //            if (loaivb.IDLoaiNguoiKy == 2)
        //            {
        //                Buser nguoichuquan = UserBUS.SearchUserByID(bophan.IdUserChuQuan, true);
        //                TreeNode tnChildNode = new TreeNode("" + nguoichuquan.USERNAME);
        //                tnChildNode.Text = nguoichuquan.USERNAME;
        //                tnChildNode.Target = nguoichuquan.USERID;
        //                tnChildNode.Value = a;

        //                //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                childNode.ChildNodes.Add(tnChildNode);
        //            }
        //            if (loaivb.IDLoaiNguoiKy == 3)
        //            {
        //                ChucVu chuc = ChucVuBUS.TimMaChucVu(loaivb.IDChucVu, macongty);
        //                List<Buser> DanhSachNguoiDuyet = UserBUS.LayDanhSachNguoiDuyetTheoMaChucVu(chuc.IDChucVu);
        //                foreach (Buser nguoi in DanhSachNguoiDuyet)
        //                {
        //                    Buser nguoiduyet1 = UserBUS.LayNguoiDuyetTheoMaChucVuCao(nguoi.IDChucVu, nguoi.USERID, macongty);
        //                    if (nguoiduyet1 == null)
        //                    {
        //                        Buser nguoiduyet2 = UserBUS.LayNguoiDuyetTheoMaChucVuPhongBan(nguoi.IDChucVu, loaivb.DonViThongQua, macongty);
        //                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet2.USERNAME);
        //                        tnChildNode.Text = nguoiduyet2.USERNAME;
        //                        tnChildNode.Target = nguoiduyet2.USERID;
        //                        tnChildNode.Value = a;

        //                        //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                    }
        //                    else
        //                    {
        //                        TreeNode tnChildNode = new TreeNode("" + nguoiduyet1.USERNAME);
        //                        tnChildNode.Text = nguoiduyet1.USERNAME;
        //                        tnChildNode.Target = nguoiduyet1.USERID;
        //                        tnChildNode.Value = a;

        //                        //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                        childNode.ChildNodes.Add(tnChildNode);
        //                    }
        //                }
        //            }
        //            if (loaivb.IDLoaiNguoiKy == 4)
        //            {
        //                Buser nguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(loaivb.IDNguoiCoDinh, macongty);
        //                TreeNode tnChildNode = new TreeNode("" + nguoiduyet.USERNAME);
        //                tnChildNode.Text = nguoiduyet.USERNAME;
        //                tnChildNode.Target = nguoiduyet.USERID;
        //                tnChildNode.Value = a;

        //                //lstIdNguoiNhan.Add(laynguoiduyet.USERID);
        //                childNode.ChildNodes.Add(tnChildNode);
        //            }
        //        }
              
        //    }
        //    TreeView2.ExpandAll();
        //    #endregion

        //}
    }
}