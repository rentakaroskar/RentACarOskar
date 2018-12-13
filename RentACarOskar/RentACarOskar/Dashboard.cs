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
using RentACarOskar.Attributes;
using System.Reflection;
using RentACarOskar.PropertClass;

namespace RentACarOskar
{
    public partial class Dashboard : Form
    {
        
        public Dashboard()
        {
            InitializeComponent();
            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
        }

        private void PopulateGrid(PropertyInterface myProperty)
        {
            DataTable dt = new DataTable();
            DataGridView dgv = new DataGridView();
            panelPanelZaGV.Controls.Add(dgv);
            dgv.Size = panelPanelZaGV.Size;
            //logika za popunjavanje tabele
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
                myProperty.GetSelectQuery());

            dt.Load(reader);
            reader.Close();

            dgv.DataSource = dt; //prikazi tabelu

            //izvuci display name
            var type = myProperty.GetType();
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
                PanelLeft.Width = 60;
                logoPic.Visible = false;
            }
            else
                PanelLeft.Width = 245;
                logoPic.Visible = true;
        }

        private void btnVozilo_Click(object sender, EventArgs e)
        {
           PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
        }
    }
}
