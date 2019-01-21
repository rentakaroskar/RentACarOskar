namespace RentACarOskar
{
    partial class DodajVoziloNaFakturu
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
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.btnDodajVozilo = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nupBrojDana = new System.Windows.Forms.NumericUpDown();
            this.txtBrojDana = new System.Windows.Forms.Label();
            this.lblCijenaPoDanu = new System.Windows.Forms.Label();
            this.lblAuto = new System.Windows.Forms.Label();
            this.txtCijenaPoDanu = new System.Windows.Forms.TextBox();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBrojDana)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDGV
            // 
            this.pnlDGV.Location = new System.Drawing.Point(13, 94);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(447, 221);
            this.pnlDGV.TabIndex = 0;
            // 
            // btnDodajVozilo
            // 
            this.btnDodajVozilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajVozilo.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDodajVozilo.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDodajVozilo.Location = new System.Drawing.Point(13, 453);
            this.btnDodajVozilo.Name = "btnDodajVozilo";
            this.btnDodajVozilo.Size = new System.Drawing.Size(113, 45);
            this.btnDodajVozilo.TabIndex = 7;
            this.btnDodajVozilo.Text = "Dodaj Vozilo";
            this.btnDodajVozilo.UseSelectable = true;
            this.btnDodajVozilo.Click += new System.EventHandler(this.btnDodajVozilo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nupBrojDana);
            this.panel1.Controls.Add(this.txtBrojDana);
            this.panel1.Controls.Add(this.lblCijenaPoDanu);
            this.panel1.Controls.Add(this.lblAuto);
            this.panel1.Controls.Add(this.txtCijenaPoDanu);
            this.panel1.Controls.Add(this.txtAuto);
            this.panel1.Location = new System.Drawing.Point(13, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 125);
            this.panel1.TabIndex = 8;
            // 
            // nupBrojDana
            // 
            this.nupBrojDana.Location = new System.Drawing.Point(203, 84);
            this.nupBrojDana.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupBrojDana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupBrojDana.Name = "nupBrojDana";
            this.nupBrojDana.Size = new System.Drawing.Size(120, 20);
            this.nupBrojDana.TabIndex = 5;
            this.nupBrojDana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtBrojDana
            // 
            this.txtBrojDana.AutoSize = true;
            this.txtBrojDana.Location = new System.Drawing.Point(116, 86);
            this.txtBrojDana.Name = "txtBrojDana";
            this.txtBrojDana.Size = new System.Drawing.Size(55, 13);
            this.txtBrojDana.TabIndex = 4;
            this.txtBrojDana.Text = "Broj dana:";
            // 
            // lblCijenaPoDanu
            // 
            this.lblCijenaPoDanu.AutoSize = true;
            this.lblCijenaPoDanu.Location = new System.Drawing.Point(115, 50);
            this.lblCijenaPoDanu.Name = "lblCijenaPoDanu";
            this.lblCijenaPoDanu.Size = new System.Drawing.Size(81, 13);
            this.lblCijenaPoDanu.TabIndex = 3;
            this.lblCijenaPoDanu.Text = "Cijena po danu:";
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Location = new System.Drawing.Point(116, 12);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(32, 13);
            this.lblAuto.TabIndex = 2;
            this.lblAuto.Text = "Auto:";
            // 
            // txtCijenaPoDanu
            // 
            this.txtCijenaPoDanu.Enabled = false;
            this.txtCijenaPoDanu.Location = new System.Drawing.Point(204, 47);
            this.txtCijenaPoDanu.Name = "txtCijenaPoDanu";
            this.txtCijenaPoDanu.Size = new System.Drawing.Size(119, 20);
            this.txtCijenaPoDanu.TabIndex = 1;
            // 
            // txtAuto
            // 
            this.txtAuto.Enabled = false;
            this.txtAuto.Location = new System.Drawing.Point(203, 9);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.Size = new System.Drawing.Size(119, 20);
            this.txtAuto.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(347, 453);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(113, 45);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Cancel";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // DodajVoziloNaFakturu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 515);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDodajVozilo);
            this.Controls.Add(this.pnlDGV);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DodajVoziloNaFakturu";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "DodajVoziloNaFakturu";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.DodajVoziloNaFakturu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupBrojDana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDGV;
        private MetroFramework.Controls.MetroButton btnDodajVozilo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nupBrojDana;
        private System.Windows.Forms.Label txtBrojDana;
        private System.Windows.Forms.Label lblCijenaPoDanu;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.TextBox txtCijenaPoDanu;
        private System.Windows.Forms.TextBox txtAuto;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}