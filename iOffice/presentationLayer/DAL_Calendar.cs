using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_Calendar:DAL_SQL_GenericDataAccess
    {
        public DAL_Calendar()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable QryTheoNguoiTao(string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryTheoNguoiTao_Calendar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("UserID", UserID));
            return selex(cmd).Tables[0];
        }
        public DataTable QryTheoNguoiTaoTheoID(string UserID, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from PSworkm where Userid=@Userid and ID=@ID";
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            return selex(cmd).Tables[0];
        }
        public int ThemLich(string GSBH, string UserID, DateTime pdates, DateTime pdatee, string wkmemo,  decimal jobpercent, string cfmuser, string Subject)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert PSworkm(GSBH,Userid,pdates,pdatee,wkmemo,jobpercent,cfmuser,Subject)";
                cmd.CommandText += "  values(@GSBH,@Userid,@pdates,@pdatee,@wkmemo,@jobpercent,@cfmuser,@Subject)";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("pdates", pdates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("pdatee", pdatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("wkmemo", wkmemo, SqlDbType.NVarChar));
               
                cmd.Parameters.Add(Para("jobpercent", jobpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("cfmuser", cfmuser, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Subject", Subject, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ThemLichRutGon(string GSBH, string UserID, DateTime pdates, DateTime pdatee, string Subject, string jobid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert PSworkm(GSBH,Userid,pdates,pdatee,Subject,cfmuser,jobid)";
                cmd.CommandText += "  values(@GSBH,@Userid,@pdates,@pdatee,@Subject,@cfmuser,@jobid)";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("pdates", pdates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("pdatee", pdatee, SqlDbType.DateTime));

                cmd.Parameters.Add(Para("cfmuser", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Subject", Subject, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobid", jobid, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ThemLichRutGon1(string GSBH, string UserID, DateTime pdates, DateTime pdatee, string Subject, string jobid,decimal jobpercent)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert PSworkm(GSBH,Userid,pdates,pdatee,Subject,cfmuser,jobid)";
                cmd.CommandText += "  values(@GSBH,@Userid,@pdates,@pdatee,@Subject,@cfmuser,@jobid)";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("pdates", pdates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("pdatee", pdatee, SqlDbType.DateTime));

                cmd.Parameters.Add(Para("cfmuser", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Subject", Subject, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobid", jobid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("jobpercent", jobpercent, SqlDbType.Decimal));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetMaxIDCalender()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetMaxIDCalender";
            cmd.CommandType = CommandType.StoredProcedure;
            return selex(cmd).Tables[0];
        }

        public int ThemLichRutGon2(string GSBH, string UserID, DateTime pdates, DateTime pdatee, string Subject, string jobid, decimal jobpercent, string wklink, string wslink2, string wslink3, string jsubid, string jsysid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert PSworkm(GSBH,Userid,pdates,pdatee,Subject,cfmuser,jobid,wklink,wslink2,wslink3,jsubid,jsysid)";
                cmd.CommandText += "  values(@GSBH,@Userid,@pdates,@pdatee,@Subject,@cfmuser,@jobid,@wklink,@wslink2,@wslink3,@jsubid,@jsysid)";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("pdates", pdates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("pdatee", pdatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("cfmuser", UserID, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Subject", Subject, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jobid", jobid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("jobpercent", jobpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("wklink", wklink,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("wslink2", wslink2,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("wslink3", wslink3,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("jsubid", jsubid));
                cmd.Parameters.Add(Para("jsysid", jsysid));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int SuaLich(int ID, string GSBH, string UserID, DateTime pdates, DateTime pdatee, string wkmemo,  decimal jobpercent, DateTime modidate, string Subject)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update PSworkm set wkmemo=@wkmemo,modidate=@modidate,jobpercent=@jobpercent,[Subject]=@Subject , pdatee=@pdatee,pdates=@pdates";
                cmd.CommandText += " where ID=@ID   ";
                cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("pdates", pdates, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("pdatee", pdatee, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("wkmemo", wkmemo, SqlDbType.NVarChar));

                cmd.Parameters.Add(Para("jobpercent", jobpercent, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("modidate", modidate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("Subject", Subject, SqlDbType.NVarChar));

                ///////////////////
                //cmd.CommandText = "update PSworkm set wkmemo='" + wkmemo + "',modidate='" + modidate + "',jobpercent='" + jobpercent + "',[Subject]='" + Subject + "' , pdatee='" + pdatee + "',pdates='" + pdates + "'";
                //cmd.CommandText += " where ID='" + ID + "'   ";
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateCalendar(DateTime StartDate, DateTime EndDate, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdateCalendar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("pdates", StartDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("pdatee", EndDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
             return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact1(string gsbh, int ID, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update PSworkm set wklink=@wklink where ID=@ID and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", gsbh));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("wklink", linkFile));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact2(string gsbh, int ID, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update PSworkm set wslink2=@wslink2 where ID=@ID and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", gsbh));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("wslink2", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateFileAttact3(string gsbh, int ID, string linkFile)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update PSworkm set wslink3=@wslink3 where ID=@ID and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", gsbh));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("wslink3", linkFile,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public DataTable QryFileDinhKemTheoID(string gsbh, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select wklink,wslink2,wslink3 from PSworkm where ID=@ID and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", gsbh));
            cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
            return selex(cmd).Tables[0];
        }
        public int XoaLich(string UserID, string GSBH, int ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete PSworkm where GSBH=@GSBH and Userid=@Userid and ID=@ID";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("Userid", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet XuatBaoCaoCongViecTheoNgayThang(string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select Userid,pdates,pdatee,Subject,wkmemo"; 
                //cmd.CommandText +=" from PSworkm  ";
                //cmd.CommandText +="  where Userid=@UserID ";
                //cmd.CommandText += " and pdates between @FromDate and @ToDate";
                //cmd.CommandText +=" order by userid,pdates";
                cmd.CommandText = "XuatBaoCaoCongViecTheoNgayThang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("UserID", UserID));
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                return selex(cmd, "dtCalendar");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
