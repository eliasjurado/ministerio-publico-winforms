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
using System.Configuration;
using System.IO;

namespace appInvestigacionPreliminar
{
    public partial class AperturaInvestigacion : Form
    {
        public AperturaInvestigacion()
        {
            InitializeComponent();
        }
        
        //------------------------------------------------------------------------
        private DAO.DisposicionDAO disposicion= new DAO.DisposicionDAO();
        private void CargarCodigo()
        {
            txtNroDisposicion.Text = disposicion.CodigoDisposicion(txtNroCarpeta.Text);
            dtpEmision.Focus();
        }

        private void txtNroCarpeta_TextChanged(object sender, EventArgs e)
        {
            CargarCodigo();
        }
        string sede;
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
            sede = SEDE;
            if (ESTADO == "PENDIENTE") { txtNroCarpeta.Text = ""; txtNroDisposicion.Text = ""; MessageBox.Show("Esta carpeta aún no ha sido calificada."); }
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            Listado f1 = new Listado();
            f1.PasarDatos += new Listado.Almacenar_Datos(RecuperarDatos);
            f1.ShowDialog();
        }

      
        //Considerando

        //Lista interna del Considerando
        private List<clsParrafo> lstConsiderando = new List<clsParrafo>();
        private void CargarGrillaConsiderando()
        {
            dgvConsiderando.DataSource = null;
            dgvConsiderando.DataSource = lstConsiderando;
            dgvConsiderando.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvConsiderando.Columns[0].Width = 25;
            dgvConsiderando.Columns[1].Width = 645;
        }
        private void picAgregarConsiderando_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstConsiderando.Find(i => i.TEXTO == txtConsiderando.Text);
            if (txtConsiderando.Text== "") { MessageBox.Show("Ingrese historia"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvConsiderando.RowCount + 1;
                reg.TEXTO = txtConsiderando.Text.Trim();
                lstConsiderando.Add(reg);
                CargarGrillaConsiderando();
                txtConsiderando.Text = "";
            }
        }
        private void picQuitarConsiderando_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstConsiderando.Find(i => i.TEXTO == txtConsiderando.Text);
            if (reg != null)
            {
                lstConsiderando.Remove(reg);
                CargarGrillaConsiderando();
                txtConsiderando.Text = "";
            }
        }
        private void dgvConsiderando_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvConsiderando.CurrentRow.Selected = true;
                txtConsiderando.Text = dgvConsiderando.CurrentRow.Cells[1].Value.ToString();
            }
        }

        //Dispone

        //Lista interna del Dispone
        private List<clsParrafo> lstDispone = new List<clsParrafo>();
        private void CargarGrillaDispone()
        {
            dgvDispone.DataSource = null;
            dgvDispone.DataSource = lstDispone;
            dgvDispone.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDispone.Columns[0].Width = 25;
            dgvDispone.Columns[1].Width = 645;
        }
        private void picAgregarDispone_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstDispone.Find(i => i.TEXTO == txtDispone.Text);
            if (txtDispone.Text == "") { MessageBox.Show("Ingrese diligencia"); }
            else if (reg == null)
            {
                reg = new clsParrafo();
                reg.ID = dgvDispone.RowCount + 1;
                reg.TEXTO = txtDispone.Text.Trim();
                lstDispone.Add(reg);
                CargarGrillaDispone();
                txtDispone.Text = "";
            }
        }
        private void picQuitarDispone_Click(object sender, EventArgs e)
        {
            clsParrafo reg = lstDispone.Find(i => i.TEXTO == txtDispone.Text);
            if (reg != null)
            {
                lstDispone.Remove(reg);
                CargarGrillaDispone();
                txtDispone.Text = "";
            }
        }
        private void dgvDispone_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDispone.CurrentRow.Selected = true;
                txtDispone.Text = dgvDispone.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private DAO.ModeloDAO documento = new DAO.ModeloDAO();
        private void picAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Seleccione una carpeta haciendo click en la lupa"); }
            else if (int.Parse(txtNroDisposicion.Text) > 1) { MessageBox.Show("Ya existe la disposición Nro. 1 en la carpeta " + txtNroCarpeta.Text + ". No es posible realizar la apertura."); this.Close(); }
            else if (dtpEmision.Value > DateTime.Now) { MessageBox.Show("Fecha de emisión no puede ser posterior a la fecha actual"); dtpEmision.Value = DateTime.Now; }
            else if (dgvConsiderando.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 historia en Considerando"); }
            else if (dgvDispone.RowCount < 1) { MessageBox.Show("Ingrese al menos 1 diligencia"); }
            else
            {
                if (MessageBox.Show("¿Confirma que la información ingresada es correcta?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mensaje = disposicion.IngresarDisposicionApertura(txtNroCarpeta.Text, txtNroDisposicion.Text, dtpEmision.Value);
                    foreach (DataGridViewRow row1 in dgvConsiderando.Rows)
                    {
                        string mensaje1 = disposicion.IngresarDisposicionParte1(txtNroCarpeta.Text, txtNroDisposicion.Text, row1.Cells[0].Value.ToString(), row1.Cells[1].Value.ToString());
                    }
                    foreach (DataGridViewRow row2 in dgvDispone.Rows)
                    {
                        string mensaje2 = disposicion.IngresarDisposicionParte2(txtNroCarpeta.Text, txtNroDisposicion.Text, row2.Cells[0].Value.ToString(), row2.Cells[1].Value.ToString());
                    }
                    string mensaje3 = documento.CrearDisposicionApertura(txtNroCarpeta.Text, txtNroDisposicion.Text,dtpEmision.Value);

                    if (this.sede == "POLICIAL") 
                    {
                        string mensaje4 = documento.CrearOficioApertura(txtNroCarpeta.Text, txtNroDisposicion.Text, dtpEmision.Value); 
                    }
                    
                    MessageBox.Show(mensaje);
                    var directorio = ConfigurationManager.AppSettings.Get("DirectorioPdf");
                    var directoryinfo = new DirectoryInfo(directorio);
                    if(!directoryinfo.Exists)
                    {
                        Directory.CreateDirectory(directorio);
                    }
                    Process.Start(directorio);
                    this.Close();
                }
            } 
        }




    }
}
