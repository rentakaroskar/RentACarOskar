namespace RentACarOskar.UserControls
{
    partial class InputDateControl
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
            this.dtNaziv = new MetroFramework.Controls.MetroDateTime();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(3, 11);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(47, 19);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Labela";
            // 
            // dtNaziv
            // 
            this.dtNaziv.Location = new System.Drawing.Point(99, 6);
            this.dtNaziv.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtNaziv.Name = "dtNaziv";
            this.dtNaziv.Size = new System.Drawing.Size(200, 29);
            this.dtNaziv.TabIndex = 2;
            // 
            // InputDateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Name = "InputDateControl";
            this.Size = new System.Drawing.Size(310, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblNaziv;
        private MetroFramework.Controls.MetroDateTime dtNaziv;
    }
}
