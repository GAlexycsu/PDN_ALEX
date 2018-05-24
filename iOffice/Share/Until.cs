using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Net.Mime;
using iOffice.DTO;
using iOffice.BUS;
using Limilabs.Mail;
using Limilabs.Client.POP3;
using System.Text.RegularExpressions;
using OpenPop.Pop3;
using iOffice.DAO;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Configuration;
    public class Until
    {
        public static string conten = "";
        public static string path = "";
      
        
       static List<string> lsnguoi = new List<string>();
       static List<string> lsnguoi1 = new List<string>();
        public static List<Abcon> dscap = new List<Abcon>();
        public  Busers2 uNhanVien;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        public static bool SendMail(string listmail, string subject, string body, string ccmail)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("ngoclien219@gmail.com", "[tyhung]", Encoding.UTF8);
                if (ccmail != null)
                    msg.CC.Add(new MailAddress(ccmail));
                if (conten != null)
                {
                    Attachment data = null;
                    data = new Attachment(conten);
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(conten);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(conten);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(conten);

                    msg.Attachments.Add(data);
                }
                
                msg.To.Add(new MailAddress(listmail));
                msg.Subject = subject;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.Body = body;
                msg.BodyEncoding = Encoding.UTF8;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                msg.Priority = MailPriority.High;
                // configuration mail server
                SmtpClient client = new SmtpClient("mail.feetgear.com.vn", 25);
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("ngoclien219@gmail.com", "thuatnguyen123");
               
                client.SendAsync(msg, new object());
                return true;
            }
            catch (Exception)
            {
                return false;


            }

        }
        public static bool SendMailss(string listmail, string subject, string body, string ccmail)
        {
            MailMessage mail = new MailMessage("tuan-it@footgear.com.vn", listmail);
           
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);
            return true;
        }
        public static bool SendMailNguoiDuyet(string from_mail,string listmail, string subject, string body)
        {
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        public static bool SendMailNguoiDuyetPhieu(string from_mail, string listmail, string subject, string body,string linkDuyet,string LinkKhongDuyet)
        {
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            
            client.Send(mail);
            return true;
        }
        public static bool SendMailNguoiTao(string from_mail, string listmail, string subject, string body)
        {
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        public static bool SendMailNguoiDich(string from_mail, string listmail, string subject, string body, string UserID, string GSBH, string NgonNgu)
        {
               string alink1 = ConfigurationManager.AppSettings["SetupLink"].ToString();
           // string k="http://"+alink1+"/NguoiDich/danhsachphieuchuadich.aspx";

               string linkDich = "<a href=\"http://" + alink1 + "/NguoiDich/danhsachphieuchuadichND.aspx" + "?UserID=" + "" + UserID + "" + "&GSBH=" + "" + GSBH + "" + "&languege=" + NgonNgu + "\">Click Here</a>" + "\n" + " <br/>";
           // string linkPDN = "<a href=\"http://" + alink1 + "/NguoiDich/danhsachphieuchuadich.aspx" + "" + "\">Click here</a>"; ;
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
           // mail.Body = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx"+"?UserIT="+"" + userid + ""+"&GSBH="+""+congty+""+"&pdno="+""+pdno+"\">Jon Doe</a>";
            //mail.Body = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\">Jon Doe</a>";
            //mail.Body = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\">Jon Doe</a>";
            mail.Body = body+ "<\n><br/>"+linkDich;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        public static bool SendMailYKienToiNguoiTaoPhieu(string from_mail, string listmail, string subject, string body, string UserID, string GSBH, string NgonNgu)
        {
            string alink1 = ConfigurationManager.AppSettings["SetupLink"].ToString();
            // string k="http://"+alink1+"/NguoiDich/danhsachphieuchuadich.aspx";

            string linkDich = "<a href=\"http://" + alink1 + "/NguoiDich/danhsachphieuchuadichND.aspx" + "?UserID=" + "" + UserID + "" + "&GSBH=" + "" + GSBH + "" + "&languege=" + NgonNgu + "\">Click Here</a>" + "\n" + " <br/>";
            // string linkPDN = "<a href=\"http://" + alink1 + "/NguoiDich/danhsachphieuchuadich.aspx" + "" + "\">Click here</a>"; ;
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            // mail.Body = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx"+"?UserIT="+"" + userid + ""+"&GSBH="+""+congty+""+"&pdno="+""+pdno+"\">Jon Doe</a>";
            //mail.Body = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\">Jon Doe</a>";
            //mail.Body = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\">Jon Doe</a>";
            mail.Body = body + "<\n><br/>" + linkDich;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        public static bool SendMailAndApproval(string from_mail, string listmail, string subject, string body)
        {
            MailMessage mail = new MailMessage(from_mail, listmail);

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.footgear.com.vn";
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
            return true;
        }
        public static string SendMail(string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            try
            {
                string senderID = "ngoclien219@gmail.com";// use sender's email id here..
                const string senderPassword = "tuan123"; // sender password here...
                SmtpClient smtp = new SmtpClient
                {
                    Host = "mail.feetgear.com.vn", // smtp server address here...
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 60000,

                };
                MailMessage message = new MailMessage(senderID, toAddress, subject, body);

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!\n" + ex.Message;
            }
            return result;
        }
       
        #region Receive Mail

        public static List<IMail> GetListReceiveMail()
        {
            List<IMail> lstMail = new List<IMail>();
            try
            {
                using (Pop3 pop3 = new Pop3())
                {
                    pop3.Connect("mail.feetgear.com.vn");  // or ConnectSSL for SSL      
                    pop3.UseBestLogin("mail.feetgear.com.vn", "123456");

                    List<string> uids = pop3.GetAll();
                    foreach (string uid in uids)
                    {
                        IMail email = new MailBuilder()
                            .CreateFromEml(pop3.GetMessageByUID(uid));
                        if (!email.Subject.Equals("Please purchase Mail.dll license at http://www.limilabs.com/mail"))
                        {
                            lstMail.Add(email);
                            pop3.DeleteMessageByUID(uid);
                        }

                    }
                    pop3.Close();
                }
                return lstMail;
            }
           
            catch (Exception )
            {
                
                return lstMail;
            }
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source.Replace("\n", Environment.NewLine), "<.*?>", Environment.NewLine);
        }

        public static string AnalysisTitleMail(string title)
        {
            try
            {
                string result = "";
                if (title.Equals("Please purchase Mail.dll license at http://www.limilabs.com/mail"))
                {
                    return result;
                }
                if (title.Length > 0)
                {
                    string[] arrString = title.Split(']');
                    if (arrString.Count() > 1)
                        result = arrString[1].Substring(1);
                }
                return result;
            }
           
            catch (Exception )
            {
                //Util.WriteFileLog("Excep\t AnalysisTitleMail: " + ex);
                return "";
            }
        }

        #endregion

        public static List<string> CapNhatChiTietDuyet(Abcon chMax, bool duyet, string ghichu, bool barCode = false)
        {


            try
            {
                List<string> kqua = new List<string>();
                DateTime date = DateTime.Now;
                Busers2 nv_mbm = UserDAO.TimKiemNhanVien_MaBaoMatTheoIDNhanVien(chMax.Auditor);
                string chuoimahoa = null;
                string st = null;
                string ngaythang = null;
                string gio = null;
                if (nv_mbm != null)
                {
                    st = nv_mbm.Password2;
                    ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    gio = DateTime.Parse(date.ToLongTimeString()).ToString("HH:mm:ss");
                    chuoimahoa = ngaythang + "*" + gio + "*" + chMax.pdno + "*" + chMax.Auditor;
                    kqua.Add(st);
                    kqua.Add(chuoimahoa);
                    kqua.Add(ngaythang);
                    kqua.Add(gio);
                }
                else
                    return null;
                chMax.abrult = duyet;
                if (duyet)
                {
                    chMax.abmomo += String.Format("{0} {1}: {2}  - [DUYỆT] {3} ", Environment.NewLine, DateTime.Now.ToString("HH:mm dd/MM/yyyy"), Environment.NewLine, ghichu);
                    
                        //InsertChuKy(chMax.VanBan_CapDuyet.VanBan.DuongDanGoc, duyet, "LEANERPCK" + (chMax.VanBan_CapDuyet.IdCapDuyet < 9 ? "0" : "") + chMax.VanBan_CapDuyet.IdCapDuyet, chMax.VanBan_CapDuyet.VanBan.LoaiFile, chMax.VanBan_CapDuyet.VanBan.DuongDanXuLy, chMax.NhanVien.ChuKy, EncryptionChuoi(chuoimahoa, st), barCode);
                }
                else
                    chMax.abmomo += String.Format("{0} {1}: {2}  - [KHÔNG DUYỆT] {3} ", Environment.NewLine, DateTime.Now.ToString("HH:mm dd/MM/yyyy"), Environment.NewLine, ghichu);
                return kqua;
            }
            
            catch (Exception ex)
            {
                Until.WriteFileLogServer("Excep\t CapNhatChiTietDuyet: " + ex);
                return null;
            }
        }
        public static List<string> CapNhatChiTietDuyetQuaMail(Abcon chMax, bool duyet, string ghichu, bool barCode = false)
        {


            try
            {
                List<string> kqua = new List<string>();
                DateTime date = DateTime.Now;
                Busers2 nv_mbm = UserDAO.TimKiemNhanVien_MaBaoMatTheoIDNhanVien(chMax.Auditor);
                string chuoimahoa = null;
                string st = null;
                string ngaythang = null;
                string gio = null;
                if (nv_mbm != null)
                {
                    st = nv_mbm.Password2;
                    ngaythang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    gio = DateTime.Parse(date.ToLongTimeString()).ToString("HH:mm:ss");
                    chuoimahoa = ngaythang + "*" + gio + "*" + chMax.pdno + "*" + chMax.Auditor;
                    kqua.Add(st);
                    kqua.Add(chuoimahoa);
                    kqua.Add(ngaythang);
                    kqua.Add(gio);
                }
                else
                    return null;
                chMax.abrult = duyet;
                if (duyet)
                {
                    chMax.abmomo += String.Format("{0} {1}: {2}  - [DUYỆT] {3} ", Environment.NewLine, DateTime.Now.ToString("HH:mm dd/MM/yyyy"), Environment.NewLine, ghichu);

                    //InsertChuKy(chMax.VanBan_CapDuyet.VanBan.DuongDanGoc, duyet, "LEANERPCK" + (chMax.VanBan_CapDuyet.IdCapDuyet < 9 ? "0" : "") + chMax.VanBan_CapDuyet.IdCapDuyet, chMax.VanBan_CapDuyet.VanBan.LoaiFile, chMax.VanBan_CapDuyet.VanBan.DuongDanXuLy, chMax.NhanVien.ChuKy, EncryptionChuoi(chuoimahoa, st), barCode);
                }
                else
                    chMax.abmomo += String.Format("{0} {1}: {2}  - [KHÔNG DUYỆT] {3} ", Environment.NewLine, DateTime.Now.ToString("HH:mm dd/MM/yyyy"), Environment.NewLine, ghichu);
                return kqua;
            }

            catch (Exception ex)
            {
                Until.WriteFileLogServer("Excep\t CapNhatChiTietDuyet: " + ex);
                return null;
            }
        }
        //#region Xử lý và xét duyệt qua mail
        //public void ExecuteMailWithOpenPop()
        //{


        //    String errorMsg = "";
        //    try
        //    {

        //        using (Pop3Client client = new Pop3Client())
        //        {
        //            // Connect to the server
        //            client.Connect("mail.feetgear.com.vn", 110, false);

        //            // Authenticate ourselves towards the server
        //            client.Authenticate("mail.feetgear.com.vn", "123456");

        //            // Fetch all the current uids seen
        //            List<string> uids = client.GetMessageUids();
        //            // All the new messages not seen by the POP3 client
        //            for (int i = 0; i < uids.Count; i++)
        //            {
        //                MailMessage mail = client.GetMessage(i + 1).ToMailMessage();


        //                try
        //                {
        //                     string idnhanvien="";

        //                      string id = Until.AnalysisTitleMail(mail.Subject);
        //                        System.Nullable<bool> duyet = null;
        //                        string str = Until.StripTagsRegex(mail.Body);
        //                        string[] body = str.Split(new string[] { Environment.NewLine, Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //                        if (body.Count() >= 1)
        //                        {
        //                            string temp = "";
        //                            if (body[0].Contains(':'))
        //                                temp = body[0].Substring(0, body[0].IndexOf(':'));
        //                            else
        //                                temp = body[0].ToString();
        //                            duyet = temp.ToUpper().Equals("YES") ? true : temp.ToUpper().Equals("NO") ? false : duyet;

        //                            if (id.StartsWith(MACHITIETXETDUYET))
        //                            {
        //                                Abcon ctxd = AbconDAO.TimKiemChiTietXetDuyetTheoMa(id, true);
        //                               Buser us=UserBUS.SearchUserByID(idnhanvien,true);
        //                                pdna pd=pnaDAO.LayNoiDungCuaVanBan(id,true);
        //                                if (ctxd != null && us.EMAIL.Equals(mail.From.Address))
        //                                {
        //                                    if (!ctxd.abrult.Equals(null))
        //                                    {
        //                                        String noidung = "- Mã văn bản: " + ctxd.pdno + "\n";
        //                                        noidung += "- Tiêu đề: " + ctxd.Maintitle + "\n";
        //                                        noidung += "- Mô tả: " + ctxd.abmomo + "\n";
        //                                        //noidung += "- Ngày tạo: " + ctxd.VanBan_CapDuyet.VanBan.NgayTao.Value.ToShortDateString() + "\n";

        //                                        noidung += "- Người duyệt: " + ctxd.Auditor + "\n";
        //                                        Until.SendMail(us, "Hiện tại bạn đã XÉT DUYỆT cho văn bản rồi " + ctxd.pdno + " với tình trạng là " + (ctxd.abrult.Value? "[ĐÃ DUYỆT]" : "[KHÔNG DUYỆT]"), noidung + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");

        //                                    }
        //                                    else
        //                                    {
        //                                        if (duyet != null)
        //                                        {

        //                                            ctxd.abrult = duyet;
        //                                            ctxd.abmomo += body[0].Substring(body[0].IndexOf(':') + 1);
        //                                            Until.XetDuyet(ctxd.pdno,us, ctxd.abrult.Value, ctxd.abmomo);

        //                                            String noidung = "- Mã văn bản: " + ctxd.pdno + "\n";
        //                                            noidung += "- Tiêu đề: " + ctxd.Maintitle + "\n";

        //                                            //noidung += "- Ngày tạo: " + ctxd.Equals(us).VanBan.NgayTao.Value.ToShortDateString() + "\n";
        //                                            noidung += "- Người duyệt: " + ctxd.Auditor + "\n";
        //                                            Util.SendMail(ctxd.Equals(c), "XÉT DUYỆT THÀNH CÔNG cho văn bản " + ctxd.VanBan_CapDuyet.IdVanBan + " với lựa chọn " + (duyet.Value ? "DUYỆT" : "KHÔNG DUYỆT"), noidung + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                        }
        //                                        else
        //                                        {

        //                                            Util.SendMail(ctxd.NhanVien.Email, "SAI CÚ PHÁP XÉT DUYỆT CHO " + ctxd.VanBan_CapDuyet.IdVanBan, " - Cú pháp đúng: " + Environment.NewLine + "\t YES(NO):Ý kiến của bạn" + Environment.NewLine + " - Ví dụ nếu bạn muốn duyệt văn bản với ghi chú là 'OK duyệt':" + Environment.NewLine + "\t YES:OK duyệt." + Environment.NewLine + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                            //return;
        //                                        }
        //                                    }

        //                                }
        //                                else
        //                                {
        //                                    Util.SendMail(mail.From.Address, "Văn bản đã bị xóa hoặc bạn không có quyền xét duyệt.", "Thanks." + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                }
        //                            }
        //                            else if (id.StartsWith(MACHITIETUYQUYEN))
        //                            {
        //                                ChiTietUyQuyen ctuq = ChiTietUyQuyenDAO.TimChiTietUyQuyenTheoMa(id, true);
        //                                if (ctuq != null && ctuq.UyQuyen.NhanVien.Email.Equals(mail.From.Address))
        //                                {
        //                                    if (ctuq.Duyet.Equals(null) && duyet != null)
        //                                    {
        //                                        ctuq.Duyet = duyet;
        //                                        ctuq.GhiChu += body[0].Substring(body[0].IndexOf(':') + 1);

        //                                        List<myChiTietUyQuyen> lstMyChiTietUyQuyen = ChiTietUyQuyenDAO.QrymyChiTietUyQuyen(1, true).ToList();
        //                                        List<myChiTietUyQuyen> userDuocUyQuyens = (from ctuqnv in lstMyChiTietUyQuyen
        //                                                                                   where ctuqnv.m_IdVanBan == ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdVanBan && ctuqnv.m_IdNhanVien == ctuq.UyQuyen.IdNguoiDuocUyQuyen && ctuqnv.m_Duyet == 0

        //                                                                                   select ctuqnv).ToList();
        //                                        foreach (myChiTietUyQuyen userDuocUyQuyen in userDuocUyQuyens)
        //                                        {
        //                                            Util.XetDuyetUyQuyen(userDuocUyQuyen, ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdVanBan, ctuq.UyQuyen.NhanVien, ctuq.Duyet.Value, ctuq.GhiChu);
        //                                        }
        //                                        String noidung = "- Mã văn bản: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.IdVanBan + "\n";
        //                                        noidung += "- Tiêu đề: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TieuDe + "\n";
        //                                        noidung += "- Mô tả: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.MoTa + "\n";
        //                                        noidung += "- Ngày tạo: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.NgayTao.Value.ToShortDateString() + "\n";
        //                                        noidung += "- Người duyệt: " + ctuq.ChiTietXetDuyet.NhanVien.HoTen + "\n" + "(Được ủy quyền từ " + ctuq.UyQuyen.NhanVien.HoTen + ")";
        //                                        Util.SendMail(ctuq.UyQuyen.NhanVien.Email, "XÉT DUYỆT THÀNH CÔNG CHO VĂN BẢN " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdVanBan + " với lựa chọn " + (duyet.Value ? "DUYỆT" : "KHÔNG DUYỆT"), noidung + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                    }
        //                                    else
        //                                        if (!ctuq.Duyet.Equals(null))
        //                                        {
        //                                            String noidung = "- Mã văn bản: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.IdVanBan + "\n";
        //                                            noidung += "- Tiêu đề: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.TieuDe + "\n";
        //                                            noidung += "- Mô tả: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.MoTa + "\n";
        //                                            noidung += "- Ngày tạo: " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.VanBan.NgayTao.Value.ToShortDateString() + "\n";
        //                                            noidung += "- Người duyệt: " + ctuq.UyQuyen.NhanVien.HoTen + "\n";
        //                                            Util.SendMail(ctuq.UyQuyen.NhanVien.Email, "Hiện tại bạn đã XÉT DUYỆT cho văn bản rồi " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdVanBan + " với tình trạng là " + (ctuq.Duyet.Value ? "[ĐÃ DUYỆT]" : "[KHÔNG DUYỆT]"), noidung + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");

        //                                        }
        //                                        else
        //                                        {
        //                                            Util.SendMail(ctuq.UyQuyen.NhanVien.Email, "SAI CÚ PHÁP XÉT DUYỆT CHO " + ctuq.ChiTietXetDuyet.VanBan_CapDuyet.IdVanBan, " - Cú pháp đúng: " + Environment.NewLine + "\t YES(NO):Ý kiến của bạn" + Environment.NewLine + " - Ví dụ nếu bạn muốn duyệt văn bản với ghi chú là 'OK duyệt':" + Environment.NewLine + "\t YES:OK duyệt." + Environment.NewLine + Environment.NewLine + "Thanks" + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                            //return;
        //                                        }

        //                                }
        //                                else
        //                                {
        //                                    Util.SendMail(mail.From.Address, "Văn bản đã bị xóa hoặc bạn không có quyền xét duyệt.", "Thanks." + Environment.NewLine + "LEAN-ERP SYSTEM");
        //                                }
        //                            }
        //                        }
        //                    }
        //                    client.DeleteMessage(i + 1);
        //                }
        //                catch (Exception ex1)
        //                {
        //                    errorMsg += (Environment.NewLine + "Error in mail: " + mail.Subject + Environment.NewLine + ex1.Message);
        //                }
        //            }



        //    }
        //    catch (Exception)
        //    {
        //        //MessageBox.Show(this, "Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    //MessageBox.Show(this, "Done with error: " + Environment.NewLine + errorMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private static void SendMail(Buser us, string p1, string p2)
        //{
        //    throw new NotImplementedException();
        //}
        //#endregion
        #region Xét duyệt

        public static void XetDuyet(string idVanBanHienHanh, Busers2 nhanVienHienHanh, bool duyet, string ghichu, string macongty)
        {
            try
            {
               // string alink = "http://localhost:3530/presentationLayer";
                string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
                int Yn;
                if(duyet==true)
                {
                    Yn=1;
                }
                else
                {
                    Yn=2;
                }
                int YnHoanThanh = 8;
                dalPDN dal = new dalPDN();
                DataTable dt = dal.QryChiTietMuaHang(macongty, idVanBanHienHanh);
                string strBody = "<html>" +
                      " <head>" +
                       "<style>" +
                       "table, th, td {" +
                          " border: 1px solid black;" +
                           "border-collapse: collapse" +
                       "}" +
                       "th, td {" +
                        "   padding: 5px;" +
                         " text-align: center;" +
                       "}" +
                       "</style>" +
                       "</head>" +
                       "<body>" +
                       "<table style=" + " float:left;border: 1px solid black;border-collapse: collapse;>" +
                      "<tr style=" + "text-align: center;>" +
                      "<td>TÊN HÀNG 品名 </td> " +
                      "<td>Size </td>" +
                       " <td>QUY CÁCH- CHỦNG LOAI 規格  </td> " +
                      " <td>Số Lượng 數量 </td> " +
                      " <td>Ghi Chú 備註 </td></tr> " +
                      "<br/>";

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //pdn.Size, cl.dwbh, pdn.Qty,pdn.CLmemo,pdn.Memo0
                        strBody = strBody + "<tr><td>" + dr["Memo0"].ToString() + "</td>";// ten hang
                        strBody = strBody + "<td>" + dr["Size"].ToString() + "</td>";// Size
                        strBody = strBody + "<td>" + dr["dwbh"].ToString() + "</td>";// Quy cachs
                        strBody = strBody + "<td>" + dr["Qty"].ToString() + "</td>";// so luong
                        strBody = strBody + "<td>" + dr["CLmemo"].ToString() + "</td></tr>";
                    }
                }
                strBody += " </table> </body></html>";
                string beginDiv = "<div style=\"border-style: solid; border-color: inherit; width:600px; border-width:1px;\"" + "><br/>";
                string endDiv = "</div> <br/>";
                Dictionary<bool, Abcon> capDangDuyet = pnaDAO.LayCapDangDuyetCuaVanBan1(idVanBanHienHanh, nhanVienHienHanh.USERID,macongty, true, true);
                Abcon cd = capDangDuyet.First().Value;
                //abill1 capDuyetCuaNhanVien = UserDAO.LayCapDuyetCuaNhanVien(nhanVienHienHanh.USERID, idVanBanHienHanh);
                List<Abcon> lstChiTietXetDuyet1 = AbconBUS.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(idVanBanHienHanh,macongty);
                int max = (from ct1 in lstChiTietXetDuyet1
                           select ct1.Abstep).Max();
                List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                pdna vb = pnaDAO.TimVanBanTheoMa(idVanBanHienHanh,macongty, true);
                Busers2 nvkt = UserDAO.LayNhanVienKhoiTaoCuaVanBan(idVanBanHienHanh, true);
                List<Abcon> nguoiduyettrong1cap = AbconBUS.QryNguoiDuyetTrongCung1Cap(idVanBanHienHanh, cd.Abstep);
                int maxABPS = (from a in nguoiduyettrong1cap select a.abps).Max();
                int minASPS = (from a in nguoiduyettrong1cap select a.abps).Min();
                if (cd.Abstep == 1 && cd.abrult==false)
                {
                       List<string> kq = CapNhatChiTietDuyet(cd, duyet, ghichu, true);
                       AbconDAO.SuaChiTiet1(cd, nhanVienHienHanh.USERID,ghichu, duyet, true);
                     
                     // Cap nhat tinh trang xet duyet cho van ban
                    // pnaDAO.CapNhatTinhTrangVanBan(idVanBanHienHanh, (duyet) ? 1 : 2, true);

                     if (kq != null)
                     {
                         string thoigian = kq[3] + " " + kq[2];

                         string thongtin = duyet ? "ĐÃ ĐƯỢC DUYỆT 接受" : "KHÔNG ĐƯỢC DUYỆT 拒絕";
                         string noidung = "- Mã văn bản-单号-TicketNo: " + vb.pdno + "<br/>";
                         noidung += "- Tiêu đề 题目-Subject: " + vb.mytitle + "<br/>";

                         noidung += "- Ngày tạo 创建于-Date: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                         noidung += "- Người duyệt 审核者-Auditor: " + nhanVienHienHanh.USERNAME + "<br/>";
                         noidung += "- Nội dung phiếu-Content:" + vb.pdmemovn + "<br />";
                         noidung += "- Nội dung phiếu dịch-Translated-Content:" + vb.NoiDungDich + "<br />";
                         
                         Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản ",beginDiv+thongtin+ noidung+endDiv);
                         if (duyet)
                         {
                             
                                 if (cd.abps != 0)
                                 {
                                     if (cd.abps < maxABPS)
                                     {
                                         Abcon ab = AbconDAO.TimBuocKeTiepTrongCung1CapDuyet(idVanBanHienHanh, macongty, cd.Abstep, cd.abps+1);
                                         BDepartment bp = BDepartmentDAO.TimMaDonVi(ab.from_depart, macongty);
                                         abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                         Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(ab.Auditor, ab.Gsbh);
                                         string languege = "lbl_TW";
                                         string linkPDN = "<a href=\"http://"+alink+"/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                         string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                         string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                         string linkKhongDuyet = "<a href=\"http://"+alink+"/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                         string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                         noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                         noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                                         noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                         noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                         noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                         noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                         noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";

                                         if (duyet)
                                         {
                                             dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                             if (vb.Abtype == "PDN2")
                                             {
                                                 Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + ab.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                             }
                                             else
                                             {
                                                 Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + ab.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                             }

                                         }
                                         else
                                         {

                                             Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                             ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                             TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                             dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                                             
                                         }
                                     }// nguoc lai buoc ke tiep = buoc hien tai
                                     else
                                     {
                                         if (cd.abps == maxABPS)
                                         {
                                             // them moi tai day
                                             if (cd.Abstep == max)
                                             {
                                                 PDNSheetFlow PDNSheetFlow11 = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(idVanBanHienHanh, cd.Abstep);
                                                 PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow11, duyet);
                                                 ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                                 TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                 dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, YnHoanThanh, cd.Abstep, nhanVienHienHanh.USERID);
                                                 if (!duyet)
                                                 {
                                                     Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为 ", beginDiv + thongtin + noidung + endDiv);
                                                 }
                                             }
                                             else
                                             {
                                                 Abcon buocketiep = AbconBUS.LayBuocKeTiepCuaNhanVien(macongty, idVanBanHienHanh, cd.Abstep + 1, minASPS);
                                                 if (buocketiep.Abstep > cd.Abstep)
                                                 {
                                                     BDepartment bp = BDepartmentDAO.TimMaDonVi(buocketiep.from_depart, macongty);
                                                     abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                                     Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(buocketiep.Auditor, buocketiep.Gsbh);
                                                     string languege = "lbl_TW";
                                                     string linkPDN = "<a href=\"http://" + alink + "/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                     string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                     string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                                     string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                                     string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                                     noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                                     noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle + vb.pdnsubject + "<br/>";

                                                     noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                                     noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                                     noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                                     noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                                     noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";

                                                     if (duyet)
                                                     {
                                                         dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                                         if (vb.Abtype == "PDN2")
                                                         {
                                                             Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + buocketiep.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                                         }
                                                         else
                                                         {
                                                             Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + buocketiep.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                                         }

                                                     }
                                                     else
                                                     {

                                                         Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                                         ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                                         TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                         dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn, cd.Abstep, nhanVienHienHanh.USERID);
                                                     }
                                                 }
                                             }
                                         }
                                     }

                                     
                                 }// chi co 1 nguoi duyet trong cung 1 cap
                                 else
                                 {
                                     Abcon laybuocke = AbconBUS.LayBuocKeTiepCuaNhanVienTrongCung1Cap(nhanVienHienHanh.USERID, idVanBanHienHanh, cd.Abstep+1, minASPS);
                                     if (laybuocke.Abstep >= cd.Abstep)
                                     {
                                         BDepartment bp = BDepartmentDAO.TimMaDonVi(laybuocke.from_depart, macongty);
                                         abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                         Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(laybuocke.Auditor, laybuocke.Gsbh);
                                         string languege = "lbl_TW";
                                         string linkPDN = "<a href=\"http://" + alink + "/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                         string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                         string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                         string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                         string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                         noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                         noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle + vb.pdnsubject + "<br/>";

                                         noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                         noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                         noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                         noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                         noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";
                                         if (duyet)
                                         {
                                             dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                             if (vb.Abtype == "PDN2")
                                             {
                                                 Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + laybuocke.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                             }
                                             else
                                             {
                                                 Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + laybuocke.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                             }

                                         }
                                         else
                                         {

                                           
                                             Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                             ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                             TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                             dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                                         }
                                     }
                                 }

                                
                                 PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(idVanBanHienHanh, cd.abps);
                                 PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                 //ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                 //TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                            

                         }
                         else
                         {
                             PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(idVanBanHienHanh, cd.abps);
                             PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                             ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                             TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                             dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                         }
                         
                     }
                }// buoc duyet > 1 keke
                else
                {
                    
                    List<string> kq = CapNhatChiTietDuyet(cd, duyet, ghichu, true);
                    AbconDAO.SuaChiTiet1(cd, nhanVienHienHanh.USERID,ghichu, duyet, true);
                
                    // Cap nhat tinh trang xet duyet cho van ban
                   // pnaDAO.CapNhatTinhTrangVanBan(idVanBanHienHanh, (duyet) ? 1 : 2, true);

                    if (kq != null)
                    {


                        //string thoigian = kq[3] + " " + kq[2];

                        //List<Abcon> lstVanBanDen = AbconDAO.TimKiemVanBanDen(vb.pdno, vb.CFMID0, false).ToList();
                        //foreach (Abcon item in lstVanBanDen)
                        //{
                        //    if (duyet)
                        //        AbconDAO.CapNhatVanBanDen2(item);
                        //}

                      //  pnaDAO.UpdatePDNA(vb);

                        string thongtin = duyet ? "ĐÃ ĐƯỢC DUYỆT 已经审核" : "KHÔNG ĐƯỢC DUYỆT 未签"+"<br/>";
                        string noidung = "- Mã văn bản 单号 - TicketNo: " + vb.pdno + "<br/>";
                        noidung += "- Tiêu đề 题目- Subject: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                        noidung += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                        noidung += "- Người duyệt 审核者: " + nhanVienHienHanh.USERNAME + "<br/>";
                        noidung += "- Nội dung phiếu- Content:" + vb.pdmemovn + "<br />";
                        noidung += "- Nội dung phiếu dịch- Translated Content:" + vb.NoiDungDich + "<br />";

                        Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản ", beginDiv + thongtin + noidung + endDiv);
                        if (duyet)
                        {
                            
                                if (cd.Abstep == max)
                                {
                                    PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(idVanBanHienHanh, cd.Abstep);
                                    PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                    ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                    TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                    dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, YnHoanThanh,cd.Abstep,nhanVienHienHanh.USERID);
                                    if (!duyet)
                                    {
                                        Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为 ", beginDiv + thongtin + noidung + endDiv);
                                    }

                                }
                                else
                                {
                                    if (cd.abps != 0)
                                    {
                                        if (cd.abps < maxABPS)
                                        {
                                            Abcon ab = AbconDAO.TimBuocKeTiepTrongCung1CapDuyet(idVanBanHienHanh, macongty, cd.Abstep, cd.abps+1);
                                            BDepartment bp = BDepartmentDAO.TimMaDonVi(ab.from_depart, macongty);
                                            abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                            Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(ab.Auditor, ab.Gsbh);
                                            string languege = "lbl_TW";
                                            string linkPDN = "<a href=\"http://" + alink + "/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                            string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                            string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                            noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                            noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle + vb.pdnsubject + "<br/>";

                                            noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                            noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                            noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                            noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                            noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";

                                            if (duyet)
                                            {
                                                dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                                if (vb.Abtype == "PDN2")
                                                {
                                                    Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + ab.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                                }
                                                else
                                                {
                                                    Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + ab.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                                }

                                            }
                                            else
                                            {

                                                Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                                            }
                                        }// nguoc lai buoc ke tiep = buoc hien tai
                                        else
                                        {
                                            if (cd.abps == maxABPS)
                                            {
                                                Abcon buocketiep = AbconBUS.LayBuocKeTiepCuaNhanVien(macongty, idVanBanHienHanh, cd.Abstep + 1, minASPS);
                                                if (buocketiep.Abstep > cd.Abstep)
                                                {
                                                    BDepartment bp = BDepartmentDAO.TimMaDonVi(buocketiep.from_depart, macongty);
                                                    abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                                    Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(buocketiep.Auditor, buocketiep.Gsbh);
                                                    string languege = "lbl_TW";
                                                    string linkPDN = "<a href=\"http://" + alink + "/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                    string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                    string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                                    string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                                    string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                                    noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                                    noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle + vb.pdnsubject + "<br/>";

                                                    noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                                    noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                                    noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                                    noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                                    noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";

                                                    if (duyet)
                                                    {
                                                        dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                                        if (vb.Abtype == "PDN2")
                                                        {
                                                            Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + buocketiep.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                                        }
                                                        else
                                                        {
                                                            Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + buocketiep.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                                        }

                                                    }
                                                    else
                                                    {

                                                       
                                                        Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                                        ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                                        TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                        dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                                                    }
                                                }
                                            }
                                        }
                                    }// trong 1 cap duyet chi co 1 nguoi
                                    else
                                    {
                                        Abcon laybuocke = AbconBUS.LayBuocKeTiepCuaNhanVienTrongCung1Cap(nhanVienHienHanh.USERID, idVanBanHienHanh, cd.Abstep + 1, minASPS);
                                        if (laybuocke.Abstep >= cd.Abstep)
                                        {
                                            BDepartment bp = BDepartmentDAO.TimMaDonVi(laybuocke.from_depart, macongty);
                                            abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                            Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(laybuocke.Auditor, laybuocke.Gsbh);
                                            string languege = "lbl_TW";
                                            string linkPDN = "<a href=\"http://" + alink + "/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                            string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                            string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                            noidung2 = "- Mã văn bản 单号- TicketNo: " + vb.pdno + "<br/>";
                                            noidung2 += "- Tiêu đề 题目- Subject: " + vb.mytitle + vb.pdnsubject + "<br/>";

                                            noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                            noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                            noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                            noidung2 += "- Nội dung phiếu - Content - 内容:" + vb.pdmemovn + "<br />";
                                            noidung2 += "- Nội dung phiếu dịch -Translated-Content - 翻译内容:" + vb.NoiDungDich + "<br />";
                                            if (duyet)
                                            {
                                                dal.CapNhatLevel(idVanBanHienHanh, macongty, cd.Abstep, user.USERID);
                                                if (vb.Abtype == "PDN2")
                                                {
                                                    Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + laybuocke.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet + endDiv);

                                                }
                                                else
                                                {
                                                    Until.SendMailNguoiDuyet(nvkt.EMAIL, user.EMAIL, "[Ty Hung-eOffice][" + laybuocke.IDCT + "] Thông báo văn bản " + vb.mytitle + " đang chờ bạn duyệt.", beginDiv + noidung2 + linkPDN + linkDuyet + linkKhongDuyet + endDiv);

                                                }

                                            }
                                            else
                                            {

                                                Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản bị TẠM DỪNG do 本单暂时停用为", beginDiv + thongtin + noidung + endDiv);
                                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                                            }
                                        }
                                    }
                                   
                                }

                            
                          
                        }// neu khong duyet thi cap nhat trang thai duyet vap ban chi tiet buoc
                        else
                        {
                            PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(idVanBanHienHanh, cd.abps);
                            PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                            ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                            TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                            dal.CapNhatPhieuPDNA(idVanBanHienHanh, macongty, Yn,cd.Abstep,nhanVienHienHanh.USERID);
                        }
                       
                    }
                }

            }
            
            catch (Exception ex)
            {
                Until.WriteFileLogServer("Excep\t XetDuyet: " + ex);
                
            }
        }
        #endregion

        #region Trình duyệt văn bản
        public static void TrinhDuyet(string idVanBanHienHanh, pdna vbHienHanh, Busers2 uNhanVien, string macongty)
        {

            try
            {
                 string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
                vbHienHanh = pdnaBUS.TimVanBanTheoMa(idVanBanHienHanh,macongty, false);
               // Dictionary<bool, PDNA_ABDE> capDangDuyet = null;
               // if (vbHienHanh.LevelDoing == 0)
               //     capDangDuyet = pdnaBUS.LayCapDangDuyetCuaVanBan(idVanBanHienHanh, false, true);
               // else
               //     capDangDuyet = pdnaBUS.LayCapDangDuyetCuaVanBan(idVanBanHienHanh, null, true);
                    BDepartment bp = BDepartmentDAO.TimMaDonVi(uNhanVien.BADEPID, macongty);
                   abill loai = abillBUS.SearchAbillByID(vbHienHanh.Abtype);
               //// vbHienHanh = pdnaBUS.LayNoiDungVanBanTheoMaVanBan(idVanBanHienHanh);
               // //Abcon cd = capDangDuyet.First().Value;
               // PDNA_ABDE cd = capDangDuyet.First().Value;
                List<Abcon> lstChiTietXetDuyet = AbconBUS.QryNguoiDuyetBuocDauTien(idVanBanHienHanh, uNhanVien.USERID,macongty, 1);
                dalPDN p = new dalPDN();
                DataTable dt = p.QryChiTietMuaHang(macongty, idVanBanHienHanh);
               
                foreach (Abcon nguoiduyet in lstChiTietXetDuyet)
                {
                    string beginDiv = "<div style=\"border-style: solid; border-color: inherit; width:600px; border-width:1px;\"" + "><br/>";
                    string endDiv = "</div> <br/>";
                    string phieu = HttpUtility.HtmlDecode(vbHienHanh.pdmemovn);
                    string phieudich= HttpUtility.HtmlDecode(vbHienHanh.NoiDungDich) ;
                    //string noidungphieu = "- Nội dung phiếu - 内容:"+"<br/>" + phieu + "<br />";
                    //string noidungdichphieu = "- Nội dung phiếu dịch - 翻译内容:" + phieudich + "<br />";
                    //string mucdicsudung = " - Mục đích sử dụng - 使用目的:" + vbHienHanh.UseIntent + "<br/>";
                    string languege="lbl_TW";
                    string linkPDN = "<a href=\"http://"+alink+"/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                    string linkPMH = "<a href=\"http://" + alink + "/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                    string linkDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                    string linkKhongDuyet = "<a href=\"http://" + alink + "/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                    //string linkPDN = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                    //string linkPMH = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + nguoiduyet.Auditor + "&GSBH=" + macongty + "&pdno=" + vbHienHanh.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                    //string linkDuyet = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                    //string linkKhongDuyet = "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + nguoiduyet.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vbHienHanh.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                   
                    string noidung2 = "- Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                    noidung2 += "- Mã văn bản - 单号- TicketNo: " + vbHienHanh.pdno + "<br />";
                    noidung2 += "- Tiêu đề - 题目- Subject: " + vbHienHanh.mytitle + vbHienHanh.pdnsubject +"<br />";
                    noidung2 += "- Ngày tạo - 创建于: " + vbHienHanh.CFMDate0.Value.ToShortDateString() + "<br />";
                    noidung2 += "- Đơn vị đề nghị - 提议单位 :" + bp.DepName + "<br/>";
                    noidung2 += "- Người trình duyệt - 制表人: " + uNhanVien.USERNAME + "<br />";
                    noidung2 += "- Nội dung phiếu - 内容- Content:" + phieu + "<br />";
                    noidung2 += "- Nội dung phiếu dịch - 翻译内容- Translated content:" + phieudich + "<br />";
                    noidung2 += " - Mục đích sử dụng - 使用目的:" + vbHienHanh.UseIntent + "<br/>";

                    string strBody = "<html>" +
                       " <head>" +
                        "<style>" +
                        "table, th, td {" +
                           " border: 1px solid black;" +
                            "border-collapse: collapse" +
                        "}" +
                        "th, td {" +
                         "   padding: 5px;" +
                          " text-align: center;" +
                        "}" +
                        "</style>" +
                        "</head>" +
                        "<body>" +
                        "<table style=" + " float:left;border: 1px solid black;border-collapse: collapse;>" +
                       "<tr style=" + "text-align: center;>" +
                       "<td>TÊN HÀNG 品名 </td> " +
                       "<td>Size </td>"+
                        " <td>QUY CÁCH- CHỦNG LOAI 規格  </td> " +
                       " <td>Số Lượng 數量 </td> " +
                       " <td>Ghi Chú 備註 </td></tr> " +
                       "<br/>";

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            //pdn.Size, cl.dwbh, pdn.Qty,pdn.CLmemo,pdn.Memo0
                            strBody = strBody + "<tr><td>" + dr["Memo0"].ToString() + "</td>";// ten hang
                            strBody = strBody + "<td>" + dr["Size"].ToString() + "</td>";// Size
                            strBody = strBody + "<td>" + dr["dwbh"].ToString() + "</td>";// Quy cachs
                            strBody = strBody + "<td>" + dr["Qty"].ToString() + "</td>";// so luong
                            strBody = strBody + "<td>" + dr["CLmemo"].ToString() + "</td></tr>";
                        }
                    }
                    strBody += " </table> </body></html>";
                    if (lsnguoi.Count == 0)
                    {
                        lsnguoi.Add(nguoiduyet.Abstep.ToString());
                        int min = (from ct in lstChiTietXetDuyet
                                   select ct.abps).Min();
                        Abcon chMin = (from ct in lstChiTietXetDuyet
                                       where ct.abps == min
                                       select ct).FirstOrDefault();
                        Busers2 nv = UserBUS.TimNhanVienTheoMa(nguoiduyet.Auditor, macongty);
                        if (vbHienHanh.Abtype == "PDN2")
                        {
                            Until.SendMailNguoiDuyet(uNhanVien.EMAIL, nv.EMAIL, "[Ty Hung-iOffice][" + chMin.IDCT + "] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+  noidung2 + strBody+linkPMH+linkDuyet+linkKhongDuyet +endDiv );
                        }
                        else
                        {
                            Until.SendMailNguoiDuyet(uNhanVien.EMAIL, nv.EMAIL, "[Ty Hung-iOffice][" + chMin.IDCT + "] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+ noidung2   + linkPDN + linkDuyet + linkKhongDuyet +endDiv);
                        }
                        

                    }
                    else
                    {
                        if (nguoiduyet.Abstep == lsnguoi.Count)
                        {
                            Busers2 us = UserBUS.TimNhanVienTheoMa(nguoiduyet.Auditor, macongty);
                            if (vbHienHanh.Abtype == "PDN2")
                            {
                                Until.SendMailNguoiDuyet(uNhanVien.EMAIL, us.EMAIL, "[Ty Hung-iOffice] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+ noidung2  + strBody + linkPMH + linkDuyet + linkKhongDuyet +endDiv);
                            }
                            else
                            {
                                Until.SendMailNguoiDuyet(uNhanVien.EMAIL, us.EMAIL, "[Ty Hung-iOffice] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+ noidung2   + linkPDN + linkDuyet + linkKhongDuyet+endDiv);
                            }
                           

                        }
                        else
                        {
                            lsnguoi.Add(nguoiduyet.Abstep.ToString());
                            Busers2 us = UserBUS.TimNhanVienTheoMa(nguoiduyet.Auditor, macongty);
                            if (vbHienHanh.Abtype == "PDN2")
                            {
                                Until.SendMailNguoiDuyet(uNhanVien.EMAIL, us.EMAIL, "[Ty Hung-iOffice] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+ noidung2 + strBody + linkPMH + linkDuyet + linkKhongDuyet +endDiv);
                            }
                            else
                            {
                                Until.SendMailNguoiDuyet(uNhanVien.EMAIL, us.EMAIL, "[Ty Hung-iOffice] Thông báo có văn bản " + vbHienHanh.mytitle + " đang chờ bạn duyệt gấp.",beginDiv+ noidung2  + linkPDN + linkDuyet + linkKhongDuyet+endDiv);
                            }
                            
                        }
                    }


                }

   
                dalPDN dal = new dalPDN();
                DateTime date=DateTime.Today;
                dal.CapNhatTinhTrangMoiGuiCuaPhieu(macongty, vbHienHanh.pdno, date);
             

            }
           
            catch (Exception ex)
            {
                Until.WriteFileLogServer("Excep\t TrinhDuyet: " + ex);
            }


        }
        #endregion

        #region Log
        private static string CurrentLogFile(string dir)
        {
            return Path.Combine(dir, DateTime.Now.ToString("dd-MM-yyyy") + ".log");
        }

        public static void WriteFileLogServer(string message)
        {

            try
            {
                string strLogText = string.Empty;
                string FileNames = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                // Create a writer and open the file:  
                //StreamWriter log;           
                //mut.WaitOne();  
                
                Object thisLock = new Object();
                lock (thisLock)
                {
                    strLogText += string.Format("{0:dd-MM-yyyy HH:mm:ss}", DateTime.Now) + "    " + message;
                    string dirLog = Until.path + "\\serverLog";
                    if (!Directory.Exists(dirLog))
                        Directory.CreateDirectory(dirLog);
                    File.AppendAllText(CurrentLogFile(dirLog), strLogText + Environment.NewLine);

                }
            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
