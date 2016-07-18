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
    public partial class PersonelSatisTablosu : Form
    {
        public PersonelSatisTablosu()
        {
            InitializeComponent();
        }

        enum Gunler : byte { Pazartesi, Salı, Çarşamba, Perşembe, Cuma, Cumartesi, Pazar }
        enum Aylar : byte { Ocak, Şubat, Mart, Nisan, Mayıs, Haziran, Temmuz, Ağustos, Eylül, Ekim, Kasım, Aralık }

        DataSet ds = new DataSet();
        BindingSource bs;
        cSiparisUrunler su = new cSiparisUrunler();

        private void PersonelSatisTablosu_Load(object sender, EventArgs e)
        {
            cPersonel p = new cPersonel();
            ds = p.PersonelGetir();

            bs = new BindingSource();
            bs.DataSource = ds.Tables[0];
            dgvPersonelSatisGetir.DataSource = bs;

            dgvPersonelSatisGetir.CellBorderStyle = DataGridViewCellBorderStyle.None;

            #region Enumlar
            string[] GunIsımler = Enum.GetNames(typeof(Gunler));
            foreach (var gun in GunIsımler)
            {
                cbGunleGetir.Items.Add(gun);
            }


            string[] AyIsımler = Enum.GetNames(typeof(Aylar));
            foreach (var ay in AyIsımler)
            {
                cbAylariGetir.Items.Add(ay);
            }
            cbAylariGetir.SelectedIndex = 0;
            #endregion

            cbGunleGetir.Visible = false;
            cbAylariGetir.Visible = false;
        }

        private void dgvPersonelSatisGetir_DoubleClick(object sender, EventArgs e)
        {
            cGenel.personeID = 0;
            cGenel.personeID = (Convert.ToInt32(dgvPersonelSatisGetir.SelectedRows[0].Cells[0].Value));
            txtToplamSatis.Text = su.PersonelSatisGetirGenel(cGenel.personeID).ToString();
            txtGünlükSatis.Text = su.PersonelSatisGetirGünlük(cGenel.personeID).ToString();
            txtAylikSatis.Text = su.PersonelSatisGetirAylik(cGenel.personeID, cbGunleGetir.SelectedIndex).ToString();
            txtYillikSatis.Text = su.PersonelSatisGetirYillik(cGenel.personeID).ToString();
            cbAylariGetir.Visible = true;
        }

        private void cbAylariGetir_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAylikSatis.Text = su.PersonelSatisGetirAylik(cGenel.personeID, cbAylariGetir.SelectedIndex + 1).ToString();
        }
    }
}
