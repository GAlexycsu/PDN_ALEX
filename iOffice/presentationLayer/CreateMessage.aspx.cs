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
using System.Collections;
using System.Xml;
using System.Xml.Linq;
namespace iOffice.presentationLayer
{
    public partial class CreateMessage : System.Web.UI.Page
    {
        DAL_GroupShare dalGroup = new DAL_GroupShare();
        string Congty = ConfigurationManager.AppSettings["Congty"].ToString();
        
        List<string> dsID = new List<string>();
        Hashtable htb = new Hashtable();
        List<AttactDD> dsP = new List<AttactDD>();
       // string IDA = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = dalGroup.GetDate();
                string date = dt.Rows[0]["NgayThang"].ToString();
                DateTime a = DateTime.Parse(date.ToString());
                txtFromDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtToDate.Text = a.ToString("yyyy/MM/dd");
                HienThiGroupLenDropBox();
            }
        }
        public void HienThiGroupLenDropBox()
        {
            string UserID=Session["UserID"].ToString();
            DataTable dt = dalGroup.LayGroupShowDrop(UserID, Congty);
            DropDownGroupName.DataSource = dt;
            DropDownGroupName.DataValueField = "ugno";
            DropDownGroupName.DataTextField = "UGtitle";
            DropDownGroupName.DataBind();
        }

        protected void LinkThem_Click(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("yyyyMMdd");
            string UserID=Session["UserID"].ToString();
            string GroupID = DropDownGroupName.SelectedValue;
            string ID="" ;
            string title = txtTitle.Text.Trim();
            string memo = txtMessage.Text.Trim();
            DateTime TuNgay = DateTime.Parse(txtFromDate.Text.Trim());
            DateTime DenNgay = DateTime.Parse(txtToDate.Text.Trim());
            DataTable dt=dalGroup.GetMaxID();
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string a = dt.Rows[0]["USID"].ToString();
                    int IDD = Int32.Parse(a) + 1;
                    ID = IDD.ToString();
                }
                catch
                {
                    ID = DateTime.Today.ToString("yyyyMM") + "000" + 1;
                }
            }
            else
            {
                ID = DateTime.Today.ToString("yyyyMM") + "000" + 1;
            }
            dalGroup.ThemMessageShare(Congty, ID, UserID, GroupID, title, memo, TuNgay, DenNgay);

           // var doc = XDocument.Load("XMLFile1.xml");
             //       var res = new XDocument
             //(new XElement("data",
             //    (from i in doc.Root.Elements()
             //     where i.Element(XName.Get("start_date")).Value == "2014-10-21 09:45"
             //     select i)));
            
            //DataSet dtXMl = new DataSet();
            //dtXMl.ReadXml(Server.MapPath("~/XML/XMLFileAttactID.xml"));
            //DataTable dtID = dtXMl.Tables[0];
            //if (dtID.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dtID.Rows)
            //    {
            //        string IDAttact = dr["ID"].ToString();
            //       // dalGroup.UpdateMessageID(UserID, IDAttact, ID);
            //    }
            //}

            //string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            //string pathServer = pathA + @"\XMLFileAttactID.xml";
            //XmlDocument dov = new XmlDocument();
            //dov.Load(pathServer);
            //XmlElement em = dov.DocumentElement;
            //XmlNodeList list = em.ChildNodes;
            //for (int i = 0; i <= list.Count; i++)
            //{

            //    if (list[i].ChildNodes[1].InnerText == UserID && list[i].ChildNodes[2].InnerText == date)
            //    {
                   
            //        string IDAttact = list[i].ChildNodes[0].InnerXml;
                   
            //        dalGroup.UpdateMessageID(UserID, IDAttact, ID);
            //        em.RemoveChild(list[i]);
            //    }
            //}
            //dov.Save(pathServer);
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileAttactID.xml";

            XDocument dov = XDocument.Load(pathServer);
            var record = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
            if (record.Count > 0)
            {
                foreach (var item in record)
                {
                    string Id = (string)item.Element("ID");
                    //string FileName = (string)item.Element("FileName");
                    string filePat = (string)item.Element("FilePath");
                    if (Id == "1")
                    {
                        dalGroup.UpdateAttactFile1(Congty, UserID, ID, filePat);
                    }
                    else
                    {
                        if (Id == "2")
                        {
                            dalGroup.UpdateAttactFile2(Congty, UserID, ID, filePat);
                        }
                        else
                        {
                            dalGroup.UpdateAttactFile3(Congty, UserID, ID, filePat);
                        }
                    }
                    item.Remove();
                }
            }
            dov.Save(pathServer);
            txtTitle.Text = "";
            txtMessage.Text = "";
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
            //
        }

        protected void linkAddgroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Group.aspx");
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
               
                string date = DateTime.Today.ToString("yyyyMMdd");
                string UserID = Session["UserID"].ToString();
                string Toi = (string)Session["LoiTaiToi"];
                string strFileName=fileUpload1.PostedFile.FileName;
                int lastIndex=0;
                if(strFileName.Contains('\\'))
                {
                    lastIndex=strFileName.LastIndexOf('\\');
                }
                strFileName=strFileName.Substring(lastIndex+1);
                int IDDD;
                try
                {
                   IDDD= int.Parse(Toi)+1;
                   Session["LoiTaiToi"] = IDDD.ToString();
                }
                catch
                {
                    IDDD = 1;
                    Session["LoiTaiToi"] = IDDD.ToString();
                }
                string server="D:\\AttactFilePDN\\"+filename;
                string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
                string pathServer = pathA + @"\XMLFileAttactID.xml";
                fileUpload1.PostedFile.SaveAs(server);
               // dalGroup.InserFileAttact(UserID,IDA,strFileName, server,idMessageTemp);
                XmlDocument myXML = new XmlDocument();
                myXML.Load(pathServer);
                XmlElement parentElement = myXML.CreateElement("AttactID");
                XmlElement ID = myXML.CreateElement("ID");
                ID.InnerText = IDDD.ToString();
                XmlElement eUserID = myXML.CreateElement("UserID");
                eUserID.InnerText = UserID;
                XmlElement FileNameA = myXML.CreateElement("FileName");
                FileNameA.InnerText = filename;
                XmlElement FileP = myXML.CreateElement("FilePath");
                FileP.InnerText = server;
                XmlElement ngay = myXML.CreateElement("UserDate");
                ngay.InnerText = date;
                parentElement.AppendChild(ID);
                parentElement.AppendChild(eUserID);
                parentElement.AppendChild(ngay);
                parentElement.AppendChild(FileNameA);
                parentElement.AppendChild(FileP);
                myXML.DocumentElement.AppendChild(parentElement);
                myXML.Save(pathServer);

                HienThiFileDinhKem();
            }
        }
        public void HienThiFileDinhKem()
        {
            string UserID=Session["UserID"].ToString();
            //gvDetails.DataSource = dalGroup.QryFileDinhKem(UserID);
            //gvDetails.DataBind();
            string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
            string pathServer = pathA + @"\XMLFileAttactID.xml";
           
            XDocument dov = XDocument.Load(pathServer);
            var record = dov.Root.Elements("AttactID").Where(p => p.Element("UserID").Value == UserID).ToList();
            if (record != null)
            {
                DataTable ds = new DataTable();
                ds.Columns.Add("ID");
                ds.Columns.Add("FileName");
                ds.Columns.Add("FilePath");
                foreach (var item in record)
                {
                    string ID = (string)item.Element("ID");
                    string fileName = (string)item.Element("FileName");
                    string filePat = (string)item.Element("FilePath");
                    DataRow dr = ds.NewRow();
                    if (fileName != null)
                    {
                        dr["FileName"] = fileName;
                        dr["ID"] = ID;
                        dr["FilePath"] = filePat;
                        ds.Rows.Add(dr);
                    }
                }
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
        }
        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            Label lblID = (Label)GridView2.Rows[e.RowIndex].FindControl("lblIDAttactFile");
            int ID=int.Parse(lblID.Text.Trim());
            dalGroup.XoaFileDinhKem(UserID, ID);
            HienThiFileDinhKem();
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            //LinkButton linkbtn = sender as LinkButton;
            //GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            //string filePath = gvDetails.DataKeys[grdRow.RowIndex].Value.ToString();

            //Response.ContentType = "image/jpg";
            //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            //Response.TransmitFile(filePath);
            //Response.End();
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = GridView2.DataKeys[0]["FilePath"].ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void linkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
        }
    }
}