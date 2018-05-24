using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Net;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class FrmView : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        abconDAL dal = new abconDAL();
        dalPDN dap = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                btnEdit.Enabled = false;
                btnEdit.Attributes.Add("opacity", "0.3");
                btnNhoNguoi.Enabled = false;
                btnNhoNguoi.Attributes.Add("opacity", "0.3");
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
               // btnDelete.Attributes["Onclick"] = "return confirm('Are you sure you want to delete this event?')";
                btnDelete.Attributes["Onclick"] = "return confirm('Are you sure?')";
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                string maloaiphieu = Session["loaiphieu"].ToString();
                pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
                if (phieu != null)
                {
                    pdna timsophieu = pnaDAO.TimVanBanTheoMa(phieu.oldpdno, macongty);
                    if (timsophieu != null)
                    {
                        string sophieucu = timsophieu.pdno;
                        Label1Sophieucu.Visible = true;
                        Label2cophieucu.Visible = true;
                        Session["sophieucu"] = sophieucu;
                        if (timsophieu.Abtype == "PDN2")
                        {
                            lblsoPhieucu1.Text = sophieucu;
                            lblSoPhieuCuMH.Visible = true;
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
                        lblSoPhieuCuMH.Visible = false;
                        lblsoPhieucu1.Visible = false;
                    }
                }
                if (maloaiphieu == "PDN2" && maloaiphieu!=null)
                {
                    divPhieuDeNghi.Visible = false;
                    divPhieuMuaHang.Visible = true;
                    HienThiDanhSachMuaHang();
                    HienThiPhieuMuaHang();
                    if (phieu == null)
                    {
                        SoPhieucuf.Visible = false;
                    }
                    else
                    {
                        SoPhieucuf.Visible = true;
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
            Button1.Text = hasLanguege["Button1"].ToString();
            btnEdit.Text = hasLanguege["btnEdit"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                btnNhoNguoi.Text = "Nhờ người dịch";
                btnDelete.Text = "Xóa Phiếu";
            }
            else if (ngonngu == "lbl_TW")
            {
                btnNhoNguoi.Text = "送翻译";
                btnDelete.Text = "Delete";
            }
            else if (ngonngu == "lbl_EN")
            {
                btnNhoNguoi.Text = "Sent To Translator";
                btnDelete.Text = "删除";
            }
            
        }
        public void HienThiDanhSachMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count < 6)
                {
                    DataRow dr = dt.NewRow();
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    DataRow dr3 = dt.NewRow();
                    DataRow dr4 = dt.NewRow();
                    DataRow dr5 = dt.NewRow();
                    DataRow dr6 = dt.NewRow();
                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    dt.Rows.Add(dr3);
                    dt.Rows.Add(dr4);
                    dt.Rows.Add(dr5);
                    dt.Rows.Add(dr6);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            
        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
         
            string manguoidung = Session["user"].ToString();

            DataTable dt = dap.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {
                string ngaythang = dt.Rows[0]["CFMDate0"].ToString();
                string madonvi = dt.Rows[0]["pddepid"].ToString().Trim();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString().Trim();
                string noidung = dt.Rows[0]["pdmemovn"].ToString().Trim();
                string tieude = dt.Rows[0]["mytitle"].ToString().Trim();
                string tieudedich = dt.Rows[0]["pdnsubject"].ToString().Trim();
                string noidungdich = dt.Rows[0]["NoiDungDich"].ToString();
                int Yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                string mucdicsudung = dt.Rows[0]["UseIntent"].ToString();
                BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
             
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    Session["bp"] = donvi.ID;
                    Session["bophan"] = donvi.DepName;
                    lblloaiphieumh.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = donvi.DepName;
                    lblsophieu.Text = idphieu;
                    lblMucDichSuDung.Text =mucdicsudung;
                    lbTieuDe.Text = tieude;
                    string dinhdang = ngaythang;
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    if (Yn!=6)
                    {
                        btnEdit.Enabled = true;
                        btnEdit.Attributes.Add("opacity", "100");
                        btnNhoNguoi.Enabled = true;
                        btnNhoNguoi.Attributes.Add("opacity", "100");

                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnNhoNguoi.Enabled = false;
                        btnNhoNguoi.Attributes.Add("opacity", "0.3");
                        btnEdit.Attributes.Add("opacity", "0.3");
                    }
                            
            }
        }
        private void HienThi()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();
           string manguoidung=Session["user"].ToString();

           DataTable dt = dap.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {
                string ngaythang = dt.Rows[0]["CFMDate0"].ToString();
                string madonvi = dt.Rows[0]["pddepid"].ToString().Trim();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString().Trim();
                string noidung = dt.Rows[0]["pdmemovn"].ToString().Trim();
                string tieude = dt.Rows[0]["mytitle"].ToString().Trim();
                string tieudedich = dt.Rows[0]["pdnsubject"].ToString().Trim();
                string noidungdich = dt.Rows[0]["NoiDungDich"].ToString();
                int Yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                    Session["bp"] = bophan.ID;
                    Session["bophan"] = bophan.DepName;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan.DepName;
                    lbSoPhieu.Text = idphieu;
                    lbNoiDung.Text = noidung;
                    //lbNgay.Text = phieu.CFMDate0.ToString();
                    lblTieuDe.Text = tieude;
                    string dinhdang = ngaythang;
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    if (Yn!=6)
                    {
                        btnEdit.Enabled = true;
                        btnNhoNguoi.Enabled = true;
                        btnEdit.Attributes.Add("opacity", "100");
                        btnNhoNguoi.Attributes.Add("opacity", "100");
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnNhoNguoi.Enabled = false;
                        btnEdit.Attributes.Add("opacity", "0.3");
                        btnNhoNguoi.Attributes.Add("opacity", "0.3");
                    }
              
            }
        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            Response.Redirect("frmTrinhDuyet.aspx");
        }

        protected void btnNhoNguoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("guinguoidichNV.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                 string maloaiphieu = Session["loaiphieu"].ToString();
                if (maloaiphieu == "PDN2")
                {
                    Response.Redirect("frmSuaphieumuahangNV.aspx");
                }
                else
                {
                    Response.Redirect("chinhsuaphieuNV.aspx");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
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
              
                string server = "D:\\AttactFilePDN\\"+filename;
              //  fileUpload1.PostedFile.SaveAs(strPath);
                fileUpload1.PostedFile.SaveAs(server);
                //string server = "\\\\192.168.11.8\\AttactFilePDN\\";
                //string partAndFile = server + filename;
                //fileUpload1.SaveAs(partAndFile);

                string macongty = Session["congty"].ToString();
                string idphieu = Session["maphieu"].ToString();
               
                dap.ThemFileDinhKemPhieuDeNghi(idphieu, macongty, filename, server);
                ShowAttactFile();
            }
        }
        private void ShowAttactFile()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            DataTable dt = dap.QryFileDinhKemPhieuDeNghi(idphieu, macongty);
            gvDetails.DataSource = dt;
            gvDetails.DataBind();
        }
        //private void HienThiFileDinhKem()
        //{
        //    string macongty = Session["congty"].ToString();
        //    string idphieu = Session["maphieu"].ToString();
        //    List<PDNLink> list = PDNLinkBUS.GetLinkAttactFileByPDNO(macongty, idphieu);
        //    if (list.Count > 0)
        //    {
        //        divUpload2.Visible = true;
        //        ShowAttactFile();
        //        divUpload1.Visible = false;
        //    }
        //    else
        //    {
        //        divUpload1.Visible = true;
        //        divUpload2.Visible = false;
        //    }
        //}

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = gvDetails.DataKeys[grdRow.RowIndex].Value.ToString();
           
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
            dap.DeleteFileDinhKemPhieuDeNghi(idphieu, macongty, int.Parse(lblID.Text.Trim()));
            ShowAttactFile();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dal.XoaMaPhieuTrongBangPDNA(macongty, idphieu);
            Response.Redirect("MyDocusNV.aspx");
        }
        
    }
}