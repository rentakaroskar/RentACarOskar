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
            panelCentar.Visible = false;
            Dobrodosli.Visible = true;
            btnIzdaj.Visible = false;

        }

        //Popunjavanje DataGridView-a sa procedurom koju je Marko sastavio
        private void PopulateGrid(PropertyInterface property)
        {
            myProperty = property;
            panelPanelZaGV.Controls.Clear();
            dt = new DataTable();
            dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            dgv.BackgroundColor = Color.White;
            //pozadina hedera
            dgv.HeaderBgColor = Color.FromArgb(44, 46, 62);
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
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 46, 62);
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
                panelPanelZaGV.Width = 1090;
                dgv.Size = panelPanelZaGV.Size;

            }
            else
            {
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                loptica.Visible = false;
                panelPanelZaGV.Width = 906;
                dgv.Size = panelPanelZaGV.Size;
            }
        }

        #region MenuButtons
        private void btnVozilo_Click(object sender, EventArgs e)
        {
            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;
            Dobrodosli.Visible = false;
            panelCentar.Visible = true;

        }

        private void btnKlijent_Click(object sender, EventArgs e)
        {
            PropertyKlijent pom = new PropertyKlijent();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyKlijent pomInput = new PropertyKlijent();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;

            Dobrodosli.Visible = false;
            panelCentar.Visible = true;

        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyFaktura pomInput = new PropertyFaktura();
            myForm = pomInput;
            panelPanelZaGV.Visible = true;
            bDelete.Visible = false;

            Dobrodosli.Visible = false;

            panelCentar.Visible = true;

            btnIzdaj.Visible = true;

        }
        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

       
        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            panelPanelZaGV.Visible = false;
            bDelete.Visible = false;
        }

        
        #region CRUDButtons
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var type = myForm.GetType();
                var properties = type.GetProperties();

                PropertyInfo property = properties.Where(x => x.IsDefined(typeof(PrimaryKeyAttribute))).FirstOrDefault();
                property.SetValue(myForm, Convert.ChangeType(dgv.SelectedRows[0].Cells[0].Value, property.PropertyType));

                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, myForm.GetDeleteQuery(), myForm.GetDeleteParameters().ToArray());
                PopulateGrid(myProperty);
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                MessageBox.Show("Nemoguce je obrisati ovaj red zbog povezanosti sa drugim tabelama!!!",
                    "Greska pri brisanju", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void panelAutomobili_MouseHover(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(40, 42, 60);
            slicicaAuto.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(44, 46, 62);
            slicicaAuto.BackColor = Color.FromArgb(44, 46, 62);

        }
        private void panelKlijenti_MouseHover(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(40, 42, 60);
            slicicaPeople.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelKlijenti_MouseLeave(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(44, 46, 62);
            slicicaPeople.BackColor = Color.FromArgb(44, 46, 62);


        }

        private void panelFaktura_MouseHover(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(40, 42, 60);
            btnFaktura.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelFaktura_MouseLeave(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(44, 46, 62);
            btnFaktura.BackColor = Color.FromArgb(44, 46, 62);

        }

        private void panelLogOut_MouseHover(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.FromArgb(40, 42, 60);
            btnLogOut.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelLogOut_MouseLeave(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.FromArgb(44, 46, 62);
            btnLogOut.BackColor = Color.FromArgb(44, 46, 62);

        }

        private void btnIzdaj_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnInsert_MouseHover(object sender, EventArgs e)
        {
            btnInsert.ForeColor = Color.White;
        }

        private void btnInsert_MouseLeave(object sender, EventArgs e)
        {
            btnInsert.ForeColor = Color.FromArgb(44, 46, 62);
            
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.White;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.FromArgb(44, 46, 62);

        }

        private void bDelete_MouseHover(object sender, EventArgs e)
        {
            bDelete.ForeColor = Color.White;
        }
        private void bDelete_MouseLeave(object sender, EventArgs e)
        {
            bDelete.ForeColor = Color.FromArgb(44, 46, 62);

        }

        private void btnIzdaj_MouseHover(object sender, EventArgs e)
        {
            btnIzdaj.ForeColor = Color.White;
        }
        private void btnIzdaj_MouseLeave(object sender, EventArgs e)
        {
            btnIzdaj.ForeColor = Color.FromArgb(44, 46, 62);

        }

        

    }
}
