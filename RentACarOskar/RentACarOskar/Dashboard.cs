﻿using KonekcijaNaBazu;
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
using RentACarOskar.CRUD;


namespace RentACarOskar
{
    public partial class Dashboard : Form
    {
        PropertyInterface myProperty;
        string UserMail;

        //filter
        PropertyInterface FilterProperty;
        DataTable dt;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

        /*Objekat koji ce sluziti za popunjavanje user kontrola u input formi zato sto ce se u 
        DGV ispisivati procedure koje je marko sastavio a mi saljemo InputFormi pravu property klasu*/
        PropertyInterface myForm;
        public Dashboard(string mail)
        {
            
            InitializeComponent();
            this.UserMail = mail;
            userLabel.Text = UserMail;
            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);
            //CRUDfunkcije crud = new CRUDfunkcije();
            //crud.PopulateGrid(pom, panelPanelZaGV);

            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
            panelCentar.Visible = false;
            btnIzdaj.Visible = false;

            FilterProperty = new VoziloIspis();
        }

        //Popunjavanje DataGridView-a sa procedurom koju je Marko sastavio
        private void PopulateGrid(PropertyInterface property)
        {//MARKO PREBACI U CRUD FOLDER
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
        {//MARKO PREBACI U CRUD FOLDER

            panelPanelZaGV.Controls.Clear();

             dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

            //pozadina hedera
            dgv.BackgroundColor = Color.White;
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
            btnInsert.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            Dobrodosli.Visible = false;
            panelCentar.Visible = true;
            btnIzdaj.Visible = false;
            //Filter 
            FilterProperty = new VoziloIspis();
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
            panelCentar.Visible = true;
            btnIzdaj.Visible = false;


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
            panelPanelZaGV.Visible = true;
            btnInsert.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;

            Dobrodosli.Visible = false;

            panelCentar.Visible = true;
            btnIzdaj.Visible = true;
            //Filter 
            FilterProperty = new FakturaIspis();
        }
        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            panelPanelZaGV.Visible = false;
            btnInsert.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

        
        #region CRUDButtons
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Visible = false;
            //InputForma pom = new InputForma(myForm, StateEnum.Create);
            //pom.ShowDialog();
            //Visible = true;
            //PopulateGrid(myProperty);
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.Insert(myForm);
            PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region staraF-ja    
            //var type = myForm.GetType();
            // int red = dgv.SelectedRows[0].Index;
            //var properties = type.GetProperties();
            //PropertyInterface pom = myProperty;
            //PopulateGrid(myForm);
            //myProperty = pom;
            //Visible = false;
            //int i = 0;
            //foreach (DataGridViewCell cell in dgv.Rows[red].Cells)
            //{
            //    String value = cell.Value.ToString();

            //    PropertyInfo property = properties.Where(x => dgv.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
            //    property.SetValue(myForm, Convert.ChangeType(value, property.PropertyType));
            //    i++;
            //}
            //InputForma inputForma = new InputForma(myForm, StateEnum.Update);
            //inputForma.ShowDialog();
            //var type = myForm.GetType();
            //var properties = type.GetProperties();
            //PropertyInterface pom = myForm;
            #endregion

            int SelektovaniRed = Convert.ToInt32(dgv.SelectedRows[0].Index);
            PropertyInterface pom = myProperty;
            PopulateGrid(myForm);
            myProperty = pom;
            Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.Update(myForm, dgv,SelektovaniRed);
            Visible = true;
            PopulateGrid(myProperty);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var type = myForm.GetType();
            //    var properties = type.GetProperties();

            //    PropertyInfo property = properties.Where(x => x.IsDefined(typeof(PrimaryKeyAttribute))).FirstOrDefault();
            //    property.SetValue(myForm, Convert.ChangeType(dgv.SelectedRows[0].Cells[0].Value, property.PropertyType));

            //    SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, myForm.GetDeleteQuery(), myForm.GetDeleteParameters().ToArray());
            //    PopulateGrid(myProperty);
            //}
            //catch (System.Data.SqlClient.SqlException sql)
            //{
            //    MessageBox.Show("Nemoguce je obrisati ovaj red zbog povezanosti sa drugim tabelama!!!\n\nError code: " + sql.Message,
            //        "Greska pri brisanju", MessageBoxButtons.OK);
            //}
            int SelektovaniRed = dgv.SelectedRows[0].Index;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.Delete(myForm,SelektovaniRed,dgv);

        }
        #endregion

        private void panelAutomobili_MouseHover(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(44, 46, 62);

        }
        private void panelKlijenti_MouseHover(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelKlijenti_MouseLeave(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(44, 46, 62);

        }

        private void panelFaktura_MouseHover(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelFaktura_MouseLeave(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(44, 46, 62);

        }

        private void panelLogOut_MouseHover(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.FromArgb(40, 42, 60);
        }

        private void panelLogOut_MouseLeave(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.FromArgb(44, 46, 62);

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
    

    #endregion

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{

        //    InputForma pom = new InputForma(, StateEnum.Update);
        //    pom.ShowDialog();
        //}


        private void btnIzdaj_Click(object sender, EventArgs e)
        {

        }
    }
}
