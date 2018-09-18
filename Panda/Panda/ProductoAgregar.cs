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
    public partial class ProductoAgregar : Form

    {

        string Provel;
        private readonly Productos frm2;
        bool dupl = false;
        bool camp = false;
        public ProductoAgregar(Productos PR)
        {
            InitializeComponent();
            frm2 = PR;
        }
        private void ProductoAgregar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT NombreProveedor FROM[dbo].[Proveedor]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "NombreProveedor";
            comboBox1.ValueMember = "NombreProveedor";
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
                camp = true;

            }
            else
            {
                camp = false;
            }

            if (camp == false)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand check_User_Name = new SqlCommand("SELECT CodigoProducto FROM[dbo].[Producto] WHERE CodigoProducto = '" + textBox1.Text + "'", con);
                check_User_Name.Parameters.AddWithValue("@user", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Verifique el codigo del producto. Ya existe un producto con ese codigo!");
                    textBox1.Text = "";
                    dupl = true;

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

                }
                reader.Close();

                if (dupl == false)
                {

                    SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con1.Open();
                    MessageBox.Show(comboBox1.Text);
                    SqlCommand cmd1 = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] where NombreProveedor = '" + comboBox1.Text.TrimEnd() + "'", con1);
                    SqlDataReader provel = cmd1.ExecuteReader();
                    if (provel.HasRows)
                    {
                        while (provel.Read())
                        {

                            Provel = provel[0].ToString().TrimEnd();
                            MessageBox.Show(Provel);

                        }


                    }

                    provel.Close();

                    reader.Close();
                    SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Producto] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','"+Provel+"')", con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Producto agregado exitosamente!");


                    

                    command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Agregación','Agregó el producto " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + " " + textBox5.Text + "" + textBox6.Text + " " + textBox7.Text + "')", con);
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


    }
}
