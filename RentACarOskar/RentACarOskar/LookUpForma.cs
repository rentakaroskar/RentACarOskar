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

            dgStandardGrid.DataSource = dt;

            //izvuci display name
            var type = myProperty.GetType();
            var properties = type.GetProperties();


            //promjeniti nazive kolona
            foreach (DataGridViewColumn item in dgStandardGrid.Columns)
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
            DataGridViewRow row = dgStandardGrid.SelectedRows[0];
            var properties = myProperty.GetType().GetProperties();

            string columnName = properties.Where(x => x.GetCustomAttribute <LookupKeyAttribute> () != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Key = row.Cells[columnName].Value.ToString();

            columnName = properties.Where(x => x.GetCustomAttribute<LookupValueAttribute>() != null)
                .FirstOrDefault().GetCustomAttribute<SqlNameAttribute>().Name;

            Value = row.Cells[columnName].Value.ToString();

            this.Close();
        }


    }
}
