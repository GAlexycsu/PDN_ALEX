using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
     class DAL_GroupShare:DAL_SQL_GenericDataAccess
    {
        public DAL_GroupShare() { }
        public DataTable LayGroupShowDrop(string userid, string GSBh)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct ugno,UGtitle from Ugroup where userid=@userid and GSBh=@GSBh";
            cmd.Parameters.Add(Para("userid",userid));
            cmd.Parameters.Add(Para("GSBh",GSBh));
            return selex(cmd).Tables[0];
        }
        public DataTable LayGroupMessage(string USID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from UShare where USID=@USID";
            cmd.Parameters.Add(Para("USID", USID));
           //
            return selex(cmd).Tables[0];
        }
        public DataTable LayGroupMessageLenGrid(string USID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select US.*,UG.UGtitle, (isnull(Bu.USERNAME,'') +'.'+ isnull(Bu.USERNAMETW,'')) as  USERNAME from UShare US ";
            cmd.CommandText +=" left join Ugroup UG on US.UGno=UG.ugno";
            cmd.CommandText +=" left join Busers2 BU on US.Userid=BU.USERID  where USID=@USID";
            cmd.Parameters.Add(Para("USID", USID));
            //
            return selex(cmd).Tables[0];
        }
        public DataTable QryFileDinhKemTT(string USID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select LinkFile,LinkFile2,LinkFile3 from UShare  where USID=@USID";
            cmd.Parameters.Add(Para("USID", USID));
            return selex(cmd).Tables[0];
        }
        public int DeleteMessageByID(int ID)
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="Delete UShare where USID=@USID";
            cmd.Parameters.Add(Para("USID",ID,SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int DeleteMessageByID1(string ID,string GSBH,string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete UShare where USID=@USID and GSBH=@GSBH and Userid=@Userid";
            cmd.Parameters.Add(Para("USID", ID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("Userid", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
            return ExecuteNonQuery(cmd);
        }
        public DataTable LayGroupTheoID(string userid, string GSBh, string ugno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Ugroup where userid=@userid and GSBh=@GSBh and ugno=@ugno";
            cmd.Parameters.Add(Para("userid", userid));
            cmd.Parameters.Add(Para("GSBh", GSBh));
            cmd.Parameters.Add(Para("ugno", ugno));
            return selex(cmd).Tables[0];
            // 
        }
        public int UpdateAttactFile1(string GSBH, string UserID, string USID,string FileName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update UShare set LinkFile=@LinkFile where GSBH=@GSBH and Userid=@Userid and USID=@USID";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("USID", USID));
            cmd.Parameters.Add(Para("LinkFile", FileName,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateAttactFile2(string GSBH, string UserID, string USID, string FileName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update UShare set LinkFile2=@LinkFile2 where GSBH=@GSBH and Userid=@Userid and USID=@USID";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("USID", USID));
            cmd.Parameters.Add(Para("LinkFile2", FileName,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateAttactFile3(string GSBH, string UserID, string USID, string FileName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update UShare set LinkFile3=@LinkFile3 where GSBH=@GSBH and Userid=@Userid and USID=@USID";
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("USID", USID));
            cmd.Parameters.Add(Para("LinkFile3", FileName,SqlDbType.NVarChar));
            return ExecuteNonQuery(cmd);
        }
        public int ThemMessageShare(string  GSBH,string USID,string Userid,string UGno,string UStitle,string USmemo,DateTime sdate,DateTime edate)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ThemMessage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("GSBH",GSBH));
            cmd.Parameters.Add(Para("USID",USID));
            cmd.Parameters.Add(Para("Userid",Userid));
            cmd.Parameters.Add(Para("UGno",UGno));
            cmd.Parameters.Add(Para("UStitle", UStitle,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("USmemo",USmemo,SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("sdate",sdate,SqlDbType.DateTime));
             cmd.Parameters.Add(Para("edate",edate,SqlDbType.DateTime));
             return ExecuteNonQuery(cmd);
        }
        public DataTable GetMaxID()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select MAX(USID) as USID from UShare";
            return selex(cmd).Tables[0];
        }
        public DataTable GetMaxIDAttact()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select MAX(ID) as ID from AttactFilePDN";
            return selex(cmd).Tables[0];
        }
        public DataTable GetDate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select (GETDATE()+7) as NgayThang";
            return selex(cmd).Tables[0];
        }
        public DataTable QryMessgage( DateTime DateCurrent,string GSBH,string Userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "QryMessgage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(Para("GSBH", GSBH));
            cmd.Parameters.Add(Para("Userid",Userid));
            cmd.Parameters.Add(Para("DateCurrent", DateCurrent, SqlDbType.DateTime));
            return selex(cmd).Tables[0];
        }
        public int InserFileAttact(string UserID,string ID,string fileName, string partName,string USID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into AttactFilePDN(UserID,ID,FileNameA,PathNameA,USID) values(@UserID,@ID,@FileNameA,@PathNameA,@USID)";
            cmd.Parameters.Add(Para("FileNameA", fileName,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("PathNameA", partName,SqlDbType.NVarChar));
            cmd.Parameters.Add(Para("UserID",UserID));
            cmd.Parameters.Add(Para("ID", ID));
            cmd.Parameters.Add(Para("USID", USID));
            return ExecuteNonQuery(cmd);
        }
        public int UpdateMessageID(string UserID, string ID, string MessageID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="update AttactFilePDN set USID=@USID  where UserID=@UserID and ID=@ID";
            cmd.Parameters.Add(Para("USID",MessageID));
            cmd.Parameters.Add(Para("UserID",UserID));
            cmd.Parameters.Add(Para("ID", ID));
            return ExecuteNonQuery(cmd);
        }
        public DataTable QryFileDinhKem(string UserID, string IDMessage)
        {
         
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from AttactFilePDN where UserID=@UserID and USID=@USID";
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("USID", IDMessage));
            return selex(cmd).Tables[0];
        }
        public DataTable QryFileDinhKem(string UserID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from AttactFilePDN where UserID=@UserID";
            cmd.Parameters.Add(Para("UserID", UserID));
            
            return selex(cmd).Tables[0];
        }
        public DataTable QryFileDinhKemTheoMa(string USID)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from AttactFilePDN where USID=@USID";
            cmd.Parameters.Add(Para("USID", USID));

            return selex(cmd).Tables[0];
        }
        public int XoaFileDinhKem(string UserID, int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete  AttactFilePDN where UserID=@UserID and ID=@ID";
            cmd.Parameters.Add(Para("UserID", UserID));
            cmd.Parameters.Add(Para("ID", ID,SqlDbType.Int));
            return ExecuteNonQuery(cmd);
        }
        public int XoaMessageTemp(string UserID, string USID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete  AttactFilePDN where UserID=@UserID and USID=@USID";
            cmd.Parameters.Add(Para("USID", USID));
            cmd.Parameters.Add(Para("UserID", UserID));
            return ExecuteNonQuery(cmd);
        }
    }
}