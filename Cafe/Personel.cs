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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }

        //int resim = 0;

        private void Personel_Load(object sender, EventArgs e)
        {
            btnPersonelDuzenle.Enabled = false;
            btnPersonelSil.Enabled = false;
            btnPersonelKaydet.Enabled = false;
            cbYetki.SelectedIndex = 1;
            lvPersonel.View = View.Details;
            cPersonel p = new cPersonel();
            p.PersonelGetir(lvPersonel);




        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            btnPersonelKaydet.Enabled = true;
            Temizle();



        }

        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            if (txtPersonelAd.Text.Trim() != "" && txtPersonelSoyad.Text.Trim() != "" && txtPersonelTcNo.Text.Trim() != "")
            {

                if (txtPersonelAd.Text.Trim() != "" && txtPersonelSoyad.Text.Trim() != "" && txtPersonelTcNo.Text.Trim() != "")
                {
                    cPersonel p = new cPersonel();
                    if (p.PersonelVarmi(txtPersonelTcNo.Text, txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2)))// TcNo'ya göre önceden kayıtlı olup olmadıgı kontrolü
                    {
                        MessageBox.Show("Girdiğiniz personel zaten kayıtlı!");
                        txtPersonelAd.Focus();
                    }
                    else
                    {
                        //int resim = 0; 
                        p.KullaniciAd = txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2);
                        p.Ad = txtPersonelAd.Text;
                        p.Soyad = txtPersonelSoyad.Text;
                        p.TcNo = txtPersonelTcNo.Text;
                        p.Telefon = txtPersonelTelefon.Text;
                        p.Sifre = txtPersonelSifre.Text;
                        p.Yetki = cbYetki.SelectedItem.ToString();


                        if (p.PersonelEkle(p))
                        {

                            MessageBox.Show("Personel Başarıyla Kaydedildi.");
                            p.PersonelGetir(lvPersonel);
                            btnPersonelKaydet.Enabled = false;
                            Temizle();
                        }
                        else { MessageBox.Show("Personel Bilgileri kayıt edilemedi !"); }


                    }
                }
            }
            }

       

        private void lvPersonel_DoubleClick(object sender, EventArgs e)
        {
            txtPersonelID.Text = lvPersonel.SelectedItems[0].SubItems[0].Text;
            txtPersonelAd.Text = lvPersonel.SelectedItems[0].SubItems[1].Text;
            txtPersonelSoyad.Text = lvPersonel.SelectedItems[0].SubItems[2].Text;
            txtPersonelTcNo.Text = lvPersonel.SelectedItems[0].SubItems[3].Text;
            txtPersonelTelefon.Text = lvPersonel.SelectedItems[0].SubItems[4].Text;
            txtPersonelKullaniciAd.Text = lvPersonel.SelectedItems[0].SubItems[5].Text;
            txtPersonelSifre.Text = lvPersonel.SelectedItems[0].SubItems[6].Text;
            txtPersonelYetki.Text = lvPersonel.SelectedItems[0].SubItems[7].Text;
            btnPersonelDuzenle.Enabled = true;
            btnPersonelSil.Enabled = true;
            btnPersonelKaydet.Enabled = false;

            txtPersonelAd.Focus();

        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            cPersonel p = new cPersonel();
            p.PersonelGetirByAdaGore(txtAdaGore.Text, lvPersonel);  // yazılacak 
        }

        private void btnPersonelDuzenle_Click(object sender, EventArgs e)
        {

            if (txtPersonelAd.Text.Trim() != "" && txtPersonelSoyad.Text.Trim() != "" && txtPersonelTcNo.Text.Trim() != "")
            {
                cPersonel p = new cPersonel();
                p.PersonelID = Convert.ToInt32(txtPersonelID.Text);
                p.Ad = txtPersonelAd.Text;
                p.Soyad = txtPersonelSoyad.Text;
                p.TcNo = txtPersonelTcNo.Text;
                p.Telefon = txtPersonelTelefon.Text;
                p.KullaniciAd = txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2);
                p.Sifre = txtPersonelSifre.Text;
                p.Yetki = cbYetki.SelectedItem.ToString();



                if (p.PersonelGuncelle(p))
                {
                    MessageBox.Show("Personel Başarıyla Güncellendi.");
                    p.PersonelGetir(lvPersonel);
                    btnPersonelDuzenle.Enabled = false;
                    btnPersonelSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Personel Bilgileri GüncellenMedi !"); }


            }
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cPersonel p = new cPersonel();
                bool Sonuc = p.PersonelSil(Convert.ToInt32(txtPersonelID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Müşteri Bilgileri silindi.");
                    p.PersonelGetir(lvPersonel);
                    btnPersonelDuzenle.Enabled = false;
                    btnPersonelSil.Enabled = false;
                    Temizle();
                }
            }
        }

        private void rbResimGorunum_CheckedChanged(object sender, EventArgs e)
        {
            lvPersonel.View = View.LargeIcon;
        }

        private void rbDetayliGorunum_CheckedChanged(object sender, EventArgs e)
        {
            lvPersonel.View = View.Details;
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYeniPersonel_Click_1(object sender, EventArgs e)
        {
            btnPersonelKaydet.Enabled = true;
            Temizle();
        }

        private void btnPersonelKaydet_Click_1(object sender, EventArgs e)
        {
            if (txtPersonelAd.Text.Trim() != "" && txtPersonelSoyad.Text.Trim() != "" && txtPersonelTcNo.Text.Trim() != "")
            {
                cPersonel p = new cPersonel();
                if (p.PersonelVarmi(txtPersonelTcNo.Text, txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2)))// TcNo'ya göre önceden kayıtlı olup olmadıgı kontrolü
                {
                    MessageBox.Show("Girdiğiniz personel zaten kayıtlı!");
                    txtPersonelAd.Focus();
                }
                else
                {
                    //int resim = 0; 
                    p.KullaniciAd = txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2);
                    p.Ad = txtPersonelAd.Text;
                    p.Soyad = txtPersonelSoyad.Text;
                    p.TcNo = txtPersonelTcNo.Text;
                    p.Telefon = txtPersonelTelefon.Text;
                    p.Sifre = txtPersonelSifre.Text;
                    p.Yetki = cbYetki.SelectedItem.ToString();


                    if (p.PersonelEkle(p))
                    {

                        MessageBox.Show("Personel Başarıyla Kaydedildi.");
                        p.PersonelGetir(lvPersonel);
                        btnPersonelKaydet.Enabled = false;
                        Temizle();
                    }
                    else { MessageBox.Show("Personel Bilgileri kayıt edilemedi !"); }


                }
            }

        }

        private void btnPersonelDuzenle_Click_1(object sender, EventArgs e)
        {
            if (txtPersonelAd.Text.Trim() != "" && txtPersonelSoyad.Text.Trim() != "" && txtPersonelTcNo.Text.Trim() != "")
            {
                cPersonel p = new cPersonel();
                p.PersonelID = Convert.ToInt32(txtPersonelID.Text);
                p.Ad = txtPersonelAd.Text;
                p.Soyad = txtPersonelSoyad.Text;
                p.TcNo = txtPersonelTcNo.Text;
                p.Telefon = txtPersonelTelefon.Text;
                p.KullaniciAd = txtPersonelAd.Text + txtPersonelTcNo.Text.Substring(9, 2);
                p.Sifre = txtPersonelSifre.Text;
                p.Yetki = cbYetki.SelectedItem.ToString();



                if (p.PersonelGuncelle(p))
                {
                    MessageBox.Show("Personel Başarıyla Güncellendi.");
                    p.PersonelGetir(lvPersonel);
                    btnPersonelDuzenle.Enabled = false;
                    btnPersonelSil.Enabled = false;
                    Temizle();
                }
                else { MessageBox.Show("Personel Bilgileri GüncellenMedi !"); }


            }
        }

        private void btnPersonelSil_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cPersonel p = new cPersonel();
                bool Sonuc = p.PersonelSil(Convert.ToInt32(txtPersonelID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Personel Bilgileri silindi.");
                    p.PersonelGetir(lvPersonel);
                    btnPersonelDuzenle.Enabled = false;
                    btnPersonelSil.Enabled = false;
                    Temizle();
                }
            }
        }




        private void Temizle()
        {
            txtPersonelAd.Clear();
            txtPersonelKullaniciAd.Clear();
            txtPersonelSifre.Clear();
            txtPersonelSoyad.Clear();
            txtPersonelTcNo.Clear();
            txtPersonelTelefon.Clear();
            cbYetki.SelectedIndex = 1;
            txtPersonelAd.Focus();

        }

        private void lvPersonel_DoubleClick_1(object sender, EventArgs e)
        {
            txtPersonelID.Text = lvPersonel.SelectedItems[0].SubItems[0].Text;
            txtPersonelAd.Text = lvPersonel.SelectedItems[0].SubItems[1].Text;
            txtPersonelSoyad.Text = lvPersonel.SelectedItems[0].SubItems[2].Text;
            txtPersonelTcNo.Text = lvPersonel.SelectedItems[0].SubItems[3].Text;
            txtPersonelTelefon.Text = lvPersonel.SelectedItems[0].SubItems[4].Text;
            txtPersonelKullaniciAd.Text = lvPersonel.SelectedItems[0].SubItems[5].Text;
            txtPersonelSifre.Text = lvPersonel.SelectedItems[0].SubItems[6].Text;
            txtPersonelYetki.Text = lvPersonel.SelectedItems[0].SubItems[7].Text;
            btnPersonelDuzenle.Enabled = true;
            btnPersonelSil.Enabled = true;
            btnPersonelKaydet.Enabled = false;

            txtPersonelAd.Focus();
        }

        private void txtAdaGore_TextChanged_1(object sender, EventArgs e)
        {
            cPersonel p = new cPersonel();
            p.PersonelGetirByAdaGore(txtAdaGore.Text, lvPersonel);  // yazılacak 
        }



        private void rbResimGorunum_CheckedChanged_1(object sender, EventArgs e)
        {
            lvPersonel.View = View.LargeIcon;
        }

        private void rbDetayliGorunum_CheckedChanged_1(object sender, EventArgs e)
        {
            lvPersonel.View = View.Details;
        }




    }
}
