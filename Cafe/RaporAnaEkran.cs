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
    public partial class RaporAnaEkran : Form
    {
        public RaporAnaEkran()
        {
            InitializeComponent();
        }

        private void btnGunlukRapor_Click(object sender, EventArgs e)
        {
            Rapor frm = new Rapor();
            frm.ShowDialog();
        }
    }
}
