using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appInvestigacionPreliminar.Mantenimiento
{
    public partial class Anio : Form
    {
        public Anio()
        {
            InitializeComponent();
        }
        
        private DAO.AnioDAO anio = new DAO.AnioDAO();
        private void Grilla()
        {
            dgvAnio.DataSource = anio.ListarAnio();
            dgvAnio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAnio.AllowUserToAddRows = false;
            dgvAnio.AllowUserToDeleteRows = false;
            dgvAnio.ReadOnly = true;
        }
        private void Limpiar()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
        }

        private void Anio_Load(object sender, EventArgs e)
        {
            txtId.Text = DateTime.Now.Year.ToString();
            Grilla();
        }

        private void dgvAnio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtId.Text = dgvAnio.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dgvAnio.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void picSi_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else
                {
                    string mensaje = anio.AgregarAnio(txtDescripcion.Text.Trim());
                    MessageBox.Show(mensaje);
                    Grilla();
                    Limpiar();
                }
            }
            if (txtId.Text != "")
            {
                if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else
                {
                    string mensaje = anio.ActualizarAnio(txtId.Text, txtDescripcion.Text.Trim());
                    MessageBox.Show(mensaje);
                    Grilla();
                    Limpiar();
                }
            }
        }


    }
}
