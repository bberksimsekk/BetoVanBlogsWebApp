using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErişimKatmanı;

namespace BetoVanBlogsWebApp.YöneticiPaneli
{
    public partial class YoneticiDefault : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int makaleSayisi = vm.MakaleSayisiGetir();
                int uyeSayisi = vm.UyeSayisiGetir();
                int yorumSayisi = vm.YorumSayisiGetir();
                int yoneticiSayisi = vm.YoneticiSayisiGetir();

                lblMakaleSayisi.Text = makaleSayisi.ToString();
                lblUyeSayisi.Text = uyeSayisi.ToString();
                lblYorumSayisi.Text = yorumSayisi.ToString();
                lblYoneticiSayisi.Text = yoneticiSayisi.ToString();
            }
        }
    }
}