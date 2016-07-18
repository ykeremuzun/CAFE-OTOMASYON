namespace Cafe
{
    partial class Personel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personel));
            this.btnGeri = new System.Windows.Forms.Button();
            this.txtPersonelTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtPersonelTcNo = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbDetayliGorunum = new System.Windows.Forms.RadioButton();
            this.rbResimGorunum = new System.Windows.Forms.RadioButton();
            this.cbYetki = new System.Windows.Forms.ComboBox();
            this.LargeImage = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPersonel = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPersonelSil = new System.Windows.Forms.Button();
            this.btnPersonelDuzenle = new System.Windows.Forms.Button();
            this.btnPersonelKaydet = new System.Windows.Forms.Button();
            this.btnYeniPersonel = new System.Windows.Forms.Button();
            this.txtPersonelSifre = new System.Windows.Forms.TextBox();
            this.txtPersonelKullaniciAd = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtPersonelSoyad = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtAdaGore = new System.Windows.Forms.TextBox();
            this.txtPersonelYetki = new System.Windows.Forms.TextBox();
            this.txtPersonelID = new System.Windows.Forms.TextBox();
            this.txtPersonelAd = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Transparent;
            this.btnGeri.BackgroundImage = global::Cafe.Properties.Resources._1462242577_MB__back;
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGeri.Location = new System.Drawing.Point(1, 380);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(68, 65);
            this.btnGeri.TabIndex = 44;
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // txtPersonelTelefon
            // 
            this.txtPersonelTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonelTelefon.Location = new System.Drawing.Point(138, 203);
            this.txtPersonelTelefon.Mask = "(999) 000-0000";
            this.txtPersonelTelefon.Name = "txtPersonelTelefon";
            this.txtPersonelTelefon.Size = new System.Drawing.Size(100, 22);
            this.txtPersonelTelefon.TabIndex = 4;
            // 
            // txtPersonelTcNo
            // 
            this.txtPersonelTcNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonelTcNo.Location = new System.Drawing.Point(138, 173);
            this.txtPersonelTcNo.Mask = "00000000000";
            this.txtPersonelTcNo.Name = "txtPersonelTcNo";
            this.txtPersonelTcNo.Size = new System.Drawing.Size(100, 24);
            this.txtPersonelTcNo.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(470, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "Personel Görünüm ";
            // 
            // rbDetayliGorunum
            // 
            this.rbDetayliGorunum.AutoSize = true;
            this.rbDetayliGorunum.Checked = true;
            this.rbDetayliGorunum.Location = new System.Drawing.Point(536, 64);
            this.rbDetayliGorunum.Name = "rbDetayliGorunum";
            this.rbDetayliGorunum.Size = new System.Drawing.Size(47, 17);
            this.rbDetayliGorunum.TabIndex = 69;
            this.rbDetayliGorunum.TabStop = true;
            this.rbDetayliGorunum.Text = "Liste";
            this.rbDetayliGorunum.UseVisualStyleBackColor = true;
            this.rbDetayliGorunum.CheckedChanged += new System.EventHandler(this.rbDetayliGorunum_CheckedChanged_1);
            // 
            // rbResimGorunum
            // 
            this.rbResimGorunum.AutoSize = true;
            this.rbResimGorunum.Location = new System.Drawing.Point(473, 64);
            this.rbResimGorunum.Name = "rbResimGorunum";
            this.rbResimGorunum.Size = new System.Drawing.Size(57, 17);
            this.rbResimGorunum.TabIndex = 68;
            this.rbResimGorunum.Text = "Resim ";
            this.rbResimGorunum.UseVisualStyleBackColor = true;
            this.rbResimGorunum.CheckedChanged += new System.EventHandler(this.rbResimGorunum_CheckedChanged_1);
            // 
            // cbYetki
            // 
            this.cbYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYetki.FormattingEnabled = true;
            this.cbYetki.Items.AddRange(new object[] {
            "Yetkili",
            "Yetkisiz"});
            this.cbYetki.Location = new System.Drawing.Point(138, 146);
            this.cbYetki.Name = "cbYetki";
            this.cbYetki.Size = new System.Drawing.Size(100, 21);
            this.cbYetki.TabIndex = 2;
            // 
            // LargeImage
            // 
            this.LargeImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImage.ImageStream")));
            this.LargeImage.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImage.Images.SetKeyName(0, "user.png");
            this.LargeImage.Images.SetKeyName(1, "Admin.png");
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Yetki";
            // 
            // lvPersonel
            // 
            this.lvPersonel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvPersonel.FullRowSelect = true;
            this.lvPersonel.GridLines = true;
            this.lvPersonel.LargeImageList = this.LargeImage;
            this.lvPersonel.Location = new System.Drawing.Point(279, 89);
            this.lvPersonel.Name = "lvPersonel";
            this.lvPersonel.Size = new System.Drawing.Size(513, 347);
            this.lvPersonel.TabIndex = 12;
            this.lvPersonel.UseCompatibleStateImageBehavior = false;
            this.lvPersonel.View = System.Windows.Forms.View.Details;
            this.lvPersonel.DoubleClick += new System.EventHandler(this.lvPersonel_DoubleClick_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PersonelID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Personel Ad";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Personel Soyad";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TC No";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Telefon";
            this.columnHeader5.Width = 66;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Kullanıcı Adı";
            this.columnHeader6.Width = 83;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Şifre";
            // 
            // btnPersonelSil
            // 
            this.btnPersonelSil.Location = new System.Drawing.Point(221, 322);
            this.btnPersonelSil.Name = "btnPersonelSil";
            this.btnPersonelSil.Size = new System.Drawing.Size(52, 27);
            this.btnPersonelSil.TabIndex = 10;
            this.btnPersonelSil.Text = "Sil";
            this.btnPersonelSil.UseVisualStyleBackColor = true;
            this.btnPersonelSil.Click += new System.EventHandler(this.btnPersonelSil_Click_1);
            // 
            // btnPersonelDuzenle
            // 
            this.btnPersonelDuzenle.Location = new System.Drawing.Point(159, 322);
            this.btnPersonelDuzenle.Name = "btnPersonelDuzenle";
            this.btnPersonelDuzenle.Size = new System.Drawing.Size(56, 27);
            this.btnPersonelDuzenle.TabIndex = 9;
            this.btnPersonelDuzenle.Text = "Düzenle";
            this.btnPersonelDuzenle.UseVisualStyleBackColor = true;
            this.btnPersonelDuzenle.Click += new System.EventHandler(this.btnPersonelDuzenle_Click_1);
            // 
            // btnPersonelKaydet
            // 
            this.btnPersonelKaydet.Location = new System.Drawing.Point(101, 322);
            this.btnPersonelKaydet.Name = "btnPersonelKaydet";
            this.btnPersonelKaydet.Size = new System.Drawing.Size(52, 27);
            this.btnPersonelKaydet.TabIndex = 7;
            this.btnPersonelKaydet.Text = "Kaydet";
            this.btnPersonelKaydet.UseVisualStyleBackColor = true;
            this.btnPersonelKaydet.Click += new System.EventHandler(this.btnPersonelKaydet_Click_1);
            // 
            // btnYeniPersonel
            // 
            this.btnYeniPersonel.Location = new System.Drawing.Point(43, 322);
            this.btnYeniPersonel.Name = "btnYeniPersonel";
            this.btnYeniPersonel.Size = new System.Drawing.Size(52, 27);
            this.btnYeniPersonel.TabIndex = 8;
            this.btnYeniPersonel.Text = "Yeni";
            this.btnYeniPersonel.UseVisualStyleBackColor = true;
            this.btnYeniPersonel.Click += new System.EventHandler(this.btnYeniPersonel_Click_1);
            // 
            // txtPersonelSifre
            // 
            this.txtPersonelSifre.Location = new System.Drawing.Point(138, 268);
            this.txtPersonelSifre.Name = "txtPersonelSifre";
            this.txtPersonelSifre.Size = new System.Drawing.Size(100, 20);
            this.txtPersonelSifre.TabIndex = 6;
            // 
            // txtPersonelKullaniciAd
            // 
            this.txtPersonelKullaniciAd.Location = new System.Drawing.Point(138, 242);
            this.txtPersonelKullaniciAd.Name = "txtPersonelKullaniciAd";
            this.txtPersonelKullaniciAd.ReadOnly = true;
            this.txtPersonelKullaniciAd.Size = new System.Drawing.Size(100, 20);
            this.txtPersonelKullaniciAd.TabIndex = 5;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(52, 271);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(76, 13);
            this.Label6.TabIndex = 64;
            this.Label6.Text = "Kullanıcı Şifre :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(58, 245);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 13);
            this.Label4.TabIndex = 59;
            this.Label4.Text = "Kullanıcı Adı :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(75, 208);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 57;
            this.Label5.Text = "Telefon :";
            // 
            // txtPersonelSoyad
            // 
            this.txtPersonelSoyad.Location = new System.Drawing.Point(138, 121);
            this.txtPersonelSoyad.Name = "txtPersonelSoyad";
            this.txtPersonelSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtPersonelSoyad.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(83, 180);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 13);
            this.Label3.TabIndex = 55;
            this.Label3.Text = "TC No:";
            // 
            // txtAdaGore
            // 
            this.txtAdaGore.Location = new System.Drawing.Point(279, 63);
            this.txtAdaGore.Name = "txtAdaGore";
            this.txtAdaGore.Size = new System.Drawing.Size(100, 20);
            this.txtAdaGore.TabIndex = 11;
            this.txtAdaGore.TextChanged += new System.EventHandler(this.txtAdaGore_TextChanged_1);
            // 
            // txtPersonelYetki
            // 
            this.txtPersonelYetki.BackColor = System.Drawing.Color.CadetBlue;
            this.txtPersonelYetki.Location = new System.Drawing.Point(244, 149);
            this.txtPersonelYetki.Name = "txtPersonelYetki";
            this.txtPersonelYetki.ReadOnly = true;
            this.txtPersonelYetki.Size = new System.Drawing.Size(10, 20);
            this.txtPersonelYetki.TabIndex = 65;
            // 
            // txtPersonelID
            // 
            this.txtPersonelID.BackColor = System.Drawing.Color.CadetBlue;
            this.txtPersonelID.Location = new System.Drawing.Point(44, 95);
            this.txtPersonelID.Name = "txtPersonelID";
            this.txtPersonelID.ReadOnly = true;
            this.txtPersonelID.Size = new System.Drawing.Size(10, 20);
            this.txtPersonelID.TabIndex = 66;
            // 
            // txtPersonelAd
            // 
            this.txtPersonelAd.Location = new System.Drawing.Point(138, 95);
            this.txtPersonelAd.Name = "txtPersonelAd";
            this.txtPersonelAd.Size = new System.Drawing.Size(100, 20);
            this.txtPersonelAd.TabIndex = 0;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(276, 46);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(49, 13);
            this.Label9.TabIndex = 53;
            this.Label9.Text = "AdaGore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Personel Yetki :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(60, 98);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 13);
            this.Label1.TabIndex = 50;
            this.Label1.Text = "Personel Adı :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(43, 126);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 13);
            this.Label2.TabIndex = 63;
            this.Label2.Text = "Personel Soyadı :";
            // 
            // Personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(835, 482);
            this.ControlBox = false;
            this.Controls.Add(this.txtPersonelTelefon);
            this.Controls.Add(this.txtPersonelTcNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbDetayliGorunum);
            this.Controls.Add(this.rbResimGorunum);
            this.Controls.Add(this.cbYetki);
            this.Controls.Add(this.lvPersonel);
            this.Controls.Add(this.btnPersonelSil);
            this.Controls.Add(this.btnPersonelDuzenle);
            this.Controls.Add(this.btnPersonelKaydet);
            this.Controls.Add(this.btnYeniPersonel);
            this.Controls.Add(this.txtPersonelSifre);
            this.Controls.Add(this.txtPersonelKullaniciAd);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtPersonelSoyad);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtAdaGore);
            this.Controls.Add(this.txtPersonelYetki);
            this.Controls.Add(this.txtPersonelID);
            this.Controls.Add(this.txtPersonelAd);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnGeri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Personel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.Personel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.MaskedTextBox txtPersonelTelefon;
        private System.Windows.Forms.MaskedTextBox txtPersonelTcNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbDetayliGorunum;
        private System.Windows.Forms.RadioButton rbResimGorunum;
        private System.Windows.Forms.ComboBox cbYetki;
        private System.Windows.Forms.ImageList LargeImage;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        internal System.Windows.Forms.ListView lvPersonel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal System.Windows.Forms.Button btnPersonelSil;
        internal System.Windows.Forms.Button btnPersonelDuzenle;
        internal System.Windows.Forms.Button btnPersonelKaydet;
        internal System.Windows.Forms.Button btnYeniPersonel;
        internal System.Windows.Forms.TextBox txtPersonelSifre;
        internal System.Windows.Forms.TextBox txtPersonelKullaniciAd;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtPersonelSoyad;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtAdaGore;
        internal System.Windows.Forms.TextBox txtPersonelYetki;
        internal System.Windows.Forms.TextBox txtPersonelID;
        internal System.Windows.Forms.TextBox txtPersonelAd;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
    }
}