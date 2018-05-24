using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.AutoComplete
{
    /// <summary>
    /// Summary description for WebServiceCLZL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCLZL : System.Web.Services.WebService
    {
        public WebServiceCLZL()
        { }
        [WebMethod]
        public List<string> GetAutoCompleteData(string ywpm)
        {
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
    }
}
