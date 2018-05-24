using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice
{
    public class userDAL : GernericDataAccess
    {
        public userDAL() { }
        public DataTable QryUser(string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select bu.GSBH,bu.BADEPID,bd.DepName,bu.USERID,bu.USERNAME,bu.IDCapDuyet,bu.IdUserQuanLyTT,bu.IDChucVu,cv.TenChucVu,cv.TenChucVuTiengHoa";
            //cmd.CommandText +=" from Busers2 bu"; 
            //cmd.CommandText +=" left join BDepartment bd on bd.ID=bu.BADEPID and bd.GSBH=bu.GSBH";
            //cmd.CommandText += " left join ChucVu cv on bu.IDChucVu=cv.IDChucVu ";
            //cmd.CommandText +=" where bu.GSBH=@GSBH";
            cmd.CommandText = "QryUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
      
        public DataTable QryUserByDepart(string GSBH, string BAdepid)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select bu.GSBH,bu.BADEPID,bd.DepName,bu.USERID,bu.USERNAME,bu.IDCapDuyet,bu.IdUserQuanLyTT,bu.IDChucVu,cv.TenChucVu,cv.TenChucVuTiengHoa";
            //cmd.CommandText += " from Busers2 bu";
            //cmd.CommandText += " left join BDepartment bd on bd.ID=bu.BADEPID and bd.GSBH=bu.GSBH";
            //cmd.CommandText += " left join ChucVu cv on bu.IDChucVu=cv.IDChucVu ";
            //cmd.CommandText += " where bu.GSBH=@GSBH and BADEPID=@BADEPID";
            cmd.CommandText = "QryUserByDepart";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
        public DataTable TImNguoiTheoDieuKien(string dieukien)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = " select DISTINCT bu.GSBH,bu.BADEPID,bd.DepName,bu.USERID,bu.USERNAME,bu.IDCapDuyet,bu.IdUserQuanLyTT,bu.IDChucVu,cv.TenChucVu,cv.TenChucVuTiengHoa";
            //cmd.CommandText +=" from Busers2 bu";
            //cmd.CommandText +=" left join BDepartment bd on bd.ID=bu.BADEPID and bd.GSBH=bu.GSBH";
            //cmd.CommandText += " left join ChucVu cv on bu.IDChucVu=cv.IDChucVu ";
            //cmd.CommandText += " where bu.USERID like '%"+dieukien+"%' or bu.USERNAME like '%"+dieukien+"%'";
            cmd.CommandText = "TImNguoiTheoDieuKien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("USERID", dieukien, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERNAME", dieukien, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
        public DataTable TimNhanVienTheoMa(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "TimNhanVienTheoMa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                cmd.Parameters.Add(CreateParameter("UserID", UserID));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimNhanVienTheoMaDonVi(string GSBH, string DepartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "TimNhanVienTheoMaDonVi";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                cmd.Parameters.Add(CreateParameter("BADEPID", DepartID));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryNguoiDich(string GSBH, string DepartID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryNguoiDich";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
            cmd.Parameters.Add(CreateParameter("BADEPID", DepartID));
            return selex(cmd).Tables[0];
        }
        
    }
}