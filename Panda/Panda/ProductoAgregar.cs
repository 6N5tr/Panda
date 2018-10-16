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
    public partial class ProductoAgregar : Form

    {

        string Provel;
        private readonly Productos frm2;
        bool dupl = false;
        bool camp = false;
        bool camp1 = false;
        bool camp2 = false;
        bool camp3 = false;
        public ProductoAgregar(Productos PR)
        {
            InitializeComponent();
            frm2 = PR;
        }
        private void ProductoAgregar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM[dbo].[Proveedor]", con);
            con.Open();
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                
                cmd = new SqlCommand("SELECT NombreProveedor FROM[dbo].[Proveedor] order by NombreProveedor", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "NombreProveedor";
                comboBox1.ValueMember = "NombreProveedor";
            }
            else
            {
                MessageBox.Show("Debe primero agregar al menos un proveedor!");
                Proveedores prov = new Proveedores();
                prov.MdiParent = MenuPrincipal.ActiveForm;
                prov.Show();
                this.Close();
            }

           
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dupl = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indique un codigo para el producto");
                camp = true;
            }
            else
            {
                camp = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Indique un nombre para el producto");
                camp1 = true;

            }
            else
            {
                camp1 = false;
            }

         
            if (camp == false && camp1==false && camp2 == false && camp3 == false)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand check_User_Name = new SqlCommand("SELECT CodigoProducto FROM[dbo].[Producto] WHERE CodigoProducto = '" + textBox1.Text + "'", con);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Verifique el codigo del producto. Ya existe un producto con ese codigo!");
                    textBox1.Text = "";
                    dupl = true;
                    camp = true;
                }
                reader.Close();
                check_User_Name = new SqlCommand("SELECT NombreProducto FROM[dbo].[Producto] WHERE NombreProducto = '" + textBox2.Text + "'", con);
                check_User_Name.Parameters.AddWithValue("@user", textBox2.Text);
                reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Verifique el nombre del producto. Ya existe un producto con ese nombre!");
                    textBox2.Text = "";
                    dupl = true;
                    camp = true;

                }
                reader.Close();

                if (dupl == false)
                {

                    SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] where NombreProveedor = '" + comboBox1.Text.TrimEnd() + "'", con1);
                    SqlDataReader provel = cmd1.ExecuteReader();
                    if (provel.HasRows)
                    {
                        while (provel.Read())
                        {

                            Provel = provel[0].ToString().TrimEnd();
                            
                        }


                    }

                    provel.Close();

                    reader.Close();
                    SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Producto] Values ('" + textBox1.Text.TrimEnd() + "','" + textBox2.Text.TrimEnd() + "','" + textBox3.Text.TrimEnd() + "','" + textBox4.Text.TrimEnd() + "','" + textBox5.Text.TrimEnd() + "','" + textBox6.Text.TrimEnd() + "','" + textBox7.Text.TrimEnd() + "','"+Provel.TrimEnd() + "')", con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Producto agregado exitosamente!");


                    

                    command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Agregación Productos','Agregó el producto " + textBox1.Text.TrimEnd() + " " + textBox2.Text.TrimEnd() + " " + textBox3.Text.TrimEnd() + " " + textBox4.Text.TrimEnd() + " " + textBox5.Text.TrimEnd() + "" + textBox6.Text.TrimEnd() + " " + textBox7.Text.TrimEnd() + "')", con);
                    command.ExecuteNonQuery();
                   
                    SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    frm2.dgProducto.DataSource = new BindingSource(table, null);

                    this.Close();
                }



            }



        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
                       
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            TextBox textBox = (TextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            TextBox textBox = (TextBox)sender;
            // only allow one decimal point
            if (e.KeyChar == '.' && textBox.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && textBox.SelectionLength == 0)
            {
                if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
