using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using System.EnterpriseServices;
namespace iOffice.presentationLayer.Users
{
    public partial class test3 : System.Web.UI.Page
    {
        iOfficeDataContext db = new iOfficeDataContext();
       
        string phong = "VTY03";
        private static String MA_CTXetDuyet = "CTXD";
        private string  str13 = "", str14 = "";
        Dictionary<String, Abcon> ctxds = new Dictionary<String, Abcon>(); // Tạo mới ctxd
        List<abill1> dschucvu = new List<abill1>();
        List<string> lstIdNguoiNhan = new List<string>();
        List<Abcon> lvb = new List<Abcon>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiNhanVien();
            }
        }
        private void HienThiNhanVien()
        {
            
                GridView1.DataSource = UserBUS.LayDanhSachNguoiDuyet(phong);
                GridView1.DataBind();
           
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
             GridViewRow row = GridView1.SelectedRow;
             string manvchon = row.Cells[0].Text;
             string tennvchon = row.Cells[1].Text;
             string chucvuchon = row.Cells[2].Text;
             if (TreeView1.Nodes.Count == 0)
             {
                 TreeNode parentNote = new TreeNode(str13);
                 parentNote.Text = "parentNode";

             }
             TreeNode childNode = new TreeNode(str14 + (TreeView1.Nodes[0].ChildNodes.Count + 1) + "-" + tennvchon);
             childNode.Text = "Cap" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);

             childNode.Value = (TreeView1.Nodes[0].ChildNodes.Count + 1).ToString();
             TreeView1.Nodes[0].ChildNodes.Add(childNode);
             TreeNode tnChildNode = new TreeNode("" + tennvchon);

             tnChildNode.Text = "NhanVien:" + tennvchon;

             childNode.ChildNodes.Add(tnChildNode);
             Abcon ct = new Abcon();
             ct.Auditor = manvchon;
             ct.Abstep = 1;
             ctxds.Add(tnChildNode.Text, ct);
            
        }
        public void reloadTreeView()
        {
            string maloai=Session["loaiphieu"].ToString();
            string phieu = Session["maphieu"].ToString();
            ctxds.Clear();
            TreeView1.Nodes.Clear();
            lvb = AbconBUS.LayDSLoaiVanBan_CapDuyet(maloai, true);
            dschucvu=abill1BUS.ListAbill1();
            TreeNode parentNode = new TreeNode(str13);
            parentNode.Text = "parentNode";
            TreeView1.Nodes.Add(parentNode);
            foreach (Abcon loaivb in lvb)
            {
                TreeNode childNode = new TreeNode(loaivb.abde.ToString() + "-" + loaivb.Auditor.ToString());
                childNode.Value = loaivb.abde.ToString();
                childNode.Text = "Cấp" + ":" + (TreeView1.Nodes[0].ChildNodes.Count + 1);
                parentNode.ChildNodes.Add(childNode);
                Abcon vbcd = new Abcon();
                vbcd.abde = loaivb.abde;
                vbcd.pdno = phieu;
                vbcd.cothutu = loaivb.cothutu;
                ctxds.Add(childNode.Text, vbcd);
            }
            TreeView1.ExpandAll();
        }

        protected void btnTrinhDuyet_Click(object sender, EventArgs e)
        {
            List<Abcon> ctxdlist = new List<Abcon>();
             pdna phieudn = new pdna();
             try
             {
                 string maloai = Session["loaiphieu"].ToString();
                 string phieu = Session["maphieu"].ToString();
                 string bophan = Session["bp"].ToString();
                 string noidung = Session["noidung"].ToString();
                 string tieude = Session["tieude"].ToString();
                 string congty = Session["congty"].ToString();
                 string user = Session["user"].ToString();


                 //string ngaytao = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                 pdna phieun = new pdna();
                 {
                     phieun.GSBH = congty;
                     phieun.pdno = phieu;
                     phieun.pddepid = bophan;
                     phieun.mytitle = tieude;
                     phieun.pdmemovn = noidung;
                     phieun.CFMDate0 = DateTime.Parse(DateTime.Now.ToShortDateString());
                     phieun.USERID = user;
                     phieun.CFMID0 = user;
                     phieun.bixoa = false;
                     phieun.YN = 0;
                     phieun.USERDATE = DateTime.Parse(DateTime.Now.ToShortDateString());
                     phieun.ABC = Convert.ToInt32(DropUutien.SelectedValue.ToString());
                     phieun.LevelDoing = 1;
                 }
                 db.pdnas.InsertOnSubmit(phieun);
                 db.SubmitChanges();
                 for (int i = 0; i < TreeView1.Nodes[0].ChildNodes.Count; i++)
                 {
                     TreeNode tn = TreeView1.Nodes[0].ChildNodes[i];
                     tn.Value = (i + 1).ToString();

                     foreach (TreeNode node in tn.ChildNodes)
                     {
                         Abcon vb = new Abcon();
                         if (ctxds.TryGetValue(tn.Text, out vb))
                         {
                            // vb.IDCT = MA_CTXetDuyet + (AbconBUS.DemSoLuongMaVanBan_CapDuyet() + 1).ToString();
                             vb.abde = int.Parse(tn.Value.ToString());
                             vb.pdno = phieu;
                             vb.cothutu = true;
                             vb.Abstep = int.Parse(tn.Value.ToString());
                             AbconBUS.ThemChiTiet(vb);
                             ctxdlist.Add(vb);
                         }
                     }
                 }
                 foreach (string str in lstIdNguoiNhan)
                 {
                     Abcon temp = AbconBUS.TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(phieudn.pdno, str, phieudn.CFMID0, false);
                     string manguoidung = Session["user"].ToString();
                     string macongty = Session["congty"].ToString();
                     Busers2 nguoi = UserBUS.TimNhanVienTheoMa(manguoidung,macongty);
                     if (temp != null)
                         continue;
                     Abcon vbd = new Abcon();
                     vbd.from_user = nguoi.USERID;
                     vbd.Auditor = str;
                     //vbd.pdnoreceived = phieudn.pdno;
                     vbd.from_depart = phieudn.pddepid;
                     vbd.bixoa = true;
                     AbconBUS.ThemChiTiet(vbd);
                 }

             }
             catch (TimeoutException ex)
             {
                 foreach (Abcon ct in ctxdlist)
                 {
                     AbconBUS.XoaChiTiet(ct.IDCT, false);
                 }
                 string manguoidung = Session["user"].ToString();
                 string macongty = Session["congty"].ToString();
                 Busers2 nguoi = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);

                 pdnaBUS.XoaVanBan(phieudn, false);
                 Until.WriteFileLogServer(nguoi.USERNAME + "\tTạo văn bản\t" + phieudn.pdno + "\tThất bại.");
                 LbThongBao.Text = "Lỗi trong quá trình xử lý";
             }
             catch (Exception)
             {
                 foreach (Abcon ct in ctxdlist)
                 {
                     AbconBUS.XoaChiTiet(ct.IDCT, false);
                 }

                 string manguoidung = Session["user"].ToString();
                 string macongty = Session["congty"].ToString();
                 Busers2 nguoi = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
                 pdnaBUS.XoaVanBan(phieudn, false);
                 Until.WriteFileLogServer(nguoi.USERNAME + "\tTạo văn bản\t" + phieudn.pdno + "\tThất bại.");
                 LbThongBao.Text = "Lỗi trong quá trình xử lý";
             }
        }
    }
}