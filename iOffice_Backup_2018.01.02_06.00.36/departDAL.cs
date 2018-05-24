using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice
{
    public class departDAL:GernericDataAccess
    {
        public departDAL() { }
        public DataTable QryDonVi(string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select bd.GSBH,bd.ID,bd.DepName,bd.DepartmentTypeID,ab.DepartmentTypeNameTW,bd.IdUserChuQuan,bu.USERNAME ";
                //cmd.CommandText +=" from BDepartment bd ";
                //cmd.CommandText +=" left join AbDepartmentType ab on ab.GSBH=bd.GSBH and ab.DepartmentTypeID=bd.DepartmentTypeID";
                //cmd.CommandText +=" left join Busers2 bu on bu.USERID=bd.IdUserChuQuan and bu.GSBH=bd.GSBH";
                //cmd.CommandText += " where bd.GSBH=@GSBH and bd.Dclass='E' and bd.PlanYN=1 and bd.DepartmentTypeID!=0";
                cmd.CommandText = "QryDonVi";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryDonViLenDropBo(string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryDonViLenDropBo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryDonViDeXetQuyTrinh(string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from BDepartment bd where bd.GSBH=@GSBH and bd.Dclass='E' and bd.PlanYN=1 ";
                cmd.CommandText +=" and bd.DepartmentTypeID!=0 and (bd.IdUserChuQuan!=null or bd.IdUserChuQuan!=' ')";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public DataTable QryDonViMaNguoiDuyetQuanLy(string GSBH, string MaNguoiDuyet)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "   select * from BDepartment bd where bd.GSBH=@GSBH and bd.Dclass='E' and bd.PlanYN=1";
                 cmd.CommandText +=" and bd.DepartmentTypeID!=0 and bd.IdUserChuQuan=@IdUserChuQuan";
                 cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                 cmd.Parameters.Add(CreateParameter("IdUserChuQuan", MaNguoiDuyet, SqlDbType.VarChar));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimKiemDonViTheoDieuKien(string GSBH, string DieuKien)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select bd.GSBH,bd.ID,bd.DepName,bd.DepartmentTypeID,ab.DepartmentTypeNameTW,bd.IdUserChuQuan,bu.USERNAME ";
                cmd.CommandText +=" from BDepartment bd ";
                cmd.CommandText +=" left join AbDepartmentType ab on ab.GSBH=bd.GSBH and ab.DepartmentTypeID=bd.DepartmentTypeID";
                cmd.CommandText +=" left join Busers2 bu on bu.USERID=bd.IdUserChuQuan and bu.GSBH=bd.GSBH";
                cmd.CommandText += " where bd.GSBH='" + GSBH + "' and bd.Dclass='E' and bd.PlanYN=1 and bd.DepartmentTypeID!=0 and bd.UserID ='%" + DieuKien + "%' or bd.DepName='%" + DieuKien + "%'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable GetDate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select (GETDATE()-30) as NgayThang";
            return Select(cmd).Tables[0];
        }
        public DataTable GetDate1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select (GETDATE()-7) as NgayThang";
            return Select(cmd).Tables[0];
        }
        public int CapNhatDepart(string ID, string GSBH, string UserID, int IDLoai)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update BDepartment set IdUserChuQuan='"+UserID+"', DepartmentTypeID='"+IDLoai+"' where GSBH='"+GSBH+"' and ID='"+ID+"'";
            return ExecuteNonQuery(cmd);
        }
        public DataTable QryDonViTheoDieuKien(string UserID, string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "QryDonViTheoDieuKien";
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("USERID", UserID));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
            return Select(cmd).Tables[0];
        }
       
    }
}