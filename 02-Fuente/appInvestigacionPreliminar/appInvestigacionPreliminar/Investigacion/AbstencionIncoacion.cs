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
    public partial class AbstencionIncoacion : Form
    {
        public AbstencionIncoacion()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------
        private DAO.DisposicionDAO disposicion = new DAO.DisposicionDAO();
        private void CargarCodigo()
        {
            txtNroDisposicion.Text = disposicion.CodigoDisposicion(txtNroCarpeta.Text);
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
            if (ESTADO == "PENDIENTE") { txtNroCarpeta.Text = ""; txtNroDisposicion.Text = ""; MessageBox.Show("Esta carpeta aún no ha sido calificada."); }
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            Listado f1 = new Listado();
            f1.PasarDatos += new Listado.Almacenar_Datos(RecuperarDatos);
            f1.ShowDialog();
        }
        //Atendiendo

        //Lista interna del Atendiendo
        private List<clsParrafo> lstAtendiendo = new List<clsParrafo>();
        private void CargarGrillaAtendiendo()
        {
            dgvAtendiendo.DataSource = null;
            dgvAtendiendo.DataSource = lstAtendiendo;
            dgvAtendiendo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAtendiendo.Columns[0].Width = 25;
            dgvAtendiendo.Columns[1].Width = 645;
        }

        private void picAgregarAtendiendo_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstAtendiendo.Find(i => i.TEXTO == txtAtendiendo.Text);
            if (txtAtendiendo.Text == "") { MessageBox.Show("Ingrese historia"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvAtendiendo.RowCount + 1;
                reg.TEXTO = txtAtendiendo.Text.Trim();
                lstAtendiendo.Add(reg);
                CargarGrillaAtendiendo();
                txtAtendiendo.Text = "";
            }
        }
        private void picQuitarAtendiendo_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstAtendiendo.Find(i => i.TEXTO == txtAtendiendo.Text);
            if (reg != null)
            {
                lstAtendiendo.Remove(reg);
                CargarGrillaAtendiendo();
                txtAtendiendo.Text = "";
            }
        }
        private void dgvAtendiendo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvAtendiendo.CurrentRow.Selected = true;
                txtAtendiendo.Text = dgvAtendiendo.CurrentRow.Cells[1].Value.ToString();
            }
        }
        //Juicio

        //Lista interna del Juicio
        private List<clsParrafo> lstJuicio = new List<clsParrafo>();
        private void CargarGrillaJuicio()
        {
            dgvJuicio.DataSource = null;
            dgvJuicio.DataSource = lstJuicio;
            dgvJuicio.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvJuicio.Columns[0].Width = 25;
            dgvJuicio.Columns[1].Width = 645;
        }

        private void picAgregarJuicio_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstJuicio.Find(i => i.TEXTO == txtJuicio.Text);
            if (txtJuicio.Text == "") { MessageBox.Show("Ingrese juicio de subsunción"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvJuicio.RowCount + 1;
                reg.TEXTO = txtJuicio.Text.Trim();
                lstJuicio.Add(reg);
                CargarGrillaJuicio();
                txtJuicio.Text = "";
            }
        }

        private void picQuitarJuicio_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstJuicio.Find(i => i.TEXTO == txtJuicio.Text);
            if (reg != null)
            {
                lstJuicio.Remove(reg);
                CargarGrillaJuicio();
                txtJuicio.Text = "";
            }
        }

        private void dgvJuicio_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvJuicio.CurrentRow.Selected = true;
                txtJuicio.Text = dgvJuicio.CurrentRow.Cells[1].Value.ToString();
            }
        }




        //Acuerdo

        //Lista interna del Acuerdo
        private List<clsParrafo> lstAcuerdo = new List<clsParrafo>();
        private void CargarGrillaAcuerdo()
        {
            dgvAcuerdo.DataSource = null;
            dgvAcuerdo.DataSource = lstAcuerdo;
            dgvAcuerdo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAcuerdo.Columns[0].Width = 25;
            dgvAcuerdo.Columns[1].Width = 645;
        }

        private void picAgregarAcuerdo_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstAcuerdo.Find(i => i.TEXTO == txtAcuerdo.Text);
            if (txtAcuerdo.Text == "") { MessageBox.Show("Ingrese acuerdo"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvAcuerdo.RowCount+1;
                reg.TEXTO = txtAcuerdo.Text.Trim();
                lstAcuerdo.Add(reg);
                CargarGrillaAcuerdo();
                txtAcuerdo.Text = "";
            }

        }

        private void picQuitarAcuerdo_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstAcuerdo.Find(i => i.TEXTO == txtAcuerdo.Text);
            if (reg != null)
            {
                lstAcuerdo.Remove(reg);
                CargarGrillaAcuerdo();
                txtAcuerdo.Text = "";
            }
        }

        private void dgvAcuerdo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvAcuerdo.CurrentRow.Selected = true;
                txtAcuerdo.Text = dgvAcuerdo.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private DAO.ModeloDAO documento = new DAO.ModeloDAO();
        private void picAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Seleccione una carpeta haciendo click en la lupa"); }
            else if (dtpEmision.Value > DateTime.Now) { MessageBox.Show("Fecha de emisión no puede ser posterior a la fecha actual"); dtpEmision.Value = DateTime.Now; }
            else if (dgvAtendiendo.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 historia en Atendiendo"); }
            else if (dgvJuicio.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 juicio de subsunción"); }
            else if (dgvAcuerdo.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 acuerdo"); }
            else
            {
                if (MessageBox.Show("¿Confirma que la información ingresada es correcta?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mensaje = disposicion.IngresarDisposicion(txtNroCarpeta.Text, txtNroDisposicion.Text, dtpEmision.Value,txtActuados.Text.Trim());
                    foreach (DataGridViewRow row1 in dgvAtendiendo.Rows)
                    {
                        string mensaje1 = disposicion.IngresarDisposicionParte1(txtNroCarpeta.Text, txtNroDisposicion.Text, row1.Cells[0].Value.ToString(), row1.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row2 in dgvJuicio.Rows)
                    {
                        string mensaje2 = disposicion.IngresarDisposicionParte2(txtNroCarpeta.Text, txtNroDisposicion.Text, row2.Cells[0].Value.ToString(), row2.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row3 in dgvAcuerdo.Rows)
                    {
                        string mensaje3 = disposicion.IngresarDisposicionParte3(txtNroCarpeta.Text, txtNroDisposicion.Text, row3.Cells[0].Value.ToString(), row3.Cells[1].Value.ToString());
                    }
                    string mensaje4 = documento.CrearAbstencionIncoacion(txtNroCarpeta.Text, txtNroDisposicion.Text, dtpEmision.Value,txtActuados.Text.Trim());


                    MessageBox.Show(mensaje);
                    Process.Start(@"C:\Roma");
                    this.Close();
                }
            }
        }

    }
}
