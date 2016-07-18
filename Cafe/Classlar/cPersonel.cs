using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Classlar
{
    class cPersonel
    {
        private int _personelID;
        private string _ad;       
        private string _soyad;
        private string _tcNo;
        private string _telefon;
        private string _yetki;   
        private string _sifre;
        private string _kullaniciAd;

      

        #region Properties

        public string KullaniciAd
        {
            get { return _kullaniciAd; }
            set { _kullaniciAd = value; }
        }
        public string Yetki
        {
            get { return _yetki; }
            set { _yetki = value; }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }
        public int PersonelID
        {
            get { return _personelID; }
            set { _personelID = value; }
        }
        public string Ad
        {
            get { return _ad; }
            set { _ad = value; }
        }
        public string Soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }
        public string TcNo
        {
            get { return _tcNo; }
            set { _tcNo = value; }
        }
        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        public bool PersonelVarmi(string TC, string kAdi)
        {
            bool Varmi = false;
            SqlCommand comm = new SqlCommand("Select Count(*) from Personel where Silindi=0 and TcNO=@TC or KullaniciAd=@KullaniciAd", conn);
            comm.Parameters.Add("@TC", SqlDbType.VarChar).Value = TC;
            comm.Parameters.Add("@KullaniciAd", SqlDbType.VarChar).Value = kAdi;



            if (conn.State == ConnectionState.Closed) conn.Open();
            int Sayisi = Convert.ToInt32(comm.ExecuteScalar());
            if (Sayisi > 0)
            {
                Varmi = true;
            }
            conn.Close();
            return Varmi;
        }


        public bool PersonelEkle(cPersonel p)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Personel (Ad,Soyad,TcNo,Telefon,KullaniciAd,Sifre,Yetki) values(@Ad,@Soyad,@TC, @Telefon,@KullaniciAd, @Sifre,@Yetki)", conn);
            comm.Parameters.Add("@Ad", SqlDbType.VarChar).Value = p._ad;
            comm.Parameters.Add("@Soyad", SqlDbType.VarChar).Value = p._soyad;
            comm.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = p._telefon;
            comm.Parameters.Add("@KullaniciAd", SqlDbType.VarChar).Value = p._kullaniciAd;
            comm.Parameters.Add("@Sifre", SqlDbType.Int).Value = p._sifre;
            comm.Parameters.Add("@Yetki", SqlDbType.VarChar).Value = p._yetki;
            comm.Parameters.Add("@TC", SqlDbType.VarChar).Value = p._tcNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }

        internal bool YetkikontrolEt(string Kullanici)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("Select Ad from Personel where Silindi=0 and Yetki='Yetkili' and PersonelID=@ID", conn);
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(Kullanici);
            if (conn.State == ConnectionState.Closed) conn.Open();
             SqlDataReader dr=comm.ExecuteReader();
            if (dr.HasRows)
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }
            dr.Close();
            conn.Close();
            return sonuc;
        }

        public void PersonelGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select PersonelID,Ad,Soyad,TcNo,Telefon,KullaniciAd,Sifre,Yetki from Personel where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;

                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString(), 0);
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());
                    i++;
                }
                dr.Close();
            }
            conn.Close();
        }

        internal void PersonelGetirByAdaGore(string AdaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select PersonelID,Ad,Soyad,TcNo,KullaniciAd,Sifre,Telefon,Yetki from Personel where Silindi=0 and Ad like @AdaGore + '%'", conn);
            comm.Parameters.Add("@AdaGore", SqlDbType.VarChar).Value = AdaGore;  // duzenlenecek
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    liste.Items.Add(dr[0].ToString());
                    liste.Items[i].SubItems.Add(dr[1].ToString());
                    liste.Items[i].SubItems.Add(dr[2].ToString());
                    liste.Items[i].SubItems.Add(dr[3].ToString());
                    liste.Items[i].SubItems.Add(dr[4].ToString());
                    liste.Items[i].SubItems.Add(dr[5].ToString());
                    liste.Items[i].SubItems.Add(dr[6].ToString());
                    liste.Items[i].SubItems.Add(dr[7].ToString());

                    i++;
                }
                dr.Close();
            }
            conn.Close();
        }

        public bool PersonelGuncelle(cPersonel p)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Personel set  Ad=@PersonelAd, Soyad=@PersonelSoyad, TcNo=@TcNo, KullaniciAd=@KullaniciAd, Sifre=@Sifre , Telefon=@Telefon , Yetki=@Yetki where PersonelID=@PersonelID", conn);
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = p._personelID;
            comm.Parameters.Add("@PersonelAd", SqlDbType.VarChar).Value = p._ad;
            comm.Parameters.Add("@PersonelSoyad", SqlDbType.VarChar).Value = p._soyad;
            comm.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = p._telefon;
            comm.Parameters.Add("@Yetki", SqlDbType.VarChar).Value = p._yetki;
            comm.Parameters.Add("@KullaniciAd", SqlDbType.VarChar).Value = p._kullaniciAd;
            comm.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = p._sifre;
            comm.Parameters.Add("@TcNo", SqlDbType.VarChar).Value = p._tcNo;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }

        public bool PersonelSil(int PersonelID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Personel set Silindi=1 where PersonelID=@PersonelID", conn);
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }

        public void PersonelGetir(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Personel where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string ad = dr["KullaniciAd"].ToString();

                    liste.Items.Add(ad);

                }
                dr.Close();
            }
            conn.Close();
        }

        public bool SifreKontrol(string sifre, string Kullanıcı)
        {
            bool sonuc;
            SqlCommand comm = new SqlCommand("Select * from Personel where Silindi=0 and KullaniciAd=@Ad and Sifre=@Sifre ", conn);
            comm.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = sifre;
            comm.Parameters.Add("@Ad", SqlDbType.VarChar).Value = Kullanıcı;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                sonuc = true;
                while (dr.Read())
                {
                    cGenel.PersonelID = Convert.ToInt32(dr["PersonelID"]);//Sisteme Giren PErsonel Id sini Bize veriyor.
                }


            }
            else
            {
                sonuc = false;
            }
            dr.Close();

            conn.Close();
            return sonuc;


        }

        internal DataSet PersonelGetir()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select PersonelID , Ad, Soyad From Personel where Silindi=0", conn);
            try
            {
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
    }
}
