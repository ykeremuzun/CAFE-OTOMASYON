namespace Cafe
{
    partial class KasaHareket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasaHareket));
            this.txtMasayaGore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbAlimlar = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cbOdemeyeGoreAlim = new System.Windows.Forms.ComboBox();
            this.rbSatislar = new System.Windows.Forms.RadioButton();
            this.CbOdemeyeGore = new System.Windows.Forms.ComboBox();
            this.txtFirmayaGore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvKasaHareket = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSonTarih = new System.Windows.Forms.DateTimePicker();
            this.dtpIlkTarih = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToplamGelir = new System.Windows.Forms.TextBox();
            this.txtToplamGider = new System.Windows.Forms.TextBox();
            this.txtToplamBakiye = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasaHareket)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasayaGore
            // 
            this.txtMasayaGore.Location = new System.Drawing.Point(635, 88);
            this.txtMasayaGore.Name = "txtMasayaGore";
            this.txtMasayaGore.Size = new System.Drawing.Size(124, 20);
            this.txtMasayaGore.TabIndex = 72;
            this.txtMasayaGore.TextChanged += new System.EventHandler(this.txtMasayaGore_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(542, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Ödemeye Göre";
            // 
            // rbAlimlar
            // 
            this.rbAlimlar.AutoSize = true;
            this.rbAlimlar.Location = new System.Drawing.Point(302, 34);
            this.rbAlimlar.Name = "rbAlimlar";
            this.rbAlimlar.Size = new System.Drawing.Size(55, 17);
            this.rbAlimlar.TabIndex = 64;
            this.rbAlimlar.Text = "Alımlar";
            this.rbAlimlar.UseVisualStyleBackColor = true;
            this.rbAlimlar.CheckedChanged += new System.EventHandler(this.rbAlimlar_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(637, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Masaya Göre";
            // 
            // cbOdemeyeGoreAlim
            // 
            this.cbOdemeyeGoreAlim.FormattingEnabled = true;
            this.cbOdemeyeGoreAlim.Items.AddRange(new object[] {
            "Nakit",
            "Kredi Karti",
            "SetCard",
            "Sodexo",
            "MultiNet",
            "İade"});
            this.cbOdemeyeGoreAlim.Location = new System.Drawing.Point(302, 85);
            this.cbOdemeyeGoreAlim.Name = "cbOdemeyeGoreAlim";
            this.cbOdemeyeGoreAlim.Size = new System.Drawing.Size(84, 21);
            this.cbOdemeyeGoreAlim.TabIndex = 66;
            this.cbOdemeyeGoreAlim.SelectedIndexChanged += new System.EventHandler(this.cbOdemeyeGoreAlim_SelectedIndexChanged);
            // 
            // rbSatislar
            // 
            this.rbSatislar.AutoSize = true;
            this.rbSatislar.Location = new System.Drawing.Point(545, 34);
            this.rbSatislar.Name = "rbSatislar";
            this.rbSatislar.Size = new System.Drawing.Size(59, 17);
            this.rbSatislar.TabIndex = 63;
            this.rbSatislar.Text = "Satışlar";
            this.rbSatislar.UseVisualStyleBackColor = true;
            this.rbSatislar.CheckedChanged += new System.EventHandler(this.rbSatislar_CheckedChanged);
            // 
            // CbOdemeyeGore
            // 
            this.CbOdemeyeGore.FormattingEnabled = true;
            this.CbOdemeyeGore.Items.AddRange(new object[] {
            "Nakit",
            "KrediKart",
            "SetCard",
            "Sodexo",
            "MultiNet",
            "İade"});
            this.CbOdemeyeGore.Location = new System.Drawing.Point(545, 86);
            this.CbOdemeyeGore.Name = "CbOdemeyeGore";
            this.CbOdemeyeGore.Size = new System.Drawing.Size(84, 21);
            this.CbOdemeyeGore.TabIndex = 65;
            this.CbOdemeyeGore.SelectedIndexChanged += new System.EventHandler(this.CbOdemeyeGore_SelectedIndexChanged);
            // 
            // txtFirmayaGore
            // 
            this.txtFirmayaGore.Location = new System.Drawing.Point(392, 86);
            this.txtFirmayaGore.Name = "txtFirmayaGore";
            this.txtFirmayaGore.Size = new System.Drawing.Size(124, 20);
            this.txtFirmayaGore.TabIndex = 71;
            this.txtFirmayaGore.TextChanged += new System.EventHandler(this.txtFirmayaGore_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Ödemeye Göre";
            // 
            // dgvKasaHareket
            // 
            this.dgvKasaHareket.BackgroundColor = System.Drawing.Color.Olive;
            this.dgvKasaHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKasaHareket.Location = new System.Drawing.Point(46, 141);
            this.dgvKasaHareket.Name = "dgvKasaHareket";
            this.dgvKasaHareket.Size = new System.Drawing.Size(742, 307);
            this.dgvKasaHareket.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Firmaya Göre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(679, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Kar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Gider";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Gelir";
            // 
            // dtpSonTarih
            // 
            this.dtpSonTarih.Location = new System.Drawing.Point(60, 88);
            this.dtpSonTarih.Name = "dtpSonTarih";
            this.dtpSonTarih.Size = new System.Drawing.Size(198, 20);
            this.dtpSonTarih.TabIndex = 62;
            // 
            // dtpIlkTarih
            // 
            this.dtpIlkTarih.Location = new System.Drawing.Point(60, 25);
            this.dtpIlkTarih.Name = "dtpIlkTarih";
            this.dtpIlkTarih.Size = new System.Drawing.Size(198, 20);
            this.dtpIlkTarih.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Tarihleri Arası";
            // 
            // txtToplamGelir
            // 
            this.txtToplamGelir.Location = new System.Drawing.Point(424, 469);
            this.txtToplamGelir.Name = "txtToplamGelir";
            this.txtToplamGelir.ReadOnly = true;
            this.txtToplamGelir.Size = new System.Drawing.Size(116, 20);
            this.txtToplamGelir.TabIndex = 55;
            // 
            // txtToplamGider
            // 
            this.txtToplamGider.Location = new System.Drawing.Point(548, 469);
            this.txtToplamGider.Name = "txtToplamGider";
            this.txtToplamGider.ReadOnly = true;
            this.txtToplamGider.Size = new System.Drawing.Size(116, 20);
            this.txtToplamGider.TabIndex = 54;
            // 
            // txtToplamBakiye
            // 
            this.txtToplamBakiye.Location = new System.Drawing.Point(672, 469);
            this.txtToplamBakiye.Name = "txtToplamBakiye";
            this.txtToplamBakiye.ReadOnly = true;
            this.txtToplamBakiye.Size = new System.Drawing.Size(116, 20);
            this.txtToplamBakiye.TabIndex = 53;
            // 
            // KasaHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(835, 514);
            this.Controls.Add(this.txtMasayaGore);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rbAlimlar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbOdemeyeGoreAlim);
            this.Controls.Add(this.rbSatislar);
            this.Controls.Add(this.CbOdemeyeGore);
            this.Controls.Add(this.txtFirmayaGore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvKasaHareket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpSonTarih);
            this.Controls.Add(this.dtpIlkTarih);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToplamGelir);
            this.Controls.Add(this.txtToplamGider);
            this.Controls.Add(this.txtToplamBakiye);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KasaHareket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Hareketler";
            this.Load += new System.EventHandler(this.KasaHareket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasaHareket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMasayaGore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbAlimlar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbOdemeyeGoreAlim;
        private System.Windows.Forms.RadioButton rbSatislar;
        private System.Windows.Forms.ComboBox CbOdemeyeGore;
        private System.Windows.Forms.TextBox txtFirmayaGore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvKasaHareket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSonTarih;
        private System.Windows.Forms.DateTimePicker dtpIlkTarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToplamGelir;
        private System.Windows.Forms.TextBox txtToplamGider;
        private System.Windows.Forms.TextBox txtToplamBakiye;
    }
}