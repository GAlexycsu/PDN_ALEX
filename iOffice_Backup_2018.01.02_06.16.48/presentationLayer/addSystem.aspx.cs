using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Xml.Linq;
namespace iOffice.presentationLayer
{
    public partial class addSystem : System.Web.UI.Page
    {
        DAL_System dal = new DAL_System();
        userDAL dalUSer = new userDAL();
        string congty = ConfigurationManager.AppSettings["Congty"].ToString();
        string duongdan = ConfigurationManager.AppSettings["attact"].ToString();
        int AttactID = 0;
        DAL_projectn dalProjectm = new DAL_projectn();
        DAL_Projects dalProjects = new DAL_Projects();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtedates.Text = DateTime.Today.ToString("yyyy/MM/dd");
                txtedatee.Text = DateTime.Today.ToString("yyyy/MM/dd");
                HienThiNguoiQuanLyTrucTiep();
                
                string them = (string)Session["themprojectm"];
                if (them != null)
                {
                    txtPhanTram.Text = "0";
                    AttactID = 0;
                    Session["AttactID"] = "0";
                    HienThiFileDinhKem();
                    HienThiTextID();
                }
                string suaproject = (string)Session["suaprojectm"];
                if (suaproject != null)
                {
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    HienThiDuLieuLenTextBox();
                    HienThiFileDinhKemTHuc();
                }
                else
                {
                    divTemp.Visible = true;
                    divAtt.Visible = false;
                    AttactID = 0;
                    Session["AttactID"] = "0";
                }
            }
        }
        public void HienThiTextID()
        {
            DataTable dt = dal.LayIDSYStem();
            if (dt.Rows.Count > 0)
            {
                string maxjsysid = dt.Rows[0]["maxjsysid"].ToString();
                string abc = dt.Rows[0]["jsysid"].ToString();
                int ID = int.Parse(abc) + 1;
                string IDSYS = "";
                if (ID < 10)
                {
                    IDSYS = "S000" + ID;
                    if (IDSYS == maxjsysid)
                    {
                        IDSYS = "S000" + ID + 1;
                    }
                }
                else
                {
                    if (ID < 99)
                    {
                        IDSYS = "S00" + ID;
                        if (IDSYS == maxjsysid)
                        {
                            IDSYS = "S00" + ID + 1;
                        }
                    }
                    else
                    {
                        if (ID < 999)
                        {
                            IDSYS = "S0" + ID;
                            if (IDSYS == maxjsysid)
                            {
                                IDSYS = "S0" + ID + 1;
                            }
                        }
                        else
                        {
                            IDSYS = "S" + ID;
                            if (IDSYS == maxjsysid)
                            {
                                IDSYS = "S" + ID + 1;
                            }
                        }
                    }
                }
                txtjsysid.Text = IDSYS;
            }
            else
            {
                txtjsysid.Text = "S0001";
            }
        }

        public void HienThiDuLieuLenTextBox()
        {

            string jsysid = (string)Session["jsysid"];

            DataTable dt = dal.LaySachProjectMTheoID(congty, jsysid);
            if (dt.Rows.Count > 0)
            {
                txtjsysid.Text =dt.Rows[0]["jsysid"].ToString();
                txtIDSystem.Text = dt.Rows[0]["jsysid"].ToString();
                txtsysname.Text =dt.Rows[0]["sysname"].ToString();
                txtsysmemo.Text =dt.Rows[0]["sysmemo"].ToString();
                string fromDate = dt.Rows[0]["edates"].ToString();
                string todate = dt.Rows[0]["edatee"].ToString();
                txtedates.Text = DateTime.Parse(fromDate).ToString("yyyy/MM/dd");
                txtedatee.Text = DateTime.Parse(todate).ToString("yyyy/MM/dd");
                try
                {
                    txtPhanTram.Text = dt.Rows[0]["Spercent"].ToString();
                }
                catch
                {
                    txtPhanTram.Text = "0";
                }
                txtsysnamevn.Text =dt.Rows[0]["sysnamevn"].ToString();
                txtsysmemovn.Text =dt.Rows[0]["sysmemovn"].ToString();
                
                string link1 = dt.Rows[0]["LinkFile"].ToString();
                string link2 = dt.Rows[0]["LinkFile2"].ToString();
                string link3 = dt.Rows[0]["LinkFile3"].ToString();
                if (link3 != null)
                {
                    AttactID = 3;
                   Session["AttactID"] = AttactID.ToString();
                }
                else
                {
                    if (link2 != null)
                    {
                        AttactID = 2;
                        Session["AttactID"] = AttactID.ToString();
                    }
                    else
                    {
                        if (link1 != null)
                        {
                            AttactID = 1;
                            Session["AttactID"] = AttactID.ToString();
                        }
                        else
                        {
                            AttactID = 0;
                            Session["AttactID"] = "0";
                        }
                    }
                }
            }

        }
        public void HienThiNguoiQuanLyTrucTiep()
        {
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            DataTable dt = dalUSer.TimNhanVienTheoMa(GSBH, UserID);
            if (dt.Rows.Count > 0)
            {
                txtsLeaderid.Text = dt.Rows[0]["USERID"].ToString();
                lblFulName.Text = dt.Rows[0]["USERNAME"].ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime UserDate = DateTime.Today;
            string UserID = (string)Session["UserID"];
            string GSBH = (string)Session["congty"];
            string jsysid = txtjsysid.Text.Trim();

            string sysname = txtsysname.Text.Trim();
            string sysmemo = txtsysmemo.Text.Trim();


            string Yn = "";
           
            string sLeaderid = txtsLeaderid.Text.Trim();
            string edates = txtedates.Text.Trim();
            string edatee = txtedatee.Text.Trim();
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
            string sysnamevn = txtsysnamevn.Text.Trim();
            string sysmemovn = txtsysmemovn.Text.Trim();

            string them = (string)Session["themprojectm"];
            string suaproject = (string)Session["suaprojectm"];
            if (UserID == null)
            {

            }
            else
            {
            
            
                if (them != null && suaproject == null)
                {
                    #region Set
                       
                     
                    #endregion
                    string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                    string pathServer = pathA + @"\XMLFileSystem.xml";
                    dal.ThemProjectm(GSBH, jsysid, sysname, sysmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), decimal.Parse(Spercent.ToString()), sysnamevn, sysmemovn);

                      XDocument doc = XDocument.Load(pathServer);
                   
                      var list = doc.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
                        foreach (var item in list)
                        {
                            string Id = (string)item.Element("ID");
                            string FileName = (string)item.Element("FileName");
                            if(Id=="1")
                            {
                                dal.UpdateFileAttact1(congty,jsysid,FileName);
                            }
                            else
                            {
                                if(Id=="2")
                                {
                                   dal.UpdateFileAttact2(congty,jsysid,FileName);
                                }
                                else
                                {
                                    dal.UpdateFileAttact3(congty,jsysid,FileName);
                                }
                            }

                            item.Remove();
                        }

                       // doc.Save(Server.MapPath("~/XML/XMLFileSystem.xml"));
                        doc.Save(pathServer);
                    txtjsysid.Text = "";

                    txtsysname.Text = "";
                    txtsysmemo.Text = "";

                    txtedates.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtedatee.Text = DateTime.Today.ToString("yyyy/MM/dd");
                    txtPhanTram.Text = "";
                    txtPDNO.Text = "";
                    txtsysnamevn.Text = "";
                    txtsysmemovn.Text = "";

                    Session.Remove("suaprojectm");
                    Session.Remove("jsysid");
                   

                    Session.Remove("lblsLeaderid");
                    HienThiFileDinhKemTHuc();
                    divTemp.Visible = false;
                    divAtt.Visible = true;
                    Response.Redirect("WF_Projectm.aspx");
                }
                else
                {
                    if (checkEndMark.Checked == false)
                    {
                        dal.SuaProjectm(GSBH, jsysid, sysname, sysmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), decimal.Parse(Spercent.ToString()), sysnamevn, sysmemovn);
                    }
                    else
                    {
                        string ynAn = "8";
                        dal.XoaProjectm(congty, jsysid, ynAn);
                        dalProjectm.XoaProjectnTheoSYstem(congty, jsysid, ynAn);
                        dalProjects.XoaProjectsTheoSystem(congty, jsysid, ynAn);
                       
                    }

                    Session.Remove("jsysid");
                   
                   
                    Session.Remove("lblsLeaderid");
                   
                    Session.Remove("themprojectm");
                    Session.Remove("suaprojectm");
                    Response.Redirect("WF_Projectm.aspx");
                }
            }
           //
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("suaprojectm");
            Session.Remove("jsysid");
            Session.Remove("jsubid");
            Session.Remove("lblsLeaderid"); 
            Session.Remove("themprojectm");
            Session.Remove("suaprojectm");
            Response.Redirect("WF_Projectm.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

            if (filename == "")
            {
                return;
            }
            else
            {
                string UserID = Session["UserID"].ToString();
                string strFileName = FileUpload1.PostedFile.FileName;
                int lastIndex = 0;

                if (strFileName.Contains('\\'))
                {
                    lastIndex = strFileName.LastIndexOf('\\');
                }
                strFileName = strFileName.Substring(lastIndex + 1);
                string txt="";
                try
                {
                    txt = Session["AttactID"].ToString();
                }
                catch
                {
                    txt = "0";
                }
                string server = "D:\\AttactFilePDN\\" + filename;
                string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                string pathServer = pathA+ @"\XMLFileSystem.xml";
                int IDA=int.Parse(txt)+1;
                FileUpload1.PostedFile.SaveAs(server);
                if (txtIDSystem.Text.Trim() == "")
                {
                    XmlDocument myXML = new XmlDocument();
                    if (IDA < 4)
                    {
                      
                        myXML.Load(pathServer);
                        XmlElement parentElement = myXML.CreateElement("AttactID");
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
                        Session["AttactID"] = IDA.ToString();
                    }
                    else
                    {
                        lblThongBao.Text = "Limited=3 file";
                    }
                    divAtt.Visible = false;
                    divTemp.Visible = true;
                    HienThiFileDinhKem();
                }
                else
                {
                     DataTable dt = dal.LaySachProjectMTheoID(congty, txtIDSystem.Text.Trim());
                     if (dt.Rows.Count > 0)
                     {
                         string link1 = dt.Rows[0]["LinkFile"].ToString();
                         string link2 = dt.Rows[0]["LinkFile2"].ToString();
                         string link3 = dt.Rows[0]["LinkFile3"].ToString();
                         if (link1 == null || link1 == "")
                         {
                             dal.UpdateFileAttact1(congty, txtIDSystem.Text.Trim(), server);
                         }
                         else
                         {
                             if (link2 == null || link2 == "")
                             {
                                 dal.UpdateFileAttact2(congty, txtIDSystem.Text.Trim(), server);
                             }
                             else
                             {
                                 if (link3 == null || link3 == "")
                                 {
                                     dal.UpdateFileAttact3(congty, txtIDSystem.Text.Trim(), server);
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
                         
                         string jsysid = txtjsysid.Text.Trim();

                         string sysname = txtsysname.Text.Trim();
                         string sysmemo = txtsysmemo.Text.Trim();


                         string Yn = "";

                         string sLeaderid = txtsLeaderid.Text.Trim();
                         string edates = txtedates.Text.Trim();
                         string edatee = txtedatee.Text.Trim();
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
                         string sysnamevn = txtsysnamevn.Text.Trim();
                         string sysmemovn = txtsysmemovn.Text.Trim();

                         string them = (string)Session["themprojectm"];
                         if (them != null)
                         {
                             dal.ThemProjectm(congty, jsysid, sysname, sysmemo, UserID, UserDate, Yn, sLeaderid, DateTime.Parse(edates.ToString()), DateTime.Parse(edatee.ToString()), decimal.Parse(Spercent.ToString()), sysnamevn, sysmemovn);

                              DataTable dt1 = dal.LaySachProjectMTheoID(congty, txtIDSystem.Text.Trim());
                              if (dt1.Rows.Count > 0)
                              {
                                  string link1 = dt1.Rows[0]["LinkFile"].ToString();
                                  string link2 = dt1.Rows[0]["LinkFile2"].ToString();
                                  string link3 = dt1.Rows[0]["LinkFile3"].ToString();
                                  if (link1 == null || link1 == "")
                                  {
                                      dal.UpdateFileAttact1(congty, txtIDSystem.Text.Trim(), server);
                                  }
                                  else
                                  {
                                      if (link2 == null || link2 == "")
                                      {
                                          dal.UpdateFileAttact2(congty, txtIDSystem.Text.Trim(), server);
                                      }
                                      else
                                      {
                                          if (link3 == null || link3 == "")
                                          {
                                              dal.UpdateFileAttact3(congty, txtIDSystem.Text.Trim(), server);
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

                     divAtt.Visible = true;
                     divTemp.Visible = false;
                     HienThiFileDinhKemTHuc();
                }
            }
        }
        public void HienThiFileDinhKemTHuc()
        {

            DataTable dt = dal.HienThiFileDinhKemThuc(congty, txtIDSystem.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                DataTable ds = new DataTable();
              
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                ds.Columns.Add("FilePath");
                foreach (DataRow row in dt.Rows)
                {
                    string lin1 = row["LinkFile"].ToString();
                    string lin2 = row["LinkFile2"].ToString();
                    string lin3 = row["LinkFile3"].ToString();
                 
                   
                    string[] a3 = lin3.Split('\\');
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
                        d["FilePath"] = lin2;
                        ds.Rows.Add(d2);
                    }
                    DataRow d3 = ds.NewRow();
                    if (lin3 != "")
                    {
                        d3["ID"] = "LinkFile3";
                        d3["FileName"] = a3[2];
                        d["FilePath"] = lin3;
                        ds.Rows.Add(d3);
                    }
                }
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
           
            
        }
        public void HienThiFileDinhKem()
        {
            string UserID = Session["UserID"].ToString();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileSystem.xml";

           // XDocument dov = XDocument.Load(Server.MapPath("~/XML/XMLFileSystem.xml"));
            XDocument dov = XDocument.Load(pathServer);
           
            var records = (from data in dov.Root.Elements("AttactID")
                           where  data.Element("UserID").Value.ToUpper().Contains(UserID)
                           select data).Distinct();
            if(records!=null)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("FileName");
                ds.Columns.Add("ID");
                foreach (var item in records)
                {
                  string filename= (string)item.Element("FileName");
                  string ID = (string)item.Element("ID");
                    DataRow dr = ds.NewRow();
                    if (filename != null || filename != "")
                    {
                        dr["FileName"] = filename;
                       
                        dr["ID"] = (string)item.Element("ID");
                        ds.Rows.Add(dr);
                    }
                    
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            string UserID = Session["UserID"].ToString();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileSystem.xml";
            //System.Xml.Linq.XElement XDoc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/XMLFileSystem.xml"));
            System.Xml.Linq.XElement XDoc = System.Xml.Linq.XElement.Load(pathServer);

            IEnumerable<System.Xml.Linq.XElement> Query = (from Q in XDoc.Elements("AttactID")
                                                           where Q.Element("ID").Value == lblID.Text.Trim() && Q.Element("UserID").Value==UserID
                                                           select  Q ).Distinct();
           

            // Check the count is grether thae equal 1
            if (Query.Count() >0)
            {
                // Remove the element
                foreach (System.Xml.Linq.XElement X in Query)
                {
                    X.Remove();
                }

                // Save the Xml File
                //XDoc.Save(Server.MapPath("~/XML/XMLFileSystem.xml"));
               // XDoc.Save(Server.MapPath("~/AttactFilePDN/XML/XMLFileSystem.xml"));
                XDoc.Save(pathServer);
            }

            HienThiFileDinhKem();      
                
        }

       

       

        protected void linkDownLoad_Click(object sender, EventArgs e)
        {
            
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
          //  string filePath = GridView2.DataKeys[grdRow.RowIndex].Value.ToString();
            string filePath = GridView2.DataKeys[0]["FilePath"].ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            try
            {
                Response.TransmitFile(filePath);
            }
            catch
            {
                lblThongBao.Text = "Could not find file "+filePath;
            }
            Response.End();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            GridViewRow row = GridView2.SelectedRow;
           // Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID11");
            Label lblID = (Label)row.FindControl("lblID11");
            string filename = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(congty, txtIDSystem.Text.Trim(), filename);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(congty, txtIDSystem.Text.Trim(), filename);
                }
                else
                {
                    if (lblID.Text.Trim() == "LinkFile3")
                    {
                        dal.UpdateFileAttact3(congty, txtIDSystem.Text.Trim(), filename);
                    }
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            // Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID11");
            Label lblID = (Label)row.FindControl("lblID11");
            string filename = "";
            if (lblID.Text.Trim() == "LinkFile")
            {
                dal.UpdateFileAttact1(congty, txtIDSystem.Text.Trim(), filename);
            }
            else
            {
                if (lblID.Text.Trim() == "LinkFile2")
                {
                    dal.UpdateFileAttact2(congty, txtIDSystem.Text.Trim(), filename);
                }
                else
                {
                    if (lblID.Text.Trim() == "LinkFile3")
                    {
                        dal.UpdateFileAttact3(congty, txtIDSystem.Text.Trim(), filename);
                    }
                }
            }
            HienThiFileDinhKemTHuc();
        }

        protected void txtsLeaderid_TextChanged(object sender, EventArgs e)
        {
            string UserID=Session["UserID"].ToString();
            if (txtsLeaderid.Text.Trim() != "" && txtsLeaderid.Text.Trim() != UserID)
            {
                DataTable dt = dalUSer.TimNhanVienTheoMa(congty, UserID);
                if (dt.Rows.Count > 0)
                {
                    string fullname = dt.Rows[0]["UserName"].ToString();
                    lblFulName.Text = fullname;
                }
            }
        }

       

        
    }
}