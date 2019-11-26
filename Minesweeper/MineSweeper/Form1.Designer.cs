namespace MineSweeper
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.beginnerRB = new System.Windows.Forms.RadioButton();
            this.intermediateRB = new System.Windows.Forms.RadioButton();
            this.expertRB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.minesRemainingLBL = new System.Windows.Forms.Label();
            this.timeLBL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(300, 21);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(65, 63);
            this.startBTN.TabIndex = 4;
            this.startBTN.Text = "Start new game";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "9          9          10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height  Width  Mines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "16        30        99";
            // 
            // beginnerRB
            // 
            this.beginnerRB.AutoSize = true;
            this.beginnerRB.Checked = true;
            this.beginnerRB.Location = new System.Drawing.Point(371, 21);
            this.beginnerRB.Name = "beginnerRB";
            this.beginnerRB.Size = new System.Drawing.Size(67, 17);
            this.beginnerRB.TabIndex = 8;
            this.beginnerRB.TabStop = true;
            this.beginnerRB.Text = "Beginner";
            this.beginnerRB.UseVisualStyleBackColor = true;
            // 
            // intermediateRB
            // 
            this.intermediateRB.AutoSize = true;
            this.intermediateRB.Location = new System.Drawing.Point(371, 44);
            this.intermediateRB.Name = "intermediateRB";
            this.intermediateRB.Size = new System.Drawing.Size(83, 17);
            this.intermediateRB.TabIndex = 9;
            this.intermediateRB.Text = "Intermadiate";
            this.intermediateRB.UseVisualStyleBackColor = true;
            // 
            // expertRB
            // 
            this.expertRB.AutoSize = true;
            this.expertRB.Location = new System.Drawing.Point(371, 67);
            this.expertRB.Name = "expertRB";
            this.expertRB.Size = new System.Drawing.Size(55, 17);
            this.expertRB.TabIndex = 10;
            this.expertRB.Text = "Expert";
            this.expertRB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "16        16        40";
            // 
            // minesRemainingLBL
            // 
            this.minesRemainingLBL.AutoSize = true;
            this.minesRemainingLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.minesRemainingLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.minesRemainingLBL.Location = new System.Drawing.Point(20, 25);
            this.minesRemainingLBL.Name = "minesRemainingLBL";
            this.minesRemainingLBL.Size = new System.Drawing.Size(53, 59);
            this.minesRemainingLBL.TabIndex = 11;
            this.minesRemainingLBL.Text = "0";
            this.minesRemainingLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeLBL
            // 
            this.timeLBL.AutoSize = true;
            this.timeLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F);
            this.timeLBL.Location = new System.Drawing.Point(800, 25);
            this.timeLBL.Name = "timeLBL";
            this.timeLBL.Size = new System.Drawing.Size(109, 59);
            this.timeLBL.TabIndex = 12;
            this.timeLBL.Text = "000";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 612);
            this.Controls.Add(this.timeLBL);
            this.Controls.Add(this.minesRemainingLBL);
            this.Controls.Add(this.expertRB);
            this.Controls.Add(this.intermediateRB);
            this.Controls.Add(this.beginnerRB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBTN);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton beginnerRB;
        private System.Windows.Forms.RadioButton intermediateRB;
        private System.Windows.Forms.RadioButton expertRB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label minesRemainingLBL;
        private System.Windows.Forms.Label timeLBL;
        private System.Windows.Forms.Timer timer1;
    }
}

