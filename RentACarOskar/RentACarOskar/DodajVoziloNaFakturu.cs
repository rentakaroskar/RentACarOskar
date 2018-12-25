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
    public partial class DodajVoziloNaFakturu : Form
    {
        int fakturaID;
        public DodajVoziloNaFakturu()
        {
            InitializeComponent();
        }
        public DodajVoziloNaFakturu(int FakturaID):this()
        {
            fakturaID = FakturaID;
        }
    }
}
