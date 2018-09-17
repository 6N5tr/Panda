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


    public partial class Login : Form
    {
        public static string Emp { get; internal set; }
        public static string User { get; internal set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click_1(object sender, EventArgs e)

        {


            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Ingrese su nombre de usuario y su contraseña");
            }
            if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("Ingrese su nombre de usuario");
            }
            if (textBox2.Text == "" && textBox1.Text != "")
            {
                MessageBox.Show("Ingrese su contraseña");
            }

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *  " +
                "FROM[dbo].[Login] where NombreUsuario = '" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Tipo FROM[dbo].[Login] where NombreUsuario = '" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Emp = dr[0].ToString();

                }
            }
            dr.Close();
            cmd = new SqlCommand("SELECT NombreUsuario FROM[dbo].[Login] where NombreUsuario = '" + textBox1.Text + "' and Contraseña = '" + textBox2.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Emp = dr[0].ToString();
                    User = Emp;
                    
                }
               
            }
            if (dt.Rows.Count == 1)
            {

                this.Hide();
                MenuPrincipal main = new MenuPrincipal();
                main.Show();
                dr.Close();
                con.Close();
            }
            else
            {

                MessageBox.Show("Nombre de usuario o contraseña invalidos");
                textBox2.Text = "";

            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }
       
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = MessageBox.Show("Desea salir de programa?", "Salir", MessageBoxButtons.YesNo);
                if (mboxResult == DialogResult.No)
                {
                    /* Cancel the Closing event from closing the form. */
                    e.Cancel = true;
                }

                else if (mboxResult == DialogResult.Yes)
                {
                    /* Closing the form. */
                    e.Cancel = false;
                    Application.Exit();
                }
            }
        }
    }
}
