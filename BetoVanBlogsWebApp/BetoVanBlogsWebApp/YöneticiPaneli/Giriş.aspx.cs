using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErişimKatmanı;

namespace BetoVanBlogsWebApp.YöneticiPaneli
{
    public partial class Giriş : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_girisYap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    Yönetici y = vm.YoneticiGiris(tb_mail.Text, tb_sifre.Text);
                    if (y != null)
                    {
                        Session["GirisYapanYonetici"] = y;
                        //Giriş Yapan Yöneticinin nesnesi client tarafında tutuldu
                        Response.Redirect("YoneticiDefault.aspx");
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şifre adresi boş bırakılamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Mail adresi boş bırakılamaz";
            }
        }
    }
}