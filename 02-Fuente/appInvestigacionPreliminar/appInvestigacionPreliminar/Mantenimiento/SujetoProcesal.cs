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
    public partial class SujetoProcesal : Form
    {
        public SujetoProcesal()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------
        private DAO.SexoDAO sexo = new DAO.SexoDAO();
        
        private void CargarSexo()
        {
            DataTable dtb = sexo.ListarSexo();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboSex.DataSource = dtb;
            cboSex.DisplayMember = "DESCRIPCION";
            cboSex.ValueMember = "ID";
            cboSex.DropDownStyle = ComboBoxStyle.DropDownList;

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
            cboIdentificacion.ValueMember = "ID";
            cboIdentificacion.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        //-----------------------------------------------------------
        private DAO.EstadoCivilDAO estadocivil = new DAO.EstadoCivilDAO();

        private void CargarEstadoCivil()
        {
            DataTable dtb = estadocivil.ListarEstadoCivil();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboEstadoCivil.DataSource = dtb;
            cboEstadoCivil.DisplayMember = "DESCRIPCION";
            cboEstadoCivil.ValueMember = "ID";
            cboEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        //-----------------------------------------------------------
        private DAO.InstruccionDAO gradoinstruccion = new DAO.InstruccionDAO();

        private void CargarGradoInstruccion()
        {
            DataTable dtb = gradoinstruccion.ListarGradoInstruccion();

            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DESCRIPCION"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboGradoInstruccion.DataSource = dtb;
            cboGradoInstruccion.DisplayMember = "DESCRIPCION";
            cboGradoInstruccion.ValueMember = "ID";
            cboGradoInstruccion.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        //-----------------------------------------------------------
        private DAO.UbigeoDAO ubigeo = new DAO.UbigeoDAO();
        
        private void CargarDepartamento()
        {
            DataTable dtb = ubigeo.ListarDepartamento();
            
            //Para evitar valor nulo
            DataRow dr = dtb.NewRow();
            dr["DEPARTAMENTO"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);


            cboDepartamento.DataSource = dtb;
            cboDepartamento.DisplayMember = "DEPARTAMENTO";
            cboDepartamento.ValueMember = "DEPARTAMENTO";
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void CargarProvincia()
        {
            
            DataTable dtb = ubigeo.ListarProvincia(cboDepartamento.SelectedValue.ToString());

            DataRow dr = dtb.NewRow();
            dr["PROVINCIA"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboProvincia.DataSource = dtb;
            cboProvincia.DisplayMember = "PROVINCIA";
            cboProvincia.ValueMember = "PROVINCIA";
            cboProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void CargarDistrito()
        {
            DataTable dtb = ubigeo.ListarDistrito(cboProvincia.SelectedValue.ToString());

            DataRow dr = dtb.NewRow();
            dr["DISTRITO"] = "Seleccione...";
            dtb.Rows.InsertAt(dr, 0);

            cboDistrito.DataSource = dtb;
            cboDistrito.DisplayMember = "DISTRITO";
            cboDistrito.ValueMember = "DISTRITO";
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void SujetoProcesal_Load(object sender, EventArgs e)
        {
            CargarSexo();
            CargarTipoDocId();
            CargarDepartamento();
            CargarEstadoCivil();
            CargarGradoInstruccion();
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvincia();
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistrito();
        }
        
    }
}
