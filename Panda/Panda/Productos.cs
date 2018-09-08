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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["ProductoAgregar"] as ProductoAgregar) != null)
            {
                //Form is already open
            }
            else
            {                
                ProductoAgregar PA = new ProductoAgregar();
                PA.ShowDialog();              
            }
            
           
        }
        
    }
}
