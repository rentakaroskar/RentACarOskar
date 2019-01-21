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
using MetroFramework.Controls;

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

        //Objekat klase CRUD gdje se nalaze sve metode za CRUD operacije
        CRUDfunkcije crud = new CRUDfunkcije();

        DataTable dt;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();

        string UserMail;
        string UserID;
        //Role Admin/User
        string Rola;

        public Dashboard(string mail, string ID, string rola)
        {
            InitializeComponent();
            //Loading timer
            timer1.Start();
            loader.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();

            //MeniZaDashboard meni = new MeniZaDashboard();
            //panelMeni.Controls.Add(meni);
            panelMeni.Visible = false;
            this.StartPosition = FormStartPosition.CenterParent;
            
            panel4.Visible = true;

            //Prilikom logina cuvamo informacije ko se prijavio na aplikaciju
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

            panelPanelZaGV.Visible = true;
            //panelCentar.Visible = false;
            panelSaTabelom.Visible = false;
            
            btnIzdaj.Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //me.BackColor = Color.Transparent;
            splash.Visible = true;
            panelPanelZaGV.Visible = true;
            bDelete.Visible = false;
            VoziloIspis pom = new VoziloIspis();
           // MeniZaDashboard dashboard = new MeniZaDashboard();
           //panel2.Controls.Add(dashboard);
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

        //Ucitavanje zadate Property klase iz foldera IspisDGV
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

            //Poziv metode za dizajniranje DGV-a
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
        //Menu item Vozilo
        private void btnVozilo_Click(object sender, EventArgs e)
        {
            //Klasa koja se prikazuje u DGV
            VoziloIspis pom = new VoziloIspis();
            PopulateGrid(pom);

            //Pomocna klasa za Input formu preko koje se rade sve CRUD funkcije
            PropertyVozilo pomInput = new PropertyVozilo();
            myForm = pomInput;

            //Sakrivanje i prikazivanje dugmica i prikaza za zadatu tabelu
            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;
            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = false;
            btnCijena.Visible = true;

            //Filter popunjavanje
            FilterProperty = new VoziloIspis();
            PopuniFilterPanel();

            BgColor(panelAutomobili);

        }

        private void btnKlijent_Click(object sender, EventArgs e)
        {
            //Klasa koja se prikazuje u DGV
            KlijentIspis pom = new KlijentIspis();
            PopulateGrid(pom);

            //Pomocna klasa za Input formu preko koje se rade sve CRUD funkcije
            PropertyKlijent pomInput = new PropertyKlijent();
            myForm = pomInput;

            //Sakrivanje i prikazivanje dugmica i prikaza za zadatu tabelu
            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;
            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = false;
            btnCijena.Visible = false;

            //Filter popunjavanje
            FilterProperty = new KlijentIspis();
            PopuniFilterPanel();

            BgColor(panelKlijenti);

        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            //Klasa koja se prikazuje u DGV
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);

            //Pomocna klasa za Input formu preko koje se rade sve CRUD funkcije
            PropertyFaktura pomInput = new PropertyFaktura();
            myForm = pomInput;

            //Sakrivanje i prikazivanje dugmica i prikaza za zadatu tabelu
            panelPanelZaGV.Visible = true;
            bDelete.Visible = false;
            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = true;
            btnCijena.Visible = false;

            //Filter popunjavanje
            FilterProperty = new FakturaIspis();
            PopuniFilterPanel();

            BgColor(panelFaktura);
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            //Klasa koja se prikazuje u DGV
            RadnikIspis pom = new RadnikIspis();

            FilterProperty = new RadnikIspis();

            //Pomocna klasa za Input formu preko koje se rade sve CRUD funkcije
            PropertyRadnik pomInput = new PropertyRadnik();
            myForm = pomInput;

            //Sakrivanje i prikazivanje dugmica i prikaza za zadatu tabelu
            panelPanelZaGV.Visible = true;
            bDelete.Visible = true;
            //panelCentar.Visible = true;
            panelSaTabelom.Visible = true;
            btnIzdaj.Visible = false;
            btnCijena.Visible = false;

            //Filter popunjavanje
            PopulateGrid(pom);
            PopuniFilterPanel();

            BgColor(panelZaposleni);
        }
        //private void panelHome_Paint(object sender, PaintEventArgs e)
        //{
        //    BgColor(panelHome);
        //}
        private void panelHome_MouseClick(object sender, MouseEventArgs e)
        {
            BgColor(panelHome);

        }



        #endregion

        #region CRUDButtons

        //Insert operacija
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Metoda za upisivanje Mail-a i ID korisnika
            crud.UserMail(UserMail, UserID);

            //Pozivanje metode INSERT za zadatu Property klasu
            crud.Insert(myForm);

            //Popunjavanje DGV-a nakon zavrsene metode INSERT
            PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;

            //Kupljenje ID vrijednosti iz DGV selektovanog reda
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();

            //Popunjavanje DGV-a sa property klasom
            PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;

            //Metoda za upisivanje Mail-a i ID korisnika
            crud.UserMail(UserMail, UserID);

            //Pozivanje metode UPDATE za zadatu Property klasu, selektovani ID i dgv sa popunjenim podacima prave property klase
            crud.Update(myForm, ID, dgv);
            //Visible = true;

            //Popunjavanje DGV-a nakon zavrsene metode UPDATE
            PopulateGrid(myProperty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Iskakanje MessageBox-a za potvrdu brisanja selektovanog reda u DGV
            DialogResult myResult = MetroMessageBox.Show(this, "Do you really want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (myResult == DialogResult.Yes)
            {
                int SelektovaniRed = dgv.SelectedRows[0].Index;

                //Metoda za upisivanje Mail-a i ID korisnika
                crud.UserMail(UserMail, UserID);

                //Pozivanje metode DELETE za zadatu Property klasu i selektovani red u DGV
                crud.Delete(myForm, SelektovaniRed, dgv);

                //Popunjavanje DGV-a nakon zavrsene metode DELETE
                PopulateGrid(myProperty);
            }
        }

        private void btnCijena_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;

            //Kupljenje ID vozila iz DGV selektovanog reda
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();

            //Kreiranje objekta PropertyCijena i popunjavanje tabele sa cijenama
            PropertyCijena cijenaTabela = new PropertyCijena();
            myForm = cijenaTabela;
            PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;

            //Metoda za upisivanje Mail-a i ID korisnika
            crud.UserMail(UserMail, UserID);

            //Pozivanje metode UPDATE sa PropertyCijena, selektovani ID i dgv sa popunjenim podacima cijena
            crud.Update(myForm, ID, dgv);
            // Visible = true;

            //Popunjavanje DGV-a nakon zavrsene metode UPDATE
            PopulateGrid(myProperty);
        }
        #endregion

        #region Filter

        private void PopuniFilterPanel()
        {
            pnlFilter1.Controls.Clear();
            if (FilterProperty.GetType() == typeof(FakturaIspis))
            {
                Label lblOd = new Label();
                //Label lblOd = new Label();
                lblOd.Text = "Od:";
                lblOd.Width = 30;
                pnlFilter1.Controls.Add(lblOd);
               
                DateTimePicker dtpOd = new DateTimePicker();
                dtpOd.Format = DateTimePickerFormat.Custom;
                dtpOd.Value = new DateTime(2018, 01, 01);
                dtpOd.CustomFormat = "dd.MM.yyyy";
                dtpOd.Width = 170;
                pnlFilter1.Controls.Add(dtpOd);
                pnlFilter1.SetFlowBreak(dtpOd, true);

                //filter

                //Label lblDo = new Label();
                Label lblDo = new Label();
                lblDo.Text = "Do:";
                lblDo.Width = 30;
                pnlFilter1.Controls.Add(lblDo);
                
                DateTimePicker dtpDo = new DateTimePicker();
                dtpDo.Format = DateTimePickerFormat.Custom;
                dtpDo.CustomFormat = "dd.MM.yyyy";
                dtpDo.Width = 170;
                pnlFilter1.Controls.Add(dtpDo);
                pnlFilter1.SetFlowBreak(dtpDo, true);

                Label lblTip = new Label();
                lblTip.Text = "Tip Fakture:";
                lblTip.Width = 50;
                pnlFilter1.Controls.Add(lblTip);
                ComboBox cbxTip = new ComboBox();
                cbxTip.Items.Add("Racun");
                cbxTip.Items.Add("Predracun");
                cbxTip.Items.Add("Rezervacija");
                cbxTip.Items.Add("Sve");
                pnlFilter1.Controls.Add(cbxTip);
                pnlFilter1.SetFlowBreak(cbxTip, true);

                Label lblKlijent = new Label();
                lblKlijent.Text = "Klijent:";
                lblKlijent.Width = 50;
                pnlFilter1.Controls.Add(lblKlijent);
                TextBox txtKlijent = new TextBox();
                pnlFilter1.Controls.Add(txtKlijent);
                pnlFilter1.SetFlowBreak(txtKlijent, true);


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

            else if (FilterProperty.GetType() == typeof(KlijentIspis))
            {
                Label lblIme = new Label();
                lblIme.Text = "Ime:";
                lblIme.Width = 50;
                pnlFilter1.Controls.Add(lblIme);
                TextBox txtIme = new TextBox();
                pnlFilter1.Controls.Add(txtIme);
                pnlFilter1.SetFlowBreak(txtIme, true);

                Label lblPrezime = new Label();
                lblPrezime.Text = "Prezime:";
                lblPrezime.Width = 50;
                pnlFilter1.Controls.Add(lblPrezime);
                TextBox txtPrezime = new TextBox();
                txtPrezime.Location = new Point(60, 31);
                pnlFilter1.Controls.Add(txtPrezime);
                pnlFilter1.SetFlowBreak(txtPrezime, true);

                Label lblTip = new Label();
                lblTip.Text = "Tip:";
                lblTip.Width = 50;
                pnlFilter1.Controls.Add(lblTip);
                ComboBox cbxTip = new ComboBox();
                cbxTip.Items.Add("Vratio");
                cbxTip.Items.Add("Preuzeo");
                cbxTip.Items.Add("Rezervisao");
                cbxTip.Items.Add("Sve");
                pnlFilter1.Controls.Add(cbxTip);
                pnlFilter1.SetFlowBreak(cbxTip, true);



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
                Label lblProizvodjac = new Label();
                lblProizvodjac.Text = "Proizvodjac:";
                pnlFilter1.Controls.Add(lblProizvodjac);
                TextBox txtProizvodjac = new TextBox();
                pnlFilter1.Controls.Add(txtProizvodjac);
                pnlFilter1.SetFlowBreak(txtProizvodjac, true);
              
                Label lblModel = new Label();
                lblModel.Text = "Model:";
                pnlFilter1.Controls.Add(lblModel);
                TextBox txtModel = new TextBox();
                pnlFilter1.Controls.Add(txtModel);
                pnlFilter1.SetFlowBreak(txtModel, true);

                Label lblBoja = new Label();
                lblBoja.Text = "Boja:";
                pnlFilter1.Controls.Add(lblBoja);
                TextBox txtBoja = new TextBox();
                pnlFilter1.Controls.Add(txtBoja);
                pnlFilter1.SetFlowBreak(txtBoja, true);

                Label lblDostupnost = new Label();
                lblDostupnost.Text = "Dostupnost:";
                pnlFilter1.Controls.Add(lblDostupnost);
                ComboBox cmbDostupnost = new ComboBox();
                cmbDostupnost.Items.Add("Zauzet");
                cmbDostupnost.Items.Add("Slobodan");
                cmbDostupnost.Items.Add("Rezervisano");
                pnlFilter1.Controls.Add(cmbDostupnost);



                txtProizvodjac.TextChanged += new EventHandler(Filter);
                txtModel.TextChanged += new EventHandler(Filter);
                txtBoja.TextChanged += new EventHandler(Filter);
                cmbDostupnost.SelectedIndexChanged += new EventHandler(Filter);

                void Filter(object sender, EventArgs e)
                {
                    string Query = @"EXEC dbo.spFilterVozila @Proizvodjac, @Model, @Boja, @Dostupnost";
                    SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString());
                    SqlCommand comm = new SqlCommand(Query, conn);

                    comm.Parameters.Add(new SqlParameter("@Proizvodjac", SqlDbType.NVarChar));
                    comm.Parameters["@Proizvodjac"].Value = txtProizvodjac.Text.ToString();
                    comm.Parameters["@Proizvodjac"].IsNullable = true;

                    comm.Parameters.Add(new SqlParameter("@Model", SqlDbType.NVarChar));
                    comm.Parameters["@Model"].Value = txtModel.Text.ToString();
                    comm.Parameters["@Model"].IsNullable = true;

                    comm.Parameters.Add(new SqlParameter("@Boja", SqlDbType.NVarChar));
                    comm.Parameters["@Boja"].Value = txtBoja.Text.ToString();
                    comm.Parameters["@Boja"].IsNullable = true;

                    comm.Parameters.Add(new SqlParameter("@Dostupnost", SqlDbType.NVarChar));
                    if (cmbDostupnost.SelectedIndex >= 0)
                        comm.Parameters["@Dostupnost"].Value = cmbDostupnost.Items[cmbDostupnost.SelectedIndex].ToString();
                    else comm.Parameters["@Dostupnost"].Value = DBNull.Value;
                    comm.Parameters["@Dostupnost"].IsNullable = true;
                    

                    dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    adapter.Fill(dt);
                    PopuniDGV(dt, FilterProperty);
                }
            }

            else if (FilterProperty.GetType() == typeof(RadnikIspis))
            {
                Label lblIme = new Label();
                lblIme.Text = "Ime:";
                pnlFilter1.Controls.Add(lblIme);
                TextBox txtIme = new TextBox();
                pnlFilter1.Controls.Add(txtIme);
                pnlFilter1.SetFlowBreak(txtIme, true);

                Label lblPrezime = new Label();
                lblPrezime.Text = "Prezime:";
                pnlFilter1.Controls.Add(lblPrezime);
                TextBox txtPrezime = new TextBox();
                pnlFilter1.Controls.Add(txtPrezime);
                pnlFilter1.SetFlowBreak(txtPrezime, true);

                Label lblPozicija = new Label();
                lblPozicija.Text = "Pozicija:";
                pnlFilter1.Controls.Add(lblPozicija);
                TextBox txtPozicija = new TextBox();
                pnlFilter1.Controls.Add(txtPozicija);
                pnlFilter1.SetFlowBreak(txtPozicija, true);

                txtIme.TextChanged += new EventHandler(Filter);
                txtPrezime.TextChanged += new EventHandler(Filter);
                txtPozicija.TextChanged += new EventHandler(Filter);

                void Filter(object sender, EventArgs e)
                {
                    string Query = @"EXEC dbo.spFilterZaposleni @Ime, @Prezime, @Pozicija";
                    SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString());
                    SqlCommand comm = new SqlCommand(Query, conn);

                    comm.Parameters.Add(new SqlParameter("@Ime", SqlDbType.NVarChar));
                    comm.Parameters["@Ime"].Value = txtIme.Text.ToString();
                    comm.Parameters["@Ime"].IsNullable = true;

                    comm.Parameters.Add(new SqlParameter("@Prezime", SqlDbType.NVarChar));
                    comm.Parameters["@Prezime"].Value = txtPrezime.Text.ToString();
                    comm.Parameters["@Prezime"].IsNullable = true;

                    comm.Parameters.Add(new SqlParameter("@Pozicija", SqlDbType.NVarChar));
                    comm.Parameters["@Pozicija"].Value = txtPozicija.Text.ToString();
                    comm.Parameters["@Pozicija"].IsNullable = true;



                    dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    adapter.Fill(dt);
                    PopuniDGV(dt, FilterProperty);
                }
            }
        }
        #endregion

        #region OtherButtons
        private void btnIzdaj_Click(object sender, EventArgs e)
        {
            int idFakture = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value.ToString());
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

        private void detaljiVozila_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();
            PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije("detalji");
            crud.UserMail(UserMail, UserID);
            crud.Update(myForm, ID, dgv);
            // Visible = true;
            PopulateGrid(myProperty);
        }
        #endregion

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
            if (panelAutomobili.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelAutomobili.BackColor = Color.FromArgb(20, 255, 255, 255);
            slicicaAuto.BackColor = Color.Transparent;
            lblAutomobili.BackColor = Color.Transparent;
        }

        private void panelAutomobili_MouseLeave(object sender, EventArgs e)
        {
            if (panelAutomobili.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelAutomobili.BackColor = Color.Transparent;
            slicicaAuto.BackColor = Color.Transparent;
            lblAutomobili.BackColor = Color.Transparent;
           

        }
       

        //PanelKlijenti animacija
        private void panelKlijenti_MouseHover(object sender, EventArgs e)
        {
            if (panelKlijenti.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelKlijenti.BackColor = Color.FromArgb(20, 255, 255, 255);
            slicicaPeople.BackColor = Color.Transparent;
            lblKlijenti.BackColor = Color.Transparent;
           
        }

        private void panelKlijenti_MouseLeave(object sender, EventArgs e)
        {
            if (panelKlijenti.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelKlijenti.BackColor = Color.Transparent;
            slicicaPeople.BackColor = Color.Transparent;
            lblKlijenti.BackColor = Color.Transparent;
           
        }

        //PanelFaktura animacija
        private void panelFaktura_MouseHover(object sender, EventArgs e)
        {
            if (panelFaktura.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelFaktura.BackColor = Color.FromArgb(20, 255, 255, 255);
            btnFaktura.BackColor = Color.Transparent;
            lblFaktura.BackColor = Color.Transparent;
        }

        private void panelFaktura_MouseLeave(object sender, EventArgs e)
        {
            if(panelFaktura.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelFaktura.BackColor = Color.Transparent;
            btnFaktura.BackColor = Color.Transparent;
            lblFaktura.BackColor = Color.Transparent;
       
        }
        //panel home animacija
        private void panelHome_MouseHover(object sender, EventArgs e)
        {
            if (panelHome.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelHome.BackColor = Color.FromArgb(20, 255, 255, 255);
            imgHome.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
        }
        private void panelHome_MouseLeave(object sender, EventArgs e)
        {
            if (panelHome.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelHome.BackColor = Color.Transparent;
            imgHome.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
        }
        //panel zaposleni animacija
        private void btnZaposleni_MouseHover(object sender, EventArgs e)
        {
            if (panelZaposleni.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelZaposleni.BackColor = Color.FromArgb(20, 255, 255, 255);
            imgZaposleni.BackColor = Color.Transparent;
            lblZaposleni.BackColor = Color.Transparent;
        }
        private void panelZaposleni_MouseLeave(object sender, EventArgs e)
        {
            if (panelZaposleni.BackColor == Color.FromArgb(20, 255, 255, 254))
            {
                return;
            }
            panelZaposleni.BackColor = Color.Transparent;
            imgZaposleni.BackColor = Color.Transparent;
            lblZaposleni.BackColor = Color.Transparent;
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
            lblLogOut1.BackColor = Color.Transparent;
        }
        //f-ja ostaje cekirna boja na btn koji je kliknut
        public void BgColor(Panel sender)
        {
            panelZaposleni.BackColor = Color.Transparent;
            panelFaktura.BackColor = Color.Transparent;
            panelKlijenti.BackColor = Color.Transparent;
            panelAutomobili.BackColor = Color.Transparent;
            panelHome.BackColor = Color.Transparent;


            sender.BackColor = Color.FromArgb(20, 255, 255, 254);
            //sender.BackColor = Color.Red;

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

                bunifuCards1.Width = 345;
                bunifuCards2.Width = bunifuCards1.Width;
                panelFilter.Width = bunifuCards1.Width;
                panelZaBunifuKartice.Width = panelPanelZaGV.Width;
            }
            else
            {
                bunifuCards1.Width = 289;
                bunifuCards2.Width = bunifuCards1.Width;
                panelFilter.Width = bunifuCards1.Width;
               

                PanelLeft.Width = 245;
                logoPic.Visible = true;
                loptica.Visible = false;

                panelPanelZaGV.Width = 906;
                dgv.Size = panelPanelZaGV.Size;
                panelSaTabelom.Width = panelPanelZaGV.Width;
                panelZaBunifuKartice.Width = panelPanelZaGV.Width;



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
            // PopuniFilterPanel();
            MeniZaDashboard meni = new MeniZaDashboard();
            
        }

        private void loader_Tick(object sender, EventArgs e)
        {
            loader.Start();
            if (bunifuCircleProgressbar1.Value < 100)
            {
                bunifuCircleProgressbar1.Value += 10;
            }
            else
            {
                splash.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void splash_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
