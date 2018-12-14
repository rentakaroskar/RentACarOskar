using KonekcijaNaBazu;
using RentACarOskar.Attributes;
using RentACarOskar.IspisDGV;
using RentACarOskar.PropertyClass;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RentACarOskar
{
    public partial class Dashboard : Form
    {
        PropertyInterface myProperty;
        DataTable dt;
        DataGridView dgv;
        public Dashboard()
        {
        
            InitializeComponent();
            PanelLeft.BackColor = Color.Red;

            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);
        }

        private void PopulateGrid(PropertyInterface property)
        {
            myProperty = property;
            panelPanelZaGV.Controls.Clear();
             dt = new DataTable();
             dgv = new DataGridView();
            panelPanelZaGV.Controls.Add(dgv);
            dgv.Size = panelPanelZaGV.Size;
            
            //logika za popunjavanje tabele
            
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                property.GetSelectQuery());

            dt.Load(reader);
            reader.Close();

            dgv.DataSource = dt; //prikazi tabelu

            //izvuci display name
            var type = property.GetType();
            var properties = type.GetProperties();

            //promijeniti nazive kolona
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
                ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
            }
            
            //sortiranje
            if (property.GetType() == typeof(VoziloIspis))
            {
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
            }
        }
        private void refreshGrid()
        {
            DataGridView dgv = new DataGridView();DataTable dataTable = new DataTable();
            SqlDataReader dataReader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text, myProperty.GetSelectQuery());

            dataTable.Load(dataReader);
            dataReader.Close();
            dgv.DataSource = dataTable;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PanelLeft.Width == 245)
            {
                PanelLeft.Width = 40;
                logoPic.Visible = false;
                slicica1.Visible = true;
                slicica2.Visible = true;
                slicica3.Visible = true;
                btnVozilo.Visible = false;
                btnRadnik.Visible = false;
                btnFaktura.Visible = false;
                loptica.Visible = true;

            }
            else
            {
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                slicica1.Visible = false;
                slicica2.Visible = false;
                slicica3.Visible = false;
                btnVozilo.Visible = true;
                btnRadnik.Visible = true;
                btnFaktura.Visible = true;
                loptica.Visible = false;
            }
        }

        private void btnVozilo_Click(object sender, EventArgs e)
        {
            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);
        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            PropertyRadnik pom = new PropertyRadnik();
            PopulateGrid(pom);
        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);
        }

        private void slicica1_Click(object sender, EventArgs e)
        {
            PanelLeft.Width = 245;
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
            loptica.Visible = false;
        }
        private void slicica2_Click(object sender, EventArgs e)
        {
            PanelLeft.Width = 245;
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
            loptica.Visible = false;
        }
        private void slicica3_Click(object sender, EventArgs e)
        {
            PanelLeft.Width = 245;
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
            loptica.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InputForma pom = new InputForma(myProperty, StateEnum.Create);
            pom.ShowDialog();
        }
    }
}
