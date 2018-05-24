using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using  System.Data.SqlClient;


namespace iOffice.presentationLayer
{
    public class Stem8SDAL:ClassGenera
    {
        ClassGenera dal = new ClassGenera();
         public DataTable QryPhieutem8SVN(string IDStem)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snamevn as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamech, S8.Snameen,S8.Snamevn";
            cmd.CommandText +="  from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp where S8.Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemtp", IDStem, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         
         }
         public DataTable QryPhieutem8SVNAll()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snamevn as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamech, S8.Snameen,S8.Snamevn";
             cmd.CommandText += "  from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp ";
             cmd.CommandText += " order by S8T.Sitemtp,S8.Sitemno asc";
             return Select(cmd).Tables[0];

         }
         public DataTable QryPhieutem8STW(string IDStem)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snamech as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamevn, S8.Snameen,S8.Snamech";
             cmd.CommandText +=" from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp where S8.Sitemtp=@Sitemtp";

             cmd.Parameters.Add(Para("Sitemtp", IDStem, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable QryPhieutem8STWAll()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snamech as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamevn, S8.Snameen,S8.Snamech";
             cmd.CommandText += " from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp";

             cmd.CommandText += " order by S8T.Sitemtp,S8.Sitemno asc";
             return Select(cmd).Tables[0];

         }
         public DataTable LayTongPhanTram()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select Sum(S8.Sitemscore) as Sitemscore from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp ";
             return Select(cmd).Tables[0];
         }
         public DataTable LayTongPhanTramTheoID(string Sitemtp)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select Sum(S8.Sitemscore) as Sitemscore";
            cmd.CommandText +=" from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp ";
            cmd.CommandText +=" where S8.Sitemtp=@Sitemtp ";
            cmd.Parameters.Add(Para("Sitemtp", Sitemtp, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieutem8SEN(string IDStem)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snameen as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamech, S8.Snamevn,S8.Snameen";
             cmd.CommandText +="  from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp where S8.Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemtp", IDStem, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable QryPhieutem8SENAll()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8.Sitemno,S8.Sitemscore,S8.Snameen as Snamevnn,S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8.Snamech, S8.Snamevn,S8.Snameen";
             cmd.CommandText += "  from S8item S8 left join  S8type S8T on S8.Sitemtp=S8T.Sitemtp ";
             cmd.CommandText += " order by S8T.Sitemtp,S8.Sitemno asc";
             return Select(cmd).Tables[0];

         }
         public DataTable QryPhieutem8SLenDrop(string IDStem)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select * from S8item  where Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemtp",IDStem,SqlDbType.NVarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable QryPhieutem8SLenDrop1()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select * from S8item  ";
            
             return Select(cmd).Tables[0];

         }
         public DataTable LayStem8STheoID(string ID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select * from S8item where Sitemno=@Sitemno";
             cmd.Parameters.Add(Para("Sitemno", ID, SqlDbType.NVarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable LayStypeVN()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select * from S8type ";
             return Select(cmd).Tables[0];
         }
         public DataTable LayStypeVNTheoID(string Sitemtp)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct * from S8type where Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemtp", Sitemtp, SqlDbType.NVarChar));
           
             return Select(cmd).Tables[0];
         }
         public DataTable LayStypeVN1(string Sitemtp, string Sitemtp1)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct * from S8type where Sitemtp=@Sitemtp or Sitemtp=@Sitemtp1";
             cmd.Parameters.Add(Para("Sitemtp", Sitemtp, SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("Sitemtp1", Sitemtp1, SqlDbType.NVarChar));
             return Select(cmd).Tables[0];
         }
         public int ThemStemt8S(string Sitemno, string Sitemtp, string Snamevn, string Snamech, string Snameen, int Sitemscore)
         {
              SqlCommand cmd = new SqlCommand();
              cmd.CommandText = "insert into S8item(Sitemno,Sitemtp,Snamech,Snameen,Snamevn,Sitemscore) values(@Sitemno,@Sitemtp,@Snamech,@Snameen,@Snamevn,@Sitemscore)";
              cmd.Parameters.Add(Para("Sitemno",Sitemno,SqlDbType.VarChar));
              cmd.Parameters.Add(Para("Sitemtp",Sitemtp,SqlDbType.NVarChar));
              cmd.Parameters.Add(Para("Snamech",Snamech,SqlDbType.NVarChar));
              cmd.Parameters.Add(Para("Snameen",Snameen,SqlDbType.NVarChar));
              cmd.Parameters.Add(Para("Snamevn", Snamevn, SqlDbType.NVarChar));
              cmd.Parameters.Add(Para("Sitemscore", Sitemscore, SqlDbType.Int));
              return ExecuteNonQuery(cmd);
         }
         public int SuaStem8S(string Sitemno, string Sitemtp, string Snamevn, string Snamech, string Snameen, int Sitemscore)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "update S8item set Snamech=@Snamech,Snameen=@Snameen,Snamevn=@Snamevn,Sitemscore=@Sitemscore where Sitemno=@Sitemno and Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("Sitemtp", Sitemtp, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("Snamech", Snamech, SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("Snameen", Snameen, SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("Snamevn", Snamevn, SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("Sitemscore", Sitemscore, SqlDbType.Int));
             return ExecuteNonQuery(cmd);
         }
         public int XoaStem8S(string Sitemno, string Sitemtp)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "delete S8item where  Sitemno=@Sitemno and Sitemtp=@Sitemtp";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("Sitemtp", Sitemtp, SqlDbType.VarChar));
             return ExecuteNonQuery(cmd);
         }
         public DataTable QryPhieu8TheoDieuKienVN(string Sitemno,DateTime FromDate, DateTime ToDate,string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where (S8R.Sitemno = @Sitemno and  S8R.S8date between @FromDate and @ToDate) or (S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate)";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienVN1( DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8SauKhiCopy_VN(DateTime S8date, string DepartmentID,string GSBH)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date=@S8date and S8R.GSBH=@GSBH";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienVN1_CR(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S6'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienVN1_NS(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienVN1_TKTH(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp<>'S6' and S8T.Sitemtp<>'S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable Qry8SCoDiemThapHonDiemChuanVN(DateTime FromDate, DateTime ToDate, string DepartmentID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,";
                cmd.CommandText +="  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                cmd.CommandText +="  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                cmd.CommandText +="  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                cmd.CommandText +="  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                cmd.CommandText += "  where S8R.depid=@depid and  S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                cmd.CommandText +="  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
                return Select(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
         public DataTable Qry8SCoDiemThapHonDiemChuanCH(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QCmemo as QCmemo,";
                 cmd.CommandText += "  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                 cmd.CommandText += "  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                 cmd.CommandText += "  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                 cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                 cmd.CommandText += "  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                 cmd.CommandText += "  where S8R.depid=@depid and  S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                 cmd.CommandText += "  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
                 return Select(cmd).Tables[0];
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }
         public DataTable Qry8SCoDiemThapHonDiemChuanEN(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QCmemo as QCmemo,";
                 cmd.CommandText += "  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                 cmd.CommandText += "  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                 cmd.CommandText += "  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                 cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                 cmd.CommandText += "  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                 cmd.CommandText += "  where S8R.depid=@depid and  S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                 cmd.CommandText += "  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
                 return Select(cmd).Tables[0];
             }
             catch (Exception)
             {

                 throw;
             }
         }
        ////
         public DataTable Qry8SCoDiemThapHonDiemChuanVNAll(DateTime FromDate, DateTime ToDate)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,";
                 cmd.CommandText += "  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                 cmd.CommandText += "  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                 cmd.CommandText += "  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                 cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                 cmd.CommandText += "  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                 cmd.CommandText += "  where S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                 cmd.CommandText += "  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             
                 return Select(cmd).Tables[0];
             }
             catch (Exception)
             {

                 throw;
             }
         }
         public DataTable Qry8SCoDiemThapHonDiemChuanCHAll(DateTime FromDate, DateTime ToDate)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QCmemo as QCmemo,";
                 cmd.CommandText += "  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                 cmd.CommandText += "  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                 cmd.CommandText += "  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                 cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                 cmd.CommandText += "  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                 cmd.CommandText += "  where S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                 cmd.CommandText += "  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                
                 return Select(cmd).Tables[0];
             }
             catch (Exception)
             {

                 throw;
             }
         }
         public DataTable Qry8SCoDiemThapHonDiemChuanENAll(DateTime FromDate, DateTime ToDate)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QCmemo as QCmemo,";
                 cmd.CommandText += "  S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, ";
                 cmd.CommandText += "  S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
                 cmd.CommandText += "  left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                 cmd.CommandText += "  left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
                 cmd.CommandText += "  left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                 cmd.CommandText += "  where  S8R.S8date  between @FromDate and @ToDate and S8R.sub_score<S8I.Sitemscore";
                 cmd.CommandText += "  order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
               
                 return Select(cmd).Tables[0];
             }
             catch (Exception)
             {

                 throw;
             }
         }
        //
         public DataSet QryDiem8STheoDonVi(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             try
             {
                 string str="";
                 #region ST
                    str+="    select  (Sum(case when S8I.Sitemno='S1001' and S8I.Sitemscore='3' then S8R.sub_score else 0 end))as S1001,";
                    str+="    (Sum(case when S8I.Sitemno='S1002' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S1002,";
                    str+="    (sum(case when S8I.Sitemno='S1003' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S1003,";
                    str+="    (sum(case when S8I.Sitemno='S1004' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S1004,";
                    str+="    (sum(case when S8I.Sitemno='S1005' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S1005,";
                    str+="    (sum(case when S8I.Sitemno='S2001' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S2001,";
                    str+="    (sum(case when S8I.Sitemno='S2002' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S2002,";
                    str+="    (sum(case when S8I.Sitemno='S2003' and S8I.Sitemscore='4' then S8R.sub_score else 0 end))as S2003,";
                    str+="    (sum(case when S8I.Sitemno='S2004' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S2004,";
                    str+="    (sum(case when S8I.Sitemno='S2005' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S2005,";
                    str+="    (sum(case when S8I.Sitemno='S2006' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S2006,";
                    str+="    (sum(case when S8I.Sitemno='S3001' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S3001,";
                    str+="    (sum(case when S8I.Sitemno='S3002' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S3002,";
                    str+="    (sum(case when S8I.Sitemno='S3003' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S3003,";
                    str+="    (sum(case when S8I.Sitemno='S3004' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S3004,";
                    str+="    (sum(case when S8I.Sitemno='S3005' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S3005,";
                    str+="    (sum(case when S8I.Sitemno='S3006' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S3006,";
                    str+="    (sum(case when S8I.Sitemno='S3007' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S3007,";
                    str+="    (sum(case when S8I.Sitemno='S4001' and S8I.Sitemscore='4' then S8R.sub_score else 0 end))as S4001,";
                    str+="    (sum(case when S8I.Sitemno='S4002' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S4002,";
                    str+="    (sum(case when S8I.Sitemno='S4003' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S4003,";
                    str+="    (sum(case when S8I.Sitemno='S4004' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S4004,";
                    str+="    (sum(case when S8I.Sitemno='S5001' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S5001,";
                    str+="    (sum(case when S8I.Sitemno='S5002' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S5002,";
                    str+="    (sum(case when S8I.Sitemno='S5003' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S5003,";
                    str+="    (sum(case when S8I.Sitemno='S6001' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S6001,";
                    str+="    (sum(case when S8I.Sitemno='S6002' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S6002,";
                    str+="    (sum(case when S8I.Sitemno='S6003' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S6003,";
                    str+="    (sum(case when S8I.Sitemno='S6004' and S8I.Sitemscore='5' then S8R.sub_score else 0 end))as S6004,";
                    str+="    (sum(case when S8I.Sitemno='S6005' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S6005,";
                    str+="    (sum(case when S8I.Sitemno='S6006' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S6006,";
                    str+="    (sum(case when S8I.Sitemno='S7001' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S7001,";
                    str+="    (sum(case when S8I.Sitemno='S7002' and S8I.Sitemscore='4' then S8R.sub_score else 0 end))as S7002,";
                    str+="    (sum(case when S8I.Sitemno='S7003' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S7003,";
                    str+="    (sum(case when S8I.Sitemno='S7004' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S7004,";
                    str+="    (sum(case when S8I.Sitemno='S7005' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S7005,";
                    str+="    (sum(case when S8I.Sitemno='S8001' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S8001,";
                    str+="    (sum(case when S8I.Sitemno='S8002' and S8I.Sitemscore='2' then S8R.sub_score else 0 end))as S8002,";
                    str+="    (sum(case when S8I.Sitemno='S8003' and S8I.Sitemscore='1' then S8R.sub_score else 0 end))as S8003,";
                    str += "    S8R.depid,BD.DepName as DV_TEN,BD.DepName as TENDV_TAIWAN";
                    str+="    from  S8rec S8R";
                    str+="    left join S8item S8I on S8I.Sitemno=S8R.Sitemno";
                    str += "    left join bdepartment BD on S8R.depid=BD.ID";
                    str+="    left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
                    str+="    where S8R.depid=@depid ";
                    str+="    and S8R.S8date between @FromDate and @ToDate";
                    str += "    group by S8R.depid,BD.DepName ";
                #endregion 
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = str;
                 cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                 cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
                 return Select(cmd, "DataTable8S");
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }
         public DataSet LayItem8SVN()
         {
             string str = "";
             SqlCommand cmd=new SqlCommand();
             #region aaa
                 str+="     select max(case when S8I.Sitemno='S1001'  then S8I.Snamevn else '' end)as vS1001,";
                 str+="    max(case when S8I.Sitemno='S1002'  then S8I.Snamevn else ''  end)as vS1002,";
                 str+="    max(case when S8I.Sitemno='S1003'  then S8I.Snamevn else ''  end)as vS1003,";
                 str+="    max(case when S8I.Sitemno='S1004'  then S8I.Snamevn else ''  end)as vS1004,";
                 str+="    max(case when S8I.Sitemno='S1005'  then S8I.Snamevn else ''  end)as vS1005,";
                 str+="    max(case when S8I.Sitemno='S2001'  then S8I.Snamevn else ''  end)as vS2001,";
                 str+="    max(case when S8I.Sitemno='S2002'  then S8I.Snamevn else ''  end)as vS2002,";
                 str+="    max(case when S8I.Sitemno='S2003'  then S8I.Snamevn else ''  end)as vS2003,";
                 str+="    max(case when S8I.Sitemno='S2004'  then S8I.Snamevn else ''  end)as vS2004,";
                 str+="    max(case when S8I.Sitemno='S2005'  then S8I.Snamevn else ''  end)as vS2005,";
                 str+="    max(case when S8I.Sitemno='S2006'  then S8I.Snamevn else ''  end)as vS2006,";
                 str+="    max(case when S8I.Sitemno='S3001'  then S8I.Snamevn else ''  end)as vS3001,";
                 str+="    max(case when S8I.Sitemno='S3002'  then S8I.Snamevn else ''  end)as vS3002,";
                 str+="    max(case when S8I.Sitemno='S3003'  then S8I.Snamevn else ''  end)as vS3003,";
                 str+="    max(case when S8I.Sitemno='S3004'  then S8I.Snamevn else ''  end)as vS3004,";
                 str+="    max(case when S8I.Sitemno='S3005'  then S8I.Snamevn else ''  end)as vS3005,";
                 str+="    max(case when S8I.Sitemno='S3006'  then S8I.Snamevn else ''  end)as vS3006,";
                 str+="    max(case when S8I.Sitemno='S3007'  then S8I.Snamevn else ''  end)as vS3007,";
                 str+="    max(case when S8I.Sitemno='S4001'  then S8I.Snamevn else ''  end)as vS4001,";
                 str+="    max(case when S8I.Sitemno='S4002'  then S8I.Snamevn else ''  end)as vS4002,";
                 str+="    max(case when S8I.Sitemno='S4003'  then S8I.Snamevn else ''  end)as vS4003,";
                 str+="    max(case when S8I.Sitemno='S4004'  then S8I.Snamevn else ''  end)as vS4002,";
                 str+="    max(case when S8I.Sitemno='S5001'  then S8I.Snamevn else ''  end)as vS5001,";
                 str+="    max(case when S8I.Sitemno='S5002'  then S8I.Snamevn else ''  end)as vS5002,";
                 str+="    max(case when S8I.Sitemno='S5003'  then S8I.Snamevn else ''  end)as vS5003,";
                 str+="    max(case when S8I.Sitemno='S6001'  then S8I.Snamevn else ''  end)as vS6001,";
                 str+="    max(case when S8I.Sitemno='S6002'  then S8I.Snamevn else ''  end)as vS6002,";
                 str+="    max(case when S8I.Sitemno='S6003'  then S8I.Snamevn else ''  end)as vS6003,";
                 str+="    max(case when S8I.Sitemno='S6004'  then S8I.Snamevn else ''  end)as vS6004,";
                 str+="    max(case when S8I.Sitemno='S6005'  then S8I.Snamevn else ''  end)as vS6005,";
                 str+="    max(case when S8I.Sitemno='S6006'  then S8I.Snamevn else ''  end)as vS6006,";
                 str+="    max(case when S8I.Sitemno='S7001'  then S8I.Snamevn else ''  end)as vS7001,";
                 str+="    max(case when S8I.Sitemno='S7002'  then S8I.Snamevn else ''  end)as vS7002,";
                 str+="    max(case when S8I.Sitemno='S7003'  then S8I.Snamevn else ''  end)as vS7003,";
                 str+="    max(case when S8I.Sitemno='S7004' then S8I.Snamevn else ''  end)as vS7004,";
                 str+="    max(case when S8I.Sitemno='S7005'  then S8I.Snamevn else ''  end)as vS7005,";
                 str+="    max(case when S8I.Sitemno='S8001'  then S8I.Snamevn else ''  end)as vS8001,";
                 str+="    max(case when S8I.Sitemno='S8002'  then S8I.Snamevn else ''  end)as vS8002,";
                 str+="    max(case when S8I.Sitemno='S8003'  then S8I.Snamevn else ''  end)as vS8003";
                 str += "  from S8item S8I";

             #endregion
                    cmd.CommandText = str;
                    return Select(cmd, "dt8SItemVN");
         }

         public DataSet LayDiem8SCH()
         {
             string str = "";
             SqlCommand cmd = new SqlCommand();
             #region aa
             str +=" select  ";
             str += "  max(case when S8I.Sitemno='S1001'  then S8I.Snamech else '' end)as wS1001,";
                str +="  max(case when S8I.Sitemno='S1002'  then S8I.Snamech else ''  end)as wS1002,";
                str +="  max(case when S8I.Sitemno='S1003'  then S8I.Snamech else ''  end)as wS1003,";
                str +="  max(case when S8I.Sitemno='S1004'  then S8I.Snamech else ''  end)as wS1004,";
                str +="  max(case when S8I.Sitemno='S1005'  then S8I.Snamech else ''  end)as wS1005,";
                str +="  max(case when S8I.Sitemno='S2001'  then S8I.Snamech else ''  end)as wS2001,";
                str +="  max(case when S8I.Sitemno='S2002'  then S8I.Snamech else ''  end)as wS2002,";
                str +="  max(case when S8I.Sitemno='S2003'  then S8I.Snamech else ''  end)as wS2003,";
                str +="  max(case when S8I.Sitemno='S2004'  then S8I.Snamech else ''  end)as wS2004,";
                str +="  max(case when S8I.Sitemno='S2005'  then S8I.Snamech else ''  end)as wS2005,";
                str +="  max(case when S8I.Sitemno='S2006'  then S8I.Snamech else ''  end)as wS2006,";
                str +="  max(case when S8I.Sitemno='S3001'  then S8I.Snamech else ''  end)as wS3001,";
                str +="  max(case when S8I.Sitemno='S3002'  then S8I.Snamech else ''  end)as wS3002,";
                str +="  max(case when S8I.Sitemno='S3003'  then S8I.Snamech else ''  end)as wS3003,";
                str +="  max(case when S8I.Sitemno='S3004'  then S8I.Snamech else ''  end)as wS3004,";
                str +="  max(case when S8I.Sitemno='S3005'  then S8I.Snamech else ''  end)as wS3005,";
                str +="  max(case when S8I.Sitemno='S3006'  then S8I.Snamech else ''  end)as wS3006,";
                str +="  max(case when S8I.Sitemno='S3007'  then S8I.Snamech else ''  end)as wS3007,";
                str +="  max(case when S8I.Sitemno='S4001'  then S8I.Snamech else ''  end)as wS4001,";
                str +="  max(case when S8I.Sitemno='S4002'  then S8I.Snamech else ''  end)as wS4002,";
                str +="  max(case when S8I.Sitemno='S4003'  then S8I.Snamech else ''  end)as wS4003,";
                str +="  max(case when S8I.Sitemno='S4004'  then S8I.Snamech else ''  end)as wS4002,";
                str +="  max(case when S8I.Sitemno='S5001'  then S8I.Snamech else ''  end)as wS5001,";
                str +="  max(case when S8I.Sitemno='S5002'  then S8I.Snamech else ''  end)as wS5002,";
                str +="  max(case when S8I.Sitemno='S5003'  then S8I.Snamech else ''  end)as wS5003,";
                str +="  max(case when S8I.Sitemno='S6001'  then S8I.Snamech else ''  end)as wS6001,";
                str +="  max(case when S8I.Sitemno='S6002'  then S8I.Snamech else ''  end)as wS6002,";
                str +="  max(case when S8I.Sitemno='S6003'  then S8I.Snamech else ''  end)as wS6003,";
                str +="  max(case when S8I.Sitemno='S6004'  then S8I.Snamech else ''  end)as wS6004,";
                str +="  max(case when S8I.Sitemno='S6005'  then S8I.Snamech else ''  end)as wS6005,";
                str +="  max(case when S8I.Sitemno='S6006'  then S8I.Snamech else ''  end)as wS6006,";
                str +="  max(case when S8I.Sitemno='S7001'  then S8I.Snamech else ''  end)as wS7001,";
                str +="  max(case when S8I.Sitemno='S7002'  then S8I.Snamech else ''  end)as wS7002,";
                str +="  max(case when S8I.Sitemno='S7003'  then S8I.Snamech else ''  end)as wS7003,";
                str +="  max(case when S8I.Sitemno='S7004' then S8I.Snamech else ''  end)as wS7004,";
                str +="  max(case when S8I.Sitemno='S7005'  then S8I.Snamech else ''  end)as wS7005,";
                str +="  max(case when S8I.Sitemno='S8001'  then S8I.Snamech else ''  end)as wS8001,";
                str +="  max(case when S8I.Sitemno='S8002'  then S8I.Snamech else ''  end)as wS8002,";
                str +="  max(case when S8I.Sitemno='S8003'  then S8I.Snamech else ''  end)as wS8003";
                str +="  from S8item S8I";
             #endregion
                cmd.CommandText = str;
                return Select(cmd, "dt8SItemCH");
         }
         public DataTable QryPhieu8TheoDieuKienVN2(int IDS8)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamevn as Stpnamevn, S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.sh=@sh";
             cmd.Parameters.Add(Para("sh", IDS8, SqlDbType.Int));
           
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW(string Sitemno, DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh ,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where (S8R.Sitemno = @Sitemno and  S8R.S8date between @FromDate and @ToDate) or (S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate)";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW1( DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8SauKhiCopy_TW(DateTime S8date, string DepartmentID,string GSBH)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.depid=@depid and S8R.S8date=@S8date and S8R.GSBH=@GSBH";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW1_CR(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S6'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW1_NS(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW1_TKTH(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp<>'S6' and S8T.Sitemtp<>'S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienTW2(int IDS8)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.Stpnamech as Stpnamevn, S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += "  where S8R.sh=@sh";
             cmd.Parameters.Add(Para("sh", IDS8, SqlDbType.Int));
           
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN(string Sitemno, DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where (S8R.Sitemno = @Sitemno and  S8R.S8date between @FromDate and @ToDate) or (S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate)";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN1( DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8SauKhiCopy_EN(DateTime S8date, string DepartmentID, string GSBH)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date=@S8date and S8R.GSBH=@GSBH";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN1_CR(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S6'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN1_NS(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN1_TKTH(DateTime FromDate, DateTime ToDate, string DepartmentID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp<>'S6' and S8T.Sitemtp<>'S8'";
             cmd.CommandText += " order by S8R.depid, S8I.Sitemtp,S8R.Sitemno";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", DepartmentID, SqlDbType.VarChar));
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKienEN2(int IDS8)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select S8T.Sitemtp,S8T.stpnameen as Stpnamevn, S8I.Snameen as Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " left join S8type  S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.sh=@sh";
             cmd.Parameters.Add(Para("sh", IDS8, SqlDbType.Int));
             
             return Select(cmd).Tables[0];
         }
         public DataTable LayTongDiemTheoDonVi(string depid, DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText="select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
            cmd.CommandText+=" from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
            cmd.CommandText+=" left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
            cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate";
            cmd.CommandText+=" group by  S8R.depid";
            cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
            cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
            return Select(cmd).Tables[0];

         }
         public DataTable LayTongDiemTheoDonViCopy(string depid, DateTime S8date)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
             cmd.CommandText += " from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
             cmd.CommandText += " left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date=@S8date";
             cmd.CommandText += " group by  S8R.depid";
             cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
            
             cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable LayTongDiemTheoDonVi_CR(string depid, DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
             cmd.CommandText += " from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
             cmd.CommandText += " left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S6'";
             cmd.CommandText += " group by  S8R.depid";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable LayTongDiemTheoDonVi_NS(string depid, DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
             cmd.CommandText += " from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
             cmd.CommandText += " left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp='S8'";
             cmd.CommandText += " group by  S8R.depid";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable LayTongDiemTheoDonVi_TKTH(string depid, DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
             cmd.CommandText += " from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
             cmd.CommandText += " left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
             cmd.CommandText += " where S8R.depid=@depid and S8R.S8date between @FromDate and @ToDate and S8T.Sitemtp<>'S6' and S8T.Sitemtp<>'S8'";
             cmd.CommandText += " group by  S8R.depid";
             cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
             cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable DemSoNgayDeTinhDiem(string depid, DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd = new SqlCommand();
                cmd.CommandText="select count(S8date) as S8date from (";
                cmd.CommandText += " select distinct S8date from S8rec where S8date between @FromDate and @ToDate and depid=@depid)A";
                cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
                cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
                return Select(cmd).Tables[0];

         }
         public DataTable DemSoNgayDeTinhDiemCopy(string depid, DateTime S8date)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select count(S8date) as S8date from (";
             cmd.CommandText += " select distinct S8date from S8rec where S8date=@S8date and depid=@depid)A";
             cmd.Parameters.Add(Para("S8date", S8date, SqlDbType.DateTime));
           
             cmd.Parameters.Add(Para("depid", depid, SqlDbType.VarChar));
             return Select(cmd).Tables[0];

         }
         public DataTable LayTongDiemTatCaDonVi()
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct count(a.depid) as empid,sum(a.Sitemscore) as Sitemscore,sum(a.sub_score)as sub_score ";
            cmd.CommandText +="  from (select distinct S8R.depid,  Sum(S8I.Sitemscore) as Sitemscore, Sum(S8R.sub_score) as sub_score";
            cmd.CommandText +="  from S8rec S8R left join  S8item S8I on S8I.Sitemno=S8R.Sitemno";
            cmd.CommandText +="  left join   S8type S8T on S8T.Sitemtp=S8I.Sitemtp";
            cmd.CommandText += "  group by  S8R.depid)a";
            return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoDieuKien1(string Sitemno)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct * from S8rec S8 left join S8item S8I on S8.Sitemno=S8I.Sitemno ";
             cmd.CommandText += " where S8.Sitemno=@Sitemno";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.VarChar));
             
             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoIDVN(int ID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8I.Snamevn, S8I.Sitemscore,S8R.QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName, S8R.depid,S8R.Sitemno  as Sitemno, S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " where S8R.sh=@ID";
             cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));

             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoIDTW(int ID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8I.Snamech as Snamevn, S8I.Sitemscore,S8R.QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " where S8R.sh=@ID";
             cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));

             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieu8TheoIDEN(int ID)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "select distinct S8I.Snameen as Snamevn, S8I.Sitemscore,S8R. QVmemo as QCmemo,S8R.QCpic0,S8R.QApic,S8R.sub_score, BD.DepName as DepName,S8R.depid,S8R.Sitemno as Sitemno,S8R.sh,S8R.S8date,S8R.yn from  S8rec S8R";
             cmd.CommandText += " left join S8item S8I on S8I.Sitemno=S8R.Sitemno ";
             cmd.CommandText += " left join bdepartment BD on S8R.depid=BD.ID and S8R.GSBH=BD.GSBH";
             cmd.CommandText += " where S8R.sh=@ID";
             cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));

             return Select(cmd).Tables[0];
         }
         public DataTable QryPhieuitemTheoID(string Sitemno)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText="select distinct * from S8item where Sitemno=@Sitemno";
             cmd.Parameters.Add(Para("Sitemno", Sitemno, SqlDbType.NVarChar));
             return Select(cmd).Tables[0];
         }
         public int CapNhatDiem(int ID, decimal Score)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "update S8rec set sub_score=@sub_score where sh=@sh ";
             cmd.Parameters.Add(Para("sh", ID, SqlDbType.Int));
             cmd.Parameters.Add(Para("sub_score", Score, SqlDbType.Decimal));
             return ExecuteNonQuery(cmd);
         }
         public DataTable QryTongDiemXuatReport(DateTime FromDate, DateTime ToDate)
         {
             SqlCommand cmd=new SqlCommand();
             
              cmd.CommandText ="  select  distinct b1.id as Depid,b1.DepName,b1.DepName_C,isnull(SUM(sub_score),0)/COUNT(distinct S8date ) as S8Score";
               cmd.CommandText +="  from S8rec ";
               cmd.CommandText +="  left join BDepartment b1 on S8rec.Depid=b1.id and S8rec.GSBH=b1.GSBH";
               cmd.CommandText +="  where S8date between @FromDate  and @ToDate and b1.Dclass='E' ";
               cmd.CommandText += "  group by b1.id,b1.DepName,b1.DepName_C";
               cmd.CommandText += " order by S8Score desc";
               cmd.Parameters.Add(Para("FromDate", FromDate, SqlDbType.DateTime));
               cmd.Parameters.Add(Para("ToDate", ToDate, SqlDbType.DateTime));
               return Select(cmd).Tables[0];
         }
    }
}