namespace appInvestigacionPreliminar.Mantenimiento
{
    partial class Documento
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvDocumento = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.picCancelar2 = new System.Windows.Forms.PictureBox();
            this.picAceptar2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Documento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.file;
            this.pictureBox1.Location = new System.Drawing.Point(206, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Nombre";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(93, 113);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(71, 20);
            this.txtId.TabIndex = 12;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(93, 168);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(368, 20);
            this.txtDescripcion.TabIndex = 12;
            // 
            // dgvDocumento
            // 
            this.dgvDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumento.Location = new System.Drawing.Point(17, 260);
            this.dgvDocumento.Name = "dgvDocumento";
            this.dgvDocumento.Size = new System.Drawing.Size(453, 292);
            this.dgvDocumento.TabIndex = 13;
            this.dgvDocumento.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumento_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tipo";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(93, 140);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(185, 21);
            this.cboTipoDocumento.TabIndex = 14;
            // 
            // picCancelar2
            // 
            this.picCancelar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCancelar2.Image = global::appInvestigacionPreliminar.Properties.Resources.cancel;
            this.picCancelar2.Location = new System.Drawing.Point(299, 200);
            this.picCancelar2.Name = "picCancelar2";
            this.picCancelar2.Size = new System.Drawing.Size(50, 50);
            this.picCancelar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCancelar2.TabIndex = 17;
            this.picCancelar2.TabStop = false;
            this.picCancelar2.Click += new System.EventHandler(this.picCancelar2_Click);
            // 
            // picAceptar2
            // 
            this.picAceptar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAceptar2.Image = global::appInvestigacionPreliminar.Properties.Resources.check;
            this.picAceptar2.Location = new System.Drawing.Point(135, 200);
            this.picAceptar2.Name = "picAceptar2";
            this.picAceptar2.Size = new System.Drawing.Size(50, 50);
            this.picAceptar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAceptar2.TabIndex = 16;
            this.picAceptar2.TabStop = false;
            this.picAceptar2.Click += new System.EventHandler(this.picAceptar2_Click);
            // 
            // Documento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 564);
            this.Controls.Add(this.picCancelar2);
            this.Controls.Add(this.picAceptar2);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.dgvDocumento);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Documento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matenimiento";
            this.Load += new System.EventHandler(this.Documento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancelar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAceptar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvDocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.PictureBox picCancelar2;
        private System.Windows.Forms.PictureBox picAceptar2;
    }
}