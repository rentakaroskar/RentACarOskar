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

        }
        //GetValue
        public string GetValueFromDateBox()
        {
            return dtNaziv.Text;
        }
        //SetValue
        public void SetValueInDateBox(string value)
        {
            dtNaziv.Text = value;
        }
    }
}
