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

        public MeniZaDashboard(string userName,int userId)
        {
            InitializeComponent();
            timer1.Start();
            loader.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

            string _userName = userName;
            int _userId = userId;

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

            MjesecnaZaradaRadnika(8);


            
            //stringQuery = brojVozila();
            //brVozila = DobavljanePOdatakaIzBaze(stringQuery);
            //labelBrVozila.Text = brVozila.ToString();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //f-ja koja poziva proceduru koja u sebi ima return
        public void MjesecnaZaradaRadnika(int idRadnika)
        {
            int plata = 0;
            using (SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("mjesecnaZaradaRadnika", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@radnikId", SqlDbType.Int).Value = idRadnika;

                    var returnParameter = cmd.Parameters.Add("@Iznos", System.Data.SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;


                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    labelPlata.Text = result.ToString();
                }               
            }
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
        public string listaSlobodnihVozila()
        {
            return @"SELECT 
                	mv.Naziv,
                	p.Naziv,
                	v.VrstaGoriva,
                	v.GodinaProizvodnje,
                	sv.DatumStatusa
                    FROM dbo.Vozilo v
                     JOIN dbo.ModelVozila mv
                     ON v.ModelID = mv.ModelID
                     JOIN dbo.Proizvodjac p
                     ON mv.ProizvodjacID = p.ProizvodjacID
                     LEFT JOIN dbo.StatusVozila sv 
                     ON v.VoziloID = sv.VoziloID
                     LEFT JOIN dbo.Dostupnost d ON sv.DostupnostID = d.DostupnostID
                     WHERE (d.TipDostupnosti IS NULL OR d.DostupnostID = 2)
	                and v.IsDeleted = 0

                    ORDER BY mv.Naziv";
        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    labelTime.Text = DateTime.Now.ToLongTimeString();
        //    timer1.Start();
        //}


        private void brVozila_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
