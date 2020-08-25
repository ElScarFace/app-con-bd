using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Aplicación_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BaseDeDatos bd = new BaseDeDatos();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bd.SelectDataTable("select * from crud");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //string Agregar = "call agregarUsuario (" + txtID.Text + ",'" + txtNombre.Text + "'," + txtEdad.Text + ")";
            string Agregar = "insert into crud values ("+txtID.Text+",'"+txtNombre.Text+"',"+txtEdad.Text+")";
            

            if (bd.executecommand(Agregar))
            {
                MessageBox.Show("Inserción Exitosa");
                dataGridView1.DataSource = bd.SelectDataTable("select * from crud");
            }
            else
            {
                MessageBox.Show("Error!!");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string actualizar = "update crud set edad="+txtEdad.Text+" where Id="+txtID.Text;
            if (bd.executecommand(actualizar))
            {
                MessageBox.Show("Actualización Exitosa!!!");
                dataGridView1.DataSource = bd.SelectDataTable("select * from crud");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Eliminar = "delete from crud where Id=" + txtID.Text;
            if (bd.executecommand(Eliminar))
            {
                MessageBox.Show("Eliminación Exitosa!!!");
                dataGridView1.DataSource = bd.SelectDataTable("select * from crud");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string BuscarPorID = "select * from crud where Id="+txtID.Text;
            dataGridView1.DataSource = bd.SelectDataTable(BuscarPorID);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
