using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_Projects:DAL_GenericERPAccess
    {
        public DAL_Projects()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable QryProjectsTheoUserID(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projects P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and (P.yn='0' or P.yn='1')";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryProjectsTheoUserIDVaSub(string UserID, string GSBH, string jsubid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projects P left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh and P.jsubid=@jsubid ";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsubid", jsubid, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryProjectsTheoNgayThang(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projects P left join Busers2 B on P.Jleaderid=B.USERID and P.gsbh=B.GSBH where P.userid=@userid and P.gsbh=@gsbh ";
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ThemProjects(string gsbh, string jsysid, string jsubid, string jobid, string ticketid, string jobname, string jobmemo, string userid,
            DateTime userdate, string yn, string Jleaderid, DateTime edates, DateTime edatee, decimal jpercent, string PDNO, string jobnamevn, string jobmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Projects(gsbh,jsysid,jsubid,jobid,ticketid,jobname,jobmemo,userid,userdate,yn,Jleaderid,edates,edatee,jpercent,PDNO,jobnamevn,jobmemovn)";
                cmd.CommandText += " values(@gsbh,@jsysid,@jsubid,@jobid,@ticketid,@jobname,@jobmemo,@userid,@userdate,@yn,@Jleaderid,@edates,@edatee,@jpercent,@PDNO,@jobnamevn,@jobmemovn)";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("ticketid", ticketid));
                cmd.Parameters.Add(Para("jobname", jobname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemo", jobmemo,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("Jleaderid", Jleaderid));
                cmd.Parameters.Add(Para("edates", edates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("edatee", edatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("jpercent", jpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("PDNO", PDNO));
                cmd.Parameters.Add(Para("jobnamevn", jobnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemovn", jobmemovn,SqlDbType.NVarChar));

                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int ThemHoacCapNhatProjects(string gsbh, string jsysid, string jsubid, string jobid, string ticketid, string jobname, string jobmemo, string userid,
           DateTime userdate, string yn, string Jleaderid, DateTime edates, DateTime edatee, decimal jpercent, string PDNO, string jobnamevn, string jobmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Projects(gsbh,jsysid,jsubid,jobid,ticketid,jobname,jobmemo,userid,userdate,yn,Jleaderid,edates,edatee,jpercent,PDNO,jobnamevn,jobmemovn)";
                cmd.CommandText += " values(@gsbh,@jsysid,@jsubid,@jobid,@ticketid,@jobname,@jobmemo,@userid,@userdate,@yn,@Jleaderid,@edates,@edatee,@jpercent,@PDNO,@jobnamevn,@jobmemovn)";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("ticketid", ticketid));
                cmd.Parameters.Add(Para("jobname", jobname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemo", jobmemo,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("Jleaderid", Jleaderid));
                cmd.Parameters.Add(Para("edates", edates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("edatee", edatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("jpercent", jpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("PDNO", PDNO));
                cmd.Parameters.Add(Para("jobnamevn", jobnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemovn", jobmemovn,SqlDbType.NVarChar));

                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int SuaProjects(string gsbh, string jsysid, string jsubid, string jobid, string ticketid, string jobname, string jobmemo, string userid,
            DateTime userdate, string yn, string Jleaderid, DateTime edates, DateTime edatee, decimal jpercent, string PDNO, string jobnamevn, string jobmemovn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Projects set ticketid=@ticketid,jobname=@jobname,jobmemo=@jobmemo,";
                cmd.CommandText += " userid=@userid,userdate=@userdate,yn=@yn,Jleaderid=@Jleaderid,";
                cmd.CommandText += " edates=@edates,edatee=@edatee,jpercent=@jpercent,PDNO=@PDNO,jobnamevn=@jobnamevn,jobmemovn=@jobmemovn";
                cmd.CommandText += " where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("ticketid", ticketid));
                cmd.Parameters.Add(Para("jobname", jobname,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemo", jobmemo,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", userid));
                cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("yn", yn));
                cmd.Parameters.Add(Para("Jleaderid", Jleaderid));
                cmd.Parameters.Add(Para("edates", edates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("edatee", edatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("jpercent", jpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("PDNO", PDNO));
                cmd.Parameters.Add(Para("jobnamevn", jobnamevn,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobmemovn", jobmemovn,SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int XoaProjects(string gsbh, string jsysid, string jsubid, string jobid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projects set yn=@yn where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("jobid", jobid));
                cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateFileAttact1(string gsbh, string jsysid, string jsubid, string jobid,string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projects set Linkfile=@Linkfile where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
            cmd.Parameters.Add(Para("gsbh", gsbh));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("jobid", jobid));
            cmd.Parameters.Add(Para("Linkfile", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact2(string gsbh, string jsysid, string jsubid, string jobid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projects set Linkfile2=@Linkfile2 where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
            cmd.Parameters.Add(Para("gsbh", gsbh));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("jobid", jobid));
            cmd.Parameters.Add(Para("Linkfile2", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact3(string gsbh, string jsysid, string jsubid, string jobid, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Projects set Linkfile3=@Linkfile3 where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
            cmd.Parameters.Add(Para("gsbh", gsbh));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("jobid", jobid));
            cmd.Parameters.Add(Para("Linkfile3", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public DataTable HienThiFileDinhKemThuc(string gsbh, string jsysid, string jsubid, string jobid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Linkfile,Linkfile2,Linkfile3 from Projects where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid and jobid=@jobid";
            cmd.Parameters.Add(Para("gsbh", gsbh));
            cmd.Parameters.Add(Para("jsysid", jsysid));
            cmd.Parameters.Add(Para("jsubid", jsubid));
            cmd.Parameters.Add(Para("jobid", jobid));
            return Select(cmd).Tables[0];
        }
        public int XoaProjectsTheoSystem(string gsbh, string jsysid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update  Projects set yn=@yn where gsbh=@gsbh and jsysid=@jsysid";
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
        public int XoaProjectsTheoSubSystem(string gsbh, string jsysid, string jsubid,string yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update   Projects set yn=@yn where gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid";
                cmd.Parameters.Add(Para("gsbh", gsbh));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiSystemLenTextBox(string SubsystemID, string USerID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Pr.jsysid,Pr.[sysname] as SystemName from Projectm Pr left join Projectn Pss on Pr.jsysid=Pss.jsysid";
                cmd.CommandText += " where Pss.jsubid =@jsubid and Pss.gsbh=@gsbh and Pss.userid=@userid";
                cmd.Parameters.Add(Para("jsubid", SubsystemID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("userid", USerID));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachJob(string systemID, string SubsystemID, string USerID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  P.*,B.USERNAME from Projects P ";
                cmd.CommandText += " left join Busers2 B on P.Userid=B.USERID and P.gsbh=B.GSBH";
                cmd.CommandText += " left join Projectn Pr on  Pr.jsubid=P.jsubid  and Pr.jsysid=P.jsysid  and Pr.gsbh=P.gsbh";
                cmd.CommandText += " where Pr.userid=@userid and Pr.gsbh=@gsbh  and Pr.jsysid=@jsysid and Pr.jsubid=@jsubid  ";
                cmd.Parameters.Add(Para("jsubid", SubsystemID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("userid", USerID));
                cmd.Parameters.Add(Para("jsysid", systemID));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayJobMax()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Max(jobid) as JobID from Projects";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiLenDropBox(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select P.jsubid,P.jsubname from Projectn P where P.userid=@userid and gsbh=@gsbh";
                cmd.Parameters.Add(Para("userid", UserID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiLenDropBoxKhiThem(string UserID, string GSBH, string jsubid,string SYstem)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select P.jsubid,P.jsubname from Projectn P where P.userid=@userid and gsbh=@gsbh and jsysid=@jsysid and jsubid=@jsubid";
                cmd.Parameters.Add(Para("userid", UserID));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsysid", SYstem));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                return Select(cmd).Tables[0];
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
        public DataTable HienThiDanhSachTheoHeThong(string UserID, string GSBH, string System, string SubSystem)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "HienThiDanhSachTheoHeThong_Job";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("gsbh", GSBH));
                cmd.Parameters.Add(Para("jsysid", System));
                cmd.Parameters.Add(Para("jsubid", SubSystem));
                cmd.Parameters.Add(Para("userid", UserID));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryTheoAuditor_TreeView(string Userid, string Juserid, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryTheoAuditor_Treeview";
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
        public DataTable TimTenJob(string GSBH, string UserID, string jobid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select PS.* from Projects PS left join Projectu PU on PS.gsbh=PU.GSBH and PS.jobid=PU.Jodid ";
                cmd.CommandText += " where PS.jobid=@jobid  and Ps.gsbh=@gsbh and (Ps.userid=@userid or PU.Juserid=@userid)";
                cmd.Parameters.Add(Para("jobid", jobid, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("userid", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LaySachProjectSTheoID(string GSBH, string SystemID, string SubSystemID, string JobID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LaySachProjectSTheoID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("jsysid", SystemID));
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("jsubid", SubSystemID));
            cmd.Parameters.Add(Para("jobid", JobID));
            return Select(cmd).Tables[0];

        }
        public DataTable QryProjectsShare(string GSBH, string SystemID, string SubSystemID, string userid, string EmpShare)
        
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryProjectsShare1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("jsysid", SystemID));
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("jsubid", SubSystemID));
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("EmpShare", EmpShare, SqlDbType.VarChar));
            return Select(cmd).Tables[0];    
        }
        public DataTable LayIDJob()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select COUNT(jobid) as jobid,MAX(jobid) as maxjobid  from Projects";
            return Select(cmd).Tables[0];
        }
    }
}
