using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_GanttTasks:DAL_SQL_GenericDataAccess
    {
        public DAL_GanttTasks()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable LayTaskTheoUserID(string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from GanttTasks where Userid=@Userid";
                cmd.Parameters.Add(Para("UserID", UserID, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
                //28150
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int InserTask(string UserID, string GSBH, int ParentID, int OrderID, string pSubject, decimal PercentComplete, bool Expanded, bool Summary, string pDescription)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into GanttTasks(UserID,GSBH,ParentID,OrderID,pSubject,PercentComplete,Expanded,Summary, pDescription)";
                cmd.CommandText += " values(@UserID,@GSBH,@ParentID,@OrderID,@pSubject,@PercentComplete,@Expanded,@Summary, @pDescription)";
                cmd.Parameters.Add(Para("UserID", UserID));
                cmd.Parameters.Add(Para("GSBH", GSBH));
                cmd.Parameters.Add(Para("ParentID", ParentID, SqlDbType.Int));
                cmd.Parameters.Add(Para("OrderID", OrderID, SqlDbType.Int));
                cmd.Parameters.Add(Para("pSubject", pSubject));
                cmd.Parameters.Add(Para("PercentComplete", PercentComplete, SqlDbType.Decimal));
                cmd.Parameters.Add(Para("Expanded", Expanded, SqlDbType.Bit));
                cmd.Parameters.Add(Para("Summary", Summary, SqlDbType.Bit));
                cmd.Parameters.Add(Para("pDescription", pDescription));
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
