using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    class DAL_TheLogib:DAL_SQL_GenericDataAccess
    {
        public DAL_TheLogib()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable CheckLogin(string pUserID, string pAcctiveCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM TheUsers WHERE UserID = @UserID AND ActiveCode = @ActiveCode";

                cmd.Parameters.Add(Para("UserID", pUserID));
                cmd.Parameters.Add(Para("ActiveCode", pAcctiveCode));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable CheckUser1(string pUserID, string pAcctiveCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM TheUsers WHERE UserID = @UserID AND ActiveCode = @ActiveCode";

                cmd.Parameters.Add(Para("UserID", pUserID));
                cmd.Parameters.Add(Para("ActiveCode", pAcctiveCode));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetListSystem(string pUserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "SELECT Name,ID,StartPage FROM dbo.TheSystems";
                //cmd.CommandText += " WHERE ID in (SELECT SystemID FROM Users_Systems WHERE UserID = @UserID)";
                cmd.CommandText = "GetListSystem";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(Para("UserID", pUserID));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int NhapID(string pUserID, string pSystemID, string pSessionID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Users_Systems SET SessionID = @SessionID WHERE UserID = @UserID AND SystemID = @SystemID";

                cmd.Parameters.Add(Para("SessionID", pSessionID));
                cmd.Parameters.Add(Para("UserID", pUserID));
                cmd.Parameters.Add(Para("SystemID", pSystemID));

                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetSystemByID(string ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from dbo.TheSystems where ID=@ID";
                cmd.Parameters.Add(Para("ID", ID));
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool UpdatePassword(string pUserID, string pAcctiCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update TheUsers set ActiveCode=@ActiveCode where UserID=@UserID";
                cmd.Parameters.Add(Para("UserID", pUserID));
                cmd.Parameters.Add(Para("ActiveCode", pAcctiCode));
                ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable CheckUser(string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TheUsers where UserID=@UserID";
                cmd.Parameters.Add(Para("UserID", UserID));

                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LoadSystem()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select id,Name from  TheSystems ";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable KiemTrauUserVoiDangNhap(string UserID, string SystemID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from  Users_Systems where UserID='" + UserID + "' and SystemID='" + SystemID + "' ";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ThemNguoiDungDangNhapHeThong(string UserID, string SystemID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Users_Systems(UserID,SystemID) values('" + UserID + "','" + SystemID + "')";

                return ExecuteNonQuery(cmd);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int ThemUser(string UserID, string Acticode, string Email)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into TheUsers(UserID,ActiveCode,SEmail) values('" + UserID + "',N'" + Acticode + "',N'" + Email + "')";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LayNguoiDungDangNhapVaoHeThong()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select us.UserID,tu.UserName,us.SystemID,ts.Name from Users_Systems us ";
                cmd.CommandText += " left join TheSystems ts on us.SystemID=ts.ID ";
                cmd.CommandText += " left join TheUsers tu on us.UserID=tu.UserID";
                cmd.CommandText += " order by us.UserID asc";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int XoaNguoiDungVaoHeThong(string UserID, string SystemID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "delete Users_Systems where UserID='" + UserID + "' and SystemID='" + SystemID + "'";
                return ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable HienThiDanhSachTimKiem(string UserID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select us.UserID,tu.UserName,us.SystemID,ts.Name from Users_Systems us ";
                cmd.CommandText += " left join TheSystems ts on us.SystemID=ts.ID ";
                cmd.CommandText += " left join TheUsers tu on us.UserID=tu.UserID";
                cmd.CommandText += " where us.UserID='" + UserID + "'";
                cmd.CommandText += " order by us.SystemID";
                return selex(cmd).Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
