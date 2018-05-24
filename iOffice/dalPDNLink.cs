using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace iOffice
{
    public class dalPDNLink : GernericDataAccess
    {
        public dalPDNLink(){}
        public DataTable QryFileDinhKem(string pdno, string GSBH)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "QryFileDinhKem";
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(CreateParameter("pdno", pdno));
                cmd.Parameters.Add(CreateParameter("Gsbh", GSBH));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}