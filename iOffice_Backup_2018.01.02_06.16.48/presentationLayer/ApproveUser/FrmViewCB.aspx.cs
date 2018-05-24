using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class FrmViewCB : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        abconDAL dal = new abconDAL();
        dalPDN dalP = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

            

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
                    LayngonNgu(2, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                btnEdit.Enabled = false;
                Button2.Enabled = false;
                btnEdit.Attributes.Add("opacity", "0.3");
                Button2.Attributes.Add("opacity", "0.3");
                btnDelete.Attributes["Onclick"] = "return confirm('Are you sure?')";
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                string maloaiphieu = Session["loaiphieu"].ToString();
                pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
                if (phieu != null)
                {
                    Label1Sophieucu.Visible = true;
                    Label2cophieucu.Visible = true;
                    pdna timsophieu = pnaDAO.TimVanBanTheoMa(phieu.oldpdno, macongty);
                    if (timsophieu != null)
                    {
                        string sophieucu = timsophieu.pdno;

                        Session["sophieucu"] = sophieucu;
                        if (timsophieu.Abtype == "PDN2")
                        {
                            lblsoPhieucu1.Text = sophieucu;
                            Labelsophieucu1.Visible = true;
                        }
                        else
                        {
                            Label2cophieucu.Text = timsophieu.pdno;
                            Label1Sophieucu.Visible = true;
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    if (phieu == null)
                    {
                        Label1Sophieucu.Visible = false;
                        Label2cophieucu.Visible = false;
                    }
                }
                if (maloaiphieu == "PDN2")
                {
                    divPhieuDeNghi.Visible = false;
                    divPhieuMuaHang.Visible = true;
                    HienThiDanhSachMuaHang();
                    HienThiPhieuMuaHang();
                    Label1Sophieucu.Visible = false;
                    Label2cophieucu.Visible = false;
                    if (phieu == null)
                    {
                        phieumuahangcu.Visible = false;
                    }
                    else
                    {
                        phieumuahangcu.Visible = true;
                    }
                    ShowAttactFile();
                }
                else
                {
                    divPhieuDeNghi.Visible = true;
                    divPhieuMuaHang.Visible = false;
                    HienThi();
                    ShowAttactFile();
                }
              
            }
            // HienThi();
           
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button3.Text = hasLanguege["Button1"].ToString();
            btnEdit.Text = hasLanguege["btnEdit"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                Button2.Text = "Nhờ người dịch";
                btnBack.Text = "Trở lại";
                btnDelete.Text = "Xóa Phiếu";
            }
            else if (ngonngu == "lbl_TW")
            {
                Button2.Text = "送翻译";
                btnBack.Text = "返回上步骤";
                btnDelete.Text = "Delete";
            }
            else if (ngonngu == "lbl_EN")
            {
                Button2.Text = "Sent To Translator";
                btnBack.Text = "Back";
                btnDelete.Text = "删除";
            }

        }
        public void HienThiDanhSachMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            DataRow drw = dt.NewRow();
            DataRow drw1 = dt.NewRow();
            DataRow drw2 = dt.NewRow();
            DataRow drw3 = dt.NewRow();
            DataRow drw4 = dt.NewRow();
            DataRow drw5 = dt.NewRow();
           
            if (dt.Rows.Count != 0 && dt.Rows.Count < 6)
            {
                dt.Rows.Add(drw);
                dt.Rows.Add(drw1);
                dt.Rows.Add(drw2);
                dt.Rows.Add(drw3);
                dt.Rows.Add(drw4);
                dt.Rows.Add(drw5);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();

            string manguoidung = Session["user"].ToString();

            DataTable dt = dalP.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {
                // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu,macongty, true);
                string madonvi = dt.Rows[0]["pddepid"].ToString();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString();
                int yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    Session["bp"] = donvi.ID;
                    Session["bophan"] = donvi.DepName;
                    lblloaiphieumh.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = donvi.DepName;
                    lblsophieu.Text = idphieu;
                    lblMucDichSuDung.Text=dt.Rows[0]["UseIntent"].ToString();
                    lbTieuDe.Text = dt.Rows[0]["mytitle"].ToString();
                    string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    if (yn != 6  )
                    {
                        btnEdit.Enabled = true;
                        Button2.Enabled = true;
                        btnEdit.Attributes.Add("opacity", "100");
                        Button2.Attributes.Add("opacity", "100");
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        Button2.Enabled = false;
                        btnEdit.Attributes.Add("opacity", "0.3");
                        Button2.Attributes.Add("opacity", "0.3");
                    }
             

            }
        }
        private void HienThi()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            
            string manguoidung = Session["user"].ToString();

            DataTable dt = dalP.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {
                string madonvi = dt.Rows[0]["pddepid"].ToString();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString();
                int yn = int.Parse(dt.Rows[0]["Yn"].ToString());
               
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                    Session["bp"] = bophan.ID;
                    Session["bophan"] = bophan.DepName;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan.DepName;
                    lbSoPhieu.Text = idphieu;
                    lbNoiDung.Text = dt.Rows[0]["pdmemovn"].ToString();
                    //lbNgay.Text = phieu.CFMDate0.ToString();
                    lbTieuDe.Text = dt.Rows[0]["mytitle"].ToString();
                    string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    if (yn!= 6 )
                    {
                        btnEdit.Enabled = true;
                        Button2.Enabled = true;
                        btnEdit.Attributes.Add("opacity", "100");
                        Button2.Attributes.Add("opacity", "100");
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        Button2.Enabled = false;
                        btnEdit.Attributes.Add("opacity", "0.3");
                        Button2.Attributes.Add("opacity", "0.3");
                    }
              
            }
        }

       
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("frmTrinhDuyetCB.aspx");
        }

        protected void btnNhoNguoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guinguoidich.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string maloaiphieu = Session["loaiphieu"].ToString();
                string maphieu = Session["maphieu"].ToString();
                if (maloaiphieu == "PDN2")
                {
                    Response.Redirect("frmSuaphieumuahang.aspx");
                }
                else
                {
                    Response.Redirect("chinhsuaphieu.aspx");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Danhsachphieumoikhoitao.aspx");
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = gvDetails.DataKeys[grdRow.RowIndex].Value.ToString();
            //Response.ContentType = "image/jpg";
            //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            Label lblID = (Label)gvDetails.Rows[e.RowIndex].FindControl("lblIDAttactFile");
            dalP.DeleteFileDinhKemPhieuDeNghi(idphieu,macongty,int.Parse(lblID.Text.Trim()));
            ShowAttactFile();
        }
        private void ShowAttactFile()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            DataTable dt = dalP.QryFileDinhKemPhieuDeNghi(idphieu, macongty);
            gvDetails.DataSource = dt;
          
            gvDetails.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
            if (filename == "")
            {
                return;
            }
            else
            {
                string strFileName = fileUpload1.PostedFile.FileName;
                int lastIndex = 0;

                if (strFileName.Contains('\\'))
                {
                    lastIndex = strFileName.LastIndexOf('\\');
                }
                strFileName = strFileName.Substring(lastIndex + 1);

                string server = "D:\\AttactFilePDN\\" + filename;
              
                fileUpload1.PostedFile.SaveAs(server);
                //fileUpload1.PostedFile.SaveAs(partAndFile);
                string macongty = Session["congty"].ToString();
                string idphieu = Session["maphieu"].ToString();
                dalP.ThemFileDinhKemPhieuDeNghi(idphieu, macongty, filename, server);
                ShowAttactFile();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dal.XoaMaPhieuTrongBangPDNA(macongty, idphieu);
            Response.Redirect("MyDocusRe.aspx");
        }
    }
}