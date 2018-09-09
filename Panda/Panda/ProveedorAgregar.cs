using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Panda
{
    public partial class ProveedorAgregar : Form
    {
        private readonly Proveedores frm1;
        public ProveedorAgregar(Proveedores PV)
        {
            InitializeComponent();
            frm1 = PV;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Proveedor] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
            command.ExecuteNonQuery();


            MessageBox.Show("Proveedor agregado exitosamente!");

         
           SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataTable table = new DataTable();
           da.Fill(table);
            
           frm1.dataGridView1.DataSource = new BindingSource(table, null);

                   
            
            this.Close();
           

        }

      
    }
}
