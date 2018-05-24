using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.presentationLayer
{
    public partial class DangNhap : LanguegeBus
    {
        
        
        int m_isSep = 0;

      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                #region Hang chua dung den- xin dung xoa em no
                if (!IsPostBack)
                {
                    Session["languege"] = "lbl_VN";
                }
                Session["languege"] = "lbl_VN";
                LayngonNgu(12);
                GanNgonNguVaoConTrol();
               
                #endregion 
                
                #region tam
                //string userid = (string)Request["UID"];
                //if (userid == null)
                //{
                //    Response.Redirect("http://portal.footgear.com.vn/");
                //}
                //if (!IsPostBack)
                //{

                //    string congty = "LTY";
                //    string ID = Request["ID"].ToString();
                //    string SID = Request["SID"].ToString();
                //    string UID = Request["UID"].ToString();
                //    int sysid = int.Parse(SID);
                //    string languege = Request["languege"].ToString();
                //    bool Actived = User_SystemBUS.Actived(UID, sysid, ID);
                //    if (Actived)
                //    {
                //        Busers2 nguoidung = UserBUS.KiemTraNguoiDung(congty, UID);
                //        if (nguoidung != null)
                //        {
                //            if (nguoidung.Admin == true)
                //            {
                //                Session["user"] = nguoidung.USERID;

                //                Session["congty"] = "LTY";
                //                if (languege == "Default")
                //                {
                //                    Session["languege"] = "lbl_VN";
                //                }
                //                else
                //                {
                //                    Session["languege"] = languege;
                //                }

                //                Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");

                //            }
                //            else
                //            {
                //                if (nguoidung.isSep == true)
                //                {
                //                    m_isSep = 1;
                //                    if (nguoidung != null)
                //                    {
                //                        Session["user"] = nguoidung.USERID;

                //                        Session["congty"] = "LTY";
                //                        if (languege == "Default")
                //                        {
                //                            Session["languege"] = "lbl_VN";
                //                        }
                //                        else
                //                        {
                //                            Session["languege"] = languege;
                //                        }


                //                        string url = Request.Url.LocalPath;

                //                        AbScreen mamanhinh = LanguegeBus.LayMaManHinh(5);
                //                        if (mamanhinh.UrlScreen == url)
                //                        {
                //                            Response.Redirect(mamanhinh.AliasScreen);
                //                        }

                //                        Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
                //                    }
                //                }
                //                else
                //                {

                //                    if (nguoidung.BADEPID == "VTY0501D")
                //                    {
                //                        Session["user"] = nguoidung.USERID;

                //                        Session["congty"] = "LTY";
                //                        if (languege == "Default")
                //                        {
                //                            Session["languege"] = "lbl_VN";
                //                        }
                //                        else
                //                        {
                //                            Session["languege"] = languege;
                //                        }

                //                        Response.Redirect("~/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx");
                //                    }
                //                    else
                //                    {
                //                        m_isSep = 2;
                //                        if (nguoidung != null)
                //                        {
                //                            Session["user"] = nguoidung.USERID;

                //                            Session["congty"] = "LTY";
                //                            if (languege == "Default")
                //                            {
                //                                Session["languege"] = "lbl_VN";
                //                            }
                //                            else
                //                            {
                //                                Session["languege"] = languege;
                //                            }

                //                            Response.Redirect("~/presentationLayer/Users/Home.aspx");

                //                        }
                //                    }

                //                }

                //            }
                //        }
                //    }


                //}
                #endregion
            }
            catch (Exception ex)
            {
               // Response.Write(ex.Message); 
              //  Response.Redirect("~/presentationLayer/DangNhap.aspx");
                //return;
            }
        }
      
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
           

        }
        //private void CreateSession(Busers2 nguoidung)
        //{
        //    try
        //    {
        //        Session["user"] = nguoidung.USERID;

        //        Session["congty"] = "LTY";
        //        if (languege == "Default")
        //        {
        //            Session["languege"] = "lbl_VN";
        //        }
        //        else
        //        {
        //            Session["languege"] = languege;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            int m_isSep = 0;
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string ngonngu = DropDownLanguege.SelectedValue.ToString();
            //  string url = Request.Url.LocalPath.Substring(url.LastIndexOf('/') + 1);
            string languege = "";
            string cty = DropCongTy.SelectedItem.Value.ToString();
            Busers2 nguoidung = UserBUS.KiemTraDangNhap2(cty, user, pass, true);


            if (nguoidung == null)
            {

                if (ngonngu == "lbl_VN")
                {
                    lbltb.Text = "Sai tên công ty, tên đăng nhập hoặc mật khẩu. Vui lòng nhập lại!";
                }
                else if (ngonngu == "lbl_TW")
                {
                    lbltb.Text = "公司名称，登入名称，密码有错误!";
                }
                else if (ngonngu == "lbl_EN")
                {
                    lbltb.Text = "Incorect company, username or password, please enter again!";
                }
            }
            else
            {
                if (nguoidung.Admin == true)
                {
                    Session["user"] = nguoidung.USERID;
                    Session["pass"] = pass;
                    Session["congty"] = cty;
                    Session["UserID"] = nguoidung.USERID;
                    if (DropDownLanguege.SelectedValue.Equals(1))
                    {
                        Session["languege"] = languege;
                    }
                    else
                    {
                        Session["languege"] = DropDownLanguege.SelectedValue.ToString();
                    }
                    Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");

                }
                else
                {
                    if (nguoidung.isSep == true)
                    {
                        m_isSep = 1;
                        if (nguoidung != null)
                        {
                            Session["user"] = nguoidung.USERID;
                            Session["pass"] = pass;
                            Session["congty"] = cty;
                            Session["userdangnhap"] = nguoidung.USERID;
                            Session["UserID"] = nguoidung.USERID;
                            if (DropDownLanguege.SelectedValue.Equals(1))
                            {
                                Session["languege"] = languege;
                            }
                            else
                            {
                                Session["languege"] = DropDownLanguege.SelectedValue.ToString();
                            }
                            // string url = Request.Url.LocalPath;
                            //string url = "presentationLayer/ApproveUser/DanhSachVanBanDen.aspx";
                            //AbScreen mamanhinh = LanguegeBus.LayMaManHinh(5);
                            //if (mamanhinh.UrlScreen == url)
                            //{
                            //    Response.Redirect(mamanhinh.AliasScreen);
                            //}

                           // Response.Redirect("~/presentationLayer/ApproveUser/MyCreatePDN.aspx");
                            Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
                           // Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx");
                        }
                    }
                    else
                    {

                        if (nguoidung.BADEPID == "VTY0501D")
                        {
                            Session["user"] = nguoidung.USERID;
                            Session["pass"] = pass;
                            Session["congty"] = cty;
                            Session["userdangnhap"] = nguoidung.USERID;
                            Session["UserID"] = nguoidung.USERID;
                            if (DropDownLanguege.SelectedValue.Equals(1))
                            {
                                Session["languege"] = languege;
                            }
                            else
                            {
                                Session["languege"] = DropDownLanguege.SelectedValue.ToString();
                            }
                            Response.Redirect("~/presentationLayer/NguoiDich/danhsachphieuchuadichND.aspx");
                        }
                        else
                        {
                            m_isSep = 2;
                            if (nguoidung != null)
                            {
                                Session["user"] = nguoidung.USERID;
                                Session["pass"] = pass;
                                Session["congty"] = cty;
                                Session["userdangnhap"] = nguoidung.USERID;
                                Session["UserID"] = nguoidung.USERID;
                                if (DropDownLanguege.SelectedValue.Equals(1))
                                {
                                    Session["languege"] = languege;
                                }
                                else
                                {
                                    Session["languege"] = DropDownLanguege.SelectedValue.ToString();
                                }

                                //Response.Redirect("~/presentationLayer/Users/Home.aspx");
                               // Response.Redirect("~/presentationLayer/ApproveUser/MyCreatePDN1.aspx");
                               // Response.Redirect("~/presentationLayer/Users/MyDocusNV.aspx");
                                Response.Redirect("~/presentationLayer/Users/MyDocusNV.aspx");

                            }
                        }

                    }

                }
            }
           

           
        }

        protected void DropDownLanguege_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownLanguege.SelectedValue.Equals("lbl_VN"))
                {
                    Session["languege"] = "lbl_VN";
                }
                else
                {
                    //Session["languege"] = DropDownLanguege.SelectedValue.ToString();
                    if (DropDownLanguege.SelectedValue.Equals("lbl_TW"))
                    {
                        Session["languege"] = "lbl_TW";
                    }
                    else
                    {
                        Session["languege"] = "lbl_EN";
                    }
                }
                LayngonNgu(12);
                GanNgonNguVaoConTrol();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual void GanNgonNguVaoConTrol()
        {
            try
            {
                //lbCty.Text = hasLanguege["lbCty"].ToString();
                //lbLanguege.Text = hasLanguege["lbLanguege"].ToString();
                //lbMatKhau.Text = hasLanguege["lbMatKhau"].ToString();
            //  lbtendangnhap.Text = hasLanguege["lbtendangnhap"].ToString();
                btnlogin.Text = hasLanguege["btnlogin"].ToString();
                btnfogot.Text = hasLanguege["btnfogot"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
       
    }
}