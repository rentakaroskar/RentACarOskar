﻿using Microsoft.Reporting.WinForms;
using RentACarOskar.PropertyClass;
using System;
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
    public partial class Izvjestaj : Form
    {
        public Izvjestaj(PropertyInterface property)
        {
            InitializeComponent();
            if (property.GetType() == typeof(PropertyVozilo))
            {
                rvIzvjestaj.ServerReport.ReportPath = "/Report_RentACarOscar/izvjestajVozila";
            }
            else if (property.GetType() == typeof(PropertyKlijent))
            {
                rvIzvjestaj.ServerReport.ReportPath = "/Report_RentACarOscar/izvjestajKlijenti";
            }
            else if (property.GetType() == typeof(PropertyRadnik))
            {
                rvIzvjestaj.ServerReport.ReportPath = "/Report_RentACarOscar/izvjestajZaposleni";
            }
            else if (property.GetType() == typeof(PropertyFaktura))
            {
                rvIzvjestaj.ServerReport.ReportPath = "/Report_RentACarOscar/izvjestajSvihFaktura";
            }
        }

        public Izvjestaj(string ID)
        {
            InitializeComponent();
            ReportParameter[] parametri = new ReportParameter[1];
            parametri[0] = new ReportParameter("FakturaID", ID);

            rvIzvjestaj.ServerReport.ReportPath = "/Report_RentACarOscar/izvjestajFaktura";
            rvIzvjestaj.ServerReport.SetParameters(parametri);

        }

        private void Izvjestaj_Load(object sender, EventArgs e)
        {

            this.rvIzvjestaj.RefreshReport();
        }
    }
}
