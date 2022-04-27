namespace warCWBv2
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOn = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.PictureBox();
            this.mute = new System.Windows.Forms.PictureBox();
            this.btnOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mute)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOn.FlatAppearance.BorderSize = 0;
            this.btnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOn.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOn.Location = new System.Drawing.Point(122, 508);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(122, 44);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "Online";
            this.btnOn.UseVisualStyleBackColor = false;
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.Color.Transparent;
            this.volume.BackgroundImage = global::warCWBv2.Properties.Resources.volume;
            this.volume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volume.Location = new System.Drawing.Point(653, 26);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(46, 46);
            this.volume.TabIndex = 1;
            this.volume.TabStop = false;
            this.volume.Click += new System.EventHandler(this.volume_Click);
            // 
            // mute
            // 
            this.mute.BackColor = System.Drawing.Color.Transparent;
            this.mute.BackgroundImage = global::warCWBv2.Properties.Resources.mute;
            this.mute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mute.Location = new System.Drawing.Point(653, 26);
            this.mute.Name = "mute";
            this.mute.Size = new System.Drawing.Size(46, 46);
            this.mute.TabIndex = 2;
            this.mute.TabStop = false;
            this.mute.Visible = false;
            this.mute.Click += new System.EventHandler(this.mute_Click);
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOff.FlatAppearance.BorderSize = 0;
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOff.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOff.Location = new System.Drawing.Point(122, 558);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(122, 44);
            this.btnOff.TabIndex = 3;
            this.btnOff.Text = "Offline";
            this.btnOff.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::warCWBv2.Properties.Resources.imagemPrincipal_png;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(720, 720);
            this.ControlBox = false;
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.mute);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.btnOn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.PictureBox volume;
        private System.Windows.Forms.PictureBox mute;
        private System.Windows.Forms.Button btnOff;
    }
}

