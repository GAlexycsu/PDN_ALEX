using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DALBuser:DAL_GenericERPAccess
    {
        public DALBuser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable TimNhanVienDangNhap(string UserID, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Busers2 where USERID=@USERID and GSBH=@GSBH";
                cmd.Parameters.Add(Para("USERID", UserID, SqlDbType.VarChar));
                cmd.Parameters.Add(Para("GSBH", GSBH, SqlDbType.VarChar));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
           //  
        }
    }
}
