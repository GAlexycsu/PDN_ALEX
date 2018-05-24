using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
namespace iOffice.presentationLayer
{
    public partial class addProjects : System.Web.UI.Page
    {
        DAL_Projects dal = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
        userDAL dalUser = new userDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        int AttactID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiNguoiQuanLyTrucTiep();
                string them = (string)Session["themprojects"];
                if (them != null)
                {
                    txtPhanTram.Text = "0";
                    txtedates.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtedatee.Text = DateTime.Today.ToString("yyyy/MM/dd");
                   Session["AttactPro"]="0";
                     divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                    HienThiTextID();
                }
                HienThiDropbox();
                HienThiSystemLenText();
                string suaproject = (string)Session["suaprojects"];
                if (suaproject != null)
                {
                    HienThiDuLieuLenTextbox();
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    HienThiDanhSachDinhKemThuc();
                }
                else
                {
                     Session["AttactPro"]="0";
                     divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                }
            }
        }
        public void HienThiTextID()
        {
            DataTable dt = dal.LayIDJob();
            if (dt.Rows.Count > 0)
            {
                string maxjobid = dt.Rows[0]["maxjobid"].ToString();
                int ID = int.Parse(dt.Rows[0]["jobid"].ToString());
                string IDSYS = "";
                if (ID < 10)
                {
                    IDSYS = "JOB000" + ID;
                    if (IDSYS == maxjobid)
                    {
                        IDSYS = "JOB000" + ID + 1;
                    }
                }
                else
                {
                    if (ID < 99)
                    {
                        IDSYS = "JOB00" + ID;
                        if (IDSYS == maxjobid)
                        {
                            IDSYS = "SUB00" + ID + 1;
                        }
                    }
                    else
                    {
                        if (ID < 999)
                        {
                            IDSYS = "JOB0" + ID;
                            if (IDSYS == maxjobid)
                            {
                                IDSYS = "JOB0" + ID + 1;
                            }
                        }
                        else
                        {
                            IDSYS = "JOB" + ID + 1;
                            if (IDSYS == maxjobid)
                            {
                                IDSYS = "JOB" + ID + 1;
                            }
                        }
                    }
                }
                txtJobID.Text = IDSYS;
            }
            else
            {
                txtJobID.Text = "JOB0001";
            }
        }
        public void HienThiDanhSachFileDinhKemTam()
        {
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileProjectS.xml";
            string UserID = Session["UserID"].ToString();
            XDocument dov = XDocument.Load(pathServer);
            var record= dov.Root.Elements("DBProject").Where(p=>p.Element("UserID").Value==UserID).ToList();
            if (record != null)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                foreach (var item in record)
                {
                    string ID = (string)item.Element("ID");
                    string FileName = (string)item.Element("FileName");
                    DataRow dr = ds.NewRow();
                    if (FileName != null)
                    {
                        dr["ID"] = ID;
                        dr["FileName"] = FileName;
                        ds.Rows.Add(dr);
                    }
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }
        public void HienThiDanhSachDinhKemThuc()
        {
            string systemID=txtSystemID.Text.Trim();
            string subsystemID=DropDownSubSystem.SelectedValue;
            string jobID=txtJobID.Text.Trim();

            DataTable dt = dal.HienThiFileDinhKemThuc(congty, systemID, subsystemID, jobID);
            if (dt.Rows.Count > 0)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                ds.Columns.Add("FilePath");
                foreach (DataRow row in dt.Rows)
                {
                    string lin1 = row["Linkfile"].ToString();
                    string lin2 = row["Linkfile2"].ToString();
                    string lin3 = row["Linkfile3"].ToString();

                    DataRow d = ds.NewRow();
                    if (lin1 != "")
                    {
                        string[] a1 = lin1.Split('\\');
                        d["ID"] = "LinkFile";
                        d["FileName"] = a1[2];
                        d["FilePath"] = lin1;
                        ds.Rows.Add(d);
                    }
                    DataRow d2 = ds.NewRow();
                    if (lin2 != "")
                    {
                        string[] a2 = lin2.Split('\\');
                        d2["ID"] = "LinkFile2";
                        d2["FileName"] = a2[2];
                        d2["FilePath"] = lin2;
                        ds.Rows.Add(d2);
                    }
                    DataRow d3 = ds.NewRow();
                    if (lin3 != "")
                    {
                        string[] a3 = lin3.Split('\\');
                        d3["ID"] = "LinkFile3";
                        d3["FileName"] = a3[2];
                        d3["FilePath"] = lin3;
                        ds.Rows.Add(d3);
                    }
                }
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime UserDate = DateTime.Today;
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string jsysid = txtSystemID.Text.Trim();
            string jsubid = DropDownSubSystem.SelectedValue;
            Session["themjobjsysid"] = jsysid;
            Session["themjobjsubid"] = jsubid;
            string jobid = "";

            //string ticketid=(string)Session["lblticketid"];
            string ticketid = "";
            string jobname = txtjobname.Text.Trim();
            string jobmemo = txtjobmemo.Text.Trim();
            string Yn = "";
            string ngaybatdau = txtedates.Text.Trim();
            string ngayketthuc = txtedatee.Text.Trim();
            string Jleaderid = txtJleaderid.Text.Trim();
            DateTime edates;
            DateTime edatee;
            if (ngaybatdau == ngayketthuc)
            {
                string ngaybd = ngaybatdau + " 07 : 30:00" + "AM";
                string ngaykt = ngayketthuc + " 04 : 30:00" + "PM";
                edates = DateTime.Parse(ngaybd);
                edatee = DateTime.Parse(ngaykt);
                // 
            }
            else
            {
                string ngaybd = ngaybatdau + " 07 : 30:00" + "AM";
                string ngaykt = ngayketthuc + " 07 : 30:00" + "AM";
                edates = DateTime.Parse(ngaybd);
                edatee = DateTime.Parse(ngaykt);
            }
            decimal Spercent;
            try
            {
                Spercent = decimal.Parse(txtPhanTram.Text.Trim());
            }
            catch
            {
                Spercent = 0;
            }
            if (Spercent == 100)
            {
                Yn = "1";
            }
            else
            {
                Yn = "0";
            }
            string PDNO = txtPDNO.Text.Trim();
            string jobnamevn = txtjobnamevn.Text.Trim();
            string jobmemovn = txtjobmemovn.Text.Trim();

            if (UserID == null)
            {

            }
            else
            {
                string them = (string)Session["themprojects"];
                string suaproject = (string)Session["suaprojectm"];
                if (them != null && suaproject == null)
                {
                    //DataTable dt = dal.LayJobMax();
                    //string job = dt.Rows[0]["JobID"].ToString();
                    //if (dt.Rows.Count > 0 && job != "")
                    //{
                    //    int jobs = int.Parse(job) + 1;
                    //    jobid = jobs.ToString();
                    //}
                    //else
                    //{
                    //    jobid = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
                    //}
                    jobid = txtJobID.Text.Trim();
                    dal.ThemProjects(GSBH, jsysid, jsubid, jobid, ticketid, jobname, jobmemo, UserID, UserDate, Yn, Jleaderid, edates, edatee, Spercent, PDNO, jobnamevn, jobmemovn);

                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFileProjectS.xml";
                     XDocument dov = XDocument.Load(pathServer);
                     var list = dov.Root.Elements("DBProject").Where(p => p.Element("UserID").Value == UserID).ToList();
                    foreach (var item in list)
                    {
                        string Id = (string)item.Element("ID");
                        string FileName = (string)item.Element("FileName");
                        if (Id == "1")
                        {
                             dal.UpdateFileAttact1(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), FileName);
                        }
                        else
                        {
                            if (Id == "2")
                            {
                                dal.UpdateFileAttact2(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), FileName);
                            }
                            else
                            {
                                dal.UpdateFileAttact3(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), FileName);
                            }
                        }
                        item.Remove();
                    }
                    dov.Save(pathServer);

                    txtedates.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtedatee.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtjobmemo.Text = "";
                    txtjobmemovn.Text = "";
                    txtjobname.Text = "";
                    txtjobnamevn.Text = "";
                    txtPhanTram.Text = "";
                    HienThiDanhSachDinhKemThuc();
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    Response.Redirect("WF_Projectm.aspx");
                }
                else
                {
                    jobid = (string)Session["lbljobid"];
                    if (checkEndMark.Checked == false)
                    {
                        dal.SuaProjects(GSBH, jsysid, jsubid, jobid, ticketid, jobname, jobmemo, UserID, UserDate, Yn, Jleaderid, edates, edatee, Spercent, PDNO, jobnamevn, jobmemovn);
                    }
                    else
                    {
                        string ynAn = "8";
                        dal.XoaProjects(GSBH, jsysid, jsubid, jobid, ynAn);
                    }
                    Session.Remove("lbljsysid");
                    Session.Remove("lbljsubid");
                    Session.Remove("lbljobid");
                    Session.Remove("lbljobid");
                    
                    Session.Remove("lbljpercent");
                    
                    Response.Redirect("WF_Projectm.aspx");
                }


            }

        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Session.Remove("suaprojectm");
            Session.Remove("lbljsysid");
            Session.Remove("lbljsubid");
            Session.Remove("lbljobid");
            Session.Remove("lbljobid");
            Session.Remove("lblticketid");
            Session.Remove("lbljobname");
            Session.Remove("lbljobmemo");
            Session.Remove("lblJleaderid");
            Session.Remove("lbledates");
            Session.Remove("lbledatee");
            Session.Remove("lbljpercent");
            Session.Remove("lblPDNO");
            Session.Remove("lbljobnamevn");
            Session.Remove("lbljobmemovn");
            Session.Remove("themjobjsubid");
            Session.Remove("themjobjsysid");
            Response.Redirect("WF_Projectm.aspx");
        }
        public void HienThiDropbox()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
          string themjobjsysid=(string)Session["themjobjsysid"];
          string themjobjsubid=(string)Session["themjobjsubid"];
          if (themjobjsubid != null && themjobjsysid != null)
          {
              DataTable dt1 = dal.HienThiLenDropBoxKhiThem(UserID, GSBH, themjobjsubid, themjobjsysid);
              if (dt1.Rows.Count > 0)
              {
                  DropDownSubSystem.DataSource = dt1;
                  DropDownSubSystem.DataValueField = "jsubid";
                  DropDownSubSystem.DataTextField = "jsubname";
                  DropDownSubSystem.DataBind();
              }
          }
          else
          {
              DataTable dt = dal.HienThiLenDropBox(UserID, GSBH);
              if (dt.Rows.Count > 0)
              {
                  DropDownSubSystem.DataSource = dt;
                  DropDownSubSystem.DataValueField = "jsubid";
                  DropDownSubSystem.DataTextField = "jsubname";
                  DropDownSubSystem.DataBind();
              }
          }
        }
        public void HienThiNguoiQuanLyTrucTiep()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            DataTable dt = dalUser.TimNhanVienTheoMa(GSBH, UserID);
            if (dt.Rows.Count > 0)
            {
                txtJleaderid.Text = dt.Rows[0]["USERID"].ToString();
                txtFullname.Text = dt.Rows[0]["USERNAME"].ToString();
            }
        }
        public void HienThiDuLieuLenTextbox()
        {

            string jsysid = (string)Session["lbljsysid"];
            string jsubid = (string)Session["lbljsubid"];
            string jobid = (string)Session["lbljobid"];
            if(jsysid!=null && jsubid!=null &&jobid!=null)
            {
            DataTable dt=dal.LaySachProjectSTheoID(congty,jsysid,jsubid,jobid);
            if(dt.Rows.Count>0)
            {
                 string fromDate=dt.Rows[0]["edates"].ToString();
                string todate=dt.Rows[0]["edatee"].ToString();
                txtedates.Text = DateTime.Parse(fromDate).ToString("yyyy/MM/dd");
                txtedatee.Text = DateTime.Parse(todate).ToString("yyyy/MM/dd");
                try
                {
                    txtPhanTram.Text = dt.Rows[0]["jpercent"].ToString();
                }
                catch
                {
                    txtPhanTram.Text = "0";
                }
                 txtJobID.Text = jobid;
                txtjobname.Text =dt.Rows[0]["jobname"].ToString();
                txtjobmemo.Text =dt.Rows[0]["jobmemo"].ToString();
                txtJleaderid.Text =dt.Rows[0]["Jleaderid"].ToString();
            
                txtPDNO.Text =dt.Rows[0]["PDNO"].ToString();
                txtjobnamevn.Text =dt.Rows[0]["jobnamevn"].ToString();
                txtjobmemovn.Text =dt.Rows[0]["jobmemovn"].ToString();
                string link1 = dt.Rows[0]["LinkFile"].ToString();
                string link2 = dt.Rows[0]["LinkFile2"].ToString();
                string link3 = dt.Rows[0]["LinkFile3"].ToString();
                if (link3 != null)
                {
                    AttactID = 3;
                    Session["AttactPro"] = AttactID.ToString();
                }
                else
                {
                    if (link2 != null)
                    {
                        AttactID = 2;
                        Session["AttactPro"] = AttactID.ToString();
                    }
                    else
                    {
                        if (link1 != null)
                        {
                            AttactID = 1;
                            Session["AttactPro"] = AttactID.ToString();
                        }
                        else
                        {
                            AttactID = 0;
                            Session["AttactPro"] = "0";
                        }
                    }
                }
            }
            }

           
        }
        protected void DropDownSubSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiSystemLenText();
        }
        public void HienThiSystemLenText()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string themjobjsysid = (string)Session["themjobjsysid"];
            string themjobjsubid = (string)Session["themjobjsubid"];
            if (themjobjsubid != null && themjobjsysid != null)
            {
              //  DataTable dt = dal.HienThiSystemLenTextBox(themjobjsubid, UserID, GSBH);
                DataTable dt = dalSystem.LaySachProjectMTheoID(congty, themjobjsysid);
                if (dt.Rows.Count > 0)
                {
                    string SystemName = dt.Rows[0]["sysname"].ToString();
                    string SystemID = dt.Rows[0]["jsysid"].ToString();
                    txtSystemname.Text = SystemName;
                    txtSystemID.Text = SystemID;
                }
            }
            else
            {
                DataTable dt = dal.HienThiSystemLenTextBox(DropDownSubSystem.SelectedValue, UserID, GSBH);
                if (dt.Rows.Count > 0)
                {
                    string SystemName = dt.Rows[0]["SystemName"].ToString();
                    string SystemID = dt.Rows[0]["jsysid"].ToString();
                    txtSystemname.Text = SystemName;
                    txtSystemID.Text = SystemID;
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileProjectS.xml";
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            string UserID = Session["UserID"].ToString();

            System.Xml.Linq.XElement XDoc = System.Xml.Linq.XElement.Load(pathServer);

            IEnumerable<System.Xml.Linq.XElement> Query = (from Q in XDoc.Elements("DBProject")
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
            HienThiDanhSachFileDinhKemTam();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string systemID = txtSystemID.Text.Trim();
            string subsystemID = DropDownSubSystem.SelectedValue;
            string jobID = txtJobID.Text.Trim();
            GridViewRow row = GridView2.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID11");
            string fileName = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(congty, systemID, subsystemID, jobID, fileName);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(congty, systemID, subsystemID, jobID, fileName);
                }
                else
                {
                    dal.UpdateFileAttact3(congty, systemID, subsystemID, jobID, fileName);
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string systemID = txtSystemID.Text.Trim();
            string subsystemID = DropDownSubSystem.SelectedValue;
            string jobID = txtJobID.Text.Trim();
            GridViewRow row = GridView2.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID11");
            string fileName = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(congty, systemID, subsystemID, jobID, fileName);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(congty, systemID, subsystemID, jobID, fileName);
                }
                else
                {
                    dal.UpdateFileAttact3(congty, systemID, subsystemID, jobID, fileName);
                }
            }
            HienThiDanhSachDinhKemThuc();
        }

        protected void linkDownLoad_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = GridView2.DataKeys[0]["FilePath"].ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (fileName == "")
            {
                return;
            }
            else
            {
                string UserID = Session["UserID"].ToString();
                string stFileName = FileUpload1.PostedFile.FileName;
                int lastIndex = 0;
                if (stFileName.Contains('\\'))
                {
                    lastIndex = stFileName.LastIndexOf('\\');
                }
                stFileName = stFileName.Substring(lastIndex + 1);
                string txt = "";
                try
                {
                    txt = Session["AttactPro"].ToString();
                }
                catch
                {
                    txt = "0";
                  
                }
                string server = "D:\\AttactFilePDN\\" + fileName;
                int IDA = int.Parse(txt) + 1;
                FileUpload1.PostedFile.SaveAs(server);
                if (txtJobID.Text.Trim() == "")
                {
                    XmlDocument myXML = new XmlDocument();
                    if (IDA < 4)
                    {
                        string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                        string pathServer = pathA + @"\XMLFileProjectS.xml";
                        myXML.Load(pathServer);
                        XmlElement parentElement = myXML.CreateElement("DBProject");
                        XmlElement ID = myXML.CreateElement("ID");
                        ID.InnerText = IDA.ToString();
                        XmlElement eUserID = myXML.CreateElement("UserID");
                        eUserID.InnerText = UserID;
                        XmlElement FileName = myXML.CreateElement("FileName");
                        FileName.InnerText = server;
                        parentElement.AppendChild(ID);
                        parentElement.AppendChild(eUserID);
                        parentElement.AppendChild(FileName);
                        myXML.DocumentElement.AppendChild(parentElement);
                        myXML.Save(pathServer);
                        AttactID = IDA;
                        Session["AttactPro"] = IDA.ToString();
                    }
                    else
                    {
                        lblThongBao.Text = "Limited 3 file";
                    }
                    divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                }
                else
                {
                    DataTable dt = dal.LaySachProjectSTheoID(congty,txtSystemID.Text.Trim(),DropDownSubSystem.SelectedValue,txtJobID.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        string lin1 = dt.Rows[0]["LinkFile"].ToString();
                        string lin2 = dt.Rows[0]["LinkFile2"].ToString();
                        string lin3 = dt.Rows[0]["LinkFile3"].ToString();
                        if (lin1 == "")
                        {
                            dal.UpdateFileAttact1(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                        }
                        else
                        {
                            if (lin2 == "")
                            {
                                dal.UpdateFileAttact2(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                            }
                            else
                            {
                                if (lin3 == "")
                                {
                                    dal.UpdateFileAttact3(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                                }
                                else
                                {
                                    lblThongBao.Text = "Limited = 3 file";
                                    FileUpload1.Enabled = false;
                                    btnUpload.Enabled = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        DateTime UserDate = DateTime.Today;
                      
                       
                        string jsysid = txtSystemID.Text.Trim();
                        string jsubid = DropDownSubSystem.SelectedValue;

                        string jobid = txtJobID.Text.Trim();
                        if (txtJobID.Text.Trim() != "")
                        {
                            //string ticketid=(string)Session["lblticketid"];
                            string them = (string)Session["themprojects"];
                            if (them != null)
                            {
                                string ticketid = "";
                                string jobname = txtjobname.Text.Trim();
                                string jobmemo = txtjobmemo.Text.Trim();
                                string Yn = "";
                                string ngaybatdau = txtedates.Text.Trim();
                                string ngayketthuc = txtedatee.Text.Trim();
                                string Jleaderid = txtJleaderid.Text.Trim();
                                DateTime edates;
                                DateTime edatee;
                                if (ngaybatdau == ngayketthuc)
                                {
                                    string ngaybd = ngaybatdau + " 07 : 30:00" + "AM";
                                    string ngaykt = ngayketthuc + " 04 : 30:00" + "PM";
                                    edates = DateTime.Parse(ngaybd);
                                    edatee = DateTime.Parse(ngaykt);
                                    // 
                                }
                                else
                                {
                                    string ngaybd = ngaybatdau + " 07 : 30:00" + "AM";
                                    string ngaykt = ngayketthuc + " 07 : 30:00" + "AM";
                                    edates = DateTime.Parse(ngaybd);
                                    edatee = DateTime.Parse(ngaykt);
                                }
                                decimal Spercent;
                                try
                                {
                                    Spercent = decimal.Parse(txtPhanTram.Text.Trim());
                                }
                                catch
                                {
                                    Spercent = 0;
                                }
                                if (Spercent == 100)
                                {
                                    Yn = "1";
                                }
                                else
                                {
                                    Yn = "0";
                                }
                                string PDNO = txtPDNO.Text.Trim();
                                string jobnamevn = txtjobnamevn.Text.Trim();
                                string jobmemovn = txtjobmemovn.Text.Trim();
                                dal.ThemProjects(congty, jsysid, jsubid, jobid, ticketid, jobname, jobmemo, UserID, UserDate, Yn, Jleaderid, edates, edatee, Spercent, PDNO, jobnamevn, jobmemovn);
                                 DataTable dt1 = dal.LaySachProjectSTheoID(congty,txtSystemID.Text.Trim(),DropDownSubSystem.SelectedValue,txtJobID.Text.Trim());
                                 if (dt1.Rows.Count > 0)
                                 {
                                     string lin1 = dt1.Rows[0]["LinkFile"].ToString();
                                     string lin2 = dt1.Rows[0]["LinkFile2"].ToString();
                                     string lin3 = dt1.Rows[0]["LinkFile3"].ToString();
                                     if (lin1 == "")
                                     {
                                         dal.UpdateFileAttact1(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                                     }
                                     else
                                     {
                                         if (lin2 == "")
                                         {
                                             dal.UpdateFileAttact2(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                                         }
                                         else
                                         {
                                             if (lin3 == "")
                                             {
                                                 dal.UpdateFileAttact3(congty, txtSystemID.Text.Trim(), DropDownSubSystem.SelectedValue, txtJobID.Text.Trim(), server);
                                             }
                                             else
                                             {
                                                 lblThongBao.Text = "Limited = 3 file";
                                                 FileUpload1.Enabled = false;
                                                 btnUpload.Enabled = false;
                                             }
                                         }
                                     }
                                 }

                                 txtedates.Text = DateTime.Today.ToString("yyyy/MM/dd");
                                 txtedatee.Text = DateTime.Today.ToString("yyyy/MM/dd");
                                txtjobmemo.Text = "";
                                txtjobmemovn.Text = "";
                                txtjobname.Text = "";
                                txtjobnamevn.Text = "";
                                txtPhanTram.Text = "";
                            }
                        }

                    }
                            divTemp.Visible = false;
                            divAtt.Visible = true;
                            HienThiDanhSachDinhKemThuc();
                  }
                }
            }
        }
    }
