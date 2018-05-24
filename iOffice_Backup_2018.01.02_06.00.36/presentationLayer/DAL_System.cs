using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_System:DAL_SQL_GenericDataAccess
    {
        public DAL_System()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable HienThiDropBoxSystem(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select jsysid,[sysname] as SystemName from Projectm where userid=@userid and gsbh=@gsbh ";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable QryProjectTheoUserID(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryProjectTheoUserID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryProjectTheoUserIDShare(string UserID, string GSBH, string UserShare)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryProjectTheoUserIDShare";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("userid", UserShare, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("sLeaderid", UserID));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuystemTheoDieuKien(string GSBH, string SYstemID, string pTuNgay, string DenNgay, string UserID,string ynEnd,string ynHide)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select P.*,B.USERNAME from Projectm P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH";
            cmd.CommandText += " where  P.GSBH=@gsbh";
            cmd.CommandText += " and P.jsysid=@jsysid";
           // cmd.CommandText += " and P.sLeaderid like @sLeaderid+'%'";
            cmd.CommandText += " and P.userid=@userid";
            //cmd.CommandText += " or (P.edates=@edates and P.edatee=@edatee)";
            cmd.CommandText += " and (P.yn=@ynEnd or P.yn=@ynHide)";
            cmd.Parameters.Add(Para("ynEnd", ynEnd, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("ynHide", ynHide, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", SYstemID));
            //cmd.Parameters.Add(Para("edates", pTuNgay, SqlDbType.DateTime, true));
            //cmd.Parameters.Add(Para("edatee", DenNgay, SqlDbType.DateTime, true));
         
            cmd.Parameters.Add(Para("userid", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuystemTheoDieuKienHuy(string GSBH, string SYstemID, string pTuNgay, string DenNgay, string ynCancel,string ynHide, string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select P.*,B.USERNAME from Projectm P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH";
            cmd.CommandText += " where  P.GSBH=@gsbh";
            cmd.CommandText += " and P.jsysid=@jsysid";
            // cmd.CommandText += " and P.sLeaderid like @sLeaderid+'%'";
            cmd.CommandText += " and P.userid=@userid";
            //cmd.CommandText += " or (P.edates=@edates and P.edatee=@edatee)";
            cmd.CommandText += " and (P.yn=@ynHide or P.yn=@ynCancel)";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", SYstemID));
            cmd.Parameters.Add(Para("edates", pTuNgay, SqlDbType.DateTime, true));
            cmd.Parameters.Add(Para("edatee", DenNgay, SqlDbType.DateTime, true));
            cmd.Parameters.Add(Para("ynCancel", ynCancel));
            cmd.Parameters.Add(Para("ynHide", ynHide));
            cmd.Parameters.Add(Para("userid", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuystemTheoDieuKien1(string GSBH, string pTuNgay, string DenNgay,  string UserID,string ynEnd,string ynHide)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select P.*,B.USERNAME from Projectm P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH";
            cmd.CommandText += " where  P.GSBH=@gsbh";
    
            //cmd.CommandText += " and P.sLeaderid like @sLeaderid+'%'";
            cmd.CommandText += " and P.userid=@userid";
            //cmd.CommandText += " or (P.edates=@edates and P.edatee=@edatee)";
            cmd.CommandText += " and (P.yn=@ynEnd or P.yn=@ynHide)";
            cmd.Parameters.Add(Para("gsbh", GSBH));
       
            //cmd.Parameters.Add(Para("edates", pTuNgay, SqlDbType.DateTime, true));
            //cmd.Parameters.Add(Para("edatee", DenNgay, SqlDbType.DateTime, true));
            
            cmd.Parameters.Add(Para("userid", UserID));
            cmd.Parameters.Add(Para("ynEnd", ynEnd, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("ynHide", ynHide, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuystemTheoDieuKien1Huy(string GSBH, string pTuNgay, string DenNgay, string ynCancel,string ynHide, string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select P.*,B.USERNAME from Projectm P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH";
            cmd.CommandText += " where  P.GSBH=@gsbh";

            //cmd.CommandText += " and P.sLeaderid like @sLeaderid+'%'";
            cmd.CommandText += " and P.userid=@userid";
           // cmd.CommandText += " or (P.edates=@edates and P.edatee=@edatee)";
            cmd.CommandText += " and (P.yn=@ynCancel or P.yn=@ynHide)";
            cmd.Parameters.Add(Para("gsbh", GSBH));

            cmd.Parameters.Add(Para("edates", pTuNgay, SqlDbType.DateTime, true));
            cmd.Parameters.Add(Para("edatee", DenNgay, SqlDbType.DateTime, true));
            cmd.Parameters.Add(Para("ynHide", ynHide));
            cmd.Parameters.Add(Para("ynCancel", ynCancel));
            cmd.Parameters.Add(Para("userid", UserID));
            return Select(cmd).Tables[0];
        }
        public DataTable QryProjectTheoNgayThang(string UserID, string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  P.*,B.USERNAME from Projectm P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and (P.yn='0' or P.yn='1') ";
            cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("gsbh", GSBH));
            return Select(cmd).Tables[0];
        }
        public int ThemProjectm(string gsbh, string jsysid, string sysname, string sysmemo,
    string userid, DateTime userdate, string yn, string sLeaderid, DateTime edates, DateTime edatee, decimal Spercent, string sysnamevn, string sysmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Projectm(gsbh,jsysid,[sysname],sysmemo,";
                cmd.CommandText += " userid,userdate,yn,sLeaderid,edates,edatee,Spercent,sysnamevn,sysmemovn)";
                cmd.CommandText += " values(@gsbh,@jsysid,@sysname,@sysmemo,@userid,@userdate,@yn,@sLeaderid,";
                cmd.CommandText += " @edates,@edatee,@Spercent,@sysnamevn,@sysmemovn)";

                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));

                cmd.Parameters.Add(Para("sysname", sysname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sysmemo", sysmemo,SqlDbType.NVarChar));

                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("sLeaderid", sLeaderid));
                cmd.Parameters.Add(Para("edates", edates));
                cmd.Parameters.Add(Para("edatee", edatee));
                cmd.Parameters.Add(Para("Spercent", Spercent));

                cmd.Parameters.Add(Para("sysnamevn", sysnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sysmemovn", sysmemovn,SqlDbType.NVarChar));
                
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int SuaProjectm(string gsbh, string jsysid, string sysname, string sysmemo,
    string userid, DateTime userdate, string yn, string sLeaderid, DateTime edates, DateTime edatee, decimal Spercent, string sysnamevn, string sysmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projectm set [sysname]=@sysname,sysmemo=@sysmemo,";
                cmd.CommandText += " userid=@userid,userdate=@userdate,yn=@yn,sLeaderid=@sLeaderid,edates=@edates,";
                cmd.CommandText += " edatee=@edatee,Spercent=@Spercent,sysnamevn=@sysnamevn,";
                cmd.CommandText += " sysmemovn=@sysmemovn";
                cmd.CommandText += " where gsbh=@gsbh and jsysid=@jsysid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));

                cmd.Parameters.Add(Para("sysname", sysname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sysmemo", sysmemo,SqlDbType.NVarChar));

                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("sLeaderid", sLeaderid));
                cmd.Parameters.Add(Para("edates", edates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("edatee", edatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("Spercent", Spercent));

                cmd.Parameters.Add(Para("sysnamevn", sysnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sysmemovn", sysmemovn,SqlDbType.NVarChar));
                
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateFileAttact1(string GSBH, string jsysid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectm set LinkFile=@LinkFile where gsbh=@gsbh and  jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("LinkFile", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact2(string GSBH, string jsysid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectm set LinkFile2=@LinkFile2 where gsbh=@gsbh and  jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("LinkFile2", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact3(string GSBH, string jsysid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projectm set LinkFile3=@LinkFile3 where gsbh=@gsbh and  jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("LinkFile3", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public DataTable HienThiFileDinhKemThuc(string GSBH, string jsysid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select LinkFile,LinkFile2,LinkFile3 from Projectm where gsbh=@gsbh and jsysid=@jsysid";
            cmd.Parameters.Add(Para("gsbh", GSBH));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            return Select(cmd).Tables[0];
        }
        public int XoaProjectm(string gsbh, string jsysid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projectm set yn=@yn where gsbh=@gsbh and jsysid=@jsysid";
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
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimSystemTheoTen(string GSBH, string UserID, string systemName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Projectm  where [sysname]=@sysname and userid=@userid and gsbh=@gsbh";
                cmd.Parameters.Add(Para("sysname", systemName, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LaySachProjectMTheoID(string GSBH,string SystemID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LaySachProjectMTheoID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("jsysid", SystemID));
            cmd.Parameters.Add(Para("GSBH", GSBH));
            return Select(cmd).Tables[0];
           // 
        }
        public DataSet XuatBaoCaoTheoNgayThang(string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "XuatBaoCaoTheoProjectNgayThang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("UserID", UserID));
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                return Select(cmd, "dtProject");
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public DataTable QryProjectMShare(string GSBH, string UserID, string EmpShare)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryProjectMShare";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("gsbh", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("EmpShare", EmpShare, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayIDSYStem()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select COUNT(jsysid) as jsysid,MAX(jsysid) as maxjsysid  from Projectm";
            return Select(cmd).Tables[0];
        }
    }
}
