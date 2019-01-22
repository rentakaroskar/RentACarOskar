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
        public MeniZaDashboard(string userName)
        {
            InitializeComponent();
            timer1.Start();

            string _userName = userName;

            labelUserName.Text = _userName;
            labelBrVozila.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            int brVozila = 0;

            string stringQuery;
            stringQuery = brojVozila();
            brVozila = DobavljanePOdatakaIzBaze(stringQuery);
            labelBrVozila.Text = brVozila.ToString();


            stringQuery = brojSlobodnihVozila();
            brVozila = DobavljanePOdatakaIzBaze(stringQuery);
            labelSlobodnaVozila.Text = brVozila.ToString();

            chart1.Series["s1"].Points.AddXY(" ", brVozila);

            stringQuery = brojZauzetihVozila();
            brVozila = DobavljanePOdatakaIzBaze(stringQuery);
            lblBrojzauzetihVozila.Text = brVozila.ToString();
            chart1.Series["s1"].Points.AddXY(" ", brVozila);





        }
        public int DobavljanePOdatakaIzBaze(string query)
        {
            int br = 0;
            DataTable dt = new DataTable();
            SqlDataReader reader;

           reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
           query);

            dt.Load(reader);
            object field = dt.Rows[0].ItemArray[0];
            reader.Close();
            br = Convert.ToInt32(field);
            return br;
        }
        public string brojVozila()
        {
            return @"SELECT COUNT(v.VoziloID)
                                FROM dbo.Vozilo v
                        WHERE IsDeleted = 0";
        }
        public string brojSlobodnihVozila()
        {
            return @"SELECT count(v.VoziloID)
                        FROM dbo.vFilterVozila v
                        WHERE
                        v.Dostupnost='Slobodan'";
        }
        public string brojZauzetihVozila()
        {
            return @"SELECT count(v.VoziloID)
                        FROM dbo.vFilterVozila v
                        WHERE
                        v.Dostupnost='Zauzet'";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ///labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }


        private void brVozila_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
