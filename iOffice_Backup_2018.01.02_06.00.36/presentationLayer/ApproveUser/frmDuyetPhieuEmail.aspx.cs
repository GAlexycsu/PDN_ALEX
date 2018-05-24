using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmDuyetPhieuEmail : System.Web.UI.Page
    {
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDetail.Visible = false;
                string UserID = (string)Request["UserID"];
                string macongty = (string)Request["GSBH"];
                string pdno = (string)Request["pdno"];
                string ngonngu = (string)Request["languege"];
                if (UserID != null && macongty != null && pdno != null && ngonngu != null)
                {
                    Session["user"] = UserID.ToString().Trim();
                    Session["UserID"] = UserID.ToString().Trim();
                    Session["maphieu"] = pdno.ToString().Trim();
                    Session["congty"] = macongty.ToString().Trim();
                    Session["languege"] = ngonngu.ToString().Trim();
                }
                string ghichu = "";
                int Yn = 1;
                bool duyet=true;
                int ynHoanThanh = 8;
                Busers2 nhanVienHienHanh = UserBUS.TimNhanVienTheoMa(UserID, macongty);
                DataTable dt = dal.QryHangTheoMaHang(pdno, macongty);
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
                Abcon timmaphieu = AbconDAO.TimPhieuTheoNguoiTao(pdno, macongty, UserID);
                if (timmaphieu != null && timmaphieu.Yn == 4)
                {
                    // cai nay
                    Dictionary<bool, Abcon> capDangDuyet = pnaDAO.LayCapDangDuyetCuaVanBan1(pdno, UserID, macongty, true, true);
                    Abcon cd = capDangDuyet.First().Value;
                    //abill1 capDuyetCuaNhanVien = UserDAO.LayCapDuyetCuaNhanVien(nhanVienHienHanh.USERID, idVanBanHienHanh);
                    List<Abcon> lstChiTietXetDuyet1 = AbconBUS.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(pdno, macongty);
                    int max = (from ct1 in lstChiTietXetDuyet1
                               select ct1.Abstep).Max();
                    List<Abcon> lstChiTietXetDuyet = AbconDAO.QryChiTietXetDuyet1(cd.IDCT, true).ToList();
                    pdna vb = pnaDAO.TimVanBanTheoMa(pdno, macongty, true);
                    Busers2 nvkt = UserDAO.LayNhanVienKhoiTaoCuaVanBan(pdno, true);
                    List<Abcon> nguoiduyettrong1cap = AbconBUS.QryNguoiDuyetTrongCung1Cap(pdno, cd.Abstep);
                    int maxABPS = (from a in nguoiduyettrong1cap select a.abps).Max();
                    int minASPS = (from a in nguoiduyettrong1cap select a.abps).Min();
                    if (cd.Abstep == 1 && cd.abrult == false)
                    {
                        List<string> kq = CapNhatChiTietDuyet(cd, duyet, ghichu, true);
                        AbconDAO.SuaChiTiet1(cd, nhanVienHienHanh.USERID, ghichu, duyet, true);

                        // Cap nhat tinh trang xet duyet cho van ban
                        // pnaDAO.CapNhatTinhTrangVanBan(idVanBanHienHanh, (duyet) ? 1 : 2, true);

                        if (kq != null)
                        {
                            string thoigian = kq[3] + " " + kq[2];

                            string thongtin = duyet ? "ĐÃ ĐƯỢC DUYỆT 已经审核" : "KHÔNG ĐƯỢC DUYỆT 未签";
                            string noidung = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                            noidung += "- Tiêu đề 题目: " + vb.mytitle + vb.pdnsubject+"<br/>";

                            noidung += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                            noidung += "- Người duyệt 审核者: " + nhanVienHienHanh.USERNAME + "<br/>";
                            noidung += "- Nội dung phiếu:" + vb.pdmemovn + "<br />";
                            noidung += "- Nội dung phiếu dịch:" + vb.NoiDungDich + "<br />";

                            Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản ", beginDiv + thongtin + noidung + endDiv);
                            if (duyet)
                            {

                                if (cd.abps != 0)
                                {
                                    if (cd.abps < maxABPS)
                                    {
                                        Abcon ab = AbconDAO.TimBuocKeTiepTrongCung1CapDuyet(pdno, macongty, cd.Abstep, cd.abps + 1);
                                        BDepartment bp = BDepartmentDAO.TimMaDonVi(ab.from_depart, macongty);
                                        abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                        Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(ab.Auditor, ab.Gsbh);
                                        string languege = "lbl_TW";
                                        string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                        string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                        string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                        string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                        string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                        noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                        noidung2 += "- Tiêu đề 题目: " + vb.mytitle + vb.pdnsubject+"<br/>";

                                        noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                        noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                        noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                        noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                        noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";

                                        if (duyet)
                                        {
                                            dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                            ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                            TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                            dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);

                                        }
                                    }// nguoc lai buoc ke tiep = buoc hien tai
                                    else
                                    {
                                        if (cd.abps == maxABPS)
                                        {
                                            Abcon buocketiep = AbconBUS.LayBuocKeTiepCuaNhanVien(macongty, pdno, cd.Abstep + 1, minASPS);
                                            if (buocketiep.Abstep > cd.Abstep)
                                            {
                                                BDepartment bp = BDepartmentDAO.TimMaDonVi(buocketiep.from_depart, macongty);
                                                abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                                Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(buocketiep.Auditor, buocketiep.Gsbh);
                                                string languege = "lbl_TW";
                                                string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                                string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                                string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                                noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                                noidung2 += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                                                noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                                noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                                noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                                noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                                noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";

                                                if (duyet)
                                                {
                                                    dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                                    ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                                    TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                    dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                                                }
                                            }
                                        }
                                    }


                                }// chi co 1 nguoi duyet trong cung 1 cap
                                else
                                {
                                    Abcon laybuocke = AbconBUS.LayBuocKeTiepCuaNhanVienTrongCung1Cap(nhanVienHienHanh.USERID, pdno, cd.Abstep + 1, minASPS);
                                    if (laybuocke.Abstep >= cd.Abstep)
                                    {
                                        BDepartment bp = BDepartmentDAO.TimMaDonVi(laybuocke.from_depart, macongty);
                                        abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                        Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(laybuocke.Auditor, laybuocke.Gsbh);
                                        string languege = "lbl_TW";
                                        string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                        string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                        string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                        string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                        string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                        noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                        noidung2 += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                                        noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                        noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                        noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                        noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                        noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";
                                        if (duyet)
                                        {
                                            dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                            ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                            TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                            dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                                        }
                                    }
                                }


                                PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(pdno, cd.abps);
                                PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                //ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(idVanBanHienHanh, macongty);
                                //TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);


                            }
                            else
                            {
                                PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(pdno, cd.abps);
                                PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                            }

                        }
                    }// buoc duyet > 1 keke
                    else
                    {

                        List<string> kq = CapNhatChiTietDuyet(cd, duyet, ghichu, true);
                        AbconDAO.SuaChiTiet1(cd, nhanVienHienHanh.USERID, ghichu, duyet, true);

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

                            string thongtin = duyet ? "ĐÃ ĐƯỢC DUYỆT 已经审核" : "KHÔNG ĐƯỢC DUYỆT 未签" + "<br/>";
                            string noidung = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                            noidung += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                            noidung += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                            noidung += "- Người duyệt 审核者: " + nhanVienHienHanh.USERNAME + "<br/>";
                            noidung += "- Nội dung phiếu:" + vb.pdmemovn + "<br />";
                            noidung += "- Nội dung phiếu dịch:" + vb.NoiDungDich + "<br />";

                            Until.SendMailNguoiTao(nhanVienHienHanh.EMAIL, nvkt.EMAIL, "[Ty Hung-eOffice] Thông báo văn bản ", beginDiv + thongtin + noidung + endDiv);
                            if (duyet)
                            {
                                
                                if (cd.Abstep == max)
                                {
                                    PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(pdno, cd.Abstep);
                                    PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                    ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                    TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                    dal.CapNhatPhieuPDNA(pdno, macongty, ynHoanThanh,cd.Abstep,UserID);
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
                                            Abcon ab = AbconDAO.TimBuocKeTiepTrongCung1CapDuyet(pdno, macongty, cd.Abstep, cd.abps + 1);
                                            BDepartment bp = BDepartmentDAO.TimMaDonVi(ab.from_depart, macongty);
                                            abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                            Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(ab.Auditor, ab.Gsbh);
                                            string languege = "lbl_TW";
                                            string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                            string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + ab.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                            string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                            noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                            noidung2 += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                                            noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                            noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                            noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                            noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                            noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";

                                            if (duyet)
                                            {
                                                dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                                            }
                                        }// nguoc lai buoc ke tiep = buoc hien tai
                                        else
                                        {
                                            if (cd.abps == maxABPS)
                                            {
                                                Abcon buocketiep = AbconBUS.LayBuocKeTiepCuaNhanVien(macongty, pdno, cd.Abstep + 1, minASPS);
                                                if (buocketiep.Abstep > cd.Abstep)
                                                {
                                                    BDepartment bp = BDepartmentDAO.TimMaDonVi(buocketiep.from_depart, macongty);
                                                    abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                                    Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(buocketiep.Auditor, buocketiep.Gsbh);
                                                    string languege = "lbl_TW";
                                                    string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                    string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                                    string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                                    string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + buocketiep.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                                    string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                                    noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                                    noidung2 += "- Tiêu đề 题目: " + vb.mytitle + vb.pdnsubject+"<br/>";

                                                    noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                                    noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                                    noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                                    noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                                    noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";

                                                    if (duyet)
                                                    {
                                                        dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                                        ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                                        TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                        dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                                                    }
                                                }
                                            }
                                        }
                                    }// trong 1 cap duyet chi co 1 nguoi
                                    else
                                    {
                                        Abcon laybuocke = AbconBUS.LayBuocKeTiepCuaNhanVienTrongCung1Cap(nhanVienHienHanh.USERID, pdno, cd.Abstep + 1, minASPS);
                                        if (laybuocke.Abstep >= cd.Abstep)
                                        {
                                            BDepartment bp = BDepartmentDAO.TimMaDonVi(laybuocke.from_depart, macongty);
                                            abill loai = abillBUS.SearchAbillByID(vb.Abtype);

                                            Busers2 user = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(laybuocke.Auditor, laybuocke.Gsbh);
                                            string languege = "lbl_TW";
                                            string linkPDN = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDetails.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkPMH = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/chitietphieumuahang.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "&languege=" + languege + "\">1. Vào đây xem chi tiết phiếu trên hệ thống- 按钮这里可以查看详细资料</a>" + "<br />";
                                            string linkDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmDuyetPhieuEmail.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">2. Đồng ý - 同意</a>" + "\n" + " <br/>";
                                            string linkKhongDuyet = "<a href=\"http://192.168.11.8/pdn/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + laybuocke.Auditor + "" + "&GSBH=" + "" + macongty + "" + "&pdno=" + "" + vb.pdno + "\">3. Không đồng ý - 不同意</a>" + "<br />";
                                            string noidung2 = "Loại phiếu - 单别:" + loai.abname + loai.abnameTW + "<br/>";
                                            noidung2 = "- Mã văn bản 单号: " + vb.pdno + "<br/>";
                                            noidung2 += "- Tiêu đề 题目: " + vb.mytitle +vb.pdnsubject+ "<br/>";

                                            noidung2 += "- Ngày tạo 创建于: " + vb.CFMDate0.Value.ToShortDateString() + "<br/>";
                                            noidung2 += "- Người trình duyệt 寄件者: " + nvkt.USERNAME + "<br/>";
                                            noidung2 += "- Đơn vị đề nghị - 提议单位:" + bp.DepName + "<br/>";
                                            noidung2 += "- Nội dung phiếu - 内容:" + vb.pdmemovn + "<br />";
                                            noidung2 += "- Nội dung phiếu dịch - 翻译内容:" + vb.NoiDungDich + "<br />";
                                            if (duyet)
                                            {
                                                dal.CapNhatLevel(pdno, macongty, cd.Abstep, user.USERID);
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
                                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                                dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                                            }
                                        }
                                    }

                                }

                               

                            }// neu khong duyet thi cap nhat trang thai duyet vap ban chi tiet buoc
                            else
                            {
                                PDNSheetFlow PDNSheetFlow = PDNSheetFlowBUS.LayPDNSheetFlowTheoIdVanBanBuocKy(pdno, cd.abps);
                                PDNSheetFlowBUS.SuaPDNSheetFlow(PDNSheetFlow, duyet);
                                ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(pdno, macongty);
                                TrangThaiDuyetDAO.SuaTrangThaiDuyet(trangthai, duyet);
                                dal.CapNhatPhieuPDNA(pdno, macongty, Yn,cd.Abstep,UserID);
                            }

                        }
                    }
                    btnDetail.Visible = true;
                    lblThongBao.Text = "Bạn đã xét duyệt thành công - 审核成功";
                    Session["maloaiphieutam"] = timmaphieu.abtype.Trim();
                    // ket thuc cai nay
                }
                else
                {
                    Abcon timphieu = AbconDAO.TimPhieuTheoNguoiTao(pdno, macongty, UserID);
                    if (timphieu !=null)
                    {
                        if (timphieu.Yn == 1 && timphieu.abrult == true)
                        {
                            btnDetail.Visible = true;
                            Session["maloaiphieutam"] = timphieu.abtype.Trim();
                            lblThongBao.Text = "Bạn đã duyệt phiếu này rồi - 您已经审核";
                        }
                    }
                }
            }
        }
        public  List<string> CapNhatChiTietDuyet(Abcon chMax, bool duyet, string ghichu, bool barCode = false)
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

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            string maloaiphieutam = (string)Session["maloaiphieutam"];
            if (maloaiphieutam != null)
            {
               
                if (maloaiphieutam == "PDN2")
                {
                    Response.Redirect("phieumuahangD.aspx");
                }
                else
                {
                    Response.Redirect("frmDetails2D.aspx");
                }
            }
        }
    }
}