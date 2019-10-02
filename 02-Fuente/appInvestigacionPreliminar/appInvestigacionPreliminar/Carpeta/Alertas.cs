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
    public partial class AlertasBackup : Form
    {
        public AlertasBackup()
        {
            InitializeComponent();
        }

        private DAO.CarpetaDAO carpeta = new DAO.CarpetaDAO();

        private void Alerta15()
        {
            dgv15dias.DataSource = carpeta.ListarAlerta15();
            dgv15dias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv15dias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv15dias.AllowUserToAddRows = false;
            dgv15dias.AllowUserToDeleteRows = false;
            dgv15dias.ReadOnly = true;
        }
        private void Alerta30()
        {
            dgv30dias.DataSource = carpeta.ListarAlerta30();
            dgv30dias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv30dias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv30dias.AllowUserToAddRows = false;
            dgv30dias.AllowUserToDeleteRows = false;
            dgv30dias.ReadOnly = true;
        }
        private void Alerta60()
        {
            dgv60dias.DataSource = carpeta.ListarAlerta60();
            dgv60dias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv60dias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv60dias.AllowUserToAddRows = false;
            dgv60dias.AllowUserToDeleteRows = false;
            dgv60dias.ReadOnly = true;
        }
        private void Alerta180()
        {
            dgv180dias.DataSource = carpeta.ListarAlerta180();
            dgv180dias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv180dias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv180dias.AllowUserToAddRows = false;
            dgv180dias.AllowUserToDeleteRows = false;
            dgv180dias.ReadOnly = true;
        }

        private void Alertas_Load(object sender, EventArgs e)
        {
            Alerta15();
            Alerta30();
            Alerta60();
            Alerta180();
        }

    }
}
