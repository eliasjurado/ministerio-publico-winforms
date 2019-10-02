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
    public partial class CarpetaEliminar : Form
    {
        public CarpetaEliminar()
        {
            InitializeComponent();
        }
        private DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();

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
        }

        private void PicBuscar_Click(object sender, EventArgs e)
        {
            Listado f1 = new Listado();
            f1.PasarDatos += new Listado.Almacenar_Datos(RecuperarDatos);
            f1.ShowDialog();
        }

        private void PicEliminar_Click(object sender, EventArgs e)
        {
            if (txtNroCarpeta.Text == "") { MessageBox.Show("Seleccione una carpeta haciendo click en la lupa"); }
            else
            {
                if (MessageBox.Show("¿Está seguro de eliminar la Carpeta Nro " + txtNroCarpeta.Text + " ? La información no se podrá recuperar.", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mensaje = carpeta.EliminarCarpeta(txtNroCarpeta.Text);
                    MessageBox.Show(mensaje);
                    this.Close();
                }
            }
        }
    }
}
