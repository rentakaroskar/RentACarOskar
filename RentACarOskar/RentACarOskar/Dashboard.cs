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

namespace RentACarOskar
{

    public partial class Dashboard : Form
    {
        PropertyInterface myProperty;
        DataTable dt;
        Bunifu.Framework.UI.BunifuCustomDataGrid dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();




        public Dashboard()
        {
        
            InitializeComponent();
            PanelLeft.BackColor = Color.Red;

            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
        }

        private void PopulateGrid(PropertyInterface property)
        {
          
          
            myProperty = property;
            panelPanelZaGV.Controls.Clear();
            dt = new DataTable();
            var dgv = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            //pozadina hedera
            dgv.HeaderBgColor = Color.FromArgb(128, 185, 209);    
            panelPanelZaGV.Controls.Add(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;

            dgv.Size = panelPanelZaGV.Size;
          

            //logika za popunjavanje tabele

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.GetConnectionString(), CommandType.Text,
            property.GetSelectQuery());

            dt.Load(reader);
            reader.Close();
            
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
                
                PanelLeft.Width = 40;
                logoPic.Visible = false;
                slicica1.Visible = true;
                slicica2.Visible = true;
                slicica3.Visible = true;
                btnVozilo.Visible = false;
                btnRadnik.Visible = false;
                btnFaktura.Visible = false;
                panelPanelZaGV.Width = 1115;
                dgv.Size = panelPanelZaGV.Size;


            }
            else
            {               
                PanelLeft.Width = 245;
                logoPic.Visible = true;
                slicica1.Visible = false;
                slicica2.Visible = false;
                slicica3.Visible = false;
                btnVozilo.Visible = true;
                btnRadnik.Visible = true;
                btnFaktura.Visible = true;
                panelPanelZaGV.Width = 906;
                dgv.Size = panelPanelZaGV.Size;


            }
        }

        private void btnVozilo_Click(object sender, EventArgs e)
        {
            PropertyVozilo pom = new PropertyVozilo();
            PopulateGrid(pom);
        }

        private void btnRadnik_Click(object sender, EventArgs e)
        {
            PropertyRadnik pom = new PropertyRadnik();
            PopulateGrid(pom);
        }

        private void btnFaktura_Click(object sender, EventArgs e)
        {
            FakturaIspis pom = new FakturaIspis();
            PopulateGrid(pom);
        }

        private void slicica1_Click(object sender, EventArgs e)
        {
            
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
        }
        private void slicica2_Click(object sender, EventArgs e)
        {
            
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
        }
        private void slicica3_Click(object sender, EventArgs e)
        {
            
            logoPic.Visible = true;
            slicica1.Visible = false;
            slicica2.Visible = false;
            slicica3.Visible = false;
            btnVozilo.Visible = true;
            btnRadnik.Visible = true;
            btnFaktura.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
