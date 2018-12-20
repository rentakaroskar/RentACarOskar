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
            tbPassword.PasswordChar = '*';
            metroPanel1.BackColor = Color.FromArgb(20, 255, 255, 255);
        }

        private void KeyUp_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                        string mail = tbUserName.Text;
                        MessageBox.Show("Uspjesan Login");
                        Dashboard pom = new Dashboard(mail);
                        pom.ShowDialog();
                        break;
                    }
                    else if (i == dt.Rows.Count - 1)
                    {   //MessageBox.Show("Pogresan E-mail ili loznika!");
                        DialogResult dr = MetroMessageBox.Show(this, "\n\nPogresan E-mail ili loznika!", "Pogresan E-mail ili loznika!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            //private void btnLogIn_Click(object sender, EventArgs e)
            //{
            //    if (tbUserName.Text == "" || tbPassword.Text == "")
            //    {
            //        //MessageBox.Show("Molim vas unesite sve potrebne podatke!");
            //        DialogResult dr = MetroMessageBox.Show(this, "\n\nMolimo Vas unesite sve potrebne podatke!", "Molimo Vas unesite sve potrebne podatke!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        return;
            //    }
            //    DataTable dt = new DataTable();

            //    PropertyRadnik myProperty = new PropertyRadnik();

            //    SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
            //        myProperty.GetSelectQuery());

            //    dt.Load(reader);
            //    reader.Close();

            //    var type = myProperty.GetType();
            //    var properties = type.GetProperties();

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        if (dt.Rows[i][7].ToString() == tbPassword.Text && dt.Rows[i][8].ToString() == tbUserName.Text)
            //        {
            //            MessageBox.Show("Uspjesan Login");
            //            Dashboard pom = new Dashboard();
            //            Visible = false;
            //            pom.ShowDialog();
            //            if (pom.DialogResult == DialogResult.Cancel)
            //            {
            //                pom.Close();
            //                Visible = true;
            //                tbUserName.Text = "";
            //                tbPassword.Text = "";
            //            }
            //            break;
            //        }
            //        else if (i == dt.Rows.Count - 1)
            //        {   //MessageBox.Show("Pogresan E-mail ili loznika!");
            //            DialogResult dr = MetroMessageBox.Show(this, "\n\nPogresan E-mail ili loznika!", "Pogresan E-mail ili loznika!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string mail = tbUserName.Text;
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
                    //MessageBox.Show("Uspjesan Login");
                    AutoClosingMessageBox.Show("Uspjesan Login", "LogIn", 1000);
                    Dashboard pom = new Dashboard(mail);
                    Visible = false;
                    pom.ShowDialog();
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

        private void btnLogIn_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnLogIn_MouseLeave(object sender, EventArgs e)
        {
            btnLogIn.BackColor = Color.FromArgb(20, 255, 255, 255);

        }



        public class AutoClosingMessageBox
        { 

            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
                 
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}
