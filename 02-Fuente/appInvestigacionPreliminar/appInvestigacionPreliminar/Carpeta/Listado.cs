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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------
        private DAO.DependenciaDAO dep = new DAO.DependenciaDAO();

        private void CargarDependenciaOrigen()
        {
            DataTable dtb = dep.ListarDependencia();
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboDepOrigen.DataSource = dtb;
            cboDepOrigen.DisplayMember = "DESCRIPCION";
            cboDepOrigen.ValueMember = "ID";
            cboDepOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarDependenciaDestino()
        {
            DataTable dtb = dep.ListarDependencia();
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboDepDestino.DataSource = dtb;
            cboDepDestino.DisplayMember = "DESCRIPCION";
            cboDepDestino.ValueMember = "ID";
            cboDepDestino.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //------------------------------------------------------------------------
        private DAO.EstadoDAO estado = new DAO.EstadoDAO();

        private void CargarEstado()
        {
            DataTable dtb = estado.ListarEstado();
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboEstado.DataSource = dtb;
            cboEstado.DisplayMember = "DESCRIPCION";
            cboEstado.ValueMember = "ID";
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //------------------------------------------------------------------------
        private DAO.SedeDAO sede = new DAO.SedeDAO();

        private void CargarSede()
        {
            DataTable dtb = sede.ListarSede();
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboSede.DataSource = dtb;
            cboSede.DisplayMember = "DESCRIPCION";
            cboSede.ValueMember = "ID";
            cboSede.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //------------------------------------------------------------------------

        private DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();

        private void CargarGrilla()
        {
            dgvListado.DataSource = carpeta.Listar();
            dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvListado.AllowUserToAddRows = false;
            dgvListado.AllowUserToDeleteRows = false;
            dgvListado.ReadOnly = true;
        }

        private void Limpiar()
        {
            txtNroCarpeta.Text = "";
            txtDelito.Text="";
            dtpDesde.Value=DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            //cboDepOrigen.SelectedIndex = 0;
            //cboSede.SelectedIndex = 0;
            //cboDepDestino.SelectedIndex = 0;
            //cboEstado.SelectedIndex = 0;
            txtNroCarpeta.Focus();
        }

        private void ListarXNroCarpeta()
        {
            if (txtNroCarpeta.Text == "") { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXNroCarpeta(txtNroCarpeta.Text);
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXFechaIngreso()
        {
            if (dtpDesde.Value > DateTime.Now) { MessageBox.Show("Desde no puede ser posterior a la fecha actual."); }
            else if (dtpHasta.Value > DateTime.Now) { MessageBox.Show("Hasta no puede ser posterior a la fecha actual."); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXFechaIngreso(dtpDesde.Value, dtpHasta.Value);
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXDelito()
        {
            if (txtDelito.Text == "") { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXDelito(txtDelito.Text);
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXDependenciaOrigen()
        {
            if (cboDepOrigen.SelectedIndex==0) { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXDependenciaOrigen(cboDepOrigen.SelectedValue.ToString());
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXSede()
        {
            if (cboDepOrigen.SelectedIndex == 0) { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXSede(cboSede.SelectedValue.ToString());
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXDependenciaDestino()
        {
            if (cboDepDestino.SelectedIndex == 0) { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXDependenciaDestino(cboDepDestino.SelectedValue.ToString());
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }
        private void ListarXEstado()
        {
            if (cboEstado.SelectedIndex == 0) { CargarGrilla(); }
            else
            {
                dgvListado.DataSource = carpeta.ListarXEstado(cboEstado.SelectedValue.ToString());
                dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvListado.AllowUserToAddRows = false;
                dgvListado.AllowUserToDeleteRows = false;
                dgvListado.ReadOnly = true;
            }
        }

        //----------------------------------------------------------------------------------------
        private void Listado_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarDependenciaOrigen();
            CargarDependenciaDestino();
            CargarSede();
            CargarEstado();
        }
        private void picBuscarNroCarpeta_Click(object sender, EventArgs e)
        {
            ListarXNroCarpeta();
            Limpiar();
        }
        private void picBuscarFechaIngreso_Click(object sender, EventArgs e)
        {
            ListarXFechaIngreso();
            Limpiar();
        }
        private void picBuscarDelito_Click(object sender, EventArgs e)
        {
            ListarXDelito();
            Limpiar();
        }
        private void cboDepOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarXDependenciaOrigen();
            Limpiar();
        }
        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarXSede();
            Limpiar();
        }
        private void cboDepDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarXDependenciaDestino();
            Limpiar();
        }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarXEstado();
            Limpiar();
        }

        //----------------------------------------------------------------------------------------
        public delegate void Almacenar_Datos(
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
        );
        public event Almacenar_Datos PasarDatos;

        
        
        private void dgv_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvListado.CurrentRow.Selected = true;
                string ID = dgvListado.CurrentRow.Cells[0].Value.ToString();
                string CASO = dgvListado.CurrentRow.Cells[1].Value.ToString();
                DateTime FECHAINGRESO = DateTime.Parse(dgvListado.CurrentRow.Cells[2].Value.ToString());
                string FISCAL = dgvListado.CurrentRow.Cells[3].Value.ToString();
                int DIASRETRASOAPERTURAINVESTIGACION = int.Parse(dgvListado.CurrentRow.Cells[4].Value.ToString());
                string DEPENDENCIAORIGEN = dgvListado.CurrentRow.Cells[5].Value.ToString();
                string OFICIOORIGEN = dgvListado.CurrentRow.Cells[6].Value.ToString();
                string SEDE = dgvListado.CurrentRow.Cells[7].Value.ToString();
                string DEPENDENCIADESTINO = dgvListado.CurrentRow.Cells[8].Value.ToString();
                string ESTADO = dgvListado.CurrentRow.Cells[9].Value.ToString();
                DateTime FECHAINIINV = DateTime.Parse(dgvListado.CurrentRow.Cells[10].Value.ToString());
                DateTime FECHAFININV = DateTime.Parse(dgvListado.CurrentRow.Cells[11].Value.ToString());
                int DIASINVESTIGACION = int.Parse(dgvListado.CurrentRow.Cells[12].Value.ToString());
                DateTime FECHAINIPRO = DateTime.Parse(dgvListado.CurrentRow.Cells[13].Value.ToString());
                DateTime FECHAFINPRO = DateTime.Parse(dgvListado.CurrentRow.Cells[14].Value.ToString());
                int DIASPRORROGA = int.Parse(dgvListado.CurrentRow.Cells[15].Value.ToString());
                DateTime FECHAINIEXT = DateTime.Parse(dgvListado.CurrentRow.Cells[16].Value.ToString());
                DateTime FECHAFINEXT = DateTime.Parse(dgvListado.CurrentRow.Cells[17].Value.ToString());
                int DIASPRORROGAEXTRAORDINARIA = int.Parse(dgvListado.CurrentRow.Cells[18].Value.ToString());

                PasarDatos(
                    ID
                    , CASO
                    , FECHAINGRESO
                    , FISCAL
                    , DIASRETRASOAPERTURAINVESTIGACION
                    , DEPENDENCIAORIGEN
                    , OFICIOORIGEN
                    , SEDE
                    , DEPENDENCIADESTINO
                    , ESTADO
                    , FECHAINIINV
                    , FECHAFININV
                    , DIASINVESTIGACION
                    , FECHAINIPRO
                    , FECHAFINPRO
                    , DIASPRORROGA
                    , FECHAINIEXT
                    , FECHAFINEXT
                    , DIASPRORROGAEXTRAORDINARIA
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarDependenciaOrigen();
            CargarDependenciaDestino();
            CargarSede();
            CargarEstado();
        }










    }
}
