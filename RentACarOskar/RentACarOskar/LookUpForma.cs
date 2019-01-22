using KonekcijaNaBazu;
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
using System.Reflection;
using RentACarOskar.Attributes;
using RentACarOskar.CRUD;
using MetroFramework;
using RentACarOskar.PropertyClass;
using RentACarOskar.IspisDGV;

namespace RentACarOskar
{
    public partial class LookUpForma : MetroFramework.Forms.MetroForm
    {
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
        PropertyInterface myProperty;

        public string Key;
        public string Value;
        public string Value2;

        public string UserMail;
        public string UserID;

        public LookUpForma(PropertyInterface property, string mail, string ID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            UserMail = mail;
            UserID = ID;
            myProperty = property;
            PopulateGrid();
            if (property.GetType() != typeof(PropertyTipFakture))
            {
                btnDelete.Visible = true;
                btnInsert.Visible = true;
                btnUpdate.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnInsert.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        //Popunjavanje Data Table
        #region PopunjavanjeDataTable
        private void PopulateGrid()
        {
            panelPanelZaGV.Controls.Clear();
            DataTable dt = new DataTable();

            //logika za popunjavanje datatable

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetSelectQuery());


            if (myProperty.GetType() == typeof(PropertyOsoba))
            {
                PropertyOsoba pom = myProperty as PropertyOsoba;
                reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
               pom.GetSelectQueryRadnik());
            }

            if (myProperty.GetType() == typeof(PropertyKlijent))
            {
                PropertyKlijent pom = myProperty as PropertyKlijent;
                reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                pom.GetSelectQueryZaFakturu());
            }

            dt.Load(reader);
            reader.Close();

            dgv.DataSource = dt;
            dgv.BackgroundColor = Color.White;
            dgv.HeaderBgColor = Color.CadetBlue;
            panelPanelZaGV.Controls.Add(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
            dgv.Size = panelPanelZaGV.Size;

            //izvuci display name
            var type = myProperty.GetType();
            var properties = type.GetProperties();

            try
            {
                //promjeniti nazive kolona
                foreach (DataGridViewColumn item in dgv.Columns)
                {
                    item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>()
                    .FirstOrDefault().Name == item.HeaderText).FirstOrDefault()
                    .GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
                }
            }
            catch { }

            //design
            //boja teksta i pozadina kada selektujemo item 
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 46, 62);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            //boja header teksta u tabeli
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;

        }
        #endregion

        //Najbolja metoda koju je iko ikad napravio
        #region MetodaZaKupljenjePodatakaZaLookUp
        public void LookUpKupljenje(PropertyInfo[] properties, DataGridViewRow row)
        {
            string columnName = properties.Where(x => x.GetCustomAttribute<LookupKeyAttribute>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            //dodan try/catch block by MARKO
            try
            {
                Key = row.Cells[columnName].Value.ToString();
            }
            catch
            { return; }

            columnName = properties.Where(x => x.GetCustomAttribute<LookupValueAttribute>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            if (columnName.Contains("ID"))
            {
                PropertyInterface foreignKeyInterface = Assembly.GetExecutingAssembly().
                        CreateInstance(properties.Where(x => x.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    .FirstOrDefault().GetCustomAttribute<ForeignKeyAttribute>().ClassName)
                        as PropertyInterface;

                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                    foreignKeyInterface.GetLookupQuery(row.Cells[1].Value.ToString()));

                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();

                dgv.DataSource = dt;

                row = dgv.Rows[0];

                Value = row.Cells[0].Value.ToString();

                try
                {
                    Value2 = row.Cells[1].Value.ToString();
                }
                catch { }
            }
            else
            {
                Value = row.Cells[columnName].Value.ToString();

                try
                {
                    columnName = properties.Where(x => x.GetCustomAttribute<LookupValueAttribute>() != null)
                        .LastOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

                    if (columnName.Contains("ID"))
                    {
                        PropertyInterface foreignKeyInterface = Assembly.GetExecutingAssembly().
                                CreateInstance(properties.Where(x => x.GetCustomAttribute<ForeignKeyAttribute>() != null)
                            .FirstOrDefault().GetCustomAttribute<ForeignKeyAttribute>().ClassName)
                                as PropertyInterface;

                        SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                            foreignKeyInterface.GetLookupQuery(row.Cells[2].Value.ToString()));

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        dgv.DataSource = dt;

                        row = dgv.Rows[0];

                        Value2 = row.Cells[0].Value.ToString();

                    }
                    else
                        Value2 = row.Cells[columnName].Value.ToString();
                }
                catch
                {

                }
            }
        }
        #endregion

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int red;
            if (myProperty.GetType() == typeof(PropertyKlijent))
            {
                red = dgv.SelectedRows[0].Index;
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                            myProperty.GetSelectQuery());
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgv.DataSource = dt;

                DataGridViewRow row = dgv.Rows[red];
                var properties = myProperty.GetType().GetProperties();

                LookUpKupljenje(properties, row);
            }
            else
            {
                try
                {
                    DataGridViewRow row = dgv.SelectedRows[0];
                    var properties = myProperty.GetType().GetProperties();

                    LookUpKupljenje(properties, row);
                }
                catch { }
            }
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //add new 

            dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Insert(myProperty);
            PopulateGrid();
            //PopulateGrid(myProperty);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PropertyInterface pom = myProperty;
            string ID = dgv.SelectedRows[0].Cells[0].Value.ToString();
            PopulateGrid();
            myProperty = pom;
            Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Update(myProperty, ID, dgv);

            Visible = true;
            try
            {
                PopulateGrid();
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MetroMessageBox.Show(this, "Do you really want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (myResult == DialogResult.Yes)
            {
                int SelektovaniRed = dgv.SelectedRows[0].Index;
                CRUDfunkcije crud = new CRUDfunkcije();
                crud.UserMail(UserMail, UserID);
                crud.Delete(myProperty, SelektovaniRed, dgv);
                try
                {
                    PopulateGrid();
                }
                catch
                {
                    DialogResult dr = MetroMessageBox.Show(this, "\n\nNemoguce je obrisati ovaj red zbog povezanosti sa drugim tabelama!!!\n\n", "Greska pri brisanju!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //No delete
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}