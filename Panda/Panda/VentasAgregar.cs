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
using System.Globalization;

namespace Panda
{
   
    public partial class VentasAgregar : Form
    {
        private readonly Ventas frm2;

        public static string CP;
        public static string CPM;
        public static int C;
        public VentasAgregar(Ventas V)
        {
            InitializeComponent();
            frm2 = V;
        }

        private void VentasAgregar_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = Ventas.NP;
            label2.Text = Ventas.PP;
            if (label2.Text == "")
            {
                MessageBox.Show("Este producto aun no ha sido ingresado!");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(textBox1.Text) >= 1) {


                bool existe = false;
                foreach (DataGridViewRow row in frm2.dgVenta.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value).Equals(Ventas.NP.TrimEnd()))
                    {
                        existe = true;
                    }
                }
                if (existe == true)
                {
                    MessageBox.Show("El producto ya fue ingresado en la venta actual");
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Cantidad FROM[dbo].[Producto] where NombreProducto ='" + Ventas.NP.TrimEnd() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CP = dr[0].ToString();

                        }
                    }
                    dr.Close();

                    cmd = new SqlCommand("SELECT CantidadMinima FROM[dbo].[Producto] where NombreProducto ='" + Ventas.NP.TrimEnd() + "'", con);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            CPM = dr1[0].ToString();

                        }
                    }
                    dr1.Close();





                    if (Convert.ToInt32(CP) - Convert.ToInt32(textBox1.Text) >= 0)
                    {


                        if (Convert.ToInt32(CP) - Convert.ToInt32(textBox1.Text) <= Convert.ToInt32(CPM))
                        {
                            MessageBox.Show("Quedan " + Convert.ToString(Convert.ToInt32(CP) - Convert.ToInt32(textBox1.Text)) + " de " + Ventas.NP + "");
                        }

                        frm2.dgVenta.AutoGenerateColumns = false;

                        frm2.dgVenta.DataSource = null;

                        frm2.dgVenta.Rows.Add(label1.Text, textBox1.Text, (Convert.ToDouble(label2.Text) * Convert.ToDouble(textBox1.Text)).ToString("N2"));


                        decimal Total = 0;

                        for (int i = 0; i < frm2.dgVenta.Rows.Count; i++)
                        {
                            Total += Convert.ToDecimal(frm2.dgVenta.Rows[i].Cells["VentaPrecio"].Value);
                        }

                        frm2.textBox1.Text = Total.ToString("N2");



                        con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                        con.Open();



                        if (frm2.dgVenta.Rows.Count >= 0)
                        {
                            frm2.button2.Enabled = true;
                        }

                        //con.Close();
                        this.Close();


                    }
                    else {
                        MessageBox.Show("No hay esa cantidad de producto para la venta!. Solo hay " + Convert.ToString(Convert.ToInt32(CP)) + " de " + Ventas.NP + "");
                    }
                   
                }

           

                
            }
            else
            {
                MessageBox.Show("La cantidad debe ser mayor a 1 ");
            }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
               
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
