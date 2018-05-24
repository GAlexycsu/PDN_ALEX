using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    public class S8recDAL:ClassGenera
    {
        public DataTable QryPhieu8recTheoNgayThangDonVi(string departID, DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from S8rec where depid=@depid and S8date between @FromDate and @ToDate";
            cmd.Parameters.Add(Para("depid", departID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
            return selex(cmd).Tables[0];
        }
        public DataTable QryPhieu8RecTheoID(string GSBH, DateTime S8date, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from S8rec where GSBH=@GSBH and S8date=@S8date and sh=@sh";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
            return selex(cmd).Tables[0];
        }
        public int InsertPicture(string GSBH,DateTime S8date,string depid,string empid,string QCmemo,string QCpic0,string QApic,string Sitemno,string ck1,string QVmemo,string Qanswer,decimal sub_score,string yn,string userid,DateTime userdate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "  insert S8rec(GSBH,S8date,depid,empid,QCmemo,QCpic0,QApic,Sitemno,ck1,QVmemo,Qanswer,sub_score,yn,userid,userdate)";
            cmd.CommandText += " values(@GSBH,@S8date,@depid,@empid,@QCmemo,@QCpic0,@QApic,@Sitemno,@ck1,@QVmemo,@Qanswer,@sub_score,@yn,@userid,@userdate)";
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("depid", depid));
            cmd.Parameters.Add(Para("empid", empid));
            cmd.Parameters.Add(Para("QCmemo", QCmemo, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("QCpic0", QCpic0, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("QApic", QApic, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("ck1", ck1, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("sub_score",sub_score, SqlDbType.Decimal));
            //cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("QVmemo", QVmemo, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Qanswer", Qanswer, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("userid", userid, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public int UpdatePicture(string GSBH,  string depid, string empid, string QCmemo, string QCpic0, string QApic, string Sitemno, string ck1, string QVmemo, string Qanswer, int sub_score, int ID,string yn,string userid,DateTime userdate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "  update S8rec set depid=@depid,empid=@empid,QCmemo=@QCmemo,QCpic0=@QCpic0,QApic=@QApic,Sitemno=@Sitemno,ck1=@ck1,QVmemo=@QVmemo,Qanswer=@Qanswer,sub_score=@sub_score,yn=@yn,userid=@userid,userdate=@userdate";
            cmd.CommandText += " where sh=@sh and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
            
            cmd.Parameters.Add(Para("depid", depid));
            cmd.Parameters.Add(Para("empid", empid));
            cmd.Parameters.Add(Para("QCmemo", QCmemo, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("QCpic0", QCpic0, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("QApic", QApic, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("ck1", ck1, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("sub_score",sub_score, SqlDbType.Int));
            cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("QVmemo", QVmemo, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Qanswer", Qanswer, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("userid", userid, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public int UpdatePicture111(string GSBH, string depid, string empid, string QCmemo, string Sitemno, string ck1, string QVmemo, string Qanswer, decimal sub_score, int ID, string yn, string userid, DateTime userdate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "  update S8rec set depid=@depid,empid=@empid,QCmemo=@QCmemo,Sitemno=@Sitemno,ck1=@ck1,QVmemo=@QVmemo,Qanswer=@Qanswer,sub_score=@sub_score,yn=@yn,userid=@userid,userdate=@userdate";
            cmd.CommandText += " where sh=@sh and GSBH=@GSBH";
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));

            cmd.Parameters.Add(Para("depid", depid));
            cmd.Parameters.Add(Para("empid", empid));
            cmd.Parameters.Add(Para("QCmemo", QCmemo, SqlDbType.NVarChar));
            
            cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("ck1", ck1, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("sub_score", sub_score, SqlDbType.Decimal));
            cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
            cmd.Parameters.Add(Para("QVmemo", QVmemo, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("Qanswer", Qanswer, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("yn", yn, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("userid", userid, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("userdate", userdate, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public int ConfirmScrore1(string ck1, int Score1, string GSBH, int sh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update S8rec set ck1=@ck1, sub_score=@sub_score where GSBH=@GSBH and sh=@sh";
            cmd.Parameters.Add(Para("ck1", ck1, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("sub_score", Score1, SqlDbType.Int));
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("sh", sh, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int ConfirmScrore2(string ck2, int Score1, string GSBH, int sh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update S8rec set ck2=@ck2, sub_score=@sub_score where GSBH=@GSBH and sh=@sh";
            cmd.Parameters.Add(Para("ck2", ck2, SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("sub_score", Score1, SqlDbType.Int));
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("sh", sh, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateConfirmAuditor(string QVmemo,string Qanswer,int sub_score,string ck2,string QCmemo,int sh,string GSBH,string Yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update S8rec set QCmemo=@QCmemo,QVmemo=@QVmemo,Qanswer=@Qanswer,sub_score=@sub_score,ck2=@ck2, yn=@yn where sh=@sh and GSBH=@GSBH";
                cmd.Parameters.Add(Para("QCmemo", QCmemo, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("QVmemo", QVmemo, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Qanswer", Qanswer, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sub_score", sub_score, SqlDbType.Int));
                cmd.Parameters.Add(Para("ck2", ck2, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("yn", Yn, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("sh", sh, SqlDbType.Int));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdatePicture0(string GSBH, DateTime S8date, int ID, int sub_score, string QCpic0, string QCmemo,string ck1,string Yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "  update S8rec set QCmemo=@QCmemo,QCpic0=@QCpic0,ck1=@ck1,sub_score=@sub_score, yn=@yn where GSBH=@GSBH and S8date=@S8date and sh=@sh";
                cmd.Parameters.Add(Para("S8date",S8date,SqlDbType.DateTime));
                cmd.Parameters.Add(Para("QCmemo",QCmemo,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("ck1",ck1,SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sub_score",sub_score,SqlDbType.Int));
                cmd.Parameters.Add(Para("QCpic0", QCpic0, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
                cmd.Parameters.Add(Para("yn", Yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdatePicture1(string GSBH, DateTime S8date, int ID, int sub_score, string QApic, string QCmemo, string ck2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "  update S8rec set QCmemo=@QCmemo,QApic=@QApic,ck2=@ck2,sub_score=@sub_score where GSBH=@GSBH and S8date=@S8date and sh=@sh";
                cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("QCmemo", QCmemo, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("ck2", ck2, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sub_score", sub_score, SqlDbType.Int));
                cmd.Parameters.Add(Para("QApic", QApic, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateImageWhenUpLoad1(string GSBH,  int ID, string Image)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update S8rec set QCpic0=@QCpic0  where GSBH=@GSBH  and sh=@sh";
                cmd.Parameters.Add(Para("GSBH", GSBH));
                
                cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
                cmd.Parameters.Add(Para("QCpic0", Image, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int UpdateImageWhenUpLoad2(string GSBH,  int ID, string Image)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update S8rec set QApic=@QApic  where GSBH=@GSBH  and sh=@sh";
                cmd.Parameters.Add(Para("GSBH", GSBH));
               
                cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
                cmd.Parameters.Add(Para("QApic", Image, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryDonViLenDropBoxTrenHRM(int Nam,int Thang)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DV_MA,DV_TEN,TENDV_TAIWAN from kh_Qrydonvi(-1,@Nam,@Thang)";
                cmd.Parameters.Add(Para("Nam", Nam, SqlDbType.Int));
                cmd.Parameters.Add(Para("Thang", Thang, SqlDbType.Int));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryDonViLenDropBoxTrenERP(string CongTy)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ID,DepName,DepName_C from bdepartment where gsbh=@GSBH and planyn=1 and useYN=1 order by DepName";
            cmd.Parameters.Add(Para("GSBH", CongTy, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }

        #region Tam Bo
        //public DataTable HienThiDanhSachChuaTaoCuaNhanVien(string GSBH,DateTime FromDate,DateTime ToDate)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID not in(select depid from S8rec where  s8date between @FromDate and @ToDate)  and planyn=1 and useYN=1 order by DepName";
        //        cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
        //        cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
        //        return selex(cmd).Tables[0];
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
        //public DataTable HienThiDanhSachDaTaoTaoCuaNhanVien(string GSBH, DateTime FromDate, DateTime ToDate)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID  in(select depid from S8rec where  s8date between @FromDate and @ToDate)  and planyn=1 and useYN=1 order by DepName";
        //        cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
        //        cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
        //        return selex(cmd).Tables[0];
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public DataTable HienThiDanhSachDonViChuaChuyenCuaCanBo(string GSBH, DateTime FromDate, DateTime ToDate)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment BD ";
        //        cmd.CommandText += "  left join S8rec S8 on BD.ID=S8.depid where  BD.GSBH=@GSBH and S8.S8date between @FromDate and @ToDate and S8.yn=0 order by DepName";
        //        cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
        //        cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
        //        return selex(cmd).Tables[0];
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public DataTable HienThiDanhSachDonViDaChuyenCuaCanBo(string GSBH, DateTime FromDate, DateTime ToDate)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment BD ";
        //        cmd.CommandText += "  left join S8rec S8 on BD.ID=S8.depid where  BD.GSBH=@GSBH and S8.S8date between @FromDate and @ToDate and S8.yn=2 order by DepName";
        //        cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
        //        cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
        //        return selex(cmd).Tables[0];
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #endregion 
        public DataTable HienThiDanhSachChuaTaoCuaNhanVienCR(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID not in(select depid from S8rec where  s8date=@s8date and ck1<>'1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
               
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachDaTaoTaoCuaNhanVienCR(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID  in(select depid from S8rec where  s8date=@s8date and ck1='1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachChuaTaoCuaNhanVienNS(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID not in(select depid from S8rec where  s8date=@s8date and ck2<>'1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachDaTaoTaoCuaNhanVienNS(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID  in(select depid from S8rec where  s8date=@s8date and ck2='1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachChuaTaoCuaNhanVienTKTH(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID not in(select depid from S8rec where  s8date=@s8date and ck3<>'1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachDaTaoTaoCuaNhanVienTKTH(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment where gsbh=@GSBH  and ID  in(select depid from S8rec where  s8date=@s8date and ck3='1')  and planyn=1 and useYN=1 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachDonViChuaChuyenCuaCanBo(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment BD ";
                cmd.CommandText += "  left join S8rec S8 on BD.ID=S8.depid where  BD.GSBH=@GSBH and S8.S8date=@S8date  and S8.yn=0 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachDonViDaChuyenCuaCanBo(string GSBH, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct ID,DepName,DepName_C from bdepartment BD ";
                cmd.CommandText += "  left join S8rec S8 on BD.ID=S8.depid where  BD.GSBH=@GSBH and S8.S8date=@S8date and S8.yn=2 order by DepName";
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("s8date", Date, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatVaKhoaDiemCuaDonVi(string checker,string depid, string GSBH, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update S8rec set yn='2', checker=@checker where depid=@depid and GSBH=@GSBH and S8date between @FromDate and @ToDate";
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("checker", checker, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraDonViTruocKhiThem(string depid, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from S8rec where S8date between @FromDate and @ToDate and depid=@depid";
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraDonViTruocKhiThem1(string depid, DateTime Date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from S8rec where S8date =@S8date and depid=@depid";
                cmd.Parameters.Add(Para("S8date", Date, SqlDbType.DateTime));
             
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayDonViCapConCuaDonVi(string DVCha)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select * from dbo.KH_LayDonViMa(@DV_Ma)";
                cmd.Parameters.Add(Para("DV_Ma", DVCha, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayIDMax()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select max(sh)as ID from S8rec ";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable XuatBaoCao()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from S8item S8I left join S8rec S8R on S8I.Sitemno=S8R.Sitemno";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayChiTiet8STheoID(int ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct * from S8item S8I ";
                cmd.CommandText +=" left join S8rec S8R on S8I.Sitemno=S8R.Sitemno";
                cmd.CommandText +=" where S8R.sh=@ID";
                cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryBanTin8SVN(DateTime Fromdate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryBanTin8SVN1(DateTime Fromdate, DateTime ToDate,string depid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate and S8R.depid=@depid";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryBanTin8SEN(DateTime Fromdate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryBanTin8SEN1(DateTime Fromdate, DateTime ToDate,string depid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate and S8R.depid=@depid";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryBanTin8STW(DateTime Fromdate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryBanTin8STW1(DateTime Fromdate, DateTime ToDate,string depid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate and S8R.depid=@depid";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryBanTin8S1(DateTime Fromdate, DateTime ToDate,string DepartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct S8I.*,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName from  S8rec S8R";
                cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
                cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID";
                cmd.CommandText += " where S8R.S8date between @FromDate and @ToDate and S8R.depid=ISNULL(@DepartID,depid)";
                cmd.Parameters.Add(Para("FromDate", Fromdate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("DepartID", DepartID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayTuanThangTheoNgay(DateTime date)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from IT_TUAN where @Date between T_TUNGAY and T_DENNGAY";
                cmd.Parameters.Add(Para("Date", date, SqlDbType.DateTime));
              
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayTuanTrenERP(string Year, string Month)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select CWEEK, WDAY1,WDAY2 from CWeeks where CYEAR=@CYEAR and CMONTH=@CMONTH and CWEEK<>'Z'";
            cmd.Parameters.Add(Para("CYEAR", Year, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("CMONTH", Month, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
        public DataTable LayTuanThangTheoNgayTrenERP(string Year, string Month, string CWEEK)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from CWeeks where CYEAR=@CYEAR and CMONTH=@CMONTH and CWEEK=@CWEEK and CWEEK<>'Z'";
                cmd.Parameters.Add(Para("CWEEK", CWEEK, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CYEAR", Year, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CMONTH", Month, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayNgayThangTheoTuan(string Year,string Month,string Week)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " select WDAY1,WDAY2 from CWeeks where CYEAR=@CYEAR and CMONTH=@CMONTH and CWEEK=@CWEEK";
            cmd.Parameters.Add(Para("CYEAR", Year, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("CMONTH", Month, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("CWEEK", Week, SqlDbType.VarChar));
            return selex(cmd).Tables[0];
        }
        public DataTable LayTuanThangTheoTuanTrenERP(string Year, string Month, string week)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from CWeeks where CYEAR=@CYEAR and CMONTH=@CMONTH and CWEEK=@CWEEK ";
                cmd.Parameters.Add(Para("CWEEK", week, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CYEAR", Year, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("CMONTH", Month, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ChuyenDiemQuaBangProScore(string Pyear,string Pmonth,string Pweek,string Pdepid,string GSBH,decimal S8score,DateTime FromDate,DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="if exists(select * from ProdScores where Pyear=@Pyear and Pmonth=@Pmonth and Pweek=@Pweek and Pdepid=@Pdepid and GSBH=@GSBH)";
                cmd.CommandText+=" begin";
                cmd.CommandText+="    update ProdScores set S8score=S8score where Pyear=@Pyear and Pmonth=@Pmonth and Pweek=@Pweek and Pdepid=@Pdepid and GSBH=@GSBH";
                cmd.CommandText+="  end";
                cmd.CommandText+="  else";
                cmd.CommandText+="   begin";
                cmd.CommandText += "    insert ProdScores(Pyear,Pmonth,Pweek,Pdepid,S8score,GSBH,wdate0,wdate1)values(@Pyear,@Pmonth,@Pweek,@Pdepid,@S8score,@GSBH,@wdate0,@wdate1)";
                cmd.CommandText += "  end";
                cmd.Parameters.Add(Para("Pyear", Pyear, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Pmonth", Pmonth, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Pweek", Pweek, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("Pdepid", Pdepid, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("S8score", S8score, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.NVarChar));
                cmd.Parameters.Add(Para("wdate0", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("wdate1", ToDate, SqlDbType.DateTime));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int Them8SVaoTrongbangS8Rec_CR(string GSBH,string depid,string UserID,DateTime Date)
        {
           // SqlCommand cmd = new SqlCommand();
           // cmd.CommandText = " SET IDENTITY_INSERT [dbo].[S8Rec] ON";
           // cmd.CommandText +="  insert S8rec (GSBH,s8date,Sitemno,depid,empid,userid,userdate,sub_score) ";
           // cmd.CommandText +="  select @GSBH as gsbh ,convert(date,GETDATE()) as s8date";
           ////  cmd.CommandText +="   ,ROW_NUMBER() over (order by i8.sitemno ) as sh";
           //  cmd.CommandText +=" ,  I8.Sitemno ";
           //  cmd.CommandText +="   ,@depid as depid ,@user as empid ,@user as userid,GETDATE() as userdate ";
           //  cmd.CommandText +="   , I8.Sitemscore as sub_score";
           // cmd.CommandText +="  from S8item I8";
           // cmd.CommandText +="  left join S8rec R8 on R8.Sitemno=I8.Sitemno and r8.gsbh=@GSBH and r8.depid=@depid";
           // cmd.CommandText +="  where R8.s8date0 is null";
           // cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
           // cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
           // cmd.Parameters.Add(Para("user", UserID, SqlDbType.VarChar));

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText += "     declare @depid varchar(11), @user varchar(10) ,@GSBH varchar(4),@Date as datetime";
            cmd.CommandText +=" set @GSBH='"+GSBH+"'";
            cmd.CommandText +=" set @depid='"+depid+"' ";
            cmd.CommandText +=" set @user='"+UserID+"'";
            cmd.CommandText += " set @Date='" + Date + "'";
            cmd.CommandText+="   insert S8rec (GSBH,s8date,Sitemno,depid,empid,userid,userdate,sub_score,yn,ck1)";
            cmd.CommandText+="   select distinct * from(";
              cmd.CommandText+="  select @GSBH as gsbh ,@Date as s8date";
              cmd.CommandText+="  ,  I8.Sitemno";
              cmd.CommandText+="  ,@depid as depid ,@user as empid ,@user as userid,GETDATE() as userdate";
              cmd.CommandText+="  , I8.Sitemscore as sub_score,yn=0,ck1='1'";
              cmd.CommandText+="  from S8item I8";
              cmd.CommandText+="  left join S8rec R8 on R8.Sitemno=I8.Sitemno and r8.gsbh=@GSBH and r8.depid=@depid";
              cmd.CommandText+="  left join S8type S8T on S8T.Sitemtp=I8.Sitemtp";
              cmd.CommandText+="  where  S8T.Sitemtp='S6'";
              cmd.CommandText+="  )A";
              cmd.CommandText += "  where not exists(select * from S8rec S8 where S8.s8date=A.s8date and S8.depid=A.depid and S8.Sitemno=A.Sitemno ) ";
            return ExecuteNonQuery(cmd);
        }
        public int Them8SVaoTrongbangS8Rec_NS(string GSBH, string depid, string UserID, DateTime Date)
        {
           

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText += "     declare @depid varchar(11), @user varchar(10) ,@GSBH varchar(4),@Date as datetime";
            cmd.CommandText += " set @GSBH='" + GSBH + "'";
            cmd.CommandText += " set @depid='" + depid + "' ";
            cmd.CommandText += " set @user='" + UserID + "'";
            cmd.CommandText += " set @Date='" + Date + "'";
            cmd.CommandText+="   insert S8rec (GSBH,s8date,Sitemno,depid,empid,userid,userdate,sub_score,yn,ck2)";
            cmd.CommandText+="   select distinct * from(";
              cmd.CommandText+="  select @GSBH as gsbh ,@Date as s8date";
              cmd.CommandText+="  ,  I8.Sitemno";
              cmd.CommandText+="  ,@depid as depid ,@user as empid ,@user as userid,GETDATE() as userdate";
              cmd.CommandText+="  , I8.Sitemscore as sub_score,yn=0,ck2='1'";
              cmd.CommandText+="  from S8item I8";
              cmd.CommandText+="  left join S8rec R8 on R8.Sitemno=I8.Sitemno and r8.gsbh=@GSBH and r8.depid=@depid";
              cmd.CommandText+="  left join S8type S8T on S8T.Sitemtp=I8.Sitemtp";
              cmd.CommandText+="  where  S8T.Sitemtp='S8'";
              cmd.CommandText+="  )A";
              cmd.CommandText += "  where not exists(select * from S8rec S8 where S8.s8date=A.s8date and S8.depid=A.depid and S8.Sitemno=A.Sitemno ) ";
            return ExecuteNonQuery(cmd);
        }
        public int Them8SVaoTrongbangS8Rec_TKTH(string GSBH, string depid, string UserID, DateTime Date)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText += "     declare @depid varchar(11), @user varchar(10) ,@GSBH varchar(4),@Date as datetime";
            cmd.CommandText += " set @GSBH='" + GSBH + "'";
            cmd.CommandText += " set @depid='" + depid + "' ";
            cmd.CommandText += " set @user='" + UserID + "'";
            cmd.CommandText += " set @Date='" + Date + "'";
            cmd.CommandText+="        insert S8rec (GSBH,s8date,Sitemno,depid,empid,userid,userdate,sub_score,yn,ck3)";
             cmd.CommandText+="   select distinct * from(";
              cmd.CommandText+="   select @GSBH as gsbh ,@Date as s8date";
              cmd.CommandText+="   ,  I8.Sitemno";
              cmd.CommandText+="   ,@depid as depid ,@user as empid ,@user as userid,GETDATE() as userdate";
              cmd.CommandText+="   , I8.Sitemscore as sub_score,yn=0,ck3='1'";
              cmd.CommandText+="   from S8item I8";
              cmd.CommandText+="   left join S8rec R8 on R8.Sitemno=I8.Sitemno and r8.gsbh=@GSBH and r8.depid=@depid";
              cmd.CommandText+="   left join S8type S8T on S8T.Sitemtp=I8.Sitemtp";
              cmd.CommandText+="   where S8T.Sitemtp<>'S6' and S8T.Sitemtp<>'S8'";
             cmd.CommandText+="    )A";
             cmd.CommandText += "   where not exists(select * from S8rec S8 where S8.s8date=A.s8date and S8.depid=A.depid and S8.Sitemno=A.Sitemno ) ";
            return ExecuteNonQuery(cmd);
        }
        public int CopyDiemGIongNhau(string GSBH, string depidDau,string depidDen, string UserID, DateTime Date)
        {
            string SQL = "";
           
            SQL+="   declare @depidDau varchar(11), @user varchar(10) ,@GSBH varchar(4),@Date as datetime,@depidDen varchar(11)";
             SQL+="   set @GSBH='"+GSBH+"'";
             SQL+="   set @depidDau='"+depidDau+"'"; 
             SQL+="   set @user='"+UserID+"'";
             SQL+="   set @Date='"+Date+"'";
             SQL+="   set @depidDen='"+depidDen+"'";
             SQL+="   update S8rec set sub_score=A.sub_score,ck1=A.ck1,ck2=A.ck2,ck3=A.ck3";
             SQL+="   from (";
             SQL+="   select distinct @GSBH as gsbh ,@Date as s8date, S8I.Sitemno, S8R.sub_score ,";
             SQL+="   @depidDen as depid ,@user as empid ,@user as userid,GETDATE() as userdate,yn=0,ck1=S8R.ck1,ck2=S8R.ck2,ck3=S8R.ck3";
             SQL+="   from S8rec S8R";
             SQL+="   left join S8item S8I on S8R.Sitemno=S8I.Sitemno and S8R.depid=@depidDau";
             SQL+="   left join S8type S8T on S8I.Sitemtp=S8T.Sitemtp";
             SQL+="   where  S8R.depid=@depidDau and S8R.S8date=@Date)A";
             SQL+="   where S8rec.GSBH=A.gsbh and S8rec.depid=A.depid and S8rec.S8date=A.s8date and S8rec.Sitemno=A.Sitemno";
             SQL+="   insert into S8rec(GSBH,S8date,Sitemno,sub_score,depid,empid,userid,userdate,yn,ck1,ck2,ck3)";
              SQL+="   select * from (";
             SQL+="   select distinct @GSBH as gsbh ,@Date as s8date, S8I.Sitemno, S8R.sub_score ,";
             SQL+="   @depidDen as depid ,@user as empid ,@user as userid,GETDATE() as userdate,yn=0,ck1=S8R.ck1,ck2=S8R.ck2,ck3=S8R.ck3";
             SQL+="   from S8rec S8R";
             SQL+="   left join S8item S8I on S8R.Sitemno=S8I.Sitemno and S8R.depid=@depidDau";
             SQL+="   left join S8type S8T on S8I.Sitemtp=S8T.Sitemtp";
             SQL+="   where  S8R.depid=@depidDau and S8R.S8date=@Date)A";
             SQL += "   where not exists (select * from S8rec S8 where S8.GSBH=A.gsbh and S8.depid=A.depid and S8.Sitemno=A.Sitemno and S8.S8date=A.s8date)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            return ExecuteNonQuery(cmd);

        }
        public DataSet QryTongDiem8STheoNgayThangClass_E(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="select  distinct b1.id as Depid,b1.DepName,b1.DepName_C,isnull(SUM(sub_score),0)/COUNT(distinct S8date ) as S8Score";
             cmd.CommandText +="  from S8rec ";
              cmd.CommandText +="  left join BDepartment b1 on S8rec.Depid=b1.id and S8rec.GSBH=b1.GSBH";
              cmd.CommandText +="  where S8date between @FromDate  and @ToDate and b1.Dclass='E' ";
              cmd.CommandText +="  group by b1.id,b1.DepName,b1.DepName_C";
              cmd.CommandText += "  order by DepName,S8Score asc";
              cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
              cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
              return selex(cmd, "dt8SSumScore");
        }
        public DataSet QryTongDiem8STheoNgayThangClass_D(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmd = new SqlCommand();
              cmd.CommandText +="    select  distinct b2.id as Depid,b2.DepName,b2.DepName_C,isnull(SUM(sub_score),0)/COUNT(distinct S8date ) as S8Score";
              cmd.CommandText +="    from S8rec ";
              cmd.CommandText +="    left join BDepartment b1 on S8rec.Depid=b1.id and S8rec.GSBH=b1.GSBH";
              cmd.CommandText +="    left join BDepartment b2 on b1.ulid=b2.id  and b2.GSBH=b1.GSBH";
              cmd.CommandText +="    left join BDepartment b3 on b2.ulid=b3.id  and b3.GSBH=b2.GSBH";
              cmd.CommandText +="    left join BDepartment b4 on b3.ulid=b4.id  and b4.GSBH=b3.GSBH";
              cmd.CommandText +="    where S8date between @FromDate  and @ToDate and b2.Dclass='D' ";
              cmd.CommandText += "    group by b2.id,b2.DepName,b2.DepName_C";
              cmd.CommandText += "  order by DepName,S8Score asc";
              cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
              cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
              return selex(cmd, "dt8SSumScore");
        }
        public DataSet QryTongDiem8STheoNgayThangClass_C(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText += "    select  distinct b3.id as Depid,b3.DepName,b3.DepName_C,isnull(SUM(sub_score),0)/COUNT(distinct S8date ) as S8Score";
            cmd.CommandText += "    from S8rec ";
            cmd.CommandText += "    left join BDepartment b1 on S8rec.Depid=b1.id and S8rec.GSBH=b1.GSBH";
            cmd.CommandText += "    left join BDepartment b2 on b1.ulid=b2.id  and b2.GSBH=b1.GSBH";
            cmd.CommandText += "    left join BDepartment b3 on b2.ulid=b3.id  and b3.GSBH=b2.GSBH";
            cmd.CommandText += "    left join BDepartment b4 on b3.ulid=b4.id  and b4.GSBH=b3.GSBH";
            cmd.CommandText += "    where S8date between @FromDate  and @ToDate and b3.Dclass='C' ";
            cmd.CommandText += "    group by b3.id,b3.DepName,b3.DepName_C";
            cmd.CommandText += "  order by DepName,S8Score asc";
            cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
            return selex(cmd, "dt8SSumScore");
        }
        public DataSet QryTongDiem8STheoNgayThangClass_B(DateTime FromDate, DateTime ToDate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText += "    select  distinct b4.id as Depid,b4.DepName,b4.DepName_C,isnull(SUM(sub_score),0)/COUNT(distinct S8date ) as S8Score";
            cmd.CommandText += "    from S8rec ";
            cmd.CommandText += "    left join BDepartment b1 on S8rec.Depid=b1.id and S8rec.GSBH=b1.GSBH";
            cmd.CommandText += "    left join BDepartment b2 on b1.ulid=b2.id  and b2.GSBH=b1.GSBH";
            cmd.CommandText += "    left join BDepartment b3 on b2.ulid=b3.id  and b3.GSBH=b2.GSBH";
            cmd.CommandText += "    left join BDepartment b4 on b3.ulid=b4.id  and b4.GSBH=b3.GSBH";
            cmd.CommandText += "    where S8date between @FromDate  and @ToDate and b4.Dclass='B' ";
            cmd.CommandText += "    group by b4.id,b4.DepName,b4.DepName_C";
            cmd.CommandText += "  order by DepName,S8Score asc";
            cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
            return selex(cmd, "dt8SSumScore");
        }
    }
}