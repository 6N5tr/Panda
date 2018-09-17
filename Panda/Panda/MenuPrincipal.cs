
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
                List<Form> forms = new List<Form>();

                // All opened myForm instances
                foreach (Form f in Application.OpenForms)
                    if (f.Name == "Productos")
                        forms.Add(f);

                // Now let's close opened myForm instances
                foreach (Form f in forms)
                    f.Close();

                Productos prod = new Productos();
                prod.MdiParent = this;
                prod.Show();
            }
            else
            {
                Productos prod = new Productos();
                prod.MdiParent = this;
                prod.Show();
            }
            
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Proveedores"] as Proveedores) != null)
            {
                List<Form> forms = new List<Form>();

                // All opened myForm instances
                foreach (Form f in Application.OpenForms)
                    if (f.Name == "Proveedores")
                        forms.Add(f);

                // Now let's close opened myForm instances
                foreach (Form f in forms)
                    f.Close();

                Proveedores prov = new Proveedores();
                prov.MdiParent = this;
                prov.Show();
            }
            else
            {
            Proveedores prov = new Proveedores();
            prov.MdiParent = this;
            prov.Show();
            }
        }

        bool close = true;
        private void MenuPrincipal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (close) {
                DialogResult result = MessageBox.Show("Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                    
                }
                else
                {
                    e.Cancel = true;
                }
            }
         
        }
    }
}
