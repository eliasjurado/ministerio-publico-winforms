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

namespace appInvestigacionPreliminar
{
    public partial class Container : Form
    {
        public Container()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------
        //Salir
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //MantenimientoDependencia
        private void button2_Click(object sender, EventArgs e)
        {
            Dependencia f = new Dependencia();
            f.Show();
        }
        //MantenimientoUsuario
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            MantenimientoFiscal f = new MantenimientoFiscal();
            f.Show();
        }
         //MantenimientoAnio
        private void btnAnio_Click(object sender, EventArgs e)
        {
            Mantenimiento.Anio f = new Mantenimiento.Anio();
            f.Show();
        }
        //MantenimientoDocumento
        private void btnDocumento_Click(object sender, EventArgs e)
        {
            Mantenimiento.Documento f = new Mantenimiento.Documento();
            f.Show();
        }
        //MantenimientoSujetoProcesal
        private void btnSujetoProcesal_Click(object sender, EventArgs e)
        {
            Mantenimiento.SujetoProcesal f = new Mantenimiento.SujetoProcesal();
            f.Show();
        }
        //-----------------------------------------------------------------------------
        //Listar Carpeta
        private void Listado_Click(object sender, EventArgs e)
        {
            Listado f = new Listado();
            f.Show();
        }
        //Eliminar Carpeta
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarpetaEliminar f = new CarpetaEliminar();
            f.Show();
        }
        //CarpetaAlertas
        private void Alertas_Click(object sender, EventArgs e)
        {
            AlertasBackup f = new AlertasBackup();
            f.Show();
        }
        //-----------------------------------------------------------------------------
        //InvestigacionIngreso
        private void ingresarCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso f = new Ingreso();
            f.Show();
        }
        //InvestigacionaCalificación
        private void Calificacion_Click(object sender, EventArgs e)
        {
            Investigacion.Calificacion f = new Investigacion.Calificacion();
            f.Show();
        }
        //InvestigacionaApertura
        private void label8_Click(object sender, EventArgs e)
        {
            AperturaInvestigacion f = new AperturaInvestigacion();
            f.Show();
        }
        //InvestigacionPrórroga
        private void disposiciónDePrórrogaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposicionProrroga f = new DisposicionProrroga();
            f.Show();
        }       
        //-----------------------------------------------------------------------------
        //ArchivoEdicion
        private void Edicion_Click(object sender, EventArgs e)
        {
            Archivo.Edicion f = new Archivo.Edicion();
            f.Show();
        }
        //ArchivoImpresion
        private void oficiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresion f = new Impresion();
            f.Show();
        }
        //-----------------------------------------------------------------------------
        //El cursor cambia el color los botones
        private void btnUsuario_MouseEnter(object sender, EventArgs e)
        {
            this.btnUsuario.BackColor = Color.Silver;
        }
        private void btnUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.btnUsuario.BackColor = Color.Gray;
        }
        //El container se adapta a la pantalla sin perder la barra de tareas
        private void Container_Load(object sender, EventArgs e)
        {
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size; 
        }
        //Adapta controles según se redimensiona el formulario
        public void AdaptarControles() {
            pictureBox64.Height = this.Size.Height;
            picRedSoc1.Location = new Point(this.Size.Width - 170, picRedSoc1.Location.Y);
            picWsp.Location = new Point(this.Size.Width - 160, picWsp.Location.Y);
            lblAyuda.Location = new Point(this.Size.Width - 125, lblAyuda.Location.Y);
            //picFb.Location = new Point(this.Size.Width - 105, picFb.Location.Y);
            //picInf.Location = new Point(this.Size.Width - 70, picInf.Location.Y);
        }
        private void Container_Resize(object sender, EventArgs e)
        {
            AdaptarControles();
        }

        private DAO.FiscalDAO usuario = new DAO.FiscalDAO();
        private void picWsp_Click(object sender, EventArgs e)
        {
            //Mantenimiento.Whatsapp f = new Mantenimiento.Whatsapp();
            //f.Show();
            DataTable dtb = usuario.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Celular = row[3].ToString();
            Process.Start("https://api.whatsapp.com/send?phone=51940285514&text=" + "Necesito%20ayuda.%20" + Nombre + "%20-%20" + Celular);
        }

        private void AbstencionIncoacion_Click(object sender, EventArgs e)
        {
            Investigacion.AbstencionIncoacion f = new Investigacion.AbstencionIncoacion();
            f.Show();
        }

        private void Incautacion_Click(object sender, EventArgs e)
        {
            Investigacion.Incautacion f = new Investigacion.Incautacion();
            f.Show();
        }

        private void PrisionPreventiva_Click(object sender, EventArgs e)
        {
            Investigacion.PrisionPreventiva f = new Investigacion.PrisionPreventiva();
            f.Show();
        }


        //-----------------------------------------------------------------------------
    }
}
