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
    public partial class DodajVoziloNaFakturu : MetroFramework.Forms.MetroForm
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
            pnlDGV.Controls.Clear();
            dgv = new DataGridView();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MouseClick += new MouseEventHandler(dgvrowchange);
            //dgv.Location = new Point(5, 5);
            pnlDGV.Controls.Add(dgv);

            string query = @"select v.CijenaID, v.VoziloID, v.CijenaPoDanu, v.Model, v.Proizvodjac, v.BrojRegistracije
                            from dbo.vDodajVoziloNaFakturu v
                            WHERE v.CijenaID NOT IN (SELECT cf.CijenaID 
		                    FROM dbo.CijenaFaktura cf
		                    WHERE cf.FakturaID =" + fakturaID + ")";
            SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dgv.DataSource = dt;
            dgv.Width = pnlDGV.Width;
            dgv.Height = pnlDGV.Height;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
        }

        private void dgvrowchange(object sender, EventArgs e)
        {
            txtCijenaPoDanu.Text = dgv.SelectedRows[0].Cells[2].Value.ToString();
            txtAuto.Text = dgv.SelectedRows[0].Cells[4].Value.ToString()+" "+ dgv.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            string insert = @"INSERT INTO [dbo].[CijenaFaktura]
                             ([CijenaID]
                             ,[FakturaID]
                             ,[BrojDana])
                                VALUES
                            ("
                            +(dgv.SelectedRows[0].Cells[0].Value.ToString()) +", "
                            +fakturaID + ", "
                            + nupBrojDana.Value
                            +")";
            SqlConnection con = new SqlConnection(SqlHelper.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.ExecuteNonQuery();
            con.Close();
            popunidgv();
        }

        private void DodajVoziloNaFakturu_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
