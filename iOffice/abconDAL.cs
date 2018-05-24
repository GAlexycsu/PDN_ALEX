using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice
{
    public class abconDAL : GernericDataAccess
    {
        public abconDAL() { }
        public int CapNhatABPStrongABcon(string GSBH,string abtype,string pdno,int abps,int abstep,int IDCT)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Abcon  set abps=@abps where Gsbh=@Gsbh and abtype=@abtype and Abstep=@Abstep and IDCT=@IDCT and pdno=@pdno";
            cmd.Parameters.Add(CreateParameter("Gsbh", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Abstep", abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("abps", abps, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("IDCT", IDCT, SqlDbType.Int));
            return ExecuteNonQuery(cmd);

        }
        public int ThemABcon(string GSBH,string abtype,string from_depart,string from_user,
            int abc,int abstep,string auditor,int IDCapDuyet,string mytitle,string pdno,int abps)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Abcon(Gsbh,abtype,from_depart,from_user,ABC,Abstep,abps,Auditor,";
            cmd.CommandText +=" IDCapDuyet,Maintitle,pdno,abrult,bixoa,boqua,cothutu,kytoanbo,ncancel,Yn)";
            cmd.CommandText +=" values(@Gsbh,@abtype,@from_depart,@from_user,@ABC,@Abstep,";
            cmd.CommandText +=" @abps,@Auditor,@IDCapDuyet,@Maintitle,@pdno,0,0,0,1,1,0,4)";
            cmd.Parameters.Add(CreateParameter("Gsbh", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("from_depart", from_depart, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("from_user", from_user, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ABC", abc, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("Abstep", abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("Auditor", auditor, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("IDCapDuyet", IDCapDuyet, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("Maintitle", mytitle, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abps", abps, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatAbcon(string GSBH,string abtype,string pdno,string Auditor,int IDCT,int Abstep, int IDCapDuyet,int abps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Abcon set abps=@abps, Auditor=@Auditor,IDCapDuyet=@IDCapDuyet"; 
            cmd.CommandText +=" where IDCT=@IDCT and Gsbh=@Gsbh and abtype=@abtype and Abstep=@Abstep and pdno=@pdno";
            cmd.Parameters.Add(CreateParameter("Gsbh", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Auditor", Auditor, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("IDCapDuyet", IDCapDuyet, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("IDCT", IDCT, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("Abstep", Abstep, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("abps", abps, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatUyQuyenAbcon(string GSBH,string IdUyQuyen,string pdno, int IDBuoc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Abcon set Auditor=@Auditor where Gsbh=@Gsbh and pdno=@pdno and IDCT=@IDCT";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Auditor", IdUyQuyen, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("IDCT", IDBuoc, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachPhieuTheoNguoiDuyet(string GSBH, string auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DanhSachPhieuTheoNguoiDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Auditor", auditor, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatBuocKyTrongBangAbcon(string GSBH, string pdno,string abtype, int IDCT, int abstep, int abps)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "update Abcon set Abstep=@Abstep, abps=@abps where pdno=@pdno and Gsbh=@Gsbh and IDCT=IDCT and abtype=@abtype";
                cmd.CommandText = "update Abcon set Abstep='"+abstep+"', abps='"+abps+"' where pdno='"+pdno+"' and Gsbh='"+GSBH+"' and IDCT='"+IDCT+"' and abtype='"+abtype+"'";
                //cmd.Parameters.Add(CreateParameter("Abstep", abstep, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("abps", abps, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("Gsbh", GSBH, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("IDCT", IDCT, SqlDbType.Int));
                //cmd.Parameters.Add(CreateParameter("abtype", abtype, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraPhieuDaDuyetChua(string GSBH, string pdno, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Abcon where pdno='"+pdno+"' and Gsbh='"+GSBH+"'  and Auditor='"+UserID+"'";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int XoaMaPhieuTrongBangPDNA(string GSBH, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete pdna where pdno='" + pdno + "' and GSBH='" + GSBH + "'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayComentTheoNguoiDuyet(string Auditor, string GSBH, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select lydokhongduyet from Abcon where Auditor='"+Auditor+"' and Gsbh='"+GSBH+"' and pdno='"+pdno+"'";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraPhieutrongBangTrangThai(string pdno, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from ABTrangThaiDuyet where pdno='" + pdno + "' and GSBH='" + GSBH + "'";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachComment(string pdno, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select ab.Abstep,ab.abps,ab.lydokhongduyet,ab.QAmemo,ab.Yn,abyn.YnName,ab.Auditor,bu.USERNAME,ab.from_user from Abcon ab"; 
                //cmd.CommandText +="  left join Busers2 bu on ab.Auditor=bu.USERID";
                //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
                //cmd.CommandText += "  where ab.pdno=@pdno and ab.GSBH=@GSBH";
                cmd.CommandText = "DanhSachComment";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatComment(string pdno, string GSBH, string auditor,string comment)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Abcon set lydokhongduyet=N'"+comment+"' where pdno='"+pdno+"' and Gsbh='"+GSBH+"' and Auditor='"+auditor+"'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatTraLoi(string pdno, string GSBH, string from_user,string Auditor, string comment)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Abcon set QAmemo=N'" + comment + "' where pdno='" + pdno + "' and Gsbh='" + GSBH + "' and from_user='" + from_user + "' and Auditor='"+Auditor+"'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatYKienPhanHoi(string pdno, string GSBH, int Yn, string Auditor, string comment)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Abcon set QAmemo2=N'" + comment + "', Yn='"+Yn+"' where pdno='" + pdno + "' and Gsbh='" + GSBH + "' and Auditor='" + Auditor + "'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatTrangThaiCuaPhieuCoYKien(string pdno, string GSBH, int Yn, string Auditor)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update Abcon set  Yn='"+Yn+"' where pdno='" + pdno + "' and Gsbh='" + GSBH + "' and Auditor='" + Auditor + "'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraNguoiDuyetPhieu(string pdno, string GSBH,  string Auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "KiemTraNguoiDuyetPhieu";
                cmd.CommandType = CommandType.StoredProcedure;
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}