namespace appInvestigacionPreliminar.Mantenimiento
{
    partial class SujetoProcesalLista
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
            this.dgvSujetoProcesal = new System.Windows.Forms.DataGridView();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.txtSujetoProcesal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSujetoProcesal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Sujeto Procesal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.userround;
            this.pictureBox1.Location = new System.Drawing.Point(452, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // dgvSujetoProcesal
            // 
            this.dgvSujetoProcesal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSujetoProcesal.Location = new System.Drawing.Point(17, 163);
            this.dgvSujetoProcesal.Name = "dgvSujetoProcesal";
            this.dgvSujetoProcesal.Size = new System.Drawing.Size(946, 336);
            this.dgvSujetoProcesal.TabIndex = 23;
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscar.Location = new System.Drawing.Point(395, 126);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(21, 21);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscar.TabIndex = 41;
            this.picBuscar.TabStop = false;
            // 
            // txtSujetoProcesal
            // 
            this.txtSujetoProcesal.Location = new System.Drawing.Point(154, 126);
            this.txtSujetoProcesal.Name = "txtSujetoProcesal";
            this.txtSujetoProcesal.Size = new System.Drawing.Size(235, 20);
            this.txtSujetoProcesal.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Nombres o Apellidos";
            // 
            // SujetoProcesalLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 511);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.txtSujetoProcesal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSujetoProcesal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SujetoProcesalLista";
            this.Text = "SujetoProcesalLista";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSujetoProcesal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSujetoProcesal;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.TextBox txtSujetoProcesal;
        private System.Windows.Forms.Label label3;
    }
}