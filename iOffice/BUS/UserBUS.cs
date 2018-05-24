using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class UserBUS
    {
        public static List<Busers2> ListUser(string macongty)
        {
            return UserDAO.ListUser(macongty);
        }
        public static List<Busers2> QryCTy()
        {
            return UserDAO.QryCTy();
        }
        public static Busers2 SearchUserByID(string id, bool checkdel = true)
        {
           
                return UserDAO.SearchUserByID(id, true);
        }
        public static List<Busers2> SearchUserByID1(string id, bool checkdel = true)
        {
            return UserDAO.SearchUserByID1(id, true);
        }
        public static List<Busers2> QryNguoiDuyetTheoMaChucVu(string machucvu,string macongty)
        {
            try
            {
                return UserDAO.QryNguoiDuyetTheoMaChucVu(machucvu,macongty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Busers2 KiemTraNguoiDung(string congty, string tenDangNhap)
        {
            try
            {
                return UserDAO.KiemTraNguoiDung(congty, tenDangNhap);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static Busers2 LayNguoiDuyetTheoMaChucVuCongty(string machucvu, string manguoiduyet, string macongty)
        {
            try
            {
                return UserDAO.LayNguoiDuyetTheoMaChucVuCongty(machucvu, manguoiduyet, macongty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertUser(Busers2 user)
        {
            return UserDAO.InsertUser(user);
        }
        public static bool UpdateUser(Busers2 user)
        {
            return UserDAO.UpdateUser(user);
        }
        public static bool DeleteUser(string id, bool checkdel)
        {
            return UserDAO.DeleteUser(id, true);
        }
        public static Busers2 KiemTraDangNhap(string tenDangNhap, string matKhau,string macongty, bool kiemTraBiXoa = true)
        {
            return UserDAO.KiemTraDangNhap(tenDangNhap, matKhau,macongty, true);
        }
        public static Busers2 KiemTraDangNhap2(string congty, string tenDangNhap, string matKhau, bool kiemTraBiXoa = true)
        {
            return UserDAO.KiemTraDangNhap2(congty, tenDangNhap, matKhau, true);
        }
        public static Busers2 CheckPass2(string tenDangNhap, string matKhau,string macongty, bool kiemTraBiXoa = true)
        {
            return UserDAO.CheckPass2(tenDangNhap, matKhau,macongty, true);
        }
        public static bool ThayDoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi,string macongty, bool kiemTraBiXoa = true)
        {
            return UserDAO.ThayDoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi,macongty, true);
        }
      
        public static Busers2 NVQuenMatKhau(string account, string email,string macongty, bool kiemTraBiXoa = true)
        {
            return UserDAO.NVQuenMatKhau(account, email,macongty, true);
        }
        public static Busers2 TimNhanVienTheoDiaChiEmail(string email, bool kiemTraBiXoa = true)
        {
            return UserDAO.TimNhanVienTheoDiaChiEmail(email, true);
        }
        public static bool ChangePasswordSendUser(string account, string email, bool kiemTraBiXoa = true)
        {
            return UserDAO.ChangePasswordSendUser(account, email, true);
        }
        public static string CreateRandomPassword()
        {
            return UserDAO.CreateRandomPassword();
        }
        public static Busers2 LayNhanVienKhoiTaoCuaVanBan(string idVanBan, bool kiemTraBiXoa = true)
        {
            return UserDAO.LayNhanVienKhoiTaoCuaVanBan(idVanBan, true);
        }
        public static Busers2 LayNhanVienNhanCuaVanBan(string id,int capke,  bool kiemtrabixoa = true)
        {
            return UserDAO.LayNhanVienNhanCuaVanBan(id,capke, true);
        }
        public static Busers2 LayNhanVienTheoIdChiTietXetDuyet(int idChiTietXetDuyet, bool kiemTraBiXoa = true)
        {
            return UserDAO.LayNhanVienTheoIdChiTietXetDuyet(idChiTietXetDuyet, true);
        }
        public static List<Busers2> QryNguoiDuyet(string idphongban)
        {
            return UserDAO.QryNguoiDuyet(idphongban);
        }
        public static List<Busers2> QryNguoiDuyets()
        {
            return UserDAO.QryNguoiDuyets();
        }
        public static bool ThayDoiMatKhauCap2(string tenDangNhap, string matKhauCu, string matKhauMoi, bool kiemTraBiXoa = true)
        {
            return UserDAO.ThayDoiMatKhauCap2(tenDangNhap, matKhauCu, matKhauMoi, true);
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyet(string congty, string bophan)
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyet(congty,bophan);
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyets(string congty)
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyets(congty);
        }
        public static Busers2 QryNguoiDuyetTheoBoPhanCapDuyet1(string mabophan)
        {
            return UserDAO.QryNguoiDuyetTheoBoPhanCapDuyet1(mabophan);
        }
        public static List<Busers2> LayDSNguoiDuyet()
        {
            return UserDAO.LayDSNguoiDuyet();
        }
        public static Busers2 LayNguoiDuyetTheoCapDuyet2()
        {
            return UserDAO.LayNguoiDuyetTheoCapDuyet2();
        }
        public static Busers2 LayNguoiDuyetTheoCapDuyet3()
        {
            return UserDAO.LayNguoiDuyetTheoCapDuyet3();
        }
        public static Busers2 LayNguoiDuyetTheoCapDuyet4()
        {
            return UserDAO.LayNguoiDuyetTheoCapDuyet4();
        }
        public static Busers2 LayNguoiDuyetTheoCapDuyet5()
        {
            return UserDAO.LayNguoiDuyetTheoCapDuyet5();
        }
        public static Busers2 LayNguoiDuyetTheoCapDuyet6()
        {
            return UserDAO.LayNguoiDuyetTheoCapDuyet6();
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyet2()
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyet2();
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyet3()
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyet3();
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyet4()
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyet4();
        }
        public static List<Busers2> QryNguoiDuyetTheoCapDuyet5()
        {
            return UserDAO.QryNguoiDuyetTheoCapDuyet5();
        }
        public static Busers2 TimNhanVienTheoMa(string manhanvien,string macongty)
        {
            return UserDAO.TimNhanVienTheoMa(manhanvien,macongty);
        }
        public static Busers2 TimKiemNhanVien_MaBaoMatTheoIDNhanVien(string idNhanVien)
        {
            return UserDAO.TimKiemNhanVien_MaBaoMatTheoIDNhanVien(idNhanVien);
        }
        public static Busers2 TimMaNhanVienTheoBoPhan(string idnhanvien, string idbophan,string macongty)
        {
            return UserDAO.TimMaNhanVienTheoBoPhan(idnhanvien, idbophan,macongty);
        }
        public static List<Busers2> QryNguoiDuyet1()
        {
            return UserDAO.QryNguoiDuyet1();
        }
        public static Busers2 KiemTraNguoiDuyetTheoPhongBan(string idnhanvien)
        {
            return UserDAO.KiemTraNguoiDuyetTheoPhongBan(idnhanvien);
        }
        public static List<Busers2> QryNguoiDuyetTheoBoPhanCap1(string mabophan,string idcongty)
        {
            return UserDAO.QryNguoiDuyetTheoBoPhanCap1(mabophan,idcongty);
        }
        public static List<Busers2> LayDSNguoiDuyetCap1()
        {
            return UserDAO.LayDSNguoiDuyetCap1();
        }
        public static List<Busers2> LayNhanVienTheoBoPhan(string mabophan,string macongty)
        {
            return UserDAO.LayNhanVienTheoBoPhan(mabophan,macongty);
        }
        public static Busers2 LayNguoiChuQuanDuyetTheoBoPhan(string idbophan, string idchuqua,string macongty )
        {
            return UserDAO.LayNguoiChuQuanDuyetTheoBoPhan(idbophan, idchuqua,macongty);
        }
        public static Busers2 LayNguoiDuyetTheoChucVu(string idchucvu, string macongty)
        {
            return UserDAO.LayNguoiDuyetTheoChucVu(idchucvu, macongty);
        }
        public static Busers2 LayNguoiDuyetTheoMaNguoiDuyet(string manguoiduyet, string macongty)
        {
            return UserDAO.LayNguoiDuyetTheoMaNguoiDuyet(manguoiduyet, macongty);
        }
        public static Busers2 LayNguoiDuyetTheoMaChucVuPhongBan(string machucvu, string maphong, string macongty)
        {
            return UserDAO.LayNguoiDuyetTheoMaChucVuPhongBan(machucvu, maphong, macongty);
        }
        public static Busers2 LayNguoiDuyetTheoMaChucVuCao(string machucvu, string manguoiduyet, string macongty,string mabophanquanly)
        {
            return UserDAO.LayNguoiDuyetTheoMaChucVuCao(machucvu, manguoiduyet, macongty,mabophanquanly);
        }
        public static Busers2 LayNhanVienTheoNhomDuyetCuaVanBan(string idnguoiduyet,string idvanban, int buocky, int nhomky, bool kiemtrabixoa = true)
        {
            try
            {
                return UserDAO.LayNhanVienTheoNhomDuyetCuaVanBan(idnguoiduyet,idvanban, buocky, nhomky, true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Busers2> HienThiDanhSachNguoiDich(string idbophan, string macongty)
        {
            return UserDAO.HienThiDanhSachNguoiDich(idbophan, macongty);
        }
        public static Busers2 TimMaNhanVienTaoPhieu(string manhanvien, string macongty)
        {
            return UserDAO.TimMaNhanVienTaoPhieu(manhanvien, macongty);
        }
        public static Busers2 TimMaNhanVienDich(string manhanvien, string macongty)
        {
            return UserDAO.TimMaNhanVienDich(manhanvien, macongty);
        }
    }
}