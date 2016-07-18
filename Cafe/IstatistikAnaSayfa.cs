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
    public partial class IstatistikAnaSayfa : Form
    {
        public IstatistikAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnSatisTablosuGetir_Click(object sender, EventArgs e)
        {
            SatisTablosu frm = new SatisTablosu();
            frm.ShowDialog();
        }

        private void btnElemanSatisTablosu_Click(object sender, EventArgs e)
        {
            PersonelSatisTablosu frm = new PersonelSatisTablosu();
            frm.ShowDialog();
        }

        private void btnSatisGrafikGetir_Click(object sender, EventArgs e)
        {
            GrafikSatisEkrani frm = new GrafikSatisEkrani();
            frm.ShowDialog();
        }
    }
}
