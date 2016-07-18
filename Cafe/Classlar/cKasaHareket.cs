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
    class cKasaHareket
    {
        SqlConnection conn = new SqlConnection(cGenel.connStr);

        DataSet ds = new DataSet();



        public DataSet AlimlariGetir(DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,ut.TipAd,u.UrunAd,IslemTuru,Firma,Tutar,ot.OdemeAd from UrunHareketler uh inner join Urunler u on uh.UrunID=u.UrunID  inner join OdemeTipi ot on ot.OdemeTipi=uh.OdemeTipi  inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID where uh.Silindi=0 and  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;

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





        public DataSet SatislariGetir(DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,IslemTuru,ut.TipAd,u.UrunAd,m.MasaAd,Tutar,ot.OdemeAd from Fis f inner join SiparisUrunler su on f.SiparisUrunID=su.ID  inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi inner join Masalar m on m.MasaID=f.MasaID inner join Urunler u on u.UrunID=su.UrunID inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID  where  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;



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

        internal DataSet FirmayaGoreArama(string FirmaAd, DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,ut.TipAd,u.UrunAd,IslemTuru,Firma,Tutar,ot.OdemeAd from UrunHareketler uh inner join Urunler u on uh.UrunID=u.UrunID  inner join OdemeTipi ot on ot.OdemeTipi=uh.OdemeTipi  inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID where uh.Silindi=0 and  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) and Firma like @Firma + '%'  ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;
            da.SelectCommand.Parameters.Add("@Firma", SqlDbType.VarChar).Value = FirmaAd;



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

        public DataSet MasayaGoreArama(string MasaAd, DateTime ilktarih, DateTime sontarih)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Tarih,IslemTuru,ut.TipAd,u.UrunAd,m.MasaAd,Tutar,ot.OdemeAd from Fis f inner join SiparisUrunler su on f.SiparisUrunID=su.ID  inner join OdemeTipi ot on ot.OdemeTipi=f.OdemeTipi inner join Masalar m on m.MasaID=f.MasaID inner join Urunler u on u.UrunID=su.UrunID inner join UrunTipleri ut on ut.UrunTipID=u.UrunTipID  where  Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104) and m.MasaAd like @MasaAd + '%' ", conn);

            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = ilktarih;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = sontarih;
            da.SelectCommand.Parameters.Add("@MasaAd", SqlDbType.VarChar).Value = MasaAd;



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
