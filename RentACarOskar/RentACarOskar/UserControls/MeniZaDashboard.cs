﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonekcijaNaBazu;

namespace RentACarOskar.UserControls
{
    public partial class MeniZaDashboard : UserControl
    {
        public MeniZaDashboard()
        {
            InitializeComponent();
            timer1.Start();

            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
            string query = @"SELECT COUNT(v.VoziloID)
                                FROM dbo.Vozilo v";

            int x = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text, query);

            brVozila.Text = x.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void brVozila_Click(object sender, EventArgs e)
        {

        }
    }
}
