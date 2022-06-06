namespace warCWBv2
{
    partial class GameScreen
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
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Skip = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_Objective = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(266, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 720);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // bt_Skip
            // 
            this.bt_Skip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Skip.Location = new System.Drawing.Point(29, 554);
            this.bt_Skip.Name = "bt_Skip";
            this.bt_Skip.Size = new System.Drawing.Size(207, 62);
            this.bt_Skip.TabIndex = 4;
            this.bt_Skip.Text = "Pular Turno";
            this.bt_Skip.UseVisualStyleBackColor = true;
            this.bt_Skip.Click += new System.EventHandler(this.bt_Skip_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.bt_Objective);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 131);
            this.panel2.TabIndex = 5;
            // 
            // bt_Objective
            // 
            this.bt_Objective.Location = new System.Drawing.Point(178, 29);
            this.bt_Objective.Name = "bt_Objective";
            this.bt_Objective.Size = new System.Drawing.Size(70, 70);
            this.bt_Objective.TabIndex = 6;
            this.bt_Objective.Text = "Mostrar Objetivo";
            this.bt_Objective.UseVisualStyleBackColor = true;
            this.bt_Objective.Click += new System.EventHandler(this.bt_Objective_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(720, 719);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_Skip);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameScreen";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_Skip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_Objective;
    }
}