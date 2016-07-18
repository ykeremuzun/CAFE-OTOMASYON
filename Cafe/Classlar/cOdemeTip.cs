using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Classlar
{
    class cOdemeTip
    {
        private int _odemeTip;       
        private string _odemeAd;
        private string _aciklama;


        SqlConnection conn = new SqlConnection(cGenel.connStr);
        DataSet ds = new DataSet();

        #region Properties

        public string OdemeAd
        {
            get { return _odemeAd; }
            set { _odemeAd = value; }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }
        public int OdemeTip
        {
            get { return _odemeTip; }
            set { _odemeTip = value; }
        }
        #endregion

        internal int OdemeTipIDGetir(string odemeTipi)
        {
            int sonuc = 0;
            SqlCommand comm = new SqlCommand("select OdemeTipi from OdemeTipi where OdemeAd=@OdemeAd", conn);
            comm.Parameters.Add("@OdemeAd", SqlDbType.VarChar).Value = odemeTipi;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonuc = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
                System.Windows.Forms.MessageBox.Show(hata);
            }
            finally { conn.Close(); }
            return sonuc;
        }

        internal DataSet OdemeTipineGoreAramaAlim(string OdemeAd, DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,ut.TipAd,u.UrunAd,IslemTuru,Firma,Tutar,ot.OdemeAd from UrunHareketler uh inner join Urunler u on uh.UrunID=u.UrunID  inner join OdemeTipi ot on ot.OdemeTipi=uh.OdemeTipi  inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID where uh.Silindi=0 and  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) and ot.OdemeAd=@OdemeAd  ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;
            da.SelectCommand.Parameters.Add("@OdemeAd", SqlDbType.VarChar).Value = OdemeAd;



            if (conn.State == ConnectionState.Closed)
                conn.Open();

            try
            {
                da.Fill(ds, "KasaHareket");

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return ds;
        }

        public DataSet OdemeTipineGoreArama(string OdemeAd, DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,IslemTuru,ut.TipAd,u.UrunAd,m.MasaAd,Tutar,ot.OdemeAd from Fis f inner join SiparisUrunler su on f.SiparisUrunID=su.ID  inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi inner join Masalar m on m.MasaID=f.MasaID inner join Urunler u on u.UrunID=su.UrunID inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID  where  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) and ot.OdemeAd=@OdemeAd ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;
            da.SelectCommand.Parameters.Add("@OdemeAd", SqlDbType.VarChar).Value = OdemeAd;



            if (conn.State == ConnectionState.Closed)
                conn.Open();

            try
            {
                da.Fill(ds, "KasaHareket");

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return ds;
        }
    }
}
