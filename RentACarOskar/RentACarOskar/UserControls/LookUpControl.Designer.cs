namespace RentACarOskar.UserControls
{
    partial class LookUpControl
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
            this.lblNaziv = new MetroFramework.Controls.MetroLabel();
            this.tbKey = new MetroFramework.Controls.MetroTextBox();
            this.btnLookup = new MetroFramework.Controls.MetroButton();
            this.tbNaziv = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(16, 10);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(47, 19);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Labela";
            // 
            // tbKey
            // 
            // 
            // 
            // 
            this.tbKey.CustomButton.Image = null;
            this.tbKey.CustomButton.Location = new System.Drawing.Point(14, 1);
            this.tbKey.CustomButton.Name = "";
            this.tbKey.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbKey.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbKey.CustomButton.TabIndex = 1;
            this.tbKey.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbKey.CustomButton.UseSelectable = true;
            this.tbKey.CustomButton.Visible = false;
            this.tbKey.Lines = new string[0];
            this.tbKey.Location = new System.Drawing.Point(149, 9);
            this.tbKey.MaxLength = 32767;
            this.tbKey.Name = "tbKey";
            this.tbKey.PasswordChar = '\0';
            this.tbKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbKey.SelectedText = "";
            this.tbKey.SelectionLength = 0;
            this.tbKey.SelectionStart = 0;
            this.tbKey.ShortcutsEnabled = true;
            this.tbKey.Size = new System.Drawing.Size(36, 23);
            this.tbKey.TabIndex = 2;
            this.tbKey.UseSelectable = true;
            this.tbKey.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbKey.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(191, 9);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(29, 23);
            this.btnLookup.TabIndex = 3;
            this.btnLookup.Text = "...";
            this.btnLookup.UseSelectable = true;
            this.btnLookup.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tbNaziv
            // 
            // 
            // 
            // 
            this.tbNaziv.CustomButton.Image = null;
            this.tbNaziv.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.tbNaziv.CustomButton.Name = "";
            this.tbNaziv.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbNaziv.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbNaziv.CustomButton.TabIndex = 1;
            this.tbNaziv.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbNaziv.CustomButton.UseSelectable = true;
            this.tbNaziv.CustomButton.Visible = false;
            this.tbNaziv.Lines = new string[0];
            this.tbNaziv.Location = new System.Drawing.Point(226, 9);
            this.tbNaziv.MaxLength = 32767;
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.PasswordChar = '\0';
            this.tbNaziv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbNaziv.SelectedText = "";
            this.tbNaziv.SelectionLength = 0;
            this.tbNaziv.SelectionStart = 0;
            this.tbNaziv.ShortcutsEnabled = true;
            this.tbNaziv.Size = new System.Drawing.Size(133, 23);
            this.tbNaziv.TabIndex = 4;
            this.tbNaziv.UseSelectable = true;
            this.tbNaziv.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbNaziv.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LookUpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblNaziv);
            this.Name = "LookUpControl";
            this.Size = new System.Drawing.Size(371, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNaziv;
        private MetroFramework.Controls.MetroTextBox tbKey;
        private MetroFramework.Controls.MetroButton btnLookup;
        private MetroFramework.Controls.MetroTextBox tbNaziv;
    }
}
