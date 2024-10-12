using System;
using System.Collections.Generic;
using System.Data;
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

        public int YoneticiSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yoneticiler";
                komut.Parameters.Clear();
                komut.Connection = Bağlantı;
                Bağlantı.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (Bağlantı.State != ConnectionState.Closed)
                    Bağlantı.Close();
            }
        }
        public int MakaleSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Makaleler";
                komut.Parameters.Clear();
                komut.Connection = Bağlantı;
                Bağlantı.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public int UyeSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Uyeler";
                komut.Parameters.Clear();
                komut.Connection = Bağlantı;
                Bağlantı.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public int YorumSayisiGetir()
        {
            SqlCommand komut = new SqlCommand();
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yorumlar";
                komut.Parameters.Clear();
                komut.Connection = Bağlantı;
                Bağlantı.Open();
                return (int)komut.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public List<Yönetici> TumYoneticileriGetir()
        {
            List<Yönetici> yoneticiler = new List<Yönetici>();

            try
            {
                Komut.CommandText = "SELECT ID, YoneticiTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum FROM Yoneticiler";
                Komut.Parameters.Clear();
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yönetici yonetici = new Yönetici();
                    yonetici.ID = okuyucu.GetInt32(0);
                    yonetici.YoneticiTurID = okuyucu.GetInt32(1);
                    yonetici.Isim = okuyucu.GetString(2);
                    yonetici.Soyisim = okuyucu.GetString(3);
                    yonetici.KullaniciAdi = okuyucu.GetString(4);
                    yonetici.Mail = okuyucu.GetString(5);
                    yonetici.Sifre = okuyucu.GetString(6);
                    yonetici.Durum = okuyucu.GetBoolean(7);
                    yoneticiler.Add(yonetici);
                }
                return yoneticiler;
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
        public void YoneticiSil(int id)
        {
            try
            {
                Komut.CommandText = "DELETE FROM Yoneticiler WHERE ID=@id";
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
        public void YoneticiDurumDegistir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT Durum FROM Yoneticiler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                bool durum = Convert.ToBoolean(Komut.ExecuteScalar());

                Komut.CommandText = "UPDATE Yoneticiler SET Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Komut.Parameters.AddWithValue("@durum", !durum);
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public bool YoneticiEkle(Yönetici yonetici)
        {
            try
            {
                Komut.CommandText = "INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum) VALUES(@yoneticiTurID, @isim, @soyisim, @kullaniciAdi, @mail, @sifre, @durum)";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@yoneticiTurID", yonetici.YoneticiTurID);
                Komut.Parameters.AddWithValue("@isim", yonetici.Isim);
                Komut.Parameters.AddWithValue("@soyisim", yonetici.Soyisim);
                Komut.Parameters.AddWithValue("@kullaniciAdi", yonetici.KullaniciAdi);
                Komut.Parameters.AddWithValue("@mail", yonetici.Mail);
                Komut.Parameters.AddWithValue("@sifre", yonetici.Sifre);
                Komut.Parameters.AddWithValue("@durum", yonetici.Durum);
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
        public Yönetici YoneticiBilgisiGetir(int yoneticiID)
        {
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, Durum, Sifre FROM Yoneticiler WHERE ID = @yoneticiID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@yoneticiID", yoneticiID);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Yönetici yonetici = null;
                if (okuyucu.Read())
                {
                    yonetici = new Yönetici();
                    yonetici.ID = okuyucu.GetInt32(0);
                    yonetici.Isim = okuyucu.GetString(1);
                    yonetici.Soyisim = okuyucu.GetString(2);
                    yonetici.KullaniciAdi = okuyucu.GetString(3);
                    yonetici.Mail = okuyucu.GetString(4);
                    yonetici.Durum = okuyucu.GetBoolean(5);
                    yonetici.Sifre = okuyucu.GetString(6);
                }
                return yonetici;
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
        public bool YoneticiProfilGuncelle(int yoneticiID, string isim, string soyisim, string kullaniciAdi, string mail, string yeniSifre)
        {
            try
            {
                Yönetici yonetici = YoneticiBilgisiGetir(yoneticiID);
                if (yonetici == null)
                    return false;

                Komut.CommandText = "UPDATE Yoneticiler SET Isim = @isim, Soyisim = @soyisim, KullaniciAdi = @kullaniciAdi, Mail = @mail, Sifre = @yeniSifre WHERE ID = @yoneticiID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@isim", isim);
                Komut.Parameters.AddWithValue("@soyisim", soyisim);
                Komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                Komut.Parameters.AddWithValue("@mail", mail);
                Komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                Komut.Parameters.AddWithValue("@yoneticiID", yoneticiID);

                Bağlantı.Open();
                int etkilenenSatirSayisi = Komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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

        public List<Kategori> TumKategorileriGetir(bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                Komut.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE Durum=@d";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@d", durum);
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.Aciklama = okuyucu.GetString(2);
                    kat.Durum = okuyucu.GetBoolean(3);
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

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                Komut.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, EklemeTarihi, GoruntulemeSayisi, KapakResim, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @eklemeTarihi, @goruntulemeSayisi, @kapakResim, @durum)";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                Komut.Parameters.AddWithValue("@yazarID", mak.YazarID);
                Komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                Komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                Komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                Komut.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                Komut.Parameters.AddWithValue("@goruntulemeSayisi", mak.GoruntulemeSayisi);
                Komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                Komut.Parameters.AddWithValue("@durum", mak.Durum);
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

        public List<Makale> MakaleListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                Komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID";
                Komut.Parameters.Clear();

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
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

        public List<Makale> MakaleListele(int kid)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                Komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID WHERE M.KategoriID = @kid";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@kid", kid);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                    makaleler.Add(mak);
                }
                return makaleler;
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

        public Makale MakaleGetir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Ozet, M.Icerik, M.Baslik, M.EklemeTarihi, M.GoruntulemeSayisi, M.KapakResim, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID WHERE M.ID = @id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();

                SqlDataReader okuyucu = Komut.ExecuteReader();
                Makale mak = new Makale();
                while (okuyucu.Read())
                {
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Ozet = okuyucu.GetString(5);
                    mak.Icerik = okuyucu.GetString(6);
                    mak.Baslik = okuyucu.GetString(7);
                    mak.EklemeTarihi = okuyucu.GetDateTime(8);
                    mak.GoruntulemeSayisi = okuyucu.GetInt64(9);
                    mak.KapakResim = okuyucu.GetString(10);
                    mak.Durum = okuyucu.GetBoolean(11);
                }
                return mak;
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

        public bool MakaleDuzenle(Makale mak)
        {
            try
            {
                Komut.CommandText = "UPDATE Makaleler SET KategoriID=@kategoriId, Baslik=@baslik, Icerik=@icerik, Ozet=@ozet, KapakResim=@kapakresim, Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@kategoriId", mak.KategoriID);
                Komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                Komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                Komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                Komut.Parameters.AddWithValue("@kapakresim", mak.KapakResim);
                Komut.Parameters.AddWithValue("@durum", mak.Durum);
                Komut.Parameters.AddWithValue("@id", mak.ID);
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

        public void MakaleSil(int id)
        {
            try
            {
                Komut.CommandText = "DELETE FROM Yorumlar WHERE MakaleID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                Komut.ExecuteNonQuery();
                Komut.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }

        #endregion

        #region Üye Metotları

        public List<Üye> TumUyeleriGetir()
        {
            List<Üye> uyeler = new List<Üye>();
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, UyelikTarihi, Durum FROM Uyeler";
                Komut.Parameters.Clear();
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Üye u = new Üye();
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.Sifre = okuyucu.GetString(5);
                    u.UyelikTarihi = okuyucu.GetDateTime(6);
                    u.Durum = okuyucu.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
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
        public Üye UyeGetir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Mail,UyelikTarihi,Durum FROM Uyeler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Üye u = new Üye();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.UyelikTarihi = okuyucu.GetDateTime(5);
                    u.Durum = okuyucu.GetBoolean(6);
                    u.Silinmis = okuyucu.GetBoolean(7);
                }
                return u;
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
        public Üye UyeGetir(string kullaniciAdi)
        {
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Soyisim, Mail, UyelikTarihi, Durum FROM Uyeler WHERE KullaniciAdi = @kullaniciAdi";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Üye u = null;
                while (okuyucu.Read())
                {
                    u = new Üye();
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = kullaniciAdi;
                    u.Mail = okuyucu.GetString(3);
                    u.UyelikTarihi = okuyucu.GetDateTime(4);
                    u.Durum = okuyucu.GetBoolean(5);
                }
                return u;
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
        public bool UyeDuzenle(Üye u)
        {
            try
            {
                Komut.CommandText = "UPDATE Uyeler SET Isim=@isim,Soyisim=@soyisim,KullaniciAdi=@kadi,Mail=@mail,UyelikTarihi=@uyet, Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", u.ID);
                Komut.Parameters.AddWithValue("@isim", u.Isim);
                Komut.Parameters.AddWithValue("@Soyisim", u.Soyisim);
                Komut.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                Komut.Parameters.AddWithValue("@email", u.Mail);
                Komut.Parameters.AddWithValue("@uyet", u.UyelikTarihi);
                Komut.Parameters.AddWithValue("@durum", u.Durum);
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
        public void UyeSil(int id)
        {
            try
            {
                Komut.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
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
        public void UyeDurumDegistir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                bool durum = Convert.ToBoolean(Komut.ExecuteScalar());

                Komut.CommandText = "UPDATE Uyeler SET Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Komut.Parameters.AddWithValue("@durum", !durum);
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public Üye UyeGiris(string mail, string sifre)
        {
            try
            {
                Üye u = new Üye();
                Komut.CommandText = "SELECT * FROM Uyeler WHERE Mail = @e AND Sifre = @s";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@e", mail);
                Komut.Parameters.AddWithValue("@s", sifre);
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    u.ID = okuyucu.GetInt32(0);
                    u.Isim = okuyucu.GetString(1);
                    u.Soyisim = okuyucu.GetString(2);
                    u.KullaniciAdi = okuyucu.GetString(3);
                    u.Mail = okuyucu.GetString(4);
                    u.Sifre = okuyucu.GetString(5);
                    u.UyelikTarihi = okuyucu.GetDateTime(6);
                    u.Durum = okuyucu.GetBoolean(7);
                }
                return u;
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
        public bool UyeOl(Üye u)
        {
            try
            {
                Komut.CommandText = "INSERT INTO Uyeler(Isim, Soyisim, KullaniciAdi, Mail, Sifre, UyelikTarihi, Durum) VALUES(@isim, @soyisim, @kadi, @mail, @sifre, @uyetarih, @durum)";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@isim", u.Isim);
                Komut.Parameters.AddWithValue("@soyisim", u.Soyisim);
                Komut.Parameters.AddWithValue("@kadi", u.KullaniciAdi);
                Komut.Parameters.AddWithValue("@mail", u.Mail);
                Komut.Parameters.AddWithValue("@sifre", u.Sifre);
                Komut.Parameters.AddWithValue("@uyetarih", u.UyelikTarihi);
                Komut.Parameters.AddWithValue("@durum", u.Durum);
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
        public Üye UyeBilgisiGetir(int uyeID)
        {
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, UyelikTarihi, Durum, Sifre FROM Uyeler WHERE ID = @uyeID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@uyeID", uyeID);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Üye uye = null;
                if (okuyucu.Read())
                {
                    uye = new Üye();
                    uye.ID = okuyucu.GetInt32(0);
                    uye.Isim = okuyucu.GetString(1);
                    uye.Soyisim = okuyucu.GetString(2);
                    uye.KullaniciAdi = okuyucu.GetString(3);
                    uye.Mail = okuyucu.GetString(4);
                    uye.UyelikTarihi = okuyucu.GetDateTime(5);
                    uye.Durum = okuyucu.GetBoolean(6);
                    uye.Sifre = okuyucu.GetString(7);
                }
                return uye;
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
        public bool UyeSifreGuncelle(int uyeID, string yeniSifre)
        {
            try
            {
                Üye uye = UyeBilgisiGetir(uyeID);
                if (uye == null)
                    return false;

                Komut.CommandText = "UPDATE Uyeler SET Sifre = @yeniSifre WHERE ID = @uyeID AND Sifre = @eskiSifre";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                Komut.Parameters.AddWithValue("@uyeID", uyeID);
                Komut.Parameters.AddWithValue("@eskiSifre", uye.Sifre);

                Bağlantı.Open();
                int etkilenenSatirSayisi = Komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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
        public Üye UyeMailGetir(string email)
        {
            try
            {
                Komut.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, UyelikTarihi, Durum FROM Uyeler WHERE Email = @email";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@email", email);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                Üye uye = null;
                if (okuyucu.Read())
                {
                    uye = new Üye();
                    uye.ID = okuyucu.GetInt32(0);
                    uye.Isim = okuyucu.GetString(1);
                    uye.Soyisim = okuyucu.GetString(2);
                    uye.KullaniciAdi = okuyucu.GetString(3);
                    uye.Mail = email;
                    uye.UyelikTarihi = okuyucu.GetDateTime(4);
                    uye.Durum = okuyucu.GetBoolean(5);
                }
                return uye;
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
        public bool UyeProfilGuncelle(int uyeID, string isim, string soyisim, string kullaniciAdi, string email, string yeniSifre)
        {
            try
            {
                Üye uye = UyeBilgisiGetir(uyeID);
                if (uye == null)
                    return false;
                Komut.CommandText = "UPDATE Uyeler SET Isim = @isim, Soyisim = @soyisim, KullaniciAdi = @kullaniciAdi, Mail = @mail, Sifre = @yeniSifre WHERE ID = @uyeID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@isim", isim);
                Komut.Parameters.AddWithValue("@soyisim", soyisim);
                Komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                Komut.Parameters.AddWithValue("@email", email);
                Komut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                Komut.Parameters.AddWithValue("@uyeID", uyeID);

                Bağlantı.Open();
                int etkilenenSatirSayisi = Komut.ExecuteNonQuery();

                if (etkilenenSatirSayisi == 0)
                    return false;

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

        #region Yorum Metotları
        public bool YorumEkle(Yorum yorum)
        {
            try
            {
                Komut.CommandText = "INSERT INTO Yorumlar (MakaleID, UyeID, Icerik, EklemeTarihi, Durum) VALUES (@makaleID, @uyeID, @icerik, @eklemetarihi, @durum)";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@makaleID", yorum.MakaleID);
                Komut.Parameters.AddWithValue("@uyeID", yorum.UyeID);
                Komut.Parameters.AddWithValue("@icerik", yorum.Icerik);
                Komut.Parameters.AddWithValue("@eklemetarihi", yorum.EklemeTarihi);
                Komut.Parameters.AddWithValue("@durum", yorum.Durum);
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
        public List<Yorum> TumYorumlariGetir()
        {
            List<Yorum> yorumlar = new List<Yorum>();

            try
            {
                Komut.CommandText = "SELECT ID, MakaleID, UyeID, Icerik, EklemeTarihi, Durum FROM Yorumlar";
                Komut.Parameters.Clear();
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
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
        public void YorumSil(int id)
        {
            try
            {
                Komut.CommandText = "DELETE FROM Yorumlar WHERE ID=@id";
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
        public void YorumDurumDegistir(int id)
        {
            try
            {
                Komut.CommandText = "SELECT Durum FROM Yorumlar WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Bağlantı.Open();
                bool durum = Convert.ToBoolean(Komut.ExecuteScalar());

                Komut.CommandText = "UPDATE Yorumlar SET Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", id);
                Komut.Parameters.AddWithValue("@durum", !durum);
                Komut.ExecuteNonQuery();
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public bool YorumDuzenle(Yorum yorum)
        {
            try
            {
                Komut.CommandText = "UPDATE Yorumlar SET MakaleID=@makaleID, UyeID=@uyeID, Icerik=@icerik, Eklemetarihi=@eklemetarihi, Durum=@durum WHERE ID=@id";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@id", yorum.ID);
                Komut.Parameters.AddWithValue("@makaleID", yorum.MakaleID);
                Komut.Parameters.AddWithValue("@uyeID", yorum.UyeID);
                Komut.Parameters.AddWithValue("@icerik", yorum.Icerik);
                Komut.Parameters.AddWithValue("@eklemetarihi", yorum.EklemeTarihi);
                Komut.Parameters.AddWithValue("@durum", yorum.Durum);
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
        public List<Yorum> YorumlariGetir(int makaleID)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                Komut.CommandText = "SELECT y.ID, y.MakaleID, y.UyeID, y.Icerik, y.Eklemetarihi, y.Durum, u.Isim, u.Soyisim FROM Yorumlar y INNER JOIN Uyeler u ON y.UyeID = u.ID WHERE y.MakaleID = @makaleID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@makaleID", makaleID);

                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    yorum.UyeIsim = okuyucu.GetString(6) + " " + okuyucu.GetString(7);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
            }
            catch
            {
                return yorumlar;
            }
            finally
            {
                Bağlantı.Close();
            }
        }
        public List<Yorum> UyeninYorumlariniGetir(int uyeID)
        {
            List<Yorum> uyeninYorumlari = new List<Yorum>();

            try
            {
                Komut.CommandText = "SELECT ID, MakaleID, UyeID, Icerik, Eklemetarihi, Durum FROM Yorumlar WHERE UyeID = @UyeID";
                Komut.Parameters.Clear();
                Komut.Parameters.AddWithValue("@UyeID", uyeID);
                Bağlantı.Open();
                SqlDataReader okuyucu = Komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = okuyucu.GetInt32(0);
                    yorum.MakaleID = okuyucu.GetInt32(1);
                    yorum.UyeID = okuyucu.GetInt32(2);
                    yorum.Icerik = okuyucu.GetString(3);
                    yorum.EklemeTarihi = okuyucu.GetDateTime(4);
                    yorum.Durum = okuyucu.GetBoolean(5);
                    uyeninYorumlari.Add(yorum);
                }
                return uyeninYorumlari;
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
