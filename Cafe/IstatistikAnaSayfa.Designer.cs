namespace Cafe
{
    partial class IstatistikAnaSayfa
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
            this.btnSatisTablosuGetir = new System.Windows.Forms.Button();
            this.btnElemanSatisTablosu = new System.Windows.Forms.Button();
            this.btnSatisGrafikGetir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSatisTablosuGetir
            // 
            this.btnSatisTablosuGetir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSatisTablosuGetir.Location = new System.Drawing.Point(197, 11);
            this.btnSatisTablosuGetir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSatisTablosuGetir.Name = "btnSatisTablosuGetir";
            this.btnSatisTablosuGetir.Size = new System.Drawing.Size(158, 410);
            this.btnSatisTablosuGetir.TabIndex = 0;
            this.btnSatisTablosuGetir.Text = "Satış Tablosu";
            this.btnSatisTablosuGetir.UseVisualStyleBackColor = false;
            this.btnSatisTablosuGetir.Click += new System.EventHandler(this.btnSatisTablosuGetir_Click);
            // 
            // btnElemanSatisTablosu
            // 
            this.btnElemanSatisTablosu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnElemanSatisTablosu.Location = new System.Drawing.Point(380, 11);
            this.btnElemanSatisTablosu.Margin = new System.Windows.Forms.Padding(2);
            this.btnElemanSatisTablosu.Name = "btnElemanSatisTablosu";
            this.btnElemanSatisTablosu.Size = new System.Drawing.Size(158, 410);
            this.btnElemanSatisTablosu.TabIndex = 1;
            this.btnElemanSatisTablosu.Text = "Personel Satış İzleme";
            this.btnElemanSatisTablosu.UseVisualStyleBackColor = false;
            this.btnElemanSatisTablosu.Click += new System.EventHandler(this.btnElemanSatisTablosu_Click);
            // 
            // btnSatisGrafikGetir
            // 
            this.btnSatisGrafikGetir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSatisGrafikGetir.Location = new System.Drawing.Point(11, 11);
            this.btnSatisGrafikGetir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSatisGrafikGetir.Name = "btnSatisGrafikGetir";
            this.btnSatisGrafikGetir.Size = new System.Drawing.Size(158, 410);
            this.btnSatisGrafikGetir.TabIndex = 2;
            this.btnSatisGrafikGetir.Text = "Grafikler";
            this.btnSatisGrafikGetir.UseVisualStyleBackColor = false;
            this.btnSatisGrafikGetir.Click += new System.EventHandler(this.btnSatisGrafikGetir_Click);
            // 
            // IstatistikAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(548, 432);
            this.Controls.Add(this.btnSatisGrafikGetir);
            this.Controls.Add(this.btnElemanSatisTablosu);
            this.Controls.Add(this.btnSatisTablosuGetir);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "IstatistikAnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstatistik";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSatisTablosuGetir;
        private System.Windows.Forms.Button btnElemanSatisTablosu;
        private System.Windows.Forms.Button btnSatisGrafikGetir;
    }
}