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
    public partial class SatisTablosu : Form
    {
        public SatisTablosu()
        {
            InitializeComponent();
        }

        private void btnSatislariGetir_Click(object sender, EventArgs e)
        {
            cSiparisUrunler su = new cSiparisUrunler();
            su.SatislariGetirByTarihlerArasi(dtpTarih1.Value, dtpTarih2.Value, lvSatislarWithoutOdemeTipi);
            //SatislariGetir();
            MiktarTutarGetir();
        }

        

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            SatislariGetir();
            MiktarTutarGetir();
        }

        private void txtMasaAdaGore_TextChanged(object sender, EventArgs e)
        {
            SatislariGetir();
            MiktarTutarGetir();
        }

        private void txtGarsonAdaGore_TextChanged(object sender, EventArgs e)
        {
            SatislariGetir();
            MiktarTutarGetir();
        }

        private void MiktarTutarGetir()
        {
            cSiparisUrunler su = new cSiparisUrunler();
            txtToplamMiktar.Text = (su.MiktarGetir(txtAdaGore.Text, txtGarsonAdaGore.Text, txtMasaAdaGore.Text, txtOdemeTipineGore.Text, dtpTarih1.Value, dtpTarih2.Value)).ToString();
            txtToplamTutar.Text = (su.TutarGetir(txtAdaGore.Text, txtGarsonAdaGore.Text, txtMasaAdaGore.Text, txtOdemeTipineGore.Text, dtpTarih1.Value, dtpTarih2.Value)).ToString();
        }

        private void SatislariGetir()
        {
            cSiparisUrunler su = new cSiparisUrunler();
            su.SatislariGetirByDetaySorgulama(txtAdaGore.Text, txtGarsonAdaGore.Text, txtMasaAdaGore.Text, txtOdemeTipineGore.Text, lvSatislarWithoutOdemeTipi, dtpTarih1.Value, dtpTarih2.Value);
        }

        private void SatisTablosu_Load(object sender, EventArgs e)
        {
            dtpTarih1.Value = DateTime.Now.AddMonths(-1);
        }

        private void txtOdemeTipineGore_TextChanged(object sender, EventArgs e)
        {
            SatislariGetir();
            MiktarTutarGetir();
        }
    }
}
