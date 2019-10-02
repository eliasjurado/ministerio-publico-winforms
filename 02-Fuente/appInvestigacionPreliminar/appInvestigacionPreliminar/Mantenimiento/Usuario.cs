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
    public partial class MantenimientoFiscal : Form
    {
        public MantenimientoFiscal()
        {
            InitializeComponent();
        }
        private DAO.FiscalDAO fiscal = new DAO.FiscalDAO();

        private void CargarDatos()
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            txtNombre.Text = row[1].ToString();
            txtSiglas.Text = row[2].ToString();
            txtCelular.Text = row[3].ToString();
            txtEmail.Text = row[4].ToString();
            txtCasillaElectronica.Text = row[5].ToString();
            txtDistritoFiscal.Text = row[6].ToString();
            txtFiscalia.Text = row[7].ToString();
            txtModulo.Text = row[8].ToString();
            txtDespacho.Text = row[9].ToString();
            txtAbreviatura.Text = row[10].ToString();
            txtDireccion.Text = row[11].ToString();
        }
        private void MantenimientoFiscal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //Solo Letras 
        private void txtSiglas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)){e.Handled = false;}
            else if (Char.IsControl(e.KeyChar)){e.Handled = false;}
            else if (Char.IsSeparator(e.KeyChar)){e.Handled = false;}
            else{
                e.Handled = true;
                MessageBox.Show("Sólo letras");
            } 
        }
        //Solo números
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") { MessageBox.Show("Ingrese nombre"); }
            else if (txtNombre.Text.Length < 5) { MessageBox.Show("Nombre mínimo 5 caracteres"); }
            else if (txtSiglas.Text == "") { MessageBox.Show("Ingrese siglas"); }
            else if (txtSiglas.Text.Length < 2) { MessageBox.Show("Siglas mínimo 2 caracteres"); }
            else if (txtCelular.Text == "") { MessageBox.Show("Ingrese celular"); }
            else if (txtCelular.Text.Length < 9) { MessageBox.Show("Celular 9 números"); }
            else if (txtCelular.Text.Length > 9) { MessageBox.Show("Celular 9 números"); }
            else if (txtEmail.Text == "") { MessageBox.Show("Ingrese email"); }
            else if (txtEmail.Text.Length < 5) { MessageBox.Show("Email mínimo 5 caracteres"); }
            else if (txtDistritoFiscal.Text == "") { MessageBox.Show("Ingrese distrito fiscal"); }
            else if (txtDistritoFiscal.Text.Length < 5) { MessageBox.Show("Distrito Fiscal mínimo 5 caracteres"); }
            else if (txtFiscalia.Text == "") { MessageBox.Show("Ingrese fiscalía"); }
            else if (txtFiscalia.Text.Length < 5) { MessageBox.Show("Fiscalía mínimo 5 caracteres"); }
            else if (txtModulo.Text == "") { MessageBox.Show("Ingrese módulo"); }
            else if (txtModulo.Text.Length < 5) { MessageBox.Show("Módulo mínimo 5 caracteres"); }
            else if (txtDespacho.Text == "") { MessageBox.Show("Ingrese despacho"); }
            else if (txtDespacho.Text.Length < 5) { MessageBox.Show("Despacho mínimo 5 caracteres"); }
            else if (txtAbreviatura.Text == "") { MessageBox.Show("Ingrese abreviatura"); }
            else if (txtAbreviatura.Text.Length < 3) { MessageBox.Show("Abreviatura mínimo 3 caracteres"); }
            else if (txtDireccion.Text == "") { MessageBox.Show("Ingrese dirección"); }
            else if (txtDireccion.Text.Length < 5) { MessageBox.Show("Dirección mínimo 5 caracteres"); }
            else
            {
                string mensaje = fiscal.ActualizarFiscal(txtNombre.Text.Trim(), txtSiglas.Text.Trim(), txtCelular.Text.Trim(), txtEmail.Text.Trim(), txtCasillaElectronica.Text.Trim(),
                    txtDistritoFiscal.Text.Trim(), txtFiscalia.Text.Trim(), txtModulo.Text.Trim(), txtDespacho.Text.Trim(), txtAbreviatura.Text.Trim(), txtDireccion.Text.Trim());
                MessageBox.Show(mensaje);
                this.Close();
            }
        }

    }
}
