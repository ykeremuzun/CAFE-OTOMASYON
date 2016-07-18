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
    class cUrunTip
    {
        private int _urunTipID;
        private string _tipAd;
        private string _aciklama;

        #region Properties

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public string TipAd
        {
            get { return _tipAd; }
            set { _tipAd = value; }
        }


        public int UrunTipID
        {
            get { return _urunTipID; }
            set { _urunTipID = value; }
        }
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();



        //public void UrunTipleriGetir(ComboBox liste)
        //{
        //    liste.Items.Clear();
        //    SqlCommand comm = new SqlCommand("Select * from UrunTipleri where Silindi=0", conn);
        //    if (conn.State == ConnectionState.Closed) conn.Open();
        //    SqlDataReader dr;
        //    dr = comm.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            liste.Items.Add(dr["TipAd"].ToString());
        //        }
        //        dr.Close();
        //    }
        //    conn.Close();
        //} 

        public void UrunTipleriGetir(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from UrunTipleri where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cUrunTip ot = new cUrunTip();
                    ot._urunTipID = Convert.ToInt32(dr["UrunTipID"]);
                    ot._tipAd = dr["TipAd"].ToString();
                    liste.Items.Add(ot);

                }
                dr.Close();
            }
            conn.Close();


        }

        public override string ToString()
        {
            return _tipAd;
        }



        public void UrunleriGetirByTipeGore(ListView liste, string UrunTip)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunID,UrunAd,UrunTipleri.TipAd,Miktar,KritikSeviye,BirimFiyat,Urunler.Aciklama,Urunler.UrunTipID from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1 and UrunTipleri.TipAd=@UrunTip ", conn);
            comm.Parameters.Add("@UrunTip", SqlDbType.VarChar).Value = UrunTip;
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

        internal void UrunleriGetirByAdaGore(ListView liste, string UrunAd)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunID,UrunAd,UrunTipleri.TipAd,Miktar,KritikSeviye,BirimFiyat,Urunler.Aciklama,Urunler.UrunTipID from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1 and UrunAd like @UrunAd + '%' ", conn);
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = UrunAd;
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

        internal DataSet UrunleriGetirByAdaGore2(string Ad)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select  UrunAd, UrunTipleri.TipAd, BirimFiyat,  Miktar,KritikSeviye, Miktar * BirimFiyat as Tutar  from Urunler inner join UrunTipleri on Urunler.UrunTipID = UrunTipleri.UrunTipID where Varmi=1 and UrunAd like @UrunAd + '%' ", conn);
            da.SelectCommand.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = Ad;
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
