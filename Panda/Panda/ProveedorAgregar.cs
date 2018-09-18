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
        bool dupl = false;
        bool camp = false;
        public ProveedorAgregar(Proveedores PV)
        {
            InitializeComponent();
            frm1 = PV;
            
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indique un codigo para el proveedor");
                camp = true;
            }
            else
            {
                camp = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Indique un nombre para el proveedor");
                camp = true;

            }
            else {
                camp = false;
            }

            if (camp == false)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand check_User_Name = new SqlCommand("SELECT CodigoProveedor FROM[dbo].[Proveedor] WHERE CodigoProveedor = '" + textBox1.Text + "'", con);
                check_User_Name.Parameters.AddWithValue("@user", textBox1.Text);
                SqlDataReader reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Verifique el codigo del proveedor. Ya existe un proveedor con ese codigo!");
                    textBox1.Text = "";
                    dupl = true;

                }
                reader.Close();
                check_User_Name = new SqlCommand("SELECT NombreProveedor FROM[dbo].[Proveedor] WHERE NombreProveedor = '" + textBox2.Text + "'", con);
                check_User_Name.Parameters.AddWithValue("@user", textBox2.Text);
                reader = check_User_Name.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Verifique el nombre del proveedor. Ya existe un proveedor con ese nombre!");
                    textBox2.Text = "";
                    dupl = true;

                }
                reader.Close();

                if (dupl == false)
                {

                    reader.Close();
                    SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Proveedor] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Proveedor agregado exitosamente!");


                    command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Agregación Proveedores','Agregó el proveedor " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + " " + textBox5.Text + "')", con);
                    command.ExecuteNonQuery();
                    //MessageBox.Show(Login.Emp.TrimEnd() +" " + DateTime.Now.ToString("MMMM dd, yyyy") + " "+ DateTime.Now.ToString("h:mm:ss tt"));


                    SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    frm1.dataGridView1.DataSource = new BindingSource(table, null);

                    this.Close();
                }



            }



        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if  (!char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
                MessageBox.Show("Este campo solo acepta números");
            }
          
        }
    }
}
