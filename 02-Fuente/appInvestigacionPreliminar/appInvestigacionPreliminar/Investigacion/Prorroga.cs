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
    public partial class DisposicionProrroga : Form
    {
        public DisposicionProrroga()
        {
            InitializeComponent();
        }
        private DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();

    }
}
