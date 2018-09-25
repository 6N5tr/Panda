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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM[dbo].[Producto]", con);
            con.Open();
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {

                cmd = new SqlCommand("SELECT NombreProducto FROM[dbo].[Producto]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "NombreProducto";
                comboBox1.ValueMember = "NombreProducto";
            }
            else
            {
                MessageBox.Show("Debe primero agregar al menos un producto!");
                Productos prod = new Productos();
                prod.MdiParent = MenuPrincipal.ActiveForm;
                prod.Show();
                this.Close();
            }

        }
    }
}
