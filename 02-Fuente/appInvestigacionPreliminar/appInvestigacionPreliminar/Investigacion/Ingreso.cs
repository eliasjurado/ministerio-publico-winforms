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
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }
        
        //-------------------------------------------------------------------------
        private DAO.SujetoProcesalDAO sujetopro = new DAO.SujetoProcesalDAO();

        private void CargarTipoSujetoProcesal()
        {
            DataTable dtb = sujetopro.ListarTipoSujetoProcesal();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboTipoSujetoProcesal.DataSource = dtb;
            cboTipoSujetoProcesal.DisplayMember = "DESCRIPCION";
            cboTipoSujetoProcesal.ValueMember = "DESCRIPCION";
            cboTipoSujetoProcesal.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //-----------------------------------------------------------
        private DAO.IdentidadDAO dni = new DAO.IdentidadDAO();

        private void CargarTipoDocId()
        {
            DataTable dtb = dni.ListarTipoDocId();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboIdentificacion.DataSource = dtb;
            cboIdentificacion.DisplayMember = "DESCRIPCION";
            cboIdentificacion.ValueMember = "DESCRIPCION";
            cboIdentificacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //-------------------------------------------------------------------------
        private DAO.DependenciaDAO dep = new DAO.DependenciaDAO();

        public void CargarDependencia()
        {
            DataTable dtb = dep.ListarDependencia();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboDepOrigen.DataSource = dtb;
            cboDepOrigen.DisplayMember = "DESCRIPCION";
            cboDepOrigen.ValueMember = "ID";
            cboDepOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Ingreso_Load(object sender, EventArgs e)
        {
            CargarTipoSujetoProcesal();
            CargarDependencia();
            CargarTipoDocId();
        }
        //-------------------------------------------------------------------------
        DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Ingrese Nro. Carpeta"); }
            else if (txtNroCarpeta.Text.Length > 10) { MessageBox.Show("Nro. Carpeta máximo 10 caracteres"); }
            else if (txtNroCaso.Text == "") { MessageBox.Show("Ingrese Nro. Caso"); }
            else if (dtpFecIng.Value > DateTime.Now) { MessageBox.Show("Fecha Ingreso no puede ser mayor a la fecha actual"); }
            else if (cboDepOrigen.SelectedIndex.ToString() == "0") { MessageBox.Show("Seleccione Dependencia Origen"); }
            else if (txtOficio.Text == "") { MessageBox.Show("Ingrese Nro. Oficio"); }
            else if (dgvSujetoProcesal.RowCount < 2) { MessageBox.Show("Ingrese al menos 1 agraviado y 1 imputado."); }
            else
            {
                if (MessageBox.Show("¿La información de la carpeta es correcta?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Ingreso Carpeta
                    string mensaje = carpeta.IngresarCarpeta(txtNroCarpeta.Text.Trim(), txtNroCaso.Text.Trim(), dtpFecIng.Value, cboDepOrigen.SelectedValue.ToString(),txtOficio.Text.Trim());
                    //Ingreso Detalle de Carpeta Sujetos Procesales
                    foreach (DataGridViewRow row in dgvSujetoProcesal.Rows)
                    {
                        string mensaje2 = carpeta.IngresarCarpetaSujetoProcesal(txtNroCarpeta.Text, row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                    }
                    MessageBox.Show(mensaje);
                    this.Close();
                }
            }
        }

        //Lista interna del formulario
        private List<clsSujetoProcesal> lstDetCar = new List<clsSujetoProcesal>();
        private void CargarGrilla()
        {
            dgvSujetoProcesal.DataSource = null;
            dgvSujetoProcesal.DataSource = lstDetCar;
            dgvSujetoProcesal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSujetoProcesal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSujetoProcesal.AllowUserToAddRows = false;
            dgvSujetoProcesal.AllowUserToDeleteRows = false;
            dgvSujetoProcesal.ReadOnly = true;
        }
        private void picAgregar_Click(object sender, EventArgs e)
        {
            clsSujetoProcesal reg = lstDetCar.Find(i => i.NOMBRE == txtNombresSujetoProcesal.Text);
            if (txtNombresSujetoProcesal.Text == "") { MessageBox.Show("Ingrese nombres completos de sujeto procesal"); }
            else if (cboIdentificacion.SelectedIndex == 0) { MessageBox.Show("Seleccione tipo de documento de identificación"); }
            else if (txtDni.Text == "") { MessageBox.Show("Ingrese número de documento de identidad"); }
            else if (txtDni.Text.Length < 8) { MessageBox.Show("Número de documento de identidad mínimo 8 números"); }
            else if (txtDni.Text.Length > 9) { MessageBox.Show("Número de documento de identidad maxímo 9 números"); }
            else if (cboTipoSujetoProcesal.SelectedIndex == 0) { MessageBox.Show("Seleccione tipo de sujeto procesal"); }
            else if (reg == null)
            {
                reg = new clsSujetoProcesal();
                reg.ID = dgvSujetoProcesal.RowCount + 1;
                reg.NOMBRE = txtNombresSujetoProcesal.Text.Trim();
                reg.TIPODNI = cboIdentificacion.SelectedValue.ToString();
                reg.NRODNI = txtDni.Text.Trim();
                reg.TIPO = cboTipoSujetoProcesal.SelectedValue.ToString();

                lstDetCar.Add(reg);

                CargarGrilla();
                txtNombresSujetoProcesal.Text = "";
                cboIdentificacion.SelectedIndex = 0;
                txtDni.Text = "";
                cboTipoSujetoProcesal.SelectedIndex = 0;
            }
        }

        private void picQuitar_Click(object sender, EventArgs e)
        {
            clsSujetoProcesal reg = lstDetCar.Find(i => i.NOMBRE == txtNombresSujetoProcesal.Text);
            if (reg != null)
            {
                lstDetCar.Remove(reg);

                CargarGrilla();
                txtNombresSujetoProcesal.Text = "";
                cboIdentificacion.SelectedIndex = 0;
                txtDni.Text = "";
                cboTipoSujetoProcesal.SelectedIndex = 0;
            }
        }

        private void dgvSujetoProcesal_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSujetoProcesal.CurrentRow.Selected = true;

                txtNombresSujetoProcesal.Text = dgvSujetoProcesal.CurrentRow.Cells["NOMBRE"].Value.ToString();
                cboIdentificacion.Text = dgvSujetoProcesal.CurrentRow.Cells["TIPODNI"].Value.ToString();
                txtDni.Text = dgvSujetoProcesal.CurrentRow.Cells["NRODNI"].Value.ToString();
                cboTipoSujetoProcesal.Text = dgvSujetoProcesal.CurrentRow.Cells["TIPO"].Value.ToString();
            }
        }


        //Solo dígitos
        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else
            {
                e.Handled = true;
                MessageBox.Show("Sólo números");
            }
        }


    }
}
