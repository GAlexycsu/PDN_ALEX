using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

    public class LangDAO:GernericDataAccess
    {
        public LangDAO(){}
        public DataTable DanhSachDaNgonNgu()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from GUI_Language where ScreenID<>''";
            return Select(cmd).Tables[0];
        }
        public DataTable DanhSachDaNgonNguTheoID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from GUI_Language where ScreenID<>'' and ScreenID=@ScreenID";
            cmd.Parameters.Add(CreateParameter("ScreenID", ID, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
    }
