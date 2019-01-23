namespace RentACarOskar
{
    partial class Izvjestaj
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
            this.rvIzvjestaj = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvIzvjestaj
            // 
            this.rvIzvjestaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvIzvjestaj.Location = new System.Drawing.Point(0, 0);
            this.rvIzvjestaj.Name = "rvIzvjestaj";
            this.rvIzvjestaj.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rvIzvjestaj.ServerReport.BearerToken = null;
            this.rvIzvjestaj.ServerReport.ReportServerUrl = new System.Uri("http://10.226.9.13/reportserver_itivity", System.UriKind.Absolute);
            this.rvIzvjestaj.Size = new System.Drawing.Size(800, 450);
            this.rvIzvjestaj.TabIndex = 0;
            // 
            // Izvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvIzvjestaj);
            this.Name = "Izvjestaj";
            this.Text = "Izvjestaj";
            this.Load += new System.EventHandler(this.Izvjestaj_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvIzvjestaj;
    }
}