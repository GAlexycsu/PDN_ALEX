using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DAO;

using iOffice.DTO;
using System.Data;

namespace iOffice.BUS
{
    public class pdnaBUS
    {
     
        public List<pdna> ListPDNA()
        {
            return pnaDAO.ListPDNA();
        }
        public static bool CapNhatTinhTrangVanBan(string idVanBan, int tinhTrang, bool kiemTraBiXoa = true)
        {
            return pnaDAO.CapNhatTinhTrangVanBan(idVanBan, tinhTrang, true);
        }
        public static bool CapNhatCapDangDuyetChoVanban(string idVanBan, int capDangDuyet, bool kiemTraBiXoa = true)
        {
            return pnaDAO.CapNhatCapDangDuyetChoVanban(idVanBan, capDangDuyet, true);
        }
        public static List<pdna> QryVanBanBiXoaTheoMaBoPhan(string idBophan, string idNhanVien, bool kiemTraBiXoa = true)
        {
            return pnaDAO.QryVanBanBiXoaTheoMaBoPhan(idBophan, idNhanVien, true);
        }
       
        public static int DemSoLuongVanBanTheoBoPhan(string idPhongBan, bool kiemTraBiXoa = true)
        {
            return pnaDAO.DemSoLuongVanBanTheoBoPhan(idPhongBan, true);
        }
        public static List<pdna> TimKiemVanBanTheoMaNguoiTao(string maNguoiTao,string macongty, bool kiemTraBiXoa = true)
        {
            return pnaDAO.TimKiemVanBanTheoMaNguoiTao(maNguoiTao,macongty, true);
        }
     
        public static Dictionary<bool, Abcon> LayCapDangDuyetCuaVanBan1(string idVanBan, string idnhanvien,string macongty, System.Nullable<bool> flag, bool kiemTraBiXoa = true)
        {
            return pnaDAO.LayCapDangDuyetCuaVanBan1(idVanBan, idnhanvien,macongty, flag, true);
        }
        public static bool CapNhatIdNguoiDangDuyetChoVanBan(string idVanBan, string idNguoiDangDuyet, bool kiemTraBiXoa = true)
        {
            return pnaDAO.CapNhatIdNguoiDangDuyetChoVanBan(idVanBan, idNguoiDangDuyet, true);
        }
        public static pdna LayNoiDungVanBanTheoMaVanBan(string id)
        {
            return pnaDAO.LayNoiDungVanBanTheoMaVanBan(id);
        }
        public static pdna TimVanBanTheoMa(string idvanban,string idcty, bool kiemtrabixoa = true)
        {
            return pnaDAO.TimVanBanTheoMa(idvanban,idcty, true);
        }
        //public static pdna TimVanBanTheoMa(string idvanban,string macongty, bool kiemtrabixoa = true)
        //{
        //    return pnaDAO.TimVanBanTheoMa(idvanban,macongty, true);
        //}
        public static int DemSoLuongVanBan()
        {
            return pnaDAO.DemSoLuongVanBan();
        }
        public static List<pdna> QryVanBanDen()
        {
            return pnaDAO.QryVanBanDen();
        }
        public static bool XoaVanBan(pdna pVanBan, bool kiemTraBiXoa = true)
        {
            return pnaDAO.XoaVanBan(pVanBan, true);
        }
        public static pdna LayNoiDungVanBanTheoIDPhieuIDNhanVien(string idphieu, string idnhanvien,string macongty)
        {
            return pnaDAO.LayNoiDungVanBanTheoIDPhieuIDNhanVien(idphieu, idnhanvien,macongty);
        }
        public static bool InsertPDNA(pdna pd)
        {
            return pnaDAO.InsertPDNA(pd);
        }
        public static pdna LayVanBanDaGuiDenNguoiDuyetTheoNGuoiTrinhDuyet(string idvanban, string idnguoidich, string macongty)
        {
            try
            {
                return pnaDAO.LayVanBanDaGuiDenNguoiDuyetTheoNGuoiTrinhDuyet(idvanban, idnguoidich, macongty);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}