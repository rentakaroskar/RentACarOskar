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

namespace RentACarOskar.CRUD
{
    public class CRUDfunkcije
    {
        PropertyInterface myProperty;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
        string UserEmail;
        string UserID;

        //NA LOOKUP FORMI TREBA PROMIJENITTI IZGLED TABELE U 
        //Bunifu.Framework.UI.BunifuCustomDataGrid dgv DA BI RADILE CRUD OPERACIJE

        public void UserMail(string mail, string ID)
        {
            UserEmail = mail;
            UserID = ID;
        }

        public void Insert(PropertyInterface myProperty)
        {
            this.myProperty = myProperty;
            InputForma pom = new InputForma(myProperty, StateEnum.Create, UserEmail, UserID);
            pom.ShowDialog();
            pom.Close();
        }

        public void Update(PropertyInterface myProperty, string ID, Bunifu.Framework.UI.BunifuCustomDataGrid dgv)
        {
            //Pretraga
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                    myProperty.GetSelectQueryZaJedanItem(ID));

            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();

            dgv.DataSource = dt;

            var type = myProperty.GetType();
            var properties = type.GetProperties();
            PropertyInterface pom = myProperty;
            int i = 0;
            try
            {
                foreach (DataGridViewCell cell in dgv.Rows[0].Cells)
                {
                    String value = cell.Value.ToString();

                    PropertyInfo property = properties.Where(x => dgv.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                    property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                    i++;
                }
            }
            catch { }

            InputForma inputForma = new InputForma(myProperty, StateEnum.Update, UserEmail, UserID);

            inputForma.ShowDialog();

            if (inputForma.DialogResult == DialogResult.Cancel)
                return;
        }

        public void Delete(PropertyInterface myProperty, int SelektovaniRed, Bunifu.Framework.UI.BunifuCustomDataGrid dgv)
        {
            try
            {                            
                DataGridViewRow row = dgv.SelectedRows[0];
                var properties = myProperty.GetType().GetProperties();

                foreach (PropertyInfo item in properties)
                {
                    if (item.GetCustomAttribute<PrimaryKeyAttribute>() != null)
                    {
                        string value = row.Cells[item.GetCustomAttribute<SqlNameAttribute>().Name]
                            .Value.ToString();

                        item.SetValue(myProperty, Convert.ChangeType(value, item.PropertyType));
                    }
                }

                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                      myProperty.GetDeleteQuery(), myProperty.GetDeleteParameters().ToArray());
                CRUD.IstorijaCRUD.Istorija(UserEmail, StateEnum.Delete, myProperty);
                //PopulateGrid(myProperty);
            }
            catch (System.Data.SqlClient.SqlException)
            { 
                  MessageBox.Show("\n\nNemoguce je obrisati ovaj red zbog povezanosti sa drugim tabelama!!!\n\n", "Greska pri brisanju!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}