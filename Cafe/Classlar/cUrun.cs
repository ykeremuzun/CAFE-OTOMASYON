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
    class cUrun
    {
        private int _urunID; 
        private string _urunAd;
        private int _urunTipID;
        private int _miktar;
        private int _kritikSeviye;
        private double _birimFiyat;
        private string _aciklama;

        #region Properties

        public int UrunID
        {
            get { return _urunID; }
            set { _urunID = value; }
        }
        public string UrunAd
        {
            get { return _urunAd; }
            set { _urunAd = value; }
        }
        public int UrunTipID
        {
            get { return _urunTipID; }
            set { _urunTipID = value; }
        }
        public int Miktar
        {
            get { return _miktar; }
            set { _miktar = value; }
        }
        public int KritikSeviye
        {
            get { return _kritikSeviye; }
            set { _kritikSeviye = value; }
        }
        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        }
        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        public bool UrunVarmi(string UrunAd, int UrunID)
        {
            bool Varmi = false;
            SqlCommand comm = new SqlCommand("Select Count(*) from Urunler where Varmi=1 and UrunAd=@UrunAd and UrunID!=@UrunID", conn);
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = UrunAd;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;

            if (conn.State == ConnectionState.Closed) conn.Open();
            int Sayisi = Convert.ToInt32(comm.ExecuteScalar());
            if (Sayisi > 0)
            {
                Varmi = true;
            }
            conn.Close();
            return Varmi;
        }

        internal void UrunleriGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunID,UrunAd,UrunTipleri.TipAd,Miktar,KritikSeviye,BirimFiyat,Urunler.Aciklama,Urunler.UrunTipID from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1", conn);
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

        public bool UrunEkle(cUrun u)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Urunler (UrunAd, UrunTipID, Miktar, KritikSeviye, BirimFiyat, Aciklama) values (@UrunAd,@UrunTipID,@Miktar,@KritikSeviye,@BirimFiyat,@Aciklama)", conn);
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = u._urunAd;
            comm.Parameters.Add("@UrunTipID", SqlDbType.Int).Value = u._urunTipID;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = u._miktar;
            comm.Parameters.Add("@KritikSeviye", SqlDbType.Int).Value = u._kritikSeviye;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = u._birimFiyat;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = u._aciklama;


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

        internal bool UrunGuncelle(cUrun u)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Urunler set UrunAd=@UrunAd, UrunTipID=@UrunTipID, Miktar=@Miktar , KritikSeviye=@KritikSeviye, BirimFiyat=@BirimFiyat, Aciklama=@Aciklama where UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = u._urunAd;
            comm.Parameters.Add("@UrunTipID", SqlDbType.Int).Value = u._urunTipID;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = u._miktar;
            comm.Parameters.Add("@KritikSeviye", SqlDbType.Int).Value = u._kritikSeviye;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = u._birimFiyat;
            comm.Parameters.Add("@Aciklama", SqlDbType.VarChar).Value = u._aciklama;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = u._urunID;

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

        public bool UrunSil(int UrunID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("update Urunler set Varmi=0 where UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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


        public void UrunAdlariGetir(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Urunler where Varmi=1", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //liste.Items.Add(dr["UrunAd"].ToString());  // miktar ve birimfiyatı almak için nesneye cevirdik

                    cUrun u = new cUrun();
                    u._urunAd = dr["UrunAd"].ToString();
                    u._miktar = Convert.ToInt32(dr["Miktar"]);
                    u._birimFiyat = Convert.ToDouble(dr["BirimFiyat"]);
                    u._urunID = Convert.ToInt32(dr["UrunID"]);
                    liste.Items.Add(u);
                }
                dr.Close();
            }
            conn.Close();
        }

        public override string ToString()   
        {
            return _urunAd;
        }

        public bool UrunStokGuncelleFromUrunHareket(int UrunID, int Adet)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set Miktar = Miktar + @Adet where UrunID=@UrunID", conn);
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = Adet;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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

        public void UrunleriGetirByTipeGore(ListView liste, string tip)
        {
            SqlCommand comm = new SqlCommand("Select  UrunID,UrunAd,TipAd,BirimFiyat,u.Aciklama from Urunler u inner join UrunTipleri ut on u.UrunTipID=ut.UrunTipID where Varmi=1 and Tipad=@Tip ", conn);
            comm.Parameters.Add("@Tip", SqlDbType.VarChar).Value = tip;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    liste.Items.Clear();
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[1].ToString(), 0);
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        liste.Items[i].SubItems.Add(dr[0].ToString());
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

        public bool StokDus(ListView liste)
        {
            bool sonuc = false;
            for (int i = 0; i < liste.Items.Count; i++)
            {


                SqlCommand comm = new SqlCommand("update Urunler set Miktar=Miktar-@Miktar where UrunID=@UrunID ", conn);
                comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[7].Text);
                comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = Convert.ToInt32(liste.Items[i].SubItems[3].Text);
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

        public bool UrunStokGuncelleFromUrunHareketSil(int UrunID, int Adet)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set Miktar = Miktar - @Adet where UrunID=@UrunID", conn);

            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = Adet;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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

        public DataSet KritikSeviyeninAltindakiUrunler()
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,UrunTipleri.TipAd,BirimFiyat,Miktar,KritikSeviye,KritikSeviye - Miktar as SiparisMiktar,(KritikSeviye - Miktar) * BirimFiyat as SiparisTutar from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1 and KritikSeviye>=Miktar", conn);
            try
            {
                da.Fill(ds, "Stok");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }

        internal DataSet UrunleriGetirByTumu()
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select  UrunAd, UrunTipleri.TipAd, BirimFiyat,  Miktar,KritikSeviye, Miktar * BirimFiyat as Tutar  from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1", conn);
            try
            {
                da.Fill(ds, "Stok");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }

        internal DataSet UrunleriGetirByTur(string TurAd)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select  UrunAd, UrunTipleri.TipAd, BirimFiyat,  Miktar,KritikSeviye, Miktar * BirimFiyat as Tutar  from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1 and UrunTipleri.TipAd=@TurAd", conn);
            da.SelectCommand.Parameters.Add("@TurAd", SqlDbType.VarChar).Value = TurAd;
            try
            {
                da.Fill(ds, "Stok");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
    }
}
