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
    public partial class MasaAktar : Form
    {
        public MasaAktar()
        {
            InitializeComponent();
        }
         SqlConnection conn = new SqlConnection(cGenel.connStr);
        private void MasaAktar_Load(object sender, EventArgs e)
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

        private void btnS4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            cGenel.MasaNo=btn.Text;
            cMasa m = new cMasa();
            m.MasaGetir(cGenel.MasaNo);
            this.Close();
            
        }
        }
    }

