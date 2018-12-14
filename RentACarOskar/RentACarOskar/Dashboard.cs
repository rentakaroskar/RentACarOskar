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
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();





        /*Objekat koji ce sluziti za popunjavanje user kontrola u input formi zato sto ce se u 
        DGV ispisivati procedure koje je marko sastavio a mi saljemo InputFormi pravu property klasu*/
        PropertyInterface myForm;
        public Dashboard()
        {
            InitializeComponent();

            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);

            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
        }

        private void PopulateGrid(PropertyInterface property)
        {


            myProperty = property;
            panelPanelZaGV.Controls.Clear();
            dt = new DataTable();
            dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            //pozadina hedera
            dgv.HeaderBgColor = Color.FromArgb(128, 185, 209);
            panelPanelZaGV.Controls.Add(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;

            dgv.Size = panelPanelZaGV.Size;


            //logika za popunjavanje tabele

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
            property.GetSelectQuery());

            dt.Load(reader);
            reader.Close();

            dgv.DataSource = dt; //prikazi tabelu

            //Auto size kolona i redova u tabeli
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //boja header teksta u tabeli
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            //boja teksta i pozadina kada selektujemo item 
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 139, 87);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            //This code allows the user to edit the information in the DataGrid.
            //***********************************************
            dt.DefaultView.AllowEdit = false;
            dt.DefaultView.AllowDelete = false;
            dt.DefaultView.AllowNew = false;
            //*

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
            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            Dobrodosli.Visible = false;

        }

        private void btnKlijent_Click(object sender, EventArgs e)
        {
            PropertyKlijent pom = new PropertyKlijent();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyKlijent pomInput = new PropertyKlijent();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;

            Dobrodosli.Visible = false;
        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyFaktura pomInput = new PropertyFaktura();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;

            Dobrodosli.Visible = false;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelAutomobili_MouseHover(object sender, EventArgs e)
        {

        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(44, 46, 62);
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
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Visible = false;
            InputForma pom = new InputForma(myForm, StateEnum.Create);
            pom.ShowDialog();
            Visible = true;
            PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int red = dgv.SelectedRows[0].Index;
            var type = myForm.GetType();
            var properties = type.GetProperties();
            PropertyInterface pom = myProperty;
            PopulateGrid(myForm);
            myProperty = pom;
            Visible = false;
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
            Visible = true;
            PopulateGrid(myProperty);
        }
    }
}
