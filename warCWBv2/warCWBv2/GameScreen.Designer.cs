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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_Skip = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_Objective = new System.Windows.Forms.Button();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.picCards = new System.Windows.Forms.PictureBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // bt_Skip
            // 
            this.bt_Skip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Skip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Skip.Location = new System.Drawing.Point(29, 564);
            this.bt_Skip.Name = "bt_Skip";
            this.bt_Skip.Size = new System.Drawing.Size(207, 62);
            this.bt_Skip.TabIndex = 4;
            this.bt_Skip.Text = "Pular";
            this.bt_Skip.UseVisualStyleBackColor = true;
            this.bt_Skip.Click += new System.EventHandler(this.bt_Skip_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
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
            this.bt_Objective.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Objective.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Objective.Location = new System.Drawing.Point(14, 137);
            this.bt_Objective.Name = "bt_Objective";
            this.bt_Objective.Size = new System.Drawing.Size(70, 70);
            this.bt_Objective.TabIndex = 6;
            this.bt_Objective.Text = "Mostrar Objetivo";
            this.bt_Objective.UseVisualStyleBackColor = false;
            this.bt_Objective.Click += new System.EventHandler(this.bt_Objective_Click);
            // 
            // picMap
            // 
            this.picMap.BackgroundImage = global::warCWBv2.Properties.Resources.iconmap;
            this.picMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMap.Location = new System.Drawing.Point(173, 480);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(64, 68);
            this.picMap.TabIndex = 8;
            this.picMap.TabStop = false;
            this.picMap.Click += new System.EventHandler(this.picMap_Click);
            // 
            // picCards
            // 
            this.picCards.BackgroundImage = global::warCWBv2.Properties.Resources.flash_cards;
            this.picCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCards.Location = new System.Drawing.Point(102, 480);
            this.picCards.Name = "picCards";
            this.picCards.Size = new System.Drawing.Size(64, 68);
            this.picCards.TabIndex = 7;
            this.picCards.TabStop = false;
            this.picCards.Click += new System.EventHandler(this.picCards_Click);
            // 
            // picHelp
            // 
            this.picHelp.BackgroundImage = global::warCWBv2.Properties.Resources.question;
            this.picHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelp.Location = new System.Drawing.Point(30, 480);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(64, 68);
            this.picHelp.TabIndex = 6;
            this.picHelp.TabStop = false;
            this.picHelp.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(720, 719);
            this.Controls.Add(this.bt_Objective);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.picCards);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_Skip);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WarCWB";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
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
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox picCards;
        private System.Windows.Forms.PictureBox picMap;
    }
}