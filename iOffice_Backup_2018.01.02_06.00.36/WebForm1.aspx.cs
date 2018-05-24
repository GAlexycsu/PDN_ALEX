using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Text;
using System.IO;
namespace iOffice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
         iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void HienThiDuLieu()
        {
            string maphieu = "201411170065";
            string macongty="LTY";
            
            pdna layphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            Label1.Text = Server.HtmlDecode(layphieu.pdmemovn);
            TextBox1.Text = HttpUtility.HtmlDecode(layphieu.pdmemovn);
            string abccc = Label1.Text.ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
             StringBuilder html = new StringBuilder();
            string userid = "00002";
            string congty = "LTY";
            string pdno = "201411180094";
            string maphieu = "201411180094";
            string macongty = "LTY";
           
            pdna layphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
           string noidung2 = "- Mã văn bản 单号: "+"<br/>";
            noidung2 += "- Tiêu đề 题目:"+" <br/>";

            noidung2 += "- Ngày tạo 创建于:"+" <br/>";
            noidung2 += "- Người trình duyệt 寄件者:"+" <br/>";
            noidung2 += "noi dung" + layphieu.pdmemovn+ "<br/>";
            
            noidung2 += "Hoac thay vao day "+"<br/>";
           
            noidung2 += "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\"> Jon Doe</a>" + "<br/>";
            noidung2 += "<br/>";
            noidung2 += "<a href=\"http://localhost:3530/presentationLayer/ApproveUser/frmKhongDuyet.aspx" + "?UserID=" + "" + userid + "" + "&GSBH=" + "" + congty + "" + "&pdno=" + "" + pdno + "\">Jon Doe</a>" + "<br/>";
            List<BOfSupply> list = SuppliesDAO.QryHangTheoPhieu(maphieu, macongty);

            string strBody = "<html>"+
               " <head>"+
                "<style>"+
                "table, th, td {"+
                   " border: 1px solid black;"+
                    "border-collapse: collapse"+
                "}"+
                "th, td {"+
                 "   padding: 5px;"+
                  " text-align: center;"+
                "}"+
                "</style>"+
                "</head>"+
                "<body>"+
                "<table style="+" float:left;border: 1px solid black;border-collapse: collapse;>"+
               "<tr style="+"text-align: center;>"+
               "<td>TÊN HÀNG 品名 </td> " +
                " <td>QUY CÁCH- CHỦNG LOAI 規格  </td> " +
               " <td>Số Lượng 數量 </td> " +
               " <td>Ghi Chú 備註 </td></tr> " +
               "<br/>";


            foreach (BOfSupply phieu in list)
            {
                strBody = strBody + "<tr><td>" + phieu.OfSuppliesName + "</td>";
                strBody = strBody + "<td>" + phieu.BUnit + "</td>";
                strBody = strBody + "<td>" + phieu.BNumber + "</td>";
                strBody = strBody + "<td>" + phieu.BCommnent + "</td></tr>";

            }
            strBody += " </table> </body></html>";
            //string strBody = "<html><body><table ><tr><td>TÊN HÀNG 品名 = </td>  <td>QUY CÁCH- CHỦNG LOAI 規格 = </td>  <td>Số Lượng 數量= </td>  <td>Ghi Chú 備註 </td></tr> <br/><tr><td>MAY TINH</td><td>PCS</td><td>1</td><td></td></tr><tr><td>Chuot</td><td>PCS</td><td>1</td><td></td></tr>";

            Label1.Text = Server.HtmlDecode(layphieu.pdmemovn);


            string abc = Server.HtmlDecode(layphieu.pdmemovn);
            string from = "tuan-it@footgear.com.vn";
            string touser = "tuan-it@footgear.com.vn";
          
           // Until.SendMailNguoiDich(from, touser, pdno, noidung2);
            // Until.SendMailNguoiTao(from, touser, YourSubject.Text, noidung2);
             Until.SendMailNguoiDuyet(from, touser, YourSubject.Text, noidung2 +strBody);

            lblMsgSend.Text = "Your Comments after sending the mail";
            lblMsgSend.Visible = true;
            YourSubject.Text = "";
            YourEmail.Text = "";
            YourName.Text = "";
            Comments.Text = "";
        }
    }
}