namespace warCWBv2
{
    partial class Config
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picOff = new System.Windows.Forms.PictureBox();
            this.picOn = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 118);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("3ds", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("3ds", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aúdio";
            // 
            // picOff
            // 
            this.picOff.BackgroundImage = global::warCWBv2.Properties.Resources.mute;
            this.picOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOff.Location = new System.Drawing.Point(196, 199);
            this.picOff.Name = "picOff";
            this.picOff.Size = new System.Drawing.Size(73, 64);
            this.picOff.TabIndex = 3;
            this.picOff.TabStop = false;
            this.picOff.Click += new System.EventHandler(this.picOff_Click);
            // 
            // picOn
            // 
            this.picOn.BackgroundImage = global::warCWBv2.Properties.Resources.volume;
            this.picOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOn.Location = new System.Drawing.Point(54, 199);
            this.picOn.Name = "picOn";
            this.picOn.Size = new System.Drawing.Size(73, 64);
            this.picOn.TabIndex = 2;
            this.picOn.TabStop = false;
            this.picOn.Click += new System.EventHandler(this.picOn_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 326);
            this.Controls.Add(this.picOff);
            this.Controls.Add(this.picOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configurações";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picOn;
        private System.Windows.Forms.PictureBox picOff;
    }
}