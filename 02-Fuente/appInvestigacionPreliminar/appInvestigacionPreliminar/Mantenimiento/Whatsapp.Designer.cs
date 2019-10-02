namespace appInvestigacionPreliminar.Mantenimiento
{
    partial class Whatsapp
    {
        /// <summary>
        /// Required designer variable.
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
            this.txtWsp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picEnviar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEnviar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWsp
            // 
            this.txtWsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtWsp.Location = new System.Drawing.Point(37, 135);
            this.txtWsp.Multiline = true;
            this.txtWsp.Name = "txtWsp";
            this.txtWsp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWsp.Size = new System.Drawing.Size(350, 122);
            this.txtWsp.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Whatsapp";
            // 
            // picEnviar
            // 
            this.picEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEnviar.Image = global::appInvestigacionPreliminar.Properties.Resources.check;
            this.picEnviar.Location = new System.Drawing.Point(187, 275);
            this.picEnviar.Name = "picEnviar";
            this.picEnviar.Size = new System.Drawing.Size(50, 50);
            this.picEnviar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEnviar.TabIndex = 47;
            this.picEnviar.TabStop = false;
            this.picEnviar.Click += new System.EventHandler(this.picEnviar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appInvestigacionPreliminar.Properties.Resources.wsp;
            this.pictureBox1.Location = new System.Drawing.Point(176, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // Whatsapp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 337);
            this.Controls.Add(this.picEnviar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtWsp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Whatsapp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda";
            ((System.ComponentModel.ISupportInitialize)(this.picEnviar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picEnviar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtWsp;
        private System.Windows.Forms.Label label1;
    }
}