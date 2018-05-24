using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice
{
    public class quytrinhDal : GernericDataAccess
    {
        public quytrinhDal()
        { 
        }
        public int CapNhatQuyABPS(string GSBH,string abtype,string BADepid, int IDQUyTrinh,int AbStep,int ABPS)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="update QPDNFlow set ABPS='"+ABPS+"'";
                cmd.CommandText += " where GSBH='"+GSBH+"' and abtype='"+abtype+"' and BADEPID='"+BADepid+"' and IDQuyTrinh='"+IDQUyTrinh+"' and ABstep='"+AbStep+"'";
                //cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("BADEPID", BADepid, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("IDQuyTrinh", IDQUyTrinh, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABstep", AbStep, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABPS", ABPS, SqlDbType.Int));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatQuyABPSAndAbstep(string GSBH, string abtype, string BADepid, int IDQUyTrinh, int AbStep, int ABPS)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update QPDNFlow set ABPS='" + ABPS + "',ABstep='" + AbStep + "'";
                cmd.CommandText += " where GSBH='" + GSBH + "' and abtype='" + abtype + "' and BADEPID='" + BADepid + "' and IDQuyTrinh='" + IDQUyTrinh + "'";
                //cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("BADEPID", BADepid, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("IDQuyTrinh", IDQUyTrinh, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABstep", AbStep, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABPS", ABPS, SqlDbType.Int));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatAbStep(string GSBH, string abtype, string BADepid, int IDQUyTrinh, int AbStep, int ABPS)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update QPDNFlow set ABstep='"+AbStep+"'";
                cmd.CommandText +=" where GSBH='"+GSBH+"' and abtype='"+abtype+"' and BADEPID='"+BADepid+"' and IDQuyTrinh='"+IDQUyTrinh+"' and ABPS='"+ABPS+"'";
                //cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("BADEPID", BADepid, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("IDQuyTrinh", IDQUyTrinh, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABstep", AbStep, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("ABPS", ABPS, SqlDbType.Int));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int ThemQPDNFlow(string GSBH, string abtype, string BADepid, int AbStep, int ABPS,string NguoiDuyet,
            string UserName,string IDChucVu,string abtypenameTW,string tendonviTW,int IDLoaiDonVi,string tenLoaiDonViTW,int IDCapDuyet,string TenChucVuTiengHoa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into QPDNFlow(GSBH,abtype,BADEPID,ABstep,ABPS,NguoiDuyet,";
                cmd.CommandText += " USERNAME,IDChucVu,abtypenameTW,tendonviTW,IDLoaiDonVi,DepartmentTypeNameTW,IDCapDuyet,TenChucVuTiengHoa)";
                cmd.CommandText += " values(@GSBH,@abtype,@BADEPID,@ABstep,@ABPS,@NguoiDuyet,@USERNAME,@IDChucVu,";
                cmd.CommandText += " @abtypenameTW,@tendonviTW,@IDLoaiDonVi,@DepartmentTypeNameTW,@IDCapDuyet,@TenChucVuTiengHoa)";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("BADEPID", BADepid, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ABstep", AbStep, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("ABPS", ABPS, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("NguoiDuyet", NguoiDuyet, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("USERNAME", UserName, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("IDChucVu", IDChucVu, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("abtypenameTW", abtypenameTW, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("tendonviTW", tendonviTW, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("IDLoaiDonVi", IDLoaiDonVi, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("DepartmentTypeNameTW", tenLoaiDonViTW, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("IDCapDuyet", IDCapDuyet, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("TenChucVuTiengHoa", TenChucVuTiengHoa, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryQPDNFlow(string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct qt.IDQuyTrinh,qt.ABPS,qt.ABstep,qt.abtype,qt.abtypenameTW,";
            cmd.CommandText +=" qt.BADEPID,qt.DepartmentTypeNameTW,qt.GSBH,qt.IDCapDuyet,qt.IDChucVu,";
            cmd.CommandText +=" qt.IDLoaiDonVi,qt.NguoiDuyet,qt.tendonviTW,qt.USERNAME,qt.TenChucVuTiengHoa ";
            cmd.CommandText +="from QPDNFlow qt ";
            cmd.CommandText +=" left join Busers2 busers on busers.USERID=qt.NguoiDuyet";
            cmd.CommandText += " left join ChucVu cv on busers.IDChucVu=cv.IDChucVu";
            cmd.CommandText +=" where qt.GSBH=@macongty";
            cmd.CommandText += " order by qt.abtype,qt.BADEPID,qt.ABstep,qt.ABPS asc";
            cmd.Parameters.Add(CreateParameter("macongty", GSBH, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryDonViTrongQuyTrinh(string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select * from QPDNFlow where GSBH=@GSBH and BADEPID='All'";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryTheoDieuKien(string GSBH, string Badepid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct qt.IDQuyTrinh,qt.ABPS,qt.ABstep,qt.abtype,qt.abtypenameTW,";
            cmd.CommandText += " qt.BADEPID,qt.DepartmentTypeNameTW,qt.GSBH,qt.IDCapDuyet,qt.IDChucVu,";
            cmd.CommandText += " qt.IDLoaiDonVi,qt.NguoiDuyet,qt.tendonviTW,qt.USERNAME,cv.TenChucVuTiengHoa ";
            cmd.CommandText += "from QPDNFlow qt ";
            cmd.CommandText += " left join Busers2 busers on busers.USERID=qt.NguoiDuyet";
            cmd.CommandText += " left join ChucVu cv on busers.IDChucVu=cv.IDChucVu";
            cmd.CommandText += " where qt.GSBH=@macongty and qt.BADEPID=@BADEPID";
            cmd.CommandText += " order by qt.abtype,qt.BADEPID,qt.ABstep,qt.ABPS asc";
            cmd.Parameters.Add(CreateParameter("macongty", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", Badepid, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryTheoLoaiPhieu(string GSBH, string abtype)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct qt.IDQuyTrinh,qt.ABPS,qt.ABstep,qt.abtype,qt.abtypenameTW,";
            cmd.CommandText += " qt.BADEPID,qt.DepartmentTypeNameTW,qt.GSBH,qt.IDCapDuyet,qt.IDChucVu,";
            cmd.CommandText += " qt.IDLoaiDonVi,qt.NguoiDuyet,qt.tendonviTW,qt.USERNAME,cv.TenChucVuTiengHoa ";
            cmd.CommandText += "from QPDNFlow qt ";
            cmd.CommandText += " left join Busers2 busers on busers.USERID=qt.NguoiDuyet";
            cmd.CommandText += " left join ChucVu cv on busers.IDChucVu=cv.IDChucVu";
            cmd.CommandText += " where qt.GSBH=@macongty and qt.abtype=@abtype";
            cmd.CommandText += " order by qt.abtype,qt.BADEPID,qt.ABstep,qt.ABPS asc";
            cmd.Parameters.Add(CreateParameter("macongty", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryTheoLoaiPhieuDonVi(string GSBH, string abtype,string madonvi)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct qt.IDQuyTrinh,qt.ABPS,qt.ABstep,qt.abtype,qt.abtypenameTW,";
            cmd.CommandText += " qt.BADEPID,qt.DepartmentTypeNameTW,qt.GSBH,qt.IDCapDuyet,qt.IDChucVu,";
            cmd.CommandText += " qt.IDLoaiDonVi,qt.NguoiDuyet,qt.tendonviTW,qt.USERNAME,cv.TenChucVuTiengHoa ";
            cmd.CommandText += "from QPDNFlow qt ";
            cmd.CommandText += " left join Busers2 busers on busers.USERID=qt.NguoiDuyet";
            cmd.CommandText += " left join ChucVu cv on busers.IDChucVu=cv.IDChucVu";
            cmd.CommandText += " where qt.GSBH=@macongty and qt.abtype=@abtype and qt.BADEPID=@BADEPID";
            cmd.CommandText += " order by qt.abtype,qt.BADEPID,qt.ABstep,qt.ABPS asc";
            cmd.Parameters.Add(CreateParameter("macongty", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", madonvi, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public int XoaQuyTrinh(string GSBH, string BAdepid, string abtype, int Abstep, int abps)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from QPDNFlow where GSBH=@GSBH and BADEPID=@BADEPID and abtype=@abtype and ABstep=@ABstep and ABPS=@ABPS";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("ABPS", abps, SqlDbType.Int));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimNguoiTrongQuyTrinh(string GSBH, string BAdepid, string abtype, int Abstep, int abps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from QPDNFlow where GSBH=@GSBH and BADEPID =@BADEPID and abtype=@abtype and ABstep=@ABstep and ABPS=@ABPS";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABPS", abps, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
        public DataTable TimNguoiTrongQT(string GSBH, string BAdepid, string abtype,string NguoiDuyet)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from QPDNFlow where GSBH=@GSBH and BADEPID =@BADEPID and abtype=@abtype and NguoiDuyet=@NguoiDuyet";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("NguoiDuyet", NguoiDuyet, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimBuocKyLonHonBuocHienTai(string GSBH, string BAdepid, string abtype, int Abstep, int abps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select * from QPDNFlow where GSBH=@GSBH and abtype=@abtype and BADEPID=@BADEPID   and ABstep=@ABstep and ABPS>@ABPS order by ABPS asc";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABPS", abps, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
        public DataTable TimBuocKyLonHonHoacBangBuocHienTai(string GSBH, string BAdepid, string abtype, int Abstep, int abps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select * from QPDNFlow where GSBH=@GSBH and abtype=@abtype and BADEPID=@BADEPID  and ABstep=@ABstep and ABPS>=@ABPS order by ABPS asc";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABPS", abps, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
        public DataTable TimAbstepLonHonHoacBangBuocHienTai(string GSBH, string BAdepid, string abtype, int Abstep)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select * from QPDNFlow where GSBH='"+GSBH+"' and abtype='"+abtype+"' and BADEPID='"+BAdepid+"'  and ABstep>='"+Abstep+"'  order by ABstep desc";
            //cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            //cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            //cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            //cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));

            return Select(cmd).Tables[0];
        }
        public DataTable TimBuocKyTrongQuytrinhXD(string GSBH, string BAdepid, string abtype, int Abstep, int abps,int IDCapDuyet)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select * from QPDNFlow where GSBH=@GSBH and abtype=@abtype and BADEPID=@BADEPID and ABstep=@ABstep and ABPS>=@ABPS and IDCapDuyet=@IDCapDuyet order by ABPS asc";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BAdepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABstep", Abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABPS", abps, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("IDCapDuyet", IDCapDuyet, SqlDbType.Int));
            return Select(cmd).Tables[0];
        }
        public int CapNhatQuyTrinh(string GSBH, string abtype, string BADepid, int AbStep, int ABPS, string NguoiDuyet,
            string UserName, string abtypenameTW, string tendonviTW, int IDLoaiDonVi, string tenLoaiDonViTW, int IDCapDuyet)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update  QPDNFlow set  NguoiDuyet=@NguoiDuyet,USERNAME=@USERNAME,abtypenameTW=@abtypenameTW,";
            cmd.CommandText +=" tendonviTW=@tendonviTW,IDLoaiDonVi=@IDLoaiDonVi,DepartmentTypeNameTW=@DepartmentTypeNameTW,IDCapDuyet=@IDCapDuyet";
            cmd.CommandText +=" where  GSBH=@GSBH and abtype=@abtype and BADEPID=@BADEPID and ABstep=@ABstep and ABPS=@ABPS";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BADEPID", BADepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABstep", AbStep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABPS", ABPS, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("NguoiDuyet", NguoiDuyet, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("USERNAME", UserName, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("abtypenameTW", abtypenameTW, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("tendonviTW", tendonviTW, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("IDLoaiDonVi", IDLoaiDonVi, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("DepartmentTypeNameTW", tenLoaiDonViTW, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("IDCapDuyet", IDCapDuyet, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
            
        }
        public DataTable KhiVangMat(string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from ABJobAgent phep";
                cmd.CommandText +=" left join StatusCode vang on vang.ID=phep.ThongQua";
                cmd.CommandText +=" where phep.GSBH=@GSBH";
                cmd.Parameters.Add(CreateParameter("GSBH", macongty, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimKiemKhiVangMat(string macongty,DateTime pTuNgay,DateTime pDenNgay)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from ABJobAgent phep";
                cmd.CommandText += " left join StatusCode vang on vang.ID=phep.ThongQua";
                cmd.CommandText += " where phep.GSBH=@GSBH and phep.TuNgay>=@TuNgay and phep.DenNgay<=@DenNgay";
                cmd.Parameters.Add(CreateParameter("GSBH", macongty, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int XoaNguoiUyQuyen(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete ABJobAgent where ID=@ID";
            cmd.Parameters.Add(CreateParameter("ID", ID, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public DataTable TimNguoiDuyet(string macongty, string manguoiduyet)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Busers2 where USERID=@USERID and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("USERID", manguoiduyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", macongty, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable KiemNguoiTrongBuocKy(string GSBH,string abtype,string Badepid,int abstep,int abps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from QPDNFlow where GSBH='"+GSBH+"' and abtype='"+abtype+"' and BADEPID='"+Badepid+"'  and ABstep='"+abstep+"' and ABPS>='"+abps+"'  order by ABstep desc";
            return Select(cmd).Tables[0];
        }
        public DataTable DanhSachNguoiDuyet(string GSBH, string abtype, string Badepid, int abstep)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from QPDNFlow where GSBH='" + GSBH + "' and abtype='" + abtype + "' and BADEPID='" + Badepid + "'  and ABstep>='" + abstep + "'   order by ABstep desc";
            return Select(cmd).Tables[0];
        }
    }
}