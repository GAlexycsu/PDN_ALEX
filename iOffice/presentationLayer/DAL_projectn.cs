using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
namespace iOffice.presentationLayer
{
    class DAL_projectn:DAL_SQL_GenericDataAccess
    {
        public DAL_projectn()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable QryProjectTheoUserID(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projectn P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh ";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiFileDinhKemThucProjectN(string GSBH, string jsubid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select LinkFile,LinkFile2,LinkFile3 from Projectn where gsbh=@gsbh and jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            return selex(cmd).Tables[0];
        }
        public DataTable QryProjectTheoUserID1(string UserID, string GSBH, string SystemID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select  P.*,B.USERNAME from Projectn P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and jsysid=@jsysid ";
                cmd.CommandText = "QryProjectTheoUserID1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsysid", SystemID));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDuLieuLeDropBox(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Pr.jsysid,Pr.[sysname] as SystemName from Projectm Pr where Pr.userid=@userid and gsbh=@gsbh";
                cmd.Parameters.Add(Para("userid", UserID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateFileAttact1(string GSBH, string jsubid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectn set LinkFile=@LinkFile where gsbh=@gsbh and  jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("LinkFile", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact2(string GSBH, string jsubid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectn set LinkFile2=@LinkFile2 where gsbh=@gsbh and  jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("LinkFile2", linkFile));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact3(string GSBH, string jsubid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectn set LinkFile3=@LinkFile3 where gsbh=@gsbh and  jsubid=@jsubid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("LinkFile3", linkFile));
            return ExecuteNonQuery(cmd);
        }
        public DataTable HienThiDuLieuLeDropBoxThem(string UserID, string GSBH,string jsysid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Pr.jsysid,Pr.[sysname] as SystemName from Projectm Pr where Pr.userid=@userid and gsbh=@gsbh and jsysid=@jsysid";
                cmd.Parameters.Add(Para("userid", UserID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetDataByGSBHSystem(string UserID, string GSBH, string SystemID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projectn P ";
                cmd.CommandText += "  left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH ";
                cmd.CommandText += " left join Projectm Pr on Pr.jsysid=P.jsysid and Pr.gsbh=P.gsbh";
                cmd.CommandText += "  where Pr.userid=@userid and Pr.gsbh=@gsbh  and Pr.jsysid=@jsysid    ";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsysid", SystemID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryProjectTheoNgayThang(string UserID, string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  P.*,B.USERNAME from Projectn P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and (P.yn='0' or P.yn='1')  ";
            cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("gsbh", GSBH));
            return selex(cmd).Tables[0];
        }
        public DataTable QryProjectTheoNgayThangMaSystem(string UserID, string GSBH,string IDSystem)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  P.*,B.USERNAME from Projectn P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh  and P.jsysid=@jsysid ";
            cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", IDSystem, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
        public DataTable QryProjectTheoNgayThang1(string UserID, string GSBH, string SystemID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  P.*,B.USERNAME from Projectn P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and P.jsysid=@jsysid  ";
            cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", SystemID));
            return selex(cmd).Tables[0];
        }
        public int ThemProjectn(string gsbh, string jsysid, string jsubid, string jsubname, string jsubmemo,
    string userid, DateTime userdate, string yn, string sLeaderid, DateTime edates, DateTime edatee, decimal Spercent, string PDNO, string jsubnamevn, string jsubmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Projectn(gsbh,jsysid,jsubid,jsubname,jsubmemo,";
                cmd.CommandText += " userid,userdate,yn,sLeaderid,edates,edatee,Spercent,PDNO,jsubnamevn,jsubmemovn)";
                cmd.CommandText += " values(@gsbh,@jsysid,@jsubid,@jsubname,@jsubmemo,@userid,@userdate,@yn,@sLeaderid,";
                cmd.CommandText += " @edates,@edatee,@Spercent,@PDNO,@jsubnamevn,@jsubmemovn)";

                cmd.Parameters.Add(Para("gsbh", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("jsysid", jsysid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("jsubid", jsubid, SqlDbType.VarChar));

                cmd.Parameters.Add(Para("jsubname", jsubname, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jsubmemo", jsubmemo, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", userid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("sLeaderid", sLeaderid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("edates", edates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("edatee", edatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("Spercent", Spercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("PDNO", PDNO, SqlDbType.VarChar));

                cmd.Parameters.Add(Para("jsubnamevn", jsubnamevn, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jsubmemovn", jsubmemovn, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int SuaProjectn(string gsbh, string jsysid, string jsubid, string jsubname, string jsubmemo,
    string userid, DateTime userdate, string yn, string sLeaderid, DateTime edates, DateTime edatee, decimal Spercent, string PDNO, string jsubnamevn, string jsubmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projectn set jsubname=@jsubname,jsubmemo=@jsubmemo,";
                cmd.CommandText += " userid=@userid,userdate=@userdate,yn=@yn,sLeaderid=@sLeaderid,edates=@edates,";
                cmd.CommandText += " edatee=@edatee,Spercent=@Spercent,PDNO=@PDNO,jsubnamevn=@jsubnamevn,jsubmemovn=@jsubmemovn";
                cmd.CommandText += " where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));

                cmd.Parameters.Add(Para("jsubname", jsubname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jsubmemo", jsubmemo,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("sLeaderid", sLeaderid));
                cmd.Parameters.Add(Para("edates", edates));
                cmd.Parameters.Add(Para("edatee", edatee));
                cmd.Parameters.Add(Para("Spercent", Spercent));
                cmd.Parameters.Add(Para("PDNO", PDNO));

                cmd.Parameters.Add(Para("jsubnamevn", jsubnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jsubmemovn", jsubmemovn,SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int XoaProjectn(string gsbh, string jsysid, string jsubid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Projectn set yn=@yn where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int XoaProjectnTheoSYstem(string gsbh, string jsysid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projectn set yn=@yn where gsbh=@gsbh and jsysid=@jsysid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimNguoiQuanLyTrucTiep(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select bu.USERID,bu.USERNAME from Busers2 bus";
                cmd.CommandText += " left join  Busers2 bu on bu.USERID=bus.IdUserQuanLyTT";
                cmd.CommandText += " where bus.USERID=@USERID and bus.GSBH=@GSBH";
                cmd.Parameters.Add(Para("USERID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimTenSubsystem(string UserID, string GSBH, string jsubname)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Projectn  where jsubname=@jsubname and userid=@userid and gsbh=@gsbh";
                cmd.Parameters.Add(Para("jsubname", jsubname, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH, SqlDbType.NVarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LaySachProjectNTheoID(string GSBH, string SystemID,string SubSystemID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LaySachProjectNTheoID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("jsysid", SystemID));
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("jsubid", SubSystemID));
            return selex(cmd).Tables[0];
          
        }
        public DataTable QryProjectNShare(string GSBH, string jsysid, string UserID, string EmpShare)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryProjectNShare";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("gsbh", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("jsysid", jsysid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("EmpShare", EmpShare, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayIDsubSystem()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select COUNT(jsubid) as jsubid,MAX(jsubid) as maxjsubid  from Projectn";
            return selex(cmd).Tables[0];

        }
    }
}
