namespace RentACarOskar
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
            this.components = new System.ComponentModel.Container();
            this.MenuVertical = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BarTitle = new MetroFramework.Controls.MetroPanel();
            this.btnSlide = new System.Windows.Forms.PictureBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BarTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.HorizontalScrollbarBarColor = true;
            this.MenuVertical.HorizontalScrollbarHighlightOnWheel = false;
            this.MenuVertical.HorizontalScrollbarSize = 10;
            this.MenuVertical.Location = new System.Drawing.Point(0, 30);
            this.MenuVertical.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(241, 674);
            this.MenuVertical.TabIndex = 0;
            this.MenuVertical.UseCustomBackColor = true;
            this.MenuVertical.VerticalScrollbarBarColor = true;
            this.MenuVertical.VerticalScrollbarHighlightOnWheel = false;
            this.MenuVertical.VerticalScrollbarSize = 10;
            this.MenuVertical.Paint += new System.Windows.Forms.PaintEventHandler(this.metroPanel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentACarOskar.Properties.Resources.logo_primjer1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 432);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BarTitle
            // 
            this.BarTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BarTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BarTitle.Controls.Add(this.btnSlide);
            this.BarTitle.HorizontalScrollbarBarColor = true;
            this.BarTitle.HorizontalScrollbarHighlightOnWheel = false;
            this.BarTitle.HorizontalScrollbarSize = 10;
            this.BarTitle.Location = new System.Drawing.Point(241, 30);
            this.BarTitle.Margin = new System.Windows.Forms.Padding(0);
            this.BarTitle.Name = "BarTitle";
            this.BarTitle.Size = new System.Drawing.Size(930, 42);
            this.BarTitle.TabIndex = 1;
            this.BarTitle.VerticalScrollbarBarColor = true;
            this.BarTitle.VerticalScrollbarHighlightOnWheel = false;
            this.BarTitle.VerticalScrollbarSize = 10;
            // 
            // btnSlide
            // 
            this.btnSlide.Image = global::RentACarOskar.Properties.Resources.menu1;
            this.btnSlide.Location = new System.Drawing.Point(17, 3);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(35, 35);
            this.btnSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSlide.TabIndex = 2;
            this.btnSlide.TabStop = false;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1171, 704);
            this.ControlBox = false;
            this.Controls.Add(this.BarTitle);
            this.Controls.Add(this.MenuVertical);
            this.DisplayHeader = false;
            this.DoubleBuffered = false;
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Dashboard";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BarTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel MenuVertical;
        private MetroFramework.Controls.MetroPanel BarTitle;
        private System.Windows.Forms.PictureBox btnSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        public MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}