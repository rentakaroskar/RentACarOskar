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
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        //SetLabel
        public void SetLabel(string name)
        {
            lblNaziv.Text = name;    

        }
        //GetValue
        public string GetValueFromTextBox()
        {
            return tbNaziv.Text;
        }
        //SetValue
        public void SetValueInTextBox(string value)
        {
            tbNaziv.Text = value;
        }

        //ReadOnly koristimo ako kliknemo na detalje da imamo0 samo ispis da ne mozemo mijenjati vrijednost
        public void ReadOnly()
        {
            tbNaziv.Enabled = false;

        }
    }
}
