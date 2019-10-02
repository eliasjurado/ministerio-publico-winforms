namespace appInvestigacionPreliminar
{
    partial class Impresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impresion));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroCarpeta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.picSi = new System.Windows.Forms.PictureBox();
            this.picBuscar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Impresión";
            // 
            // txtNroCarpeta
            // 
            this.txtNroCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNroCarpeta.Location = new System.Drawing.Point(149, 135);
            this.txtNroCarpeta.Name = "txtNroCarpeta";
            this.txtNroCarpeta.ReadOnly = true;
            this.txtNroCarpeta.Size = new System.Drawing.Size(121, 21);
            this.txtNroCarpeta.TabIndex = 103;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(16, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 101;
            this.label8.Text = "Archivo Nro.";
            // 
            // picSi
            // 
            this.picSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSi.Image = ((System.Drawing.Image)(resources.GetObject("picSi.Image")));
            this.picSi.Location = new System.Drawing.Point(187, 183);
            this.picSi.Name = "picSi";
            this.picSi.Size = new System.Drawing.Size(50, 50);
            this.picSi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSi.TabIndex = 122;
            this.picSi.TabStop = false;
            // 
            // picBuscar
            // 
            this.picBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBuscar.Image = global::appInvestigacionPreliminar.Properties.Resources.glass;
            this.picBuscar.Location = new System.Drawing.Point(276, 135);
            this.picBuscar.Name = "picBuscar";
            this.picBuscar.Size = new System.Drawing.Size(21, 21);
            this.picBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuscar.TabIndex = 116;
            this.picBuscar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.printer;
            this.pictureBox1.Location = new System.Drawing.Point(176, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // Impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 249);
            this.Controls.Add(this.picSi);
            this.Controls.Add(this.picBuscar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNroCarpeta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Impresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archivo";
            ((System.ComponentModel.ISupportInitialize)(this.picSi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNroCarpeta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picSi;
    }
}