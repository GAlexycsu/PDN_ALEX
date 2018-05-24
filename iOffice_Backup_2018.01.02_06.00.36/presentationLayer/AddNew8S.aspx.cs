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
    public partial class AddNew8S : LanguegeBus

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
              
                Session.Remove("ThemThanhCong");
                PhanQuyen();
             
                //string ID = (string)Request["ID"];
                //string DepartID = (string)Request["DepartID"];
                //string Sitemno = (string)Request["Sitemno"];
                //txtIDTemp.Text = ID.ToString();
                txtDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                HienThiDropType();
                HienThiDropDonViERP();

               // HienThiChiTietLenDrop();
                DropDown.Items.Insert(0, new ListItem("", "0"));
                DropDownDonVi.Items.Insert(0, new ListItem("", "0"));
             //   HienThiDanhSachTheoID(int.Parse(ID));
                string DepartID = (string)Request["S8Depart"];
                if (DepartID != null && DepartID!="0")
                {
                    DropDownDonVi.SelectedValue = DepartID;
                }
                //btnConfirm.Attributes["OnClick"] = "return confirm('Are you sure?')";
            }
        }
      


        public void PhanQuyen()
        {
            string UserID = (string)Session["UserID"];
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFilePhanQuyen.xml";
            XDocument dov = XDocument.Load(pathServer);
            var list = dov.Root.Elements("PhanQuyenID").Where(p => p.Element("UserID").Value.Trim() == UserID).ToList();
            if (list.Count > 0)
            {
                //foreach (var item in list)
                //{
                   
                //    string Write = (string)item.Element("RoleWrite");
                //    if (Write.Trim() == "1")
                //    {
                       
                //        btnConfirm.Enabled = true;
                //        btnConfirm.Attributes.CssStyle.Add("opacity", "100");
                //    }
                //    else
                //    {
                        
                //        btnConfirm.Enabled = false;
                //        btnConfirm.Attributes.CssStyle.Add("opacity", "0.3");
                //    }
                //}
            }
            else
            {
                
                btnUpload1.Enabled = false;


                btnUpload2.Enabled = false;
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
               // lblPercent.Text = dt.Rows[0]["StpPerCent"].ToString()+"%";
            }
        }

        public void HienThiPhanTramTheoID(string Sitemtp)
        {
            DataTable dt = dalType.LayStypeVNTheoID(Sitemtp);
            if (dt.Rows.Count > 0)
            {

                lblPercent.Text = dt.Rows[0]["StpPerCent"].ToString() +"%";
            }
        }

        public void HienThiChiTietLenDrop()
        {
            string ID = DropDown.SelectedValue;
            if (ID != "0")
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
                    DropDownList1.DataSource = null;
                    DropDownList1.DataBind();
                    DropDownList1.Items.Clear();
                    lblChiTiet.Text = "";
                    txtScoreMau.Text = "";
                }

            }
            else
            {
                DropDownList1.DataSource = null;
               
                DropDownList1.DataBind();
                DropDownList1.Items.Clear();
                lblChiTiet.Text = "";
                txtScoreMau.Text = "";
            }

        }

     
        protected void DropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDown.SelectedValue;
            if (ID != "0")
            {
                txtTypeID.Text = ID.ToString();
                HienThiChiTietLenDrop();
                HienThiPhanTramTheoID(ID);
            }
            else
            {
                HienThiChiTietLenDrop();
                lblChiTiet.Text = "";
                txtTypeID.Text = "";
                lblPercent.Text = "";
            }
        }
        public void HienThiNoiDungLeDanhSach(int ID)
        {
            DataTable dt = dal8Rec.LayChiTiet8STheoID(ID);
            if (dt.Rows.Count > 0)
            {
                int Score;
                try
                {
                    Score = int.Parse(dt.Rows[0]["sub_score"].ToString());
                }
                catch
                {
                    Score = 0;
                }
                txtIDTemp.Text = ID.ToString();
                txtMemoVN.Text = dt.Rows[0]["QCmemo"].ToString();
                txtScore1.Text = Score.ToString();

                txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
                lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                ImagePic1.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                ImagePic1Tooltrip.ImageUrl = dt.Rows[0]["QCpic0"].ToString();
                ImagePic2.ImageUrl = dt.Rows[0]["QApic"].ToString();
                ImagePic2Tootrip.ImageUrl = dt.Rows[0]["QApic"].ToString();
                lblImagePic1.Text = dt.Rows[0]["QCpic0"].ToString();
                lblImagePic2.Text = dt.Rows[0]["QApic"].ToString();
            }
        }
        #region DonVI HRM
        //   public void HienThiDropDonVi()
        //{
        //    int Nam = int.Parse(DateTime.Today.Year.ToString());
        //    int Month = int.Parse(DateTime.Today.Month.ToString());
        //    DataTable dt = dal8Rec.QryDonViLenDropBox(Nam,Month);
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
            if (Page.IsValid &&  CheckFileType(FileUpload1.FileName))
            {
                if (txtIDTemp.Text.Trim() != "")
                {
                    string link = "~/Image8S/2015/" + filename;
                    int ID = int.Parse(txtIDTemp.Text.Trim());
                    FileUpload1.SaveAs(Server.MapPath(link));
                    dal8Rec.UpdateImageWhenUpLoad1(Congty, ID, link);
                    ImagePic1.ImageUrl = link;
                    ImagePic1Tooltrip.ImageUrl = link;
                    lblImagePic1.Text = link;
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
                    Pat.InnerText = server + FileUpload1.FileName;
                    parentElement.AppendChild(eUser);
                    parentElement.AppendChild(Pat);
                    myXML.DocumentElement.AppendChild(parentElement);
                    myXML.Save(pathServer);
                    FileUpload1.SaveAs(Server.MapPath("~/Image8S/2015/" + FileUpload1.FileName));
                    ImagePic1.ImageUrl = "~/Image8S/2015/" + FileUpload1.FileName;
                }
            }
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
        //    if (Page.IsValid && CheckFileType(FileUpload2.FileName))
        //    {

        //        if (txtIDTemp.Text.Trim() != "")
        //        {
        //            string link = "~/Image8S/2015/" + filename;
        //            int ID = int.Parse(txtIDTemp.Text.Trim());
        //            FileUpload2.SaveAs(Server.MapPath(link));
        //            dal8Rec.UpdateImageWhenUpLoad2(Congty, ID, link);
        //            Image2.ImageUrl = link;
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
        //            Pat.InnerText = server;
        //            parentElement.AppendChild(eUser);
        //            parentElement.AppendChild(Pat);
        //            myXML.DocumentElement.AppendChild(parentElement);
        //            myXML.Save(pathServer);
        //            FileUpload2.SaveAs(Server.MapPath(server + filename));
        //            Image2.ImageUrl = server + filename;

        //        }
        //        HienThiDanhSachTheoID(int.Parse(txtIDTemp.Text.Trim()));
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date;
            try
            {
                date = DateTime.Parse(txtDate.Text.Trim());
            }
            catch
            {
                date = DateTime.Today;
            }
            string userID = (string)Session["UserID"];
            if (userID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                string stem8 = DropDown.SelectedValue;
                string stemDetail = DropDownList1.SelectedValue;
                string memoVN = txtMemoVN.Text.Trim();
                string score = txtScore1.Text.Trim();
                
                string DonViMa = DropDownDonVi.SelectedValue;
                string memoTW = txtMemoTW.Text;
                string answer = txtAnswer.Text;
                string YN = "0";
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
                string pathServer1 = pathA + @"\XMLFile8SS.xml";
                XDocument dov = XDocument.Load(pathServer);
                var record = dov.Root.Elements("ImageID").Where(p => p.Element("UserID").Value == userID).ToList();
                XDocument data = XDocument.Load(pathServer1);
                string link = "";
                string link2 = "";
                if (record != null)
                {
                    foreach (var item in record)
                    {
                        link = (string)item.Element("PathName");
                    }
                }
                var list = data.Root.Elements("ImageID").Where(p => p.Element("UserID").Value == userID).ToList();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        link2 = (string)item.Element("PathName");
                    }
                }
                int ID = 0;
                if (txtIDTemp.Text.Trim() == "")
                {
                   
                    //DataTable dt = dal8Rec.LayIDMax();
                    //if (dt.Rows.Count > 0)
                    //{
                    //    string a = dt.Rows[0]["ID"].ToString();
                    //    try
                    //    {
                    //        ID = int.Parse(a) + 1;
                    //    }
                    //    catch
                    //    {
                    //        ID = 0;
                    //    }
                    //}
                    dal8Rec.InsertPicture(Congty, date, DonViMa, userID, memoTW, link, link2, stemDetail, CK1, memoVN, answer, PScore, YN,userID,DateTime.Today);
                   
                }
                else
                {
                    ID = int.Parse(txtIDTemp.Text.Trim());

                    dal8Rec.UpdatePicture111(Congty, DonViMa, userID, memoTW, stemDetail, CK1, memoVN, answer, PScore, ID, YN,userID,DateTime.Today);
                   
                }
                Response.Redirect("page8SDetail.aspx?IDS8=" + DonViMa);
            }
        }
       
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = DropDownList1.SelectedValue;
            DataTable dt = dalType.QryPhieuitemTheoID(ID);
            if (dt.Rows.Count > 0)
            {
                string ngonngu = (string)Session["languege"];
                if (ngonngu != null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lblChiTiet.Text = dt.Rows[0]["Snamevn"].ToString();
                    }
                    else
                    {
                        lblChiTiet.Text = dt.Rows[0]["Snamech"].ToString();
                    }
                }
                txtScoreMau.Text = dt.Rows[0]["Sitemscore"].ToString();
            }
            else
            {
                lblChiTiet.Text = "";
                txtScoreMau.Text = "";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lb = (Label)e.Row.FindControl("lblsub_score");
                lb.ForeColor = System.Drawing.Color.Red;
            }
        }

       
        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            txtScore1.Text = "";
            txtScore1.Focus();
            txtScore1.BackColor = System.Drawing.Color.Maroon;
            txtScore1.ForeColor = System.Drawing.Color.Blue;

        }



   

        protected void btnBack_Click(object sender, EventArgs e)
        {
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

        protected void btnUpload2_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
            if (Page.IsValid  && CheckFileType(FileUpload2.FileName))
            {
                if (txtIDTemp.Text.Trim() != "")
                {
                    string link = "~/Image8S/2015/" + filename;
                    int ID = int.Parse(txtIDTemp.Text.Trim());
                    FileUpload2.SaveAs(Server.MapPath(link));
                    dal8Rec.UpdateImageWhenUpLoad2(Congty, ID, link);
                    ImagePic2.ImageUrl = link;
                    ImagePic2Tootrip.ImageUrl = link;
                    lblImagePic2.Text = link;
                }
                else
                {

                    string UserID = Session["UserID"].ToString();
                    string server = ConfigurationManager.AppSettings["ima8S"].ToString();
                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFile8SS.xml";
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
                    Pat.InnerText = server + FileUpload2.FileName;
                    parentElement.AppendChild(eUser);
                    parentElement.AppendChild(Pat);
                    myXML.DocumentElement.AppendChild(parentElement);
                    myXML.Save(pathServer);
                    FileUpload2.SaveAs(Server.MapPath("~/Image8S/2015/" + FileUpload2.FileName));
                    ImagePic2.ImageUrl = "~/Image8S/2015/" + FileUpload2.FileName;
                }
            }
        }

      
    }
}