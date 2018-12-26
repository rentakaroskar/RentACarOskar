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
using KonekcijaNaBazu;
using MetroFramework;
using RentACarOskar.PropertyClass;

namespace RentACarOskar
{
    public partial class FormaIzdavanje : MetroFramework.Forms.MetroForm
    {
        int FakturaID;
        DataGridView dgvRacun;


        public FormaIzdavanje(int fakturaID, string tipFakture)
        {
            Font font = new Font("Arial", 9);

            InitializeComponent();
            
            Text = "";
            Size = new Size(600, 600);
            btnStampaj.Location = new Point(480, 550);
            btnDodajVozilo.Location = new Point(30, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            //Kreiranje labela 
            #region Label
            Label naziv = new Label();
            naziv.Text = "Rent A Car Oskar";
            naziv.Size = new Size(150, 20);
            naziv.Location = new Point(50, 50);
            naziv.Visible = true;
            naziv.Font = new Font("Arial", 12);
            Controls.Add(naziv);

            Label adresa = new Label();
            adresa.Text = "Veljka Mladjenovica bb";
            adresa.Size = new Size(170, 20);
            adresa.Location = new Point(50, 75);
            adresa.Font = font;
            Controls.Add(adresa);

            Label adresa2 = new Label();
            adresa2.Text = "78000, Banja Luka, BiH";
            adresa2.Size = new Size(170, 20);
            adresa2.Location = new Point(50, 95);
            adresa2.Font = font;
            Controls.Add(adresa2);

            Label jib = new Label();
            jib.Text = "JIB: 4002358629267";
            jib.Size = new Size(150, 20);
            jib.Location = new Point(50, 115);
            jib.Font = font;
            Controls.Add(jib);

            Label pib = new Label();
            pib.Text = "PIB: 44002358629267";
            pib.Size = new Size(150, 20);
            pib.Location = new Point(50, 135);
            pib.Font = font;
            Controls.Add(pib);
            
            Label brRacuna = new Label();
            if (tipFakture == "Predracun")
            {
                brRacuna.Text = "Broj predracuna: " + fakturaID.ToString() + "/" + DateTime.Today.Year.ToString();
            }
            else if (tipFakture == "Racun")
            {
                brRacuna.Text = "Broj racuna: " + fakturaID.ToString() + "/" + DateTime.Today.Year.ToString();
            }
            else
                brRacuna.Text = "Broj rezervacije: " + fakturaID.ToString() + "/" + DateTime.Today.Year.ToString();
            brRacuna.Size = new Size(220, 20);
            brRacuna.Location = new Point(210, 170);
            brRacuna.Font = new Font("Arial", 12);
            Controls.Add(brRacuna);
            #endregion

            //ispis klijenta
            #region IspisKlijentaLabel
            List<string> klijent = PronadjiKlijenta(fakturaID);

            Label imePrezime = new Label();
            imePrezime.Text = "Ime i prezime: "+klijent[0] + " " + klijent[1];
            imePrezime.Size = new Size(190, 20);
            imePrezime.Location = new Point(370, 75);
            imePrezime.Font = font;
            Controls.Add(imePrezime);

            Label jmb = new Label();
            jmb.Text = "JMB: "+klijent[2];
            imePrezime.Size = new Size(180, 20);
            jmb.Location = new Point(370, 95);
            jmb.Font = font;
            Controls.Add(jmb);

            Label adresaKlijent = new Label();
            adresaKlijent.Text ="Adresa: "+klijent[3];
            adresaKlijent.Size = new Size(190, 20);
            adresaKlijent.Location = new Point(370, 115);
            adresaKlijent.Font = font;
            Controls.Add(adresaKlijent);
            #endregion


            //ispis artikala
            #region IspisArtiklaLabel
            string QueryKlijent = "EXEC dbo.spVozilaNafakturi @FakturaID";

            SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand(QueryKlijent, conn);

            cmd.Parameters.Add("@FakturaID", SqlDbType.Int);
            cmd.Parameters["@FakturaID"].Value = fakturaID;

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            decimal bezPdv = 0; 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bezPdv += Convert.ToDecimal(dt.Rows[i].ItemArray[3].ToString());
            }

            dgvRacun = new DataGridView();
            dgvRacun.DataSource = dt;
            dgvRacun.Location = new Point(15, 200);
            dgvRacun.Size = new Size(570, 270);
            Controls.Add(dgvRacun);

            Label ukupnobezPDV = new Label();
            ukupnobezPDV.Text = "Ukupno bez PDV-a :" + bezPdv;
            ukupnobezPDV.Location = new Point(390, 475);
            ukupnobezPDV.Size = new Size(220, 20);
            Controls.Add(ukupnobezPDV);

            Label ukupnoPDV = new Label();
            ukupnoPDV.Text = "Iznos PDV-a: " + (bezPdv * (decimal)0.17).ToString("F");
            ukupnoPDV.Location = new Point(390, 495);
            ukupnoPDV.Size = new Size(220, 20);
            Controls.Add(ukupnoPDV);

            Label ukupno = new Label();
            ukupno.Text = "Ukupno za platiti: " + (bezPdv * (decimal)1.17).ToString("F");
            ukupno.Location = new Point(390, 515);
            ukupno.Size = new Size(220, 20);
            Controls.Add(ukupno);
            FakturaID = fakturaID;
            #endregion

            dgvRacun.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn vozilo =
                new DataGridViewTextBoxColumn();
            vozilo.HeaderText = "Vozilo";
            vozilo.MinimumWidth = 50;
            vozilo.FillWeight = 100;

        }
        #region PronadjiKlijenta
        private List<string> PronadjiKlijenta(int fakturaID)
        {
            string QueryKlijent = "EXEC spKlijentRacun @FakturaID";

            SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand(QueryKlijent, conn);

            cmd.Parameters.Add("@FakturaID", SqlDbType.Int);
            cmd.Parameters["@FakturaID"].Value = fakturaID;

            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);

            List<string> klijent = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    klijent.Add(dt.Rows[i].ItemArray[j].ToString());
                }
            }
            return klijent;
        }
        #endregion

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            DodajVoziloNaFakturu dodajVozilo = new DodajVoziloNaFakturu(FakturaID);
            dodajVozilo.ShowDialog();
        }
    }
}
