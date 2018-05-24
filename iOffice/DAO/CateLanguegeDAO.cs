using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
namespace iOffice.DAO
{
    public class CateLanguegeDAO : BaseGennal1
    {
        protected Hashtable _htbLanguage;
       
      static  iOfficeDataContext db = new iOfficeDataContext();
      //public static List<GUI_Language> Qryngonngu()
      //{
      //    return db.GUI_Languages.ToList();
      //}
      //public static List<GUI_Language> LayIDDiaChiURL(int IDScreen)
      //{
      //    var list = (from p in db.GUI_Languages
      //                from h in db.AbScreens
      //                where (p.ScreenID == h.ScreenID && p.ScreenID == IDScreen)
      //                select p);
      //    return list.ToList();
      //}
      public static DataTable LayIDDiaChiURLTW(int ScreenID)
      {
          SqlCommand cmd = new SqlCommand();
          cmd.CommandText = "LayIDDiaChiURLTW";
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(Para("ScreenID", ScreenID));
          return selex(cmd).Tables[0];
      }
      public static DataTable LayIDDiaChiURLEN(int ScreenID)
      {
          SqlCommand cmd = new SqlCommand();
          cmd.CommandText = "LayIDDiaChiURLEN";
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(Para("ScreenID", ScreenID));
          return selex(cmd).Tables[0];
      }
      public static DataTable LayIDDiaChiURLVN(int ScreenID)
      {
          SqlCommand cmd = new SqlCommand();
          cmd.CommandText = "LayIDDiaChiURLVN";
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(Para("ScreenID", ScreenID));
          return selex(cmd).Tables[0];
      }
      public static List<GUI_Language> LayIDDiaChiURLVaNgonNgu(int IDScreen,string idngonngu)

      {
          
          var list = (from p in db.GUI_Languages
                      from h in db.AbScreens
                      where (p.ScreenID == h.ScreenID && p.ScreenID == IDScreen || p.lbl_VN==idngonngu || p.lbl_TW==idngonngu ||p.lbl_EN==idngonngu)
                      select p);
          return list.ToList();
      }
      public static AbScreen LayURLScreen(string url)
      {
          var list = (from p in db.GUI_Languages
                      from h in db.AbScreens
                      where (p.ScreenID == h.ScreenID && h.AliasScreen == url)
                      select h).FirstOrDefault();
          return list;
      }
      public static List<GUI_Language> LayIDLabel(string Lableid)
      {
          var list = from p in db.GUI_Languages.Where(h => h.lblID == Lableid) select p;
          return list.ToList();
      }
      public static List<AbScreen> QryManHinh()
      {
          return db.AbScreens.ToList();
      }
      public static Hashtable LayNgonNgu(int ScreenId, string idngonngu)
      {
         Hashtable htb ;
          try
          {
              htb = new Hashtable();
              List<Hashtable> las = new List<Hashtable>();

              #region Version Old
             // List<GUI_Language> dt = CateLanguegeDAO.LayIDDiaChiURL(ScreenId);
             //  // List<GUI_Language> dt = CateLanguegeDAO.LayIDDiaChiURLVaNgonNgu(ScreenId,idngonngu);
             //// List<GUI_Language> dt = CateLanguegeDAO.LayIDDiaChiURL(ScreenId);
             //if (idngonngu.Equals("lbl_VN"))
             //{
             //    foreach (GUI_Language lang in dt)
             //    {

             //        htb.Add(lang.lblID, lang.lbl_VN);
             //    }
             //}
             //else
             //{
             //    if (idngonngu.Equals("lbl_TW"))
             //    {
             //        foreach (GUI_Language lang in dt)
             //        {

             //            htb.Add(lang.lblID, lang.lbl_TW);
             //        }
             //    }
             //    else
             //    {
             //        foreach (GUI_Language lang in dt)
             //        {

             //            htb.Add(lang.lblID, lang.lbl_EN);
             //        }
             //    }
             //}
              
            
             // return htb;
              #endregion

              #region cai nay moi
              if (idngonngu.Equals("lbl_VN"))
              {
                  DataTable dt = LayIDDiaChiURLVN(ScreenId);
                  if (dt.Rows.Count > 0)
                  {
                      foreach (DataRow dr in dt.Rows)
                      {

                          htb.Add(dr["lblID"].ToString(), dr["lbl_VN"].ToString());
                      }
                  }
              }
              else
              {
                  if (idngonngu.Equals("lbl_TW"))
                  {
                      DataTable dt = LayIDDiaChiURLTW(ScreenId);
                      if (dt.Rows.Count > 0)
                      {
                          foreach (DataRow dr in dt.Rows)
                          {

                              htb.Add(dr["lblID"].ToString(), dr["lbl_TW"].ToString());
                          }
                      }
                  }
                  else
                  {
                      DataTable dt = LayIDDiaChiURLEN(ScreenId);
                      if (dt.Rows.Count > 0)
                      {
                          foreach (DataRow dr in dt.Rows)
                          {

                              htb.Add(dr["lblID"].ToString(), dr["lbl_EN"].ToString());
                          }
                      }
                  }
              }
              #endregion
              #region XML
              //string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
              //string pathServer = pathA + @"\XMLFileLang.xml";
              //XDocument dov = XDocument.Load(pathServer);
              //var list = dov.Root.Elements("LangID").Where(p => p.Element("ScreenID").Value == ScreenId.ToString()).ToList();
              //if (list.Count > 0)
              //{

              //    switch (idngonngu)
              //    {
              //        case "lbl_VN":
              //            foreach (var item in list)
              //            {
              //                string lblID = (string)item.Element("lblID");
              //                string lblVN = (string)item.Element("lbl_VN");
              //                htb.Add(lblID, lblVN);
              //            }
              //            break;
              //        case "lbl_TW":
              //            foreach (var item in list)
              //            {
              //                string lblID = (string)item.Element("lblID");
              //                string lblTW = (string)item.Element("lbl_TW");
              //                htb.Add(lblID, lblTW);
              //            }
              //            break;
              //        case "lbl_EN":
              //            foreach (var item in list)
              //            {
              //                string lblID = (string)item.Element("lblID");
              //                string lblEN = (string)item.Element("lbl_EN");
              //                htb.Add(lblID, lblEN);
              //            }
              //            break;

              //    }
              //}
              #endregion
              return htb;
          }
          catch (Exception )
          {
              throw;
          }
      }
      public void aa(int ScreenId, string idngonngu)
      {
          string pathA = ConfigurationManager.AppSettings["attactFile"].ToString();
          string pathServer = pathA + @"\XMLFileLang.xml";
          XDocument dov = XDocument.Load(pathServer);
          var list = dov.Root.Elements("LangID").Where(p => p.Element("ScreenID").Value == ScreenId.ToString() ).ToList();
          if (list.Count > 0)
          {
              if (idngonngu == "lbl_VN")
              {
                  foreach (var item in list)
                  {
                      string lblID = (string)item.Element("lblID");
                      string lblVN = (string)item.Element("lbl_VN");
                      
                  }
              }
          }
        
      }
      public static int LayMaManHinh(string url)
      {
          try
          {
              return int.Parse(LayURLScreen(url).ToString());
          }
          catch
          {
              return 0;
          }
      }
      public static AbScreen LayDiaChiAlias(string url, string alias)
      {
          return db.AbScreens.Where(p => p.UrlScreen == url && p.AliasScreen == alias).FirstOrDefault();
      }
    }
}