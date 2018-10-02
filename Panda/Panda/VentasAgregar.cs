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

        public static bool addr = false;
   
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

                //frm2.dgVenta.Rows.Clear();
                //frm2.dgVenta.Refresh();
                // frm2.dgVenta.
                frm2.dgVenta.AutoGenerateColumns = false;
                
                frm2.dgVenta.DataSource = null;
              
                frm2.dgVenta.Rows.Add(label1.Text, textBox1.Text, Convert.ToDouble(label2.Text) * Convert.ToDouble(textBox1.Text));
                




                //DataTable dataTable = (DataTable)frm2.dgVenta.DataSource;
                //DataRow drToAdd = dataTable.NewRow();

                //drToAdd["VentaNombre"] = label1.Text;
                //drToAdd["VentaCantidad"] = textBox1.Text;
                //drToAdd["VentaPrecio"] = Convert.ToDouble(label2.Text) * Convert.ToDouble(textBox1.Text);


                //dataTable.Rows.Add(drToAdd);
                //dataTable.AcceptChanges();



                decimal Total = 0;

                for (int i = 0; i < frm2.dgVenta.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(frm2.dgVenta.Rows[i].Cells["VentaPrecio"].Value);
                }

               frm2.textBox1.Text = Total.ToString();



                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                //con.Open();

                //valor = Ventas.PP;


                //SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Venta] Values ('" + Ventas.NP.TrimEnd() + "','" + textBox1.Text.TrimEnd() + "','" + valor.Replace(",", ".") + "')", con);
                //command.ExecuteNonQuery();


                //con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                //con.Open();
                //command = new SqlCommand("Select SUM(CAST(VentaPrecio AS decimal(10,2)))FROM Venta", con);

                //SqlDataReader dr = command.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {

                //        preciototal = dr[0].ToString().TrimEnd();

                //    }
                //    dr.Close();
                //    con.Close();
                //}
                //con.Close();
                //con.Open();
                //SqlCommand cmd = new SqlCommand("SELECT VentaNombre,VentaPrecio,VentaCantidad FROM[dbo].[Venta]", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable table = new DataTable();
                //da.Fill(table);

                //frm2.dgVenta.DataSource = new BindingSource(table, null);
                //frm2.textBox1.Text = preciototal;

                if (frm2.dgVenta.Rows.Count >= 0)
                {
                    frm2.button2.Enabled = true;
                }

                //con.Close();
                this.Close();
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
