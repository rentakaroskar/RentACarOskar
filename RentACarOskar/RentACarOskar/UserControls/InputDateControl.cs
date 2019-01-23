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
    public partial class InputDateControl : UserControl
    {
        public InputDateControl()
        {
            InitializeComponent();
        }
        //SetLabel
        public void SetLabel(string name)
        {
            lblNaziv.Text = name;
            if (name == "Datum fakture")
                dtNaziv.Enabled = false;
        }
        //GetValue
        public string GetValueFromDateBox()
        {
            return dtNaziv.Value.ToString();
        }
        //SetValue
        public void SetValueInDateBox(string value)
        {
            dtNaziv.Text = value;
        }
        //ReadOnly koristimo ako kliknemo na detalje da imamo0 samo ispis da ne mozemo mijenjati vrijednost
        public void ReadOnly()
        {
            this.dtNaziv.Enabled = false;
        }
    }
}
