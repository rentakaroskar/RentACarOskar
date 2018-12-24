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
            this.btnStampaj.Text = "STAMPAJ";
            this.btnStampaj.UseSelectable = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
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
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "FormaIzdavanje";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnStampaj;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}