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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(cGenel.connStr);
        private void Giris_Load(object sender, EventArgs e)
        { 
            PersonelGetir(cbPersonel);
            cbPersonel.SelectedIndex=0;
        }
        private void PersonelGetir(ComboBox liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select * from Personel where Silindi=0", conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string ad = dr["Ad"].ToString() ;
                    liste.Items.Add(ad);

                }
                dr.Close();
            }
            conn.Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            bool sonuc;
            if (txtSifre.Text.Trim()!="")
            {
                sonuc= SifreKontrol(txtSifre.Text, cbPersonel.SelectedItem.ToString());
                if (sonuc==false)
                {
                    MessageBox.Show("Bigiler Yalnış");
                }
                else
                {
                    AnaSayfa frm = new AnaSayfa();
                    frm.ShowDialog();
                    txtSifre.Text = "";
                    
                }
            }
        }
        private bool SifreKontrol(string sifre, string Kullanıcı)
        {
            bool sonuc;
            SqlCommand comm = new SqlCommand("Select * from Personel where Silindi=0 and Ad=@Ad and Sifre=@Sifre ", conn);
            comm.Parameters.Add("@Sifre", SqlDbType.VarChar).Value = sifre;
            comm.Parameters.Add("@Ad", SqlDbType.VarChar).Value = Kullanıcı;
            if (conn.State == ConnectionState.Closed) conn.Open();
           SqlDataReader dr= comm.ExecuteReader();
            if(dr.HasRows)
            {
                 sonuc = true;
            }
            else
            {
                sonuc = false;
            }
            dr.Close();
            
            conn.Close();
            return sonuc;


        }
       
    }
    
}
