using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonekcijaNaBazu;
using System.Data.SqlClient;

namespace RentACarOskar.UserControls
{
    public partial class MeniZaDashboard : UserControl
    {
        public MeniZaDashboard()
        {
            InitializeComponent();
            timer1.Start();

            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

            DataTable dt = new DataTable();
            //int x = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, brojVozila());
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
            brojVozila());
            dt.Load(reader);
            brVozila.Text = dt.Rows[0].ToString();
           
            //int x = dt.Rows[0];
            reader.Close();
            //brVozila.Text = x.ToString();
        }
        public string brojVozila()
        {
            return @"SELECT COUNT(v.VoziloID)
                                FROM dbo.Vozilo v";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void brVozila_Click(object sender, EventArgs e)
        {

        }
    }
}
