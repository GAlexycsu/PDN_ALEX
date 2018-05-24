using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

using System.Configuration;
using System.Management;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
namespace iOffice.presentationLayer
{
    public partial class pageMain3 : System.Web.UI.Page
    {
        DAL_PDN _bll = new DAL_PDN();
        BLL_TheLogib bllTheLogib = new BLL_TheLogib();
        BLL_Buser2 bllUser = new BLL_Buser2();
        DAL_Calendar dal = new DAL_Calendar();
        string Status = string.Empty;
        string SelectTime = string.Empty;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        DAL_projectn dalProjectm = new DAL_projectn();
        DAL_Projects dalProjects = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
        DAL_ProjectShare dalShare = new DAL_ProjectShare();
        DAL_GroupShare dalGroup = new DAL_GroupShare();
        decimal jobpercent;
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        int AttactID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime pNgay = DateTime.Now;
            // DateTime dateToSet = DateTime.Today;
            //Calendar1.SelectedDate = dateToSet;

            //Calendar1.VisibleDate = dateToSet;

            if (!IsPostBack)
            {
               
                Session.Remove("AttactID");
                //string UserID="22343";
                string IDUser = (string)Request["UserID"];
                string cty = (string)Request["congty"];
                string lang = (string)Request["languege"];
                if (IDUser != null && cty != null && lang != null)
                {
                    Session["UserID"] = IDUser;
                    Session["user"] = IDUser;
                    Session["congty"] = cty;
                    Session["languege"] = lang;
                }
                string UserID = (string)Session["UserID"];
                string user = (string)Session["UserID"];
                if (user == null || UserID == null)
                {
                    Response.Redirect("http://portal.footgear.com.vn/");
                }

                string languege = Session["languege"].ToString();

                string congty = "LTY";
                Session["congty"] = congty;
                // LinkHRM.Visible = false;
                LinkImportData.Visible = false;
                LinkKswiss.Visible = false;

                LinkImportBOMTest.Visible = false;
                LinkPMBOM.Visible = false;
                LinkProvider.Visible = false;
                Link_WebErp.Visible = false;
                LinkCreateUser.Visible = false;
                HienThiDanhSachHeThong();
                HienThiUserShareLenDropDow();
                HienThiTreeview();
               // HienThiTreeviewJobShare();
                
                XoaMessageTemp();
                RaScheduler_Load1();
                HienThiMessage();
                DataTable dtBuser = bllUser.TimNhanVienDangNhap(UserID, congty);
                if (dtBuser.Rows.Count != 0)
                {
                    string Admin = dtBuser.Rows[0]["Admin"].ToString();
                    string isSep = dtBuser.Rows[0]["isSep"].ToString();
                    if (Admin == "True")
                    {
                        //divMyCheck.Visible = false;
                        //divMyDoc.Visible = false;

                        LinkMyCheck.Visible = false;
                        LinkMyDocus.Visible = false;
                        lblCheck1.Visible = false;
                        lblCheck2.Visible = false;
                        lblCheck3.Visible = false;
                        lblDoc1.Visible = false;
                        lblDoc2.Visible = false;
                        lblDoc3.Visible = false;
                        LinkMyCheck.Text = "";
                        LinkMyDocus.Text = "";
                        LinkMyDocus.Width = new Unit("1px");
                        LinkMyCheck.Width = new Unit("1px");
                        lblCheck1.Text = "";
                        lblCheck3.Text = "";
                        lblDoc1.Text = "";
                        lblDoc3.Text = "";
                        LinkCreateUser.Visible = true;
                    }
                    else if (isSep == "True")
                    {
                        //divMyCheck.Visible = true;
                        //divMyDoc.Visible = true;
                        //divAdmin.Visible = false;
                        LinkMyCheck.Visible = true;
                        LinkMyDocus.Visible = true;
                        LinkButton1.Visible = false;
                        LinkCreateUser.Visible = false;
                        LinkCreateUser.Text = "";
                        List<string> dt = _bll.QryPhieuChoKyTheoNguoiKy(UserID, congty);
                        string soluong = "";
                        string soluong2 = "";
                        if (dt.Count > 0)
                        {
                            soluong = dt.Count.ToString();
                            lblCheck2.Text = soluong;
                        }
                        else
                        {
                            soluong = "0";
                            lblCheck2.Text = soluong;
                        }
                        DataTable dtt = _bll.QryPhieuDaKyDaDich(congty, UserID, pNgay);
                        if (dtt.Rows.Count > 0)
                        {
                            soluong2 = dtt.Rows.Count.ToString();
                            lblDoc2.Text = soluong2;
                        }
                        else
                        {
                            DataTable dtPhieu = _bll.QryPhieuDaDich(congty, UserID);
                            if (dtPhieu.Rows.Count > 0)
                            {
                                soluong2 = dtPhieu.Rows.Count.ToString();
                                lblDoc2.Text = soluong2;
                            }
                            else
                            {
                                soluong2 = "0";
                                lblDoc2.Text = soluong2;
                            }
                        }
                    }
                    else
                    {
                        //divMyDoc.Visible = true;
                        //divMyCheck.Visible = false;
                        //divAdmin.Visible = false;
                        LinkMyCheck.Visible = false;
                        LinkMyDocus.Visible = true;
                        LinkButton1.Visible = false;
                        LinkCreateUser.Visible = false;
                        LinkCreateUser.Text = "";
                        lblCheck1.Visible = false;
                        lblCheck2.Visible = false;
                        lblCheck3.Visible = false;
                        LinkMyCheck.Text = "";
                        LinkMyCheck.Width = new Unit("1px");
                        lblCheck1.Text = "";
                        lblCheck3.Text = "";
                        if (dtBuser.Rows[0]["BADEPID"].ToString() == "VTY0501D")
                        {
                            string soluong = "";
                            DataTable dtNguoiDich = _bll.SoPhieuChoToiDich(UserID, congty);
                            if (dtNguoiDich.Rows.Count != 0)
                            {
                                soluong = dtNguoiDich.Rows.Count.ToString();
                                lblDoc2.Text = soluong;
                            }
                        }
                        else
                        {
                            string soluong2 = "";
                            // DataTable dtt = _bll.SoPhieuDaDichChoToiGui(UserID, pNgay);
                            DataTable dtt = _bll.QryPhieuDaKyDaDich(congty, UserID, pNgay);
                            if (dtt.Rows.Count > 0)
                            {
                                soluong2 = dtt.Rows.Count.ToString();
                                lblDoc2.Text = soluong2;
                            }
                            else
                            {
                                DataTable dtPhieu = _bll.QryPhieuDaDich(congty, UserID);
                                if (dtPhieu.Rows.Count > 0)
                                {
                                    soluong2 = dtPhieu.Rows.Count.ToString();
                                    lblDoc2.Text = soluong2;
                                }
                                else
                                {
                                    soluong2 = "0";
                                    lblDoc2.Text = soluong2;
                                }
                            }
                        }
                    }
                    DropDownUserName.SelectedValue = UserID;
                }
                else
                {
                    //divAdmin.Visible = false;
                    //divMyCheck.Visible = false;
                    //divMyDoc.Visible = false;
                    LinkMyCheck.Visible = false;
                    LinkMyDocus.Visible = false;
                    LinkButton1.Visible = false;
                }


            }
        }
        public void HienThiDanhSachHeThong()
        {
            try
            {
                DataTable dt = bllTheLogib.GetListSystem(Session["UserID"].ToString());
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string ID = dr["ID"].ToString();
                        switch (ID)
                        {

                            case "2":
                                LinkProvider.Visible = true;
                               
                                break;

                            case "4":
                                Link_WebErp.Visible = true;
                               
                                break;
                            case "5":
                                LinkImportData.Visible = true;
                               
                                break;
                            //case "6":
                            //    LinkKswiss.Visible = true;
                            //    break;
                            //case "7":
                            //    LinkPMBOM.Visible = true;
                            //    break;
                            //case "8":
                            //    LinkImportBOMTest.Visible = true;
                            //    break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnMyEmail_Click1(object sender, EventArgs e)
        {
            Response.Redirect("http://mail.footgear.com.vn/");
        }
        private void Redirect(string pID)
        {
            try
            {
                DataTable dt = bllTheLogib.GetSystemByID(pID);
                if (dt.Rows.Count > 0)
                {
                    string Url = dt.Rows[0]["StartPage"].ToString();
                    string SID = dt.Rows[0]["ID"].ToString();


                    string SessionID = (Session["UserID"].ToString() + DateTime.Now.ToString()).GetHashCode().ToString();
                    string languege = Session["languege"].ToString();
                    string HashSessionID = CalculateMD5Hash(SessionID);
                    bllTheLogib.NhapID(Session["UserID"].ToString(), SID, HashSessionID);  // login log to table
                    Response.Redirect(Url + "?ID=" + SessionID + "&SID=" + SID + "&UID=" + Session["UserID"].ToString() + "&languege=" + languege);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CalculateMD5Hash(string input)
        {
            try
            {
                // step 1, calculate MD5 hash from input
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.Unicode.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void LinkMyCheck_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string GSBH = "LTY";
            string languege = Session["languege"].ToString();
            DataTable dt = bllUser.TimNhanVienDangNhap(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                string isSep = dt.Rows[0]["isSep"].ToString().ToLower();
                if (isSep == "true")
                {
                    // Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyCheckPDN.aspx?UserID="+UserID + "&congty="+GSBH +"&languege="+languege);
                    // Response.Redirect("http://" + alink + "/ApproveUser/MyCheckPDN.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                    Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx");
                }

            }
        }

        protected void LinkMyDocus_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string GSBH = "LTY";
            string languege = Session["languege"].ToString();
            DataTable dt = bllUser.TimNhanVienDangNhap(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                string isSep = dt.Rows[0]["isSep"].ToString();
                string BoPhan = dt.Rows[0]["BADEPID"].ToString();
                if (BoPhan == "VTY0501D")
                {
                    //Response.Redirect("http://localhost:3530/presentationLayer/NguoiDich/MyDocusND.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                    // Response.Redirect("http://" + alink + "/NguoiDich/MyDocusND.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                    Response.Redirect("~/presentationLayer/NguoiDich/MyDocusND.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                }
                else
                {
                    if (isSep == "True")
                    {
                        //  Response.Redirect("http://localhost:3530/presentationLayer/ApproveUser/MyDocusRe.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                        //Response.Redirect("http://" + alink + "/ApproveUser/MyDocusRe.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                        Response.Redirect("~/presentationLayer/ApproveUser/MyDocusRe.aspx");
                    }
                    else
                    {
                        string link = "http://" + alink + "/Users/MyDocusNV.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege;
                        //Response.Redirect("http://localhost:3530/presentationLayer/Users/MyDocusNV.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                        //Response.Redirect("http://" + alink + "/Users/MyDocusNV.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                        Response.Redirect("~/presentationLayer/Users/MyDocusNV.aspx");
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString().ToLower();
            string GSBH = "LTY";
            string languege = Session["languege"].ToString();
            DataTable dt = bllUser.TimNhanVienDangNhap(UserID, GSBH);
            if (dt.Rows.Count > 0)
            {
                if (UserID.ToLower() == "admin")
                {

                    // Response.Redirect("http://" + alink + "/Admin/frmAddUsers.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                    //  Response.Redirect("http://" + alink + "/Users/MyDocusNV.aspx?UserID=" + UserID + "&congty=" + GSBH + "&languege=" + languege);
                    Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
                }

            }
        }

        protected void LinkCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }

        protected void linkProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("WF_Projectm.aspx");
        }
        protected void LinkProvider_Click(object sender, EventArgs e)
        {
            Redirect("2");
        }

        protected void LinkWebErp_Click(object sender, EventArgs e)
        {
            Redirect("4");
        }

        protected void LinkImportData_Click(object sender, EventArgs e)
        {
            Redirect("5");
        }

        protected void LinkKswiss_Click(object sender, EventArgs e)
        {
            Redirect("6");
        }

        protected void LinkPMBOM_Click(object sender, EventArgs e)
        {
            Redirect("7");
        }

        protected void LinkImportBOMTest_Click(object sender, EventArgs e)
        {
            Redirect("8");
        }


        protected void Link_HRM_Click(object sender, EventArgs e)
        {
            Redirect("9");
        }

        protected void linkQuenMatKhau_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];

            string languege = (string)Session["languege"];
           
            //Response.Redirect("http://192.168.11.8/PDN/presentationLayer/FrmQuenmatkhauxetduyet.aspx"?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege)
            // Response.Redirect("http://" + alink + "/FrmQuenmatkhauxetduyet.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("FrmQuenmatkhauxetduyet.aspx");
        }

        protected void linkChangPass_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
          
            string languege = Session["languege"].ToString();
            //  Response.Redirect("http://" + alink + "/frmDoiMatKhauXetDuyet.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("frmDoiMatKhauXetDuyet.aspx");
        }

        protected void linkChuKy_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
           
            string languege = Session["languege"].ToString();
            // Response.Redirect("http://" + alink + "/changesignature.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("changesignature.aspx");
        }

        protected void LinkMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://mail.google.com/");
        }

        protected void LinkTranslate_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://translate.google.com/");
        }

        protected void LinkMap_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.google.com/maps");
        }

        protected void LinkDocument_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://docs.google.com/");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Remove("congty");
            Session.Remove("user");
            Session.Remove("UserID");
            Session.RemoveAll();
            //string langue = Session["languege"].ToString();
            //Response.Redirect("http://portal.footgear.com.vn/?biennho=" + langue);
            Response.Redirect("http://portal.footgear.com.vn");
        }

        protected void LinkChangPassLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("WF_ChangePassword.aspx");
        }
        protected void LinkGroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx");
        }
        public void HienThiMessage()
        {
            string CongTy = "LTY";
            string UserID = (string)Session["UserID"].ToString();
            DateTime date = DateTime.Today;
            DataTable dt = dalGroup.QryMessgage(date, CongTy, UserID);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }
        public void HienThiTreeviewJobShare()
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string UserShare = DropDownUserName.SelectedValue;
            string CongTy = "LTY";
            RadTreeNode roott = new RadTreeNode("System");
            RadTreeView1.Nodes.Clear();
            RadTreeView1.Nodes.Add(roott);
            DataTable dt = dalSystem.QryProjectMShare(CongTy,UserID,UserShare);
            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow dr in dt.Rows)
                {

                    string jsysid = dr["jsysid"].ToString();
                    string sysname = dr["sysname"].ToString();
                    RadTreeNode childNode = new RadTreeNode("");
                    childNode.AllowDrag=false;
                    childNode.AllowDrop=false;
                    childNode.ForeColor = System.Drawing.Color.Red;
                    childNode.Value = jsysid;
                    childNode.Text = sysname;
                    childNode.ToolTip ="System ID :"+ jsysid;
                    roott.Nodes.Add(childNode);
                    roott.ExpandChildNodes();
                    DataTable dtProjectN = dalProjectm.QryProjectNShare(congty, jsysid, UserID,UserShare);
                    if (dtProjectN.Rows.Count > 0)
                    {
                        foreach (DataRow drN in dtProjectN.Rows)
                        {
                            string jsubid = drN["jsubid"].ToString();
                            string jsubname = drN["jsubname"].ToString();
                            RadTreeNode chi1 = new RadTreeNode("Sub System");
                            chi1.AllowDrop = false;
                            chi1.AllowDrag = false;
                            chi1.ForeColor = System.Drawing.Color.Chocolate;
                            chi1.Value = jsubid;
                            chi1.Text = jsubname;
                            chi1.ToolTip = "Sub system ID: " + jsubid;
                            childNode.Nodes.Add(chi1);
                            childNode.ExpandChildNodes();
                            DataTable dtProjectS = dalProjects.QryProjectsShare(congty, jsysid, jsubid,UserID, UserShare);
                            if (dtProjectS.Rows.Count > 0)
                            {
                                foreach (DataRow drS in dtProjectS.Rows)
                                {
                                    string jobid = drS["jobid"].ToString();
                                    string jobname = drS["jobname"].ToString();
                                    RadTreeNode chil2 = new RadTreeNode("Job");
                                    chil2.ForeColor = System.Drawing.Color.Blue;
                                    chil2.Value = jobid;
                                    chil2.Text = jobname;
                                    chil2.ToolTip = "Job ID: " + jobid;
                                    chi1.Nodes.Add(chil2);
                                    chi1.ExpandChildNodes();
                                }
                            }
                        }
                    }
                }
                RadTreeView1.ExpandAllNodes();
            }
            else

            {
                RadTreeView1.Nodes.Clear();
            }
          
        }
        public void XoaMessageTemp()
        {
            string idMessageTemp = "MessageTemp";
            string UserID = Session["UserID"].ToString();
            dalGroup.XoaMessageTemp(UserID, idMessageTemp);
        }
        public void HienThiUserShareLenDropDow()
        {
            string UserID = Session["UserID"].ToString();
            string CongTy = "LTY";
            DataTable dt = dalShare.QryUserLenDropBoxShare(CongTy, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownUserName.DataSource = dt;
                DropDownUserName.DataValueField = "userid";
                DropDownUserName.DataTextField = "USERNAME";
                DropDownUserName.DataBind();
            }
            //DataTable dt1 = dalShare.HienThiUserLenDropBox(CongTy, UserID);
            //if (dt1.Rows.Count > 0)
            //{
            //    DropDownUserName.DataSource = dt1
            //        ;
            //    DropDownUserName.DataValueField = "userid";
            //    DropDownUserName.DataTextField = "USERNAME";
            //    DropDownUserName.DataBind();
            //}
            DropDownUserName.SelectedValue = UserID;
        }
        public void HienThiTreeview()
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string CongTy = "LTY";
            RadTreeNode roottree = new RadTreeNode("System");
            RadTreeView1.Nodes.Clear();
            RadTreeView1.Nodes.Add(roottree);

            DataTable dtSystem = dalSystem.QryProjectTheoUserID(UserID, CongTy);
            if (dtSystem.Rows.Count > 0)
            {
                foreach (DataRow row in dtSystem.Rows)
                {
                    string SysID = row["jsysid"].ToString();
                    string SysName = row["sysname"].ToString();
                    RadTreeNode nootcha = new RadTreeNode("");
                    nootcha.Text = SysName;
                    nootcha.Value = SysID;
                    nootcha.ToolTip = "System ID : " + SysID;
                    //nootcha.Enabled = false;
                    nootcha.AllowDrag = false;
                    nootcha.AllowDrop = false;
                    //nootcha.ForeColor = System.Drawing.Color.Red;
                    nootcha.Text.ToUpper();
                    roottree.Nodes.Add(nootcha);
                    roottree.ExpandChildNodes();
                    DataTable dtProjectm = dalProjectm.QryProjectTheoUserID1(UserID, CongTy, SysID);

                    if (dtProjectm.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtProjectm.Rows)
                        {// 
                            string SystemID = dr["jsysid"].ToString();
                            string subSystemID = dr["jsubid"].ToString();
                            string subName = dr["jsubname"].ToString();
                            RadTreeNode parentNode = new RadTreeNode("Sub System");
                            parentNode.Text = subName;
                            parentNode.ToolTip ="Sub System ID : "+ subSystemID;
                            parentNode.Value = SystemID.ToString();
                           // parentNode.ForeColor = System.Drawing.Color.Chocolate;
                            parentNode.Text.ToUpper();
                            //parentNode.Enabled = false;
                            parentNode.AllowDrag = false;
                            parentNode.AllowDrop = false;
                            nootcha.Nodes.Add(parentNode);
                            nootcha.ExpandChildNodes();
                            DataTable dtProjects = dalProjects.HienThiDanhSachTheoHeThong(UserID, CongTy, SystemID, subSystemID);
                            if (dtProjects.Rows.Count > 0)
                            {//
                                foreach (DataRow drs in dtProjects.Rows)
                                {
                                    string systemID = drs["jsysid"].ToString();
                                    string subSystem = drs["jsubid"].ToString();
                                    string jobID = drs["jobid"].ToString();
                                    string jobName = drs["jobname"].ToString();
                                    RadTreeNode childNode = new RadTreeNode("");
                                    childNode.Value = jobID;
                                    childNode.ToolTip ="Job ID: "+ jobID;
                                    childNode.Target = systemID.ToString();
                                    childNode.Text = jobName;
                                    parentNode.Nodes.Add(childNode);
                                    parentNode.ExpandChildNodes();

                                }
                            }
                        }
                    }

                }
            }
            RadTreeView1.ExpandAllNodes();


        }
        private void RaScheduler_Load()
        {
            Appointment app = new Appointment();
            string UserID = Session["UserID"].ToString();
            // string UserID = "27276";
            List<OCanlendar> list = new List<OCanlendar>();
            DataTable dt = dal.QryTheoNguoiTao(UserID);

            list = Common.ConvertTo<OCanlendar>(dt).ToList();

            RadScheduler1.DataSource = list;
            RadScheduler1.DataBind();


        }
        public void RaScheduler_Load1()
        {

            string UserID = Session["UserID"].ToString();
            // string UserID = "27276";
            List<Appointment> list = new List<Appointment>();
            DataTable dt = dal.QryTheoNguoiTao(UserID);
            foreach (DataRow dr in dt.Rows)
            {
                string per = dr["jobpercent"].ToString();
                Appointment app = new Appointment();
                app.ID = dr["ID"].ToString();
                app.Subject = dr["Subject"].ToString();
                app.Attributes["jobpercent"] = per;
                app.Attributes["GSBH"] = dr["GSBH"].ToString();
                app.Attributes["Userid"] = dr["Userid"].ToString();
                app.Start = DateTime.Parse(dr["pdates"].ToString());
                app.End = DateTime.Parse(dr["pdatee"].ToString());
                app.Description = dr["wkmemo"].ToString();
                //app.RecurrenceRule = per;
                app.BackColor = System.Drawing.Color.Blue;
                list.Add(app);
            }
            RadScheduler1.DataSource = list;
            RadScheduler1.DataBind();
        }

        protected void RadScheduler1_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
        {
            string UserID = (string)Session["UserID"].ToString();
           
            if (UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                if (e.Container.Mode == SchedulerFormMode.Insert)
                {
                    Status = "Insert";

                }
                if (e.Container.Mode == SchedulerFormMode.AdvancedInsert)
                {
                    Status = "AdvancedInsert";
                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFileCalender.xml";
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    startInput.SelectedDate = e.Appointment.Start;
                    endInput.SelectedDate = e.Appointment.End;
                    GridView GridView1 = (GridView)e.Container.FindControl("GridView1");
                    XDocument dov = XDocument.Load(pathServer);
                    var record = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
                    if (record != null)
                    {
                        DataTable ds = new DataTable();
                        ds.Columns.Add("ID");
                        ds.Columns.Add("FileName");
                        foreach (var item in record)
                        {
                            string ID = (string)item.Element("ID");
                            string fileName = (string)item.Element("FileName");
                            DataRow dr = ds.NewRow();
                            if (fileName != null)
                            {
                                dr["FileName"] = fileName;
                                dr["ID"] = ID;
                                ds.Rows.Add(dr);
                            }
                        }
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                   
                }

                if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
                {


                    HiddenField hdffID = ((HiddenField)e.Container.FindControl("hdfID"));
                    hdffID.Value = e.Appointment.ID.ToString();
                    lblABC.Text = hdffID.Value;
                    DataTable dt = dal.QryTheoNguoiTaoTheoID(UserID, int.Parse(hdffID.Value));
                    TextBox subjectBox = (TextBox)e.Container.FindControl("SubjectTextBox");
                    subjectBox.Text = e.Appointment.Subject;
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    startInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    string jsubID = dt.Rows[0]["jsubid"].ToString();
                    string jsysID = dt.Rows[0]["jsysid"].ToString();
                    string jobID=dt.Rows[0]["jobid"].ToString();
                    string gio = DateTime.Parse(e.Appointment.End.ToString()).ToString("HH");
                    int hi = int.Parse(gio);
                    //string ngaybatdau = DateTime.Parse(e.Appointment.Start.ToShortTimeString()).ToString("dd/MM/yyyy");
                    //string ngayketthuc = DateTime.Parse(e.Appointment.End.ToString()).ToString("dd/MM/yyyy");
                    //DateTime EndDate1;
                    //if (ngaybatdau != ngayketthuc)
                    //{
                       
                    //    string datE = ngayketthuc + " 16:30:00 PM"; 
                     
                    //    EndDate1 = DateTime.Parse(datE.ToString());
                    //    // 
                    //}
                    //else
                    //{
                    //    if (hi > 17)
                    //    {
                    //        string datE = ngayketthuc + " 16:30:00 PM";

                    //        EndDate1 = DateTime.Parse(datE.ToString());
                    //    }
                    //    else
                    //    {
                    //        EndDate1 = DateTime.Parse(e.Appointment.End.ToString());
                    //    }
                    //}
                    endInput.SelectedDate = e.Appointment.End;
                    RadTextBox txtDescription = (RadTextBox)e.Container.FindControl("txtDescription");
                    txtDescription.Text = e.Appointment.Description;
                    //RadTextBox txtLink = (RadTextBox)e.Container.FindControl("txtLink");
                    RadNumericTextBox txtPhanTram = (RadNumericTextBox)e.Container.FindControl("txtPhanTram");
                   // OCanlendar objec = new OCanlendar();

                    if ((jsubID != null || jsubID != "") && (jsysID != null || jsysID != "") && (jobID!=null || jobID!=""))
                    {
                        DataTable dtSystem = dalSystem.LaySachProjectMTheoID(congty, jsysID);
                        if (dtSystem.Rows.Count > 0)
                        {
                            RadGrid radGrid2 = (RadGrid)e.Container.FindControl("RadGrid2");
                            radGrid2.DataSource = dtSystem;
                            radGrid2.DataBind();
                        }
                        else
                        {
                            RadGrid radGrid2 = (RadGrid)e.Container.FindControl("RadGrid2");
                            radGrid2.Visible = false;
                            
                        }
                        DataTable dtSubSystem = dalProjectm.LaySachProjectNTheoID(congty, jsysID, jsubID);
                        if (dtSubSystem.Rows.Count > 0)
                        {
                            RadGrid RadGrid3 = (RadGrid)e.Container.FindControl("RadGrid3");
                            RadGrid3.DataSource = dtSubSystem;
                            RadGrid3.DataBind();
                        }
                        else
                        {
                            RadGrid RadGrid3 = (RadGrid)e.Container.FindControl("RadGrid3");
                            RadGrid3.Visible = false;
                           
                        }
                        DataTable dtJob = dalProjects.LaySachProjectSTheoID(congty, jsysID, jsubID, jobID);
                        if (dtJob.Rows.Count > 0)
                        {
                            RadGrid RadGrid4 = (RadGrid)e.Container.FindControl("RadGrid4");
                            RadGrid4.DataSource = dtJob;
                            RadGrid4.DataBind();
                        }
                        else
                        {
                            RadGrid RadGrid4 = (RadGrid)e.Container.FindControl("RadGrid4");
                            RadGrid4.Visible = false;
                           
                        }
                    }
                    txtPhanTram.Text = dt.Rows[0]["jobpercent"].ToString();
                    
                    GridView gridView2 = (GridView)e.Container.FindControl("GridView2");
                    DataTable Ds = dal.QryFileDinhKemTheoID(congty, int.Parse(hdffID.Value));
                    if (Ds.Rows.Count > 0)
                    {
                        DataTable dsA = new DataTable();
                        dsA.Columns.Add("ID");
                        dsA.Columns.Add("FileName");
                        dsA.Columns.Add("FilePath");
                        foreach (DataRow row in Ds.Rows)
                        {
                            string lin1 = row["wklink"].ToString();
                            string lin2 = row["wslink2"].ToString();
                            string lin3 = row["wslink3"].ToString();
                            DataRow d = dsA.NewRow();
                            if (lin1 != "")
                            {
                                string[] a1 = lin1.Split('\\');
                                d["ID"] = "LinkFile";
                                d["FileName"] = a1[2];
                                d["FilePath"] = lin1;
                                dsA.Rows.Add(d);
                            }
                            DataRow d2 = dsA.NewRow();
                            if (lin2 != "")
                            {
                                string[] a2 = lin2.Split('\\');
                                d2["ID"] = "LinkFile2";
                                d2["FileName"] = a2[2];
                                d2["FilePath"] = lin2;
                                dsA.Rows.Add(d2);
                            }
                            DataRow d3 = dsA.NewRow();
                            if (lin3 != "")
                            {
                                string[] a3 = lin3.Split('\\');
                                d3["ID"] = "LinkFile3";
                                d3["FileName"] = a3[2];
                                d3["FilePath"] = lin3;
                                dsA.Rows.Add(d3);
                            }
                        }
                        gridView2.DataSource = dsA;
                        gridView2.DataBind();
                    }
                }
            }
        }

        protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
        {
            string subject = e.Appointment.Subject.Trim();
            string s = e.Appointment.Description;
            if (subject != "")
            {
                string UserID = (string)Session["UserID"].ToString();

                //string UserID = "27276";
                string CongTy = "LTY";
              
               
                DateTime StartDate = e.Appointment.Start;
                //string ngaythang = DateTime.Parse(StartDate.ToShortDateString()).ToString("dd/MM/yyyy");
                //string gio = DateTime.Parse(StartDate.ToLongTimeString()).ToString("HH");
                
                //string phut = DateTime.Parse(e.Appointment.Start.ToShortTimeString()).ToString("mm");
                //int hour = int.Parse(gio.ToString()) + 1;
                //string hour1 = "";
                //if (phut == "30")
                //{
                //    hour1 = hour.ToString() + ":30";
                //}
                //else
                //{
                //    hour1 = hour.ToString() + ":00";
                //}
                //if (hour > 7)
                //{
                //    St = "PM";
                //}
                //else
                //{
                //    St = "AM";
                //}
                string jobid = "";
                string Sub = "";
                //string ngay = ngaythang + " " +hour1 + " " + St;
                // DateTime EndDate = e.Appointment.End;
                DateTime EndDate = e.Appointment.Start.AddHours(1);
                DataTable dt3 = dalProjects.TimTenJob(CongTy, UserID, subject);
                if (dt3.Rows.Count > 0)
                {
                    jobid = dt3.Rows[0]["jobid"].ToString();
                    Sub = dt3.Rows[0]["jobname"].ToString();
                    string lin1 = dt3.Rows[0]["Linkfile"].ToString();
                    string lin2 = dt3.Rows[0]["Linkfile2"].ToString();
                    string lin3 = dt3.Rows[0]["Linkfile3"].ToString();
                    string jsysid = dt3.Rows[0]["jsysid"].ToString();
                    string jsubid = dt3.Rows[0]["jsubid"].ToString();
                    //DateTime StartDate1;
                   // DateTime EndDate1;

                    try
                    {
                        string p = dt3.Rows[0]["jobpercent"].ToString();
                        jobpercent = decimal.Parse(p);
                    }
                    catch
                    {
                        jobpercent = 0;
                    }
                    //string ngaybatdau = DateTime.Parse(dt3.Rows[0]["edates"].ToString()).ToString("dd/MM/yyyy");
                    //string ngayketthuc = DateTime.Parse(dt3.Rows[0]["edatee"].ToString()).ToString("dd/MM/yyyy");
                    //if (ngaybatdau != ngayketthuc)
                    //{
                    //    string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                    //    string datE = ngayketthuc + " " + gio + ":" + phut + " " + St;
                    //    StartDate1 = DateTime.Parse(datS.ToString());
                    //    EndDate1 = DateTime.Parse(datE.ToString());
                    //    // 
                    //}
                    //else
                    //{
                    //    string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                    //    string datE = ngayketthuc + " " + hour.ToString() + ":" + phut + " " + St;
                    //    StartDate1 = DateTime.Parse(datS.ToString());
                    //    EndDate1 = DateTime.Parse(datE.ToString());
                    //}
                    //string datE = ngaythang + " " + hour.ToString() + ":" + phut + " " + St;
                 
                    //EndDate1 = DateTime.Parse(datE.ToString());
                    dal.ThemLichRutGon2(CongTy, UserID, StartDate, EndDate, Sub, jobid, jobpercent,lin1,lin2,lin3,jsubid,jsysid);
                }
                else
                {
                    jobid = "A";
                    dal.ThemLichRutGon1(CongTy, UserID, StartDate, EndDate, subject, jobid, jobpercent);
                }
                #region Cai Nay chua dung den
                //DataTable dt = dalSystem.TimSystemTheoTen(CongTy, UserID, subject);
                //if (dt.Rows.Count > 0)
                //{
                //    DateTime StartDate1 ;
                //    DateTime EndDate1;
                //    string ngaybatdau = DateTime.Parse(dt.Rows[0]["edates"].ToString()).ToString("dd/MM/yyyy");
                //    string ngayketthuc = DateTime.Parse(dt.Rows[0]["edatee"].ToString()).ToString("dd/MM/yyyy");
                //    if (ngaybatdau != ngayketthuc)
                //    {
                //        string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                //        string datE = ngayketthuc + " " + gio + ":" + phut + " " + St;
                //        StartDate1 = DateTime.Parse(datS.ToString());
                //        EndDate1 = DateTime.Parse(datE.ToString());

                //    }
                //    else
                //    {
                //        string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                //        string datE = ngayketthuc + " " + hour.ToString() + ":" + phut + " " + St;
                //        StartDate1 = DateTime.Parse(datS.ToString());
                //        EndDate1 = DateTime.Parse(datE.ToString());
                //    }
                //    dal.ThemLichRutGon(CongTy, UserID, StartDate1, EndDate1, subject);
                //}
                //else
                //{
                //    DataTable dt2 = dalProjectm.TimTenSubsystem(CongTy, UserID, subject);
                //    if (dt2.Rows.Count > 0)
                //    {
                //        DateTime StartDate1;
                //        DateTime EndDate1;
                //        string ngaybatdau = DateTime.Parse(dt2.Rows[0]["edates"].ToString()).ToString("dd/MM/yyyy");
                //        string ngayketthuc = DateTime.Parse(dt2.Rows[0]["edatee"].ToString()).ToString("dd/MM/yyyy");
                //        if (ngaybatdau != ngayketthuc)
                //        {
                //            string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                //            string datE = ngayketthuc + " " + gio + ":" + phut + " " + St;
                //            StartDate1 = DateTime.Parse(datS.ToString());
                //            EndDate1 = DateTime.Parse(datE.ToString());

                //        }
                //        else
                //        {
                //            string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                //            string datE = ngayketthuc + " " + hour.ToString() + ":" + phut + " " + St;
                //            StartDate1 = DateTime.Parse(datS.ToString());
                //            EndDate1 = DateTime.Parse(datE.ToString());
                //        }
                //        dal.ThemLichRutGon(CongTy, UserID, StartDate1, EndDate1, subject);
                //    }
                //    else
                //    {

                //    }
                //}
                #endregion

                /////////// Cach ra
                // string St = "";
                // DateTime StartDate = e.Appointment.Start;
                //string ngaythang = DateTime.Parse(StartDate.ToShortDateString()).ToString("dd/MM/yyyy");
                //string gio = DateTime.Parse(StartDate.ToLongTimeString()).ToString("HH");
                //string phut = DateTime.Parse(StartDate.ToLongDateString()).ToString("mm:ss");
                //int hour = int.Parse(gio.ToString()) + 1;
                //if (hour > 7)
                //{
                //    St = "PM";
                //}
                //else
                //{
                //    St = "AM";
                //}
                // string ngay = ngaythang +" "+ hour.ToString() +":"+phut +" "+St;
                //// DateTime EndDate = e.Appointment.End;
                //DateTime EndDate = DateTime.Parse(ngay.ToString());
                // dal.ThemLichRutGon(CongTy, UserID, StartDate, EndDate, subject);
            }
            RaScheduler_Load1();
        }

        protected void RadScheduler1_AppointmentDelete(object sender, AppointmentDeleteEventArgs e)
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string CongTy = "LTY";
            if (UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                int ID = int.Parse(e.Appointment.ID.ToString());
                dal.XoaLich(UserID, CongTy, ID);
                RaScheduler_Load1();
            }
        }
       
        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string CongTy = "LTY";
            if (UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                if (e.CommandName == "Update")
                {
                    Session["UpdateDB"] = "UpdateDB";
                    decimal JobPercent;
                    DateTime date = DateTime.Today;
                    string IDD = ((HiddenField)e.Container.FindControl("hdfID")).Value;
                    int ID = int.Parse(IDD.ToString());
                    string Name = ((TextBox)e.Container.FindControl("SubjectTextBox")).Text;
                    string Description = ((RadTextBox)e.Container.FindControl("txtDescription")).Text;
                 
                    string phantram = ((RadNumericTextBox)e.Container.FindControl("txtPhanTram")).Text;
                    if (phantram == "")
                    {
                        JobPercent = 0;
                    }
                    else
                    {
                        JobPercent = decimal.Parse(phantram.ToString());
                    }

                    RadDateTimePicker radStartDate = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    DateTime StartDate = DateTime.Parse(radStartDate.DbSelectedDate.ToString());
                    RadDateTimePicker radEndDate = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    DateTime EndDate = DateTime.Parse(radEndDate.DbSelectedDate.ToString());

                                 
                    dal.SuaLich(ID, CongTy, UserID, StartDate, EndDate, Description, JobPercent, date, Name);
                    RaScheduler_Load1();
                }
                if (e.CommandName == "Insert")
                {
                    if (Status == "Insert")
                    {
                        RadTextBox txtName = (RadTextBox)e.Container.FindControl("txtName");
                        //DateTime radStartDate =e.Container.Appointment.Start;
                        DateTime StartDate = e.Container.Appointment.Start;
                        // RadDateTimePicker radEndDate = (RadDateTimePicker)e.Container.Appointment.End;
                        DateTime EndDate = e.Container.Appointment.End.AddHours(1);
                        string jobid = "A";
                        dal.ThemLichRutGon(CongTy, UserID, StartDate, EndDate, txtName.Text, jobid);

                        RaScheduler_Load1();
                    }
                    if (Status == "AdvancedInsert")
                    {
                        decimal Percent;
                        RadDateTimePicker RadStartDate = (RadDateTimePicker)e.Container.FindControl("StartInput");
                        DateTime StartDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                        RadDateTimePicker RadEndDate = (RadDateTimePicker)e.Container.FindControl("EndInput");
                        DateTime EndDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());
                        string Name = ((TextBox)e.Container.FindControl("SubjectTextBox")).Text;
                        string Description = ((RadTextBox)e.Container.FindControl("txtDescription")).Text;
                      
                        string phantram = ((RadNumericTextBox)e.Container.FindControl("txtPhanTram")).Text;
                        if (phantram == "")
                        {
                            Percent = 0;
                        }
                        else
                        {
                            Percent = decimal.Parse(phantram.ToString());
                        }
                        dal.ThemLich(CongTy, UserID, StartDate, EndDate, Description, Percent, UserID, Name);
                        DataTable dt = dal.GetMaxIDCalender();
                        if (dt.Rows.Count > 0)
                        {
                            string I = dt.Rows[0]["ID"].ToString();
                            int IDD = int.Parse(I);
                            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                            string pathServer = pathA + @"\XMLFileCalender.xml";
                            XDocument dov = XDocument.Load(pathServer);
                             var list = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
                             foreach (var item in list)
                             {
                                 string Id = (string)item.Element("ID");
                                 string FileName = (string)item.Element("FileName");
                                 if (Id == "1")
                                 {

                                     dal.UpdateFileAttact1(congty, IDD, FileName);
                                 }
                                 else
                                 {
                                     if (Id == "2")
                                     {
                                         dal.UpdateFileAttact2(congty, IDD, FileName);
                                     }
                                     else
                                     {
                                         dal.UpdateFileAttact3(congty, IDD, FileName);
                                     }
                                 }
                                 item.Remove();
                             }
                             dov.Save(pathServer);
                        }
                        RaScheduler_Load1();
                    }
                }
                if (e.CommandName == "UploadFile")
                {
                    //Button btnUpload = (Button)e.Container.FindControl("btnUpload");
                    FileUpload fileUpdload = (FileUpload)e.Container.FindControl("FileUpload1");
                    string IDD = ((HiddenField)e.Container.FindControl("hdfID")).Value;
                    GridView gridView2 = (GridView)e.Container.FindControl("GridView2");
                    string filename = Path.GetFileName(fileUpdload.PostedFile.FileName);
                    if (filename == "")
                    {
                        return;
                    }
                    else
                    {

                        int ID=int.Parse(IDD);

                        string server = "D:\\AttactFilePDN\\" + filename;
                        DataTable dt=dal.QryFileDinhKemTheoID(congty,ID);
                        if(dt.Rows.Count>0)
                        {
                            string lin1=dt.Rows[0]["wklink"].ToString();
                             string lin2=dt.Rows[0]["wslink2"].ToString();
                             string lin3=dt.Rows[0]["wslink3"].ToString();
                             if (lin1 == "" || lin1 == null)
                             {
                                 fileUpdload.PostedFile.SaveAs(server);

                                 dal.UpdateFileAttact1(congty, ID, server);
                             }
                             else
                             {
                                 if (lin2 == null || lin2 == "")
                                 {
                                     fileUpdload.PostedFile.SaveAs(server);

                                     dal.UpdateFileAttact2(congty, ID, server);
                                 }
                                 else
                                 {
                                     fileUpdload.PostedFile.SaveAs(server);

                                     dal.UpdateFileAttact3(congty, ID, server);
                                 }
                             }
                        }
                        DataTable Ds = dal.QryFileDinhKemTheoID(congty, ID);
                        if (Ds.Rows.Count > 0)
                        {
                            DataTable dsA = new DataTable();
                            dsA.Columns.Add("ID");
                            dsA.Columns.Add("FileName");
                            dsA.Columns.Add("FilePath");
                            foreach (DataRow row1 in Ds.Rows)
                            {
                                string lin1 = row1["wklink"].ToString();
                                string lin2 = row1["wslink2"].ToString();
                                string lin3 = row1["wslink3"].ToString();
                                DataRow d = dsA.NewRow();
                                if (lin1 != "")
                                {
                                    string[] a1 = lin1.Split('\\');
                                    d["ID"] = "LinkFile";
                                    d["FileName"] = a1[2];
                                    d["FilePath"] = lin1;
                                    dsA.Rows.Add(d);
                                }
                                DataRow d2 = dsA.NewRow();
                                if (lin2 != "")
                                {
                                    string[] a2 = lin2.Split('\\');
                                    d2["ID"] = "LinkFile2";
                                    d2["FileName"] = a2[2];
                                    d2["FilePath"] = lin2;
                                    dsA.Rows.Add(d2);
                                }
                                DataRow d3 = dsA.NewRow();
                                if (lin3 != "")
                                {
                                    string[] a3 = lin3.Split('\\');
                                    d3["ID"] = "LinkFile3";
                                    d3["FileName"] = a3[2];
                                    d3["FilePath"] = lin3;
                                    dsA.Rows.Add(d3);
                                }
                            }
                            gridView2.DataSource = dsA;
                            gridView2.DataBind();
                        }
                       
                    }

                }
                if (e.CommandName == "UploadFile12")
                {
                    FileUpload fileUpdload = (FileUpload)e.Container.FindControl("FileUpload12");

                    GridView GridView1 = (GridView)e.Container.FindControl("GridView1");
                    Label lblThongBao = (Label)e.Container.FindControl("lblThongBao");
                
                     string filename = Path.GetFileName(fileUpdload.PostedFile.FileName);
                     if (filename == "")
                     {
                         return;
                     }
                     else
                     {
                         string txt = "";
                         try
                         {
                             txt = Session["attactCalendar"].ToString();
                         }
                         catch
                         {
                             txt = "0";
                         }
                         int ida = int.Parse(txt) + 1;
                         string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                         string pathServer = pathA + @"\XMLFileCalender.xml";
                         string server = "D:\\AttactFilePDN\\" + filename;
                         XmlDocument myXML = new XmlDocument();
                         if (ida < 4)
                         {
                             myXML.Load(pathServer);
                             XmlElement parentElement = myXML.CreateElement("AttactID");
                             XmlElement ID = myXML.CreateElement("ID");
                             ID.InnerText = ida.ToString();
                             XmlElement eUserID = myXML.CreateElement("UserID");
                             eUserID.InnerText = UserID;
                             XmlElement FileName = myXML.CreateElement("FileName");
                             FileName.InnerText = server;
                             parentElement.AppendChild(ID);
                             parentElement.AppendChild(eUserID);
                             parentElement.AppendChild(FileName);
                             myXML.DocumentElement.AppendChild(parentElement);
                             myXML.Save(pathServer);
                             AttactID = ida;
                             Session["attactCalendar"] = ida.ToString();
                             XDocument dov = XDocument.Load(pathServer);
                             var record = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
                             if (record != null)
                             {
                                 DataTable ds = new DataTable();
                                 ds.Columns.Add("ID");
                                 ds.Columns.Add("FileName");
                                 foreach (var item in record)
                                 {
                                     string IDTemp = (string)item.Element("ID");
                                     string FileNameTemp = (string)item.Element("FileName");
                                     DataRow dr = ds.NewRow();
                                     if (FileName != null)
                                     {
                                         dr["ID"] = IDTemp;
                                         dr["FileName"] = FileNameTemp;
                                         ds.Rows.Add(dr);
                                     }
                                 }
                                 GridView1.DataSource = ds;
                                 GridView1.DataBind();

                             }
                         }
                         else
                         {
                             lblThongBao.Text = "limited 3 file";
                         }

                       
                        
                         
                     }
                }
                if (e.CommandName == "XoaThoiMa1")
                {
                    //
                    string IDD = ((HiddenField)e.Container.FindControl("hdfID")).Value;
                    int ID = int.Parse(IDD);
                    GridView gridView2 = (GridView)e.Container.FindControl("GridView2");

                   
                  
               
                    Label lblID = (Label)gridView2.Rows[1].FindControl("lblID11");

                  
                }
                if (e.CommandName == "DownloadThoiMa1")
                {
                    LinkButton linkbtn = sender as LinkButton;
                   // Label lblID = (Label)gridView2.Rows[0].FindControl("lblID11");
                    GridView gridView2 = (GridView)e.Container.FindControl("GridView2");
                    GridViewRow grRow = linkbtn.NamingContainer as GridViewRow;
                    string filePath = gridView2.DataKeys[grRow.RowIndex].Value.ToString();
                    Response.ContentType = "image/jpg";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                    Response.TransmitFile(filePath);
                    Response.End();
                }
            }
        }

        void gridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string IDD = ((HiddenField)e.Container.FindControl("hdfID")).Value;
            //int ID = int.Parse(IDD);
            
            
        }

       

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            //string ngaybatdau = DateTime.Parse(e.Appointment.Start.ToString()).ToString("dd/MM/yyyy");
            //string ngayketthuc = DateTime.Parse(e.Appointment.End.ToString()).ToString("dd/MM/yyyy");
           
            try
            {
              //  DateTime end = DateTime.Parse(ngayketthuc);
                string p1 = e.Appointment.Attributes["jobpercent"];
                if (p1 == null)
                {
                    p1 = "0";
                }

                string aa = "";
                aa += e.Appointment.Subject;
                aa += " Start:" + e.Appointment.Start.ToString("dd/MM/yyyy") + " End: " + e.Appointment.End.ToString("dd/MM/yyyy");
                aa += " Complete: " + p1 + " %";
                decimal phantram;
                try
                {
                    phantram = decimal.Parse(p1);
                }
                catch
                {
                    phantram = 0;
                }

                e.Appointment.ForeColor = System.Drawing.Color.Blue;

                e.Appointment.ToolTip = aa;

                //if (ngayhomnay > end)
                //{
                //    if (phantram == 100)
                //    {
                //        e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                //    }
                //    else
                //    {
                //        e.Appointment.BackColor = System.Drawing.Color.Tomato;
                //    }
                //}
                //else
                //{
                //    if (phantram == 100)
                //    {
                //        e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                //    }
                //    else
                //    {
                //        e.Appointment.BackColor = System.Drawing.Color.Silver;
                //    }
                //}
                if (e.Appointment.Start.ToString("dd/MM/yyyy") != e.Appointment.End.ToString("dd/MM/yyy"))
                {
                    if (phantram == 100)
                    {
                        e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                    }
                    else
                    {
                        e.Appointment.BackColor = System.Drawing.Color.Tomato;
                    }
                }
                else
                {
                    if (phantram == 100)
                    {
                        e.Appointment.BackColor = System.Drawing.Color.Turquoise;
                    }
                    else
                    {
                        e.Appointment.BackColor = System.Drawing.Color.Silver;
                    }
                }

            }
            catch
            {
 
            }
        }

        protected void RadScheduler1_DataBound(object sender, EventArgs e)
        {
            //DateTime StartDate = e.Appointment.Start;
            //HiddenField hdffID = ((HiddenField)e.Container.FindControl("hdfID"));
            //hdffID.Value = e.Appointment.ID.ToString();
            //lblABC.Text = hdffID.Value;
            
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                // Nếu được chọn lại chưa chắc anh đã chọn phương án 1, và có thể chọn phương án 2 
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["USID"], e.Item.ItemIndex);
            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid1.MasterTableView.SortExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1;
                RadGrid1.Rebind();
                //
            }
        }

        protected void DropDownUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            if (DropDownUserName.SelectedValue == UserID)
            {
                HienThiTreeview();
            }
            else
            {
                HienThiTreeviewJobShare();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            if (DropDownUserName.SelectedValue == UserID)
            {
                HienThiTreeview();
            }
            else
            {
                HienThiTreeviewJobShare();
            }
        }

        protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
        {
            // Viet thu o day
            RadGrid grid = (RadGrid)e.Container.FindControl("RadGridAttactFile");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridView gridView2 = (GridView)sender;
            GridViewRow row = gridView2.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID11");
           
            int ID =int.Parse(lblABC.Text.Trim());
            string fileName = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(congty, ID, fileName);
               
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(congty, ID, fileName);
                }
                else
                {
                    dal.UpdateFileAttact3(congty, ID, fileName);
                }
            }
            DataTable Ds = dal.QryFileDinhKemTheoID(congty, ID);
            if (Ds.Rows.Count > 0)
            {
                DataTable dsA = new DataTable();
                dsA.Columns.Add("ID");
                dsA.Columns.Add("FileName");
                dsA.Columns.Add("FilePath");
                foreach (DataRow row1 in Ds.Rows)
                {
                    string lin1 = row1["wklink"].ToString();
                    string lin2 = row1["wslink2"].ToString();
                    string lin3 = row1["wslink3"].ToString();
                    DataRow d = dsA.NewRow();
                    if (lin1 != "")
                    {
                        string[] a1 = lin1.Split('\\');
                        d["ID"] = "LinkFile";
                        d["FileName"] = a1[2];
                        d["FilePath"] = lin1;
                        dsA.Rows.Add(d);
                    }
                    DataRow d2 = dsA.NewRow();
                    if (lin2 != "")
                    {
                        string[] a2 = lin2.Split('\\');
                        d2["ID"] = "LinkFile2";
                        d2["FileName"] = a2[2];
                        d2["FilePath"] = lin2;
                        dsA.Rows.Add(d2);
                    }
                    DataRow d3 = dsA.NewRow();
                    if (lin3 != "")
                    {
                        string[] a3 = lin3.Split('\\');
                        d3["ID"] = "LinkFile3";
                        d3["FileName"] = a3[2];
                        d3["FilePath"] = lin3;
                        dsA.Rows.Add(d3);
                    }
                }
                gridView2.DataSource = dsA;
                gridView2.DataBind();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gridView2 = (GridView)sender;
            GridViewRow row = gridView2.SelectedRow;
            //string filePath = GridView2.DataKeys[grRow.RowIndex].Value.ToString();
            string filePath = gridView2.DataKeys[e.RowIndex]["FilePath"].ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileCalender.xml";
            GridView GridView1 = (GridView)sender;
            GridViewRow row = GridView1.SelectedRow;
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            string UserID = Session["UserID"].ToString();

            System.Xml.Linq.XElement XDoc = System.Xml.Linq.XElement.Load(pathServer);

            IEnumerable<System.Xml.Linq.XElement> Query = (from Q in XDoc.Elements("AttactID")
                                                           where Q.Element("ID").Value == lblID.Text.Trim() && Q.Element("UserID").Value == UserID
                                                           select Q).Distinct();

            if (Query.Count() > 0)
            {

                foreach (System.Xml.Linq.XElement X in Query)
                {
                    X.Remove();
                }


                XDoc.Save(pathServer);

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileCalender.xml";
            GridView GridView1 = (GridView)sender;
            GridViewRow row = GridView1.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID");
            string UserID = Session["UserID"].ToString();

            System.Xml.Linq.XElement XDoc = System.Xml.Linq.XElement.Load(pathServer);

            IEnumerable<System.Xml.Linq.XElement> Query = (from Q in XDoc.Elements("AttactID")
                                                           where Q.Element("ID").Value == lblID.Text.Trim() && Q.Element("UserID").Value == UserID
                                                           select Q).Distinct();

            if (Query.Count() > 0)
            {

                foreach (System.Xml.Linq.XElement X in Query)
                {
                    X.Remove();
                }


                XDoc.Save(pathServer);

            }
            XDocument dov = XDocument.Load(pathServer);
            var record = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
            if (record != null)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                foreach (var item in record)
                {
                    string ID = (string)item.Element("ID");
                    string fileName = (string)item.Element("FileName");
                    DataRow dr = ds.NewRow();
                    if (fileName != null)
                    {
                        dr["FileName"] = fileName;
                        dr["ID"] = ID;
                        ds.Rows.Add(dr);
                    }
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {
            string UpdateDB = (string)Session["UpdateDB"];
            if (UpdateDB == null)
            {
                string idd = e.Appointment.ID.ToString();
                int ID = int.Parse(idd);
                DateTime startDate = e.ModifiedAppointment.Start;
                DateTime enddate = e.ModifiedAppointment.End;
                dal.UpdateCalendar(startDate, enddate, ID);
                RaScheduler_Load1();
            }
            Session.Remove("UpdateDB");
        }

        protected void RadGrid2_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                item.ForeColor = System.Drawing.Color.Red;
                item.BackColor = System.Drawing.Color.White;
            }
        }

        protected void RadGrid3_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                item.BackColor = System.Drawing.Color.White;
                item.ForeColor = System.Drawing.Color.Blue;
            }
        }

        protected void RadGrid4_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                item.BackColor = System.Drawing.Color.White;
                item.ForeColor = System.Drawing.Color.Blue;
            }
        }

        protected void LinkExportJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportJob.aspx");
        }

        protected void LinkExportProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportProject.aspx");
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblUserID");
            Label lblUSID = (Label)e.Item.FindControl("lblUSID");
            string UserID = (string)Session["UserID"];
            if (UserID != null && lbl.Text.Trim()==UserID )
            {
                dalGroup.DeleteMessageByID1(lblUSID.Text.Trim(), congty, UserID);
                HienThiMessage();
            }
          
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            
                if (e.Item is GridDataItem)
                {
                     GridDataItem item = e.Item as GridDataItem;
                    LinkButton link = (LinkButton)e.Item.FindControl("linkDelete");
                    Label lblUserID = (Label)e.Item.FindControl("lblUserID");
                    string UserID = (string)Session["UserID"];
                    if (UserID != null && lblUserID.Text.Trim() == UserID)
                    {
                        link.Enabled = true;
                        link.Attributes.Add("opacity", "100");
                        item.ForeColor = System.Drawing.Color.Blue;
                        link.Attributes["onclick"] = "return confirm('Are you sure?')";
                    }
                    else
                    {
                        //link.Enabled = false;
                        //link.Attributes.Add("opacity", "0");
                        link.Visible = false;
                        item.ForeColor = System.Drawing.Color.DarkViolet;
                    }
                }
        }

        protected void Link8S_Click(object sender, EventArgs e)
        {
            Response.Redirect("page8SDetail.aspx");
        }

        protected void RadTreeView1_NodeClick(object sender, RadTreeNodeEventArgs e)
        {

        }

        

     

       
    }
}