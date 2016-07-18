namespace Cafe
{
    partial class PersonelSatisTablosu
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
            this.cbAylariGetir = new System.Windows.Forms.ComboBox();
            this.cbGunleGetir = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYillikSatis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToplamSatis = new System.Windows.Forms.TextBox();
            this.txtAylikSatis = new System.Windows.Forms.TextBox();
            this.txtGünlükSatis = new System.Windows.Forms.TextBox();
            this.dgvPersonelSatisGetir = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonelSatisGetir)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAylariGetir
            // 
            this.cbAylariGetir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAylariGetir.FormattingEnabled = true;
            this.cbAylariGetir.Location = new System.Drawing.Point(182, 338);
            this.cbAylariGetir.Name = "cbAylariGetir";
            this.cbAylariGetir.Size = new System.Drawing.Size(121, 21);
            this.cbAylariGetir.TabIndex = 23;
            this.cbAylariGetir.SelectedIndexChanged += new System.EventHandler(this.cbAylariGetir_SelectedIndexChanged);
            // 
            // cbGunleGetir
            // 
            this.cbGunleGetir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGunleGetir.FormattingEnabled = true;
            this.cbGunleGetir.Location = new System.Drawing.Point(182, 281);
            this.cbGunleGetir.Name = "cbGunleGetir";
            this.cbGunleGetir.Size = new System.Drawing.Size(121, 21);
            this.cbGunleGetir.TabIndex = 22;
            this.cbGunleGetir.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Yıllık";
            // 
            // txtYillikSatis
            // 
            this.txtYillikSatis.Location = new System.Drawing.Point(55, 404);
            this.txtYillikSatis.Name = "txtYillikSatis";
            this.txtYillikSatis.Size = new System.Drawing.Size(100, 20);
            this.txtYillikSatis.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Toplam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Aylık";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Günlük";
            // 
            // txtToplamSatis
            // 
            this.txtToplamSatis.Location = new System.Drawing.Point(182, 404);
            this.txtToplamSatis.Name = "txtToplamSatis";
            this.txtToplamSatis.Size = new System.Drawing.Size(100, 20);
            this.txtToplamSatis.TabIndex = 16;
            // 
            // txtAylikSatis
            // 
            this.txtAylikSatis.Location = new System.Drawing.Point(55, 338);
            this.txtAylikSatis.Name = "txtAylikSatis";
            this.txtAylikSatis.Size = new System.Drawing.Size(100, 20);
            this.txtAylikSatis.TabIndex = 15;
            // 
            // txtGünlükSatis
            // 
            this.txtGünlükSatis.Location = new System.Drawing.Point(55, 281);
            this.txtGünlükSatis.Name = "txtGünlükSatis";
            this.txtGünlükSatis.Size = new System.Drawing.Size(100, 20);
            this.txtGünlükSatis.TabIndex = 14;
            // 
            // dgvPersonelSatisGetir
            // 
            this.dgvPersonelSatisGetir.AllowUserToAddRows = false;
            this.dgvPersonelSatisGetir.AllowUserToDeleteRows = false;
            this.dgvPersonelSatisGetir.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPersonelSatisGetir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersonelSatisGetir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonelSatisGetir.Location = new System.Drawing.Point(12, 12);
            this.dgvPersonelSatisGetir.Name = "dgvPersonelSatisGetir";
            this.dgvPersonelSatisGetir.ReadOnly = true;
            this.dgvPersonelSatisGetir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonelSatisGetir.Size = new System.Drawing.Size(344, 236);
            this.dgvPersonelSatisGetir.TabIndex = 13;
            this.dgvPersonelSatisGetir.DoubleClick += new System.EventHandler(this.dgvPersonelSatisGetir_DoubleClick);
            // 
            // PersonelSatisTablosu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(368, 442);
            this.Controls.Add(this.cbAylariGetir);
            this.Controls.Add(this.cbGunleGetir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYillikSatis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToplamSatis);
            this.Controls.Add(this.txtAylikSatis);
            this.Controls.Add(this.txtGünlükSatis);
            this.Controls.Add(this.dgvPersonelSatisGetir);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "PersonelSatisTablosu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Satış Tablosu";
            this.Load += new System.EventHandler(this.PersonelSatisTablosu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonelSatisGetir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAylariGetir;
        private System.Windows.Forms.ComboBox cbGunleGetir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYillikSatis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToplamSatis;
        private System.Windows.Forms.TextBox txtAylikSatis;
        private System.Windows.Forms.TextBox txtGünlükSatis;
        private System.Windows.Forms.DataGridView dgvPersonelSatisGetir;
    }
}