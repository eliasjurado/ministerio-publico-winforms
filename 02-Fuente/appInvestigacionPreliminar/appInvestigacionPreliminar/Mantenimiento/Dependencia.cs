using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appInvestigacionPreliminar
{
    public partial class Dependencia : Form
    {
        public Dependencia()
        {
            InitializeComponent();
        }
        private DAO.DependenciaDAO dep = new DAO.DependenciaDAO();

        private void Cargar_Grilla()
        {
            dgvDependencia.DataSource = dep.ListarDependencia();
            dgvDependencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDependencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDependencia.AllowUserToAddRows = false;
            dgvDependencia.AllowUserToDeleteRows = false;
            dgvDependencia.ReadOnly = true;
        }
        private void Limpiar_Formulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
        }

        private void Dependencia_Load(object sender, EventArgs e)
        {
            Cargar_Grilla();
            Limpiar_Formulario();
        }

        private void dgvDependencia_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtId.Text = dgvDependencia.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dgvDependencia.CurrentRow.Cells[1].Value.ToString();
                txtDireccion.Text = dgvDependencia.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void picAceptar_Click(object sender, EventArgs e)
        {
            if (txtId.Text=="")
            {
                if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else if (txtDireccion.Text == "") { MessageBox.Show("Ingrese dirección"); }
                else
                {
                    string mensaje = dep.AgregarDependencia(txtDescripcion.Text.Trim(), txtDireccion.Text.Trim());
                    MessageBox.Show(mensaje);
                    Cargar_Grilla();
                    Limpiar_Formulario();
                }
            }
            if (txtId.Text != "")
            {
                if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else if (txtDireccion.Text == "") { MessageBox.Show("Ingrese dirección"); }
                else if (txtId.Text == "1") { 
                    txtDescripcion.Text="DESPACHO FISCAL";
                    string mensaje = dep.ActualizarDependencia(txtId.Text, txtDescripcion.Text.Trim(), txtDireccion.Text.Trim());
                    MessageBox.Show("Sólo es posible modificar la dirección del Despacho Fiscal ");
                    Cargar_Grilla();
                    Limpiar_Formulario();
                }
                else
                {
                    string mensaje = dep.ActualizarDependencia(txtId.Text, txtDescripcion.Text.Trim(), txtDireccion.Text.Trim());
                    MessageBox.Show(mensaje);
                    Cargar_Grilla();
                    Limpiar_Formulario();
                }
            }
        }

        private void picCancelar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == ""){ MessageBox.Show("Seleccione un documento de la lista"); }
            if (txtId.Text == "1") { MessageBox.Show("El despacho fiscal no puede ser eliminado"); Limpiar_Formulario(); }
            else 
            {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mensaje = dep.EliminarDependencia(txtId.Text);
                MessageBox.Show(mensaje);
            }
            Cargar_Grilla();
            Limpiar_Formulario();
            }
            
        }
    }
}
