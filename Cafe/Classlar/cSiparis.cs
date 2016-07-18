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
    class cSiparis
    {
        private int _siparisID;
        private int _masaID;
        private int _odemeTipiID;
        private int _personelID;
        private int _toplamMiktar;
        private double _toplamTutar;
        private DateTime _tarih;
        private string _aciklama;

        #region Properties
        public int SiparisID
        {
            get { return _siparisID; }
            set { _siparisID = value; }
        }


        public int MasaID
        {
            get { return _masaID; }
            set { _masaID = value; }
        }


        public int OdemeTipiID
        {
            get { return _odemeTipiID; }
            set { _odemeTipiID = value; }
        }


        public int PersonelID
        {
            get { return _personelID; }
            set { _personelID = value; }
        }


        public int ToplamMiktar
        {
            get { return _toplamMiktar; }
            set { _toplamMiktar = value; }
        }


        public double ToplamTutar
        {
            get { return _toplamTutar; }
            set { _toplamTutar = value; }
        }


        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }


        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        internal bool SiparisKaydetBySiparis(cSiparis s)
        {
            SqlCommand comm = new SqlCommand("insert into Siparis (MasaID,PersonelID) values (@MasaID,@PersonelID)", conn);
            comm.Parameters.Add("MasaID", SqlDbType.Int).Value = _masaID;
            comm.Parameters.Add("@PersonelID", SqlDbType.VarChar).Value = _personelID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            bool sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            conn.Close();
            return sonuc;

        }

        internal int SiparisNoGetirByMasaDurumu(cSiparis s)
        {
            int No = 0;
            SqlCommand comm = new SqlCommand("select SiparisID From Siparis inner join Masalar on Siparis.MasaID=Masalar.MasaID  where Masalar.MasaID=@MasaID and Masalar.Durum=1", conn);
            comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = _masaID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    No = Convert.ToInt32(dr[0]);
                }

            }
            dr.Close();
            conn.Close();
            return No;
        }

        public void ToplamVeMiktarDuzenle(double toplam, object miktar, int SiparisID)
        {
            SqlCommand comm = new SqlCommand("Update Siparis set ToplamTutar=ToplamTutar+@Toplam,ToplamMiktar=ToplamMiktar+@Miktar where SiparisID=@ID", conn);
            comm.Parameters.Add("@Toplam", SqlDbType.Money).Value = toplam;
            comm.Parameters.Add("@Miktar", SqlDbType.Int).Value = miktar;
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = SiparisID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
                MessageBox.Show(hata);
            }
        }

    }
}
