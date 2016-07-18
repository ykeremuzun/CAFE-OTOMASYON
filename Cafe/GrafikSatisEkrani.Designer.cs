namespace Cafe
{
    partial class GrafikSatisEkrani
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Cafe.DataSet1();
            this.dtpTarih1 = new System.Windows.Forms.DateTimePicker();
            this.dtpTarih2 = new System.Windows.Forms.DateTimePicker();
            this.pbTatli = new System.Windows.Forms.PictureBox();
            this.pbYan = new System.Windows.Forms.PictureBox();
            this.pbIcecek = new System.Windows.Forms.PictureBox();
            this.pbSalata = new System.Windows.Forms.PictureBox();
            this.pbPizza = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartSatislar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTumUrunler = new System.Windows.Forms.Button();
            this.lvSiparisler = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGrafikCiz = new System.Windows.Forms.Button();
            this.lblUrunTipAd = new System.Windows.Forms.Label();
            this.rpvGrafik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable2TableAdapter = new Cafe.DataSet1TableAdapters.DataTable2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTatli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcecek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPizza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSatislar)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpTarih1
            // 
            this.dtpTarih1.Location = new System.Drawing.Point(90, 96);
            this.dtpTarih1.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTarih1.Name = "dtpTarih1";
            this.dtpTarih1.Size = new System.Drawing.Size(105, 20);
            this.dtpTarih1.TabIndex = 0;
            // 
            // dtpTarih2
            // 
            this.dtpTarih2.Location = new System.Drawing.Point(90, 127);
            this.dtpTarih2.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTarih2.Name = "dtpTarih2";
            this.dtpTarih2.Size = new System.Drawing.Size(105, 20);
            this.dtpTarih2.TabIndex = 1;
            // 
            // pbTatli
            // 
            this.pbTatli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTatli.Image = global::Cafe.Properties.Resources._1462503512_cake_20;
            this.pbTatli.Location = new System.Drawing.Point(705, 417);
            this.pbTatli.Name = "pbTatli";
            this.pbTatli.Size = new System.Drawing.Size(124, 92);
            this.pbTatli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTatli.TabIndex = 43;
            this.pbTatli.TabStop = false;
            this.pbTatli.Tag = "Tatli";
            this.pbTatli.Click += new System.EventHandler(this.pbTatli_Click);
            // 
            // pbYan
            // 
            this.pbYan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbYan.Image = global::Cafe.Properties.Resources._256_256_612579d32495f482af02007f595665ad_fries;
            this.pbYan.Location = new System.Drawing.Point(445, 417);
            this.pbYan.Name = "pbYan";
            this.pbYan.Size = new System.Drawing.Size(124, 92);
            this.pbYan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbYan.TabIndex = 46;
            this.pbYan.TabStop = false;
            this.pbYan.Tag = "Yan Ürün";
            this.pbYan.Click += new System.EventHandler(this.pbYan_Click);
            // 
            // pbIcecek
            // 
            this.pbIcecek.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbIcecek.Image = global::Cafe.Properties.Resources.tea_icon;
            this.pbIcecek.Location = new System.Drawing.Point(304, 417);
            this.pbIcecek.Name = "pbIcecek";
            this.pbIcecek.Size = new System.Drawing.Size(124, 92);
            this.pbIcecek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcecek.TabIndex = 44;
            this.pbIcecek.TabStop = false;
            this.pbIcecek.Tag = "İçecek";
            this.pbIcecek.Click += new System.EventHandler(this.pbIcecek_Click);
            // 
            // pbSalata
            // 
            this.pbSalata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pbSalata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSalata.Image = global::Cafe.Properties.Resources.icon_salad;
            this.pbSalata.Location = new System.Drawing.Point(174, 417);
            this.pbSalata.Name = "pbSalata";
            this.pbSalata.Size = new System.Drawing.Size(124, 92);
            this.pbSalata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSalata.TabIndex = 45;
            this.pbSalata.TabStop = false;
            this.pbSalata.Tag = "Salata";
            this.pbSalata.Click += new System.EventHandler(this.pbSalata_Click);
            // 
            // pbPizza
            // 
            this.pbPizza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPizza.Image = global::Cafe.Properties.Resources.Pizza_icon;
            this.pbPizza.Location = new System.Drawing.Point(575, 417);
            this.pbPizza.Name = "pbPizza";
            this.pbPizza.Size = new System.Drawing.Size(124, 92);
            this.pbPizza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPizza.TabIndex = 42;
            this.pbPizza.TabStop = false;
            this.pbPizza.Tag = "Pizza";
            this.pbPizza.Click += new System.EventHandler(this.pbPizza_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Başlangıç Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Bitiş Tarihi";
            // 
            // chartSatislar
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSatislar.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSatislar.Legends.Add(legend2);
            this.chartSatislar.Location = new System.Drawing.Point(315, 52);
            this.chartSatislar.Margin = new System.Windows.Forms.Padding(2);
            this.chartSatislar.Name = "chartSatislar";
            this.chartSatislar.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Satislar";
            this.chartSatislar.Series.Add(series2);
            this.chartSatislar.Size = new System.Drawing.Size(320, 360);
            this.chartSatislar.TabIndex = 49;
            this.chartSatislar.Text = "chart1";
            // 
            // btnTumUrunler
            // 
            this.btnTumUrunler.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTumUrunler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumUrunler.ForeColor = System.Drawing.Color.Black;
            this.btnTumUrunler.Location = new System.Drawing.Point(34, 417);
            this.btnTumUrunler.Margin = new System.Windows.Forms.Padding(2);
            this.btnTumUrunler.Name = "btnTumUrunler";
            this.btnTumUrunler.Size = new System.Drawing.Size(123, 102);
            this.btnTumUrunler.TabIndex = 50;
            this.btnTumUrunler.Tag = " ";
            this.btnTumUrunler.Text = "Tüm Ürünler";
            this.btnTumUrunler.UseVisualStyleBackColor = false;
            this.btnTumUrunler.Click += new System.EventHandler(this.btnTumUrunler_Click);
            // 
            // lvSiparisler
            // 
            this.lvSiparisler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSiparisler.Location = new System.Drawing.Point(15, 157);
            this.lvSiparisler.Margin = new System.Windows.Forms.Padding(2);
            this.lvSiparisler.Name = "lvSiparisler";
            this.lvSiparisler.Size = new System.Drawing.Size(180, 246);
            this.lvSiparisler.TabIndex = 51;
            this.lvSiparisler.UseCompatibleStateImageBehavior = false;
            this.lvSiparisler.View = System.Windows.Forms.View.Details;
            this.lvSiparisler.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ürün Ad";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar";
            // 
            // btnGrafikCiz
            // 
            this.btnGrafikCiz.Location = new System.Drawing.Point(753, 23);
            this.btnGrafikCiz.Margin = new System.Windows.Forms.Padding(2);
            this.btnGrafikCiz.Name = "btnGrafikCiz";
            this.btnGrafikCiz.Size = new System.Drawing.Size(123, 102);
            this.btnGrafikCiz.TabIndex = 52;
            this.btnGrafikCiz.Tag = " ";
            this.btnGrafikCiz.Text = "Grafik Çiz";
            this.btnGrafikCiz.UseVisualStyleBackColor = true;
            this.btnGrafikCiz.Visible = false;
            this.btnGrafikCiz.Click += new System.EventHandler(this.btnGrafikCiz_Click);
            // 
            // lblUrunTipAd
            // 
            this.lblUrunTipAd.AutoSize = true;
            this.lblUrunTipAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUrunTipAd.Location = new System.Drawing.Point(520, 85);
            this.lblUrunTipAd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUrunTipAd.Name = "lblUrunTipAd";
            this.lblUrunTipAd.Size = new System.Drawing.Size(0, 31);
            this.lblUrunTipAd.TabIndex = 53;
            // 
            // rpvGrafik
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DataTable2BindingSource;
            this.rpvGrafik.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGrafik.LocalReport.ReportEmbeddedResource = "Cafe.Report2.rdlc";
            this.rpvGrafik.Location = new System.Drawing.Point(251, 11);
            this.rpvGrafik.Margin = new System.Windows.Forms.Padding(2);
            this.rpvGrafik.Name = "rpvGrafik";
            this.rpvGrafik.Size = new System.Drawing.Size(468, 392);
            this.rpvGrafik.TabIndex = 54;
            this.rpvGrafik.Visible = false;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // GrafikSatisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(833, 523);
            this.Controls.Add(this.rpvGrafik);
            this.Controls.Add(this.lblUrunTipAd);
            this.Controls.Add(this.btnGrafikCiz);
            this.Controls.Add(this.lvSiparisler);
            this.Controls.Add(this.btnTumUrunler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTatli);
            this.Controls.Add(this.pbYan);
            this.Controls.Add(this.pbIcecek);
            this.Controls.Add(this.pbSalata);
            this.Controls.Add(this.pbPizza);
            this.Controls.Add(this.dtpTarih2);
            this.Controls.Add(this.dtpTarih1);
            this.Controls.Add(this.chartSatislar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GrafikSatisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrafikSatisEkrani";
            this.Load += new System.EventHandler(this.GrafikSatisEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTatli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcecek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPizza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSatislar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTarih1;
        private System.Windows.Forms.DateTimePicker dtpTarih2;
        private System.Windows.Forms.PictureBox pbTatli;
        private System.Windows.Forms.PictureBox pbYan;
        private System.Windows.Forms.PictureBox pbIcecek;
        private System.Windows.Forms.PictureBox pbSalata;
        private System.Windows.Forms.PictureBox pbPizza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSatislar;
        private System.Windows.Forms.Button btnTumUrunler;
        private System.Windows.Forms.ListView lvSiparisler;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnGrafikCiz;
        private System.Windows.Forms.Label lblUrunTipAd;
        private Microsoft.Reporting.WinForms.ReportViewer rpvGrafik;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
    }
}