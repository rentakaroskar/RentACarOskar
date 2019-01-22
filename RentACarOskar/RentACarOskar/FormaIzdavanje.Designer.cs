namespace RentACarOskar
{
    partial class FormaIzdavanje
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
            this.btnStampaj = new MetroFramework.Controls.MetroButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnDodajVozilo = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnStampaj
            // 
            this.btnStampaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStampaj.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnStampaj.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnStampaj.Location = new System.Drawing.Point(670, 399);
            this.btnStampaj.Name = "btnStampaj";
            this.btnStampaj.Size = new System.Drawing.Size(107, 28);
            this.btnStampaj.TabIndex = 5;
            this.btnStampaj.Text = "ŠTAMPAJ";
            this.btnStampaj.UseSelectable = true;
            this.btnStampaj.Click += new System.EventHandler(this.btnStampaj_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnDodajVozilo
            // 
            this.btnDodajVozilo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDodajVozilo.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDodajVozilo.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDodajVozilo.Location = new System.Drawing.Point(23, 399);
            this.btnDodajVozilo.Name = "btnDodajVozilo";
            this.btnDodajVozilo.Size = new System.Drawing.Size(107, 28);
            this.btnDodajVozilo.TabIndex = 6;
            this.btnDodajVozilo.Text = "DODAJ VOZILO";
            this.btnDodajVozilo.UseSelectable = true;
            this.btnDodajVozilo.Click += new System.EventHandler(this.btnDodajVozilo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::RentACarOskar.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(772, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(21, 20);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnRemove.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnRemove.Location = new System.Drawing.Point(151, 399);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(107, 28);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "OBRISI VOZILO";
            this.btnRemove.UseSelectable = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FormaIzdavanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDodajVozilo);
            this.Controls.Add(this.btnStampaj);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FormaIzdavanje";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "FormaIzdavanje";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnStampaj;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private MetroFramework.Controls.MetroButton btnDodajVozilo;
        private System.Windows.Forms.Button btnCancel;
        private MetroFramework.Controls.MetroButton btnRemove;
    }
}