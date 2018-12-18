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
            this.btnStampaj = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btnStampaj
            // 
            this.btnStampaj.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(88)))));
            this.btnStampaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnStampaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStampaj.BorderRadius = 6;
            this.btnStampaj.ButtonText = "STAMPAJ";
            this.btnStampaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStampaj.DisabledColor = System.Drawing.Color.Gray;
            this.btnStampaj.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStampaj.Iconimage = null;
            this.btnStampaj.Iconimage_right = null;
            this.btnStampaj.Iconimage_right_Selected = null;
            this.btnStampaj.Iconimage_Selected = null;
            this.btnStampaj.IconMarginLeft = 0;
            this.btnStampaj.IconMarginRight = 0;
            this.btnStampaj.IconRightVisible = true;
            this.btnStampaj.IconRightZoom = 0D;
            this.btnStampaj.IconVisible = true;
            this.btnStampaj.IconZoom = 90D;
            this.btnStampaj.IsTab = false;
            this.btnStampaj.Location = new System.Drawing.Point(660, 393);
            this.btnStampaj.Name = "btnStampaj";
            this.btnStampaj.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(135)))), ((int)(((byte)(150)))));
            this.btnStampaj.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(181)))), ((int)(((byte)(88)))));
            this.btnStampaj.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStampaj.selected = false;
            this.btnStampaj.Size = new System.Drawing.Size(108, 34);
            this.btnStampaj.TabIndex = 4;
            this.btnStampaj.Text = "STAMPAJ";
            this.btnStampaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStampaj.Textcolor = System.Drawing.Color.White;
            this.btnStampaj.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // FormaIzdavanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStampaj);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FormaIzdavanje";
            this.Resizable = false;
            this.Text = "FormaIzdavanje";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnStampaj;
    }
}