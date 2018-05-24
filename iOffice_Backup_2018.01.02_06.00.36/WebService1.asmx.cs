using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        public WebService1()
        { }
        [WebMethod]
        public List<string> GetAutoCompleteData(string ywpm)
        {
            string abc = Session["UserID"].ToString();
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection("Data Source=192.168.11.15;Initial Catalog=LY_ERP;User ID=Programer;Password=P@ssw0rd"))
            {
                // using (SqlCommand cmd = new SqlCommand("select DISTINCT UserName,UserId from UserInformation where UserName LIKE '%'+@SearchText+'%'", con))
                using (SqlCommand cmd = new SqlCommand("select  distinct top 20 ywpm, cldh  from clzl where ywpm like '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", ywpm);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(string.Format("{0}^^{1}", dr["ywpm"], dr["cldh"]));
                    }
                    return result;
                }
            }
        }
        [WebMethod]
        public List<string> GetData(string DName)
        {
            string gsbh = "LTY";
            string UserID = Session["UserID"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select pdno from pdna where CFMID0='"+UserID+"' and GSBH='"+gsbh+"'and  pdno like '%'+@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", DName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result.Add(dr["pdno"].ToString());
                    }
                    return result;
                }
            }
        }   
    }
}
