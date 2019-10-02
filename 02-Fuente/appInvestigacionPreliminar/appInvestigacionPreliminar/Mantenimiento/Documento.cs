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
    public partial class Documento : Form
    {
        public Documento()
        {
            InitializeComponent();
        }
        private DAO.DocumentoDAO doc = new DAO.DocumentoDAO();
        private void ComboDocumento()
        {
            DataTable dtb = doc.ListarTipoDocumento();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboTipoDocumento.DataSource = dtb;
            cboTipoDocumento.DisplayMember = "DESCRIPCION";
            cboTipoDocumento.ValueMember = "DESCRIPCION";
            cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void GrillaDocumento()
        {
            dgvDocumento.DataSource = doc.ListarDocumento();
            dgvDocumento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocumento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDocumento.AllowUserToAddRows = false;
            dgvDocumento.AllowUserToDeleteRows = false;
            dgvDocumento.ReadOnly = true;
        }

        private void LimpiardgvDocumento()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            cboTipoDocumento.SelectedIndex = 0;
        }
        private void Documento_Load(object sender, EventArgs e)
        {
            ComboDocumento();
            GrillaDocumento();
        }

        private void picAceptar2_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                if (cboTipoDocumento.SelectedIndex == 0) { MessageBox.Show("Seleccione tipo de documento"); }
                else if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else
                {
                    string mensaje = doc.AgregarDocumento(txtDescripcion.Text,cboTipoDocumento.SelectedIndex.ToString());
                    MessageBox.Show(mensaje);
                    GrillaDocumento();
                    LimpiardgvDocumento();
                }
            }
            if (txtId.Text != "")
            {
                if (txtDescripcion.Text == "") { MessageBox.Show("Ingrese nombre"); }
                else
                {
                    string mensaje = doc.ActualizarDocumento(txtId.Text, txtDescripcion.Text,cboTipoDocumento.SelectedIndex.ToString());
                    MessageBox.Show(mensaje);
                    GrillaDocumento();
                    LimpiardgvDocumento();
                }
            }
        }

        private void picCancelar2_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") { MessageBox.Show("Seleccione un documento de la lista"); }
            else
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mensaje = doc.EliminarDocumento(txtId.Text);
                    MessageBox.Show(mensaje);
                }
                GrillaDocumento();
                LimpiardgvDocumento();
            }
            
        }

        private void dgvDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvDocumento.CurrentRow.Selected = true;
                txtId.Text = dgvDocumento.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dgvDocumento.CurrentRow.Cells[2].Value.ToString();
                cboTipoDocumento.SelectedValue = dgvDocumento.CurrentRow.Cells[1].Value.ToString();
            }
        }






    }
}
