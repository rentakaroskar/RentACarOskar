using System.Drawing;

namespace RentACarOskar
{
    partial class Form1
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.btnLogIn = new System.Windows.Forms.Button();
            this.tbPassword = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new MetroFramework.Controls.MetroTextBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.slicicaAuto = new Bunifu.Framework.UI.BunifuImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicicaAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.Transparent;
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogIn.Location = new System.Drawing.Point(103, 404);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(98, 42);
            this.btnLogIn.TabIndex = 8;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            this.btnLogIn.MouseLeave += new System.EventHandler(this.btnLogIn_MouseLeave);
            this.btnLogIn.MouseHover += new System.EventHandler(this.btnLogIn_MouseHover);
            // 
            // tbPassword
            // 
            // 
            // 
            // 
            this.tbPassword.CustomButton.Image = null;
            this.tbPassword.CustomButton.Location = new System.Drawing.Point(246, 1);
            this.tbPassword.CustomButton.Name = "";
            this.tbPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPassword.CustomButton.TabIndex = 1;
            this.tbPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPassword.CustomButton.UseSelectable = true;
            this.tbPassword.CustomButton.Visible = false;
            this.tbPassword.Lines = new string[0];
            this.tbPassword.Location = new System.Drawing.Point(27, 307);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '\0';
            this.tbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPassword.SelectedText = "";
            this.tbPassword.SelectionLength = 0;
            this.tbPassword.SelectionStart = 0;
            this.tbPassword.ShortcutsEnabled = true;
            this.tbPassword.Size = new System.Drawing.Size(268, 23);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSelectable = true;
            this.tbPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(23, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "User name";
            // 
            // tbUserName
            // 
            // 
            // 
            // 
            this.tbUserName.CustomButton.Image = null;
            this.tbUserName.CustomButton.Location = new System.Drawing.Point(246, 1);
            this.tbUserName.CustomButton.Name = "";
            this.tbUserName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbUserName.CustomButton.TabIndex = 1;
            this.tbUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbUserName.CustomButton.UseSelectable = true;
            this.tbUserName.CustomButton.Visible = false;
            this.tbUserName.Lines = new string[0];
            this.tbUserName.Location = new System.Drawing.Point(27, 223);
            this.tbUserName.MaxLength = 32767;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUserName.SelectedText = "";
            this.tbUserName.SelectionLength = 0;
            this.tbUserName.SelectionStart = 0;
            this.tbUserName.ShortcutsEnabled = true;
            this.tbUserName.Size = new System.Drawing.Size(268, 23);
            this.tbUserName.TabIndex = 2;
            this.tbUserName.UseSelectable = true;
            this.tbUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Enter);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // slicicaAuto
            // 
            this.slicicaAuto.BackColor = System.Drawing.Color.Transparent;
            this.slicicaAuto.Image = global::RentACarOskar.Properties.Resources.car2;
            this.slicicaAuto.ImageActive = null;
            this.slicicaAuto.InitialImage = global::RentACarOskar.Properties.Resources.car__2_;
            this.slicicaAuto.Location = new System.Drawing.Point(130, 22);
            this.slicicaAuto.Name = "slicicaAuto";
            this.slicicaAuto.Size = new System.Drawing.Size(65, 65);
            this.slicicaAuto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slicicaAuto.TabIndex = 7;
            this.slicicaAuto.TabStop = false;
            this.slicicaAuto.Zoom = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(82, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "MEMBER LOGIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(23, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RentACarOskar.Properties.Resources.Smoke_PNG_Image_72462;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 406);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.ForeColor = System.Drawing.Color.White;
            label4.Location = new System.Drawing.Point(233, 108);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 10;
            label4.Text = "____";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(52, 108);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(31, 13);
            label5.TabIndex = 11;
            label5.Text = "____";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RentACarOskar.Properties.Resources.blur2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackImage = global::RentACarOskar.Properties.Resources.blur2;
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.BackMaxSize = 550;
            this.ClientSize = new System.Drawing.Size(321, 493);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.slicicaAuto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slicicaAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTextBox tbPassword;
        private MetroFramework.Controls.MetroTextBox tbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogIn;
        private Bunifu.Framework.UI.BunifuImageButton slicicaAuto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

