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
        private readonly MenuPrincipal frm1;
       
        public Ventas(MenuPrincipal MP) 
        {
            InitializeComponent();

            frm1 = MP;
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


            //Cerrar ventana si es mayor 1 el index
         
            int count = frm1.tabControl1.TabPages.Count;
            for (int i = 0; i <frm1.tabControl1.TabPages.Count; i++)
            {
                if (i == count - 1)
                {

                }
                else
                {
                   if (count - 1 <= 1)
                            {
                        MenuPrincipal.cpest = 1;
                        frm1.tabControl1.TabPages[0].Text = "Venta " +MenuPrincipal.cpest + "       ";

                            }
                            else
                            {
                                frm1.tabControl1.TabPages.RemoveAt(i);



                            }

                            break;
                }

            }

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
            NP = "";
            PP = "";
            comboBox1.Text = button37.Text.TrimEnd();
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

        private void dgVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            NP = "";
            PP = "";
          
            NP=dgVenta.CurrentRow.Cells["VentaNombre"].Value.ToString().TrimEnd();
            comboBox1.Text = NP;
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
            dgVenta.Rows.RemoveAt(dgVenta.CurrentRow.Index);

            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void dgVenta_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            decimal Total = 0;

            for (int i = 0; i < dgVenta.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dgVenta.Rows[i].Cells["VentaPrecio"].Value);
            }

            textBox1.Text = Total.ToString("N2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button3.Text.TrimEnd();
            NP = button3.Text.TrimEnd();
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

        private void button4_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button4.Text.TrimEnd();
            NP = button4.Text.TrimEnd();
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

        private void button5_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button5.Text.TrimEnd();
            NP = button5.Text.TrimEnd();
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

        private void button6_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button6.Text.TrimEnd();
            NP = button6.Text.TrimEnd();
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

        private void button7_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button7.Text.TrimEnd();
            NP = button7.Text.TrimEnd();
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

        private void button8_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button8.Text.TrimEnd();
            NP = button8.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {PP = dr[0].ToString().TrimEnd();}
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button9.Text.TrimEnd();
            NP = button9.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button10.Text.TrimEnd();
            NP = button10.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button11.Text.TrimEnd();
            NP = button11.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button12.Text.TrimEnd();
            NP = button12.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button22.Text.TrimEnd();
            NP = button22.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button21.Text.TrimEnd();
            NP = button21.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button20.Text.TrimEnd();
            NP = button20.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button19.Text.TrimEnd();
            NP = button19.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button18.Text.TrimEnd();
            NP = button18.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button17.Text.TrimEnd();
            NP = button17.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button16.Text.TrimEnd();
            NP = button16.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button15.Text.TrimEnd();
            NP = button15.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button14.Text.TrimEnd();
            NP = button14.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button13.Text.TrimEnd();
            NP = button13.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button32.Text.TrimEnd();
            NP = button32.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button31.Text.TrimEnd();
            NP = button31.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button30.Text.TrimEnd();
            NP = button30.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button29.Text.TrimEnd();
            NP = button29.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button28.Text.TrimEnd();
            NP = button28.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button27.Text.TrimEnd();
            NP = button27.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button26.Text.TrimEnd();
            NP = button26.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button25.Text.TrimEnd();
            NP = button25.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button24.Text.TrimEnd();
            NP = button24.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            NP = "";
            PP = "";
            comboBox1.Text = button23.Text.TrimEnd();
            NP = button23.Text.TrimEnd();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT PrecioVenta FROM[dbo].[Producto] Where NombreProducto='" + NP.TrimEnd() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                { PP = dr[0].ToString().TrimEnd(); }
                dr.Close();
                con.Close();
            }
            VentasAgregar V = new VentasAgregar(this);
            V.ShowDialog();
        }
    }
}
