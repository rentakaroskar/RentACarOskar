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

namespace RentACarOskar
{
    public partial class DodajVoziloNaFakturu : Form
    {
        DataGridView dgv = new DataGridView();
        int fakturaID;
        public DodajVoziloNaFakturu()
        {
            InitializeComponent();

        }
        public DodajVoziloNaFakturu(int FakturaID):this()
        {
            fakturaID = FakturaID;
            popunidgv();
        }

        private void popunidgv()
        {
            dgv = new DataGridView();
            dgv.Location = new Point(5, 5);
            Controls.Add(dgv);

            string query = @"select * from dbo.vDodajVoziloNaFakturu";
            SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
        }


    }
}
