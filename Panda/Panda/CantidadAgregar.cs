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
    public partial class CantidadAgregar : Form
    {

        string CA;
        string NCA;
        private readonly Productos frm2;

        public CantidadAgregar(Productos PR)
        {
            InitializeComponent();
            frm2 = PR;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdProducto FROM[dbo].[Producto] Where " + Productos.columnanombre.TrimEnd() + "='" + Productos.valorcelda.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    CA = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }

            con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("SELECT NombreProducto FROM[dbo].[Producto] Where " + Productos.columnanombre.TrimEnd() + "='" + Productos.valorcelda.TrimEnd() + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    NCA = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }


            con.Open();
            cmd = new SqlCommand("UPDATE [dbo].[Producto] SET Cantidad = '" + label4.Text.TrimEnd() + "' WHERE IdProducto = '" + CA.TrimEnd() + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Modificación realizada exitosamente!");




            cmd = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Edición Productos','Cambió " + Productos.columnanombre.TrimEnd() + " " + label3.Text.TrimEnd() + " por " + label4.Text.TrimEnd() + " de " + NCA.TrimEnd() + "')", con);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            frm2.dgProducto.DataSource = new BindingSource(table, null);


            this.Close();

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
                
            }
        }

        private void CantidadAgregar_Load(object sender, EventArgs e)
        {
            
            label3.Text = Productos.valorcelda;
            label4.Text = Convert.ToString(Convert.ToInt32(Productos.valorcelda) + Convert.ToInt32(textBox1.Text));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label4.Text = Convert.ToString(Convert.ToInt32(Productos.valorcelda) +0);
            }
            else {
                label4.Text = Convert.ToString(Convert.ToInt32(Productos.valorcelda) + Convert.ToInt32(textBox1.Text));
            }
            
           

        }
    }
}
