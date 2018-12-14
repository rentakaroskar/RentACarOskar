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

             PropertyVozilo pom = new PropertyVozilo();
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
                PanelLeft.Width = 63;
                logoPic.Visible = false;
                slicicaAuto.Visible = true;
                loptica.Visible = true;

            }
            else
            {
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                loptica.Visible = false;
            }
        }

        private void btnVozilo_Click(object sender, EventArgs e)
        {
            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;

        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            PropertyRadnik pom = new PropertyRadnik();
            PopulateGrid(pom);
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
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

        private void panelAutomobili_MouseHover(object sender, EventArgs e)
        {

        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            panelAutomobili.BackColor =Color.FromArgb(44, 46, 62);
            slicicaAuto.BackColor = Color.FromArgb(44, 46, 62);

            PanelLeft.Width = 63;
            logoPic.Visible = false;
            loptica.Visible = true;
        }

        private void panelKlijenti_MouseHover(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(40, 42, 60);
            slicicaPeople.BackColor = Color.FromArgb(40, 42, 60);

            if (PanelLeft.Width == 63)
            {
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                loptica.Visible = false;
            }
        }

        private void panelKlijenti_MouseLeave(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(44, 46, 62);
            slicicaPeople.BackColor = Color.FromArgb(44, 46, 62);

            PanelLeft.Width = 63;
            logoPic.Visible = false;
            loptica.Visible = true;
        }

        private void btnFaktura_MouseLeave(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(44, 46, 62);
            btnFaktura.BackColor = Color.FromArgb(44, 46, 62);

            PanelLeft.Width = 63;
            logoPic.Visible = false;
            loptica.Visible = true;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panelPanelZaGV.Visible = false;
            btnInsert.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

        private void panelMenu_MouseHover(object sender, EventArgs e)
        {

        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            PanelLeft.Width = 63;
            logoPic.Visible = false;
            loptica.Visible = true;
        }
    }
}
