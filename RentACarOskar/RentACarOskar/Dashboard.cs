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
using RentACarOskar.CRUD;
using MetroFramework;
using System.Collections.Generic;
using RentACarOskar.UserControls;



namespace RentACarOskar
{

    public partial class Dashboard : Form
    {
        /*Objekat koji ce sluziti za popunjavanje user kontrola u input formi zato sto ce se u 
        DGV ispisivati procedure koje je marko sastavio a mi saljemo InputFormi pravu property klasu*/
        PropertyInterface myForm;

        //Property interface za procedure
        PropertyInterface myProperty;
        
        //fProperty interface za filter
        PropertyInterface FilterProperty;

        DataTable dt;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

        string UserMail;
        string UserID;
        //Role Admin/User
        string Rola;
        
        public Dashboard(string mail, string ID,string rola)
        {
            InitializeComponent();
            timer1.Start();
            loader.Start();

            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
            //MeniZaDashboard meni = new MeniZaDashboard();
            //panelMeni.Controls.Add(meni);
            panelMeni.Visible = false;
            this.StartPosition = FormStartPosition.CenterParent;
           

            panel4.Visible = true;
            UserID = ID;
            UserMail = mail;
            labelUser.Text = mail;
            Rola = rola;

            if (Rola == "Admin")
            {
                panelZaposleni.Visible = true;
            }
            else
            {
                panelZaposleni.Visible = false;
            }

            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);

            FilterProperty = new VoziloIspis();

            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;
            
            panelPanelZaGV.Visible = true;
            //panelCentar.Visible = false;
            panelSaTabelom.Visible = false;


            btnIzdaj.Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            panelPanelZaGV.Visible = true;
            bDelete.Visible = false;
            VoziloIspis pom = new VoziloIspis();
          

        }

        //f-ja za datum i vrijeme
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        #region PopunjavanjeDGV-a
        //Popunjavanje DataGridView-a sa procedurom koju je Marko sastavio
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
            //Ciscenje panela za refresh
            panelPanelZaGV.Controls.Clear();

            //Restart DGV-a
            dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

            //pozadina hedera
        panelPanelZaGV.Controls.Add(dgv);

            //Popunjavanje tabele sa vrijednostima
            dgv.DataSource = dt;

            DGVDizajn();

            //izvuci display name
            var type = property.GetType();
            var properties = type.GetProperties();

            //promijeniti nazive kolona
            if (property.GetType() != typeof(VoziloIspis))
            {
                foreach (DataGridViewColumn item in dgv.Columns)
                {
                    item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
                    ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
                }
            }

            //sakrij ID
            if (property.GetType() == typeof(VoziloIspis)
                || property.GetType() == typeof(PropertyKlijent))
            {
                dgv.Columns[0].Visible = false;
            }
            
        }
        #endregion

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

            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = false;
            btnFilter.Visible = true;

            //Filter 
            FilterProperty = new VoziloIspis();
        }

        private void btnKlijent_Click(object sender, EventArgs e)
        {
            //Za popunjavanje DT-Klijent
            KlijentIspis pom = new KlijentIspis();
            PopulateGrid(pom);

            //Pom za Input formu
            PropertyKlijent pomInput = new PropertyKlijent();
            myForm = pomInput;

            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;

            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = false;
            btnFilter.Visible = true;

            FilterProperty = new KlijentIspis();
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
            btnFilter.Visible = true;

            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = true;

            //Filter 
            FilterProperty = new FakturaIspis();
        }
        #endregion
        
        #region CRUDButtons
        private void btnInsert_Click(object sender, EventArgs e)
        {
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Insert(myForm);
            PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();
            PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Update(myForm, ID, dgv);
           // Visible = true;
            PopulateGrid(myProperty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MetroMessageBox.Show(this, "Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (myResult == DialogResult.Yes)
            {
                int SelektovaniRed = dgv.SelectedRows[0].Index;
                CRUDfunkcije crud = new CRUDfunkcije();
                crud.UserMail(UserMail, UserID);
                crud.Delete(myForm, SelektovaniRed, dgv);
                PopulateGrid(myProperty);
            }
            else
            {
                //No delete
            }
        }
        #endregion

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
                dtpOd.Value = new DateTime(2018, 01, 01);
                dtpOd.CustomFormat = "dd.MM.yyyy";
                dtpOd.Location = new Point(35, 1);
                dtpOd.Width = 170;
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
                dtpDo.Width = 170;
                panelFilter.Controls.Add(dtpDo);

                Label lblTip = new Label();
                lblTip.Text = "Tip Fakture:";
                lblTip.Location = new Point(1, 61);
                lblTip.Width = 50;
                panelFilter.Controls.Add(lblTip);
                ComboBox cbxTip = new ComboBox();
                cbxTip.Items.Add("Racun");
                cbxTip.Items.Add("Predracun");
                cbxTip.Items.Add("Rezervacija");
                cbxTip.Items.Add("Sve");
                cbxTip.Location = new Point(60, 61);
                panelFilter.Controls.Add(cbxTip);

                Label lblKlijent = new Label();
                lblKlijent.Text = "Klijent:";
                lblKlijent.Location = new Point(1, 31);
                lblKlijent.Width = 50;
                panelFilter.Controls.Add(lblKlijent);
                TextBox txtKlijent = new TextBox();
                txtKlijent.Location = new Point(60, 31);
                panelFilter.Controls.Add(txtKlijent);


                cbxTip.SelectedIndexChanged += new EventHandler(f_ValueChanged);
                txtKlijent.TextChanged += new EventHandler(f_ValueChanged);
                dtpOd.ValueChanged += new EventHandler(f_ValueChanged);
                dtpDo.ValueChanged += new EventHandler(f_ValueChanged);

                dtpOd.MaxDate = dtpDo.Value;
                dtpDo.MinDate = dtpOd.Value;

                void f_ValueChanged(object sender, EventArgs e)
                {
                    dtpOd.MaxDate = dtpDo.Value;
                    dtpDo.MinDate = dtpOd.Value;

                    string QueryFilter = "exec [dbo].[spFilterFakutra] @PocetniDatum, @KrajniDatum, @Klijent, @TipFakture";

                    SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());

                    SqlCommand Cmd = new SqlCommand(QueryFilter, con);

                    Cmd.Parameters.Add(new SqlParameter("@PocetniDatum", SqlDbType.DateTime));
                    Cmd.Parameters.Add(new SqlParameter("@KrajniDatum", SqlDbType.DateTime));
                    Cmd.Parameters.Add(new SqlParameter("@Klijent", SqlDbType.NVarChar));
                    Cmd.Parameters.Add(new SqlParameter("@TipFakture", SqlDbType.NVarChar));

                    Cmd.Parameters["@PocetniDatum"].Value = dtpOd.Value.ToLongDateString();
                    Cmd.Parameters["@PocetniDatum"].IsNullable = true;
                    Cmd.Parameters["@KrajniDatum"].Value = dtpDo.Value.ToLongDateString();
                    Cmd.Parameters["@KrajniDatum"].IsNullable = true;
                    Cmd.Parameters["@Klijent"].Value = txtKlijent.Text;
                    Cmd.Parameters["@Klijent"].IsNullable = true;
                    if (cbxTip.SelectedIndex >= 0)
                        Cmd.Parameters["@TipFakture"].Value = cbxTip.Items[cbxTip.SelectedIndex].ToString();
                    else
                        Cmd.Parameters["@TipFakture"].Value = "Sve";
                    Cmd.Parameters["@TipFakture"].IsNullable = true;

                    dt = new DataTable();

                    //logika za popunjavanje tabele
                    SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                    adapter.Fill(dt);
                    PopuniDGV(dt, FilterProperty);
                }
            }

            else if(FilterProperty.GetType() == typeof(KlijentIspis))
            {
                Label lblIme = new Label();
                lblIme.Text = "Ime:";
                lblIme.Location = new Point(1, 1);
                lblIme.Width = 50;
                panelFilter.Controls.Add(lblIme);
                TextBox txtIme = new TextBox();
                txtIme.Location = new Point(60, 1);
                panelFilter.Controls.Add(txtIme);

                Label lblPrezime = new Label();
                lblPrezime.Text = "Prezime:";
                lblPrezime.Location = new Point(1, 31);
                lblPrezime.Width = 50;
                panelFilter.Controls.Add(lblPrezime);
                TextBox txtPrezime = new TextBox();
                txtPrezime.Location = new Point(60, 31);
                panelFilter.Controls.Add(txtPrezime);

                Label lblTip = new Label();
                lblTip.Text = "Tip:";
                lblTip.Location = new Point(1, 61);
                lblTip.Width = 50;
                panelFilter.Controls.Add(lblTip);
                ComboBox cbxTip = new ComboBox();
                cbxTip.Items.Add("Vratio");
                cbxTip.Items.Add("Preuzeo");
                cbxTip.Items.Add("Rezervisao");
                cbxTip.Items.Add("Sve");
                cbxTip.Location = new Point(60, 61);
                panelFilter.Controls.Add(cbxTip);



                txtIme.TextChanged += new EventHandler(v_ValueChanged);
                txtPrezime.TextChanged += new EventHandler(v_ValueChanged);
                cbxTip.SelectedIndexChanged += new EventHandler(v_ValueChanged);

                void v_ValueChanged(object sender, EventArgs e)
                {
                    string QueryFilter = @"exec dbo.spFilterKlijenata
                                          @Ime,
                                          @Prezime,
                                          @TipFaktureID";
                    SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());
                    SqlCommand Cmd = new SqlCommand(QueryFilter, con);

                    Cmd.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar));
                    Cmd.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar));
                    Cmd.Parameters.Add(new SqlParameter("@TipFaktureID", SqlDbType.Int));

                    Cmd.Parameters["@Ime"].Value = txtIme.Text;
                    Cmd.Parameters["@Ime"].IsNullable = true;
                    Cmd.Parameters["@Prezime"].Value = txtPrezime.Text;
                    Cmd.Parameters["@Prezime"].IsNullable = true;
                    if (cbxTip.SelectedIndex != 0 && cbxTip.SelectedIndex != 1 && cbxTip.SelectedIndex != 2)
                        Cmd.Parameters["@TipFaktureID"].Value = DBNull.Value;
                    else
                    Cmd.Parameters["@TipFaktureID"].Value = cbxTip.SelectedIndex + 1;
                    Cmd.Parameters["@TipFaktureID"].IsNullable = true;

                    dt = new DataTable();

                    //logika za popunjavanje tabele
                    SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
                    adapter.Fill(dt);
                    PopuniDGV(dt, FilterProperty);
                }
            }
            else if (FilterProperty.GetType() == typeof(VoziloIspis))
            {

            }

        }
        #endregion
        
        private void btnIzdaj_Click(object sender, EventArgs e)
        {
             int idFakture= Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value.ToString());
            string tipFakture = dgv.SelectedRows[0].Cells[4].Value.ToString();

            FormaIzdavanje formaIzdavanje = new FormaIzdavanje(idFakture, tipFakture);
            formaIzdavanje.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
           
            DialogResult myResult;
            myResult = MetroMessageBox.Show(this, "Da li zelite napustiti App?", "Question Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (myResult == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                //No delete
            }
           
        }

        #region Animacije
        //ButtonInsert animacija
        private void btnInsert_MouseHover(object sender, EventArgs e)
        {
            btnInsert.ForeColor = Color.White;
        }

        private void btnInsert_MouseLeave(object sender, EventArgs e)
        {
            btnInsert.ForeColor = Color.FromArgb(44, 46, 62);
        }

        //ButtonUpdate animacija
        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.White;
            return;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.ForeColor = Color.FromArgb(44, 46, 62);
            return;
        }

        //ButtonDelete animacija
        private void bDelete_MouseHover(object sender, EventArgs e)
        {
            bDelete.ForeColor = Color.White;
        }

        private void bDelete_MouseLeave(object sender, EventArgs e)
        {
            bDelete.ForeColor = Color.FromArgb(44, 46, 62);
        }

        //ButtonIzdaj animacija
        private void btnIzdaj_MouseHover(object sender, EventArgs e)
        {
            btnIzdaj.ForeColor = Color.White;
        }

        private void btnIzdaj_MouseLeave(object sender, EventArgs e)
        {
            btnIzdaj.ForeColor = Color.FromArgb(44, 46, 62);
        }

        //PanelAutomobili animacija
        private void panelAutomobili_MouseHover(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.FromArgb(20, 255, 255, 255);
            slicicaAuto.BackColor = Color.Transparent;
            lblAutomobili.BackColor = Color.Transparent;
        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            panelAutomobili.BackColor = Color.Transparent;
            slicicaAuto.BackColor = Color.Transparent;
            lblAutomobili.BackColor = Color.Transparent;
        }

        //PanelKlijenti animacija
        private void panelKlijenti_MouseHover(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.FromArgb(20, 255, 255, 255);
            slicicaPeople.BackColor = Color.Transparent;
            lblKlijenti.BackColor = Color.Transparent;
        }

        private void panelKlijenti_MouseLeave(object sender, EventArgs e)
        {
            panelKlijenti.BackColor = Color.Transparent;
            slicicaPeople.BackColor = Color.Transparent;
            lblKlijenti.BackColor = Color.Transparent;

        }

        //PanelFaktura animacija
        private void panelFaktura_MouseHover(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.FromArgb(20, 255, 255, 255);
            btnFaktura.BackColor = Color.Transparent;
            lblFaktura.BackColor= Color.Transparent;
        }

        private void panelFaktura_MouseLeave(object sender, EventArgs e)
        {
            panelFaktura.BackColor = Color.Transparent;
            btnFaktura.BackColor = Color.Transparent;
            lblFaktura.BackColor= Color.Transparent;
        }

        //PanelLogOut animacija
        private void panelLogOut_MouseHover(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.FromArgb(20, 255, 255, 255);
            btnLogOut.BackColor = Color.Transparent;
            lblLogOut1.BackColor = Color.Transparent;
        }

        private void panelLogOut_MouseLeave(object sender, EventArgs e)
        {
            panelLogOut.BackColor = Color.Transparent;
            btnLogOut.BackColor = Color.Transparent;
            lblLogOut1.BackColor= Color.Transparent;
        }
        #endregion

        #region Dizajn
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (PanelLeft.Width == 245)
            {
                PanelLeft.Width = 63;
                logoPic.Visible = false;
                slicicaAuto.Visible = true;
                loptica.Visible = true;
                panelPanelZaGV.Width = 1090;
                dgv.Size = panelPanelZaGV.Size;
                panelSaTabelom.Width = panelPanelZaGV.Width;
            }
            else
            {
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                loptica.Visible = false;

                panelPanelZaGV.Width = 906;
                dgv.Size = panelPanelZaGV.Size;
                panelSaTabelom.Width = panelPanelZaGV.Width;
            }
        }

        private void DGVDizajn()
        {
            dgv.BackgroundColor = Color.White;
            dgv.HeaderBgColor = Color.CadetBlue;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
            dgv.Size = panelPanelZaGV.Size;

            //Auto size kolona i redova u tabeli
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Boja header teksta u tabeli
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

            //Boja teksta i pozadina kada selektujemo item 
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 46, 62);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            //This code allows the user to edit the information in the DataGrid.
            //***********************************************
            dt.DefaultView.AllowEdit = false;
            dt.DefaultView.AllowDelete = false;
            dt.DefaultView.AllowNew = false;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            panelSaTabelom.Visible = false;
        }

        private void detaljiVozila_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();
            PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Update(myForm, ID, dgv);
            // Visible = true;
            PopulateGrid(myProperty);
        }

        private void loader_Tick(object sender, EventArgs e)
        {
            loader.Start();
            if (bunifuCircleProgressbar1.Value < 100)
            {
                bunifuCircleProgressbar1.Value+=5;
            }
            else
            {
                splash.Visible = false;
            }
           
        }
    }

}
