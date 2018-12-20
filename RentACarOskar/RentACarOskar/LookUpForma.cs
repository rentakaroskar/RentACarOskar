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

        public LookUpForma()
        {
            InitializeComponent();
        }
        public LookUpForma(PropertyInterface property, string mail, string ID)
        {
            InitializeComponent();
            UserMail = mail;
            UserID = ID;
            myProperty = property;
            PopulateGrid();
        }        
        private void PopulateGrid()
        {
            DataTable dt = new DataTable();

            //logika za popunjavanje datatable
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetSelectQuery());

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

            //promjeniti nazive kolona
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>()
                .FirstOrDefault().Name == item.HeaderText).FirstOrDefault()
                .GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            LookUpKupljenje(properties, row);

            this.Close();
        }

        //Najbolja metoda koju je iko ikad napravio
        public void LookUpKupljenje(PropertyInfo[] properties, DataGridViewRow row)
        {
            string columnName = properties.Where(x => x.GetCustomAttribute<LookupKeyAttribute>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Key = row.Cells[columnName].Value.ToString();

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

                Value2 = row.Cells[1].Value.ToString();
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
            int SelektovaniRed = dgv.SelectedRows[0].Index;
            PropertyInterface pom = myProperty;
            PopulateGrid();
            //PopulateGrid(myForm);
            myProperty = pom;
            //Visible = false;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.UserMail(UserMail, UserID);
            crud.Update(myProperty, dgv, SelektovaniRed);
            PopulateGrid();
            //Visible = true;
            //PopulateGrid(myProperty);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {          
            DialogResult myResult = MetroMessageBox.Show(this, "Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (myResult == DialogResult.Yes)
            {
                int SelektovaniRed = dgv.SelectedRows[0].Index;
                CRUDfunkcije crud = new CRUDfunkcije();
                crud.UserMail(UserMail, UserID);
                crud.Delete(myProperty, SelektovaniRed, dgv);
                PopulateGrid();
            }
            else
            {
                //No delete
            }
        }
    }
}
