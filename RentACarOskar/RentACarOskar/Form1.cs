﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarOskar
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {

            InitializeComponent();
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Dashboard02 nova = new Dashboard02();
            nova.ShowDialog();
        }
    }
}
