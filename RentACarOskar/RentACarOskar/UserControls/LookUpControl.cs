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

        public LookUpControl(PropertyInterface interf)
        {
            InitializeComponent();

            myInterface = interf;
        }

        public void SetLabel(string text)
        {
            lblNaziv.Text = text;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //StandardForm sf = new StandardForm(myInterface);
           //sf.ShowDialog();
            //Key = sf.Key;
            //Value = sf.Value;
            tbNaziv.Text = Value;
        }

        public void SetValueTextBox(string value)
        {
            tbNaziv.Text = value;
        }
    }
}
