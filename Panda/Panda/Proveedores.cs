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
        string nid;
        string IdProv;
        string IdProvU;
        string Provel;
        bool dupl = false;

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
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            string columnName = dataGridView1.Columns[columnindex].Name;
            nid = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();

                        
            if (id != nid) {
                DialogResult dialogResult = MessageBox.Show("Desea conservar los cambios realizados?", "Borrar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT CodigoProveedor FROM[dbo].[Proveedor] WHERE CodigoProveedor = '" + nid + "'", con);
                    SqlDataReader reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Verifique el codigo del proveedor. Ya existe un proveedor con ese codigo!");
                        dupl = true;

                    }
                    reader.Close();

                    check_User_Name = new SqlCommand("SELECT NombreProveedor FROM[dbo].[Proveedor] WHERE NombreProveedor = '" + nid + "'", con);
                    reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Verifique el nombre del proveedor. Ya existe un proveedor con ese nombre!");
                        dupl = true;

                    }
                    reader.Close();

                    
                    if (dupl == true)
                    {
                        this.dataGridView1.CancelEdit();
                        SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);

                    }
                    else
                    {

                        con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT NombreProveedor FROM[dbo].[Proveedor] Where " + columnName + "='" + id + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                IdProvU = dr[0].ToString();

                            }
                            dr.Close();
                            con.Close();
                        }
                        con.Open();
                        SqlCommand command = new SqlCommand("UPDATE [dbo].[Proveedor] SET [" + columnName + "] = '" + nid + "' WHERE IdProveedor = '" + IdProv + "'", con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Modificación realizada exitosamente!");

                        cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        dataGridView1.DataSource = new BindingSource(table, null);


                        cmd = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Edición Proveedores','Cambió " + columnName.TrimEnd() + " " + id.TrimEnd() + " por " + nid.TrimEnd() + " de " + IdProvU + "')", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show(Login.Emp.TrimEnd() +" " + DateTime.Now.ToString("MMMM dd, yyyy") + " "+ DateTime.Now.ToString("h:mm:ss tt"));


                    }


                }
                else if (dialogResult == DialogResult.No)
                {
                    this.dataGridView1.CancelEdit();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = new BindingSource(table, null);
                }
            }
            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Desea eliminar los campos seleccionados?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {


                    int rowindex = dataGridView1.CurrentCell.RowIndex;
                    int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                    id = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();

                    string columnName = dataGridView1.Columns[columnindex].Name;





                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] Where " + columnName + "='" + id + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            IdProv = dr[0].ToString();

                        }
                        dr.Close();
                        con.Close();
                    }

                }


                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM[dbo].[Proveedor] where IdProveedor = '" + IdProv + "'", con1);
                SqlDataReader provel = cmd1.ExecuteReader();
                if (provel.HasRows)
                {
                    while (provel.Read())
                    {

                        Provel = provel[0].ToString().TrimEnd() + " " + provel[1].ToString().TrimEnd();
                        

                    }
                    

                }

                provel.Close();

                SqlConnection con3 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con3.Open();
                SqlCommand cmd3 = new SqlCommand("DELETE FROM [dbo].[Producto] WHERE IdProveedor = '" + IdProv + "'", con3);
                cmd3.ExecuteNonQuery();



                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con2.Open();
                SqlCommand command= new SqlCommand("DELETE FROM [dbo].[Proveedor] WHERE IdProveedor = '" + IdProv + "'", con2);
                command.ExecuteNonQuery();
                MessageBox.Show("Se ha eliminado los campos exitosamente!");

                
                
                command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Eliminación Proveedor','Eliminó el proveedor " + Provel + "')", con1);
                command.ExecuteNonQuery();
                //MessageBox.Show(Login.Emp.TrimEnd() +" " + DateTime.Now.ToString("MMMM dd, yyyy") + " "+ DateTime.Now.ToString("h:mm:ss tt"));
                provel.Close();
                con1.Close();

                


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


                int rowindex = dataGridView1.CurrentCell.RowIndex;
                int columnindex = dataGridView1.CurrentCell.ColumnIndex;
                id = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();

                string columnName = dataGridView1.Columns[columnindex].Name;
               

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] Where "+columnName+"='"+id+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        IdProv = dr[0].ToString();
                                         
                    }
                    dr.Close();
                    con.Close();
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);

            }
            else {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT CodigoProveedor,NombreProveedor,Telefono,Preventa,Posventa  " + "FROM[dbo].[Proveedor] where " +
                   "CodigoProveedor like '%" + textBox1.Text + "%' or " +
                   "NombreProveedor  like '%" + textBox1.Text + "%' or " +
                   "Telefono  like '%" + textBox1.Text + "%' or " +
                   "Preventa  like '%" + textBox1.Text + "%' or " +
                   "Posventa  like '%" + textBox1.Text + "%'" , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = new BindingSource(table, null);

            }
        }
    }
}
