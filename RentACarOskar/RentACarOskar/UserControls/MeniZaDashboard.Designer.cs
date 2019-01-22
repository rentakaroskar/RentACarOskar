namespace RentACarOskar.UserControls
{
    partial class MeniZaDashboard
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

        #region Component Designer generated code

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
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.lblBrojzauzetihVozila = new System.Windows.Forms.Label();
            this.labelSlobodnaVozila = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBrVozila = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.bunifuCards1.Controls.Add(this.chart1);
            this.bunifuCards1.Controls.Add(this.lblBrojzauzetihVozila);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.labelSlobodnaVozila);
            this.bunifuCards1.Controls.Add(this.labelBrVozila);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(472, 23);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(354, 221);
            this.bunifuCards1.TabIndex = 3;
            this.bunifuCards1.Paint += new System.Windows.Forms.PaintEventHandler(this.bunifuCards1_Paint);
            // 
            // lblBrojzauzetihVozila
            // 
            this.lblBrojzauzetihVozila.AutoSize = true;
            this.lblBrojzauzetihVozila.BackColor = System.Drawing.Color.Transparent;
            this.lblBrojzauzetihVozila.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.lblBrojzauzetihVozila.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.lblBrojzauzetihVozila.Location = new System.Drawing.Point(314, 87);
            this.lblBrojzauzetihVozila.Name = "lblBrojzauzetihVozila";
            this.lblBrojzauzetihVozila.Size = new System.Drawing.Size(41, 16);
            this.lblBrojzauzetihVozila.TabIndex = 19;
            this.lblBrojzauzetihVozila.Text = "label1";
            // 
            // labelSlobodnaVozila
            // 
            this.labelSlobodnaVozila.AutoSize = true;
            this.labelSlobodnaVozila.BackColor = System.Drawing.Color.Transparent;
            this.labelSlobodnaVozila.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.labelSlobodnaVozila.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.labelSlobodnaVozila.Location = new System.Drawing.Point(314, 72);
            this.labelSlobodnaVozila.Name = "labelSlobodnaVozila";
            this.labelSlobodnaVozila.Size = new System.Drawing.Size(41, 16);
            this.labelSlobodnaVozila.TabIndex = 18;
            this.labelSlobodnaVozila.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ukupan broj vozila: ";
            // 
            // labelBrVozila
            // 
            this.labelBrVozila.AutoSize = true;
            this.labelBrVozila.BackColor = System.Drawing.Color.Transparent;
            this.labelBrVozila.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.labelBrVozila.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.labelBrVozila.Location = new System.Drawing.Point(275, 27);
            this.labelBrVozila.Name = "labelBrVozila";
            this.labelBrVozila.Size = new System.Drawing.Size(86, 30);
            this.labelBrVozila.TabIndex = 13;
            this.labelBrVozila.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(18, 65);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "s1";
            series2.YValuesPerPoint = 2;
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(183, 154);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.label4.Location = new System.Drawing.Point(197, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Broj  zauzetih vozila";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.label2.Location = new System.Drawing.Point(197, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Broj slobodnih vozila";
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.bunifuCards2.Controls.Add(this.lblTime);
            this.bunifuCards2.Controls.Add(this.label6);
            this.bunifuCards2.Controls.Add(this.labelUserName);
            this.bunifuCards2.Controls.Add(this.label3);
            this.bunifuCards2.Controls.Add(this.pictureBox1);
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(72, 25);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(354, 219);
            this.bunifuCards2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.label3.Location = new System.Drawing.Point(140, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 30);
            this.label3.TabIndex = 20;
            this.label3.Text = "Korisnik:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.labelUserName.Location = new System.Drawing.Point(150, 82);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(166, 21);
            this.labelUserName.TabIndex = 21;
            this.labelUserName.Text = "email@email.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.label6.Location = new System.Drawing.Point(14, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 22);
            this.label6.TabIndex = 22;
            this.label6.Text = "Vrijeme logovavanja:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.lblTime.Location = new System.Drawing.Point(32, 177);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(28, 21);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "lbl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentACarOskar.Properties.Resources.avatar_circle_human_male_2_512;
            this.pictureBox1.Location = new System.Drawing.Point(18, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MeniZaDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.bunifuCards1);
            this.Name = "MeniZaDashboard";
            this.Size = new System.Drawing.Size(855, 465);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.bunifuCards2.ResumeLayout(false);
            this.bunifuCards2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelBrVozila;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrojzauzetihVozila;
        private System.Windows.Forms.Label labelSlobodnaVozila;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label3;
    }
}
