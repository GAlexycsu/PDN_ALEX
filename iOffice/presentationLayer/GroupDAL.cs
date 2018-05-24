using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
     class GroupDAL:DAL_SQL_GenericDataAccess
    {
        public GroupDAL() { }
        public DataTable QryGroup(string userid,string gsbh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select UR.*,B.USERNAME from Ugroup UR left join Busers2 B on UR.userid2=B.USERID where UR.userid=@userid and UR.GSBh=@GSBh";
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("GSBh", gsbh));
            return selex(cmd).Tables[0];

        }
        public DataTable QryGroupTheoNgayThang(string userid, string gsbh,DateTime TuNgay,DateTime DenNgay)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Ugroup where userid=@userid and GSBh=@GSBh";
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("GSBh", gsbh));
            return selex(cmd).Tables[0];
        }
        public int ThemGroup(string userid, string gsbh, string ugno, string userid2, string UGtitle, string UGmemo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ThemGroup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("GSBh",gsbh));
            cmd.Parameters.Add(Para("ugno",ugno));
            cmd.Parameters.Add(Para("userid",userid));
            cmd.Parameters.Add(Para("userid2",userid2));
            cmd.Parameters.Add(Para("UGtitle",UGtitle,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("UGmemo", UGmemo,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int SuaGroup(string userid, string gsbh, string ugno, string userid2, string UGtitle, string UGmemo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SuaGroup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("GSBh", gsbh));
            cmd.Parameters.Add(Para("ugno", ugno));
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("userid2", userid2));
            cmd.Parameters.Add(Para("UGtitle", UGtitle,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("UGmemo", UGmemo,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
          // Tôi yêu em như yêu những như lập trình .Net
          // Có đôi lúc code làm đầu tôi đau

        }
        public int XoaGroup(string userid, string gsbh, string ugno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete Ugroup where GSBh=@GSBh and ugno=@ugno and userid=@userid";
            cmd.Parameters.Add(Para("GSBh", gsbh));
            cmd.Parameters.Add(Para("ugno", ugno));
            cmd.Parameters.Add(Para("userid", userid));
           
            return ExecuteNonQuery(cmd);
        }
        public int XoaGroup1(string userid, string gsbh, string ugno,string UserIDShare)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete Ugroup where GSBh=@GSBh and ugno=@ugno and userid=@userid and userid2=@userid2";
            cmd.Parameters.Add(Para("GSBh", gsbh));
            cmd.Parameters.Add(Para("ugno", ugno));
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("userid2", UserIDShare));
            return ExecuteNonQuery(cmd);
        }
    }
}