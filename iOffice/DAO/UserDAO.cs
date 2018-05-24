using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.DAO
{
    public class UserDAO
    {
       static  iOfficeDataContext db = new iOfficeDataContext();

       public static List<Busers2> ListUser(string macongty)
       {
         
               return db.Busers2s.Where(p=>p.GSBH==macongty).ToList();
          
       }
       public static List<Busers2> QryCTy()
       {
           var list = from p in db.Busers2s
                      from q in db.BDepartments
                      where (p.GSBH == q.GSBH)
                      select p;
           return list.ToList();
       }
       public static Busers2 SearchUserByID(string id, bool checkdel = true)
       {
           Busers2 user = new Busers2();
           if (checkdel)
           {
               user = db.Busers2s.Where(p => p.USERID.Equals(id)).FirstOrDefault();

           }
           else
           {
               user = db.Busers2s.Where(p => p.USERID.Equals(id)).SingleOrDefault();
           }
           return user;
       }
       public static List<Busers2> QryNguoiDuyetTheoMaChucVu(string machucvu, string macongty)
       {
           var list = (from p in db.Busers2s
                       from q in db.ChucVus
                       where (p.IDChucVu == q.IDChucVu && p.IDChucVu == machucvu && p.GSBH==macongty)
                       select p).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoMaChucVuCongty(string machucvu, string manguoiduyet, string macongty)
       {
           try
           {
               var list = (from p in db.ChucVus
                           from h in db.Busers2s
                           where (p.IDChucVu == h.IDChucVu && h.USERID == manguoiduyet && h.IDChucVu == machucvu && h.GSBH == macongty)
                           select h).FirstOrDefault();

               return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<Busers2> SearchUserByID1(string id, bool checkdel = true)
       {
           List<Busers2> user = new List<Busers2>();
           if (checkdel)
           {
               user = db.Busers2s.Where(p => p.USERID.Equals(id)).ToList();
               
                      
           }
           else
           {
               user = db.Busers2s.Where(p => p.USERID.Equals(id)).ToList();
           }
           return user;
       }
       public static bool InsertUser(Busers2 user)
       {
           try
           {
               db.Busers2s.InsertOnSubmit(user);
               db.SubmitChanges();
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }
       public static bool UpdateUser(Busers2 user)
       {
           try
           {
               Busers2 u = new Busers2();
               u = db.Busers2s.Where(p => p.USERID == user.USERID && p.GSBH==user.GSBH).FirstOrDefault();
               {
                   u.USERID = user.USERID;
                   u.USERNAME = user.USERNAME;
               
                   u.Password2 = user.Password2;
                   u.LASTDATETIME = user.LASTDATETIME;
                   u.isSep = user.isSep;
                   u.EMAIL = user.EMAIL;
                   u.IDChucVu = user.IDChucVu;
                   u.BADEPID = user.BADEPID;
                   u.GSBH = user.GSBH; 
                   u.EMAIL = user.EMAIL;
                   u.IDCapDuyet = user.IDCapDuyet;
                   u.signatue = user.signatue;
                   u.YN = user.YN;
                   u.IdUserQuanLyTT = user.IdUserQuanLyTT;
               }
               db.SubmitChanges();
               return true;
           }
           catch (Exception)
           { return false; }
       }
       public static bool CapNhatNguoiDung(Busers2 user)
       {
           try
           {
               Busers2 u = new Busers2();
               u = db.Busers2s.Where(p => p.USERID == user.USERID && p.GSBH == user.GSBH).FirstOrDefault();
               {
                   u.USERID = user.USERID;
                   u.GSBH = user.GSBH;
                   u.signatue = user.signatue;
                  
               }
               db.SubmitChanges();
               return true;
           }
           catch (Exception)
           { return false; }
       }
       public static bool DeleteUser(string id,bool checkdel)
       {
           try
           {
               if (checkdel)
               {
                   Busers2 user = new Busers2();
                   user = db.Busers2s.Where(p => p.USERID.Equals(id)).FirstOrDefault();
                   user.bixoa = true;
                   
               }
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }
       public static Busers2 KiemTraDangNhap(string tenDangNhap, string matKhau, string macongty, bool kiemTraBiXoa = true)
       {

           Busers2 nNhanVien = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.PWD == matKhau && nv.GSBH==macongty).FirstOrDefault();
                  // var login = from p in db.Busers.Where(p => p.USERID.Equals(tenDangNhap) && p.PWD.Equals(matKhau)) select p;
                  //return login.FirstOrDefault();
               }
               else
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.PWD == matKhau && nv.GSBH == macongty).FirstOrDefault();
               }
               return nNhanVien;
              
           }
           catch (Exception )
           {
               
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
           return null;
       }

       public static Busers2 KiemTraDangNhap2(string congty, string tenDangNhap, string matKhau, bool kiemTraBiXoa = true)
       {

           Busers2 nNhanVien = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.GSBH == congty && nv.USERID == tenDangNhap && nv.PWD == matKhau).FirstOrDefault();
                   // var login = from p in db.Busers.Where(p => p.USERID.Equals(tenDangNhap) && p.PWD.Equals(matKhau)) select p;
                   //return login.FirstOrDefault();
               }
               else
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.GSBH == congty && nv.USERID == tenDangNhap && nv.PWD == matKhau).FirstOrDefault();
               }
               return nNhanVien;

           }
           catch (Exception )
           {

           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
           return null;
       }
       public static Busers2 KiemTraNguoiDung(string congty, string tenDangNhap)
       {

         
           try
           {

               var nNhanVien = db.Busers2s.Where(nv => nv.GSBH == congty && nv.USERID == tenDangNhap);
                   // var login = from p in db.Busers.Where(p => p.USERID.Equals(tenDangNhap) && p.PWD.Equals(matKhau)) select p;
                   //return login.FirstOrDefault();
               return nNhanVien.FirstOrDefault();

           }
           catch (Exception )
           {
               throw;

           }
           
       }
       public static Busers2 CheckPass2(string tenDangNhap, string matKhau, string macongty, bool kiemTraBiXoa = true)
       {

           Busers2 nNhanVien = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.Password2 == matKhau && nv.GSBH==macongty).FirstOrDefault();
               }
               else
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.Password2 == matKhau && nv.GSBH == macongty).FirstOrDefault();
               }
               db.ToString();
               if (nNhanVien != null)
                   return nNhanVien;
               else
                   return null;
           }
           catch (Exception)
           {
              
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
           return null;
       }
       public static bool ThayDoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi,string macongty, bool kiemTraBiXoa = true)
       {


           Busers2 nNhanVien = new Busers2();


           try
           {
               if (kiemTraBiXoa)
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.PWD == matKhauCu && nv.GSBH==macongty).FirstOrDefault();

                   if (nNhanVien == null)
                   {
                       if (db != null)
                           db.ToString();
                       return false;
                   }


                   else
                   {

                       nNhanVien.PWD = matKhauMoi;
                       db.SubmitChanges();
                       if (db != null)
                           db.ToString();
                       return true;
                   }
               }
               else
               {
                   return false;
               }
           }
           catch (Exception )
           {
             
               return false;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }

       public static bool ThayDoiMatKhauCap2(string tenDangNhap, string matKhauCu, string matKhauMoi, bool kiemTraBiXoa = true)
       {

           Busers2 nNhanVien = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNhanVien = db.Busers2s.Where(nv => nv.USERID == tenDangNhap && nv.Password2 == matKhauCu ).FirstOrDefault();


                   if (nNhanVien == null)
                   {
                       if (db != null)
                           db.ToString();
                       return false;
                   }
                   else
                   {
                       nNhanVien.Password2 = matKhauMoi;

                       //NhanVien_MaBaoMat nvbm = new NhanVien_MaBaoMat();
                       //nvbm.IdNhanVien = nNhanVien.IdNhanVien;
                       //nvbm.MyKey = matKhauMoi;
                       //nvbm.Ngay = DateTime.Now;
                       //db.NhanVien_MaBaoMats.InsertOnSubmit(nvbm);

                       db.SubmitChanges();
                       if (db != null)
                           db.ToString();

                       return true;
                   }
               }
               else
               {
                   return false;
               }
           }
           catch (Exception ex)
           {
               Until.WriteFileLogServer("ThayDoiMatKhauCap2\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return false;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }

       }

       

       public static Busers2 NVQuenMatKhau(string account, string email, string macongty, bool kiemTraBiXoa = true)
       {


           Busers2 nNV = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNV = db.Busers2s.Where(nv => nv.USERID == account && nv.EMAIL == email && nv.GSBH==macongty ).FirstOrDefault();
                   // var  nNV=(from p in db.Busers.where(p=>p.USERID==account && p.EMAIL== email && p.bixoa==false ) select p.USERID);
                   //var nNV = from q in db.Busers where (q.USERID == account && q.EMAIL == email && q.bixoa == false) select q;
                   //return nNV.FirstOrDefault();
               }
               else
               {
                   nNV = db.Busers2s.Where(nv => nv.USERID == account && nv.EMAIL == email).FirstOrDefault();
                   //var nNV = from q in db.Busers where (q.USERID == account && q.EMAIL == email ) select q;
                   //return nNV.FirstOrDefault();
               }
               return nNV;
               //int kiemtra = db.Busers.Where(p => p.EMAIL == email).Count();
               //if (kiemtra > 0)
               //{
               //    Buser j = db.Busers.Where(p => p.EMAIL == email && p.USERID==account).First();
                  
               //        GuiMail mail = new GuiMail();
               //        string bodymail = mail.BodyMail_LayLaiMatKhau(Email, j.MatKhau);
               //        string ThongBao = mail.Send("Lấy lại mật khẩu", bodymail, Email, true, true);
               //        ViewBag.ThongBao = ThongBao;
                 
               //}
               //else
               //{
               //    ViewBag.ThongBao = "Email không đúng! Vui lòng nhập lại!";
               //} 
           }
           catch (Exception )
           {

               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }

       public static Busers2 TimNhanVienTheoDiaChiEmail(string email, bool kiemTraBiXoa = true)
       {

           Busers2 nNV = new Busers2();
           try
           {
               if (kiemTraBiXoa)
               {
                   nNV = db.Busers2s.Where(nv => nv.EMAIL == email && nv.bixoa == false).SingleOrDefault();
               }
               else
               {
                   nNV = db.Busers2s.Where(nv => nv.EMAIL == email).SingleOrDefault();
               }
               db.ToString();
               if (nNV != null)
                   return nNV;
               else
                   return null;
           }
           catch (Exception )
           {
              
               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }
       public static bool ChangePasswordSendUser(string account, string email, bool kiemTraBiXoa = true)
       {
          
           //string MatKhauMoi = "";
           Busers2 nNV = new Busers2();
           try
           {

               if (kiemTraBiXoa)
               {
                   nNV = db.Busers2s.Where(nv => nv.USERID == account && nv.EMAIL == email).FirstOrDefault();
                   if (nNV == null)
                   {
                       if (db != null)
                           db.ToString();
                       return false;
                   }
                   else
                   {
                       //nNV.PWD = pass;
                       //db.SubmitChanges();
                       if (db != null)
                           db.ToString();
                       return true;
                   }
               }
               else
               {
                   return false;
               }
           }
           catch (Exception )
           {
              
               return false;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }

       }

       public static string CreateRandomPassword()
       {
           try
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
           catch (Exception)
           {
              
               return "";
           }
       }


       public static bool ChangeSercuritySendUser(string account, string email, bool kiemTraBiXoa = true)
       {
          
           string MaBaoMat = CreateRandomPassword();
           Busers2 nNV = new Busers2();
           try
           {


               if (kiemTraBiXoa)
               {
                   nNV = db.Busers2s.Where(nv => nv.USERID == account && nv.EMAIL == email && nv.bixoa == false).SingleOrDefault();
                   if (nNV == null)
                   {
                       if (db != null)
                           db.ToString();
                       return false;
                   }

                   else
                   {
                       nNV.Password2 = libraly.EncryptionPassword(MaBaoMat);
                      

                       db.SubmitChanges();
                       if (db != null)
                           db.ToString();
                       return true;
                   }
               }
               else
               {
                   return false;
               }
           }
           catch (Exception )
           {
               //Util.WriteFileLogServer("ChangeSercuritySendUser\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return false;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }
       //public static Abcon LayCapDuyetCuaNhanVien(string idNhanVien, string idVanBan, bool kiemTraBiXoa = true)
       //{


       //    try
       //    {
       //        if (kiemTraBiXoa)
       //        {
       //            var cd = (from vb_cd in db.abills_1s
       //                      from chitiet in db.Abcons
       //                      where chitiet.pdno == idVanBan && vb_cd. == chitiet.Id_VB_CD && chitiet.IdNhanVien == idNhanVien && vb_cd.BiXoa == false && chitiet.BiXoa == false
       //                      select vb_cd.CapDuyet).FirstOrDefault();
       //            //return capDuyet.FirstOrDefault();
       //        }
       //        else
       //        {
       //            cd = (from vb_cd in db.VanBan_CapDuyets
       //                  from chitiet in db.ChiTietXetDuyets
       //                  where vb_cd.IdVanBan == idVanBan && vb_cd.Id_VB_CD == chitiet.Id_VB_CD && chitiet.IdNhanVien == idNhanVien
       //                  select vb_cd.CapDuyet).FirstOrDefault();
       //            // return capDuyet.FirstOrDefault();
       //        }
       //        db.ToString();
       //        if (cd != null)
       //            return cd;
       //        else
       //            return new CapDuyet();
       //    }

       //    catch (Exception ex)
       //    {
       //        Until.WriteFileLogServer("LayCapDuyetCuaNhanVien\t\t" + "\tMessage Error:\t\t" + ex.Message);
       //        return new CapDuyet();
       //    }
       //    finally
       //    {
       //        if (db != null)
       //            db.ToString();
       //    }
       //}

       public static Busers2 LayNhanVienKhoiTaoCuaVanBan(string idVanBan, bool kiemTraBiXoa = true)
       {
          
           //NhanVien nv = new NhanVien();
           try
           {
               if (kiemTraBiXoa)
               {
                 var  nv = (from n in db.Busers2s
                         from vb in db.pdnas
                         from p in db.Abcons
                            where n.USERID == vb.CFMID0 && vb.pdno == p.pdno && vb.pdno == idVanBan 
                         select n).FirstOrDefault();
                  
                 return nv;
               }
               else
               {
                   var nv1 = (from n in db.Busers2s
                             from vb in db.pdnas
                             from p in db.Abcons
                             where n.USERID == vb.CFMID0 && vb.pdno == p.pdno && vb.pdno == idVanBan
                             select n).FirstOrDefault();

                   return nv1;
               }
              
           }
           catch (Exception ex)
           {
               Until.WriteFileLogServer("LayNhanVienKhoiTaoCuaVanBan\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }

       public static Busers2 LayNhanVienNhanCuaVanBan(string idvanban,int capke, bool kiemtrabixoa = true)
       {
           try
           {
               if (kiemtrabixoa)
               {
                   var nv = (from n in db.Busers2s
                             
                             from p in db.Abcons
                             where n.USERID ==p.Auditor   && p.pdno==idvanban && p.Abstep==capke
                             select n).FirstOrDefault();
                   return nv;
               }
               else
               {
                   var nv = (from n in db.Busers2s

                             from p in db.Abcons
                             where n.USERID == p.Auditor && p.pdno == idvanban && p.Abstep == capke
                             select n).FirstOrDefault();
                   return nv;
               }
           }
           catch (Exception ex)
           {
               Until.WriteFileLogServer("LayNhanVienKhoiTaoCuaVanBan\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }
       public static Busers2 LayNhanVienTheoNhomDuyetCuaVanBan(string idnguoiduyet,string idvanban,int buocky, int nhomky, bool kiemtrabixoa = true)
       {
           try
           {
               if (kiemtrabixoa)
               {
                   var nv = (from n in db.Busers2s
                             from q in db.pdnas
                             from p in db.Abcons
                             where n.USERID == p.Auditor && q.pdno==p.pdno && p.pdno == idvanban && p.Abstep == buocky && p.Nhom==nhomky && p.Auditor==idnguoiduyet
                             select n).FirstOrDefault();
                   return nv;
               }
               else
               {
                   var nv = (from n in db.Busers2s
                             from q in db.pdnas
                             from p in db.Abcons
                             where n.USERID == p.Auditor && q.pdno == p.pdno && p.pdno == idvanban && p.Abstep == buocky && p.Nhom == nhomky
                             select n).FirstOrDefault();
                   return nv;
               }
           }
           catch (Exception ex)
           {
               Until.WriteFileLogServer("LayNhanVienKhoiTaoCuaVanBan\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }
       public static Busers2 LayNhanVienTheoIdChiTietXetDuyet(int idChiTietXetDuyet, bool kiemTraBiXoa = true)
       {

           
           try
           {
               if (kiemTraBiXoa)
               {
                   var lstnv1 = from nv in db.Busers2s
                                from ctxd in db.Abcons
                                where nv.USERID == ctxd.Auditor && ctxd.IDCT == idChiTietXetDuyet 
                                select nv;
                  
                   return lstnv1.FirstOrDefault();
               }
               var lstnv2 = from nv in db.Busers2s
                            from ctxd in db.Abcons
                            where nv.USERID == ctxd.Auditor && ctxd.IDCT == idChiTietXetDuyet 
                            select nv;

               return lstnv2.FirstOrDefault();
           }
           catch (Exception ex)
           {

               Until.WriteFileLogServer("LayNhanVienTheoIdChiTietXetDuyet\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return null;
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }
       public static List<Busers2> QryNguoiDuyet(string idphongban)
       {
           var list = (from p in db.BDepartments
                       from q in db.Busers2s
                       where (p.ID == q.BADEPID && q.BADEPID == idphongban && q.isSep == true)
                       select q).ToList();
           return list;
       }
       public static List<Busers2> QryNguoiDuyet1()
       {
           return db.Busers2s.Where(p => p.isSep == true && p.abde > 0).ToList();
       }
     
       public static List<Busers2> QryNguoiDuyets()
       {
           var list = (from p in db.BDepartments
                       from q in db.Busers2s
                       where (p.ID == q.BADEPID  && q.isSep == true)
                       select q).ToList();
           return list;
       }
       public static List<Busers2> LayDSNguoiDuyet()
       {
           var list = from q in db.Busers2s where (q.isSep == true && q.abde > 1 ) orderby q.abde ascending select q;
           return list.ToList();
       }
       public static List<Busers2> LayDSNguoiDuyetCap1()
       {
           return db.Busers2s.Where(p => p.isSep == true && p.abde ==1 && p.abstep==1).ToList();
       }
       public static Busers2 QryNguoiDuyetTheoBoPhanCapDuyet1(string mabophan)
       {
           var list = (from p in db.BDepartments
                       from q in db.Busers2s
                       where (p.ID == q.BADEPID && q.BADEPID==mabophan && q.isSep == true && q.abde==1 )
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoBoPhanCap1(string mabophan,string idcongty)
       {
           var list = (from p in db.BDepartments
                       from q in db.Busers2s
                       where (p.ID == q.BADEPID && q.BADEPID == mabophan && q.isSep == true && q.abde == 1 && q.GSBH==idcongty)
                       select q).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet1()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 1)
                       select q).FirstOrDefault();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet2()
       {
           var list = ( from q in db.Busers2s
                       where ( q.isSep == true && q.abde == 2)
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyet2()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 2)
                       select q).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet3()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 3)
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyet3()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 3)
                       select q).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet4()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 4)
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyet4()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 4)
                       select q).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet5()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 5)
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyet5()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 5)
                       select q).ToList();
           return list;
       }
       public static Busers2 LayNguoiDuyetTheoCapDuyet6()
       {
           var list = (from q in db.Busers2s
                       where (q.isSep == true && q.abde == 6)
                       select q).FirstOrDefault();
           return list;
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyet(string congty,string bophan)
       {
           
          //return db.Busers.Where(p => p.isSep == true && p.abstep > 1).ToList();
           var list = (from p in db.BDepartments
                       from q in db.Busers2s
                       where (p.ID == q.BADEPID && q.GSBH==congty &&q.BADEPID == bophan && q.isSep == true && q.abstep>0)
                       select q).ToList();
           return list;
         
       }
       public static List<Busers2> QryNguoiDuyetTheoCapDuyets(string congty)
       {

           //return db.Busers.Where(p => p.isSep == true && p.abstep > 1).ToList();
           var list = (from q in db.Busers2s
                       where ( q.GSBH == congty  && q.isSep == true && q.abstep > 0)
                       select q).ToList();
           return list;

       }
       public static Busers2 TimNhanVienTheoMa(string manhanvien,string macongty)
       {
           return db.Busers2s.Where(p => p.USERID == manhanvien && p.GSBH==macongty).FirstOrDefault();
       }
       public static Busers2 KiemTraMatKhauXetDuyetCuaNguoiDuyet(string manhanvien, string macongty,string matkhau2)
       {
           return db.Busers2s.Where(p => p.USERID == manhanvien && p.GSBH == macongty && p.Password2==matkhau2).FirstOrDefault();
       }
       public static Busers2 TimNhanVienTheoMaVaBoPhan(string manhanvien,string mabophan, string macongty)
       {
           return db.Busers2s.Where(p => p.USERID == manhanvien && p.BADEPID==mabophan && p.GSBH == macongty).FirstOrDefault();
       }
       public static Busers2 TimKiemNhanVien_MaBaoMatTheoIDNhanVien(string idNhanVien)
       {

           try
           {
              
                   return db.Busers2s.Where(cd => cd.USERID == idNhanVien ).FirstOrDefault();
             
           }
           catch (Exception ex)
           {
               Until.WriteFileLogServer("TimKiemNhanVien_MaBaoMatTheoIDNhanVien_Ngay\t\t" + "\tMessage Error:\t\t" + ex.Message);
               return new Busers2();
           }
           finally
           {
               if (db != null)
                   db.ToString();
           }
       }

       public static Busers2 TimMaNhanVienTheoBoPhan(string idnhanvien, string idbophan,string macongty)
       {
           var list = (from p in db.Busers2s
                       from h in db.BDepartments
                       where (p.BADEPID == h.ID && p.USERID == idnhanvien && p.BADEPID == idbophan && p.GSBH==macongty)
                       select p).FirstOrDefault();
           return list;
       }
       public static Busers2 TimNhanVienQuanLyDonVi(string manhanvien, string madonvi, string macongty)
       {
           var list = (from p in db.Busers2s
                       from h in db.BDepartments
                       where ( p.USERID==h.IdUserChuQuan && p.USERID == manhanvien && h.ID == madonvi && p.GSBH==macongty)
                       select p).FirstOrDefault();
           return list;
       }
       public static Busers2 KiemTraNguoiDuyetTheoPhongBan(string idnhanvien)
       {

           var list = (from q in db.BDepartments
                       from h in db.Busers2s
                       where (q.ID == h.BADEPID && h.USERID == idnhanvien)
                       select h).FirstOrDefault();
           return list;
       }
       public static List<Busers2> LayNhanVienTheoBoPhan(string mabophan, string macongty)
       {
           var list = (from p in db.Busers2s
                       from h in db.BDepartments
                       where (p.BADEPID == h.ID && p.BADEPID == mabophan && p.GSBH==macongty)
                       select p).ToList();
           return list;
       }
       public static List<Busers2> LayNhanVienTheoCongTy( string macongty)
       {

           return db.Busers2s.Where(p => p.GSBH == macongty).ToList();
       }
       public static Busers2 LayNguoiChuQuanDuyetTheoBoPhan(string idbophan, string idchuqua, string macongty)
       {
           var list = from p in db.Busers2s
                      from q in db.ChucVus
                      where (p.IDChucVu == q.IDChucVu && p.IDChucVu == idchuqua && p.BADEPID == idbophan && p.GSBH==macongty)
                      select p;
           return list.FirstOrDefault();
       
      }
       public static Busers2 LayNguoiDuyetTheoChucVu(string idchucvu, string macongty)
       {
           var list = from p in db.Busers2s
                      from q in db.ChucVus
                      where (p.IDChucVu == q.IDChucVu && p.IDChucVu == idchucvu && p.GSBH==macongty )
                      select p;
           return list.FirstOrDefault();
       }
       public static Busers2 LayNguoiDuyetTheoMaNguoiDuyet(string manguoiduyet, string macongty)
       {
           var list = from p in db.Busers2s where p.USERID == manguoiduyet && p.GSBH==macongty select p;
           return list.FirstOrDefault();
       }
       public static Busers2 TimMaNhanVienTaoPhieu(string manhanvien, string macongty)
       {
           try
           {
               var list = (from p in db.Busers2s
                           from q in db.pdnas
                           where (p.GSBH == macongty && p.USERID == q.CFMID0 && q.CFMID0 == manhanvien)
                           select p).FirstOrDefault();
               return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static Busers2 TimMaNhanVienDich(string manhanvien, string macongty)
       {
           try
           {
               var list = (from p in db.Busers2s
                           where (p.GSBH == macongty &&  p.USERID == manhanvien)
                           select p).FirstOrDefault();
               return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static Busers2 LayNguoiDuyetTheoMaChucVuPhongBan(string machucvu, string maphong, string macongty)
       {
           try
           {
               var list = (from p in db.ChucVus
                           from q in db.BDepartments
                           from h in db.Busers2s
                           where (p.IDChucVu == h.IDChucVu && q.ID == h.BADEPID && h.BADEPID == maphong && h.GSBH == macongty && h.IDChucVu == machucvu)
                           select h).SingleOrDefault();
               return list;
               //var list =  (from h in db.Busers
               //            where (h.BADEPID == maphong && h.GSBH == macongty && h.IDChucVu == machucvu)
               //            select h).SingleOrDefault();
               //return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static Busers2 LayNguoiDuyetTheoMaChucVuCao(string machucvu, string manguoiduyet, string macongty, string mabophanquanly)
       {
           try
           {
               var list = (from p in db.ChucVus
                         //  from q in db.CanBoDonVis
                           from h in db.Busers2s
                           where (p.IDChucVu == h.IDChucVu && h.USERID == manguoiduyet && h.IDChucVu == machucvu && h.GSBH == macongty )
                           select h).FirstOrDefault();

               return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       public static List<Busers2> HienThiDanhSachNguoiDich(string idbophan,string macongty)
       {
           try
           {
               var list = (from p in db.BDepartments
                           from q in db.Busers2s
                           where (p.ID == q.BADEPID && q.BADEPID == idbophan && q.GSBH==macongty)
                           select q).ToList();
               return list;
           }
           catch (Exception)
           {
               throw;
           }
       }
       
    }
}