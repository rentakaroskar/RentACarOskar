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
            this.tbNaziv = new MetroFramework.Controls.MetroTextBox();
            this.btnLookup = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(3, 9);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(47, 19);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Labela";
            // 
            // tbNaziv
            // 
            // 
            // 
            // 
            this.tbNaziv.CustomButton.Image = null;
            this.tbNaziv.CustomButton.Location = new System.Drawing.Point(190, 1);
            this.tbNaziv.CustomButton.Name = "";
            this.tbNaziv.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbNaziv.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbNaziv.CustomButton.TabIndex = 1;
            this.tbNaziv.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbNaziv.CustomButton.UseSelectable = true;
            this.tbNaziv.CustomButton.Visible = false;
            this.tbNaziv.Lines = new string[0];
            this.tbNaziv.Location = new System.Drawing.Point(88, 9);
            this.tbNaziv.MaxLength = 32767;
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.PasswordChar = '\0';
            this.tbNaziv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbNaziv.SelectedText = "";
            this.tbNaziv.SelectionLength = 0;
            this.tbNaziv.SelectionStart = 0;
            this.tbNaziv.ShortcutsEnabled = true;
            this.tbNaziv.Size = new System.Drawing.Size(212, 23);
            this.tbNaziv.TabIndex = 2;
            this.tbNaziv.UseSelectable = true;
            this.tbNaziv.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbNaziv.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(306, 9);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(48, 23);
            this.btnLookup.TabIndex = 3;
            this.btnLookup.Text = "...";
            this.btnLookup.UseSelectable = true;
            // 
            // LookUpControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.tbNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Name = "LookUpControl";
            this.Size = new System.Drawing.Size(364, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNaziv;
        private MetroFramework.Controls.MetroTextBox tbNaziv;
        private MetroFramework.Controls.MetroButton btnLookup;
    }
}
