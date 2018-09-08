
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panda
{
    public partial class MenuPrincipal : Form
    {

        public MenuPrincipal()
        {
            InitializeComponent();
        }

       
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MenuPrincipal_Load_1(object sender, EventArgs e)
        {
           
            if (Login.Emp.Substring(0, 1) == "E")
            {
                
                usuariosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;

            }
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Productos"] as Productos) != null)
            {
                //Form is already open
            }
            else
            {
                Productos pro = new Productos();
                pro.MdiParent = this;
                pro.Show();
            }
            
        }
    }
}
