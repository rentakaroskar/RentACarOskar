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
            this.btnInsert = new MetroFramework.Controls.MetroButton();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnDelete = new MetroFramework.Controls.MetroButton();
            this.btnReturn = new MetroFramework.Controls.MetroButton();
            this.panelPanelZaGV = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(23, 404);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Add New";
            this.btnInsert.UseSelectable = true;
            this.btnInsert.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(104, 404);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(185, 404);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(527, 404);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseSelectable = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // panelPanelZaGV
            // 
            this.panelPanelZaGV.Location = new System.Drawing.Point(23, 68);
            this.panelPanelZaGV.Name = "panelPanelZaGV";
            this.panelPanelZaGV.Size = new System.Drawing.Size(578, 323);
            this.panelPanelZaGV.TabIndex = 6;
            // 
            // LookUpForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 440);
            this.Controls.Add(this.panelPanelZaGV);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookUpForma";
            this.Text = "LookUpForma";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnInsert;
        private MetroFramework.Controls.MetroButton btnUpdate;
        private MetroFramework.Controls.MetroButton btnDelete;
        private MetroFramework.Controls.MetroButton btnReturn;
        private System.Windows.Forms.Panel panelPanelZaGV;
    }
}