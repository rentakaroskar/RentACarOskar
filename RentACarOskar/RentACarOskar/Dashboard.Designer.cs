﻿namespace RentACarOskar
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelCentar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panelPanelZaGV = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.PanelTop = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelLeft = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnFaktura = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnVozilo = new Bunifu.Framework.UI.BunifuTileButton();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRadnik = new Bunifu.Framework.UI.BunifuTileButton();
            this.slicica1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.slicica2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.slicica3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelCentar.SuspendLayout();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slicica1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicica2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicica3)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.PanelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelLeft.BackgroundImage")));
            this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelLeft.Controls.Add(this.btnFaktura);
            this.PanelLeft.Controls.Add(this.btnRadnik);
            this.PanelLeft.Controls.Add(this.btnVozilo);
            this.PanelLeft.Controls.Add(this.logoPic);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.GradientBottomLeft = System.Drawing.Color.White;
            this.PanelLeft.GradientBottomRight = System.Drawing.Color.White;
            this.PanelLeft.GradientTopLeft = System.Drawing.Color.White;
            this.PanelLeft.GradientTopRight = System.Drawing.Color.White;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Quality = 10;
            this.PanelLeft.Size = new System.Drawing.Size(245, 700);
            this.PanelLeft.TabIndex = 0;
            // 
            // btnFaktura
            // 
            this.btnFaktura.BackColor = System.Drawing.Color.SeaGreen;
            this.btnFaktura.color = System.Drawing.Color.SeaGreen;
            this.btnFaktura.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btnFaktura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFaktura.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnFaktura.ForeColor = System.Drawing.Color.White;
            this.btnFaktura.Image = ((System.Drawing.Image)(resources.GetObject("btnFaktura.Image")));
            this.btnFaktura.ImagePosition = 10;
            this.btnFaktura.ImageZoom = 20;
            this.btnFaktura.LabelPosition = 41;
            this.btnFaktura.LabelText = "Faktura";
            this.btnFaktura.Location = new System.Drawing.Point(0, 521);
            this.btnFaktura.Margin = new System.Windows.Forms.Padding(6);
            this.btnFaktura.Name = "btnFaktura";
            this.btnFaktura.Size = new System.Drawing.Size(245, 98);
            this.btnFaktura.TabIndex = 3;
            this.btnFaktura.Click += new System.EventHandler(this.btnFaktura_Click);
            // 
            // btnRadnik
            // 
            this.btnRadnik.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRadnik.color = System.Drawing.Color.SeaGreen;
            this.btnRadnik.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btnRadnik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRadnik.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnRadnik.ForeColor = System.Drawing.Color.White;
            this.btnRadnik.Image = ((System.Drawing.Image)(resources.GetObject("btnRadnik.Image")));
            this.btnRadnik.ImagePosition = 10;
            this.btnRadnik.ImageZoom = 20;
            this.btnRadnik.LabelPosition = 41;
            this.btnRadnik.LabelText = "Radnici";
            this.btnRadnik.Location = new System.Drawing.Point(0, 376);
            this.btnRadnik.Margin = new System.Windows.Forms.Padding(6);
            this.btnRadnik.Name = "btnRadnik";
            this.btnRadnik.Size = new System.Drawing.Size(245, 98);
            this.btnRadnik.TabIndex = 2;
            this.btnRadnik.Click += new System.EventHandler(this.btnRadnik_Click);
            // 
            // btnVozilo
            // 
            this.btnVozilo.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVozilo.color = System.Drawing.Color.SeaGreen;
            this.btnVozilo.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btnVozilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVozilo.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnVozilo.ForeColor = System.Drawing.Color.White;
            this.btnVozilo.Image = ((System.Drawing.Image)(resources.GetObject("btnVozilo.Image")));
            this.btnVozilo.ImagePosition = 10;
            this.btnVozilo.ImageZoom = 20;
            this.btnVozilo.LabelPosition = 41;
            this.btnVozilo.LabelText = "Automobili";
            this.btnVozilo.Location = new System.Drawing.Point(0, 239);
            this.btnVozilo.Margin = new System.Windows.Forms.Padding(6);
            this.btnVozilo.Name = "btnVozilo";
            this.btnVozilo.Size = new System.Drawing.Size(245, 98);
            this.btnVozilo.TabIndex = 1;
            this.btnVozilo.Click += new System.EventHandler(this.btnVozilo_Click);
            // 
            // logoPic
            // 
            this.logoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoPic.ErrorImage = null;
            this.logoPic.Image = global::RentACarOskar.Properties.Resources.logo_primjer1;
            this.logoPic.InitialImage = null;
            this.logoPic.Location = new System.Drawing.Point(0, 0);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(245, 180);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // panelCentar
            // 
            this.panelCentar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCentar.BackgroundImage")));
            this.panelCentar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCentar.Controls.Add(this.panelPanelZaGV);
            this.panelCentar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentar.GradientBottomLeft = System.Drawing.Color.White;
            this.panelCentar.GradientBottomRight = System.Drawing.Color.White;
            this.panelCentar.GradientTopLeft = System.Drawing.Color.White;
            this.panelCentar.GradientTopRight = System.Drawing.Color.White;
            this.panelCentar.Location = new System.Drawing.Point(245, 50);
            this.panelCentar.Name = "panelCentar";
            this.panelCentar.Quality = 10;
            this.panelCentar.Size = new System.Drawing.Size(927, 650);
            this.panelCentar.TabIndex = 2;
            // 
            // panelPanelZaGV
            // 
            this.panelPanelZaGV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelPanelZaGV.BackgroundImage")));
            this.panelPanelZaGV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPanelZaGV.GradientBottomLeft = System.Drawing.Color.White;
            this.panelPanelZaGV.GradientBottomRight = System.Drawing.Color.White;
            this.panelPanelZaGV.GradientTopLeft = System.Drawing.Color.White;
            this.panelPanelZaGV.GradientTopRight = System.Drawing.Color.White;
            this.panelPanelZaGV.Location = new System.Drawing.Point(0, 189);
            this.panelPanelZaGV.Name = "panelPanelZaGV";
            this.panelPanelZaGV.Quality = 10;
            this.panelPanelZaGV.Size = new System.Drawing.Size(960, 380);
            this.panelPanelZaGV.TabIndex = 0;
            // 
            // PanelTop
            // 
            this.PanelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTop.BackgroundImage")));
            this.PanelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelTop.Controls.Add(this.pictureBox3);
            this.PanelTop.Controls.Add(this.pictureBox1);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.GradientBottomLeft = System.Drawing.Color.White;
            this.PanelTop.GradientBottomRight = System.Drawing.Color.White;
            this.PanelTop.GradientTopLeft = System.Drawing.Color.White;
            this.PanelTop.GradientTopRight = System.Drawing.Color.White;
            this.PanelTop.Location = new System.Drawing.Point(245, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Quality = 10;
            this.PanelTop.Size = new System.Drawing.Size(927, 50);
            this.PanelTop.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::RentACarOskar.Properties.Resources.cross;
            this.pictureBox3.Location = new System.Drawing.Point(887, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::RentACarOskar.Properties.Resources.menu1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.PanelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelLeft.BackgroundImage")));
            this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelLeft.Controls.Add(this.panel1);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.GradientBottomLeft = System.Drawing.Color.White;
            this.PanelLeft.GradientBottomRight = System.Drawing.Color.White;
            this.PanelLeft.GradientTopLeft = System.Drawing.Color.White;
            this.PanelLeft.GradientTopRight = System.Drawing.Color.White;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Quality = 10;
            this.PanelLeft.Size = new System.Drawing.Size(245, 700);
            this.PanelLeft.TabIndex = 0;
            // 
            // btnFaktura
            // 
            this.btnFaktura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnFaktura.color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnFaktura.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(88)))));
            this.btnFaktura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFaktura.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnFaktura.ForeColor = System.Drawing.Color.White;
            this.btnFaktura.Image = global::RentACarOskar.Properties.Resources.icons8_invoice_80;
            this.btnFaktura.ImagePosition = 10;
            this.btnFaktura.ImageZoom = 20;
            this.btnFaktura.LabelPosition = 41;
            this.btnFaktura.LabelText = "Faktura";
            this.btnFaktura.Location = new System.Drawing.Point(0, 529);
            this.btnFaktura.Margin = new System.Windows.Forms.Padding(6);
            this.btnFaktura.Name = "btnFaktura";
            this.btnFaktura.Size = new System.Drawing.Size(245, 94);
            this.btnFaktura.TabIndex = 3;
            // 
            // btnVozilo
            // 
            this.btnVozilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnVozilo.color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnVozilo.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(88)))));
            this.btnVozilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVozilo.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnVozilo.ForeColor = System.Drawing.Color.White;
            this.btnVozilo.Image = global::RentACarOskar.Properties.Resources.car__2_;
            this.btnVozilo.ImagePosition = 10;
            this.btnVozilo.ImageZoom = 20;
            this.btnVozilo.LabelPosition = 41;
            this.btnVozilo.LabelText = "Automobili";
            this.btnVozilo.Location = new System.Drawing.Point(0, 239);
            this.btnVozilo.Margin = new System.Windows.Forms.Padding(6);
            this.btnVozilo.Name = "btnVozilo";
            this.btnVozilo.Size = new System.Drawing.Size(245, 94);
            this.btnVozilo.TabIndex = 1;
            // 
            // logoPic
            // 
            this.logoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoPic.ErrorImage = null;
            this.logoPic.Image = global::RentACarOskar.Properties.Resources.logo_primjer1;
            this.logoPic.InitialImage = null;
            this.logoPic.Location = new System.Drawing.Point(0, 12);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(245, 174);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            this.logoPic.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(185)))), ((int)(((byte)(209)))));
            this.panel1.Controls.Add(this.slicica3);
            this.panel1.Controls.Add(this.slicica2);
            this.panel1.Controls.Add(this.slicica1);
            this.panel1.Controls.Add(this.btnVozilo);
            this.panel1.Controls.Add(this.logoPic);
            this.panel1.Controls.Add(this.btnFaktura);
            this.panel1.Controls.Add(this.btnRadnik);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 700);
            this.panel1.TabIndex = 0;
            // 
            // btnRadnik
            // 
            this.btnRadnik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnRadnik.color = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnRadnik.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(88)))));
            this.btnRadnik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRadnik.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnRadnik.ForeColor = System.Drawing.Color.White;
            this.btnRadnik.Image = global::RentACarOskar.Properties.Resources.icons8_people_96__1_;
            this.btnRadnik.ImagePosition = 12;
            this.btnRadnik.ImageZoom = 20;
            this.btnRadnik.LabelPosition = 41;
            this.btnRadnik.LabelText = "Radnici";
            this.btnRadnik.Location = new System.Drawing.Point(0, 389);
            this.btnRadnik.Margin = new System.Windows.Forms.Padding(6);
            this.btnRadnik.Name = "btnRadnik";
            this.btnRadnik.Size = new System.Drawing.Size(245, 94);
            this.btnRadnik.TabIndex = 2;
            // 
            // slicica1
            // 
            this.slicica1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.slicica1.Image = global::RentACarOskar.Properties.Resources.car__2_;
            this.slicica1.ImageActive = null;
            this.slicica1.InitialImage = global::RentACarOskar.Properties.Resources.car__2_;
            this.slicica1.Location = new System.Drawing.Point(0, 239);
            this.slicica1.Name = "slicica1";
            this.slicica1.Size = new System.Drawing.Size(40, 92);
            this.slicica1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slicica1.TabIndex = 6;
            this.slicica1.TabStop = false;
            this.slicica1.Visible = false;
            this.slicica1.Zoom = 10;
            this.slicica1.Click += new System.EventHandler(this.slicica1_Click);
            // 
            // slicica2
            // 
            this.slicica2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.slicica2.Image = global::RentACarOskar.Properties.Resources.icons8_people_96__1_;
            this.slicica2.ImageActive = null;
            this.slicica2.InitialImage = global::RentACarOskar.Properties.Resources.car__2_;
            this.slicica2.Location = new System.Drawing.Point(0, 389);
            this.slicica2.Name = "slicica2";
            this.slicica2.Size = new System.Drawing.Size(40, 92);
            this.slicica2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slicica2.TabIndex = 7;
            this.slicica2.TabStop = false;
            this.slicica2.Visible = false;
            this.slicica2.Zoom = 10;
            this.slicica2.Click += new System.EventHandler(this.slicica2_Click);
            // 
            // slicica3
            // 
            this.slicica3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.slicica3.Image = global::RentACarOskar.Properties.Resources.icons8_invoice_80;
            this.slicica3.ImageActive = null;
            this.slicica3.InitialImage = global::RentACarOskar.Properties.Resources.car__2_;
            this.slicica3.Location = new System.Drawing.Point(0, 529);
            this.slicica3.Name = "slicica3";
            this.slicica3.Size = new System.Drawing.Size(40, 92);
            this.slicica3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slicica3.TabIndex = 8;
            this.slicica3.TabStop = false;
            this.slicica3.Visible = false;
            this.slicica3.Zoom = 10;
            this.slicica3.Click += new System.EventHandler(this.slicica3_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 700);
            this.Controls.Add(this.panelCentar);
            this.Controls.Add(this.PanelTop);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panelCentar.ResumeLayout(false);
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slicica1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicica2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicica3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel PanelLeft;
        private Bunifu.Framework.UI.BunifuGradientPanel PanelTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuGradientPanel panelCentar;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuTileButton btnVozilo;
        private Bunifu.Framework.UI.BunifuTileButton btnFaktura;
        private Bunifu.Framework.UI.BunifuTileButton btnRadnik;
        private Bunifu.Framework.UI.BunifuGradientPanel panelPanelZaGV;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton slicica1;
        private Bunifu.Framework.UI.BunifuImageButton slicica2;
        private Bunifu.Framework.UI.BunifuImageButton slicica3;
    }
}