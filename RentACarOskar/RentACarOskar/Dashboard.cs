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

        /*Objekat koji ce sluziti za popunjavanje user kontrola u input formi zato sto ce se u 
        DGV ispisivati procedure koje je marko sastavio a mi saljemo InputFormi pravu property klasu*/
        PropertyInterface myForm;
        DataTable dt;
        DataGridView dgv;
        public Dashboard()
        {
            InitializeComponent();
            PanelLeft.BackColor = Color.Red;

            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);

            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
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
            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
            
            //Pom za Input formu
            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            PropertyRadnik pom = new PropertyRadnik();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyRadnik pomInput = new PropertyRadnik();
            myForm = pomInput;
        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyFaktura pomInput = new PropertyFaktura();
            myForm = pomInput;
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
            InputForma pom = new InputForma(myForm, StateEnum.Create);
            pom.ShowDialog();
            PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int red = dgv.SelectedRows[0].Index;
            var type = myForm.GetType();
            var properties = type.GetProperties();
            PopulateGrid(myForm);
            dgv.Visible = false;
            int i = 0;
            foreach (DataGridViewCell cell in dgv.Rows[red].Cells)
            {
                String value = cell.Value.ToString();

                PropertyInfo property = properties.Where(x => dgv.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                property.SetValue(myForm, Convert.ChangeType(value, property.PropertyType));
                i++;
            }

            InputForma inputForma = new InputForma(myForm, StateEnum.Update);
            inputForma.ShowDialog();
            PopulateGrid(myForm);
        }
    }
}
