using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appInvestigacionPreliminar.Investigacion
{
    public partial class Calificacion : Form
    {
        public Calificacion()
        {
            InitializeComponent();
        }
        private DAO.DependenciaDAO dependencia = new DAO.DependenciaDAO();
        private void CargarDependencia()
        {
            DataTable dtb = dependencia.ListarDependencia();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboDepDestino.DataSource = dtb;
            cboDepDestino.DisplayMember = "DESCRIPCION";
            cboDepDestino.ValueMember = "ID";
            cboDepDestino.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private DAO.DelitoDAO del = new DAO.DelitoDAO();
        private void CargarTipoDelito()
        {
            DataTable dtb = del.ListarTipoDelito();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboTipoDelito.DataSource = dtb;
            cboTipoDelito.DisplayMember = "DESCRIPCION";
            cboTipoDelito.ValueMember = "DESCRIPCION";
            cboTipoDelito.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private DAO.SedeDAO sede = new DAO.SedeDAO();
        private void CargarSede()
        {
            DataTable dtb = sede.ListarSede();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboSede.DataSource = dtb;
            cboSede.DisplayMember = "DESCRIPCION";
            cboSede.ValueMember = "ID";
            cboSede.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //Días Hábiles
        private void DiasInvestigacion()
        {
            DateTime desde = dtpIniInvestigacion.Value;
            DateTime hasta = dtpFinInvestigacion.Value;
            int dias_habiles = 0;

            while (desde <= hasta)
            {
                int numero_dia = Convert.ToInt16(desde.DayOfWeek.ToString("d"));
                if (numero_dia == 1 || numero_dia == 2 || numero_dia == 3 || numero_dia == 4 || numero_dia == 5)
                {
                    dias_habiles++;
                }
                desde = desde.AddDays(1);
            }
            txtDiasInvestigacion.Text = dias_habiles.ToString();

            if (dias_habiles <= 0) { MessageBox.Show("Intervalo de fechas inválido"); }
            else { txtDiasInvestigacion.Text = dias_habiles.ToString(); }
            //differenceInDays+1 como corrección porque haciendo el cálculo manual me da un día más. No sé qué pasa con C#
            
        }
        //------------------------------------------------------------------------
        private void Calificacion_Load(object sender, EventArgs e)
        {
            CargarSede();
            CargarDependencia();
            CargarTipoDelito();
        }

        private void dtpIniInvestigacion_ValueChanged(object sender, EventArgs e)
        {
            DiasInvestigacion();
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
        //Solo letras
        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else
            {
                e.Handled = true;
                MessageBox.Show("Sólo letras");
            }

        }
        //------------------------------------------------------------------------
        //Lista interna del formulario
        private List<clsDelito> lstDetCar = new List<clsDelito>();
        private void CargarGrilla()
        {
            dgvDelito.DataSource = null;
            dgvDelito.DataSource = lstDetCar;
            dgvDelito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDelito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDelito.AllowUserToAddRows = false;
            dgvDelito.AllowUserToDeleteRows = false;
            dgvDelito.ReadOnly = true;
        }
        
        private void picAgregar_Click(object sender, EventArgs e)
        {
            clsDelito reg = lstDetCar.Find(i => i.ARTICULO == txtArticulo.Text);
            if (cboTipoDelito.SelectedIndex == 0) { MessageBox.Show("Seleccione Tipo Delito"); }
            else if (txtArticulo.Text == "") { MessageBox.Show("Ingrese artículo"); }
            else if (txtGenerico.Text == "") { MessageBox.Show("Ingrese delito genérico"); }
            else if (txtSubgenerico.Text == "") { MessageBox.Show("Ingrese delito subgenérico"); }
            else if (txtEspecifico.Text == "") { MessageBox.Show("Ingrese delito específico"); }
            else if (txtInciso.Text == "") { MessageBox.Show("Ingrese inciso del artículo citado"); }
            else if (txtCita.Text == "") { MessageBox.Show("Ingrese cita del código penal"); }
            else if (reg == null)
            {
                reg = new clsDelito();
                reg.ID = dgvDelito.RowCount + 1;
                reg.ARTICULO = txtArticulo.Text.Trim();
                reg.GENERICO = txtGenerico.Text.Trim();
                reg.SUBGENERICO = txtSubgenerico.Text.Trim();
                reg.ESPECIFICO = txtEspecifico.Text.Trim();
                reg.INCISO = txtInciso.Text.Trim();
                reg.CITA = txtCita.Text;
                reg.TIPODELITO = cboTipoDelito.SelectedValue.ToString();

                lstDetCar.Add(reg);

                CargarGrilla();
                txtArticulo.Text = "";
                txtGenerico.Text = "";
                txtSubgenerico.Text = "";
                txtEspecifico.Text = "";
                txtInciso.Text = "";
                txtCita.Text = "";
                cboTipoDelito.SelectedIndex = 0;
            }
        }
        private void picQuitar_Click(object sender, EventArgs e)
        {
            clsDelito reg = lstDetCar.Find(i => i.ARTICULO == txtArticulo.Text);
            if (reg != null)
            {
                lstDetCar.Remove(reg);

                CargarGrilla();
                txtArticulo.Text = "";
                txtGenerico.Text = "";
                txtSubgenerico.Text = "";
                txtEspecifico.Text = "";
                txtInciso.Text = "";
                txtCita.Text = "";
                cboTipoDelito.SelectedIndex = 0;

            }
        }
        private void dgvDelito_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDelito.CurrentRow.Selected = true;

                txtArticulo.Text = dgvDelito.CurrentRow.Cells["ARTICULO"].Value.ToString();
                txtGenerico.Text = dgvDelito.CurrentRow.Cells["GENERICO"].Value.ToString();
                txtSubgenerico.Text = dgvDelito.CurrentRow.Cells["SUBGENERICO"].Value.ToString();
                txtEspecifico.Text = dgvDelito.CurrentRow.Cells["ESPECIFICO"].Value.ToString();
                txtInciso.Text = dgvDelito.CurrentRow.Cells["INCISO"].Value.ToString();
                txtCita.Text = dgvDelito.CurrentRow.Cells["CITA"].Value.ToString();
                cboTipoDelito.SelectedValue = dgvDelito.CurrentRow.Cells["TIPODELITO"].Value.ToString(); 

            }
        }
        //------------------------------------------------------------------------
        DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();
        private void picAceptar_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Seleccione una carpeta haciendo click en la lupa"); }
            //else if (txtDelitoArticulo.Text == "") { MessageBox.Show("Ingrese delito artículo"); }
            //else if (txtDelitoGenerico.Text == "") { MessageBox.Show("Ingrese delito genérico"); }
            //else if (txtDelitoSubgenerico.Text == "") { MessageBox.Show("Ingrese delito subgenérico"); }
            //else if (txtDelitoEspecifico.Text == "") { MessageBox.Show("Ingrese delito específico"); }
            else if (cboSede.SelectedIndex == 0) { MessageBox.Show("Seleccione sede"); }
            else if (cboDepDestino.SelectedIndex == 0) { MessageBox.Show("Seleccione dependencia destino"); }
            else if (int.Parse(txtDiasInvestigacion.Text) <= 0) { MessageBox.Show("Fechas de investigación inválidas"); }
            //else if (dgvDelito.RowCount < 1) { MessageBox.Show("Ingrese mínimo un delito"); }
            else
            {
                if (MessageBox.Show("¿La información ingresada a la carpeta " + txtNroCarpeta.Text + " es correcta?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Calificacion Carpeta
                    string mensaje = carpeta.CalificarCarpeta(txtNroCarpeta.Text, cboSede.SelectedValue.ToString(), cboDepDestino.SelectedValue.ToString(), dtpIniInvestigacion.Value, dtpFinInvestigacion.Value,txtDiasInvestigacion.Text);
                    MessageBox.Show(mensaje);
                    //Ingreso Detalle de Carpeta Sujetos Procesales
                    foreach (DataGridViewRow row in dgvDelito.Rows)
                    {
                        string mensaje2 = carpeta.CalificarCarpetaDelito(txtNroCarpeta.Text, row.Cells[0].Value.ToString(), row.Cells[2].Value.ToString()
                            , row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[1].Value.ToString());
                    }
                    this.Close();
                }
            }

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
            if (ESTADO == "CALIFICACION") { txtNroCarpeta.Text = ""; MessageBox.Show("Esta carpeta ya ha sido calificada."); }
        }

        private void picBuscar_Click(object sender, EventArgs e)
        {
            Listado f1 = new Listado();
            f1.PasarDatos += new Listado.Almacenar_Datos(RecuperarDatos);
            f1.ShowDialog();
        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSede.SelectedIndex == 1) 
            {
                cboDepDestino.SelectedIndex = 1;
                cboDepDestino.Enabled = false;
            }
            if (cboSede.SelectedIndex == 2)
            {
                cboDepDestino.Enabled = true;
                cboDepDestino.SelectedIndex = 0;
            }
        }

        private void cboDepDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSede.SelectedIndex == 2 && cboDepDestino.SelectedIndex == 1)
            { 
                MessageBox.Show("Si la sede es policial la dependencia de destino no puede ser el despacho fiscal");
                cboDepDestino.SelectedIndex = 0;
            }
        }









        





        
    }
}
