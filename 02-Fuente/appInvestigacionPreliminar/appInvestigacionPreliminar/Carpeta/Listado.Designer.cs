namespace appInvestigacionPreliminar
{
    partial class Listado
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
            this.lblListado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDepDestino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSede = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepOrigen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picBuscarDelito = new System.Windows.Forms.PictureBox();
            this.txtDelito = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.picBuscarFechaIngreso = new System.Windows.Forms.PictureBox();
            this.picBuscarNroCarpeta = new System.Windows.Forms.PictureBox();
            this.txtNroCarpeta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarDelito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarFechaIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarNroCarpeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListado.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblListado.Location = new System.Drawing.Point(16, 10);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(59, 18);
            this.lblListado.TabIndex = 2;
            this.lblListado.Text = "Listado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.list;
            this.pictureBox1.Location = new System.Drawing.Point(478, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(709, 201);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(288, 21);
            this.cboEstado.TabIndex = 7;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(585, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Estado Carpeta";
            // 
            // cboDepDestino
            // 
            this.cboDepDestino.FormattingEnabled = true;
            this.cboDepDestino.Location = new System.Drawing.Point(709, 172);
            this.cboDepDestino.Name = "cboDepDestino";
            this.cboDepDestino.Size = new System.Drawing.Size(288, 21);
            this.cboDepDestino.TabIndex = 6;
            this.cboDepDestino.SelectedIndexChanged += new System.EventHandler(this.cboDepDestino_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(585, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Dependencia Destino";
            // 
            // cboSede
            // 
            this.cboSede.FormattingEnabled = true;
            this.cboSede.Location = new System.Drawing.Point(709, 143);
            this.cboSede.Name = "cboSede";
            this.cboSede.Size = new System.Drawing.Size(288, 21);
            this.cboSede.TabIndex = 5;
            this.cboSede.SelectedIndexChanged += new System.EventHandler(this.cboSede_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sede Investigación";
            // 
            // cboDepOrigen
            // 
            this.cboDepOrigen.FormattingEnabled = true;
            this.cboDepOrigen.Location = new System.Drawing.Point(709, 114);
            this.cboDepOrigen.Name = "cboDepOrigen";
            this.cboDepOrigen.Size = new System.Drawing.Size(288, 21);
            this.cboDepOrigen.TabIndex = 4;
            this.cboDepOrigen.SelectedIndexChanged += new System.EventHandler(this.cboDepOrigen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dependencia Origen";
            // 
            // picBuscarDelito
            // 
            this.picBuscarDelito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscarDelito.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscarDelito.Location = new System.Drawing.Point(404, 172);
            this.picBuscarDelito.Name = "picBuscarDelito";
            this.picBuscarDelito.Size = new System.Drawing.Size(21, 21);
            this.picBuscarDelito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscarDelito.TabIndex = 41;
            this.picBuscarDelito.TabStop = false;
            this.picBuscarDelito.Click += new System.EventHandler(this.picBuscarDelito_Click);
            // 
            // txtDelito
            // 
            this.txtDelito.Location = new System.Drawing.Point(127, 173);
            this.txtDelito.Name = "txtDelito";
            this.txtDelito.Size = new System.Drawing.Size(272, 20);
            this.txtDelito.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Delito";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(303, 201);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(96, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(168, 201);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(96, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Desde";
            // 
            // picBuscarFechaIngreso
            // 
            this.picBuscarFechaIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscarFechaIngreso.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscarFechaIngreso.Location = new System.Drawing.Point(405, 201);
            this.picBuscarFechaIngreso.Name = "picBuscarFechaIngreso";
            this.picBuscarFechaIngreso.Size = new System.Drawing.Size(21, 21);
            this.picBuscarFechaIngreso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscarFechaIngreso.TabIndex = 37;
            this.picBuscarFechaIngreso.TabStop = false;
            this.picBuscarFechaIngreso.Click += new System.EventHandler(this.picBuscarFechaIngreso_Click);
            // 
            // picBuscarNroCarpeta
            // 
            this.picBuscarNroCarpeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscarNroCarpeta.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscarNroCarpeta.Location = new System.Drawing.Point(405, 143);
            this.picBuscarNroCarpeta.Name = "picBuscarNroCarpeta";
            this.picBuscarNroCarpeta.Size = new System.Drawing.Size(21, 21);
            this.picBuscarNroCarpeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscarNroCarpeta.TabIndex = 36;
            this.picBuscarNroCarpeta.TabStop = false;
            this.picBuscarNroCarpeta.Click += new System.EventHandler(this.picBuscarNroCarpeta_Click);
            // 
            // txtNroCarpeta
            // 
            this.txtNroCarpeta.Location = new System.Drawing.Point(127, 144);
            this.txtNroCarpeta.Name = "txtNroCarpeta";
            this.txtNroCarpeta.Size = new System.Drawing.Size(272, 20);
            this.txtNroCarpeta.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Número Carpeta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Fecha Ingreso";
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(12, 238);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(1004, 215);
            this.dgvListado.TabIndex = 8;
            this.dgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Inicio";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(127, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Listar Todos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboDepDestino);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboSede);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboDepOrigen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picBuscarDelito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.txtDelito);
            this.Controls.Add(this.picBuscarNroCarpeta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.txtNroCarpeta);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picBuscarFechaIngreso);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Listado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carpeta";
            this.Load += new System.EventHandler(this.Listado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarDelito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarFechaIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscarNroCarpeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDepDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSede;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBuscarDelito;
        private System.Windows.Forms.TextBox txtDelito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBuscarFechaIngreso;
        private System.Windows.Forms.PictureBox picBuscarNroCarpeta;
        private System.Windows.Forms.TextBox txtNroCarpeta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

