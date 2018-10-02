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

        public static string NP;
        public static string PP;

        bool NoPro = false;
     
       
        public Ventas()
        {
            InitializeComponent();


        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            
            if (dgVenta.Rows.Count == 0) {
                button2.Enabled = false;
            }


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
                NoPro = true;
              
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            NP = comboBox1.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }

                                 
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta](VentaNombre, VentaCantidad,VentaPrecio) VALUES (@VentaNombre, @VentaCantidad, @VentaPrecio)",con);
            foreach (DataGridViewRow row in dgVenta.Rows)
            {
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@VentaNombre", row.Cells[0].Value);
                cmd.Parameters.AddWithValue("@VentaCantidad", row.Cells[1].Value);
                cmd.Parameters.AddWithValue("@VentaPrecio", row.Cells[2].Value);
              
                cmd.ExecuteNonQuery();
            }

            cmd = new SqlCommand("SELECT VentaNombre,VentaPrecio,VentaCantidad FROM[dbo].[Venta]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dgVenta.DataSource = new BindingSource(table, null);
            VentasAgregar.addr = true;
            foreach (DataGridViewRow row in dgVenta.Rows)
            {

                string Venta;
                string Cantidad;
                string Precio;
               

                Venta = dgVenta[0, row.Index].Value.ToString();
                Precio = dgVenta[1, row.Index].Value.ToString();
                Cantidad = dgVenta[2, row.Index].Value.ToString();
                            


                con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Venta Productos','Se vendió " + Cantidad.TrimEnd() + " del producto " + Venta.TrimEnd() + " a " + Precio.TrimEnd() + "')", con);
                command.ExecuteNonQuery();
            }

            


            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con1.Open();


            cmd = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Venta Productos Total','Se vendió total " + textBox1.Text.TrimEnd() + "')", con1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Venta Realizada!");

            cmd = new SqlCommand("DELETE FROM [dbo].[Venta]", con1);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT VentaNombre,VentaPrecio,VentaCantidad FROM[dbo].[Venta]", con1);
             da = new SqlDataAdapter(cmd);
            table = new DataTable();
            da.Fill(table);
            dgVenta.DataSource = new BindingSource(table, null);

            if (dgVenta.Rows.Count == 0)
            {
                button2.Enabled = false;
            }
            textBox1.Text = "";
            con.Close();
            con1.Close();
        

        }

        private void Ventas_VisibleChanged(object sender, EventArgs e)
        {
            if (NoPro == true) {
               
                Productos prod = new Productos();
                prod.MdiParent = MenuPrincipal.ActiveForm;
                prod.Show();
                this.Close();
                
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //Enrollado
            NP = "";
            PP = "";
            comboBox1.Text= button37.Text.TrimEnd();
            NP = button37.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();
                 

                }
                dr.Close();
                con.Close();
            }


            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //Cacho
            NP = "";
            PP = "";
            comboBox1.Text = button36.Text.TrimEnd();
            NP = button36.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();
                    MessageBox.Show(PP);
                }
                dr.Close();
                con.Close();
            }


            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button35.Text.TrimEnd();
            NP = button35.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }


            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button34.Text.TrimEnd();
            NP = button34.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }


            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button33.Text.TrimEnd();
            NP = button33.Text.TrimEnd();
         
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    PP = dr[0].ToString().TrimEnd();

                }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

       
       
    }
}
