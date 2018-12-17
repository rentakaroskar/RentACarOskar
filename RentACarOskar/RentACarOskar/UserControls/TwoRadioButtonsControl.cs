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
    public partial class TwoRadioButtonsControl : UserControl
    {
        public TwoRadioButtonsControl()
        {
            InitializeComponent();
        }

        public void SetLabel(string name)
        {
            lblNaziv.Text = name;
        }

        public void SetRadioButtons(string name1, string name2)
        {
            rb1.Text = name1;
            rb2.Text = name2;
            rb1.Checked = true;
        }

        public string GetChecked()
        {
            if (rb1.Checked == true)
                return rb1.Text;
            else
                return rb2.Text;
        }

        public void SetChecked(string value)
        {
            if (value == rb1.Text)
                rb1.Checked = true;
            else
                rb2.Checked = true;
        }
    }
}
