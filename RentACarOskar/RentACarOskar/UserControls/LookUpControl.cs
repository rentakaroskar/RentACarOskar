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
        }

        public void SetLabel(string text)
        {
            lblNaziv.Text = text;
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            LookUpForma sf = new LookUpForma(myInterface);
            sf.ShowDialog();
            //Key = sf.Key;
            //Value = sf.Value;
            //txtValue.Text = Value;
        }

        public void setInterface(PropertyInterface interf)
        {
            myInterface = interf;
        }

        public void SetValueTextBox(string value)
        {
            tbNaziv.Text = value;
        }

        public string GetKeyValue()
        {
            return tbNaziv.Text;
        }
    }
}
