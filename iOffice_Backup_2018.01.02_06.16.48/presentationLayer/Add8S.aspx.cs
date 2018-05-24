using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.presentationLayer
{
    public partial class Add8S : LanguegeBus
    {
        Stem8SDAL dalType = new Stem8SDAL();
        S8recDAL dal8Rec = new S8recDAL();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];
            string ngonngu = (string)Session["languege"];
            if (UserID == null && ngonngu == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/presentationLayer/Default.aspx");
            }
            else
            {
                LayngonNgu(41, ngonngu);
            }
            if (!IsPostBack)
            {
                
                HienThiDropType();
                HienThiDropDonViERP();
              //  HienThiChiTietLenDrop();
               // HienThiDanhSachTheoDieuKien();
                DropDown.Items.Insert(0, new ListItem("", "0"));
                DropDownDonVi.Items.Insert(0, new ListItem("", "0"));
                
                //txtScore2.Enabled = false;
                //FileUpload2.Enabled = false;
                //Button3.Enabled = false;
                //Button2.Enabled = false;
                //btnCancel.Enabled = false;
                Button1.Attributes["OnClick"] = "return confirm('Are you sure?')";
                //Button2.Attributes["OnClick"] = "return confirm('Are you sure?')";
            }
        }
        public void HienThiDropType()
        {
            DataTable dt = dalType.LayStypeVN();
            if (dt.Rows.Count > 0)
            {
               
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    DropDown.DataSource = dt;
                    DropDown.DataValueField = "Sitemtp";
                    DropDown.DataTextField = "Stpnamevn";
                    DropDown.DataBind();
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDown.DataSource = dt;
                    DropDown.DataValueField = "Sitemtp";
                    DropDown.DataTextField = "Stpnamech";
                    DropDown.DataBind();
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDown.DataSource = dt;
                    DropDown.DataValueField = "Sitemtp";
                    DropDown.DataTextField = "Stpnameen";
                    DropDown.DataBind();
                }
            }
        }

        public void HienThiChiTietLenDrop()
        {
            string ID = DropDown.SelectedValue;
            if (ID != "")
            {
                DataTable dt = dalType.QryPhieutem8SLenDrop(ID);
                if (dt.Rows.Count > 0)
                {

                   
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataValueField = "Sitemno";
                        DropDownList1.DataTextField = "Sitemno";
                        DropDownList1.DataBind();
                        lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataValueField = "Sitemno";
                        DropDownList1.DataTextField = "Sitemno";
                        DropDownList1.DataBind();
                        lblChiTiet.Text = dt.Rows[0]["Snamech"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataValueField = "Sitemno";
                        DropDownList1.DataTextField = "Sitemno";
                        DropDownList1.DataBind();
                        lblChiTiet.Text = dt.Rows[0]["Snameen"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                    }
                }
                else
                {
                    DropDownList1.SelectedValue = null;
                    DropDownList1.DataBind();
                    lblChiTiet.Text = "";
                }

            }

        }

        public void HienThiDanhSachTheoDieuKien()
        {
            DateTime FromDate = DateTime.Today.AddDays(-7);
            DateTime ToDate = DateTime.Today;
            string siteNo=DropDownList1.SelectedValue;
            string DepartID = "";
                if (siteNo != "")
                {
                    if (txtDepartmentTemp.Text.Trim() != "0" || txtDepartmentTemp.Text.Trim() != "")
                    {
                        DepartID = txtDepartmentTemp.Text.Trim();
                    }
                    else
                    {
                        DepartID = "null";
                    }
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienVN(siteNo, FromDate, ToDate,DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienTW(siteNo, FromDate, ToDate,DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        DataTable dt = dalType.QryPhieu8TheoDieuKienEN(siteNo, FromDate, ToDate,DepartID);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
           

        }
        public void HienThiDanhSachTheoID(int ID)
        {
           
                DataTable dt = dalType.QryPhieu8TheoIDVN(ID);
                GridView1.DataSource = dt;
                GridView1.DataBind();
        }
        public void HienThiDanhSachTheoID1(int ID)
        {

                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                   DataTable dt = dalType.QryPhieu8TheoIDVN(ID);
                    if (dt.Rows.Count > 0)
                    {
                        txtMemoVN.Text = dt.Rows[0]["QCmemo"].ToString();
                        txtScore1.Text = dt.Rows[0]["sub_score"].ToString();
                      //  txtScore2.Text = dt.Rows[0]["sub_score"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                        lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                        Image1.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        Image5.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        //Image2.ImageUrl = dt.Rows[0]["QApic"].ToString();
                        //Image6.ImageUrl = dt.Rows[0]["QApic"].ToString();
              
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else if (ngonngu == "lbl_TW")
                {
                   DataTable dt = dalType.QryPhieu8TheoIDTW(ID);
                    if (dt.Rows.Count > 0)
                    {
                        txtMemoVN.Text = dt.Rows[0]["QCmemo"].ToString();
                        txtScore1.Text = dt.Rows[0]["sub_score"].ToString();
                       // txtScore2.Text = dt.Rows[0]["sub_score"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                        lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                        Image1.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        Image5.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        //Image2.ImageUrl = dt.Rows[0]["QApic"].ToString();
                        //Image6.ImageUrl = dt.Rows[0]["QApic"].ToString();
              
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else if (ngonngu == "lbl_EN")
                {
                    DataTable dt = dalType.QryPhieu8TheoIDEN(ID);
                    if (dt.Rows.Count > 0)
                    {
                        txtMemoVN.Text = dt.Rows[0]["QCmemo"].ToString();
                        txtScore1.Text = dt.Rows[0]["sub_score"].ToString();
                        //txtScore2.Text = dt.Rows[0]["sub_score"].ToString();
                        txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                        lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                        Image1.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        Image5.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                        //Image2.ImageUrl = dt.Rows[0]["QApic"].ToString();
                        //Image6.ImageUrl = dt.Rows[0]["QApic"].ToString();
              
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                 }
            
        }
        protected void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDown.SelectedValue;
            if (ID != "")
            {
                HienThiChiTietLenDrop();
            }
            else
            {
                DropDownList1.SelectedValue = null;
                DropDownList1.DataBind();
                lblChiTiet.Text = "";
            }
        }
        public void HienThiNoiDungLeDanhSach(int ID)
        {
            DataTable dt = dal8Rec.LayChiTiet8STheoID(ID);
            if (dt.Rows.Count > 0)
            {
                txtIDTemp.Text = ID.ToString();
                txtMemoVN.Text = dt.Rows[0]["QCmemo"].ToString();
                txtScore1.Text = dt.Rows[0]["sub_score"].ToString();
               // txtScore2.Text = dt.Rows[0]["sub_score"].ToString();
                txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                Image1.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                Image5.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                //Image2.ImageUrl = dt.Rows[0]["QApic"].ToString();
                //Image6.ImageUrl = dt.Rows[0]["QApic"].ToString();
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiDanhSachTheoDieuKien();
        }
        #region Don VI HRM

        //   public void HienThiDropDonVi()
        //{
        //    int Nam = int.Parse(DateTime.Today.Year.ToString());
        //    int Month = int.Parse(DateTime.Today.Month.ToString());
        //    DataTable dt = dal8Rec.QryDonViLenDropBox(Nam, Month);
        //    if (dt.Rows.Count > 0)
        //    {

        //        string ngonngu = (string)Session["languege"];
        //        if (ngonngu != null)
        //        {
        //            if (ngonngu == "lbl_VN")
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "DV_TEN";
        //                DropDownDonVi.DataBind();
        //            }
        //            else
        //            {
        //                DropDownDonVi.DataSource = dt;
        //                DropDownDonVi.DataValueField = "DV_MA";
        //                DropDownDonVi.DataTextField = "TENDV_TAIWAN";
        //                DropDownDonVi.DataBind();
        //            }
        //        }


        //        //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
        //        //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

        //    }

        //}
        #endregion
        public void HienThiDropDonViERP()
        {

            DataTable dt = dal8Rec.QryDonViLenDropBoxTrenERP(Congty);
            if (dt.Rows.Count > 0)
            {

                string ngonngu = (string)Session["languege"];
                if (ngonngu != null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                    else
                    {
                        DropDownDonVi.DataSource = dt;
                        DropDownDonVi.DataValueField = "ID";
                        DropDownDonVi.DataTextField = "DepName";
                        DropDownDonVi.DataBind();
                    }
                }


                //txtCQUserID0.Text = dt.Rows[0]["CQuserid0"].ToString();
                //txtCQUserID1.Text = dt.Rows[0]["CQUserid1"].ToString();

            }

        }
        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (Page.IsValid && FileUpload1.HasFile && CheckFileType(FileUpload1.FileName))
            {
                if (txtIDTemp.Text.Trim() != "")
                {
                    string link = "~/Image8S/2015/" + filename;
                    int ID = int.Parse(txtIDTemp.Text.Trim());
                    FileUpload1.SaveAs(Server.MapPath(link));
                    dal8Rec.UpdateImageWhenUpLoad1(Congty, ID, link);
                    Image1.ImageUrl = link;
                    HienThiDanhSachTheoID1(ID);
                }
                else
                {

                    string UserID = Session["UserID"].ToString();
                    string server = ConfigurationManager.AppSettings["ima8S"].ToString();
                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFile8S.xml";
                    XDocument dov = XDocument.Load(pathServer);
                    var record = dov.Root.Elements("ImageID").Where(p => p.Element("UserID").Value == UserID).ToList();
                    if (record != null)
                    {
                        foreach (var item in record)
                        {
                            string path = (string)item.Element("PathName");
                            item.Remove();
                            FileInfo inp = new FileInfo(path);
                            if (inp.Exists)
                            {
                                inp.Delete();
                            }
                        }
                    }
                    XmlDocument myXML = new XmlDocument();
                    myXML.Load(pathServer);
                    XmlElement parentElement = myXML.CreateElement("ImageID");
                    XmlElement eUser = myXML.CreateElement("UserID");
                    eUser.InnerText = UserID.ToString();
                    XmlElement Pat = myXML.CreateElement("PathName");
                    Pat.InnerText = server+filename;
                    parentElement.AppendChild(eUser);
                    parentElement.AppendChild(Pat);
                    myXML.DocumentElement.AppendChild(parentElement);
                    myXML.Save(pathServer);
                    FileUpload1.SaveAs(Server.MapPath("~/Image8S/2015/" + filename));
                    Image1.ImageUrl = "~/Image8S/2015/" + FileUpload1.FileName;
                }
            }
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
        //    if (Page.IsValid &&  CheckFileType(FileUpload2.FileName))
        //    {

        //        if (txtIDTemp.Text.Trim() != "")
        //        {
        //            string link = "~/Image8S/2015/" + filename;
        //            int ID = int.Parse(txtIDTemp.Text.Trim());
        //            FileUpload2.SaveAs(Server.MapPath(link));
        //            dal8Rec.UpdateImageWhenUpLoad2(Congty, ID, link);
        //            Image2.ImageUrl = link;
        //            HienThiDanhSachTheoID1(ID);
        //        }
        //        else
        //        {
        //            string UserID = Session["UserID"].ToString();
        //            string server = ConfigurationManager.AppSettings["ima8S"].ToString();
        //            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
        //            string pathServer = pathA + @"\XMLFile8SS.xml";
        //            XDocument dov = XDocument.Load(pathServer);
        //            var record = dov.Root.Elements("ImageID").Where(p => p.Element("UserID").Value == UserID).ToList();
        //            if (record != null)
        //            {
        //                foreach (var item in record)
        //                {
        //                    string path = (string)item.Element("PathName");
        //                    item.Remove();
        //                    FileInfo inp = new FileInfo(path);
        //                    if (inp.Exists)
        //                    {
        //                        inp.Delete();
        //                    }
        //                }
        //            }
        //            XmlDocument myXML = new XmlDocument();
        //            myXML.Load(pathServer);
        //            XmlElement parentElement = myXML.CreateElement("ImageID");
        //            XmlElement eUser = myXML.CreateElement("UserID");
        //            eUser.InnerText = UserID.ToString();
        //            XmlElement Pat = myXML.CreateElement("PathName");
        //            Pat.InnerText = server+filename;
        //            parentElement.AppendChild(eUser);
        //            parentElement.AppendChild(Pat);
        //            myXML.DocumentElement.AppendChild(parentElement);
        //            myXML.Save(pathServer);
        //            FileUpload2.SaveAs(Server.MapPath(server + filename));
        //            Image2.ImageUrl = server + filename;
        //        }
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            string stem8 = DropDown.SelectedValue;
            string stemDetail = DropDownList1.SelectedValue;
            string memo = txtMemoVN.Text.Trim();
            string score = txtScore1.Text.Trim();
            string UserID = Session["UserID"].ToString();
            string DonViMa = DropDownDonVi.SelectedValue;
            string CK1 = "";
            int PScore = 0;
            if (CheckBox1.Checked == true)
            {
                try
                {
                    PScore = int.Parse(score);
                    CK1 = "1";
                }
                catch
                {
                    PScore = 0;
                    CK1 = "0";
                }
            }
            else
            {
                PScore = 0;
                CK1 = "0";
            }

            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFile8S.xml";
            XDocument dov = XDocument.Load(pathServer);
            var record = dov.Root.Elements("ImageID").Where(p => p.Element("UserID").Value == UserID).ToList();
            string link = "";
            if (record != null)
            {
                foreach (var item in record)
                {
                    link = (string)item.Element("PathName");
                    item.Remove();
                }
            }
            dov.Save(pathServer);
            if (txtIDTemp.Text.Trim() == "")
            {
                int ID = 0;
                DataTable dt = dal8Rec.LayIDMax();
                if (dt.Rows.Count > 0)
                {
                    string a = dt.Rows[0]["ID"].ToString();
                    try
                    {
                        ID = int.Parse(a) + 1;
                    }
                    catch
                    {
                        ID = 0;
                    }
                }
                try
                {
                   // dal8Rec.InsertPicture(Congty, date, DonViMa, UserID, memo, link, stemDetail, CK1, PScore, ID);
                    //txtScore2.Enabled = true;
                    //FileUpload2.Enabled = true;
                    //Button3.Enabled = true;
                    //Button2.Enabled = true;
                    //btnCancel.Enabled = true;
                    Session["ThemThanhCong"] = ID.ToString();
                    txtIDTemp.Text = Session["ThemThanhCong"].ToString();
                }
                catch
                {
 
                }
                HienThiDanhSachTheoID(ID);
            }
            else
            {
                int ID = int.Parse(txtIDTemp.Text.Trim());
               // dal8Rec.UpdatePicture0(Congty, date, ID, PScore, link, memo, CK1);
                HienThiDanhSachTheoID(ID);
            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDownList1.SelectedValue;
            DataTable dt = dalType.QryPhieuitemTheoID(ID);
            if (dt.Rows.Count > 0)
            {
                lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
            }
            HienThiDanhSachTheoDieuKien();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lb = (Label)e.Row.FindControl("lblsub_score");
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblsh = (Label)row.FindControl("lblsh");
            Label lbldepid = (Label)row.FindControl("lbldepid");
            Label lblSitemno = (Label)row.FindControl("lblSitemno");
            Label lblck1 = (Label)row.FindControl("lblck1");
            Label lblck2 = (Label)row.FindControl("lblck2");
            Label lblQCmemo = (Label)row.FindControl("lblQCmemo");
            Image Image11 = (Image)row.FindControl("Image1");
            Image Image31 = (Image)row.FindControl("Image3");
            Label lblsub_score = (Label)row.FindControl("lblsub_score");
            txtIDTemp.Text = lblsh.Text.Trim();
            DropDownDonVi.SelectedValue = lbldepid.Text.Trim();

            if (lblck1.Text.Trim() == "1")
            {
                txtScore1.Text = lblsub_score.Text.Trim();
            }
            else
            {
                txtScore1.Text = "0";
            }
         
            txtMemoVN.Text = lblQCmemo.Text.Trim();
            Image1.ImageUrl = Image11.ImageUrl;
           // Image2.ImageUrl = Image31.ImageUrl;
            Image5.ImageUrl = Image11.ImageUrl;
           // Image6.ImageUrl = Image31.ImageUrl;
            lblImageTem1.Text = Image11.ImageUrl;
            DataTable dt = dalType.LayStem8STheoID(lblSitemno.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["Sitemtp"].ToString();
                string IDD = dt.Rows[0]["Sitemno"].ToString();
                DropDown.SelectedValue = type;
                lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                DropDownList1.SelectedValue = IDD;
            }
            DropDown.Enabled = false;
            DropDownDonVi.Enabled = false;
            DropDownList1.Enabled = false;
          
            //txtScore2.Enabled = true;
            //FileUpload2.Enabled = true;
            //Button3.Enabled = true;
            //Button2.Enabled = true;
            //btnCancel.Enabled = true;
        }

        protected void btnQuery_Click1(object sender, EventArgs e)
        {
            HienThiDanhSachTheoDieuKien();
        }



        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    int ID = int.Parse(txtIDTemp.Text);
        //    string CK2 = "";
        //    int Score;

        //    if (CheckBox2.Checked == true)
        //    {
        //        CK2 = "1";
        //        try
        //        {
        //            Score = int.Parse(txtScore2.Text.Trim());
        //        }
        //        catch
        //        {
        //            Score = 0;
        //        }
        //    }
        //    else
        //    {
        //        CK2 = "0";
        //        try
        //        {
        //            Score = int.Parse(txtScore2.Text.Trim());
        //        }
        //        catch
        //        {
        //            Score = 0 - int.Parse(txtScoreMau.Text.Trim());
        //        }
        //    }
        //    dal8Rec.ConfirmScrore2(CK2, Score, Congty, ID);
        //    HienThiDanhSachTheoID(ID);
        //}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("ThemThanhCong");
            Response.Redirect("page8SDetail.aspx");
        }

        protected void DropDownDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDownDonVi.SelectedValue;
            if (ID != "0")
            {
                txtDepartmentTemp.Text = ID;
            }
        }
    }
}