namespace appInvestigacionPreliminar
{
    partial class CarpetaEliminar
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
            this.txtNroCarpeta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.picEliminar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNroCarpeta
            // 
            this.txtNroCarpeta.Enabled = false;
            this.txtNroCarpeta.Location = new System.Drawing.Point(149, 135);
            this.txtNroCarpeta.Name = "txtNroCarpeta";
            this.txtNroCarpeta.ReadOnly = true;
            this.txtNroCarpeta.Size = new System.Drawing.Size(121, 20);
            this.txtNroCarpeta.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Carpeta Nro.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Eliminar";
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscar.Location = new System.Drawing.Point(276, 134);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(21, 21);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscar.TabIndex = 40;
            this.picBuscar.TabStop = false;
            this.picBuscar.Click += new System.EventHandler(this.PicBuscar_Click);
            // 
            // picEliminar
            // 
            this.picEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEliminar.Image = global::appInvestigacionPreliminar.Properties.Resources.cancel;
            this.picEliminar.Location = new System.Drawing.Point(187, 183);
            this.picEliminar.Name = "picEliminar";
            this.picEliminar.Size = new System.Drawing.Size(50, 50);
            this.picEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEliminar.TabIndex = 41;
            this.picEliminar.TabStop = false;
            this.picEliminar.Click += new System.EventHandler(this.PicEliminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.bin;
            this.pictureBox1.Location = new System.Drawing.Point(176, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // CarpetaEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 249);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.picEliminar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNroCarpeta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CarpetaEliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carpeta";
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNroCarpeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.PictureBox picEliminar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}