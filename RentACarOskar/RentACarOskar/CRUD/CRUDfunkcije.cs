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


namespace RentACarOskar.CRUD
{
    public class CRUDfunkcije
    {
        PropertyInterface myProperty;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
        int SelektovaniRed;
        string UserEmail;

        //NA LOOKUP FORMI TREBA PROMIJENITTI IZGLED TABELE U 
        //Bunifu.Framework.UI.BunifuCustomDataGrid dgv DA BI RADILE CRUD OPERACIJE

        public void UserMail(string mail)
        {
            UserEmail = mail;
        }

        public void Insert(PropertyInterface myProperty)
        {
            this.myProperty = myProperty;
            InputForma pom = new InputForma(myProperty, StateEnum.Create,UserEmail);
            pom.ShowDialog();

        }

        public void Update(PropertyInterface myProperty, Bunifu.Framework.UI.BunifuCustomDataGrid dgv, int SelektovaniRed)
        {

            this.SelektovaniRed = SelektovaniRed;
            var type = myProperty.GetType();
            var properties = type.GetProperties();
            PropertyInterface pom = myProperty;
            int i = 0;
            foreach (DataGridViewCell cell in dgv.Rows[SelektovaniRed].Cells)
            {
                String value = cell.Value.ToString();

                PropertyInfo property = properties.Where(x => dgv.Columns[i].HeaderText == x.GetCustomAttribute<DisplayNameAttribute>().DisplayName).FirstOrDefault();
                property.SetValue(myProperty, Convert.ChangeType(value, property.PropertyType));
                i++;
            }
            InputForma inputForma = new InputForma(myProperty, StateEnum.Update, UserEmail);
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
                //SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, this.myProperty.GetDeleteQuery(), this.myProperty.GetDeleteParameters().ToArray());
                //CRUD.IstorijaCRUD.Istorija(UserEmail, StateEnum.Delete, myProperty);
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


        //Popunjavanje DataGridView-a sa procedurom koju je Marko sastavio
       // public void PopulateGrid(PropertyInterface property, Bunifu.Framework.UI.BunifuGradientPanel panelPanelZaGV)
//        {
//            myProperty = property;
//            panelPanelZaGV.Controls.Clear();
//            DataTable dt = new DataTable();
//            Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
//            dgv.BackgroundColor = Color.White;
//            //pozadina hedera
//            dgv.HeaderBgColor = Color.FromArgb(128, 185, 209);
         
//            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//            dgv.MultiSelect = false;
//            dgv.Dock = DockStyle.Fill;
            

//            //logika za popunjavanje tabele

//            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
//            property.GetSelectQuery());

//            dt.Load(reader);
//            reader.Close();

//            panelPanelZaGV.Controls.Add(dgv);
//            dgv.Size = panelPanelZaGV.Size;

//            dgv.DataSource = dt; //prikazi tabelu

         
//            //Auto size kolona i redova u tabeli
//            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
//            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
//            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
//            //boja header teksta u tabeli
//            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
//            //boja teksta i pozadina kada selektujemo item 
//            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 139, 87);
//            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

//            //This code allows the user to edit the information in the DataGrid.
//            //***********************************************
//            dt.DefaultView.AllowEdit = false;
//            dt.DefaultView.AllowDelete = false;
//            dt.DefaultView.AllowNew = false;
//            //*

//            //izvuci display name
//            var type = property.GetType();
//            var properties = type.GetProperties();

           

//            //promijeniti nazive kolona
//            foreach (DataGridViewColumn item in dgv.Columns)
//            {
//                item.HeaderText = properties.Where(x => x.GetCustomAttributes<SqlNameAttribute>().FirstOrDefault().Name == item.HeaderText
//                ).FirstOrDefault().GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName;
//            }

//            //sortiranje
//            //if (property.GetType() == typeof(VoziloIspis))
//            //{
//            //    dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);
//            //}
        
//        }


//    }
//}
