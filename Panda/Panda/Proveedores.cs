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
    public partial class Proveedores : Form
    {
        string id;
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProveedorAgregar PV = new ProveedorAgregar(this);
            PV.ShowDialog();
            
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
             SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable table = new DataTable();
             da.Fill(table);
             dataGridView1.DataSource = new BindingSource(table, null);

           
             
        }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea conservar los cambios realizados?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                


            }
            else if (dialogResult == DialogResult.No)
            {
                this.dataGridView1.CancelEdit();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea eliminar los campos seleccionados?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                id=dataGridView1.SelectedCells[0].Value.ToString();
               
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] where CodigoProveedor='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString();
                        MessageBox.Show(id);
                    }
                    dr.Close();
                    con.Close();
                }

            }

        }
    }
}
