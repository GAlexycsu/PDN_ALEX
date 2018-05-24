using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class AbconBUS
    {
        public static int DemSoLuongMaVanBan_CapDuyet()
        {
            return AbconDAO.DemSoLuongMaVanBan_CapDuyet();
        }
        public static Abcon TimKiemChiTietXetDuyetTheoMa(int maChiTietXetDuyet, bool kiemtrabixoa = true)
        {
            return AbconDAO.TimKiemChiTietXetDuyetTheoMa(maChiTietXetDuyet, true);
        }
        
        public static Abcon LayChiTietXetDuyetCuaMotNhanVien(string idNhanVien, string idVanBan)
        {
            return AbconDAO.LayChiTietXetDuyetCuaMotNhanVien(idNhanVien, idVanBan);
        }
        public static bool ThemChiTiet(Abcon ct)
        {
            return AbconDAO.ThemChiTiet(ct);
        }
        public static bool SuaChiTiet(Abcon ct)
        {
            return AbconDAO.SuaChiTiet(ct);
        }
        public static bool SuaChiTiet(Abcon ct,string idnguoiduyet,string ghichu,bool duyet,bool kiemtrabixoa=true)
        {
            return AbconDAO.SuaChiTiet1(ct,idnguoiduyet,ghichu, duyet, true);
        }
        public static bool XoaChiTiet(int Id, bool kiemtrabixoa = true)
        {
            return AbconDAO.XoaChiTiet(Id, true);
        }
        public static List<Abcon> LayDSLoaiVanBan_CapDuyet(string idLoaiVanBan, bool kiemTraBiXoa = true)
        {
            return AbconDAO.LayDSLoaiVanBan_CapDuyet(idLoaiVanBan, true);
        }
        public static Abcon TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(string idVanBan, string idNhanVien, string idNguoiChuyen, bool kiemTraBiXoa = true)
        {
            return AbconDAO.TimKiemVanBanDenTheoIdVanBan_IdNguoiNhan(idVanBan, idNhanVien, idNguoiChuyen, true);
        }
        public static Abcon LaymaVanBanTheoCapDuyet1(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet1(idvanban, id);
        }
        public static Abcon LaymaVanBanTheoCapDuyet2(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet2(idvanban,id);
        }
        public static Abcon LaymaVanBanTheoCapDuyet3(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet3(idvanban,id);

        }
        public static Abcon LaymaVanBanTheoCapDuyet4(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet4(idvanban, id);
        }
        public static Abcon LaymaVanBanTheoCapDuyet5(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet5(idvanban, id);
        }
        public static Abcon LaymaVanBanTheoCapDuyet6(string idvanban, int id)
        {
            return AbconDAO.LaymaVanBanTheoCapDuyet6(idvanban, id);
        }
        public static Busers2 LayMaNguoiTaoTheoIDVanBan(string idvanban, string congty)
        {
            return AbconDAO.LayMaNguoiTaoTheoIDVanBan(idvanban,congty);
        }
        public static Abcon LayCapDangDuyetCuaVanBan(string idvanban,int capduyet, bool kiemtrabixoa = true)
        {
            return AbconDAO.LayCapDangDuyetCuaVanBan(idvanban,capduyet, true);
        }
        public static Abcon LayCapDuyetTruocCuaNhanVienTheoVanBan(string idnhanvien, string idvanban)
        {
            return AbconDAO.LayCapDuyetTruocCuaNhanVienTheoVanBan(idnhanvien, idvanban);
        }
        public static Abcon LayCapDuyetHienTaiCuaNhanVienTheoVanBan(string idnhanvien, string idvanban)
        {
            return AbconDAO.LayCapDuyetHienTaiCuaNhanVienTheoVanBan(idnhanvien, idvanban);
        }
        public static Abcon LayCapDuyetTruocCuaNhanVien(string idnhanvien)
        {
            return AbconDAO.LayCapDuyetTruocCuaNhanVien(idnhanvien);
        }
        public static Abcon LayCapDuyetCuaNhanVien(string idnhanvien)
        {
            return AbconDAO.LayCapDuyetCuaNhanVien(idnhanvien);
        }
        public static List<Abcon> QryChiTietXetDuyet1(int IDCT, bool kiemtrabixoa = true)
        {
            return AbconDAO.QryChiTietXetDuyet1(IDCT, true);
        }
        public static List<Abcon> QryChiTietXetDuyetTheoIdVanBan(string idvanban, bool kiemtrabixoa = true)
        {
            return AbconDAO.QryChiTietXetDuyetTheoIdVanBan(idvanban, true);
        }
        public static List<Abcon> LayCapDuyetTruocCuaNhanVienTheoChiTiet(string idnhanvien)
        {
            return AbconDAO.LayCapDuyetTruocCuaNhanVienTheoChiTiet(idnhanvien);
        }
        public static List<Abcon1> QryVanBanDenTheoNguoiDuyet(string manguoiduyet,string macongty)
        {
            return AbconDAO.QryVanBanDenTheoNguoiDuyet(manguoiduyet, macongty);
        }
        public static List<Abcon> QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(string mavanban,string macongty)
        {
            return AbconDAO.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(mavanban,macongty);
        }
        public static List<Abcon> QryNguoiDuyetBuocDauTien(string mavanban, string idnguoitrinh, string macongty, int buoc = 1,int abps=1)
        {
            try
            {
                return AbconDAO.QryNguoiDuyetBuocDauTien(mavanban, idnguoitrinh,macongty, buoc,abps);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> QryBuocDuyetCuaVanBan(string idvanban, int buocduyet)
        {
            try
            {
                return AbconDAO.QryBuocDuyetCuaVanBan(idvanban, buocduyet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Abcon TimBuocKyChuaHoanThanh(string idvanban, int buocky)
        {
            try
            {
                return AbconDAO.TimBuocKyChuaHoanThanh(idvanban,  buocky);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Abcon LayBuocKeTiepCuaNhanVien(string gsbh,string pdno, int buocduyet, int cap)
        {
            try
            {
                return AbconDAO.LayBuocKeTiepCuaNhanVien(gsbh,pdno, buocduyet, cap);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> QryNguoiDuyetBuocKeTiep(string idvanban, int buocduyet)
        {
            try
            {
                return AbconDAO.QryNguoiDuyetBuocKeTiep(idvanban, buocduyet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> QryNguoiDuyetTrongCung1Cap(string idvanban, int capduyet)
        {
            try
            {
                return AbconDAO.QryNguoiDuyetTrongCung1Cap(idvanban, capduyet);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Abcon LayChiTietXetDuyetTheoNhanVienDuyet(string idvanban, string idnhanvien)
        {
            try
            {
                return AbconDAO.LayChiTietXetDuyetTheoNhanVienDuyet(idvanban, idnhanvien);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Abcon> QryVanBanChuaDuyet(string idnguoiduyet,string macongty)
        {
            try
            {
                return AbconDAO.QryVanBanChuaDuyet(idnguoiduyet, macongty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Abcon KiemTraPhieu(string maphieu, string macongty, int capduyet, int buocduyet)
        {
            try
            {
                return AbconDAO.KiemTraPhieu(maphieu, macongty, capduyet, buocduyet);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool XoaPhieuBiHuy(string pdno, string macongty)
        {
            try
            {
                return AbconDAO.XoaPhieuBiHuy(pdno, macongty);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static Abcon LayBuocKeTiepCuaNhanVienTrongCung1Cap(string idnhanvien, string pdno, int buocduyet, int cap)
        {
            try
            {
                return AbconDAO.LayBuocKeTiepCuaNhanVienTrongCung1Cap(idnhanvien, pdno, buocduyet, cap);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}