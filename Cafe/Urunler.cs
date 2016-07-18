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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        private void Urunler_Load(object sender, EventArgs e)
        {
            cUrunTip ut = new cUrunTip();
            ut.UrunTipleriGetir(cbUrunTipi);

            ut.UrunTipleriGetir(cbUrunTipineGore);  // tipe gore arama için
            ut.UrunTipleriGetir(cbTureGore);  // 3.sayfa türleri getirmek için 


            cUrun u = new cUrun();
            u.UrunleriGetir(lvUrunler);  // 1.sayfa urunler listesi
            u.UrunAdlariGetir(cbUrunAd);  // 2.sayfa için ürün adlar 


            txtTarih.Text = DateTime.Now.ToShortDateString();

            cUrunHareket uh = new cUrunHareket();
            uh.UrunHareketleriGetir(lvStokHareket, uh.UrunID);
            uh.UrunHareketlerinHepsiniGetir(lvStokHareket); // sayfa 2 stokhareket listesi

            //cbUrunAd.Items.Insert(0, "Tüm Ürünler");
        }

        private void tsYeni_Click(object sender, EventArgs e)
        {
            tsKaydet.Enabled = true;
            Temizle();

        }

        private void tsKaydet_Click(object sender, EventArgs e)
        {

            txtUrunID.Text = "0";

            if (txtUrunAd.Text.Trim() != "" && txtUrunTip.Text.Trim() != "" && txtStok.Text.Trim() != "" && txtKritikSeviye.Text.Trim() != "")
            {
                cUrun u = new cUrun();
                bool Sonuc = u.UrunVarmi(txtUrunAd.Text, Convert.ToInt32(txtUrunID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Bu Ürün önceden kayıtlı!");
                    txtUrunAd.Focus();
                }
                else
                {
                    u.UrunAd = txtUrunAd.Text;
                    u.Miktar = Convert.ToInt32(txtStok.Text);
                    u.KritikSeviye = Convert.ToInt32(txtKritikSeviye.Text);
                    u.BirimFiyat = Convert.ToDouble(txtUrunFiyat.Text);
                    u.UrunTipID = Convert.ToInt32(txtUrunTipID.Text);
                    u.Aciklama = txtAciklama.Text;



                    if (u.UrunEkle(u))
                    {
                        MessageBox.Show("Yeni Ürün eklendi.");
                        u.UrunleriGetir(lvUrunler);
                        tsKaydet.Enabled = false;
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Ürün Eklemede sorunla karşılaşıldı!");
                        txtUrunAd.Focus();
                    }

                }

            }
        }

        private void cbUrunTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunTip ot = (cUrunTip)cbUrunTipi.SelectedItem;
            txtUrunTip.Text = ot.TipAd;
            txtUrunTipID.Text = Convert.ToString(ot.UrunTipID);
        }

        private void tsDegistir_Click(object sender, EventArgs e)
        {

            if (txtUrunAd.Text.Trim() != "" && txtUrunTip.Text.Trim() != "" && txtStok.Text.Trim() != "" && txtKritikSeviye.Text.Trim() != "")
            {
                cUrun u = new cUrun();
                bool Sonuc = u.UrunVarmi(txtUrunAd.Text, Convert.ToInt32(txtUrunID.Text));

                if (Sonuc)
                {
                    MessageBox.Show("Bu Ürün önceden kayıtlı!");
                    txtUrunAd.Focus();
                }
                else
                {
                    u.UrunAd = txtUrunAd.Text;
                    u.Miktar = Convert.ToInt32(txtStok.Text);
                    u.KritikSeviye = Convert.ToInt32(txtKritikSeviye.Text);
                    u.BirimFiyat = Convert.ToDouble(txtUrunFiyat.Text);
                    u.UrunTipID = Convert.ToInt32(txtUrunTipID.Text);
                    u.Aciklama = txtAciklama.Text;
                    u.UrunID = Convert.ToInt32(txtUrunID.Text);

                    if (u.UrunGuncelle(u))
                    {
                        MessageBox.Show("Ürün Bilgileri güncellendi.");
                        u.UrunleriGetir(lvUrunler);
                        tsDegistir.Enabled = false;
                        tsSil.Enabled = false;
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Urun Güncellemede Sorun !");
                        txtUrunAd.Focus();
                    }
                }
            }
            else { MessageBox.Show("Ürun Adı alanı boş geçilemez!", "Dİkkat! Eksik Bilgi!"); }
        }

        private void Temizle()
        {
            txtUrunAd.Clear();
            txtUrunFiyat.Clear();
            txtAciklama.Clear();
            txtStok.Clear();
            txtKritikSeviye.Clear();
            txtUrunTip.Clear();
            txtUrunTipID.Clear();
            txtUrunAd.Focus();

        }

        private void Temizle2()
        {
            cbUrunAd.SelectedIndex = -1;
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtUrunAd.Clear();
            txtStok.Clear();
            txtOdemeTip.Clear();
            txtOdemeNo.Clear();
            txtMevcutStok.Clear();
            txtFirma.Clear();
            txtBirimFiyat.Clear();
            txtHareketID.Clear();

            txtBirimFiyat.Focus();



        }

        private void lvUrunler_DoubleClick(object sender, EventArgs e)
        {
            tsDegistir.Enabled = true;
            tsSil.Enabled = true;
            txtUrunID.Text = lvUrunler.SelectedItems[0].SubItems[0].Text;
            txtUrunAd.Text = lvUrunler.SelectedItems[0].SubItems[1].Text;
            txtUrunTip.Text = lvUrunler.SelectedItems[0].SubItems[2].Text;
            txtStok.Text = lvUrunler.SelectedItems[0].SubItems[3].Text;
            txtKritikSeviye.Text = lvUrunler.SelectedItems[0].SubItems[4].Text;
            txtUrunFiyat.Text = lvUrunler.SelectedItems[0].SubItems[5].Text;
            txtAciklama.Text = lvUrunler.SelectedItems[0].SubItems[6].Text;
            txtUrunTipID.Text = lvUrunler.SelectedItems[0].SubItems[7].Text;
        }

        private void tsSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cUrun u = new cUrun();
                bool Sonuc = u.UrunSil(Convert.ToInt32(txtUrunID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Ürün Silindi.");
                    u.UrunleriGetir(lvUrunler);
                    tsDegistir.Enabled = false;
                    tsSil.Enabled = false;
                    Temizle();
                }
            }
        }

        private void tsVazgec_Click(object sender, EventArgs e)
        {
            Temizle();
            tsDegistir.Enabled = true;
            tsSil.Enabled = true;
            tsKaydet.Enabled = false;

        }

        private void cbUrunTipineGore_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunTip ot = new cUrunTip();
            ot.UrunleriGetirByTipeGore(lvUrunler, cbUrunTipineGore.SelectedItem.ToString());
        }

        private void txtUrunAdaGore_TextChanged(object sender, EventArgs e)
        {
            cUrunTip ot = new cUrunTip();
            ot.UrunleriGetirByAdaGore(lvUrunler, txtUrunAdaGore.Text);
        }

        private void cbUrunAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunHareket uh = new cUrunHareket();
            if (cbUrunAd.SelectedIndex != -1)
            {
                cUrun u = (cUrun)cbUrunAd.SelectedItem;
                txtUrunID.Text = u.UrunID.ToString();
                txtMevcutStok.Text = u.Miktar.ToString();


                uh.UrunHareketleriGetir(lvStokHareket, Convert.ToInt32(txtUrunID.Text));

                rbTumHareketler.Checked = false;
            }
            else
            {
                rbTumHareketler.Checked = true;
                uh.UrunHareketlerinHepsiniGetir(lvStokHareket);

            }






        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            Temizle2();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtTarih.Text.Trim() != "" && txtMevcutStok.Text.Trim() != "" && txtBirimFiyat.Text.Trim() != "")
            {

                //UrunHareket bilgileri kayıt edilecek...(UrunHareketler)
                cUrunHareket uh = new cUrunHareket();
                uh.Tarih = Convert.ToDateTime(txtTarih.Text);
                uh.Firma = txtFirma.Text;
                uh.UrunID = Convert.ToInt32(txtUrunID.Text);
                uh.BirimFiyat = Convert.ToDouble(txtBirimFiyat.Text);
                uh.Belge = txtBelge.Text;
                uh.Adet = Convert.ToInt32(txtAdet.Text);
                uh.OdemeTip = Convert.ToInt32(txtOdemeNo.Text);




                int kayitno = uh.UrunHareketEkle(uh);
                if (kayitno > 0)
                {
                    MessageBox.Show("Ürün Hareket bilgisi eklendi.");
                    uh.UrunHareketleriGetir(lvStokHareket, uh.UrunID);

                    cUrun u = new cUrun();
                    bool Sonuc = u.UrunStokGuncelleFromUrunHareket(uh.UrunID, uh.Adet);
                    u.UrunleriGetir(lvUrunler);
                    if (Sonuc)
                    {
                        MessageBox.Show("Stok güncellendi!");

                    }
                    else
                    {
                        MessageBox.Show("Stok Güncellenemedi !");
                    }

                }
                else
                {
                    MessageBox.Show("Ürün hareket bilgisi eklenemedi ! ");
                }

            }
            else
            {
                MessageBox.Show("Lütfen ürün seçiniz !", "Eksik Bilgi!");
            }




        }

        private void cbOdemeTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOdemeTip.Text = cbOdemeTip.SelectedItem.ToString();
            switch (cbOdemeTip.SelectedItem.ToString())
            {
                case "Nakit": txtOdemeNo.Text = "1"; break;
                case "KrediKart": txtOdemeNo.Text = "2"; break;
                case "SetCard": txtOdemeNo.Text = "3"; break;
                case "Sodexo": txtOdemeNo.Text = "4"; break;
                case "MultiNet": txtOdemeNo.Text = "5"; break;
                case "Borc": txtOdemeNo.Text = "6"; break;

            }
        }

        private void rbTumHareketler_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTumHareketler.Checked)
            {
                cUrunHareket uh = new cUrunHareket();
                uh.UrunHareketlerinHepsiniGetir(lvStokHareket);
            }

        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (txtTarih.Text.Trim() != "" && txtMevcutStok.Text.Trim() != "" && txtBirimFiyat.Text.Trim() != "")
            {


                cUrunHareket uh = new cUrunHareket();
                uh.Tarih = Convert.ToDateTime(txtTarih.Text);
                uh.Firma = txtFirma.Text;
                uh.UrunID = Convert.ToInt32(txtUrunID.Text);
                uh.BirimFiyat = Convert.ToInt32(txtBirimFiyat.Text);
                uh.Belge = txtBelge.Text;
                uh.Adet = Convert.ToInt32(txtAdet.Text);
                uh.OdemeTip = Convert.ToInt32(txtOdemeNo.Text);
            }


        }



        private void lvStokHareket_DoubleClick(object sender, EventArgs e)
        {

            btnSil.Enabled = true;

            txtHareketID.Text = lvStokHareket.SelectedItems[0].SubItems[0].Text;
            txtUrunID.Text = lvStokHareket.SelectedItems[0].SubItems[1].Text;
            txtAdet.Text = lvStokHareket.SelectedItems[0].SubItems[6].Text;



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ürün Hareketi İptal etmek istiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                cUrunHareket uh = new cUrunHareket();
                bool Sonuc = uh.UrunHareketSil(Convert.ToInt32(txtHareketID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Ürün Hareket bilgisi silindi.");
                    uh.UrunHareketleriGetir(lvStokHareket, Convert.ToInt32(txtUrunID.Text));

                    cUrun u = new cUrun();
                    Sonuc = u.UrunStokGuncelleFromUrunHareketSil(Convert.ToInt32(txtUrunID.Text), Convert.ToInt32(txtAdet.Text));
                    if (Sonuc)
                    {

                        u.UrunleriGetir(lvUrunler);
                        MessageBox.Show("Stok güncellendi!");
                        Temizle2();



                    }
                    else MessageBox.Show("Stok güncellenemedi!");
                }
                else MessageBox.Show("Ürün Hareket eklenemedi!");
            }
        }

        private void rbKritikSeviye_CheckedChanged(object sender, EventArgs e)
        {
            cUrun u = new cUrun();
            ds = u.KritikSeviyeninAltindakiUrunler();
            dgvStok.DataSource = ds.Tables["Stok"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Stok"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["SiparisMiktar"]);
                ToplamTutar += Convert.ToDouble(dr["SiparisTutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            //txtToplamTutar.Text = ToplamTutar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvStok.Columns["SiparisMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStok.Columns["SiparisTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void GridViewDuzenle()
        {
            dgvStok.Columns["UrunAd"].Width = 145;
            dgvStok.Columns["Miktar"].Width = 70;
            dgvStok.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStok.Columns["BirimFiyat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStok.Columns["KritikSeviye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void rbTumUrunler_CheckedChanged(object sender, EventArgs e)
        {
            cUrun u = new cUrun();
            ds = u.UrunleriGetirByTumu();
            dgvStok.DataSource = ds.Tables["Stok"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Stok"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["Miktar"]);
                ToplamTutar += Convert.ToDouble(dr["Tutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvStok.Columns["UrunAd"].Width = 225;
            dgvStok.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void cbTureGore_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrun u = new cUrun();
            ds = u.UrunleriGetirByTur(cbTureGore.SelectedItem.ToString());
            dgvStok.DataSource = ds.Tables["Stok"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Stok"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["Miktar"]);
                ToplamTutar += Convert.ToDouble(dr["Tutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvStok.Columns["UrunAd"].Width = 225;
            dgvStok.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void txtUrunAdaGore2_TextChanged(object sender, EventArgs e)
        {
            cUrunTip ot = new cUrunTip();
            ds = ot.UrunleriGetirByAdaGore2(txtUrunAdaGore2.Text);
            dgvStok.DataSource = ds.Tables["Stok"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Stok"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["Miktar"]);
                ToplamTutar += Convert.ToDouble(dr["Tutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvStok.Columns["UrunAd"].Width = 225;
            dgvStok.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
