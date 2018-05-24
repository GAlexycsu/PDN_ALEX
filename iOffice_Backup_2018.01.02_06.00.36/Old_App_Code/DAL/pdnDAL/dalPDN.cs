using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

    public class dalPDN : GernericDataAccess
    {
        public dalPDN()
        { }
        public  DataTable QryPhieuPDNTheoNguoiDuyet(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay,string Yn1,string Yn2,string Yn4)

        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select distinct pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
            //cmd.CommandText +=" from pdna pd";
            //cmd.CommandText +=" left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
            //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
            //cmd.CommandText +=" left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText +=" left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
            //cmd.CommandText +=" left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
            //cmd.CommandText +=" left join aABC abc on abc.ABC=ab.ABC";
            //cmd.CommandText +=" where   ab.Auditor=@Auditor";  
            //cmd.CommandText += " and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1)";
            //cmd.CommandText += " and ab.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc";
            cmd.CommandText = "QryPhieuPDNTheoNguoiDuyet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));
          
            return Select(cmd).Tables[0];

        }
        public DataTable QryPhieuPDNTheoNguoiDuyetEN(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, string Yn1, string Yn2, string Yn4)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select distinct pd.Abtype,abi.abnameEng as abname,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " ab.ABC,abc.NameABCEng as NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
            //cmd.CommandText += " from pdna pd";
            //cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
            //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
            //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
            //cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
            //cmd.CommandText += " where   ab.Auditor=@Auditor";
            //cmd.CommandText += " and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1)";
            //cmd.CommandText += " and ab.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc";
            cmd.CommandText = "QryPhieuPDNTheoNguoiDuyetEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));

            return Select(cmd).Tables[0];

        }
        public DataTable TimKiemPhieuTheoMaPhieuVaNguoiDuyetVN(string pdno,string GSBH,string auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle,";
                //cmd.CommandText += " ab.ABC,abc.NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
                //cmd.CommandText +=" from pdna pd";
                //cmd.CommandText +=" left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
                //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
                //cmd.CommandText +=" left join abill abi on pd.Abtype=abi.abtype";
                //cmd.CommandText +=" left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
                //cmd.CommandText +=" left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
                //cmd.CommandText +=" left join aABC abc on abc.ABC=ab.ABC";
                //cmd.CommandText += " where   ab.Auditor=@Auditor";
                //cmd.CommandText += " and ab.Gsbh=@Gsbh and pd.pdno=@pdno";
                cmd.CommandText = "TimKiemPhieuTheoMaPhieuVaNguoiDuyetVN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", auditor));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                return Select(cmd).Tables[0];

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimKiemPhieuTheoMaPhieuVaNguoiDuyetEN(string pdno, string GSBH, string auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abi.abnameEng as abname,pd.pdno,pd.mytitle as mytitle,";
                //cmd.CommandText += " ab.ABC,abc.NameABCEng as NameABC,ab.from_user ,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
                //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
                //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
                //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
                //cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
                //cmd.CommandText += " where   ab.Auditor=@Auditor";
                //cmd.CommandText += " and ab.Gsbh=@Gsbh and pd.pdno=@pdno";
                cmd.CommandText = "TimKiemPhieuTheoMaPhieuVaNguoiDuyetEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", auditor));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                return Select(cmd).Tables[0];

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimKiemPhieuTheoMaPhieuVaNguoiDuyetTW(string pdno, string GSBH, string auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abi.abnameTW,pd.pdno,pd.mytitle as mytitle,";
                //cmd.CommandText += " ab.ABC,abc.NameABCTW,ab.from_user,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
                //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
                //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
                //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
                //cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
                cmd.CommandText = "TimKiemPhieuTheoMaPhieuVaNguoiDuyetTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", auditor));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuPDNTheoNguoiDuyetTW(string idNguoiDuyet, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, string Yn1, string Yn2, string Yn4)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select distinct pd.Abtype,abi.abnameTW,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " ab.ABC,abc.NameABCTW,ab.from_user,bu.USERNAME,ab.from_depart,bd.DepName,ab.Yn, abyn.YnName,pd.CFMDate0";
            //cmd.CommandText += " from pdna pd";
            //cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
            //cmd.CommandText += "  left join ABYn abyn on abyn.Yn=ab.Yn";
            //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
            //cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
            //cmd.CommandText += " where   ab.Auditor=@Auditor";
            //cmd.CommandText += " and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1 )";
            //cmd.CommandText += " and ab.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc";
            cmd.CommandText = "QryPhieuPDNTheoNguoiDuyetTW";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));
           
            return Select(cmd).Tables[0];

        }
        public  DataTable QryPhieuDeNghiMyDocus(string idNguoiTao, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, string Yn5, string Yn6, string Yn7)
        {
            SqlCommand cmd = new SqlCommand();
           
            //cmd.CommandText = " select distinct pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName,pd.CFMDate0";
            //cmd.CommandText += " from pdna pd";
            //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
            //cmd.CommandText += " where   pd.CFMID0=@CFMID0";
            //cmd.CommandText += " and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
            //cmd.CommandText += " and pd.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc";

            cmd.CommandText = "QryPhieuDeNghiMyDocus";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuDeNghiMyDocusEN(string idNguoiTao, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, string Yn5, string Yn6, string Yn7)
        {
            SqlCommand cmd = new SqlCommand();

            //cmd.CommandText = " select distinct pd.Abtype,abi.abnameEng as abname,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName,pd.CFMDate0";
            //cmd.CommandText += " from pdna pd";
            //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
            //cmd.CommandText += " where   pd.CFMID0=@CFMID0";
            //cmd.CommandText += " and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
            //cmd.CommandText += " and pd.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc";
            cmd.CommandText = "QryPhieuDeNghiMyDocusEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuDeNghiMyDocusTW(string idNguoiTao, string pGSBH, DateTime pTuNgay, DateTime pDenNgay, string Yn5, string Yn6, string Yn7)
        {
            SqlCommand cmd = new SqlCommand();

            //cmd.CommandText = " select distinct pd.Abtype,abi.abnameTW,pd.pdno,pd.mytitle as mytitle,";
            //cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName,pd.CFMDate0";
            //cmd.CommandText += " from pdna pd";
            //cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            //cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
            //cmd.CommandText += " where   pd.CFMID0=@CFMID0";
            //cmd.CommandText += " and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
            //cmd.CommandText += " and pd.Gsbh=@GSBH and pd.CFMDate0 between @TuNgay and @DenNgay order by pd.pdno asc ";

            cmd.CommandText = "QryPhieuDeNghiMyDocusTW";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("TuNgay", pTuNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("DenNgay", pDenNgay, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        //public DataTable QryPhieuChoDuyetTheoNguoiDuyet(string idNguoiDuyet, string pGSBH, string Yn1, string Yn2, string Yn4)
        //{
        //    try
        //    {
        //         SqlCommand cmd = new SqlCommand();
        //         cmd.CommandText = "select distinct pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle,";
        //         cmd.CommandText += " ab.ABC,abc.NameABC,ab.from_user,bu.USERNAME,ab.from_depart,bd.DepName";
        //         cmd.CommandText += " from pdna pd";
        //         cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
        //         cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
        //         cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
        //         cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
        //         cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
        //         cmd.CommandText += " where   ab.Auditor=@Auditor";
        //         cmd.CommandText += " and ab.from_user!=@Auditor and pd.CFMID0!=@Auditor";
        //         cmd.CommandText += " and ab.Gsbh=@GSBH and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1)";
        //         cmd.CommandText += " order by";
        //         cmd.CommandText += " CASE";
        //         cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
        //         cmd.CommandText += " ELSE null";
        //         cmd.CommandText += " END DESC";
        //            cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
        //            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
        //            cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
        //            cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
        //            cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));
        //            return Select(cmd).Tables[0];

        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
        //public DataTable QryPhieuChoDuyetTheoNguoiDuyetEN(string idNguoiDuyet, string pGSBH, string Yn1, string Yn2, string Yn4)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct pd.Abtype,abi.abnameEng as abname,pd.pdno,pd.mytitle as mytitle,";
        //        cmd.CommandText += " ab.ABC,abc.NameABCEng as NameABC,ab.from_user,bu.USERNAME,ab.from_depart,bd.DepName";
        //        cmd.CommandText += " from pdna pd";
        //        cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
        //        cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
        //        cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
        //        cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
        //        cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
        //        cmd.CommandText += " where   ab.Auditor=@Auditor";
        //        cmd.CommandText += " and ab.from_user!=@Auditor and pd.CFMID0!=@Auditor";
        //        cmd.CommandText += " and ab.Gsbh=@GSBH and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1)";
        //        cmd.CommandText += " order by";
        //        cmd.CommandText += " CASE";
        //        cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
        //        cmd.CommandText += " ELSE null";
        //        cmd.CommandText += " END DESC";
        //        cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));
        //        return Select(cmd).Tables[0];

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public DataTable QryPhieuChoDuyetTheoNguoiDuyetTW(string idNguoiDuyet, string pGSBH, string Yn1, string Yn2, string Yn4)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "select distinct pd.Abtype,abi.abnameTW,pd.pdno,pd.mytitle as mytitle,";
        //        cmd.CommandText += " ab.ABC,abc.NameABCTW,ab.from_user,bu.USERNAME,ab.from_depart,bd.DepName";
        //        cmd.CommandText += " from pdna pd";
        //        cmd.CommandText += " left join Abcon ab on ab.pdno=pd.pdno and ab.Gsbh=pd.GSBH";
        //        cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
        //        cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =ab.from_depart";
        //        cmd.CommandText += " left join Busers2 bu on bu.USERID=ab.from_user and bu.GSBH=ab.Gsbh";
        //        cmd.CommandText += " left join aABC abc on abc.ABC=ab.ABC";
        //        cmd.CommandText += " where   ab.Auditor=@Auditor";
        //        cmd.CommandText += " and ab.from_user!=@Auditor and pd.CFMID0!=@Auditor";
        //        cmd.CommandText += " and ab.Gsbh=@GSBH and (ab.Yn=@Yn4 or ab.Yn= @Yn2 or ab.Yn=@Yn1)";
        //        cmd.CommandText += " order by";
        //        cmd.CommandText += " CASE";
        //        cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
        //        cmd.CommandText += " ELSE null";
        //        cmd.CommandText += " END DESC";
        //        cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn1", Yn1, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.VarChar));
        //        return Select(cmd).Tables[0];

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public DataTable QryPhieuDeNghiDaDichChoGui(string idNguoiTao, string pGSBH, string Yn5, string Yn6, string Yn7)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = " select distinct pd.Abtype,abi.abname,pd.pdno,pd.mytitle as mytitle,";
        //    cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName";
        //    cmd.CommandText += " from pdna pd";
        //    cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
        //    cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
        //    cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
        //    cmd.CommandText += " where   pd.CFMID0=@CFMID0";
        //    cmd.CommandText += " and pd.Gsbh=@GSBH and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
        //    cmd.CommandText += " order by";
        //    cmd.CommandText += " CASE";
        //    cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
        //    cmd.CommandText += " ELSE null";
        //    cmd.CommandText += " END DESC";
        //    cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
        //    return Select(cmd).Tables[0];
        //}
        //public DataTable QryPhieuDeNghiDaDichChoGuiEN(string idNguoiTao, string pGSBH, string Yn5, string Yn6, string Yn7)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = " select distinct pd.Abtype,abi.abnameEng as abname,pd.pdno,pd.mytitle as mytitle,";
        //    cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName";
        //    cmd.CommandText += " from pdna pd";
        //    cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
        //    cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
        //    cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
        //    cmd.CommandText += " where   pd.CFMID0=@CFMID0";
        //    cmd.CommandText += " and pd.Gsbh=@GSBH and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
        //    cmd.CommandText += " order by";
        //    cmd.CommandText += " CASE";
        //    cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
        //    cmd.CommandText += " ELSE null";
        //    cmd.CommandText += " END DESC";
        //    cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
        //    cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
        //    return Select(cmd).Tables[0];
        //}
        public DataTable QryPhieuDeNghiDaDichChoGuiTW(string idNguoiTao, string pGSBH, string Yn5, string Yn6, string Yn7)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = " select distinct pd.Abtype,abi.abnameTW,pd.pdno,pd.mytitle as mytitle,";
            cmd.CommandText += " bu.USERNAME,pd.pddepid,bd.DepName";
            cmd.CommandText += " from pdna pd";
            cmd.CommandText += " left join abill abi on pd.Abtype=abi.abtype";
            cmd.CommandText += " left join BDepartment bd on bd.GSBH=pd.GSBH and bd.ID =pd.CFMID0";
            cmd.CommandText += " left join Busers2 bu on bu.USERID=pd.CFMID0 and bu.GSBH=pd.GSBH";
            cmd.CommandText += " where   pd.CFMID0=@CFMID0";
            cmd.CommandText += " and pd.Gsbh=@GSBH and (pd.Yn=@Yn5 or pd.Yn= @Yn6 or pd.Yn=@Yn7)";
            cmd.CommandText += " order by";
            cmd.CommandText += " CASE";
            cmd.CommandText += " WHEN IsDate(pd.CFMDate0) = 1 THEN CONVERT(DateTime,pd.CFMDate0,101)";
            cmd.CommandText += " ELSE null";
            cmd.CommandText += " END DESC";
            cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", pGSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Yn7", Yn7, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable SoPhieuChoToiDuyet(string IDNguoiDuyet, DateTime NgayGui)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="select COUNT(ab.pdno) from Abcon ab";  
            cmd.CommandText=" left join pdna pd on ab.pdno=pd.pdno and pd.GSBH=ab.Gsbh";
            cmd.CommandText = " where pd.CFMDate0=@CFMDate0 and ab.Auditor=@Auditor and ab.Yn=4";
            cmd.Parameters.Add(CreateParameter("Auditor", IDNguoiDuyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate0", NgayGui, SqlDbType.DateTime));
            return Select(cmd).Tables[0];
        }
        public DataTable LayTrangThaiCuaPhieuChoDuyet(string pMaPhieu,string idNguoiDuyet,string pGSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LayTrangThaiCuaPhieuChoDuyet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("pdno", pMaPhieu, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Auditor", idNguoiDuyet, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Gsbh", pGSBH, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable QryChiTietMuaHang(string gsbh,string pdno)
        {
            try
            {
                SqlCommand cmd=new SqlCommand();
                
              cmd.CommandText ="select distinct pdn.GSBH,pdn.pdNO,pdn.CLBH,pdn.Size, cl.dwbh, pdn.Qty,pdn.CLmemo,pdn.Memo0";
                cmd.CommandText +=" from pdna pd";
                cmd.CommandText +=" left join pdnaS pdn on pdn.pdNO=pd.pdno and pdn.GSBH=pd.GSBH";
                cmd.CommandText +=" left join clzl cl on pdn.CLBH=cl.cldh";
                cmd.CommandText +=" where pdn.pdNO=pd.pdno and pdn.GSBH=pd.GSBH ";
                cmd.CommandText += " and pdn.CLBH=cl.cldh and pdn.pdNO=@pdno and pdn.GSBH=@GSBH";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryTenHang()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryTenHang";
            cmd.CommandType = CommandType.StoredProcedure;
            return Select(cmd).Tables[0];

        }
       
        public int ThemHang1(string gsbh, string clbh, string pdno, string size, decimal qty, string meno0, string CLMemo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into pdnaS(GSBH,CLBH,Size,pdNO,Qty,Memo0,CLmemo)";
                cmd.CommandText += " values(@GSBH,@CLBH,@Size,@pdNO,@Qty,@Memo0,@CLmemo)";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", clbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Size", size, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Qty", qty, SqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("Memo0", meno0, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("CLmemo", CLMemo, SqlDbType.NVarChar));

            
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public int SuaHang1(string gsbh, string clbh, string pdno, string size, decimal qty, string meno0, string CLMemo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update pdnaS set Qty=@Qty,Memo0=@Memo0,CLmemo=@CLmemo ";
                cmd.CommandText += " where GSBH=@GSBH and CLBH=@CLBH and Size=@Size and pdNO=@pdNO";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", clbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Size", size, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Qty", qty, SqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("Memo0", meno0, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("CLmemo", CLMemo, SqlDbType.NVarChar));

                
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimMaHangTrongPhieu(string gsbh, string clbh, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdnaS where GSBH=@GSBH and pdNO=@pdNO and CLBH=@CLBH";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", clbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int XoaHang(string gsbh, string clbh, string pdno, string size)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete from pdnaS";
                cmd.CommandText += " where GSBH=@GSBH and CLBH=@CLBH and Size=@Size and pdNO=@pdNO";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", clbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Size", size, SqlDbType.VarChar));
                
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryHangTheoMaHang(string pdno, string gsbh)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText=  "select distinct pdn.GSBH as GSBH,pdn.pdNO as pdNO ,pdn.CLBH as CLBH,";
                //cmd.CommandText +=" pdn.Size as Size, cl.dwbh as dwbh, pdn.Qty as Qty,pdn.CLmemo as CLmemo,pdn.Memo0 as Memo0";
                //cmd.CommandText +=" from pdna pd";
                //cmd.CommandText +=" left join pdnaS pdn on pdn.pdNO=pd.pdno and pdn.GSBH=pd.GSBH";
                //cmd.CommandText +=" left join clzl cl on pdn.CLBH=cl.cldh";
                //cmd.CommandText +=" where pdn.pdNO=pd.pdno and pdn.GSBH=pd.GSBH";
                //cmd.CommandText += " and pdn.CLBH=cl.cldh and pdn.pdNO=@pdNO and pdn.GSBH=@GSBH";
                cmd.CommandText = "select distinct pdn.GSBH as GSBH,pdn.pdNO as pdNO,pdn.CGNO,pdn.ZSBH";
                   cmd.CommandText +=" ,pdn.CLBH as CLBH, pdn.Size as Size, cl.dwbh as dwbh,";
                   cmd.CommandText +=" pdn.Qty as Qty,pdn.CLmemo as CLmemo,pdn.Memo0 as Memo0"; 
                   cmd.CommandText +="  from pdnaS pd";
                   cmd.CommandText +=" left join pdnaS pdn on pdn.pdNO=pd.pdno"; 
                   cmd.CommandText +=" left join clzl cl on pdn.CLBH=cl.cldh";
                   cmd.CommandText += " where pdn.pdNO=@pdNO and pdn.GSBH=@GSBH";
                   cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                   cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DemSoLuongPhieu()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DemSoLuongPhieu";
                cmd.CommandType = CommandType.StoredProcedure;
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DemSoLuongPhieu1()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DemSoLuongPhieu1";
                cmd.CommandType = CommandType.StoredProcedure;
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayTrangDanhSachPhieuTrongKho(string GSBH, string UserID,DateTime tungay,DateTime denngay)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct pd.pdno,pd.mytitle,abcon.abtype,abi.abname,";
                cmd.CommandText += " abcon.from_depart,bd.DepName,abcon.from_user, buser.USERNAME,abyn.YnName, abc.NameABC";
                cmd.CommandText +=" from pdna pd";
                cmd.CommandText +=" left join Abcon abcon on abcon.pdno=pd.pdno and abcon.Gsbh=pd.GSBH";
                cmd.CommandText +=" left join abill abi on abcon.abtype=abi.abtype";
                cmd.CommandText +=" left join BDepartment bd on abcon.from_depart=bd.ID and abcon.Gsbh=bd.GSBH";
                cmd.CommandText +=" left join Busers2 buser on abcon.Gsbh=buser.GSBH and abcon.from_user=buser.USERID";
                cmd.CommandText +=" left join ABYn abyn on abyn.Yn=abcon.Yn";
                cmd.CommandText +=" left join aABC abc on abcon.ABC=abc.ABC";
                cmd.CommandText += " where abcon.Auditor=@Auditor and abcon.Gsbh=@GSBH and abcon.bixoa=1 ";
                cmd.CommandText += " and abcon.Userdate between @TuNgay and @DenNgay";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Auditor", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("TuNgay", tungay, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("DenNgay", denngay, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayTrangDanhSachPhieuTrongKhoTW(string GSBH, string UserID,DateTime tungay,DateTime denngay)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select distinct pd.pdno,pd.mytitle,abcon.abtype,abi.abnameTW,";
                cmd.CommandText += " abcon.from_depart,bd.DepName,abcon.from_user, buser.USERNAME,abyn.YnNameTW,abc.NameABC";
                cmd.CommandText +=" from pdna pd";
                cmd.CommandText +=" left join Abcon abcon on abcon.pdno=pd.pdno and abcon.Gsbh=pd.GSBH";
                cmd.CommandText +=" left join abill abi on abcon.abtype=abi.abtype";
                cmd.CommandText +=" left join BDepartment bd on abcon.from_depart=bd.ID and abcon.Gsbh=bd.GSBH";
                cmd.CommandText +=" left join Busers2 buser on abcon.Gsbh=buser.GSBH and abcon.from_user=buser.USERID";
                cmd.CommandText +=" left join ABYn abyn on abyn.Yn=abcon.Yn";
                cmd.CommandText +=" left join aABC abc on abcon.ABC=abc.ABC";
                cmd.CommandText += " where abcon.Auditor=@Auditor and abcon.Gsbh=@GSBH and abcon.bixoa=1";
                cmd.CommandText += " and abcon.Userdate between @TuNgay and @DenNgay";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Auditor", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("TuNgay", tungay, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("DenNgay", denngay, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuTheoNguoiTao(string GSBH, string UserID, int Yn2, int Yn3, int YnD,int Yn5, int Yn6,int Yn4,int Yn12,DateTime FromDate,DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABC ";
                // cmd.CommandText +=" from pdna pd";
                // cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                // cmd.CommandText +=" left join abill abil on abil.abtype=pd.Abtype";
                // cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                // cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                // cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                // cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                // cmd.CommandText +=" left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH"; 
                // cmd.CommandText +=" left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                // cmd.CommandText +=" where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                // cmd.CommandText += " (pd.YN=@Yn3 or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2 or pd.Yn=@Yn4 or pd.Yn=@Yn12 ) and";
                // cmd.CommandText += " (pd.CFMDate0 between @FromDate and @ToDate) order by pd.pdno asc";
                // //cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='"+Yn5+"' or pd.YN='"+Yn6+"' or tra.Yn='"+YnD+"' or abcon.Yn='"+Yn2+"' ) and";
                // //cmd.CommandText += "  and (pd.CFMDate0 between convert(varchar(10),@FromDate,112) and CONVERT(varchar(10),@ToDate ,112)";
                cmd.CommandText = "QryPhieuTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                 cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                 cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("Yn12", Yn12, SqlDbType.Int));
                 cmd.Parameters.Add(CreateParameter("FromDate", FromDate));
                 cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuTheoNguoiTaoEN(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6, int Yn4,int Yn12, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                // ABTrangThaiDuyet=TrangThaiDuyet
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCEng as NameABC ";
                cmd.CommandText += " from pdna pd";
                cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";  
                cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText += " where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                cmd.CommandText += " (pd.YN=@Yn3 or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2 or pd.Yn=@Yn4 or pd.Yn=@Yn12) and";
                cmd.CommandText += " (pd.CFMDate0 between @FromDate and @ToDate) order by pd.pdno asc";
                //cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='"+Yn5+"' or pd.YN='"+Yn6+"' or tra.Yn='"+YnD+"' or abcon.Yn='"+Yn2+"' ) and";
                //cmd.CommandText += "  and (pd.CFMDate0 between convert(varchar(10),@FromDate,112) and CONVERT(varchar(10),@ToDate ,112)";
                ///////--------------------------
                //cmd.CommandText = "QryPhieuTheoNguoiTaoEN11";
               //cmd. CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn4", Yn4, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn12", Yn12, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                //
              //  cmd.CommandType = CommandType.StoredProcedure;
               
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public DataTable QryPhieuTheoNguoiTao1(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6,int Yn4,int Yn12, string FromDate, string ToDate)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        //cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
        //        //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABC  ";
        //        //cmd.CommandText += " from pdna pd";
        //        //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
        //        //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
        //        //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
        //        //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
        //        //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
        //        //cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
        //        //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
        //        //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
        //        //cmd.CommandText += " where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
        //        //cmd.CommandText += " (pd.YN=@Yn3 or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2 ) and";
        //        //cmd.CommandText += " (pd.CFMDate0 between @FromDate and @ToDate)";
        //        //cmd.CommandText += "  (pd.CFMDate0 between convert(varchar(10), '" + FromDate + "',112) and CONVERT(varchar(10), '" + ToDate + "' ,112))";
        //        //cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='" + Yn5 + "' or pd.YN='" + Yn6 + "' or tra.Yn='" + YnD + "' or abcon.Yn='" + Yn2 + "' or pd.Yn='" + Yn4 + "' or pd.Yn='" + Yn12 + "' ) ";
        //        //cmd.CommandText += " order by pd.pdno asc";
        //        //cmd.CommandText += "  (pd.CFMDate0 between convert(varchar(10), '" + FromDate + "',112) and CONVERT(varchar(10), '" + ToDate + "' ,112))";
        //        //cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='" + Yn5 + "' or pd.YN='" + Yn6 + "' or tra.Yn='" + YnD + "' or abcon.Yn='" + Yn2 + "' or pd.Yn='" + Yn4 + "' or pd.Yn='" + Yn12 + "' ) and";

        //        cmd.CommandText = "QryPhieuTheoNguoiTao1";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.VarChar));
               
        //        cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.VarChar));
        //        cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.VarChar));
        //        return Select(cmd).Tables[0];
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public DataTable QryPhieuTheoNguoiTao1(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6, int Yn4,int Yn12, string FromDate, string ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABC  ";
                cmd.CommandText += " from pdna pd";
                cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText += " where pd.CFMID0='" + UserID + "' and pd.GSBH='" + GSBH + "' and";
                //cmd.CommandText += " (pd.YN='"+Yn3+"' or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2 ) and";
                cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='" + Yn5 + "' or pd.YN='" + Yn6 + "' or tra.Yn='" + YnD + "' or abcon.Yn='" + Yn2 + "' or pd.Yn='" + Yn4 + "' or pd.Yn='"+Yn12+"'  ) and";
                //cmd.CommandText += " (pd.CFMDate0 between @FromDate and @ToDate)";
                cmd.CommandText += "  (pd.CFMDate0 between convert(varchar(10), '" + FromDate + "',112) and CONVERT(varchar(10), '" + ToDate + "' ,112))";
                cmd.CommandText += " order by pd.pdno asc";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("bixoa", bixoa, SqlDbType.Bit));
                //cmd.Parameters.Add(CreateParameter("FromDate", FromDate,SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuTheoNguoiTaoEN(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6, int Yn4, string FromDate, string ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCEng as NameABC  ";
                cmd.CommandText += " from pdna pd";
                cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText += " where pd.CFMID0='" + UserID + "' and pd.GSBH='" + GSBH + "' and";
                cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2 ) and";
                cmd.CommandText += " (pd.CFMDate0 between @FromDate and @ToDate)";
                //cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='" + Yn5 + "' or pd.YN='" + Yn6 + "' or tra.Yn='" + YnD + "' or abcon.Yn='" + Yn2 + "' or pd.Yn='" + Yn4 + "'  ) and";
                //cmd.CommandText += "  (pd.CFMDate0 between convert(varchar(10), '" + FromDate + "',112) and CONVERT(varchar(10), '" + ToDate + "' ,112))";
                cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "QryPhieuTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.VarChar));
             
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuTheoNguoiTaoTW(string GSBH, string UserID, int Yn2, int Yn3, int YnD, int Yn5, int Yn6, int Yn4,int Yn12,DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select distinct pd.Abtype,abil.abnameTW as abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCTW as NameABC ";
                cmd.CommandText += " from pdna pd";
                cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText +=" where pd.CFMDate0 between @FromDate and @ToDate and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH ";
                //cmd.CommandText += "  (pd.YN=@Yn3 or pd.YN=@Yn5 or pd.YN=@Yn6 or tra.Yn=@YnD or abcon.Yn=@Yn2)";
                cmd.CommandText += " where pd.CFMID0='" + UserID + "' and pd.GSBH='" + GSBH + "' and";
                cmd.CommandText += " (pd.YN='" + Yn3 + "' or pd.YN='" + Yn5 + "' or pd.YN='" + Yn6 + "' or tra.Yn='" + YnD + "' or abcon.Yn='" + Yn2 + "' or pd.Yn='" + Yn4 + "' or pd.Yn='" + Yn12 + "' ) and";
                cmd.CommandText += "   (pd.CFMDate0 between convert(varchar(10),@FromDate,112) and CONVERT(varchar(10),@ToDate ,112))";
                cmd.CommandText += " order by pd.pdno asc";

                //cmd.CommandText = "QryPhieuTheoNguoiTaoTW";
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Yn2", Yn2, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn3", Yn3, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn5", Yn5, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("Yn6", Yn6, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("YnD", YnD, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable QryPhieuTrongKhoTheoNguoiTaoTW(string GSBH,string UserID,DateTime FromDate,DateTime ToDate)
        {
            try
            {
                SqlCommand cmd=new SqlCommand();

                cmd.CommandText = " select distinct pd.Abtype,abil.abnameTW, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid";
                cmd.CommandText +=" from pdna pd";
                cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText +=" left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText +=" left join Busers2 bu on bu.USERID =pd.CFMID0 and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                cmd.CommandText +=" left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText += " where pd.CFMDate0 between @FromDate and @ToDate and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.bixoa=1";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuTrongKhoTheoNguoiTao(string GSBH, string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid";
                cmd.CommandText += " from pdna pd";
                cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.CFMID0 and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText += " where pd.CFMDate0 between @FromDate and @ToDate and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.bixoa=1";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayTrangThaiDuyetTheoBangTrangThai(string GSBH, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct tra.Yn as Yn,abyn.YnName as YnName from ABTrangThaiDuyet tra";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=tra.Yn";
                //cmd.CommandText +=" where pdno=@pdno and GSBH=@GSBH and yn!=4";
                cmd.CommandText = "LayTrangThaiDuyetTheoBangTrangThai";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayTrangThaiTheoBangPDNA(string GSBH, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.YN,abyn.YnName as YnName from pdna pd";
                //cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText +=" where pd.pdno=@pdno and pd.GSBH=@GSBH ";
                cmd.CommandText = "LayTrangThaiTheoBangPDNA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayTrangThaiCuaPhieuTheoNguoiDuyet(string GSBH, string pdno,string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct abcon.YN,abyn.YnName as YnName from Abcon abcon";
                //cmd.CommandText +=" left join ABYn abyn on abyn.Yn=abcon.Yn";
                //cmd.CommandText += " where abcon.pdno=@pdno and abcon.GSBH=@GSBH and abcon.Auditor=@Auditor";
                cmd.CommandText = "LayTrangThaiCuaPhieuTheoNguoiDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Auditor", UserID, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatPhieuMuaHangDich(string gsbh, string clbh, string pdno, string size, string meno0, string CLMemo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="update pdnaS set Memo0=@Memo0,CLmemo=@CLmemo ";
                cmd.CommandText += " where GSBH=@GSBH and pdNO=@pdNO and CLBH=@CLBH and Size=@Size";
                cmd.Parameters.Add(CreateParameter("GSBH", gsbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", clbh, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Size", size, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Memo0", meno0, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("CLmemo", CLMemo, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatPhieuPDNA(string maphieu, string GSBH, int YN,int abstep,string Auditor)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = " update pdna set YN=@YN,LevelDoing=@LevelDoing,CFMID1=@CFMID1 where GSBH=@GSBH and pdno=@pdno";
                cmd.Parameters.Add(CreateParameter("pdno", maphieu, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("YN", YN, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("LevelDoing", abstep, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("CFMID1", Auditor, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        public int CapNhatLevel(string maphieu, string GSBH,  int abstep, string Auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " update pdna set LevelDoing=@LevelDoing,CFMID1=@CFMID1 where GSBH=@GSBH and pdno=@pdno";
                cmd.Parameters.Add(CreateParameter("pdno", maphieu, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("LevelDoing", abstep, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("CFMID1", Auditor, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable QryPhieuChoDich(string IDNguoiDich, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abname,pd.pdno,pd.mytitle,pd.pddepid,bd.DepName,pd.CFMID0,bus.USERNAME,pd.Yn, abyn.YnName,pd.CFMDate0, pd.isPause";
                //cmd.CommandText +=" from  pdna pd"; 
                //cmd.CommandText +=" left join abill abil on pd.Abtype=abil.abtype";
                //cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText +=" left join  Busers2 bus on pd.CFMID0=bus.USERID and pd.GSBH=bus.GSBH";
                //cmd.CommandText +=" left join BDepartment bd on pd.pddepid=bd.ID and pd.GSBH=bd.GSBH";
                //cmd.CommandText += " where pd.IdnguoiDich=@IdnguoiDich and pd.GSBH=@GSBH and trangthaidich=0 and pd.YN=3 order by pd.pdno asc";
                cmd.CommandText = "QryPhieuChoDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuChoDichEN(string IDNguoiDich, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname,pd.pdno,pd.mytitle,pd.pddepid,bd.DepName,pd.CFMID0,bus.USERNAME,pd.Yn, abyn.YnName,pd.CFMDate0,pd.isPause";
                //cmd.CommandText += " from  pdna pd";
                //cmd.CommandText += " left join abill abil on pd.Abtype=abil.abtype";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join  Busers2 bus on pd.CFMID0=bus.USERID and pd.GSBH=bus.GSBH";
                //cmd.CommandText += " left join BDepartment bd on pd.pddepid=bd.ID and pd.GSBH=bd.GSBH";
                //cmd.CommandText += " where pd.IdnguoiDich=@IdnguoiDich and pd.GSBH=@GSBH and trangthaidich=0 and pd.YN=3 order by pd.pdno asc";
                cmd.CommandText = "QryPhieuChoDichEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuTheoDieuKienCuaNguoiDich(string IDNguoiDich, string GSBH,DateTime FromDate,DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abname,pd.pdno,pd.mytitle,pd.pddepid,bd.DepName,pd.CFMID0,bus.USERNAME,pd.Yn, abyn.YnName,pd.CFMDate0, pd.isPause";
                //cmd.CommandText += " from  pdna pd";
                //cmd.CommandText += " left join abill abil on pd.Abtype=abil.abtype";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join  Busers2 bus on pd.CFMID0=bus.USERID and pd.GSBH=bus.GSBH";
                //cmd.CommandText += " left join BDepartment bd on pd.pddepid=bd.ID and pd.GSBH=bd.GSBH";
                //cmd.CommandText += " where pd.IdnguoiDich=@IdnguoiDich and pd.GSBH=@GSBH and ((trangthaidich=0 and pd.YN=3) or (trangthaidich=1 and pd.YN=6)) and pd.CFMDate0 between @CFMDate01 and @CFMDate02";
                //cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "QryPhieuTheoDieuKienCuaNguoiDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate01", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("CFMDate02", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuTheoDieuKienCuaNguoiDichEN(string IDNguoiDich, string GSBH, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname,pd.pdno,pd.mytitle,pd.pddepid,bd.DepName,pd.CFMID0,bus.USERNAME,pd.Yn, abyn.YnName,pd.CFMDate0, pd.isPause";
                //cmd.CommandText += " from  pdna pd";
                //cmd.CommandText += " left join abill abil on pd.Abtype=abil.abtype";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join  Busers2 bus on pd.CFMID0=bus.USERID and pd.GSBH=bus.GSBH";
                //cmd.CommandText += " left join BDepartment bd on pd.pddepid=bd.ID and pd.GSBH=bd.GSBH";
                //cmd.CommandText += " where pd.IdnguoiDich=@IdnguoiDich and pd.GSBH=@GSBH and ((trangthaidich=0 and pd.YN=3) or (trangthaidich=1 and pd.YN=6)) and pd.CFMDate0 between @CFMDate01 and @CFMDate02";
                //cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "QryPhieuTheoDieuKienCuaNguoiDichEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate01", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("CFMDate02", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuTrongKhoTheoNguoiDich(string GSBH, string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
                cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid";
                cmd.CommandText +=" from pdna pd";
                cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                cmd.CommandText +=" left join abill abil on abil.abtype=pd.Abtype";
                cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                cmd.CommandText +=" left join Busers2 bu on bu.USERID =pd.CFMID0 and bu.GSBH=pd.GSBH";
                cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                cmd.CommandText +=" left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                cmd.CommandText +=" where pd.CFMDate0 between @FromDate and @ToDate and";
                cmd.CommandText += " (pd.CFMID0=@CFMID0 and pd.IdnguoiDich= @CFMID0) and pd.GSBH=@GSBH and pd.bixoa=1";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("ToDate", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DemMaDatMuaHang()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " Select max(CGNO) as CGNO from CGZL where USERDate>='2014-12-01'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuDaKyDaDichTW(string GSBH, string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abil.abnameTW, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0";
                //cmd.CommandText +=" from pdna pd";
                //cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText +=" left join abill abil on abil.abtype=pd.Abtype";
                //cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                //cmd.CommandText +=" left join Busers2 bu on bu.USERID =pd.CFMID1 and bu.GSBH=pd.GSBH";
                //cmd.CommandText +=" left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText +=" left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += "  where pd.CFMDate0=@CFMDate0  and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                //cmd.CommandText += "  (pd.YN=1 or pd.YN=6 ) and pd.bixoa=0 order by pd.pdno asc";

                cmd.CommandText = "QryPhieuDaKyDaDichTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate1", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("CFMDate2", ToDate, SqlDbType.DateTime));
              
                
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuDaKyDaDich(string GSBH, string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abil.abname, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABC";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                //cmd.CommandText += "  (pd.YN=1  or pd.YN=6 and pd.trangthaidich=1) and pd.bixoa=0";
                //cmd.CommandText += " and pd.CFMDate0 between @CFMDate1 and @CFMDate2 order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaKyDaDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate1", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("CFMDate2", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaKyDaDichEN(string GSBH, string UserID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.Abtype,abil.abnameEng as abname , pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCEng as NameABC";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join ABYn abyn on abyn.Yn=pd.YN";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype";
                //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and";
                //cmd.CommandText += "  (pd.YN=1  or pd.YN=6 and pd.trangthaidich=1) and pd.bixoa=0";
                //cmd.CommandText += " and pd.CFMDate0 between @CFMDate1 and @CFMDate2 order by pd.pdno asc";
                cmd.CommandText = "QryDKPhieuTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate1", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("CFMDate2", ToDate, SqlDbType.DateTime));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDich(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,pd.IDNguoiDich as CFMID1,bu.USERNAME,pd.CFMDate0,pd.ABC,aa.NameABC ";
                //cmd.CommandText += " from pdna pd left join ABYn abyn on abyn.Yn=pd.YN ";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype ";
                //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IDNguoiDich and bu.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += " where  pd.YN=6 and pd.trangthaidich=1 and pd.bixoa=0 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDich";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDichEN(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,pd.IDNguoiDich as CFMID1,bu.USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCEng as NameABC ";
                //cmd.CommandText += " from pdna pd left join ABYn abyn on abyn.Yn=pd.YN ";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype ";
                //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IDNguoiDich and bu.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += " where  pd.YN=6 and pd.trangthaidich=1 and pd.bixoa=0 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH order by pd.pdno asc";

                cmd.CommandText = "QryPhieuDaDichEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDichTW(string GSBH, string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select distinct pd.Abtype,abil.abnameTW, pd.pdno,";
                //cmd.CommandText += " (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,pd.IDNguoiDich as CFMID1,bu.USERNAME,pd.CFMDate0 ,pd.ABC,aa.NameABCTW ";
                //cmd.CommandText += " from pdna pd left join ABYn abyn on abyn.Yn=pd.YN ";
                //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype ";
                //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IDNguoiDich and bu.GSBH=pd.GSBH ";
                //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH";
                //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh";
                //cmd.CommandText += " where  pd.YN=6 and pd.trangthaidich=1 and pd.bixoa=0 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDichTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatPhieuMHDich(string UserID,string GSBH,string pdno,string UseIntent, string subject,DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText=" update pdna set pdnsubject=@pdnsubject,";
	        cmd.CommandText +=" CFMDate2=@CFMDate2,IdnguoiDich=@IdnguoiDich,UseIntent=@UseIntent,";
            cmd.CommandText += " trangthaidich=1, Yn=6 where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("UseIntent", UseIntent, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("pdnsubject", subject, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate2", date, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDich(string UserID,string GSBH,string pdno,string subject, string NoiDungDich,DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=@pdnsubject,";
            cmd.CommandText +=" CFMDate2=@CFMDate2,IdnguoiDich=@IdnguoiDich,NoiDungDich=@NoiDungDich,";
            cmd.CommandText +=" trangthaidich=1, Yn=6 where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdnsubject", subject, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("NoiDungDich", NoiDungDich, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate2", date, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDich1(string UserID, string GSBH, string pdno, string subject, string NoiDungDich, DateTime date,int YN)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=@pdnsubject,";
            cmd.CommandText += " CFMDate2=@CFMDate2,IdnguoiDich=@IdnguoiDich,NoiDungDich=@NoiDungDich,";
            cmd.CommandText += " trangthaidich=1, Yn=@YN where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdnsubject", subject, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("NoiDungDich", NoiDungDich, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate2", date, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("YN", YN, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDichTraVe(string UserID, string GSBH, string pdno, string subject, string UseIntent, DateTime date, int YN)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=@pdnsubject,";
            cmd.CommandText += " CFMDate2=@CFMDate2,IdnguoiDich=@IdnguoiDich,UseIntent=@UseIntent,";
            cmd.CommandText += " trangthaidich=1, Yn=@YN where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdnsubject", subject, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("UseIntent", UseIntent, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate2", date, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("YN", YN, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDichPhieuCoYKien(string UserID, string GSBH, string pdno, string subject, string NoiDungDich, DateTime date,int Yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=@pdnsubject,";
            cmd.CommandText += " CFMDate2=@CFMDate2,IdnguoiDich=@IdnguoiDich,NoiDungDich=@NoiDungDich,";
            cmd.CommandText += " trangthaidich=1, Yn=@Yn where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdnsubject", subject, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("NoiDungDich", NoiDungDich, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate2", date, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("Yn", Yn, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public DataTable QryPhieuChoDichTheoNguoiDich(string GSBH, string IDNguoiDich)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select pd.pdno,pd.mytitle,pd.CFMID0,b.USERNAME, pd.CFMDate0, pd.Yn,pd.isPause";
            cmd.CommandText +=" from pdna pd ";
            cmd.CommandText += " left join Busers2 b on pd.CFMID0=b.USERID and pd.GSBH=b.GSBH";
            cmd.CommandText += " where pd.YN=3  and pd.trangthaidich=0 and pd.GSBH=@GSBH and pd.IdnguoiDich=@IdnguoiDich";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("IdnguoiDich", IDNguoiDich, SqlDbType.VarChar));
            return Select(cmd).Tables[0];

        }
        public int CapNhatTinhTrangMoiGuiCuaPhieu(string GSBH, string pdno,DateTime CFDate1)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set YN=4, CFMDate1=@CFMDate1 where pdno=@pdno and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate1", CFDate1, SqlDbType.DateTime));
            return ExecuteNonQuery(cmd);
        }
        public DataSet QryPhieuDatMuaHangNoSize(string pdno,string GSBH,string CGNO,string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
             cmd.CommandText =" select pnaS.CLBH,pnaS.Memo0,cl.dwbh,pnaS.CLmemo,isnull(cgs.yqdate,getdate()+15) as YQDate,";
             cmd.CommandText +=" cgs.Memo,zs.zsywjc,zs.dh,zs.cz,cg.CGDate,pnaS.CGNO,pnaS.GSBH,";
             cmd.CommandText +=" pnaS.ZSBH,pnaS.pdNO,pnaS.Qty";  
             cmd.CommandText +=" from  pdnaS pnaS";
             cmd.CommandText +=" left join pdna pna on pna.pdno =pnaS.pdNO and pna.GSBH=pnaS.GSBH ";
             cmd.CommandText +=" left join CGZL cg on cg.CGNO=pnaS.CGNO and cg.GSBH=pnaS.GSBH";
             cmd.CommandText +=" left join  CGZLS cgs on cg.CGNO=cgs.CGNO and cgs.GSBH=cg.GSBH  and cgs.CLBH=pnaS.CLBH";
             cmd.CommandText +=" left join  zszl zs on cg.ZSBH=zs.zsdh";
             cmd.CommandText +=" left join clzl cl on pnas.CLBH=cl.cldh ";
             cmd.CommandText += "  where pnaS.pdNO=@pdNO";
             cmd.CommandText += "  and pnaS.GSBH=@GSBH and pnaS.CGNO=@CGNO and pnaS.ZSBH=@ZSBH and pnaS.Size='ZZZZZZ'";
             cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
             cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
             cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
             cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
             return Select(cmd, "dtPhieuMuaHangNoSize");
            
        }
        public DataSet QryPhieuDatMuaHangCoSize(string pdno, string GSBH, string CGNO, string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct pnaS.CLBH,pnaS.Memo0,cl.dwbh,pnaS.CLmemo,cgs.YQDate,";
            cmd.CommandText += " cgs.Memo,zs.zsywjc,zs.dh,zs.cz,cg.CGDate,pnaS.CGNO,pnaS.GSBH,";
            cmd.CommandText += " pnaS.ZSBH,pnaS.pdNO,pnaS.Qty,pnaS.Size,pnaS.DDBH  from  pdnaS pnaS  ";
            cmd.CommandText += " left join pdna pna on pna.pdno =pnaS.pdNO and pna.GSBH=pnaS.GSBH  ";
            cmd.CommandText += " left join CGZL cg on cg.CGNO=pnaS.CGNO and cg.GSBH=pnaS.GSBH  ";
            cmd.CommandText += " left join  CGZLS cgs on cg.CGNO=cgs.CGNO and cgs.GSBH=cg.GSBH  and cgs.CLBH=pnaS.CLBH";
            cmd.CommandText += " left join  zszl zs on cg.ZSBH=zs.zsdh ";
            cmd.CommandText += " left join clzl cl on cgs.CLBH=cl.cldh  where pnaS.pdNO=@pdNO";
            cmd.CommandText += "  and pnaS.GSBH=@GSBH and pnaS.CGNO=@CGNO and pnaS.ZSBH=@ZSBH and pnaS.Size!='ZZZZZZ'";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
            return Select(cmd, "dtPhieuMuaHangCoSize");

        }
        public int ThemCGNOTrongBangCGZL(string GSBH,string CGNO,string ZSBH,string UserID)
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="insert into CGZL(GSBH,CGNO,ZSBH,CGDate,USERDate,USERID,CGLX,YN,PRLX)";
            cmd.CommandText +=" values(@GSBH,@CGNO,@ZSBH,GETDATE(),GETDATE(),@USERID,'4','1','1')";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            return ExecuteNonQuery(cmd);
            // Trong tình bạn nó càng đẹp càng cao quý bao nhiêu khi phải xa nhau thì càng buồn bấy nhiêu. 
            //Những người bạn của tôi ơi đừng có bùn nữa nhé cho dù ở xa nhau về mặt địa lý nhưng trong thâm tâm mỗi người đều nhớ về nhau.
        }
        public int CapNhatCGNOTrongBangPDNAS(string GSBH, string pdno, string CGNO, string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdnaS set CGNO='"+CGNO+"' where pdNO='"+pdno+"' and GSBH='"+GSBH+"' and ZSBH='"+ZSBH+"'";
            return ExecuteNonQuery(cmd);
        }
        public int ThemCGNOTrongBangCGZLS(string GSBH,string CGNO,string CLBH,string UserID,decimal Qty)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="insert CGZLS(GSBH,CGNO,CLBH,XqQty,Qty,USERDate,USERID,YN)";
            cmd.CommandText +="  values(@GSBH,@CGNO,@CLBH,@XqQty,@Qty,GETDATE(),@USERID,'1')";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CLBH", CLBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("XqQty", Qty, SqlDbType.Decimal));
            cmd.Parameters.Add(CreateParameter("Qty", Qty, SqlDbType.Decimal));
            
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatCGNOTrongBangCGZLS(string GSBH,string CGNO,string CLBH,string UserID,decimal Qty,DateTime UserDate,string Yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="update CGZLS set XqQty=@XqQty,Qty=@Qty,";
                cmd.CommandText +=" USERDate=@USERDate,USERID=@USERID,YN=@YN ";
                cmd.CommandText +=" where GSBH=@GSBH and CGNO=@CGNO and CLBH=@CLBH";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CLBH", CLBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Qty", Qty, SqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("XqQty", Qty, SqlDbType.Decimal));
                cmd.Parameters.Add(CreateParameter("USERDate", UserDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("Yn", Yn, SqlDbType.VarChar));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int XoaCGNOTrongBangCGZLS(string GSBH,string CGNO,string CLBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from CGZLS where GSBH=@GSBH and CGNO=@CGNO and CLBH=@CLBH";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CLBH", CLBH, SqlDbType.VarChar));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDatMuaHangVuaTaoTrongBangPDNAS(string GSBH,string pdno,string CLBH,decimal Size,string CGNO,string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdnaS set CGNO=@CGNO,ZSBH=@ZSBH  where GSBH=@GSBH and pdNO=@pdNO and CLBH=@CLBH and Size=@Size";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CLBH", CLBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Size", Size, SqlDbType.Decimal));
            cmd.Parameters.Add(CreateParameter("CGNO", CGNO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
            return ExecuteNonQuery(cmd);
        }
        public int ThemPhieuDeNghi(string GSBH,string pdno,string pddepid,string mytitle,string noidung,DateTime NgayTao,string UserID,string abtype,string CFMIDO,bool bixoa,int Yn, DateTime UserDate,int LevelDoing,int ABC)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into pdna(GSBH,pdno,pddepid,mytitle,pdmemovn,CFMDate0,USERID,Abtype,CFMID0,bixoa,YN,USERDATE,LevelDoing,ABC)";
            cmd.CommandText += "  values(@GSBH,@pdno,@pddepid,@mytitle,@pdmemovn,@CFMDate0,@USERID,@Abtype,@CFMID0,@bixoa,@YN,@USERDATE,@LevelDoing,@ABC)";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pddepid", pddepid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("mytitle", mytitle, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("pdmemovn", noidung, SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("CFMDate0", NgayTao, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("UserID", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Abtype", abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CFMID0", CFMIDO, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("bixoa", bixoa, SqlDbType.Bit));
            cmd.Parameters.Add(CreateParameter("YN", Yn, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("LevelDoing", LevelDoing, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABC", ABC, SqlDbType.Int));
            return ExecuteNonQuery(cmd);

        }
        public int ThemPhieuDeNghiTemp(string GSBH, string pdno,string UserID,DateTime UserDate,int LevelDoing,string mucDich,string Abtype,string mytitle, string pddepid,int Yn,int ABC)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into pdna(GSBH,pdno,CFMID0,USERDATE,LevelDoing,UseIntent, Abtype,mytitle,pddepid,YN,ABC) values(@GSBH,@pdno,@CFMID0,@USERDATE,@LevelDoing,@UseIntent,@Abtype,@mytitle,@pddepid,@Yn,@ABC)";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("CFMID0", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("LevelDoing", LevelDoing, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("UseIntent", mucDich,SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("Abtype", Abtype, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("mytitle", mytitle,SqlDbType.NVarChar));
            cmd.Parameters.Add(CreateParameter("pddepid", pddepid));
            cmd.Parameters.Add(CreateParameter("Yn", Yn, SqlDbType.Int));
            cmd.Parameters.Add(CreateParameter("ABC", ABC, SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuDeNghi(string GSBH, string pdno, string pddepid, string mytitle, string noidung, DateTime NgayTao, string UserID, string abtype, string CFMIDO,string mucdich, bool bixoa, int Yn, DateTime UserDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update pdna set pddepid=@pddepid,mytitle=@mytitle,pdmemovn=@pdmemovn,";
                cmd.CommandText +=" CFMDate0=@CFMDate0,USERID=@USERID,Abtype=@Abtype,CFMID0=@CFMID0,bixoa=@bixoa,";
                cmd.CommandText +=" YN=@YN,USERDATE=@USERDATE where GSBH=@GSBH and pdno=@pdno";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pddepid", pddepid, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("mytitle", mytitle, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("pdmemovn", noidung, SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("CFMDate0", NgayTao, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Abtype", abtype, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("CFMID0", CFMIDO, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("YN", Yn, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("bixoa", bixoa, SqlDbType.Bit));
                cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.DateTime));
                cmd.Parameters.Add(CreateParameter("UseIntent", mucdich, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimMaDonDatHangTheoNhaCungUngVaSoPhieuNoSize(string GSBH, string pdno, string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct pdNO,CGNO,ZSBH from pdnaS where pdNO=@pdNO and ZSBH=@ZSBH and GSBH=@GSBH and Size='ZZZZZZ'";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        public DataTable KiemTraSoPhieuNoSize(string GSBH, string pdno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct pdNO from pdnaS where pdNO='"+pdno+"'  and GSBH='"+GSBH+"' and Size='ZZZZZZ'";
            
            return Select(cmd).Tables[0];
        }
        public DataTable TimMaDonDatHangTheoNhaCungUngVaSoPhieuSize(string GSBH, string pdno, string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct pdNO,CGNO,ZSBH from pdnaS where pdNO=@pdNO and ZSBH=@ZSBH and GSBH=@GSBH and Size!='ZZZZZZ'";
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("pdNO", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("ZSBH", ZSBH, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }

        public DataTable DanhSachNhaCungUngTheoMaPhieu(string GSBH, string pdno)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select pd.ZSBH,zl.zsywjc from pdnaS pd left join zszl zl on pd.ZSBH=zl.zsdh";
                cmd.CommandText += " where pd.pdNO ='"+pdno+"' and pd.GSBH='"+GSBH+"'";
                
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatDDBHTrongBangPDNAS(string GSBH, string pdno, string DDBH,string ZSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update pdnaS set DDBH='"+DDBH+"' where pdNO='"+pdno+"' and GSBH='"+GSBH+"'and ZSBH='"+ZSBH+"'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraDDBHTrongBangDDZL(string DDBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DDBH from DDZL where DDBH='"+DDBH+"'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CapNhatPhieuPDNDich(string GSBH, string pdno, string noidung, string nguoidich,string mytitle,bool trangthai, int Yn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText="update pdna set pdmemovn=@pdmemovn,IdnguoiDich=@IdnguoiDich,Yn=@Yn,";
                cmd.CommandText +=" trangthaidich=@trangthaidich where pdno=@pdno and GSBH=@GSBH";
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdmemovn", noidung,SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("IdnguoiDich", nguoidich, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("trangthaidich", trangthai, SqlDbType.Bit));
                cmd.Parameters.Add(CreateParameter("Yn", Yn, SqlDbType.Int));
                cmd.Parameters.Add(CreateParameter("mytitle", mytitle, SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimPhieuGuiNguoiDich(string pdno,string GSBH,string CFMID0)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdna where pdno=@pdno and GSBH=@GSBH and CFMID0=@CFMID0 and trangthaidich=0 and Yn=3";
                cmd.Parameters.Add(CreateParameter("CFMID0", CFMID0, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimPhieuTheoMaPhieu(string pdno, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdna where pdno='"+pdno+"' and GSBH='"+GSBH+"'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimPhieuTheoMaNguoiDuyet(string pdno, string GSBH,string Auditor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdna pd";
                cmd.CommandText +=" left join Abcon ab on pd.pdno=ab.pdno and pd.GSBH=ab.Gsbh";
                cmd.CommandText += " where ab.pdno=@pdno and ab.GSBH=@GSBH and ab.Auditor=@Auditor";
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                cmd.Parameters.Add(CreateParameter("Auditor", Auditor));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimKiemPhieuTheoDKMaPhieuVN(string pdno, string GSBH, string idNguoiTao)
        {
            SqlCommand cmd = new SqlCommand();
             //cmd.CommandText = " select distinct pd.Abtype,abil.abname, pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,";
             //cmd.CommandText +=" pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
             //cmd.CommandText += " isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0 ,pd.ABC,aa.NameABC ";
             //cmd.CommandText +=" from pdna pd left join ABYn abyn on abyn.Yn=pd.YN ";
             //cmd.CommandText +=" left join abill abil on abil.abtype=pd.Abtype ";
             //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
             //cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
             //cmd.CommandText +=" left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
             //cmd.CommandText +=" left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
            //cmd.CommandText +=" left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
             //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
             //cmd.CommandText += " where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and  pd.pdno=@pdno";
            cmd.CommandText = "TimKiemPhieuTheoDKMaPhieuVN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("CFMID0",idNguoiTao));
            cmd.Parameters.Add(CreateParameter("GSBH",GSBH));
            cmd.Parameters.Add(CreateParameter("pdno", pdno));
             return Select(cmd).Tables[0];
        }
        public DataTable TimKiemPhieuTheoDKMaPhieuEN(string pdno, string GSBH, string idNguoiTao)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = " select distinct pd.Abtype,abil.abnameEng as abname, pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,";
            //cmd.CommandText += " pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
            //cmd.CommandText += " isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0 ,pd.ABC,aa.NameABC ";
            //cmd.CommandText += " from pdna pd left join ABYn abyn on abyn.Yn=pd.YN ";
            //cmd.CommandText += " left join abill abil on abil.abtype=pd.Abtype ";
            //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
            //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
            //cmd.CommandText += " left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
            //cmd.CommandText += " left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
            //cmd.CommandText += " left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
            //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
            //cmd.CommandText += " where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and  pd.pdno=@pdno";
            cmd.CommandText = "TimKiemPhieuTheoDKMaPhieuEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
            cmd.Parameters.Add(CreateParameter("pdno", pdno));
            return Select(cmd).Tables[0];
        }
        public DataTable TimKiemPhieuTheoDKMaPhieuTW(string pdno, string GSBH, string idNguoiTao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText = "select distinct pd.Abtype,abil.abnameTW, pd.pdno, ";
                 //cmd.CommandText +=" (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,";
                 //cmd.CommandText +=" pd.pddepid,bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                 //cmd.CommandText += " isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0,pd.ABC,aa.NameABCTW  from pdna pd ";
                 //cmd.CommandText +=" left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                 //cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                 //cmd.CommandText += " left join aABC aa on aa.ABC=pd.ABC";
                 //cmd.CommandText +=" left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                 //cmd.CommandText +=" left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                //cmd.CommandText +=" left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                 //cmd.CommandText += " left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                 //cmd.CommandText += " where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and  pd.pdno=@pdno";
                cmd.CommandText = "TimKiemPhieuTheoDKMaPhieuTW";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("CFMID0", idNguoiTao));
                 cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                 cmd.Parameters.Add(CreateParameter("pdno", pdno));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimPhieuTheoMaNguoiTao(string pdno, string GSBH, string IDNguoiTao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdna where pdno='"+pdno+"' and GSBH='"+GSBH+"' and CFMID0='"+IDNguoiTao+"'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable TimPhieuTheoMaNguoiDich(string pdno, string GSBH, string IDNguoiDich)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from pdna where pdno='" + pdno + "' and GSBH='" + GSBH + "' and IDNguoiDich='" + IDNguoiDich + "'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimKiemCLBHTrongBangPDNAS(string pdno,string GSBH,string ZSBH,string CGNO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select CLBH,Qty from pdnaS where pdNO='" + pdno + "' and GSBH='" + GSBH + "' and ZSBH='" + ZSBH + "' and CGNO='" + CGNO + "'";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable KiemTraXemDDBHDaCoTrongBangPDNAS(string pdno,string GSBH,string ZSBH,string CGNO,string DDBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select DDBH from pdnaS where pdNO='"+pdno+"' and GSBH='"+GSBH+"' and ZSBH='"+ZSBH+"' and CGNO='"+CGNO+"' and (DDBH='"+DDBH+"' or DDBH!=null)";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoAllUser(string GSBH,int ynDuyet,int YnKhongDuyet,string fromDate,string toDate )
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abname as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle, pd.ABC,ab.NameABC,";
               cmd.CommandText +="  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
               cmd.CommandText +="   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
               cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC";
               cmd.CommandText +="  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
               cmd.CommandText +="  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
               cmd.CommandText +="  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
               cmd.CommandText +="  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
               cmd.CommandText +="  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
               //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
               //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
               cmd.CommandText += "  where  pd.GSBH='"+GSBH+"' and ( pd.Yn='"+ynDuyet+"' or pd.Yn='"+YnKhongDuyet+"'   ) ";
               cmd.CommandText +="  and  (pd.CFMDate0 between convert(varchar(10), '"+fromDate+"',112) and CONVERT(varchar(10), '"+toDate+"' ,112)) order by pd.CFMID0, pd.pdno asc";
               return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoAllUserEN(string GSBH, int ynDuyet, int YnKhongDuyet, string fromDate, string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abnameEng as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.ABC,ab.NameABCEng as NameABC,";
                cmd.CommandText += "  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                cmd.CommandText += "   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
                cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC  ";
                cmd.CommandText += "  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                cmd.CommandText += "  where  pd.GSBH='" + GSBH + "' and ( pd.Yn='" + ynDuyet + "' or pd.Yn='" + YnKhongDuyet + "'   ) ";
                cmd.CommandText += "  and  (pd.CFMDate0 between convert(varchar(10), '" + fromDate + "',112) and CONVERT(varchar(10), '" + toDate + "' ,112)) order by pd.CFMID0, pd.pdno asc";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoAllUserTW(string GSBH, int ynDuyet, int YnKhongDuyet, string fromDate, string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abnameTW as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.ABC,ab.NameABCTW as NameABC,";
                cmd.CommandText += "  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                cmd.CommandText += "   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
                cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC";
                cmd.CommandText += "  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                cmd.CommandText += "  where  pd.GSBH='" + GSBH + "' and ( pd.Yn='" + ynDuyet + "' or pd.Yn='" + YnKhongDuyet + "'   ) ";
                cmd.CommandText += "  and  (pd.CFMDate0 between convert(varchar(10), '" + fromDate + "',112) and CONVERT(varchar(10), '" + toDate + "' ,112)) order by pd.CFMID0, pd.pdno asc";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoUser(string IDNguoiTao,string GSBH, int ynDuyet, int YnKhongDuyet, string fromDate, string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abname as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.ABC,ab.NameABC as NameABC,";
                cmd.CommandText += "  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                cmd.CommandText += "   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
                cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC";
                cmd.CommandText += "  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                cmd.CommandText += "  where pd.CFMID0='"+IDNguoiTao+"' and  pd.GSBH='" + GSBH + "' and ( pd.Yn='" + ynDuyet + "' or pd.Yn='" + YnKhongDuyet + "'   ) ";
                cmd.CommandText += "  and  (pd.CFMDate0 between convert(varchar(10), '" + fromDate + "',112) and CONVERT(varchar(10), '" + toDate + "' ,112)) order by pd.CFMID0, pd.pdno asc";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoUserEN(string IDNguoiTao, string GSBH, int ynDuyet, int YnKhongDuyet, string fromDate, string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abnameEng as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle,pd.ABC,ab.NameABCEng as NameABC,";
                cmd.CommandText += "  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                cmd.CommandText += "   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
                cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC";
                cmd.CommandText += "  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                cmd.CommandText += "  where pd.CFMID0='" + IDNguoiTao + "' and  pd.GSBH='" + GSBH + "' and ( pd.Yn='" + ynDuyet + "' or pd.Yn='" + YnKhongDuyet + "'   ) ";
                cmd.CommandText += "  and  (pd.CFMDate0 between convert(varchar(10), '" + fromDate + "',112) and CONVERT(varchar(10), '" + toDate + "' ,112)) order by pd.CFMID0, pd.pdno asc";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable AdminTimKiemDanhSachPhieuTheoUserTW(string IDNguoiTao, string GSBH, int ynDuyet, int YnKhongDuyet, string fromDate, string toDate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "   select distinct pd.CFMID0,b3.USERNAME as NguoiTao, pd.Abtype,abil.abnameTW as abname,";
                cmd.CommandText += "  pd.pdno, (isnull(pd.mytitle,'') +'.'+ isnull(pd.pdnsubject,'')) as  mytitle, pd.ABC,ab.NameABCTW as NameABC,";
                cmd.CommandText += "  pd.pddepid, bd.DepName,pd.Yn, abyn.YnName,pd.LevelDoing,ISNULL(pd.CFMID1,pd.IdnguoiDich)as CFMID1,";
                cmd.CommandText += "   isnull(b2.USERNAME,bu.USERNAME) as USERNAME,pd.CFMDate0  from pdna pd ";
                cmd.CommandText += " left join aABC ab on ab.ABC=pd.ABC";
                cmd.CommandText += "  left join ABYn abyn on abyn.Yn=pd.YN left join abill abil on abil.abtype=pd.Abtype ";
                cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 bu on bu.USERID =pd.IdnguoiDich and bu.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b2 on b2.USERID =pd.CFMID1 and b2.GSBH=pd.GSBH ";
                cmd.CommandText += "  left join Busers2 b3 on b3.USERID =pd.CFMID0 and b3.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join ABTrangThaiDuyet tra on tra.pdno=pd.pdno and tra.GSBH=pd.GSBH ";
                //cmd.CommandText +="  left join Abcon abcon on pd.pdno=abcon.pdno and pd.GSBH =abcon.Gsbh ";
                cmd.CommandText += "  where pd.CFMID0='" + IDNguoiTao + "' and  pd.GSBH='" + GSBH + "' and ( pd.Yn='" + ynDuyet + "' or pd.Yn='" + YnKhongDuyet + "'   ) ";
                cmd.CommandText += "  and  (pd.CFMDate0 between convert(varchar(10), '" + fromDate + "',112) and CONVERT(varchar(10), '" + toDate + "' ,112)) order by pd.CFMID0, pd.pdno asc";
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDuyetTheoNguoiTao(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abname,pd.pdno,pd.mytitle,yn.YnName,aa.NameABC,b.USERNAME,pd.pddepid,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText +="	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText +="	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText +="	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText +="	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText +="	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=8 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText +="	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDuyetTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuDaDuyetTheoNguoiTaoEN(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abnameEng as abname,pd.pdno,pd.mytitle,yn.YnName,aa.NameABCEng as NameABC,b.USERNAME,pd.pddepid,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText += "	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText += "	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText += "	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText += "	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText += "	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=8 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += "	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDuyetTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuKhongDuocDuyetTheoNguoiTao(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abname,pd.pdno,pd.mytitle,yn.YnName,aa.NameABC,b.USERNAME,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText += "	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText += "	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText += "	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText += "	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText += "	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=2 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += "	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuKhongDuocDuyetTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuKhongDuocDuyetTheoNguoiTaoEN(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abnameEng as abname,pd.pdno,pd.mytitle,yn.YnName,aa.NameABCEng as NameABC,b.USERNAME,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText += "	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText += "	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText += "	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText += "	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText += "	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=2 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += "	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuKhongDuocDuyetTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDuyetTheoNguoiTaoTW(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abnameTW,pd.pdno,pd.mytitle,yn.YnNameTW,aa.NameABCTW,b.USERNAME,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText += "	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText += "	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText += "	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText += "	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText += "	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=8 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += "	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDuyetTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuKhongDuocDuyetTheoNguoiTaoTW(string IDNGuoiTao, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select a.abtype,a.abnameTW,pd.pdno,pd.mytitle,yn.YnNameTW,aa.NameABCTW,b.USERNAME,pd.pddepid as ID,bd.DepName";
                //cmd.CommandText += "	from pdna pd left join Busers2 b on b.USERID=pd.CFMID1";
                //cmd.CommandText += "	left join BDepartment bd on pd.pddepid=bd.ID";
                //cmd.CommandText += "	left join aABC aa on pd.ABC=aa.ABC";
                //cmd.CommandText += "	left join abill a on pd.Abtype=a.abtype";
                //cmd.CommandText += "	left join ABYn yn on pd.YN=yn.Yn";
                //cmd.CommandText += "	where pd.Yn=2 and pd.CFMID0='" + IDNGuoiTao + "' and pd.GSBH='" + GSBH + "'";
                //cmd.CommandText += "	order by pd.pdno asc";
                cmd.CommandText = "QryPhieuKhongDuocDuyetTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", IDNGuoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TimCGNOTrongBangPDNAS(string GSBH,string pdno,string ZSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select ZSBH,CGNO from pdnaS where GSBH='"+GSBH+"' and pdNO='"+pdno+"' and ZSBH='"+ZSBH+"'";
            return Select(cmd).Tables[0];
        }
        public DataTable QryPhieuChuaDichTheoNguoiTao(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select Distinct pd.pdno,pd.mytitle,b.TenNguoiDich,pd.CFMDate0"; 
                //cmd.CommandText += "  from pdna pd";
                //cmd.CommandText += "  left join ABTranslator b on b.UserID=pd.IdnguoiDich";
                //cmd.CommandText += "  where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and YN=3 and trangthaidich=0 and bixoa=0 order by pd.pdno asc";
                cmd.CommandText = "QryPhieuChuaDichTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuChuaDichTheoNguoiTaoTW(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select Distinct pd.pdno,pd.mytitle,b.TenNguoiDichTiengHoa,pd.CFMDate0";
                //cmd.CommandText += "  from pdna pd";
                //cmd.CommandText += "  left join ABTranslator b on b.UserID=pd.IdnguoiDich";
                //cmd.CommandText += "  where pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and YN=3 and trangthaidich=0 and bixoa=0 order by pd.pdno asc";
                cmd.CommandText = "QryPhieuChuaDichTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryPhieuDaDichTheoNguoiTao(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText = "select distinct pd.pdno,pd.mytitle,b.TenNguoiDich,pd.CFMDate2";
                 //cmd.CommandText += " from pdna pd";
                 //cmd.CommandText += " left join ABTranslator b on pd.IdnguoiDich=b.UserID";
                 //cmd.CommandText += " where pd.GSBH=@GSBH and pd.CFMID0=@CFMID0 ";
                 //cmd.CommandText += " and pd.YN=6 and pd.bixoa=0 and pd.dagui=0 and pd.trangthaidich=1";
                 //cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "QryPhieuDaDichTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                 cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryPhieuDaDichTheoNguoiTaoTW(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select distinct pd.pdno,pd.mytitle,b.TenNguoiDichTiengHoa,pd.CFMDate2";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join ABTranslator b on pd.IdnguoiDich=b.UserID";
                //cmd.CommandText += " where pd.GSBH=@GSBH and pd.CFMID0=@CFMID0 ";
                //cmd.CommandText += " and pd.YN=6 and pd.bixoa=0 and pd.dagui=0 and pd.trangthaidich=1";
                //cmd.CommandText += " order by pd.pdno asc";

                cmd.CommandText = "QryPhieuDaDichTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuDaGuiBiHuyTheoNguoiTao(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abname,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText +="  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText +="  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText +="  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=7 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuDaGuiBiHuyTheoNguoiTaoP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachPhieuDaGuiBiHuyTheoNguoiTaoEN(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abnameEng as abname,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += "  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=7 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuDaGuiBiHuyTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuDaGuiBiHuyTheoNguoiTaoTW(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abnameTW,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += "  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=7 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuDaGuiBiHuyTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuMoiKhoiTaoTheoNguoiTaoTW(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abnameTW,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += "  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=5 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuMoiKhoiTaoTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuMoiKhoiTaoTheoNguoiTaoEN(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abnameEng as abname,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += "  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=5 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuMoiKhoiTaoTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuMoiKhoiTaoTheoNguoiTao(string manguoitao, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "  select distinct a.abtype,a.abname,pd.pdno,pd.mytitle,b.USERNAME,bd.ID,bd.DepName  from pdna pd ";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += "  left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += "  where  pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH and pd.YN=5 order by pd.pdno asc;";
                cmd.CommandText = "DanhSachPhieuMoiKhoiTaoTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoitao));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachVanBanDaGuiTheoNguoiGui(string manguoigui, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
               // cmd.CommandText = "select DISTINCT a.abname,pd.pdno,pd.mytitle,abc.NameABC,b.USERNAME,bd.DepName"; 
               //cmd.CommandText +=" from pdna pd"; 
               //cmd.CommandText +=" left join abill a on a.abtype=pd.Abtype";
               //cmd.CommandText +=" left join ABYn ab on ab.Yn=pd.YN";
               //cmd.CommandText +=" left join aABC abc on abc.ABC=pd.ABC";
               //cmd.CommandText +=" left join  Busers2 b on b.USERID=pd.CFMID0";
               //cmd.CommandText +=" left join BDepartment bd on bd.ID=pd.pddepid";
               //cmd.CommandText += " where pd.dagui=1 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
               //cmd.CommandText +=" order by pd.pdno asc";
                cmd.CommandText = "DanhSachVanBanDaGuiTheoNguoiGui";
                cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
               cmd.Parameters.Add(CreateParameter("GSBH", macongty));
               return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachVanBanDaGuiTheoNguoiGuiEN(string manguoigui, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select DISTINCT a.abnameEng as abname,pd.pdno,pd.mytitle,abc.NameABCEng as NameABC,b.USERNAME,bd.DepName";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += " left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += " left join aABC abc on abc.ABC=pd.ABC";
                //cmd.CommandText += " left join  Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += " where pd.dagui=1 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "DanhSachVanBanDaGuiTheoNguoiGuiEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachVanBanDaGuiTheoNguoiGuiTW(string manguoigui, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select DISTINCT a.abnameTW,pd.pdno,pd.mytitle,abc.NameABCTW,b.USERNAME,bd.DepName";
                //cmd.CommandText += " from pdna pd";
                //cmd.CommandText += " left join abill a on a.abtype=pd.Abtype";
                //cmd.CommandText += " left join ABYn ab on ab.Yn=pd.YN";
                //cmd.CommandText += " left join aABC abc on abc.ABC=pd.ABC";
                //cmd.CommandText += " left join  Busers2 b on b.USERID=pd.CFMID0";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=pd.pddepid";
                //cmd.CommandText += " where pd.dagui=1 and pd.CFMID0=@CFMID0 and pd.GSBH=@GSBH";
                //cmd.CommandText += " order by pd.pdno asc";
                cmd.CommandText = "DanhSachVanBanDaGuiTheoNguoiGuiTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
                cmd.Parameters.Add(CreateParameter("GSBH", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryVanBanDaKyTheoCapDuyet(string manguoiduyet,string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText="select Distinct a.abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABC,b.USERNAME,bd.DepName, abcon.from_depart"; 
                 //cmd.CommandText +="  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +="  left join ABYn ab on ab.Yn=abcon.Yn ";
                 //cmd.CommandText +="  left join abill a on a.abtype= abcon.abtype";
                 //cmd.CommandText +="  left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                 //cmd.CommandText +="  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +="  left join aABC abc on abc.ABC=abcon.ABC";
                 //cmd.CommandText += "  where abcon.Yn=1 and abrult=1 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "QryVanBanDaKyTheoCapDuyet";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                 cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryVanBanDaKyTheoCapDuyetEN(string manguoiduyet, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select Distinct a.abnameEng as abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCEng as NameABC,b.USERNAME,bd.DepName, abcon.from_depart";
                //cmd.CommandText += "  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=abcon.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += "  where abcon.Yn=1 and abrult=1 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "QryVanBanDaKyTheoCapDuyetEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable QryVanBanDaKyTheoCapDuyetTW(string manguoiduyet, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select Distinct a.abnameTW,pd.pdno,pd.mytitle,ab.YnNameTW,abc.NameABCTW,b.USERNAME,bd.DepName, abcon.from_depart";
                //cmd.CommandText += "  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=abcon.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += "  where abcon.Yn=1 and abrult=1 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "QryVanBanDaKyTheoCapDuyetTW";
              cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyet(string manguoiduyet, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText=" select  Distinct a.abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABC,b.USERNAME,bd.DepName,a.abtype,bd.ID";
                 //cmd.CommandText +=" from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +=" left join ABYn ab on ab.Yn=abcon.Yn"; 
                 //cmd.CommandText +=" left join abill a on a.abtype= abcon.abtype";
                 //cmd.CommandText +=" left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                 //cmd.CommandText +=" left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +=" left join aABC abc on abc.ABC=abcon.ABC";
                 //cmd.CommandText += " where abcon.Yn=2 and abrult=0 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyet";
              cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                 cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyetEN(string manguoiduyet, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select  Distinct a.abnameEng as abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCEng as NameABC,b.USERNAME,bd.DepName,a.abtype,bd.ID";
                //cmd.CommandText += " from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += " left join ABYn ab on ab.Yn=abcon.Yn";
                //cmd.CommandText += " left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += " left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += " left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += " where abcon.Yn=2 and abrult=0 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyetEN";
              cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyetTW(string manguoiduyet, string macongty)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = " select  Distinct a.abnameTW,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCTW,b.USERNAME,bd.DepName,a.abtype,bd.ID";
                //cmd.CommandText += " from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += " left join ABYn ab on ab.Yn=abcon.Yn";
                //cmd.CommandText += " left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += " left join Busers2 b on b.USERID=abcon.from_user and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += " left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += " left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += " where abcon.Yn=2 and abrult=0 and abcon.Auditor=@Auditor and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyetTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("Auditor", manguoiduyet));
                cmd.Parameters.Add(CreateParameter("Gsbh", macongty));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayTinhTrangVanBanTheoNguoiGui(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText = "select Distinct a.abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABC,b.USERNAME,bd.DepName"; 
                 //cmd.CommandText +="  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +="  left join ABYn ab on ab.Yn=abcon.Yn ";
                 //cmd.CommandText +="  left join abill a on a.abtype= abcon.abtype";
                 //cmd.CommandText +="  left join Busers2 b on b.USERID=abcon.Auditor and b.GSBH= abcon.Gsbh";
                 //cmd.CommandText +="  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                 //cmd.CommandText +="  left join aABC abc on abc.ABC=abcon.ABC";
                 //cmd.CommandText += "  where  abcon.from_user=@from_user and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "LayTinhTrangVanBanTheoNguoiGui";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("from_user", manguoigui));
                 cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayTinhTrangVanBanTheoNguoiGuiEN(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select Distinct a.abnameEng as abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCEng as NameABC,b.USERNAME,bd.DepName";
                //cmd.CommandText += "  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=abcon.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=abcon.Auditor and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += "  where  abcon.from_user=@from_user and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "LayTinhTrangVanBanTheoNguoiGuiEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("from_user", manguoigui));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayTinhTrangVanBanTheoNguoiGuiTW(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select Distinct a.abnameTW,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCTW,b.USERNAME,bd.DepName";
                //cmd.CommandText += "  from Abcon abcon left join pdna pd on pd.pdno =abcon.pdno and pd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=abcon.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= abcon.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=abcon.Auditor and b.GSBH= abcon.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=abcon.from_depart and bd.GSBH=abcon.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=abcon.ABC";
                //cmd.CommandText += "  where  abcon.from_user=@from_user and abcon.Gsbh=@Gsbh";
                cmd.CommandText = "LayTinhTrangVanBanTheoNguoiGuiTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("from_user", manguoigui));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuKhongDuyetTheoNguoiTao(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                 //cmd.CommandText = "select   DISTINCT  a.abtype,a.abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABC,b.USERNAME,bd.ID,bd.DepName"; 
                 //cmd.CommandText +="  from  pdna pd";
                 //cmd.CommandText +="  left join ABYn ab on ab.Yn=pd.Yn ";
                 //cmd.CommandText +="  left join abill a on a.abtype= pd.abtype";
                 //cmd.CommandText +="  left join Busers2 b on b.USERID=pd.CFMID1 and b.GSBH= pd.Gsbh";
                 //cmd.CommandText +="  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.Gsbh";
                 //cmd.CommandText += "  left join aABC abc on abc.ABC=pd.ABC";
                 //cmd.CommandText += "  where pd.Yn=2  and pd.CFMID0=@CFMID0 and pd.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachPhieuKhongDuyetTheoNguoiTao";
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
                 cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                 return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable DanhSachPhieuKhongDuyetTheoNguoiTaoEN(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select   DISTINCT  a.abtype,a.abnameEng as abname,pd.pdno,pd.mytitle,ab.YnName,abc.NameABCEng as NameABC,b.USERNAME,bd.ID,bd.DepName";
                //cmd.CommandText += "  from  pdna pd";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= pd.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID1 and b.GSBH= pd.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=pd.ABC";
                //cmd.CommandText += "  where pd.Yn=2  and pd.CFMID0=@CFMID0 and pd.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachPhieuKhongDuyetTheoNguoiTaoEN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable DanhSachPhieuKhongDuyetTheoNguoiTaoTW(string manguoigui, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select   DISTINCT  a.abtype,a.abnameTW,pd.pdno,pd.mytitle,ab.YnNameTW,abc.NameABCTW,b.USERNAME,bd.ID,bd.DepName";
                //cmd.CommandText += "  from  pdna pd";
                //cmd.CommandText += "  left join ABYn ab on ab.Yn=pd.Yn ";
                //cmd.CommandText += "  left join abill a on a.abtype= pd.abtype";
                //cmd.CommandText += "  left join Busers2 b on b.USERID=pd.CFMID1 and b.GSBH= pd.Gsbh";
                //cmd.CommandText += "  left join BDepartment bd on bd.ID=pd.pddepid and bd.GSBH=pd.Gsbh";
                //cmd.CommandText += "  left join aABC abc on abc.ABC=pd.ABC";
                //cmd.CommandText += "  where pd.Yn=2  and pd.CFMID0=@CFMID0 and pd.Gsbh=@Gsbh";
                cmd.CommandText = "DanhSachPhieuKhongDuyetTheoNguoiTaoTW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", manguoigui));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatPhanHoiCuaNguoiDuyetTheoPhieu(string maphieu, string gsbh, string comment,string Auditor,int Yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdmemovn1=N'" + comment + "', YN='" + Yn + "',CFMID1='"+Auditor+"' where pdno='" + maphieu + "' and GSBH='" + gsbh + "'";
            return ExecuteNonQuery(cmd);
        }
        public DataTable QryPhieuChuaDuyetCoYKien(string maNguoiTao,string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "select pdn.pdno,pdn.mytitle,pdn.pdmemovn,pdn.pdmemovn1,pdn.CFMDate0,pdn.CFMID1,B.USERNAME,pdn.LevelDoing,pdn.Abtype";
                //cmd.CommandText += " from pdna pdn left join Busers2 B on pdn.CFMID1=B.USERID where pdn.CFMID0=@CFMID0 and pdn.GSBH=@GSBH and pdn.YN='12'";
                cmd.CommandText = "QryPhieuChuaDuyetCoYKien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("CFMID0", maNguoiTao));
                cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable LayThongTinPhieuCoYKien(string maNguoiTao, string GSBH,string maPhieu)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = " select pdn.pdno,pdn.mytitle,pdn.pdnsubject,pdn.Abtype,";
            // cmd.CommandText +=" (ab.abname+' '+ab.abnameTW)as abname, pdn.CFMDate0,pdn.CFMID1,";
            // cmd.CommandText += " B.USERNAME,pdn.pdmemovn,pdn.NoiDungDich, pdn.pdmemovn1,bd.ID,bd.DepName from pdna pdn ";
            // cmd.CommandText +=" left join BDepartment bd on bd.ID=pdn.pddepid";
            // cmd.CommandText +=" left join abill ab on ab.abtype=pdn.Abtype ";
            // cmd.CommandText +=" left join Busers2 B on B.USERID=pdn.CFMID1";
            // cmd.CommandText += " where pdn.pdno=@pdno and pdn.CFMID0=@CFMID0 and pdn.GSBH=@GSBH";
            cmd.CommandText = "LayThongTinPhieuCoYKien";
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add(CreateParameter("pdno", maPhieu));
             cmd.Parameters.Add(CreateParameter("CFMID0", maNguoiTao));
             cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
             return Select(cmd).Tables[0];
        }
        public DataTable LayThongTinPhieuCoYKien1(string maNguoiTao, string GSBH, string maPhieu)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = " select pdn.pdno,pdn.mytitle,pdn.pdnsubject,pdn.Abtype,";
            //cmd.CommandText += " (ab.abname+' '+ab.abnameTW)as abname, pdn.CFMDate0,pdn.CFMID1,";
            //cmd.CommandText += " B.USERNAME,pdn.pdmemovn,pdn.NoiDungDich, pdn.pdmemovn1,bd.ID,bd.DepName,pdn.UseIntent from pdna pdn ";
            //cmd.CommandText += " left join BDepartment bd on bd.ID=pdn.pddepid";
            //cmd.CommandText += " left join abill ab on ab.abtype=pdn.Abtype ";
            //cmd.CommandText += " left join Busers2 B on B.USERID=pdn.CFMID1";
            //cmd.CommandText += " where pdn.pdno=@pdno and pdn.CFMID0=@CFMID0 and pdn.GSBH=@GSBH";
            cmd.CommandText = "LayThongTinPhieuCoYKien1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(CreateParameter("pdno", maPhieu));
            cmd.Parameters.Add(CreateParameter("CFMID0", maNguoiTao));
            cmd.Parameters.Add(CreateParameter("GSBH", GSBH));
            return Select(cmd).Tables[0];
        }
        public int CapNhatPhieuCoYKienToiNguoiDuyet(string tieuDeTW,string tieuDeVN,string pNoiDung,string pNoiDungDich,string pMaPhieu,string pNguoiTao,string GSBH,int Yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=N'"+tieuDeTW+"',mytitle=N'"+tieuDeVN+"', pdmemovn=N'"+pNoiDung+"', NoiDungDich=N'"+pNoiDungDich+"', YN='"+Yn+"' where pdno='"+pMaPhieu+"' and GSBH='"+GSBH+"' and CFMID0='"+pNguoiTao+"'";
            return ExecuteNonQuery(cmd);         
        }
        public int CapNhatPhieuCoYKienToiNguoiDuyet1(string tieuDeTW, string tieuDeVN, string pMaPhieu, string pNguoiTao, string GSBH, int Yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=N'" + tieuDeTW + "',mytitle=N'" + tieuDeVN + "', YN='" + Yn + "' where pdno='" + pMaPhieu + "' and GSBH='" + GSBH + "' and CFMID0='" + pNguoiTao + "'";
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatPhieuCoYKienToiNguoiDuyet2(string tieuDeTW, string tieuDeVN, string pMaPhieu, string pNguoiTao, string GSBH,string UseIntent, int Yn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update pdna set pdnsubject=N'" + tieuDeTW + "',mytitle=N'" + tieuDeVN + "', YN='" + Yn + "',UseIntent=N'"+UseIntent+"' where pdno='" + pMaPhieu + "' and GSBH='" + GSBH + "' and CFMID0='" + pNguoiTao + "'";
            return ExecuteNonQuery(cmd);
        }
        public int CapNhatNguoiDichNHungPhieuCoYKien(string IDNguoiDich,string myTitle,string pdnsubject,string UseInten, string pdno,string GSBH,int Yn,bool isPause)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update pdna set trangthaidich=0, IdnguoiDich='" + IDNguoiDich + "', mytitle=N'" + myTitle + "',pdnsubject=N'" + pdnsubject + "', UseIntent=N'" + UseInten + "',Yn='" + Yn + "',isPause=@isPause where pdno='" + pdno + "' and GSBH='" + GSBH + "' ";
                cmd.Parameters.Add(CreateParameter("isPause", isPause, SqlDbType.Bit));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CapNhatNguoiDichNHungPhieuCoYKien1(string IDNguoiDich, string myTitle, string pdnsubject, string pdno, string GSBH,int Yn,bool isPause)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update pdna set trangthaidich=0, IdnguoiDich='" + IDNguoiDich + "', mytitle=N'" + myTitle + "',pdnsubject=N'" + pdnsubject + "',Yn='"+Yn+"',isPause=@isPause where pdno='" + pdno + "' and GSBH='" + GSBH + "' ";
                cmd.Parameters.Add(CreateParameter("isPause", isPause, SqlDbType.Bit));
                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ThemFileDinhKemPhieuDeNghi(string pdno, string GSBH, string fileName, string filePath)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " insert PDNLink(pdno,Gsbh,[Filename],FilePath) values(@pdno,@Gsbh,@Filename,@FilePath)";
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                cmd.Parameters.Add(CreateParameter("Filename",fileName,SqlDbType.NVarChar));
                cmd.Parameters.Add(CreateParameter("FilePath",filePath,SqlDbType.NVarChar));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int DeleteFileDinhKemPhieuDeNghi(string pdno, string GSBH, int ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete PDNLink where Gsbh=@Gsbh and pdno=@pdno and ID=@ID";
                cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                cmd.Parameters.Add(CreateParameter("ID", ID, SqlDbType.Int));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable QryFileDinhKemPhieuDeNghi(string pdno, string GSBH)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from PDNLink where pdno=@pdno and Gsbh=@Gsbh";
            cmd.Parameters.Add(CreateParameter("pdno", pdno, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
            return Select(cmd).Tables[0];
        }
       
    }
