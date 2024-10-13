using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErişimKatmanı;

namespace BetoVanBlogsWebApp
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_tikla_Click(object sender, EventArgs e)
        {
            string email = tb_mail.Text;
            string yeniSifre = tb_yenisifre.Text;

            Üye uye = vm.UyeMailGetir(email);

            if (uye == null || string.IsNullOrEmpty(email))
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Geçersiz email adresi!";
                return;
            }
            if (string.IsNullOrEmpty(yeniSifre))
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Yeni şifre boş olamaz!";
                return;
            }
            if (vm.UyeSifreGuncelle(uye.ID, yeniSifre))
            {
                pnl_basarili.Visible = true;
                lbl_mesaj.Text = "Şifreniz başarıyla güncellendi!";
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_hatamesaj.Text = "Şifre güncelleme işlemi başarısız!";
            }
        }
    }
}