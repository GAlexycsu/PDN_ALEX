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
namespace iOffice.presentationLayer
{
    public partial class pageMain2 : System.Web.UI.Page
    {
        DAL_PDN _bll = new DAL_PDN();
        BLL_TheLogin bllTheLogin = new BLL_TheLogin();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime pNgay = DateTime.Now;
            // DateTime dateToSet = DateTime.Today;
            //Calendar1.SelectedDate = dateToSet;

            //Calendar1.VisibleDate = dateToSet;

            if (!IsPostBack)
            {
                liLinkProvider.Visible = false;
                liLinkSIS.Visible = false;
                liLinkPMBOM.Visible = false;
                liLinkKswiss.Visible = false;
                liLinkImportData.Visible = false;
                liLinkImportBOMTest.Visible = false;
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
                LinkSIS.Visible = false;
                LinkCreateUser.Visible = false;
                HienThiDanhSachHeThong();
                HienThiUserShareLenDropDow();
                HienThiTreeview();
                HienThiTreeviewJobShare();
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
                        List<string> dt = _bll.LayDanhSachPhieuChoKyTheoNguoiKy(UserID, congty);
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
                        DataTable dtt = _bll.LayDanhSachPhieuDaKyDaDich(congty, UserID, pNgay);
                        if (dtt.Rows.Count > 0)
                        {
                            soluong2 = dtt.Rows.Count.ToString();
                            lblDoc2.Text = soluong2;
                        }
                        else
                        {
                            DataTable dtPhieu = _bll.LayDanhSachPhieuDaDich(congty, UserID);
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
                            DataTable dtt = _bll.LayDanhSachPhieuDaKyDaDich(congty, UserID, pNgay);
                            if (dtt.Rows.Count > 0)
                            {
                                soluong2 = dtt.Rows.Count.ToString();
                                lblDoc2.Text = soluong2;
                            }
                            else
                            {
                                DataTable dtPhieu = _bll.LayDanhSachPhieuDaDich(congty, UserID);
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
        public void HienThiMessage()
        {
             string CongTy = "LTY";
             string UserID = (string)Session["UserID"].ToString();
            DateTime date=DateTime.Today;
            DataTable dt = dalGroup.LayDanhSachMessgage(date, CongTy, UserID);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
        }
        public void HienThiTreeviewJobShare()
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string UserShare=DropDownUserName.SelectedValue;
            string CongTy = "LTY";
            RadTreeNode roott = new RadTreeNode("Job Share");
            RadTreeView2.Nodes.Add(roott);
            DataTable dt = dalProjects.LayDanhSachTheoAuditor_TreeView(UserShare, UserID, CongTy);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                   
                    string jobID = dr["jobid"].ToString();
                    string jobName = dr["jobname"].ToString();
                    RadTreeNode childNode = new RadTreeNode("");
                    childNode.Value = jobID;
                    childNode.Text = jobName;
                    roott.Nodes.Add(childNode);
                    roott.ExpandChildNodes();
                }
            }
            RadTreeView2.ExpandAllNodes();
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
            DataTable dt = dalShare.LayDanhSachUserLenDropBoxShare(CongTy, UserID);
            if (dt.Rows.Count > 0)
            {
                DropDownUserName.DataSource = dt;
                DropDownUserName.DataValueField = "userid";
                DropDownUserName.DataTextField = "USERNAME";
                DropDownUserName.DataBind();
            }
        }
        public void HienThiTreeview()
        {
            string UserID = (string)Session["UserID"].ToString();
            //string UserID = "27276";
            string CongTy = "LTY";
            RadTreeNode roottree = new RadTreeNode("System");
            RadTreeView1.Nodes.Add(roottree);

            DataTable dtSystem = dalSystem.LayDanhSachProjectTheoUserID(UserID, CongTy);
            if (dtSystem.Rows.Count > 0)
            {
                foreach (DataRow row in dtSystem.Rows)
                {
                    string SysID = row["jsysid"].ToString();
                    string SysName = row["sysname"].ToString();
                    RadTreeNode nootcha = new RadTreeNode("");
                    nootcha.Text = SysName;
                    nootcha.Value = SysID;
                    nootcha.Enabled = false;
                    nootcha.ForeColor = System.Drawing.Color.Red;
                    roottree.Nodes.Add(nootcha);
                    roottree.ExpandChildNodes();
                    DataTable dtProjectm = dalProjectm.LayDanhSachProjectTheoUserID1(UserID, CongTy, SysID);

                    if (dtProjectm.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtProjectm.Rows)
                        {// 
                            string SystemID = dr["jsysid"].ToString();
                            string subSystemID = dr["jsubid"].ToString();
                            string subName = dr["jsubname"].ToString();
                            RadTreeNode parentNode = new RadTreeNode("Sub System");
                            parentNode.Text = subName;
                            parentNode.ToolTip = subSystemID;
                            parentNode.Value = SystemID.ToString();
                            parentNode.ForeColor = System.Drawing.Color.Red;
                            parentNode.Enabled = false;
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
                                    childNode.ToolTip = subSystem;
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
            DataTable dt = dal.LayDanhSachTheoNguoiTao(UserID);
            
            list = Common.ConvertTo<OCanlendar>(dt).ToList();

            RadScheduler1.DataSource = list;
            RadScheduler1.DataBind();

           
        }
        public void RaScheduler_Load1()
        {
            
            string UserID = Session["UserID"].ToString();
            // string UserID = "27276";
            List<Appointment> list = new List<Appointment>();
            DataTable dt = dal.LayDanhSachTheoNguoiTao(UserID);
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
        public void HienThiDanhSachHeThong()
        {
            try
            {
                DataTable dt = bllTheLogin.GetListSystem(Session["UserID"].ToString());
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string ID = dr["ID"].ToString();
                        switch (ID)
                        {

                            case "2":
                                LinkProvider.Visible = true;
                                liLinkProvider.Visible = true;
                                break;

                            case "4":
                                LinkSIS.Visible = true;
                                liLinkSIS.Visible = true;
                                break;
                            case "5":
                                LinkImportData.Visible = true;
                                liLinkImportData.Visible = true;
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
                DataTable dt = bllTheLogin.GetSystemByID(pID);
                if (dt.Rows.Count > 0)
                {
                    string Url = dt.Rows[0]["StartPage"].ToString();
                    string SID = dt.Rows[0]["ID"].ToString();


                    string SessionID = (Session["UserID"].ToString() + DateTime.Now.ToString()).GetHashCode().ToString();
                    string languege = Session["languege"].ToString();
                    string HashSessionID = bllTheLogin.CalculateMD5Hash(SessionID);
                    bllTheLogin.NhapID(Session["UserID"].ToString(), SID, HashSessionID);
                    Response.Redirect(Url + "?ID=" + SessionID + "&SID=" + SID + "&UID=" + Session["UserID"].ToString() + "&languege=" + languege);
                }

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
                    Response.Redirect("~/presentationLayer/NguoiDich/MyDocusND.aspx");
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

        protected void RadScheduler1_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
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
                if (e.Container.Mode == SchedulerFormMode.Insert)
                {
                    Status = "Insert";

                }
                if (e.Container.Mode == SchedulerFormMode.AdvancedInsert)
                {
                    Status = "AdvancedInsert";
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    startInput.SelectedDate = e.Appointment.Start;
                    endInput.SelectedDate = e.Appointment.End;


                }

                if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
                {


                    HiddenField hdffID = ((HiddenField)e.Container.FindControl("hdfID"));
                    hdffID.Value = e.Appointment.ID.ToString();
                    DataTable dt = dal.LayDanhSachTheoNguoiTaoTheoID(UserID, int.Parse(hdffID.Value));
                    TextBox subjectBox = (TextBox)e.Container.FindControl("SubjectTextBox");
                    subjectBox.Text = e.Appointment.Subject;
                    RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    startInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);
                    RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    endInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);

                    RadTextBox txtDescription = (RadTextBox)e.Container.FindControl("txtDescription");
                    txtDescription.Text = e.Appointment.Description;
                    RadTextBox txtLink = (RadTextBox)e.Container.FindControl("txtLink");
                    RadNumericTextBox txtPhanTram = (RadNumericTextBox)e.Container.FindControl("txtPhanTram");
                    OCanlendar objec = new OCanlendar();
                    txtLink.Text = dt.Rows[0]["wklink"].ToString();
                    txtPhanTram.Text = dt.Rows[0]["jobpercent"].ToString();
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
                //string abc = e.Appointment.ToolTip;
                string St = "";
                DateTime StartDate = e.Appointment.Start;
                string ngaythang = DateTime.Parse(StartDate.ToShortDateString()).ToString("dd/MM/yyyy");
                string gio = DateTime.Parse(StartDate.ToLongTimeString()).ToString("HH");
                string phut = DateTime.Parse(StartDate.ToLongDateString()).ToString("mm:ss");
                int hour = int.Parse(gio.ToString()) + 1;
                if (hour > 7)
                {
                    St = "PM";
                }
                else
                {
                    St = "AM";
                }
                string jobid = "";
                string Sub = "";
                string ngay = ngaythang + " " + hour.ToString() + ":" + phut + " " + St;
                // DateTime EndDate = e.Appointment.End;
                DateTime EndDate = DateTime.Parse(ngay.ToString());
                DataTable dt3 = dalProjects.TimTenJob(CongTy, UserID, subject);
                if (dt3.Rows.Count > 0)
                {
                    jobid = dt3.Rows[0]["jobid"].ToString();
                    Sub = dt3.Rows[0]["jobname"].ToString();
                    DateTime StartDate1;
                    DateTime EndDate1;
                   
                    try
                    {
                        string p = dt3.Rows[0]["jobpercent"].ToString();
                        jobpercent = decimal.Parse(p);
                    }
                    catch
                    {
                        jobpercent = 0;
                    }
                    string ngaybatdau = DateTime.Parse(dt3.Rows[0]["edates"].ToString()).ToString("dd/MM/yyyy");
                    string ngayketthuc = DateTime.Parse(dt3.Rows[0]["edatee"].ToString()).ToString("dd/MM/yyyy");
                    if (ngaybatdau != ngayketthuc)
                    {
                        string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                        string datE = ngayketthuc + " " + gio + ":" + phut + " " + St;
                        StartDate1 = DateTime.Parse(datS.ToString());
                        EndDate1 = DateTime.Parse(datE.ToString());
                        // 
                    }
                    else
                    {
                        string datS = ngaybatdau + " " + gio + ":" + phut + " " + St;
                        string datE = ngayketthuc + " " + hour.ToString() + ":" + phut + " " + St;
                        StartDate1 = DateTime.Parse(datS.ToString());
                        EndDate1 = DateTime.Parse(datE.ToString());
                    }
                    dal.ThemLichRutGon1(CongTy, UserID, StartDate, EndDate, Sub,jobid,jobpercent);
                }
                else
                {
                    jobid = "A";
                    dal.ThemLichRutGon1(CongTy, UserID, StartDate, EndDate, subject,jobid,jobpercent);
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
                    decimal JobPercent;
                    DateTime date = DateTime.Today;
                    string IDD = ((HiddenField)e.Container.FindControl("hdfID")).Value;
                    int ID = int.Parse(IDD.ToString());
                    string Name = ((TextBox)e.Container.FindControl("SubjectTextBox")).Text;
                    string Description = ((RadTextBox)e.Container.FindControl("txtDescription")).Text;
                    string Link = ((RadTextBox)e.Container.FindControl("txtLink")).Text;
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
                    DateTime StartDate = DateTime.Parse(radStartDate.DateInput.SelectedDate.ToString());
                    RadDateTimePicker radEndDate = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    DateTime EndDate = DateTime.Parse(radEndDate.DateInput.SelectedDate.ToString());
                    dal.SuaLich(ID, CongTy, UserID, StartDate, EndDate, Description, Link, JobPercent, date, Name);
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
                        DateTime EndDate = e.Container.Appointment.End;
                        string jobid = "A";
                        dal.ThemLichRutGon(CongTy, UserID, StartDate, EndDate, txtName.Text,jobid);

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
                        string Link = ((RadTextBox)e.Container.FindControl("txtLink")).Text;
                        string phantram = ((RadNumericTextBox)e.Container.FindControl("txtPhanTram")).Text;
                        if (phantram == "")
                        {
                            Percent = 0;
                        }
                        else
                        {
                            Percent = decimal.Parse(phantram.ToString());
                        }
                        dal.ThemLich(CongTy, UserID, StartDate, EndDate, Description, Link, Percent, UserID, Name);
                        RaScheduler_Load1();
                    }
                }
            }
        }

        protected void LinkProvider_Click(object sender, EventArgs e)
        {
            Redirect("2");
        }

        protected void LinkSIS_Click(object sender, EventArgs e)
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

        protected void linkQuenMatKhau_Click(object sender, EventArgs e)
        {
            string UserID = (string)Session["UserID"];

            string languege = (string)Session["languege"];
            string congty = "LTY";
            //Response.Redirect("http://192.168.11.8/PDN/presentationLayer/FrmQuenmatkhauxetduyet.aspx"?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege)
           // Response.Redirect("http://" + alink + "/FrmQuenmatkhauxetduyet.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("FrmQuenmatkhauxetduyet.aspx");
        }

        protected void linkChangPass_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string congty = "LTY";
            string languege = Session["languege"].ToString();
          //  Response.Redirect("http://" + alink + "/frmDoiMatKhauXetDuyet.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("frmDoiMatKhauXetDuyet.aspx");
        }

        protected void linkChuKy_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string congty = "LTY";
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

        protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today; 
            string ngaybatdau=DateTime.Parse(e.Appointment.Start.ToString()).ToString("dd-MM-yyyy") ;
            string ngayketthuc=DateTime.Parse(e.Appointment.End.ToString()).ToString("dd-MM-yyyy");
            DateTime end = DateTime.Parse(ngayketthuc);

            string p1 = e.Appointment.Attributes["jobpercent"];
            if (p1 == null)
            {
                p1 = "0";
            }
            
            string aa = "";
            aa += e.Appointment.Subject ;
            aa +=" Start:"+ngaybatdau+ " End: "+ngayketthuc;
            aa += " Complete: "+ p1+" %";
            decimal phantram;
            try
            {
                phantram = decimal.Parse(p1);
            }
            catch {
                phantram = 0;
            }

            e.Appointment.ForeColor = System.Drawing.Color.Blue;
            
            e.Appointment.ToolTip = aa;
            
            if (ngayhomnay > end)
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

        protected void RadScheduler1_DataBound(object sender, EventArgs e)
        {
          
        }

        protected void LinkGroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx");
        }

        protected void DropDownUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiTreeviewJobShare();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            HienThiTreeviewJobShare();
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

       
        
        
    }
}