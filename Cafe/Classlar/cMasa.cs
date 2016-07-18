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
    class cMasa
    {
        private int _masaID;       
        private string _masaAd;

        #region Properties
        public string MasaAd
        {
            get { return _masaAd; }
            set { _masaAd = value; }
        }
        public int MasaID
        {
            get { return _masaID; }
            set { _masaID = value; }
        } 
        #endregion


        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        internal bool MasaDurumDoluYap(cMasa m)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update Masalar set Durum=1 where MasaID=@MasaID and Durum=0", conn);
            comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = _masaID;
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
            return sonuc;
        }

        internal bool MasaDurumBosYap(cMasa m)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update Masalar set Durum=0 where MasaID=@MasaID and Durum=1", conn);
            comm.Parameters.Add("@MasaID", SqlDbType.Int).Value = _masaID;
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
            return sonuc;
        }

        public void MasaGetir(string MasaNo)
        {
            SqlConnection conn = new SqlConnection(cGenel.connStr);
            SqlCommand comm = new SqlCommand("Select MasaID from Masalar where MAsaAd=@MAsaAd", conn);
            comm.Parameters.Add("@MasaAd", SqlDbType.VarChar).Value = MasaNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cGenel.MasaID = Convert.ToInt32(dr[0]);
                }
                dr.Close();
            }
            conn.Close();

        }


        internal bool MAsaAktar(int sipariid, int MAsaID,int EskiMAsa)
        {
            bool sonuc = false;
            SqlCommand comm = new SqlCommand("update Siparis set MasaID=@ID where SiparisID=@SiparisID", conn);
            SqlCommand commm = new SqlCommand("update Masalar set Durum=1 where MasaID=@ID", conn);
            SqlCommand commmm = new SqlCommand("update Masalar set Durum=0 where MasaID=@ID", conn);
            commmm.Parameters.Add("@ID", SqlDbType.Int).Value = EskiMAsa;
            commm.Parameters.Add("@ID", SqlDbType.Int).Value = MAsaID;
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = MAsaID;
            comm.Parameters.Add("@SiparisID", SqlDbType.Int).Value = sipariid;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                commmm.ExecuteNonQuery();
                commm.ExecuteNonQuery();
              sonuc= Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
                MessageBox.Show(hata);
            }
            finally { conn.Close(); }
            return sonuc;
        }
    }
}
