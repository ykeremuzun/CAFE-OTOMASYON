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
    public partial class HesapAl : Form
    {
        public HesapAl()
        {
            InitializeComponent();
        }
        bool bol = false;
        Font fntBaslik = new Font("Times New Roman", 16, FontStyle.Bold);
        Font fntdetay = new Font("Times New Roman", 12, FontStyle.Regular);
        SolidBrush sr = new SolidBrush(Color.Black);
        public static string OdemeTipi;
        public static double Toplam;
        public static double KalanTutar;
        DataSet ds = new DataSet();

        private void HesapAl_Load(object sender, EventArgs e)
        {
            cSiparis s = new cSiparis();
            s.MasaID = cGenel.MasaID;
            cGenel.siparis = s.SiparisNoGetirByMasaDurumu(s);

            cSiparisUrunler su = new cSiparisUrunler();
            su.SiparisleriGoster(lvSiparisler, cGenel.MasaID, cGenel.siparis);
            ToplamHesapla(lvSiparisler, txtToplamTutar);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //if (txtSayi.Text == "0")
            //{
            //    txtSayi.Clear();
            //}
            //txtSayi.Text += btn.Text;
        }

        private void btnSodexo_Click(object sender, EventArgs e)
        {
            bool sonuc = false;
            OdemeTipi = "";
            int odemeId = 0;
            Button btn = (Button)sender;

            OdemeTipi = btn.Text;
            cSiparisUrunler su = new cSiparisUrunler();
            if (OdemeTipi=="İade")
            {
                for (int i = 0; i < lvFis.Items.Count; i++)
                {
                    lvFis.Items[i].SubItems[4].Text = "0";
                }
            }
           
sonuc = su.HesapGuncelleByOdendi(lvFis);//liste gönderilip içindeki SiparisUrunler Id leri okunuyor ve onlara göre siparişlerin durumu ödendi olarak değiştiriliyor ve liste bidaha gösterilmiyor.
           
           if (sonuc)
            {
                MessageBox.Show("Odendi Durumu Güncellendi");
                cOdemeTip o = new cOdemeTip();
                odemeId = o.OdemeTipIDGetir(OdemeTipi);//Odeme tipi elimizde string olarak bulunduğundan db den ismin karşılığı olan odemetip ıdsini aldık
                sonuc = su.FisKaydet(lvFis, odemeId, cGenel.PersonelID);//sisteme giriş yaptığımızda kaydedilen PersonelID
                if (sonuc)
                {
                    MessageBox.Show("Fis Kaydedildi");
                    btnYazdir_Click(sender, e);
                    lvFis.Items.Clear();
                    

                }
            }
        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            int item = lvFis.Items.Count;//listedeki item sayısını belirleyerek bir sonraki alan belirleniyor.

            double Fiyat = Convert.ToDouble(lvSiparisler.SelectedItems[0].SubItems[4].Text);
            lvFis.Items.Add(lvSiparisler.SelectedItems[0].SubItems[1].Text);
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[2].Text);
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[3].Text);
            lvFis.Items[item].SubItems.Add(Fiyat.ToString());
            lvFis.Items[item].SubItems.Add((Convert.ToDouble(lvSiparisler.SelectedItems[0].SubItems[3].Text) * Fiyat).ToString());
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[8].Text);
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[0].Text);
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[6].Text);
            lvFis.Items[item].SubItems.Add(lvSiparisler.SelectedItems[0].SubItems[7].Text);
            lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedIndices[0]);
            double sayi = 0;
            for (int i = 0; i < lvFis.Items.Count; i++)
            {
                sayi += Convert.ToDouble(lvFis.Items[i].SubItems[4].Text);

            }

            txtSecilen.Text = sayi.ToString();
            ToplamHesapla(lvSiparisler, txtToplamTutar);
        }

        private void ToplamHesapla(ListView liste, TextBox txt)
        {
            double sayi = 0;
            for (int i = 0; i < liste.Items.Count; i++)
            {
                sayi += Convert.ToDouble(liste.Items[i].SubItems[5].Text);
            }
            txt.Text = sayi.ToString();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();     
        }
        int k = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (lvFis.Items.Count != 0)
            {
                StringFormat fmt = new StringFormat();
                fmt.Alignment = StringAlignment.Near;
                e.Graphics.DrawString("KOPERNİK PİZZA", fntBaslik, sr, 300, 200);
                e.Graphics.DrawString("SİPARİS NO : " + lvFis.Items[0].SubItems[8].Text, fntBaslik, sr, 100, 100);
                e.Graphics.DrawString("MASA : " + lvFis.Items[0].SubItems[0].Text, fntBaslik, sr, 100, 120);
                e.Graphics.DrawString(DateTime.Now.ToShortDateString(), fntBaslik, sr, 610, 110);
                e.Graphics.DrawString("  ÜRÜN       ADET       BİRİM FİYAT       TUTAR", fntBaslik, sr, 100, 250);
                e.Graphics.DrawString("________________________________________________________", fntBaslik, sr, 100, 270);
                int j = 0;
                for (int i = k; i < lvFis.Items.Count; i++)
                {
                    e.Graphics.DrawString(lvFis.Items[i].SubItems[1].Text, fntdetay, sr, 110, 300 + j * 30, fmt);
                    e.Graphics.DrawString("x" + lvFis.Items[i].SubItems[2].Text, fntdetay, sr, 250, 300 + j * 30, fmt);
                    e.Graphics.DrawString(lvFis.Items[i].SubItems[3].Text, fntdetay, sr, 320, 300 + j * 30, fmt);
                    fmt.Alignment = StringAlignment.Far;
                    e.Graphics.DrawString(lvFis.Items[i].SubItems[4].Text, fntdetay, sr, 520, 300 + j * 30, fmt);
                    fmt.Alignment = StringAlignment.Near;
                    if (i % 22 == 0 && i != 0)
                    {

                        e.HasMorePages = true;
                        k++;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
                        j++;
                        k++;
                    }
                }
                j++;
                e.Graphics.DrawString("_____________________________________________________", fntBaslik, sr, 100, 300 + j * 30, fmt);
                j++;
                e.Graphics.DrawString("KDV: ", fntBaslik, sr, 290, 300 + j * 30, fmt);
                fmt.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(Convert.ToString(Convert.ToDouble(txtSecilen.Text) * (0.18)) + " TL", fntBaslik, sr, 520, 300 + j * 30, fmt);
                j++;
                fmt.Alignment = StringAlignment.Near;
                e.Graphics.DrawString("Toplam : ", fntBaslik, sr, 290, 300 + j * 30, fmt);
                fmt.Alignment = StringAlignment.Far;
                e.Graphics.DrawString(txtSecilen.Text + " TL", fntBaslik, sr, 520, 300 + j * 30, fmt);
                fmt.Alignment = StringAlignment.Near;
                j++;
                //e.Graphics.DrawString("Bakiye : ", fntBaslik, sr, 290, 300 + j * 30, fmt);
                //fmt.Alignment = StringAlignment.Far;
                //e.Graphics.DrawString(txtBakiye.Text, fntBaslik, sr, 520, 300 + j * 30, fmt);
                k = 0;
            }
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
           
        }
    }
    }

