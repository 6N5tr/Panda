
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
        public static int cpest=0;
        
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

            
            tabControl1.TabPages.Clear();
            tabControl1.Visible = false;
            if (Login.Emp.Substring(0, 1) == "E")
            {
                
                usuariosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;

            }
        }

        private void productosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl1.Visible = false;

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

       
        private void MenuPrincipal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = MessageBox.Show("Desea salir de programa?", "Salir", MessageBoxButtons.YesNo);
                if (mboxResult == DialogResult.No)
                {
                    /* Cancel the Closing event from closing the form. */
                    e.Cancel = true;
                }

                else if (mboxResult == DialogResult.Yes)
                {
                    /* Closing the form. */
                    e.Cancel = false;
                    Application.Exit();
                }
            }

        }
        
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (tabControl1.TabPages.Count == 0)
            {
                Ventas vt = new Ventas(this);
                vt.MdiParent = this;
                vt.WindowState = FormWindowState.Maximized;
                vt.TopMost = true;
                vt.Activate();
                vt.Focus();


                cpest++;
                tabControl1.Visible = true;
                vt.TopLevel = false;
                vt.ControlBox = false;
                vt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                vt.Dock = DockStyle.Fill;

                var newTab = new TabPage();
                newTab.Controls.Add(vt);
                this.tabControl1.TabPages.Add(newTab);
                newTab.Text = "Venta " + cpest + "       ";
                this.tabControl1.SelectedTab = newTab;
                vt.Show();

                
                var newTab1 = new TabPage();
                this.tabControl1.TabPages.Add(newTab1);
                newTab1.Text = "+";
               
                


            }
            else {
             tabControl1.Visible = true;
            }

            
           
        }

       
       
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            int count = this.tabControl1.TabPages.Count;
            if (e.Index == count-1)
            {
                e.Graphics.DrawString("", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
            else {
                
                if (e.Index <=count-1)
                {
                     

                    if (e.Index == tabControl1.SelectedIndex)
                    {
                        TabPage page = tabControl1.TabPages[e.Index];
                        Color col = Color.LawnGreen; 
                        e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

                        Rectangle paddedBounds = e.Bounds;
                        int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
                        paddedBounds.Offset(1, yOffset);
                        TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);

                        e.Graphics.DrawString("X", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                        //e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                        e.DrawFocusRectangle();

                    }
                    else
                    {
                        TabPage page = tabControl1.TabPages[e.Index];
                        Color col = Color.LightSkyBlue;
                        e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

                        Rectangle paddedBounds = e.Bounds;
                        int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
                        paddedBounds.Offset(1, yOffset);
                        TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);

                        e.Graphics.DrawString("X", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                        //e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                        e.DrawFocusRectangle();

                    }
                    
                }
               
            }
           
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            int count = this.tabControl1.TabPages.Count;
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                if (i == count-1) {
                    
                }
                else
                {
                    Rectangle r = tabControl1.GetTabRect(i);
                    //Getting the position of the "x" mark.
                    Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 15, 7);
                    if (closeButton.Contains(e.Location))
                    {
                        if (MessageBox.Show("Desea cerrar esta ventana de ventas?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (count-1 <= 1)
                            {
                                this.tabControl1.TabPages.RemoveAt(i);
                                tabControl1.Visible = false;
                                tabControl1.TabPages.Clear();
                                cpest = 0;


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



                            }
                            else
                            {
                                this.tabControl1.TabPages.RemoveAt(i);

                               
                               
                            }

                            break;
                        }
                    }
                }
                
            }
        }

      

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
            int count = this.tabControl1.TabPages.Count;
            if (tabControl1.SelectedIndex == count - 1)//your specific tabname
            {
                
                Ventas vt = new Ventas(this);
                vt.MdiParent = this;
                vt.WindowState = FormWindowState.Maximized;
                vt.TopMost = true;
                vt.Activate();
                vt.Focus();


                cpest++;
                tabControl1.Visible = true;
                vt.TopLevel = false;
                vt.ControlBox = false;
                vt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                vt.Dock = DockStyle.Fill;
                var newTab = new TabPage();
                newTab.Controls.Add(vt);
                this.tabControl1.TabPages.Insert(0, newTab);
                newTab.Text = "Venta " + cpest + "       ";
                this.tabControl1.SelectedTab = newTab;
                vt.Show();

            }
        }


    }
}
