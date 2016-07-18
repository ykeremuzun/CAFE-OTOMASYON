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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {          
            this.Close();
                          
        }

        private void btnMasa_Click(object sender, EventArgs e)
        {
            Masalar frm = new Masalar();
            frm.ShowDialog();
            
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            Personel frm = new Personel();
            frm.ShowDialog();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            Urunler frm = new Urunler();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KasaHareket frm = new KasaHareket();
            frm.ShowDialog();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            cPersonel p = new cPersonel();
            p.PersonelGetir(cbPersonel);
            cbPersonel.SelectedIndex = 0;
        }

        private void aktif()
        {
            btnMasa.Visible = true;
            btnIstatistik.Visible = true;
            btnPersonel.Visible = true;
            btnRapor.Visible = true;
            btnUrun.Visible = true;
            button6.Visible = true;
            btnGiris.Visible = false;
            txtSifre.Visible = false;
            cbPersonel.Visible = false;
            btnGeri.Visible = true;
            txtPersonelID.Text = cGenel.PersonelID.ToString();
        }

        private void Pasif()
        {
            btnMasa.Visible = false;
            btnIstatistik.Visible = false;
            btnPersonel.Visible = false;
            btnRapor.Visible = false;
            btnUrun.Visible = false;
            button6.Visible = false;
            btnGiris.Visible = true;
            txtSifre.Visible = true;
            cbPersonel.Visible = true;
            btnGeri.Visible = false;
            txtPersonelID.Text = cGenel.PersonelID.ToString();
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {
            cPersonel p = new cPersonel();
            bool sonuc;
            if (txtSifre.Text.Trim() != "")
            {
                sonuc = p.SifreKontrol(txtSifre.Text, cbPersonel.SelectedItem.ToString());
                if (sonuc == false)
                {
                    MessageBox.Show("Bigiler Yalnış");
                }
                else
                {
                    txtPersonelID.Text = cGenel.PersonelID.ToString();
                  sonuc=  p.YetkikontrolEt(txtPersonelID.Text);
                    if (sonuc)
                    {
                     aktif();
                    }
                    else
                    {
                        Masalar frm = new Masalar();
                        frm.ShowDialog();
                    }
                    
                }
            }
            txtSifre.Clear();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            Rapor frm = new Rapor();
            frm.ShowDialog();
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            IstatistikAnaSayfa frm = new IstatistikAnaSayfa();
            frm.ShowDialog();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Pasif();
            txtSifre.Clear();
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
