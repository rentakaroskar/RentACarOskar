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
    public partial class ComboBoxControl : UserControl
    {
        public ComboBoxControl()
        {
            InitializeComponent();
        }

        public void SetLabel(string name)
        {
            lblNaziv.Text = name;
        }

        public void FillComboBox(List<string> vrijednosti)
        {
            foreach (var item in vrijednosti)
            {
                comboBox.Items.Add(item);
            }
        }

        public void SetComboBox(string vrijednost)
        {
            comboBox.Text = vrijednost;
        }

        public string GetText()
        {
            return comboBox.Text;
        }
        //ReadOnly koristimo ako kliknemo na detalje da imamo0 samo ispis da ne mozemo mijenjati vrijednost
        public void ReadOnly()
        {
            comboBox.Enabled = false;

        }
    }
}
