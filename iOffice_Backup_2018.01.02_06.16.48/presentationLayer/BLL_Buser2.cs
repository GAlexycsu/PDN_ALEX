using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class BLL_Buser2
    {
        DALBuser dal = new DALBuser();
        public BLL_Buser2()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable TimNhanVienDangNhap(string UserID, string GSBH)
        {
            try
            {
                return dal.TimNhanVienDangNhap(UserID, GSBH);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
