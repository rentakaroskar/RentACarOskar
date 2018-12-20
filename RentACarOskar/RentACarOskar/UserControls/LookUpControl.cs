using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarOskar.UserControls
{
    public partial class LookUpControl : UserControl
    {

        PropertyInterface myInterface;
        public string Key;
        public string Value;

        public LookUpControl(PropertyInterface interFace)
        {
            InitializeComponent();
            myInterface = interFace;
            tbKey.ReadOnly = true;
            tbNaziv.ReadOnly = true;
        }

        public void SetLabel(string text)
        {
            lblNaziv.Text = text;
            if (text == "Radnik ID")
                btnLookup.Enabled = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LookUpForma sf = new LookUpForma(myInterface);
            sf.ShowDialog();

            //TextBox za ID
            tbKey.Text = sf.Key;

            //TextBox za naziv
            tbNaziv.Text = sf.Value;
            //Dodatak nazivu da se ispise na puno ime i prezime
            if(sf.Value != sf.Value2)
                tbNaziv.Text += " " + sf.Value2;
        }

        public void setInterface(PropertyInterface interf)
        {
            myInterface = interf;
        }

        public void SetValueTextBox(string key, string naziv)
        {
            tbKey.Text = key;
            tbNaziv.Text = naziv;
        }

        public string GetLabelValue()
        {
            return lblNaziv.Text;
        }

        public string GetKeyValue()
        {
            return tbKey.Text;
        }
    }
}
