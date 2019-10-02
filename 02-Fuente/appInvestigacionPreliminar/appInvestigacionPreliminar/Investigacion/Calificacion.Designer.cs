namespace appInvestigacionPreliminar.Investigacion
{
    partial class Calificacion
    {
        /// <summary>
        /// Required designer imputados.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calificacion));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSi = new System.Windows.Forms.PictureBox();
            this.cboDepDestino = new System.Windows.Forms.ComboBox();
            this.cboSede = new System.Windows.Forms.ComboBox();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.dtpFinInvestigacion = new System.Windows.Forms.DateTimePicker();
            this.dtpIniInvestigacion = new System.Windows.Forms.DateTimePicker();
            this.txtDiasInvestigacion = new System.Windows.Forms.TextBox();
            this.txtNroCarpeta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEspecifico = new System.Windows.Forms.TextBox();
            this.txtGenerico = new System.Windows.Forms.TextBox();
            this.txtSubgenerico = new System.Windows.Forms.TextBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picQuitar = new System.Windows.Forms.PictureBox();
            this.picAgregar = new System.Windows.Forms.PictureBox();
            this.dgvDelito = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCita = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtInciso = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboTipoDelito = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelito)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Calificación";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.star;
            this.pictureBox1.Location = new System.Drawing.Point(189, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // picSi
            // 
            this.picSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSi.Image = ((System.Drawing.Image)(resources.GetObject("picSi.Image")));
            this.picSi.Location = new System.Drawing.Point(198, 695);
            this.picSi.Name = "picSi";
            this.picSi.Size = new System.Drawing.Size(50, 50);
            this.picSi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSi.TabIndex = 123;
            this.picSi.TabStop = false;
            this.picSi.Click += new System.EventHandler(this.picAceptar_Click);
            // 
            // cboDepDestino
            // 
            this.cboDepDestino.FormattingEnabled = true;
            this.cboDepDestino.Location = new System.Drawing.Point(130, 164);
            this.cboDepDestino.Name = "cboDepDestino";
            this.cboDepDestino.Size = new System.Drawing.Size(307, 21);
            this.cboDepDestino.TabIndex = 1;
            this.cboDepDestino.SelectedIndexChanged += new System.EventHandler(this.cboDepDestino_SelectedIndexChanged);
            // 
            // cboSede
            // 
            this.cboSede.FormattingEnabled = true;
            this.cboSede.Location = new System.Drawing.Point(130, 136);
            this.cboSede.Name = "cboSede";
            this.cboSede.Size = new System.Drawing.Size(116, 21);
            this.cboSede.TabIndex = 0;
            this.cboSede.SelectedIndexChanged += new System.EventHandler(this.cboSede_SelectedIndexChanged);
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscar.Location = new System.Drawing.Point(252, 109);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(21, 21);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscar.TabIndex = 174;
            this.picBuscar.TabStop = false;
            this.picBuscar.Click += new System.EventHandler(this.picBuscar_Click);
            // 
            // dtpFinInvestigacion
            // 
            this.dtpFinInvestigacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinInvestigacion.Location = new System.Drawing.Point(130, 248);
            this.dtpFinInvestigacion.Name = "dtpFinInvestigacion";
            this.dtpFinInvestigacion.Size = new System.Drawing.Size(116, 20);
            this.dtpFinInvestigacion.TabIndex = 3;
            this.dtpFinInvestigacion.ValueChanged += new System.EventHandler(this.dtpIniInvestigacion_ValueChanged);
            // 
            // dtpIniInvestigacion
            // 
            this.dtpIniInvestigacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIniInvestigacion.Location = new System.Drawing.Point(130, 221);
            this.dtpIniInvestigacion.Name = "dtpIniInvestigacion";
            this.dtpIniInvestigacion.Size = new System.Drawing.Size(116, 20);
            this.dtpIniInvestigacion.TabIndex = 2;
            this.dtpIniInvestigacion.ValueChanged += new System.EventHandler(this.dtpIniInvestigacion_ValueChanged);
            // 
            // txtDiasInvestigacion
            // 
            this.txtDiasInvestigacion.Location = new System.Drawing.Point(130, 276);
            this.txtDiasInvestigacion.Name = "txtDiasInvestigacion";
            this.txtDiasInvestigacion.ReadOnly = true;
            this.txtDiasInvestigacion.Size = new System.Drawing.Size(116, 20);
            this.txtDiasInvestigacion.TabIndex = 4;
            // 
            // txtNroCarpeta
            // 
            this.txtNroCarpeta.Location = new System.Drawing.Point(130, 109);
            this.txtNroCarpeta.Name = "txtNroCarpeta";
            this.txtNroCarpeta.ReadOnly = true;
            this.txtNroCarpeta.Size = new System.Drawing.Size(116, 20);
            this.txtNroCarpeta.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Días Hábiles";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fin Investigación";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Inicio Investigación";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 30);
            this.label11.TabIndex = 16;
            this.label11.Text = "Dependencia Destino";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sede de Investigación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Carpeta Nro.";
            // 
            // txtEspecifico
            // 
            this.txtEspecifico.Location = new System.Drawing.Point(130, 428);
            this.txtEspecifico.Name = "txtEspecifico";
            this.txtEspecifico.Size = new System.Drawing.Size(307, 20);
            this.txtEspecifico.TabIndex = 9;
            this.txtEspecifico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            // 
            // txtGenerico
            // 
            this.txtGenerico.Location = new System.Drawing.Point(130, 376);
            this.txtGenerico.Name = "txtGenerico";
            this.txtGenerico.Size = new System.Drawing.Size(307, 20);
            this.txtGenerico.TabIndex = 7;
            this.txtGenerico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            // 
            // txtSubgenerico
            // 
            this.txtSubgenerico.Location = new System.Drawing.Point(130, 402);
            this.txtSubgenerico.Name = "txtSubgenerico";
            this.txtSubgenerico.Size = new System.Drawing.Size(307, 20);
            this.txtSubgenerico.TabIndex = 8;
            this.txtSubgenerico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras_KeyPress);
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(130, 350);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(116, 20);
            this.txtArticulo.TabIndex = 6;
            this.txtArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Específico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Genérico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Subgenérico";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 353);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Artículo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Delitos y Agravantes";
            // 
            // picQuitar
            // 
            this.picQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuitar.Image = global::appInvestigacionPreliminar.Properties.Resources.remove;
            this.picQuitar.Location = new System.Drawing.Point(416, 544);
            this.picQuitar.Name = "picQuitar";
            this.picQuitar.Size = new System.Drawing.Size(21, 21);
            this.picQuitar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuitar.TabIndex = 184;
            this.picQuitar.TabStop = false;
            this.picQuitar.Click += new System.EventHandler(this.picQuitar_Click);
            // 
            // picAgregar
            // 
            this.picAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregar.Image = global::appInvestigacionPreliminar.Properties.Resources.add;
            this.picAgregar.Location = new System.Drawing.Point(389, 544);
            this.picAgregar.Name = "picAgregar";
            this.picAgregar.Size = new System.Drawing.Size(21, 21);
            this.picAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAgregar.TabIndex = 185;
            this.picAgregar.TabStop = false;
            this.picAgregar.Click += new System.EventHandler(this.picAgregar_Click);
            // 
            // dgvDelito
            // 
            this.dgvDelito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelito.Location = new System.Drawing.Point(15, 571);
            this.dgvDelito.Name = "dgvDelito";
            this.dgvDelito.Size = new System.Drawing.Size(423, 118);
            this.dgvDelito.TabIndex = 12;
            this.dgvDelito.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDelito_CellContentDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 483);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Cita";
            // 
            // txtCita
            // 
            this.txtCita.Location = new System.Drawing.Point(130, 480);
            this.txtCita.Multiline = true;
            this.txtCita.Name = "txtCita";
            this.txtCita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCita.Size = new System.Drawing.Size(307, 58);
            this.txtCita.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 457);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Inciso";
            // 
            // txtInciso
            // 
            this.txtInciso.Location = new System.Drawing.Point(130, 454);
            this.txtInciso.Name = "txtInciso";
            this.txtInciso.Size = new System.Drawing.Size(116, 20);
            this.txtInciso.TabIndex = 10;
            this.txtInciso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 327);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Tipo";
            // 
            // cboTipoDelito
            // 
            this.cboTipoDelito.FormattingEnabled = true;
            this.cboTipoDelito.Location = new System.Drawing.Point(130, 323);
            this.cboTipoDelito.Name = "cboTipoDelito";
            this.cboTipoDelito.Size = new System.Drawing.Size(116, 21);
            this.cboTipoDelito.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 199);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(202, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Plazo para la dependencia policial";
            // 
            // Calificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 749);
            this.Controls.Add(this.picQuitar);
            this.Controls.Add(this.picAgregar);
            this.Controls.Add(this.dgvDelito);
            this.Controls.Add(this.txtCita);
            this.Controls.Add(this.txtInciso);
            this.Controls.Add(this.txtEspecifico);
            this.Controls.Add(this.txtGenerico);
            this.Controls.Add(this.txtSubgenerico);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboDepDestino);
            this.Controls.Add(this.cboTipoDelito);
            this.Controls.Add(this.cboSede);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.dtpFinInvestigacion);
            this.Controls.Add(this.dtpIniInvestigacion);
            this.Controls.Add(this.txtDiasInvestigacion);
            this.Controls.Add(this.txtNroCarpeta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picSi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Calificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Investigación";
            this.Load += new System.EventHandler(this.Calificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSi;
        private System.Windows.Forms.ComboBox cboDepDestino;
        private System.Windows.Forms.ComboBox cboSede;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.DateTimePicker dtpFinInvestigacion;
        private System.Windows.Forms.DateTimePicker dtpIniInvestigacion;
        private System.Windows.Forms.TextBox txtDiasInvestigacion;
        private System.Windows.Forms.TextBox txtNroCarpeta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEspecifico;
        private System.Windows.Forms.TextBox txtGenerico;
        private System.Windows.Forms.TextBox txtSubgenerico;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picQuitar;
        private System.Windows.Forms.PictureBox picAgregar;
        private System.Windows.Forms.DataGridView dgvDelito;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCita;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInciso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboTipoDelito;
        private System.Windows.Forms.Label label16;
    }
}