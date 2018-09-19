﻿using System;
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
    public partial class Productos : Form
    {
        string id;
        string nid;
        string IdProdU;
        string IdProd;
        string IdProvb;
        string Provel;
        bool dupl = false;
        public Productos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductoAgregar PR = new ProductoAgregar(this);
            PR.ShowDialog();


        }

        private void Productos_Load(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dgProducto.DataSource = new BindingSource(table, null);


        }

        private void dgProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dgProducto.CurrentCell.RowIndex;
            int columnindex = dgProducto.CurrentCell.ColumnIndex;
            string columnName = dgProducto.Columns[columnindex].Name;
            nid = dgProducto.Rows[rowindex].Cells[columnindex].Value.ToString();

            if (id != nid)
            {
                DialogResult dialogResult = MessageBox.Show("Desea conservar los cambios realizados?", "Borrar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT CodigoProducto FROM[dbo].[Producto] WHERE CodigoProducto = '" + nid + "'", con);
                    SqlDataReader reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Verifique el codigo del producto. Ya existe un producto con ese codigo!");
                        dupl = true;

                    }
                    reader.Close();

                    check_User_Name = new SqlCommand("SELECT NombreProducto FROM[dbo].[Producto] WHERE NombreProducto = '" + nid + "'", con);
                    reader = check_User_Name.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Verifique el nombre del producto. Ya existe un producto con ese nombre!");
                        dupl = true;

                    }
                    reader.Close();


                    if (dupl == true)
                    {
                        this.dgProducto.CancelEdit();

                        SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        dgProducto.DataSource = new BindingSource(table, null);

                       
                    }
                    else
                    {

                        con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                        con.Open(); 
                        SqlCommand cmd = new SqlCommand("SELECT NombreProducto FROM[dbo].[Producto] Where " + columnName + "='" + id + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                IdProdU = dr[0].ToString();

                            }
                            dr.Close();
                            con.Close();
                        }

                        con.Open();
                        SqlCommand command = new SqlCommand("UPDATE [dbo].[Producto] SET [" + columnName + "] = '" + nid + "' WHERE IdProducto = '" + IdProd + "'", con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Modificación realizada exitosamente!");




                        cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);
                        dgProducto.DataSource = new BindingSource(table, null);

                      


                        cmd = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Edición Productos','Cambió " + columnName.TrimEnd() + " " + id.TrimEnd() + " por " + nid.TrimEnd() + " de "+ IdProdU+"')", con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show(Login.Emp.TrimEnd() +" " + DateTime.Now.ToString("MMMM dd, yyyy") + " "+ DateTime.Now.ToString("h:mm:ss tt"));


                    }


                }
                else if (dialogResult == DialogResult.No)
                {
                    this.dgProducto.CancelEdit();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dgProducto.DataSource = new BindingSource(table, null);
                }
            }


        }

        private void dgProducto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea eliminar los campos seleccionados?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dgProducto.SelectedCells.Count > 0)
                {


                    int rowindex = dgProducto.CurrentCell.RowIndex;
                    int columnindex = dgProducto.CurrentCell.ColumnIndex;
                    id = dgProducto.Rows[rowindex].Cells[columnindex].Value.ToString();

                    string columnName = dgProducto.Columns[columnindex].Name;


                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto FROM[dbo].[Producto] Where " + columnName + "='" + id + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            IdProd = dr[0].ToString();

                        }
                        dr.Close();
                        con.Close();
                    }

                }


                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM[dbo].[Producto] where IdProducto = '" + IdProd + "'", con1);
                SqlDataReader provel = cmd1.ExecuteReader();
                if (provel.HasRows)
                {
                    while (provel.Read())
                    {

                        Provel = provel[0].ToString().TrimEnd() + " " + provel[1].ToString().TrimEnd();


                    }


                }

                provel.Close();

                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con2.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[Producto] WHERE IdProducto = '" + IdProd + "'", con2);
                command.ExecuteNonQuery();
                MessageBox.Show("Se ha eliminado los campos exitosamente!");



                command = new SqlCommand("INSERT INTO [dbo].[Registro] Values ('" + Login.Emp.TrimEnd() + "','" + DateTime.Now.ToString("MMMM dd, yyyy") + "','" + DateTime.Now.ToString("h:mm:ss tt") + "','Eliminación Productos','Eliminó el producto " + Provel + "')", con1);
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

        private void dgProducto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (dgProducto.SelectedCells.Count > 0)
            {


                int rowindex = dgProducto.CurrentCell.RowIndex;
                int columnindex = dgProducto.CurrentCell.ColumnIndex;
                id = dgProducto.Rows[rowindex].Cells[columnindex].Value.ToString();

                string columnName = dgProducto.Columns[columnindex].Name;


                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdProducto FROM[dbo].[Producto] Where " + columnName + "='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        IdProd = dr[0].ToString().TrimEnd();

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
                SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dgProducto.DataSource = new BindingSource(table, null);

            }
            else
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM[dbo].[Producto] where " +
                  "NombreProducto like '%" + textBox1.Text + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dgProducto.DataSource = new BindingSource(table, null);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM [dbo].[Producto]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dgProducto.DataSource = new BindingSource(table, null);

            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdProveedor FROM[dbo].[Proveedor] Where NombreProveedor like '%" + textBox2.Text + "%'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        IdProvb = dr[0].ToString().TrimEnd();

                    }
                    dr.Close();
                    con.Close();
                }

                con = new SqlConnection("Data Source=DESKTOP-9PPVGAJ;Initial Catalog=Panda;Integrated Security=True");
                cmd = new SqlCommand("SELECT CodigoProducto,NombreProducto,PrecioAdquisicion,PrecioVenta,Cantidad,CantidadMinima,CantidadMaxima FROM[dbo].[Producto] where " +
                  "IdProveedor ='" + IdProvb + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dgProducto.DataSource = new BindingSource(table, null);

            }
        }
    }
}
