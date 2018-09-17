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
    
    public partial class Inicio : Form

    {
        int cont = 0;
        public Inicio()
        {
            
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cont = cont + 1;
            if (cont == 10) {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM[dbo].[Login]", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    
                    this.Hide();
                    Login ingreso = new Login();
                    ingreso.Show();
                    timer1.Enabled = false;   
                }
                else
                {
                    this.Opacity = 100;
                }
               

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Login] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','A')", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Administrador agregado exitosamente");
                this.Hide();
                Login ingreso = new Login();
                ingreso.Show();

            }
            else
            {
                MessageBox.Show("Digite nuevamente las contraseñas hubo un error");
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }
        bool close = true;
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (close)
            {
                DialogResult result = MessageBox.Show("Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();

                }
                else
                {
                    e.Cancel = true;
                }
            }
    }
}
