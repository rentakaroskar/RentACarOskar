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

        //filter
        PropertyInterface FilterProperty;
        DataTable dt;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

        


        /*Objekat koji ce sluziti za popunjavanje user kontrola u input formi zato sto ce se u 
        DGV ispisivati procedure koje je marko sastavio a mi saljemo InputFormi pravu property klasu*/
        PropertyInterface myForm;
        public Dashboard()
        {
            InitializeComponent();
            PanelLeft.BackColor = Color.Red;

            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);
            FilterProperty = new VoziloIspis();
        }

        private void PopulateGrid(PropertyInterface property)
        {
            myProperty = property;
            dt = new DataTable();
            //logika za popunjavanje tabele
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
            property.GetSelectQuery());
            dt.Load(reader);
            reader.Close();
            PopuniDGV(dt, property);
        }

        private void PopuniDGV(DataTable dt, PropertyInterface property)
        {
            panelPanelZaGV.Controls.Clear();

            var dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

            //pozadina hedera
            dgv.HeaderBgColor = Color.FromArgb(128, 185, 209);
            panelPanelZaGV.Controls.Add(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;

            dgv.Size = panelPanelZaGV.Size;

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
        }

        private void refreshGrid()
        {
            DataGridView dgv = new DataGridView(); DataTable dataTable = new DataTable();
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
                panelPanelZaGV.Width = 1115;
                dgv.Size = panelPanelZaGV.Size;

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
                panelPanelZaGV.Width = 906;
                dgv.Size = panelPanelZaGV.Size;


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

            //Filter 
            FilterProperty = new VoziloIspis();
        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            PropertyRadnik pom = new PropertyRadnik();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyRadnik pomInput = new PropertyRadnik();
            myForm = pomInput;

            //Filter 
            FilterProperty = new FakturaIspis();

        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyFaktura pomInput = new PropertyFaktura();
            myForm = pomInput;

            //Filter 
            FilterProperty = new FakturaIspis();
        }

        private void slicica1_Click(object sender, EventArgs e)
        {

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
        }

        #region Filter
        private void btnFilter_Click(object sender, EventArgs e)
        {
            PopuniFilterPanel();
        }

        private void PopuniFilterPanel()
        {
            panelFilter.Controls.Clear();
            if (FilterProperty.GetType() == typeof(FakturaIspis))
            {
                Label lblOd = new Label();
                lblOd.Text = "Od:";
                lblOd.Location = new Point(1, 1);
                lblOd.Width = 30;
                panelFilter.Controls.Add(lblOd);
                DateTimePicker dtpOd = new DateTimePicker();
                dtpOd.Format = DateTimePickerFormat.Custom;
                dtpOd.CustomFormat = "dd.MM.yyyy";
                dtpOd.Location = new Point(35, 1);
                dtpOd.Width = 190;
                panelFilter.Controls.Add(dtpOd);

                //filter

                Label lblDo = new Label();
                lblDo.Text = "Do:";
                lblDo.Location = new Point(230, 1);
                lblDo.Width = 30;
                panelFilter.Controls.Add(lblDo);
                DateTimePicker dtpDo = new DateTimePicker();
                dtpDo.Format = DateTimePickerFormat.Custom;
                dtpDo.CustomFormat = "dd.MM.yyyy";
                dtpDo.Location = new Point(265, 1);
                dtpDo.Width = 190;
                panelFilter.Controls.Add(dtpDo);

                dtpOd.ValueChanged += new EventHandler(f_ValueChanged);
                dtpDo.ValueChanged += new EventHandler(f_ValueChanged);


                void f_ValueChanged(object sender, EventArgs e)
                {
                    string QueryFilter = "exec [dbo].[spFilterFakutra] @PocetniDatum, @KrajniDatum";

                    SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());

                    SqlCommand Cmd = new SqlCommand(QueryFilter, con);

                    Cmd.Parameters.Add(new SqlParameter("@PocetniDatum", SqlDbType.DateTime));
                    Cmd.Parameters.Add(new SqlParameter("@KrajniDatum", SqlDbType.DateTime));

                    Cmd.Parameters["@PocetniDatum"].Value = dtpOd.Value.ToLongDateString();
                    Cmd.Parameters["@PocetniDatum"].IsNullable = true;
                    Cmd.Parameters["@KrajniDatum"].Value = dtpDo.Value.ToLongDateString();
                    Cmd.Parameters["@KrajniDatum"].IsNullable = true;
                    
                    dt = new DataTable();

                    //logika za popunjavanje tabele
                    SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                    adapter.Fill(dt);
                    PopuniDGV(dt, FilterProperty);
                }
            }

        }
    }

    #endregion

    //private void btnUpdate_Click(object sender, EventArgs e)
    //{

    //    InputForma pom = new InputForma(, StateEnum.Update);
    //    pom.ShowDialog();
    //}
}

