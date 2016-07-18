using Cafe.Classlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class KasaHareket : Form
    {
        public KasaHareket()
        {
            InitializeComponent();
        }

        cUrunHareket uh = new cUrunHareket();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        double ToplamGelir = 0;
        double ToplamGider = 0;
        private void KasaHareket_Load(object sender, EventArgs e)
        {

            dtpIlkTarih.Value = DateTime.Now.AddMonths(-1);
            dtpSonTarih.Value = DateTime.Now;

        }

        private void rbSatislar_CheckedChanged(object sender, EventArgs e)
        {
            ToplamGelir = 0;  // ikinci defa toplamaması için 

            cKasaHareket kh = new cKasaHareket();
            ds = kh.SatislariGetir(dtpIlkTarih.Value, dtpSonTarih.Value);
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];


            foreach (DataRow dr in ds.Tables["KasaHareket"].Rows)
            {

                ToplamGelir += Convert.ToDouble(dr["Tutar"]);
            }

            txtToplamGelir.Text = string.Format("{0:C}", ToplamGelir);
            txtToplamGider.Text = string.Format("{0:C}", ToplamGider);

            txtToplamBakiye.Text = string.Format("{0:C}", ToplamGelir - ToplamGider);

        }

        private void rbAlimlar_CheckedChanged(object sender, EventArgs e)
        {
            ToplamGider = 0;   // ikinci defa toplamaması için 

            cKasaHareket kh = new cKasaHareket();
            ds = kh.AlimlariGetir(dtpIlkTarih.Value, dtpSonTarih.Value);
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];

            foreach (DataRow dr in ds.Tables["KasaHareket"].Rows)
            {

                ToplamGider += Convert.ToDouble(dr["Tutar"]);
            }

            txtToplamGider.Text = string.Format("{0:C}", ToplamGider);
            txtToplamGelir.Text = string.Format("{0:C}", ToplamGelir);

            txtToplamBakiye.Text = string.Format("{0:C}", ToplamGelir - ToplamGider);   // tablolar ayrı geldigi için kar hesabını alış ve satış olarak sabit tuttuk..
        }

        private void rbHepsi_CheckedChanged(object sender, EventArgs e)
        {
        //    cGenel.IslemTuru = "";
        //dt = uh.TarihlerArasıHareketleriGetir(dtpIlkTarih, dtpSonTarih,cGenel.IslemTuru);
        //dgvHareketler.DataSource = dt;

            
        }

        private void btnHareketleriGetir_Click(object sender, EventArgs e)
        {

        }

        private void cbOdemeyeGoreAlim_SelectedIndexChanged(object sender, EventArgs e)
        {
            cOdemeTip ot = new cOdemeTip();
            ds = ot.OdemeTipineGoreAramaAlim(cbOdemeyeGoreAlim.SelectedItem.ToString(), dtpIlkTarih.Value, dtpSonTarih.Value);  // ürün alım için 
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];
        }

        private void CbOdemeyeGore_SelectedIndexChanged(object sender, EventArgs e)
        {
            cOdemeTip ot = new cOdemeTip();
            ds = ot.OdemeTipineGoreArama(CbOdemeyeGore.SelectedItem.ToString(), dtpIlkTarih.Value, dtpSonTarih.Value);  //satıslar için 
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];
        }

        private void txtMasayaGore_TextChanged(object sender, EventArgs e)
        {
            cKasaHareket ks = new cKasaHareket();
            ds = ks.MasayaGoreArama(txtMasayaGore.Text, dtpIlkTarih.Value, dtpSonTarih.Value);   // masalar için (satıs)
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];
        }

        private void txtFirmayaGore_TextChanged(object sender, EventArgs e)
        {
            cKasaHareket ks = new cKasaHareket();
            ds = ks.FirmayaGoreArama(txtFirmayaGore.Text, dtpIlkTarih.Value, dtpSonTarih.Value);   // firma (alim) için 
            dgvKasaHareket.DataSource = ds.Tables["KasaHareket"];
        }
    }
}
