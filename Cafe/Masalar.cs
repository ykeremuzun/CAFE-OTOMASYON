using Cafe.Classlar;
using System;
using System.Collections;
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
    public partial class Masalar : Form
    {
        public Masalar()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(cGenel.connStr);

        private void Masalar_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select MasaAd from Masalar where Durum=1", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader(); ;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button)
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                if (item.Name == "btn" + dr[i].ToString())
                                {
                                    item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.DoluMasa);
                                }
                            }

                        }
                    }
                }
                dr.Close();
            }
            conn.Close();
        }
              
        private void btnT1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtMasaNo.Text = btn.Text;
            cGenel.buttonname = btn.Name;
            cGenel.MasaNo = txtMasaNo.Text;
            SiparisEkrani frm = new SiparisEkrani();
            frm.ShowDialog();
            SqlCommand comm = new SqlCommand("select MasaAd from Masalar where Durum=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr = comm.ExecuteReader(); ;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button)
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                if (item.Name == "btn" + dr[i].ToString())
                                {
                                    item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.BosMAsa);
                                }
                            }

                        }
                    }
                }
                dr.Close();
            }
            conn.Close();
            SqlCommand commm = new SqlCommand("select MasaAd from Masalar where Durum=1", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader drr = commm.ExecuteReader(); ;
            if (drr.HasRows)
            {
                while (drr.Read())
                {
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button)
                        {
                            for (int i = 0; i < drr.FieldCount; i++)
                            {
                                if (item.Name == "btn" + drr[i].ToString())
                                {
                                    item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.DoluMasa);
                                }
                            }

                        }
                    }
                }
                drr.Close();
            }
            conn.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
