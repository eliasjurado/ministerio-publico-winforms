namespace appInvestigacionPreliminar
{
    partial class AperturaInvestigacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AperturaInvestigacion));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNroCarpeta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picQuitarConsiderando = new System.Windows.Forms.PictureBox();
            this.picAgregarConsiderando = new System.Windows.Forms.PictureBox();
            this.txtConsiderando = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvConsiderando = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picQuitar = new System.Windows.Forms.PictureBox();
            this.picAgregarDispone = new System.Windows.Forms.PictureBox();
            this.txtDispone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDispone = new System.Windows.Forms.DataGridView();
            this.picAceptar = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNroDisposicion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitarConsiderando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregarConsiderando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsiderando)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregarDispone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Apertura";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.blackcheck;
            this.pictureBox1.Location = new System.Drawing.Point(334, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // txtNroCarpeta
            // 
            this.txtNroCarpeta.Location = new System.Drawing.Point(99, 115);
            this.txtNroCarpeta.Name = "txtNroCarpeta";
            this.txtNroCarpeta.ReadOnly = true;
            this.txtNroCarpeta.Size = new System.Drawing.Size(100, 20);
            this.txtNroCarpeta.TabIndex = 134;
            this.txtNroCarpeta.TextChanged += new System.EventHandler(this.txtNroCarpeta_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 126;
            this.label2.Text = "Carpeta Nro.";
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscar.Location = new System.Drawing.Point(205, 114);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(21, 21);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscar.TabIndex = 129;
            this.picBuscar.TabStop = false;
            this.picBuscar.Click += new System.EventHandler(this.picBuscar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 443);
            this.tabControl1.TabIndex = 135;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picQuitarConsiderando);
            this.tabPage2.Controls.Add(this.picAgregarConsiderando);
            this.tabPage2.Controls.Add(this.txtConsiderando);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgvConsiderando);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Considerando";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picQuitarConsiderando
            // 
            this.picQuitarConsiderando.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuitarConsiderando.Image = global::appInvestigacionPreliminar.Properties.Resources.remove;
            this.picQuitarConsiderando.Location = new System.Drawing.Point(369, 89);
            this.picQuitarConsiderando.Name = "picQuitarConsiderando";
            this.picQuitarConsiderando.Size = new System.Drawing.Size(21, 21);
            this.picQuitarConsiderando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuitarConsiderando.TabIndex = 138;
            this.picQuitarConsiderando.TabStop = false;
            this.picQuitarConsiderando.Click += new System.EventHandler(this.picQuitarConsiderando_Click);
            // 
            // picAgregarConsiderando
            // 
            this.picAgregarConsiderando.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregarConsiderando.Image = global::appInvestigacionPreliminar.Properties.Resources.add;
            this.picAgregarConsiderando.Location = new System.Drawing.Point(342, 89);
            this.picAgregarConsiderando.Name = "picAgregarConsiderando";
            this.picAgregarConsiderando.Size = new System.Drawing.Size(21, 21);
            this.picAgregarConsiderando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAgregarConsiderando.TabIndex = 139;
            this.picAgregarConsiderando.TabStop = false;
            this.picAgregarConsiderando.Click += new System.EventHandler(this.picAgregarConsiderando_Click);
            // 
            // txtConsiderando
            // 
            this.txtConsiderando.Location = new System.Drawing.Point(8, 27);
            this.txtConsiderando.Multiline = true;
            this.txtConsiderando.Name = "txtConsiderando";
            this.txtConsiderando.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsiderando.Size = new System.Drawing.Size(717, 56);
            this.txtConsiderando.TabIndex = 137;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Añadir Párrafo";
            // 
            // dgvConsiderando
            // 
            this.dgvConsiderando.AllowUserToAddRows = false;
            this.dgvConsiderando.AllowUserToDeleteRows = false;
            this.dgvConsiderando.AllowUserToResizeColumns = false;
            this.dgvConsiderando.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsiderando.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsiderando.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsiderando.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConsiderando.Location = new System.Drawing.Point(8, 116);
            this.dgvConsiderando.Name = "dgvConsiderando";
            this.dgvConsiderando.Size = new System.Drawing.Size(717, 295);
            this.dgvConsiderando.TabIndex = 135;
            this.dgvConsiderando.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsiderando_CellContentDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picQuitar);
            this.tabPage3.Controls.Add(this.picAgregarDispone);
            this.tabPage3.Controls.Add(this.txtDispone);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.dgvDispone);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(732, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Diligencias";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // picQuitar
            // 
            this.picQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuitar.Image = global::appInvestigacionPreliminar.Properties.Resources.remove;
            this.picQuitar.Location = new System.Drawing.Point(369, 89);
            this.picQuitar.Name = "picQuitar";
            this.picQuitar.Size = new System.Drawing.Size(21, 21);
            this.picQuitar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuitar.TabIndex = 138;
            this.picQuitar.TabStop = false;
            this.picQuitar.Click += new System.EventHandler(this.picQuitarDispone_Click);
            // 
            // picAgregarDispone
            // 
            this.picAgregarDispone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAgregarDispone.Image = global::appInvestigacionPreliminar.Properties.Resources.add;
            this.picAgregarDispone.Location = new System.Drawing.Point(342, 89);
            this.picAgregarDispone.Name = "picAgregarDispone";
            this.picAgregarDispone.Size = new System.Drawing.Size(21, 21);
            this.picAgregarDispone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAgregarDispone.TabIndex = 139;
            this.picAgregarDispone.TabStop = false;
            this.picAgregarDispone.Click += new System.EventHandler(this.picAgregarDispone_Click);
            // 
            // txtDispone
            // 
            this.txtDispone.Location = new System.Drawing.Point(8, 27);
            this.txtDispone.Multiline = true;
            this.txtDispone.Name = "txtDispone";
            this.txtDispone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDispone.Size = new System.Drawing.Size(717, 56);
            this.txtDispone.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Añadir Párrafo";
            // 
            // dgvDispone
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDispone.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDispone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDispone.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDispone.Location = new System.Drawing.Point(8, 116);
            this.dgvDispone.Name = "dgvDispone";
            this.dgvDispone.Size = new System.Drawing.Size(717, 295);
            this.dgvDispone.TabIndex = 135;
            this.dgvDispone.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispone_CellContentDoubleClick);
            // 
            // picAceptar
            // 
            this.picAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAceptar.Image = ((System.Drawing.Image)(resources.GetObject("picAceptar.Image")));
            this.picAceptar.Location = new System.Drawing.Point(346, 595);
            this.picAceptar.Name = "picAceptar";
            this.picAceptar.Size = new System.Drawing.Size(50, 50);
            this.picAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAceptar.TabIndex = 136;
            this.picAceptar.TabStop = false;
            this.picAceptar.Click += new System.EventHandler(this.picAceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "Emisión";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmision.Location = new System.Drawing.Point(584, 116);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(100, 20);
            this.dtpEmision.TabIndex = 137;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "Disposición Nro.";
            // 
            // txtNroDisposicion
            // 
            this.txtNroDisposicion.Location = new System.Drawing.Point(377, 115);
            this.txtNroDisposicion.Name = "txtNroDisposicion";
            this.txtNroDisposicion.ReadOnly = true;
            this.txtNroDisposicion.Size = new System.Drawing.Size(100, 20);
            this.txtNroDisposicion.TabIndex = 134;
            // 
            // AperturaInvestigacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 650);
            this.Controls.Add(this.dtpEmision);
            this.Controls.Add(this.picAceptar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtNroDisposicion);
            this.Controls.Add(this.txtNroCarpeta);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AperturaInvestigacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Investigación";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitarConsiderando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregarConsiderando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsiderando)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAgregarDispone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNroCarpeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picQuitarConsiderando;
        private System.Windows.Forms.PictureBox picAgregarConsiderando;
        private System.Windows.Forms.TextBox txtConsiderando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvConsiderando;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox picQuitar;
        private System.Windows.Forms.PictureBox picAgregarDispone;
        private System.Windows.Forms.TextBox txtDispone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDispone;
        private System.Windows.Forms.PictureBox picAceptar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNroDisposicion;
    }
}