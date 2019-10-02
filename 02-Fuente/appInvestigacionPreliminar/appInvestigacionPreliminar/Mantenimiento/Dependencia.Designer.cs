namespace appInvestigacionPreliminar
{
    partial class Dependencia
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvDependencia = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.picCancelar = new System.Windows.Forms.PictureBox();
            this.picAceptar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDependencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dependencia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(92, 116);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(65, 20);
            this.txtId.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(92, 145);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(370, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // dgvDependencia
            // 
            this.dgvDependencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDependencia.Location = new System.Drawing.Point(12, 271);
            this.dgvDependencia.Name = "dgvDependencia";
            this.dgvDependencia.Size = new System.Drawing.Size(462, 281);
            this.dgvDependencia.TabIndex = 2;
            this.dgvDependencia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDependencia_CellContentDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(92, 176);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(370, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // picCancelar
            // 
            this.picCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCancelar.Image = global::appInvestigacionPreliminar.Properties.Resources.cancel;
            this.picCancelar.Location = new System.Drawing.Point(313, 208);
            this.picCancelar.Name = "picCancelar";
            this.picCancelar.Size = new System.Drawing.Size(50, 50);
            this.picCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCancelar.TabIndex = 8;
            this.picCancelar.TabStop = false;
            this.picCancelar.Click += new System.EventHandler(this.picCancelar_Click);
            // 
            // picAceptar
            // 
            this.picAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAceptar.Image = global::appInvestigacionPreliminar.Properties.Resources.check;
            this.picAceptar.Location = new System.Drawing.Point(121, 209);
            this.picAceptar.Name = "picAceptar";
            this.picAceptar.Size = new System.Drawing.Size(50, 50);
            this.picAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAceptar.TabIndex = 8;
            this.picAceptar.TabStop = false;
            this.picAceptar.Click += new System.EventHandler(this.picAceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.hotel;
            this.pictureBox1.Location = new System.Drawing.Point(206, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Dependencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 564);
            this.Controls.Add(this.picCancelar);
            this.Controls.Add(this.picAceptar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvDependencia);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Dependencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Dependencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDependencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvDependencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.PictureBox picAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCancelar;
    }
}