using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErişimKatmanı;

namespace BetoVanBlogsWebApp.ÜyePaneli
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Üye uye = Session["uye"] as Üye;
                if (uye != null)
                {
                    int uyeID = uye.ID;
                    lv_yorumlar.DataSource = vm.UyeninYorumlariniGetir(uyeID);
                    lv_yorumlar.DataBind();
                }
            }
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vm.YorumSil(id);
            }
            if (e.CommandName == "durum")
            {
                vm.YorumDurumDegistir(id);
            }
            Üye uye = Session["uye"] as Üye;
            if (uye != null)
            {
                int uyeID = uye.ID;
                lv_yorumlar.DataSource = vm.UyeninYorumlariniGetir(uyeID);
                lv_yorumlar.DataBind();
            }
        }
    }
}