using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Linq;
namespace iOffice.presentationLayer
{
    public partial class addProjectn : System.Web.UI.Page
    {
        DAL_projectn dal = new DAL_projectn();
        userDAL dalUser = new userDAL();
        int AttactID = 0;
   
        DAL_Projects dalProjects = new DAL_Projects();
        DAL_System dalSystem = new DAL_System();
        string conty = ConfigurationManager.AppSettings["Congty"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                HienThiNguoiQuanLyTrucTiep();
                HienThiDropbox();
                string them = (string)Session["themprojectn"];
                if (them != null)
                {
                    txtPhanTram.Text = "0";
                    Session["attactIDP"] = "0";
                    divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                    HienThiTextID();
                }
                string suaproject = (string)Session["suaprojectn"];
                if (suaproject != null)
                {
                    HienThiDuLieuLenTextBox();
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    HienThiDanhSachFileDinhKemThuc();
                }
                else
                {
                    Session["attactIDP"] = "0";
                    divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                }
            }

        }
        public void HienThiTextID()
        {
            DataTable dt = dal.LayIDsubSystem();
            if (dt.Rows.Count > 0)
            {
                string maxjsysid = dt.Rows[0]["maxjsubid"].ToString();
                string abc = dt.Rows[0]["jsubid"].ToString();
                int ID = int.Parse(abc) + 1;
                string IDSYS = "";
                if (ID < 10)
                {
                    IDSYS = "SUB000" + ID;
                    if (IDSYS == maxjsysid)
                    {
                        IDSYS = "SUB000" + ID + 1;
                    }
                }
                else
                {
                    if (ID < 99)
                    {
                        IDSYS = "SUB00" + ID;
                        if (IDSYS == maxjsysid)
                        {
                            IDSYS = "SUB00" + ID + 1;
                        }
                    }
                    else
                    {
                        if (ID < 999)
                        {
                            IDSYS = "SUB0" + ID;
                            if (IDSYS == maxjsysid)
                            {
                                IDSYS = "SUB0" + ID + 1;
                            }
                        }
                        else
                        {
                            IDSYS = "SUB" + ID;
                            if (IDSYS == maxjsysid)
                            {
                                IDSYS = "SUB" + ID + 1;
                            }
                        }
                    }
                }
                txtjsubid.Text = IDSYS;
            }
            else
            {
                txtjsubid.Text = "SUB0001";
            }
        }
        public void HienThiDropbox()
        {
            string UserID = Session["UserID"].ToString();
            string CongTY = "LTY";
            string themjsysid = (string)Session["themjsysid"];
            if (themjsysid != null)
            {
                DataTable dt1 = dal.HienThiDuLieuLeDropBoxThem(UserID, CongTY,themjsysid);
                if (dt1.Rows.Count > 0)
                {
                    DropDownSystem.DataSource = dt1;
                    DropDownSystem.DataValueField = "jsysid";
                    DropDownSystem.DataTextField = "SystemName";
                    DropDownSystem.DataBind();
                }
            }
            else
            {
                DataTable dt = dal.HienThiDuLieuLeDropBox(UserID, CongTY);
                if (dt.Rows.Count > 0)
                {
                    DropDownSystem.DataSource = dt;
                    DropDownSystem.DataValueField = "jsysid";
                    DropDownSystem.DataTextField = "SystemName";
                    DropDownSystem.DataBind();
                }
            }
        }
        public void HienThiDuLieuLenTextBox()
        {


            string jsysid = (string)Session["jsysid"];
            string jsubid = (string)Session["jsubid"];

            DataTable dt = dal.LaySachProjectNTheoID(conty, jsysid, jsubid);
            if (dt.Rows.Count > 0)
            {

                txtjsubid.Enabled = false;
                txtjsubid.Text = jsubid;
                DropDownSystem.DataValueField = jsubid;
                txtjsubname.Text =dt.Rows[0]["jsubname"].ToString();
                txtjsubmemo.Text =dt.Rows[0]["jsubmemo"].ToString();
                string fromDate=dt.Rows[0]["edates"].ToString();
                string todate=dt.Rows[0]["edatee"].ToString();
                txtFromDate.Text = DateTime.Parse(fromDate).ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Parse(todate).ToString("yyyy/MM/dd");
                try
                {
                    txtPhanTram.Text = dt.Rows[0]["Spercent"].ToString();
                }
                catch
                {
                    txtPhanTram.Text = "0";
                }

                txtPDNO.Text =dt.Rows[0]["PDNO"].ToString();

                txtjsubmemovn.Text =dt.Rows[0]["jsubmemovn"].ToString();
                string link1 = dt.Rows[0]["LinkFile"].ToString();
                string link2 = dt.Rows[0]["LinkFile2"].ToString();
                string link3 = dt.Rows[0]["LinkFile3"].ToString();
                if (link3 != null)
                {
                    AttactID = 3;
                    Session["attactIDP"] = AttactID.ToString();
                }
                else
                {
                    if (link2 != null)
                    {
                        AttactID = 2;
                        Session["attactIDP"] = AttactID.ToString();
                    }
                    else
                    {
                        if (link1 != null)
                        {
                            AttactID = 1;
                            Session["attactIDP"] = AttactID.ToString();
                        }
                        else
                        {
                            AttactID = 0;
                            Session["attactIDP"] = "0";
                        }
                    }
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
                txtsLeaderid.Text = dt.Rows[0]["USERID"].ToString();
                txtFuleName.Text = dt.Rows[0]["USERNAME"].ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime UserDate = DateTime.Today;
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string jsysid = DropDownSystem.SelectedValue;
            Session["themjsysid"] = jsysid;
            string jsubid = txtjsubid.Text.Trim();

            string jsubname = txtjsubname.Text.Trim();
            string jsubmemo = txtjsubmemo.Text.Trim();

            string yn = (string)Session["lblyn"];
            string sLeaderid = txtsLeaderid.Text.Trim();
            string edates = txtFromDate.Text.Trim();
            string edatee = txtToDate.Text.Trim();
            decimal Spercent;
            try
            {
                Spercent = decimal.Parse(txtPhanTram.Text.Trim());
            }
            catch
            {
                Spercent = 0;
            }

            string PDNO = txtPDNO.Text.Trim();

            string jsubnamevn = txtjsubnamevn.Text.Trim();
            string jsubmemovn = txtjsubmemovn.Text.Trim();
            string them = (string)Session["themprojectn"];
            string suaproject = (string)Session["suaprojectn"];
            if (UserID == null)
            {

            }
            else
            {
                if (them != null && suaproject == null)
                {
                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFileProjectN.xml";
                    string Yn = "0";
                    dal.ThemProjectn(GSBH, jsysid, jsubid, jsubname, jsubmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), Spercent, PDNO, jsubnamevn, jsubmemovn);
                    XDocument dov = XDocument.Load(pathServer);
                    var list = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
                    foreach (var item in list)
                    {
                        string Id = (string)item.Element("ID");
                        string FileName = (string)item.Element("FileName");
                        if (Id == "1")
                        {
                            dal.UpdateFileAttact1(conty, txtjsubid.Text.Trim(), FileName);
                        }
                        else
                        {
                            if (Id == "2")
                            {
                                dal.UpdateFileAttact2(conty, txtjsubid.Text.Trim(), FileName);
                            }
                            else
                            {
                                dal.UpdateFileAttact3(conty, txtjsubid.Text.Trim(), FileName);
                            }
                        }
                        item.Remove();
                    }
                    dov.Save(pathServer);

                    txtjsubid.Text = "";

                    txtjsubname.Text = "";
                    txtjsubmemo.Text = "";
                    txtFromDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtPhanTram.Text = "";
                    txtPDNO.Text = "";

                    txtjsubmemovn.Text = "";
                    Session.Remove("suaprojectn");
                    HienThiDanhSachFileDinhKemThuc();
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    Session["themjsysid"] = jsysid.ToString().Trim();
                   Response.Redirect("WF_Projectm.aspx");

                }
                else
                {
                    string Yn = "";
                    if (txtPhanTram.Text.Trim() == "100")
                    {
                        Yn = "1";
                    }
                    else
                    {
                        Yn = "0";
                    }
                    if (checkEndMark.Checked == false)
                    {
                        dal.SuaProjectn(GSBH, jsysid, jsubid, jsubname, jsubmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), Spercent, PDNO, jsubnamevn, jsubmemovn);
                    }
                    else
                    {
                        string ynAn = "8";
                        dal.XoaProjectn(GSBH, jsysid, jsubid, ynAn);
                        dalProjects.XoaProjectsTheoSubSystem(GSBH, jsysid, jsubid, ynAn);
                    }

                    Session.Remove("jsubid");

                    Session.Remove("lbljsubname");
                    Session.Remove("lbljsubmemo");
                    Session.Remove("lblsysnamevn");
                    Session.Remove("lbluserdate");
                    Session.Remove("lblyn");
                    Session.Remove("lblsLeaderid");
                    Session.Remove("lbledates");
                    Session.Remove("lbledatee");
                    Session.Remove("lblSpercent");
                    Session.Remove("lblPDNO");

                    Session.Remove("lbljsubnamevn");
                    Session.Remove("lbljsubmemovn");
                    Session.Remove("themprojectn");
                    Session.Remove("suaprojectn");
                    Response.Redirect("WF_Projectm.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("suaprojectn");
            Session.Remove("jsubid");

            Session.Remove("lbljsubname");
            Session.Remove("lbljsubmemo");
            Session.Remove("lblsysnamevn");
            Session.Remove("lbluserdate");
            Session.Remove("lblyn");
            Session.Remove("lblsLeaderid");
            Session.Remove("lbledates");
            Session.Remove("lbledatee");
            Session.Remove("lblSpercent");
            Session.Remove("lblPDNO");

            Session.Remove("lbljsubnamevn");
            Session.Remove("lbljsubmemovn");
            Session.Remove("themprojectn");
            Session.Remove("suaprojectn");
            Response.Redirect("WF_Projectm.aspx");
        
        }

        protected void DropDownSystem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename=Path.GetFileName(FileUpload1.PostedFile.FileName);
            if(filename=="")
            {
                return ;
            }
            else
            {
                string UserID=Session["UserID"].ToString();
                string strFileName=FileUpload1.PostedFile.FileName;
                int lastIndex=0;
                if(strFileName.Contains('\\'))
                {
                    lastIndex =strFileName.LastIndexOf('\\');
                }
                strFileName=strFileName.Substring(lastIndex+1);
                string txt = "";
                try
                {
                    txt = Session["attactIDP"].ToString();
                }
                catch
                {
                    txt = "0";
                }
                string server="D:\\AttactFilePDN\\"+filename;
                string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                string pathServer = pathA + @"\XMLFileProjectN.xml";
                int ida=int.Parse(txt)+1;
                FileUpload1.PostedFile.SaveAs(server);
                if (txtjsubid.Text.Trim() == "")
                {
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
                        Session["attactIDP"] = ida.ToString();
                    }
                    else
                    {
                        lblThongBao.Text = "limited 3 file";
                    }
                    divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiDanhSachFileDinhKemTam();
                }
                else
                {
                    DataTable dt = dal.LaySachProjectNTheoID(conty, DropDownSystem.SelectedValue, txtjsubid.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        string lin1 = dt.Rows[0]["LinkFile"].ToString();
                        string lin2 = dt.Rows[0]["LinkFile2"].ToString();
                        string lin3 = dt.Rows[0]["LinkFile3"].ToString();
                        if (lin1 == "")
                        {
                            dal.UpdateFileAttact1(conty, txtjsubid.Text.Trim(), server);
                        }
                        else
                        {
                            if (lin2 == "")
                            {
                                dal.UpdateFileAttact2(conty, txtjsubid.Text.Trim(), server);
                            }
                            else
                            {
                                if (lin3 == "")
                                {
                                    dal.UpdateFileAttact3(conty, txtjsubid.Text.Trim(), server);
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
                        
                        string jsysid = DropDownSystem.SelectedValue;
                        Session["themjsysid"] = jsysid;
                        string jsubid = txtjsubid.Text.Trim();

                        string jsubname = txtjsubname.Text.Trim();
                        string jsubmemo = txtjsubmemo.Text.Trim();

                        string yn = (string)Session["lblyn"];
                        string sLeaderid = txtsLeaderid.Text.Trim();
                        string edates = txtFromDate.Text.Trim();
                        string edatee = txtToDate.Text.Trim();
                        decimal Spercent;
                        try
                        {
                            Spercent = decimal.Parse(txtPhanTram.Text.Trim());
                        }
                        catch
                        {
                            Spercent = 0;
                        }

                        string PDNO = txtPDNO.Text.Trim();

                        string jsubnamevn = txtjsubnamevn.Text.Trim();
                        string jsubmemovn = txtjsubmemovn.Text.Trim();
                        string them = (string)Session["themprojectn"];
                        if (them != null)
                        {
                            string Yn = "0";
                            dal.ThemProjectn(conty, jsysid, jsubid, jsubname, jsubmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), Spercent, PDNO, jsubnamevn, jsubmemovn);
                            DataTable dt1 = dal.LaySachProjectNTheoID(conty, DropDownSystem.SelectedValue, txtjsubid.Text.Trim());
                            if (dt1.Rows.Count > 0)
                            {
                                string lin1 = dt1.Rows[0]["LinkFile"].ToString();
                                string lin2 = dt1.Rows[0]["LinkFile2"].ToString();
                                string lin3 = dt1.Rows[0]["LinkFile3"].ToString();
                                if (lin1 == "")
                                {
                                    dal.UpdateFileAttact1(conty, txtjsubid.Text.Trim(), server);
                                }
                                else
                                {
                                    if (lin2 == "")
                                    {
                                        dal.UpdateFileAttact2(conty, txtjsubid.Text.Trim(), server);
                                    }
                                    else
                                    {
                                        if (lin3 == "")
                                        {
                                            dal.UpdateFileAttact3(conty, txtjsubid.Text.Trim(), server);
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
                        }
                    }
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    HienThiDanhSachFileDinhKemThuc();
                }
            }
        }
        public void HienThiDanhSachFileDinhKemTam()
        {
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileProjectN.xml";
            string UserID = Session["UserID"].ToString();
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
        public void HienThiDanhSachFileDinhKemThuc()
        {
            DataTable dt = dal.HienThiFileDinhKemThucProjectN(conty, txtjsubid.Text.Trim());
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            string UserID = Session["UserID"].ToString();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileProjectN.xml";
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
            HienThiDanhSachFileDinhKemTam();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID11");
            string fileName = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(conty, txtjsubid.Text.Trim(), fileName);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(conty, txtjsubid.Text.Trim(), fileName);
                }
                else
                {
                    dal.UpdateFileAttact3(conty, txtjsubid.Text.Trim(), fileName);
                }
            }
            HienThiDanhSachFileDinhKemThuc();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID11");
            string fileName = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(conty, txtjsubid.Text.Trim(), fileName);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(conty, txtjsubid.Text.Trim(), fileName);
                }
                else
                {
                    dal.UpdateFileAttact3(conty, txtjsubid.Text.Trim(), fileName);
                }
            }
            HienThiDanhSachFileDinhKemThuc();
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
    }
}