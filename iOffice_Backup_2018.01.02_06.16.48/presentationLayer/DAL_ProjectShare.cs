using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
     class DAL_ProjectShare:DAL_SQL_GenericDataAccess
    {
        public DAL_ProjectShare() { }
        public DataTable QryJobShare(string UserID, string GSBH, string systemID, string jubSystemID,int TruongHop)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryProjectShare";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("GSBH",GSBH));
              cmd.Parameters.Add(Para("Jsysid",systemID));
              cmd.Parameters.Add(Para("Jsubid",jubSystemID));
              cmd.Parameters.Add(Para("TruongHop", TruongHop, SqlDbType.Int));
              return Select(cmd).Tables[0];
        }
        public int ThemProjectShare(string GSBH, string Jsysid, string Jsubid, string Jodid,  string juamemo, string Juserid,  string userid, string yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ThemProjectShare";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("Jsysid", Jsysid));
            cmd.Parameters.Add(Para("Jsubid", Jsubid));
            cmd.Parameters.Add(Para("Jodid", Jodid));
            cmd.Parameters.Add(Para("juamemo", juamemo,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Juserid", Juserid));
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("yn", yn));
             return ExecuteNonQuery(cmd);
        }
        public int XoaProjectShare(string GSBH, string Jsysid, string Jsubid, string Jodid, string Juserid, string userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete Projectu where GSBH=@GSBH and Jsysid=@Jsysid and Jodid=@Jodid and Jsubid =@Jsubid and userid=@userid and Juserid=@Juserid";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("Jsysid", Jsysid));
            cmd.Parameters.Add(Para("Jsubid", Jsubid));
            cmd.Parameters.Add(Para("Jodid", Jodid));
            cmd.Parameters.Add(Para("Juserid", Juserid));
            cmd.Parameters.Add(Para("userid", userid)); 
            return ExecuteNonQuery(cmd);
        }
        public DataTable HienThiDropDowSystemTheoUserID(string GSBH,string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select jsysid,[sysname]as SysTemName from Projectm  where gsbh=@gsbh and userid=@userid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("userid", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiDropDowSystemTheoUserIDSua(string GSBH, string UserID, string jsysid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select jsysid,[sysname]as SysTemName from Projectm  where gsbh=@gsbh and userid=@userid and jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiDropDowSubSystemTheoUserID(string GSBH, string UserID, string jsysid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select jsubid,jsubname from Projectn  where gsbh=@gsbh and userid=@userid and jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiDropDowSubSystemTheoUserIDByID(string GSBH, string UserID, string jsubid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select jsubid,jsubname from Projectn  where gsbh=@gsbh and userid=@userid and jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiDropJobBySubSystem(string GSBH, string UserID, string jsysid, string Jsubid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select P.jobid,P.jobname from Projects P where P.gsbh=@gsbh and P.userid=@userid and P.jsysid=@jsysid and P.jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("jsubid", Jsubid));
            return Select(cmd).Tables[0];
        }
        public DataTable LayProjectUSua(string GSBH, string Jsysid, string Jsubid, string Jodid, string Juserid, string userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select PU.*,BU.USERNAME from Projectu PU left join Busers2 BU on PU.Juserid=BU.USERID and PU.GSBH=BU.GSBH ";
            cmd.CommandText+=" where PU.userid=@userid and PU.Jsysid=@Jsysid and PU.Jsubid=@Jsubid and PU.Jodid=@Jodid and PU.Juserid=@Juserid and PU.GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("Jsysid", Jsysid));
            cmd.Parameters.Add(Para("Jsubid", Jsubid));
            cmd.Parameters.Add(Para("Jodid", Jodid));
            cmd.Parameters.Add(Para("Juserid", Juserid));
            cmd.Parameters.Add(Para("userid", userid));
            return Select(cmd).Tables[0];
        }
        public int SuaProjectShare(string GSBH, string Jsysid, string Jsubid, string Jodid, string Juserid, string userid, string juamemo, string Juserid1, string Jodid1)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "	update Projectu set Juserid=@Juserid1,Jodid=@Jodid1,juamemo=@juamemo";
                //cmd.CommandText +=" where userid=@userid and Jsysid=@Jsysid and Jsubid=@Jsubid and Jodid=@Jodid and Juserid=@Juserid and GSBH=@GSBH";
              
                //cmd.Parameters.Add(Para("GSBH", GSBH));
                //cmd.Parameters.Add(Para("Jsysid", Jsysid));
                //cmd.Parameters.Add(Para("Jsubid", Jsubid));
                //cmd.Parameters.Add(Para("Jodid", Jodid));
                //cmd.Parameters.Add(Para("Juserid", Juserid));
                //cmd.Parameters.Add(Para("userid", userid));
                //cmd.Parameters.Add(Para("juamemo",juamemo));
                //cmd.Parameters.Add(Para("Juserid1",Juserid1));
                //cmd.Parameters.Add(Para("Jodid1", Jodid1));
                cmd.CommandText += "if( not exists(select * from Projectu where Juserid='" + Jodid + "'and Jodid='" + Jodid + "' ))";
                cmd.CommandText += "	update Projectu set Juserid='"+Juserid1+"',Jodid='"+Jodid+"',juamemo=N'"+juamemo+"'";
                cmd.CommandText += " where userid='"+userid+"' and Jsysid='"+Jsysid+"' and Jsubid='"+Jsubid+"' and Jodid='"+Jodid1+"' and Juserid='"+Juserid+"' and GSBH='"+GSBH+"'";
              //
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }


        }
        public DataTable QryProjectShareByAuditor(string GSBH, string userid, string Jsubid, DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryProjectShareByAuditor";
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("GSBH",GSBH));
                cmd.Parameters.Add(Para("userid",userid));
                cmd.Parameters.Add(Para("Juserid", Jsubid));
                cmd.Parameters.Add(Para("NgayBatDau",NgayBatDau));
                cmd.Parameters.Add(Para("NgayKetThuc", NgayKetThuc));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryTheoAuditor_Calendar(string Userid, string Juserid,string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryTheoAuditor_Calendar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("Userid", Userid));
                cmd.Parameters.Add(Para("Juserid", Juserid));
                cmd.Parameters.Add(Para("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryUserLenDropBoxShare(string GSBH, string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select distinct PU.userid,BU.USERNAME from Busers2 BU left join  Projectu PU on BU.USERID=PU.Juserid and PU.GSBH=BU.GSBH";
            //cmd.CommandText += " where PU.GSBH=@GSBH and  PU.userid=@Juserid";
              cmd.CommandText="  select distinct isnull(PU.userid ,BU.USERID)as UserID,BU.USERNAME  from Busers2 BU ";
             cmd.CommandText+="  left join  Projectu PU on BU.USERID=PU.userid and PU.GSBH=BU.GSBH";
             cmd.CommandText += "  where PU.GSBH=@GSBH and  PU.Juserid=@Juserid or BU.USERID=@Juserid";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("Juserid", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiUserLenDropBox(string GSBH, string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select USERID,USERNAME from Busers2 where USERID=@USERID and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("USERID", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable QryTheoTheoID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from PSworkm where   ID=@ID";
          
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
        public DataTable HienThiThongTiJobTheoID(string gsbh,string jsysid,string jsubid,string jobid,string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HienThiThongTiJobTheoID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("userid", UserID));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryNguoiDuocShareJob(string gsbh, string jsysid, string jsubid, string jobid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryNguoiDuocShareJob";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
              
                return Select(cmd).Tables[0];

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int XoaNguoiTrongDanhSachShare(string gsbh, string jsysid, string jsubid, string jobid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete Projectu  where jsysid=@jsysid and jsubid=@jsubid and Jodid=@jobid and GSBH=@gsbh";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}