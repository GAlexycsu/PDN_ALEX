using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;

using System.Net.Mail;
namespace iOffice.presentationLayer
{
    class BLL_TheLogib
    {
        DAL_TheLogib _dal = new DAL_TheLogib();
        public BLL_TheLogib()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string CalculateMD5Hash(string input)
        {
            try
            {
                // step 1, calculate MD5 hash from input
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.Unicode.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string CreateRandomPassword()
        {
            int PasswordLength = 10;
            string _allowedChars = "abcdefghijkmnopqrstuvwxyz0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public bool SendMailss(string listmail, string emailto, string subject, string body)
        {

            MailMessage mail = new MailMessage(listmail, emailto);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.CC.Add(new MailAddress("tuan-it@footgear.com.vn"));
            mail.Body = body;
            client.Send(mail);
            return true;
        }
        public bool Login(string pUserID, string pPassword, ref string pAcctiveCode)
        {
            try
            {
                pAcctiveCode = CalculateMD5Hash(pUserID + "TheLogin" + pPassword);
                DataTable dt = _dal.CheckLogin(pUserID, pAcctiveCode);
                if (dt.Rows.Count > 0)
                {
                    int Count = (int)dt.Rows[0][0];
                    if (Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
                return _dal.GetListSystem(pUserID);
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
                return _dal.NhapID(pUserID, pSystemID, pSessionID);
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
                return _dal.GetSystemByID(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable CheckLogin(string pUserID, string pAcctiveCode)
        {
            try
            {
                return _dal.CheckLogin(pUserID, pAcctiveCode);
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
                return _dal.UpdatePassword(pUserID, pAcctiCode);
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
                return _dal.CheckUser1(pUserID, pAcctiveCode);
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
                return _dal.CheckUser(UserID);
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
                return _dal.LoadSystem();
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
                return _dal.KiemTrauUserVoiDangNhap(UserID, SystemID);
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
                return _dal.ThemNguoiDungDangNhapHeThong(UserID, SystemID);
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
                return _dal.ThemUser(UserID, Acticode, Email);
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
                return _dal.LayNguoiDungDangNhapVaoHeThong();
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
                return _dal.XoaNguoiDungVaoHeThong(UserID, SystemID);
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
                return _dal.HienThiDanhSachTimKiem(UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
