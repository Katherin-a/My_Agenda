using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Agenda
{
    public partial class Form1 : Form
    {
        private int id;
        agenda age = new agenda();
        DataTable dt; 

        public Form1()
        {
            InitializeComponent();
            restablecerControles();
            consultar();
            dgvAgenda.Columns["id"].Visible = false;
        }

        
        private void consultar ()
        {
            dgvAgenda.DataSource = dt = age.consultar();

        }
        private void obtenerId()
        {
            id = Convert.ToInt32(dgvAgenda.CurrentRow.Cells["Id"].Value);
        }

        private void obtenerDatos()
        {
            obtenerId();
            txtNombre.Text = dgvAgenda.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dgvAgenda.CurrentRow.Cells["Telefono"].Value.ToString();
        }

        private void restablecerControles()
        {

            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtFiltrar.Clear();
            this.btnEliminar.Enabled = false;
            this.btnmodificar.Enabled = false; 
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            bool rs = age.actualizar(id,txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro Actualizado Correctamente");
                consultar();
            }
            restablecerControles();
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool rs = age.insertar(txtNombre.Text, txtTelefono.Text);
            if (rs)
            {
                MessageBox.Show("Registro Insertado Correctamente");
            }
            restablecerControles();
            consultar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r =
                MessageBox.Show("Eliminar", "Esta seguro que desea eliminar este registro?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (r == DialogResult.OK)
            {
                bool rs = age.eliminar(id);
                if(rs)
                {
                    MessageBox.Show("Registro Eliminado Correctamente");
                    consultar();
                }
                restablecerControles();
            }   
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"Nombre LIKE '%{txtFiltrar.Text}%'";       
        }

        private void dgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            restablecerControles();
            obtenerId();
            this.btnEliminar.Enabled = true;
        }

        private void dgvAgenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerDatos();
            this.btnEliminar.Enabled = false;
            this.btnmodificar.Enabled = true; 
        }
    }
}
