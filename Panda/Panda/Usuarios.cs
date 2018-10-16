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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Usuario]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = new BindingSource(table, null);
        }
    }
}
