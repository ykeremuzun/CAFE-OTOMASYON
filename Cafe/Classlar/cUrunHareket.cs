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
    class cUrunHareket
    {
        private int _hareketID;
        private int _urunID;
        private DateTime _tarih;
        private string _firma;
        private string _belge;
        private string _birim;
        private int _adet;
        private double _birimFiyat;
        private int _odemeTip;
        private string _islemTuru;


        #region Properties

        public int OdemeTip
        {
            get { return _odemeTip; }
            set { _odemeTip = value; }
        }


        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        }

        public int Adet
        {
            get { return _adet; }
            set { _adet = value; }
        }

        public string Birim
        {
            get { return _birim; }
            set { _birim = value; }
        }


        public string Belge
        {
            get { return _belge; }
            set { _belge = value; }
        }

        public string Firma
        {
            get { return _firma; }
            set { _firma = value; }
        }


        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public int UrunID
        {
            get { return _urunID; }
            set { _urunID = value; }
        }

        public int HareketID
        {
            get { return _hareketID; }
            set { _hareketID = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();


        public DataSet TarihlerArasıHareketleriGetir(DateTimePicker dtpIlkTarih, DateTimePicker dtpSonTarih,string islemtur)
        {
            //DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Convert(Date,s.Tarih, 104) as Tarih,m.MasaAd ,ToplamTutar,p.Ad as Garson   from Siparis s  inner join Masalar m on s.MasaID=m.MasaID  inner join Personel p on p.PersonelID=s.PersonelID  ", conn);

             //Select Convert(Date, uh.Tarih, 104) as Tarih, IslemTuru, ot.OdemeAd, Firma, m.MasaAd, p.Ad,s.Aciklama,Belge,s.SiparisID,uh.HareketID,p.PersonelID,m.MasaID,ot.OdemeTipi from UrunHareketler uh inner join SiparisUrunler su on su.UrunID = uh.UrunID  inner join Siparis s on s.SiparisID=su.SiparisID inner join Personel p on p.PersonelID=s.PersonelID inner join Masalar m on m.MasaID=s.MasaID inner join OdemeTipi ot on ot.OdemeTipi=su.OdemeTipiID where uh.Silindi=0 and Convert(Date, uh.Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104)

          

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = dtpIlkTarih.Value;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = dtpSonTarih.Value;
            try
            {
                da.Fill(ds,"UrunHareketler");
             
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }

        public int UrunHareketEkle(cUrunHareket uh)
        {
            //bool Sonuc = false;
            int sonkayitno = 0;
            SqlCommand comm = new SqlCommand("insert into UrunHareketler (UrunID,Tarih, Firma, Belge, Adet,BirimFiyat,OdemeTipi) values(@UrunID,@Tarih, @Firma, @Belge, @Adet, @BirimFiyat, @OdemeTipi); Select Scope_Identity()", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = uh._tarih;
            //comm.Parameters.Add("@IslemTuru", SqlDbType.VarChar).Value = uh._islemTuru;
            comm.Parameters.Add("@Firma", SqlDbType.VarChar).Value = uh._firma;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = uh._urunID;
            comm.Parameters.Add("@Belge", SqlDbType.VarChar).Value = uh._belge;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = uh._adet;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = uh._birimFiyat;
            comm.Parameters.Add("@OdemeTipi", SqlDbType.Int).Value = uh._odemeTip;

            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonkayitno = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonkayitno;
        }

        public void UrunHareketleriGetir(ListView liste, int UrunID)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select HareketID,u.UrunID,uh.Tarih,IslemTuru, Firma, u.UrunAd,uh.Adet, uh.BirimFiyat,Tutar,Belge,ot.OdemeAd from UrunHareketler uh inner join OdemeTipi ot on uh.OdemeTipi=ot.OdemeTipi inner join Urunler u on u.UrunID=uh.UrunID where uh.Silindi=0  and uh.UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
            if (conn.State == ConnectionState.Closed) conn.Open();
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


        internal void UrunHareketlerinHepsiniGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select HareketID,u.UrunID,uh.Tarih,IslemTuru, Firma, u.UrunAd,uh.Adet, uh.BirimFiyat,Tutar,Belge,ot.OdemeAd from UrunHareketler uh inner join OdemeTipi ot on uh.OdemeTipi=ot.OdemeTipi inner join Urunler u on u.UrunID=uh.UrunID where uh.Silindi=0 ", conn);

            if (conn.State == ConnectionState.Closed) conn.Open();
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

        public bool UrunHareketSil(int HareketID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update UrunHareketler Set Silindi=1 where HareketID=@HareketID", conn);
            comm.Parameters.Add("@HareketID", SqlDbType.Int).Value = HareketID;
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
    }
}
