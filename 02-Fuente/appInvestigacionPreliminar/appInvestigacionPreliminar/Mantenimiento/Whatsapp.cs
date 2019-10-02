using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace appInvestigacionPreliminar.Mantenimiento
{
    public partial class Whatsapp : Form
    {
        public Whatsapp()
        {
            InitializeComponent();
        }

        private DAO.FiscalDAO usuario= new DAO.FiscalDAO();

        private void picEnviar_Click(object sender, EventArgs e)
        {
            DataTable dtb = usuario.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string Direccion = row[11].ToString();

            string msg = "Mensaje: "+txtWsp.Text + ". " + Nombre + " - " + Celular;

            Process.Start("https://api.whatsapp.com/send?phone=51940285514&text="+msg);
            this.Close();
        }
    }
}
