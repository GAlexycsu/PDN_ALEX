using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;

namespace iOffice.DAO
{
    public class KhiVangMatDAO
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        public static List<StatusCode> Qry()
        {
            return db.StatusCodes.ToList();
        }
        //public static StatusCode LayNguoiNguoiVangMatTheoNgay(string manhanvien, string macongty)
        //{
        //    var list=(from p in db.ABJobAgents
        //                  from q in db.StatusCodes
        //                  where(p.TuNgay.))
        //}
        public static StatusCode TimMaThongQua(int id)
        {
            try
            {
                return db.StatusCodes.Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}