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
using System.Windows.Forms.DataVisualization.Charting;

namespace Cafe
{
    public partial class GrafikSatisEkrani : Form
    {
        public GrafikSatisEkrani()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(cGenel.connStr);

        private void pbPizza_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvSiparisler, pbPizza.Tag.ToString());
            grafikciz(pbPizza.Tag.ToString(), Color.Yellow);
            rpvYoket();
        }
        private void pbSalata_Click(object sender, EventArgs e)
        {
            
            UrunleriListele(lvSiparisler, pbSalata.Tag.ToString());
            grafikciz(pbSalata.Tag.ToString(), Color.Green);
            rpvYoket();
        }
        private void pbTatli_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvSiparisler, pbTatli.Tag.ToString());
            grafikciz(pbTatli.Tag.ToString(),Color.Brown);
            rpvYoket();
        }
        private void pbYan_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvSiparisler, pbYan.Tag.ToString());
            grafikciz(pbYan.Tag.ToString(), Color.Purple);
            rpvYoket();
        }
        private void pbIcecek_Click(object sender, EventArgs e)
        {
            UrunleriListele(lvSiparisler, pbIcecek.Tag.ToString());
            grafikciz(pbIcecek.Tag.ToString(),Color.Red);
            rpvYoket();
        }
        private void UrunleriListele(ListView liste, string Tip)
        {
            cSiparisUrunler su = new cSiparisUrunler();
            su.UrunleriGetirByTipeGore(dtpTarih1.Value, dtpTarih2.Value, lvSiparisler, Tip);
        }
        private void btnTumUrunler_Click(object sender, EventArgs e)
        {
           
            rpvGrafik.Visible = true;
            string Tur = "";
            UrunleriListele(lvSiparisler, Tur);
            grafikciz(btnTumUrunler.Text,Color.Cyan);

            this.DataSet1.Clear();        
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT UrunTipleri.TipAd, Urunler.UrunAd, SiparisUrunler.UrunID, SiparisUrunler.Miktar, Fis.Tarih FROM     UrunTipleri INNER JOIN Urunler ON UrunTipleri.UrunTipID = Urunler.UrunTipID INNER JOIN SiparisUrunler ON Urunler.UrunID = SiparisUrunler.UrunID INNER JOIN Fis ON SiparisUrunler.ID = Fis.SiparisUrunID where Convert(Date,Tarih,104) Between Convert(Date,@Tarih1,104) and Convert(Date,@Tarih2,104)", conn);
            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = dtpTarih1.Value;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = dtpTarih2.Value;
            try
            {
                da.Fill(this.DataSet1.DataTable2);
                this.rpvGrafik.Visible = true;             
                this.rpvGrafik.RefreshReport();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            lvSiparisler.Visible = true;
        }
        private void btnGrafikCiz_Click(object sender, EventArgs e)
        {
            btnGrafikCiz.Visible = false;
            chartSatislar.Visible = true;
            chartSatislar.Palette = ChartColorPalette.None;
            chartSatislar.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chartSatislar.Series[0].Color = Color.Red;

            if (lvSiparisler.Items.Count > 0)
            {
                chartSatislar.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvSiparisler.Items.Count; i++)
                {
                    chartSatislar.Series["Satislar"].Points.AddXY(lvSiparisler.Items[i].SubItems[0].Text, lvSiparisler.Items[i].SubItems[1].Text);
                }
            }
           
        }
        private void grafikciz(string ad, Color renk)
        {
            lvSiparisler.Visible = false;
            chartSatislar.Series["Satislar"].Points.Clear();
            btnGrafikCiz.Visible = false;
            chartSatislar.Visible = true;
            chartSatislar.Palette = ChartColorPalette.None;
            chartSatislar.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chartSatislar.Series[0].Color = renk;
            lblUrunTipAd.Text = ad;

            if (lvSiparisler.Items.Count > 0)
            {
                chartSatislar.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvSiparisler.Items.Count; i++)
                {
                    chartSatislar.Series["Satislar"].Points.AddXY(lvSiparisler.Items[i].SubItems[0].Text, lvSiparisler.Items[i].SubItems[1].Text);
                }
            }
        }
        private void GrafikSatisEkrani_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
           this.DataTable2TableAdapter.Fill(this.DataSet1.DataTable2);

            this.rpvGrafik.RefreshReport();
        }
        private void rpvYoket()
        {
            rpvGrafik.Visible = false;
        }


    }
}
