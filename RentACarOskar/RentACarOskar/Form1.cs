using KonekcijaNaBazu;
using MetroFramework;
using RentACarOskar.PropertyClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarOskar
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
           
            InitializeComponent();
            Color panelColor = Color.FromArgb(102, 0, 0, 0);
            //panel3.BackColor = panelColor;
            tbPassword.PasswordChar = '*';
            // panel3.BackColor = Color.FromArgb(102, 0, 0, 0);
            //metroPanel1.BackColor = Color.FromArgb(20, 255, 255, 255);  
            this.ControlBox = false;

        }

        #region Prijavljivanje_Enter
        private void KeyUp_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Login();
        }
        #endregion

        #region Login
        private void Login()
        {
            if (tbUserName.Text == "" || tbPassword.Text == "")
            {
                //MessageBox.Show("Molim vas unesite sve potrebne podatke!");
                DialogResult dr = MetroMessageBox.Show(this, "\n\nMolimo Vas unesite sve potrebne podatke!", "Molimo Vas unesite sve potrebne podatke!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            DataTable dt = new DataTable();

            PropertyRadnik myProperty = new PropertyRadnik();

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetSelectQuery());

            dt.Load(reader);
            reader.Close();

            var type = myProperty.GetType();
            var properties = type.GetProperties();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][7].ToString() == tbPassword.Text && dt.Rows[i][8].ToString() == tbUserName.Text)
                {
                    string rola = dt.Rows[i][9].ToString();
                    //MessageBox.Show("Uspjesan Login");
                    AutoClosingMessageBox.Show("Uspjesan Login", "LogIn", 1000);
                    string mail = tbUserName.Text;
                    string ID = dt.Rows[i][0].ToString();
                    Dashboard pom = new Dashboard(mail, ID,rola);
                    pom.ShowDialog();
                    Visible = false;
                    if (pom.DialogResult == DialogResult.Cancel)
                    {
                        pom.Close();
                        Visible = true;
                        tbUserName.Text = "";
                        tbPassword.Text = "";
                    }
                    break;
                }
                else if (i == dt.Rows.Count - 1)
                {   //MessageBox.Show("Pogresan E-mail ili loznika!");
                    DialogResult dr = MetroMessageBox.Show(this, "\n\nPogresan E-mail ili loznika!", "Pogresan E-mail ili loznika!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Dugme
        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {
            btnLogIn.ForeColor = Color.White;
        }

        private void btnLogIn_MouseLeave(object sender, EventArgs e)
        {
            btnLogIn.ForeColor = Color.Gray;
        }

        #endregion

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
