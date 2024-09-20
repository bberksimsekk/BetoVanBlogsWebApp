using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErişimKatmanı
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

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                Komut.CommandText = "INSERT INTO Kategoriler(Isim,Aciklama,Durum,Silinmis) VALUES(@isim,@aciklama,@durum,@silinmis)";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@isim", kat.Isim);
                Komut.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                Komut.Parameters.AddWithValue("@durum", kat.Durum);
                Komut.Parameters.AddWithValue("@silinmis", kat.Silinmis);
                Bağlantı.Open();
                Komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                Komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler ";
                Komut.Parameters.Clear();
                Bağlantı.Open();
                SqlDataReader reader = Komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
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

        public List<Kategori> KategoriListele(bool silinmis)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                Komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE Silinmis=@silinmis";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@silinmis", silinmis);
                Bağlantı.Open();
                SqlDataReader reader = Komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
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
        public List<Kategori> KategoriListele(bool silinmis, bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                Komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE Silinmis=@silinmis AND Durum =@durum";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@silinmis", silinmis);
                Komut.Parameters.AddWithValue("@durum", durum);
                Bağlantı.Open();
                SqlDataReader reader = Komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    kat.Silinmis = reader.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
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

        public void KategoriSilHardDelete(int id)
        {
            try
            {
                Komut.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                Komut.CommandText = "UPDATE Kategoriler SET Silinmis = 1 WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT Durum FROM Kategoriler WHERE ID = @id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                bool durum = Convert.ToBoolean(Komut.ExecuteScalar());
                Komut.CommandText = "UPDATE Kategoriler SET Durum=@durum WHERE ID = @id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@durum", !durum);
                Komut.Parameters.AddWithValue("@id", id);
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Aciklama, Durum, Silinmis FROM Kategoriler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Kategori kat = new Kategori();

                while (okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
                    kat.Silinmis = okuyucu.GetBoolean(4);
                }
                return kat;
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

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                Komut.CommandText = "UPDATE Kategoriler SET Isim=@isim, Aciklama=@aciklama, Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", k.ID);
                Komut.Parameters.AddWithValue("@isim", k.Isim);
                Komut.Parameters.AddWithValue("@aciklama", k.Aciklama);
                Komut.Parameters.AddWithValue("@durum", k.Durum);
                Bağlantı.Open();
                Komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        #endregion
    }
}
