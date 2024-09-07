using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModeli
    {
        SqlConnection Bağlantı; SqlCommand Komut;

        public VeriModeli()
        {
            Bağlantı = new SqlConnection(BağlantıYolları.BağlantıYolu);
            Komut = Bağlantı.CreateCommand();
        }

        #region Yönetici Metotları

        public Yönetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                Komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @mail AND Sifre = @sifre";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@mail", mail);
                Komut.Parameters.AddWithValue("@sifre", sifre);
                Bağlantı.Open();

                int sayi = Convert.ToInt32(Komut.ExecuteScalar());
                if (sayi == 1)
                {
                    Komut.CommandText = "SELECT Y.ID, Y.YoneticiTurID, YT.Isim, Y.Isim, Y.Soyisim, Y.KullaniciAdi, Y.Mail, Y.Sifre, Y.Durum, Y.Silinmis FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID = YT.ID WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                    Komut.Parameters.Clear();
                    Komut.Parameters.AddWithValue("@mail", mail);
                    Komut.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader okuyucu = Komut.ExecuteReader();
                    Yönetici y = new Yönetici();
                    while (okuyucu.Read())
                    {
                        y.ID = okuyucu.GetInt32(0);
                        y.YoneticiTurID = okuyucu.GetInt32(1);
                        y.YoneticiTur = okuyucu.GetString(2);
                        y.Isim = okuyucu.GetString(3);
                        y.Soyisim = okuyucu.GetString(4);
                        y.KullaniciAdi = okuyucu.GetString(5);
                        y.Mail = okuyucu.GetString(6);
                        y.Sifre = okuyucu.GetString(7);
                        y.Durum = okuyucu.GetBoolean(8);
                        y.Silinmis = okuyucu.GetBoolean(9);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        #endregion
    }
}
