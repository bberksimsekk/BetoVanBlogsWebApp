﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErişimKatmanı;

namespace BetoVanBlogsWebApp.ÜyePaneli
{
    public partial class UyePanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Uye"] == null)
            {
                Response.Redirect("~/UyeGiris.aspx");
            }
            else
            {
                Üye u = (Üye)Session["Uye"];
                lbl_kullanici.Text = u.KullaniciAdi;

            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["Uye"] = null;
            Response.Redirect("Default.aspx");
        }

    }
}