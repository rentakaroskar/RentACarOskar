using KonekcijaNaBazu;
using RentACarOskar.PropertClass;
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
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(tbUserName.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Molim vas unesite sve potrebne podatke!");
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
                    MessageBox.Show("Uspjesan Login");
                    break;
                }
                else if (i == dt.Rows.Count - 1)
                    MessageBox.Show("Pogresan E-mail ili loznika!");
            }
        }
    }
}
