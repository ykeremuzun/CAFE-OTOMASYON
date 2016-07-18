using Cafe.Classlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class SiparisEkrani : Form
    {
        public SiparisEkrani()
        {
            InitializeComponent();
        }

        public static int miktar = 0;
        public static double Toplam = 0;
        SqlConnection conn = new SqlConnection(cGenel.connStr);

        private void SiparisEkrani_Load(object sender, EventArgs e)
        {
            cMasa m = new cMasa();
            m.MasaGetir(cGenel.MasaNo);
            txtMAsaNo.Text = cGenel.MasaID.ToString();
            txtMasaAd.Text = cGenel.MasaNo;
            cSiparisUrunler su = new cSiparisUrunler();
            cSiparis s = new cSiparis();
            s.MasaID = cGenel.MasaID;
            s.PersonelID = cGenel.PersonelID;
            s.Tarih = DateTime.Now;
            cGenel.siparis = s.SiparisNoGetirByMasaDurumu(s);
            su.SiparisleriGoster(lvSiparisler, cGenel.MasaID, cGenel.siparis);
            su.SiparisleriGosterEklemeli(lvEklemeli, cGenel.MasaID, cGenel.siparis);
            
            Toplama(lvSiparisler, txtToplam);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtSayi.Text += btn.Text;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtSayi.Clear();
        }

        private void pbPizza_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvUrunler, pbPizza.Tag.ToString());
        }

        private void pbIcecek_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvUrunler, pbIcecek.Tag.ToString());
        }

        private void pbSalata_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvUrunler, pbSalata.Tag.ToString());
        }

        private void pbTatli_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvUrunler, pbTatli.Tag.ToString());
        }

        private void pbYan_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvUrunler, pbYan.Tag.ToString());
        }

        private void UrunleriListele(ListView liste, string Tip)//Tiplere göre Listelemek için Metot oluşturuldu
        {
            cUrun u = new cUrun();
            u.UrunleriGetirByTipeGore(liste, Tip);
        }

        private void lvUrunler_DoubleClick(object sender, EventArgs e)
        {
            int item = lvAraSiparis.Items.Count;//listedeki item sayısını belirleyerek bir sonraki alan belirleniyor.

            double Fiyat = Convert.ToDouble(lvUrunler.SelectedItems[0].SubItems[1].Text);
            lvAraSiparis.Items.Add(txtMAsaNo.Text);
            lvAraSiparis.Items[item].SubItems.Add(txtMasaAd.Text);
            lvAraSiparis.Items[item].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[0].Text);
            if (txtSayi.Text == "")
            {
                txtSayi.Text = "1";
            }
            double miktar = Convert.ToDouble("1");
            txtSayi.Text = "1";
            lvAraSiparis.Items[item].SubItems.Add(miktar.ToString());
            lvAraSiparis.Items[item].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[1].Text);
            lvAraSiparis.Items[item].SubItems.Add((miktar * Fiyat).ToString());
            lvAraSiparis.Items[item].SubItems.Add(cGenel.PersonelID.ToString());
            lvAraSiparis.Items[item].SubItems.Add(lvUrunler.SelectedItems[0].SubItems[3].Text);
        }

        private void btnIndirim_Click(object sender, EventArgs e)
        {
            if (txtSayi.Text == "")

                MessageBox.Show("Fiyat Giriniz!!!");
            else if (lvAraSiparis.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Sipariş Seçiniz");

            }
            else
            {
                lvAraSiparis.SelectedItems[0].SubItems[4].Text = txtSayi.Text;
                lvAraSiparis.SelectedItems[0].SubItems[5].Text = (Convert.ToDouble(lvAraSiparis.SelectedItems[0].SubItems[3].Text) * Convert.ToDouble(lvAraSiparis.SelectedItems[0].SubItems[4].Text)).ToString();
                txtSayi.Text = "1";
                lvAraSiparis.Refresh();
            }
        }

        private void btnSiparisSil_Click(object sender, EventArgs e)
        {
            if (lvAraSiparis.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Sipariş Seçiniz");

            }
            else
            {
                lvAraSiparis.Items.RemoveAt(lvAraSiparis.SelectedIndices[0]);

            }
        }

        private void btnSiparisOnayla_Click(object sender, EventArgs e)
        {
            cSiparis s = new cSiparis();
            cMasa m = new cMasa();
            m.MasaID = Convert.ToInt32(txtMAsaNo.Text);
            s.MasaID = cGenel.MasaID;
            s.PersonelID = cGenel.PersonelID;
            s.Tarih = DateTime.Now;
            bool sonuc = m.MasaDurumDoluYap(m);//Boşsa Masa durumunu true yapıp 1 döndürcek.boşssa işlem yapmıcak 0 döndürcek.
            if (sonuc)//eğer masa durumu Boş gözüküyorsa bu alana gircek ve yeni bir sipariş numarası oluşturcak.
            {
                Masalar ma = new Masalar();
                ma.btnT1.BackgroundImage = Properties.Resources.DoluMasa;
                MessageBox.Show("Masa Güncellendi");
                sonuc = s.SiparisKaydetBySiparis(s);
                if (sonuc)
                {
                    MessageBox.Show("Boş Masaya Sipariş Numarası oluşturuldu");
                    cGenel.siparis = s.SiparisNoGetirByMasaDurumu(s);//mevcut SiparisID yi saklamak için.
                }
            }
            else
            {
                cGenel.siparis = s.SiparisNoGetirByMasaDurumu(s);//eğer masa aktifse ve tekrar sipariş girilcekse bu alana girip aktif olan sipariş numarasını alıcak.
            }
            cSiparisUrunler su = new cSiparisUrunler();
            ToplamAl(lvAraSiparis);
            sonuc = su.SiparisKaydetBySiparisUrun(lvAraSiparis, cGenel.siparis);
            if (sonuc)
            {
                MessageBox.Show("Sipariş Kayıt Tamamlandı");

                su.SiparisleriGoster(lvSiparisler, cGenel.MasaID, cGenel.siparis);
                su.SiparisleriGosterEklemeli(lvEklemeli, cGenel.MasaID, cGenel.siparis);
                s.ToplamVeMiktarDuzenle(Toplam, miktar, cGenel.siparis);
                cUrun u = new cUrun();
                sonuc = u.StokDus(lvAraSiparis);//SiparişID'si Ve Miktar KAdar içerdeki stoktan düşürüyoruz.
                lvAraSiparis.Items.Clear();
                Toplam = 0;
                miktar = 0;
                if (sonuc)
                {
                    MessageBox.Show("Stok Güncelleme Yapıldı");
                }

            }
            Toplama(lvSiparisler, txtToplam);
        }

        private void ToplamAl(ListView liste)
        {


            for (int i = 0; i < liste.Items.Count; i++)
            {
                miktar += Convert.ToInt32(liste.Items[i].SubItems[3].Text);
                Toplam += Convert.ToDouble(liste.Items[i].SubItems[5].Text);
            }
        }

        private void txtSayi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHesapAl_Click(object sender, EventArgs e)
        {
            HesapAl frm = new HesapAl();
            frm.ShowDialog();
            cSiparisUrunler su = new cSiparisUrunler();
            su.SiparisleriGoster(lvSiparisler, cGenel.MasaID, cGenel.siparis);
            su.SiparisleriGosterEklemeli(lvEklemeli, cGenel.MasaID, cGenel.siparis);
            Toplama(lvSiparisler, txtToplam);
            if (lvSiparisler.Items.Count == 0)
            {
                btnMasaKapat.Enabled = true;
            }
        }

        private void Toplama(ListView liste, TextBox txt)
        {
            double sayi = 0;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                sayi += Convert.ToDouble(liste.Items[i].SubItems[5].Text);
            }
            txt.Text = sayi.ToString();
        }

        private void btnMasaKapat_Click(object sender, EventArgs e)
        {
            cSiparis s = new cSiparis();
            s.MasaID = cGenel.MasaID;
            s.PersonelID = cGenel.PersonelID;
            cGenel.siparis = s.SiparisNoGetirByMasaDurumu(s);
            cSiparisUrunler su = new cSiparisUrunler();
            su.SiparisleriGoster(lvSiparisler, cGenel.MasaID, cGenel.siparis);
            if (txtToplam.Text != "0")
            {
                if (MessageBox.Show("Hesap Ödenmemiş Kapatmak İstediğine Eminmisin!!!", "Dikkat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cMasa m = new cMasa();
                    m.MasaID = Convert.ToInt32(txtMAsaNo.Text);
                    bool sonuc = m.MasaDurumBosYap(m);
                    if (sonuc)
                    {
                        MessageBox.Show("MAsa Durumu Boş");
                    }
                }

            }
            else if (txtToplam.Text == "0")
            {
                cMasa m = new cMasa();
                m.MasaID = Convert.ToInt32(txtMAsaNo.Text);
                bool sonuc = m.MasaDurumBosYap(m);
                if (sonuc)
                {
                    MessageBox.Show("MAsa Durumu Boş");
                }
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            int mn = 0;
            MasaAktar ma = new MasaAktar();
            ma.ShowDialog();
            cMasa m = new cMasa();
           mn=Convert.ToInt32(txtMAsaNo.Text);
           bool sonuc= m.MAsaAktar(cGenel.siparis,cGenel.MasaID,mn);
           if (sonuc)
               MessageBox.Show("Masa Aktarıldı");
           this.Close();
        }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
