using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace appInvestigacionPreliminar.Investigacion
{
    public partial class Incautacion : Form
    {
        public Incautacion()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------
        private DAO.RequerimientoDAO req = new DAO.RequerimientoDAO();
        private void CargarCodigo()
        {
            txtNroRequerimiento.Text = req.CodigoRequerimiento(txtNroCarpeta.Text);
            dtpEmision.Focus();
        }

        private void txtNroCarpeta_TextChanged(object sender, EventArgs e)
        {
            CargarCodigo();
        }
        //------------------------------------------------------------------------
        private void RecuperarDatos(
            string ID
            , string CASO
            , DateTime FECHAINGRESO
            , string FISCAL
            , int DIASRETRASOAPERTURAINVESTIGACION
            , string DEPENDENCIAORIGEN
            , string OFICIOORIGEN
            , string SEDE
            , string DEPENDENCIADESTINO
            , string ESTADO
            , DateTime FECHAINIINV
            , DateTime FECHAFININV
            , int DIASINVESTIGACION
            , DateTime FECHAINIPRO
            , DateTime FECHAFINPRO
            , int DIASPRORROGA
            , DateTime FECHAINIEXT
            , DateTime FECHAFINEXT
            , int DIASPRORROGAEXTRAORDINARIA
            )
        {
            txtNroCarpeta.Text = ID;
            if (ESTADO == "PENDIENTE") { txtNroCarpeta.Text = ""; txtNroRequerimiento.Text = ""; MessageBox.Show("Esta carpeta aún no ha sido calificada."); }
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            Listado f1 = new Listado();
            f1.PasarDatos += new Listado.Almacenar_Datos(RecuperarDatos);
            f1.ShowDialog();
        }

        //Bienes

        //Lista interna del Bienes
        private List<clsParrafo> lstBienes = new List<clsParrafo>();
        private void CargarGrillaBienes()
        {
            dgvBienes.DataSource = null;
            dgvBienes.DataSource = lstBienes;
            dgvBienes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBienes.Columns[0].Width = 25;
            dgvBienes.Columns[1].Width = 645;
        }
        private void picAgregarBienes_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstBienes.Find(i => i.TEXTO == txtBienes.Text);
            if (txtBienes.Text == "") { MessageBox.Show("Ingrese bienes requeridos"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvBienes.RowCount + 1;
                reg.TEXTO = txtBienes.Text.Trim();
                lstBienes.Add(reg);
                CargarGrillaBienes();
                txtBienes.Text = "";
            }
        }
        private void picQuitarBienes_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstBienes.Find(i => i.TEXTO == txtBienes.Text);
            if (reg != null)
            {
                lstBienes.Remove(reg);
                CargarGrillaBienes();
                txtBienes.Text = "";
            }
        }
        private void dgvBienes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvBienes.CurrentRow.Selected = true;
                txtBienes.Text = dgvBienes.CurrentRow.Cells[1].Value.ToString();
            }
        }

        //Hechos

        //Lista interna del Hechos
        private List<clsParrafo> lstHechos = new List<clsParrafo>();
        private void CargarGrillaHechos()
        {
            dgvHechos.DataSource = null;
            dgvHechos.DataSource = lstHechos;
            dgvHechos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHechos.Columns[0].Width = 25;
            dgvHechos.Columns[1].Width = 645;
        }
        private void picAgregarHechos_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstHechos.Find(i => i.TEXTO == txtHechos.Text);
            if (txtHechos.Text == "") { MessageBox.Show("Ingrese hechos requeridos"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvHechos.RowCount + 1;
                reg.TEXTO = txtHechos.Text.Trim();
                lstHechos.Add(reg);
                CargarGrillaHechos();
                txtHechos.Text = "";
            }
        }
        private void picQuitarHechos_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstHechos.Find(i => i.TEXTO == txtHechos.Text);
            if (reg != null)
            {
                lstHechos.Remove(reg);
                CargarGrillaHechos();
                txtHechos.Text = "";
            }
        }
        private void dgvHechos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvHechos.CurrentRow.Selected = true;
                txtHechos.Text = dgvHechos.CurrentRow.Cells[1].Value.ToString();
            }
        }
        //Elementos

        //Lista interna del Elementos
        private List<clsParrafo> lstElementos = new List<clsParrafo>();
        private void CargarGrillaElementos()
        {
            dgvElementos.DataSource = null;
            dgvElementos.DataSource = lstElementos;
            dgvElementos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvElementos.Columns[0].Width = 25;
            dgvElementos.Columns[1].Width = 645;
        }
        private void picAgregarElementos_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstElementos.Find(i => i.TEXTO == txtElementos.Text);
            if (txtElementos.Text == "") { MessageBox.Show("Ingrese Elementos requeridos"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvElementos.RowCount + 1;
                reg.TEXTO = txtElementos.Text.Trim();
                lstElementos.Add(reg);
                CargarGrillaElementos();
                txtElementos.Text = "";
            }
        }
        private void picQuitarElementos_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstElementos.Find(i => i.TEXTO == txtElementos.Text);
            if (reg != null)
            {
                lstElementos.Remove(reg);
                CargarGrillaElementos();
                txtElementos.Text = "";
            }
        }
        private void dgvElementos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvElementos.CurrentRow.Selected = true;
                txtElementos.Text = dgvElementos.CurrentRow.Cells[1].Value.ToString();
            }
        }
        //Fundamento

        //Lista interna del Fundamento
        private List<clsParrafo> lstFundamento = new List<clsParrafo>();
        private void CargarGrillaFundamento()
        {
            dgvFundamento.DataSource = null;
            dgvFundamento.DataSource = lstFundamento;
            dgvFundamento.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFundamento.Columns[0].Width = 25;
            dgvFundamento.Columns[1].Width = 645;
        }
        private void picAgregarFundamento_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstFundamento.Find(i => i.TEXTO == txtFundamento.Text);
            if (txtFundamento.Text == "") { MessageBox.Show("Ingrese Fundamento requeridos"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvFundamento.RowCount + 1;
                reg.TEXTO = txtFundamento.Text.Trim();
                lstFundamento.Add(reg);
                CargarGrillaFundamento();
                txtFundamento.Text = "";
            }
        }
        private void picQuitarFundamento_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstFundamento.Find(i => i.TEXTO == txtFundamento.Text);
            if (reg != null)
            {
                lstFundamento.Remove(reg);
                CargarGrillaFundamento();
                txtFundamento.Text = "";
            }
        }
        private void dgvFundamento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvFundamento.CurrentRow.Selected = true;
                txtFundamento.Text = dgvFundamento.CurrentRow.Cells[1].Value.ToString();
            }
        }


        private DAO.ModeloDAO documento = new DAO.ModeloDAO();
        private void picAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Seleccione una carpeta haciendo click en la lupa"); }
            else if (dtpEmision.Value > DateTime.Now) { MessageBox.Show("Fecha de emisión no puede ser posterior a la fecha actual"); dtpEmision.Value = DateTime.Now; }
            else if (dgvBienes.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 bien requerido"); }
            else if (dgvHechos.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 hecho"); }
            else if (dgvElementos.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 elemento de convicción"); }
            else if (dgvFundamento.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 peligro de fuga u obstaculización"); }
            else
            {
                if (MessageBox.Show("¿Confirma que la información ingresada es correcta?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mensaje = req.IngresarRequerimientoIncautacion(txtNroCarpeta.Text, txtNroRequerimiento.Text, dtpEmision.Value);
                    
                    foreach (DataGridViewRow row1 in dgvBienes.Rows)
                    {
                        string mensaje1 = req.IngresarRequerimientoParte1(txtNroCarpeta.Text, txtNroRequerimiento.Text, row1.Cells[0].Value.ToString(), row1.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row2 in dgvHechos.Rows)
                    {
                        string mensaje2 = req.IngresarRequerimientoParte2(txtNroCarpeta.Text, txtNroRequerimiento.Text, row2.Cells[0].Value.ToString(), row2.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row3 in dgvElementos.Rows)
                    {
                        string mensaje3 = req.IngresarRequerimientoParte3(txtNroCarpeta.Text, txtNroRequerimiento.Text, row3.Cells[0].Value.ToString(), row3.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row4 in dgvFundamento.Rows)
                    {
                        string mensaje4 = req.IngresarRequerimientoParte4(txtNroCarpeta.Text, txtNroRequerimiento.Text, row4.Cells[0].Value.ToString(), row4.Cells[1].Value.ToString());
                    }


                    string mensaje5 = documento.CrearReqIncautacion(txtNroCarpeta.Text, txtNroRequerimiento.Text, dtpEmision.Value);


                    MessageBox.Show(mensaje);
                    Process.Start(@"C:\Roma");
                    this.Close();
                }
            }
        }
    }
}
