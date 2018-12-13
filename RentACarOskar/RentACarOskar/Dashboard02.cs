using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RentACarOskar
{
    public partial class Dashboard02 : Form
    {
        public Dashboard02()
        {
            InitializeComponent();
        }
        /*
        [DllImport("user32.DLL", EntryPoint = "RelaseCapture")]
        private extern static void RelaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);*/

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 279)
            {
                MenuVertical.Width = 67;
                pictureBox1.Visible = false;
            }
            else
            {
                MenuVertical.Width = 279;
                pictureBox1.Visible = true;
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void iconMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void Dashboard02_Load(object sender, EventArgs e)
        {

        }

        /* private void BarTitle_MouseDown(object sender, MouseEventArgs e)
         {
             RelaseCapture();
             SendMessage(this.Handle, 0x112, 0xf012,0);
         }*/
    }
}
