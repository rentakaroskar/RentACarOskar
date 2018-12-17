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

namespace RentACarOskar
{
    public partial class LookUpForma : MetroFramework.Forms.MetroForm
    {
        PropertyInterface myProperty;
        public string Key;
        public string Value;

        public LookUpForma()
        {
            InitializeComponent();
        }
        public LookUpForma(PropertyInterface property)
        {
            InitializeComponent();
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

            //izvuci display name
            var type = myProperty.GetType();
            var properties = type.GetProperties();


            //promjeniti nazive kolona
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
                                      ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;

                /*foreach (PropertyInfo prop in properties)
                {
                    if(item.HeaderText.Equals(prop.GetCustomAttributes<SqlName>().FirstOrDefault().name))
                        item.HeaderText = prop.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
                }*/
            }


        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            string columnName = properties.Where(x => x.GetCustomAttribute <LookupKeyAttribute> () != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Key = row.Cells[columnName].Value.ToString();

            columnName = properties.Where(x => x.GetCustomAttribute<LookupValueAttribute>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Value = row.Cells[columnName].Value.ToString();

            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Visible = false;
            //InputForma pom = new InputForma(myProperty, StateEnum.Create);
            //pom.ShowDialog();
            //Visible = true;
            CRUDfunkcije crud = new CRUDfunkcije();
            crud.Insert(myProperty);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CRUDfunkcije crud = new CRUDfunkcije();
            //crud.Update(myProperty,dgv);
            //treba dodati f-ju koja refresuje data grid view
            //int red = dgv.SelectedRows[0].Index;
            //var type = myProperty.GetType();
            //var properties = type.GetProperties();
            //PropertyInterface pom = myProperty;
            //PopulateGrid(myProperty);
            //myProperty = pom;
            //Visible = false;
            //int i = 0;
            //foreach (DataGridViewCell cell in dgv.Rows[red].Cells)
            //{
            //   String value = cell.Value.ToString();

            //    PropertyInfo property = properties.Where(x => dgv.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
            //    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
            //    i++;
            //}
            //InputForma inputForma = new InputForma(myProperty, StateEnum.Update);
            //inputForma.ShowDialog();
            //Visible = true;
            //PopulateGrid(myProperty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //treba dodati f-ju koja refresuje data grid view
            try
            {
                var type = myProperty.GetType();
                var properties = type.GetProperties();

                PropertyInfo property = properties.Where(x => x.IsDefined(typeof(PrimaryKeyAttribute))).FirstOrDefault();
                property.SetValue(myProperty, Convert.ChangeType(dgv.SelectedRows[0].Cells[0].Value, property.PropertyType));

                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, myProperty.GetDeleteQuery(), myProperty.GetDeleteParameters().ToArray());
                //PopulateGrid(myProperty);
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                MessageBox.Show("Nemoguce je obrisati ovaj red zbog povezanosti sa drugim tabelama!!!\n\nError code: " + sql.Message,
                    "Greska pri brisanju", MessageBoxButtons.OK);
            }
        }
    }
}
