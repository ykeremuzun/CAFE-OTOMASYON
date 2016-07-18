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
    class cSiparisUrunler
    {
        private int _urunID;
        private int _siparisID;
        private int _miktar;
        private double _birimFiyat;

        #region Properties
        public int UrunID
        {
            get { return _urunID; }
            set { _urunID = value; }
        }

        public int SiparisID
        {
            get { return _siparisID; }
            set { _siparisID = value; }
        }

        public int Miktar
        {
            get { return _miktar; }
            set { _miktar = value; }
        }

        

        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        } 
        #endregion


        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        internal bool SiparisKaydetBySiparisUrun(ListView liste, int siparisid)
        {
            bool sonuc = false;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                SqlCommand comm = new SqlCommand("insert into SiparisUrunler (UrunID, SiparisID, Miktar, BirimFiyat) values (@UrunID, @SiparisID, @Miktar, @BirimFiyat)", conn);

                comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[7].Text);
                comm.Parameters.Add("@SiparisID", SqlDbType.Int).Value = siparisid;
                comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[3].Text);
                comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = Convert.ToDouble(liste.Items[i].SubItems[4].Text);

                if (conn.State == ConnectionState.Closed) conn.Open();
                sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                conn.Close();
            }
            return sonuc;


        }

        internal bool FisKaydet(ListView liste, int odemeTipi, int personeid)
        {
            bool sonuc = false;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                SqlCommand comm = new SqlCommand("insert into Fis (SiparisUrunID,MasaID,PersonelID,OdemeTipi,Tutar) values(@SiparisUrunID,@MasaID,@PersonelID,@OdemeTipi,@Tutar)", conn);
                comm.Parameters.Add("@SiparisUrunID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[5].Text);
                comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[6].Text);
                comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = personeid;
                comm.Parameters.Add("@OdemeTipi", SqlDbType.Int).Value = odemeTipi;
                comm.Parameters.Add("@Tutar", SqlDbType.Money).Value = Convert.ToDouble(liste.Items[i].SubItems[4].Text);
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                    MessageBox.Show(hata);
                }
                finally { conn.Close(); }
            }
            return sonuc;
        }

        public void SiparisleriGoster(ListView liste, int MAsaID, int ID)
        {

            SqlCommand comm = new SqlCommand("select m.MasaID,m.MasaAd,u.UrunAd,su.Miktar,su.BirimFiyat,su.Miktar*su.BirimFiyat as Tutar,Ad,s.SiparisID,su.ID from Siparis s inner join SiparisUrunler su on s.SiparisID=su.SiparisID inner join Urunler u on u.UrunID=su.UrunID inner join Masalar m on s.MasaID=m.MasaID inner join Personel p on s.PersonelID=p.PersonelID where m.MasaID=@MasaID and m.Durum=1 and su.Odendi=0", conn);
            comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = MAsaID;
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                liste.Items.Clear();
                dr = comm.ExecuteReader();
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
                        liste.Items[i].SubItems.Add(dr[8].ToString());

                        i++;
                    }
                    dr.Close();

                }

            }
            catch (SqlException ex)
            {

                string Hata = ex.Message;
                MessageBox.Show(Hata);
            }
            finally { conn.Close(); }
        }

        public void SiparisleriGosterEklemeli(ListView liste, int masaid,int siparisid)
        {
            SqlCommand comm = new SqlCommand("select Urunler.UrunAd,sum(SiparisUrunler.Miktar),avg(SiparisUrunler.BirimFiyat),sum(SiparisUrunler.Miktar*SiparisUrunler.BirimFiyat),sum(SiparisUrunler.Miktar/SiparisUrunler.BirimFiyat) from Urunler inner join SiparisUrunler on Urunler.UrunID=SiparisUrunler.UrunID where SiparisUrunler.SiparisID=@SiparisID and SiparisUrunler.Odendi=0  group by Urunler.UrunAd", conn);
            comm.Parameters.Add("@SiparisID", SqlDbType.Int).Value = siparisid;
            comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = masaid;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                double sayi2 = 0;
                double sayi = 0;
                liste.Items.Clear();
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {

                    int i = 0;
                    while (dr.Read())
                    {sayi=Convert.ToInt32(dr[2])/ Convert.ToInt32(dr[1]);
                    sayi2 = Convert.ToInt32(dr[2]) * Convert.ToInt32(dr[1]);
                    
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(siparisid.ToString());

                        i++;
                    }
                    dr.Close();

                }

            }
            catch (SqlException ex)
            {

                string Hata = ex.Message;
                MessageBox.Show(Hata);
            }
            finally { conn.Close(); }
        }

        internal bool HesapGuncelleByOdendi(ListView liste)
        {
            bool sonuc = false;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                SqlCommand comm = new SqlCommand("update SiparisUrunler set Odendi=1 where ID=@ID", conn);
                comm.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[5].Text);
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                    MessageBox.Show(hata);
                }
                finally { conn.Close(); }
            }

            return sonuc;
        }
        internal bool HesapGuncelleByOdendi2(ListView liste)
        {
            bool sonuc = false;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                SqlCommand comm = new SqlCommand("update SiparisUrunler set Odendi=1 where SiparisID=@ID", conn);
                comm.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[4].Text);
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
                }
                catch (SqlException ex)
                {

                    string hata = ex.Message;
                    MessageBox.Show(hata);
                }
                finally { conn.Close(); }
            }

            return sonuc;
        }

        internal void SatislariGetirByTarihlerArasi(DateTime Tarih1, DateTime Tarih2, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select s.SiparisID,su.UrunID, convert(Date , f.Tarih,104  ) as Tarih , u.UrunAd, m.MasaAd, p.Ad + ' ' + p.Soyad as GarsonAd, su.Miktar, su.BirimFiyat, su.Miktar*f.Tutar as Tutar,f.OdemeTipi, ot.OdemeAd from Urunler u inner join SiparisUrunler su on u.UrunID=su.UrunID inner join Siparis s on su.SiparisID=s.SiparisID inner join Masalar m on m.MasaID=s.MasaID inner join Personel p on p.PersonelID=s.PersonelID  inner join Fis f on f.SiparisUrunID = su.ID inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi where Convert(Date,f.Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            comm.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            comm.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
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
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        liste.Items[i].SubItems.Add(dr[9].ToString());
                        liste.Items[i].SubItems.Add(dr[10].ToString());
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

        internal void SatislariGetirByDetaySorgulama(string AdaGore, string GarsonAdaGore, string MasaAdaGore, string OdemeTipeGore, ListView liste, DateTime Tarih1, DateTime Tarih2)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select s.SiparisID,su.UrunID, convert(Date , s.Tarih,104  ) as Tarih , u.UrunAd, m.MasaAd, p.Ad + ' ' + p.Soyad as GarsonAd, su.Miktar, su.BirimFiyat, su.Miktar*f.Tutar as Tutar,f.OdemeTipi, ot.OdemeAd from Urunler u inner join SiparisUrunler su on u.UrunID=su.UrunID inner join Siparis s on su.SiparisID=s.SiparisID inner join Masalar m on m.MasaID=s.MasaID inner join Personel p on p.PersonelID=s.PersonelID  inner join Fis f on f.SiparisUrunID = su.ID inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi where u.UrunAd like @AdaGore + '%' and p.Ad like @GarsonAdaGore + '%' and m.MasaAd like @MasaAdaGore + '%' and ot.OdemeAd like @OdemeTipeGore + '%' and Convert(Date,f.Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            comm.Parameters.Add("@AdaGore", SqlDbType.VarChar).Value = AdaGore;
            comm.Parameters.Add("@GarsonAdaGore", SqlDbType.VarChar).Value = GarsonAdaGore;
            comm.Parameters.Add("@MasaAdaGore", SqlDbType.VarChar).Value = MasaAdaGore;
            comm.Parameters.Add("@OdemeTipeGore", SqlDbType.VarChar).Value = OdemeTipeGore;
            comm.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            comm.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
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
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        liste.Items[i].SubItems.Add(dr[9].ToString());
                        liste.Items[i].SubItems.Add(dr[10].ToString());
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

        internal int MiktarGetir(string AdaGore, string GarsonAdaGore, string MasaAdaGore, string OdemeTipeGore, DateTime Tarih1, DateTime Tarih2)
        {

            cSiparisUrunler su = new cSiparisUrunler();
            SqlCommand comm = new SqlCommand("Select s.SiparisID,su.UrunID, convert(Date , s.Tarih,104  ) as Tarih , u.UrunAd, m.MasaAd, p.Ad + ' ' + p.Soyad as GarsonAd, su.Miktar, su.BirimFiyat, su.Miktar*su.BirimFiyat as Tutar,f.OdemeTipi, ot.OdemeAd from Urunler u inner join SiparisUrunler su on u.UrunID=su.UrunID inner join Siparis s on su.SiparisID=s.SiparisID inner join Masalar m on m.MasaID=s.MasaID inner join Personel p on p.PersonelID=s.PersonelID  inner join Fis f on f.SiparisUrunID = su.ID inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi where u.UrunAd like @AdaGore + '%' and p.Ad like @GarsonAdaGore + '%' and m.MasaAd like @MasaAdaGore + '%' and ot.OdemeAd like @OdemeTipeGore + '%' and Convert(Date,f.Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            comm.Parameters.Add("@AdaGore", SqlDbType.VarChar).Value = AdaGore;
            comm.Parameters.Add("@GarsonAdaGore", SqlDbType.VarChar).Value = GarsonAdaGore;
            comm.Parameters.Add("@MasaAdaGore", SqlDbType.VarChar).Value = MasaAdaGore;
            comm.Parameters.Add("@OdemeTipeGore", SqlDbType.VarChar).Value = OdemeTipeGore;
            comm.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            comm.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        su.Miktar += Convert.ToInt32(dr["Miktar"]);
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }



            return su.Miktar;
        }

        internal double TutarGetir(string AdaGore, string GarsonAdaGore, string MasaAdaGore, string OdemeTipeGore, DateTime Tarih1, DateTime Tarih2)
        {

            cSiparisUrunler su = new cSiparisUrunler();
            SqlCommand comm = new SqlCommand("Select s.SiparisID,su.UrunID, convert(Date , s.Tarih,104  ) as Tarih , u.UrunAd, m.MasaAd, p.Ad + ' ' + p.Soyad as GarsonAd, su.Miktar, su.BirimFiyat, su.Miktar*f.Tutar as Tutar,f.OdemeTipi, ot.OdemeAd from Urunler u inner join SiparisUrunler su on u.UrunID=su.UrunID inner join Siparis s on su.SiparisID=s.SiparisID inner join Masalar m on m.MasaID=s.MasaID inner join Personel p on p.PersonelID=s.PersonelID  inner join Fis f on f.SiparisUrunID = su.ID inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi where u.UrunAd like @AdaGore + '%' and p.Ad like @GarsonAdaGore + '%' and m.MasaAd like @MasaAdaGore + '%' and ot.OdemeAd like @OdemeTipeGore + '%' and Convert(Date,f.Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            comm.Parameters.Add("@AdaGore", SqlDbType.VarChar).Value = AdaGore;
            comm.Parameters.Add("@GarsonAdaGore", SqlDbType.VarChar).Value = GarsonAdaGore;
            comm.Parameters.Add("@MasaAdaGore", SqlDbType.VarChar).Value = MasaAdaGore;
            comm.Parameters.Add("@OdemeTipeGore", SqlDbType.VarChar).Value = OdemeTipeGore;
            comm.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            comm.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        su.BirimFiyat += Convert.ToDouble(dr["Tutar"]);
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }



            return su.BirimFiyat;
        }

        internal double PersonelSatisGetirGenel(int PersonelID)
        {
            double hesap = 0;
            SqlCommand comm = new SqlCommand("Select ToplamTutar from Siparis where PersonelID=@PersonelID", conn);
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hesap += Convert.ToDouble(dr["ToplamTutar"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return hesap;
        }

        internal double PersonelSatisGetirGünlük(int PersonelID)
        {
            double hesap = 0;
            SqlCommand comm = new SqlCommand("Select ToplamTutar from Siparis where PersonelID=@PersonelID and Convert(date, Tarih, 104)=Convert(date,@Tarih,104)", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hesap += Convert.ToDouble(dr["ToplamTutar"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return hesap;
        }

        internal double PersonelSatisGetirAylik(int PersonelID, int ay)
        {
            double hesap = 0;
            SqlCommand comm = new SqlCommand("Select ToplamTutar from Siparis where PersonelID=@PersonelID and Month(Siparis.Tarih) = @Ay", conn);
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            comm.Parameters.Add("@Ay", SqlDbType.Int).Value = ay;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hesap += Convert.ToDouble(dr["ToplamTutar"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return hesap;
        }

        internal double PersonelSatisGetirYillik(int PersonelID)
        {
            double hesap = 0;
            SqlCommand comm = new SqlCommand("Select ToplamTutar from Siparis where PersonelID=@PersonelID and Year(Siparis.Tarih) = Year(getdate())", conn);
            comm.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        hesap += Convert.ToDouble(dr["ToplamTutar"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return hesap;
        }

        internal void UrunleriGetirByTipeGore(DateTime Tarih1, DateTime Tarih2, ListView liste, string tip)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select u.UrunAd,sum(su.Miktar) as Miktar from Urunler u inner join SiparisUrunler su on u.UrunID=su.UrunID inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID inner join Fis f on f.SiparisUrunID=su.ID where ut.TipAd like @tip + '%' and Convert(Date,f.Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104) group by u.UrunAd  ", conn);
            comm.Parameters.Add("@tip", SqlDbType.VarChar).Value = tip;
            comm.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            comm.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        i++;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

    }
}
