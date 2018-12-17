namespace RentACarOskar
{
    partial class LookUpForma
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
            this.dgStandardGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgStandardGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgStandardGrid
            // 
            this.dgStandardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStandardGrid.Location = new System.Drawing.Point(43, 88);
            this.dgStandardGrid.Name = "dgStandardGrid";
            this.dgStandardGrid.Size = new System.Drawing.Size(579, 303);
            this.dgStandardGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // LookUpForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgStandardGrid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpForma";
            this.Text = "LookUpForma";
            ((System.ComponentModel.ISupportInitialize)(this.dgStandardGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStandardGrid;
        private System.Windows.Forms.Button button1;
    }
}