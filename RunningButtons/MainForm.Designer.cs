namespace RunningButtons
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.start_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.third_btn = new RunningButtons.ButtonCompare();
            this.second_btn = new RunningButtons.ButtonCompare();
            this.first_btn = new RunningButtons.ButtonCompare();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(23, 31);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 3;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.Enabled = false;
            this.pause_btn.Location = new System.Drawing.Point(138, 31);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(75, 23);
            this.pause_btn.TabIndex = 4;
            this.pause_btn.Text = "Pause";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Location = new System.Drawing.Point(257, 31);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 5;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.start_btn);
            this.groupBox1.Controls.Add(this.stop_btn);
            this.groupBox1.Controls.Add(this.pause_btn);
            this.groupBox1.Location = new System.Drawing.Point(256, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RunningButtons.Properties.Resources.Finish;
            this.pictureBox1.Location = new System.Drawing.Point(827, -17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(6, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // third_btn
            // 
            this.third_btn.Location = new System.Drawing.Point(13, 100);
            this.third_btn.Name = "third_btn";
            this.third_btn.Size = new System.Drawing.Size(75, 23);
            this.third_btn.TabIndex = 2;
            this.third_btn.Text = "button3";
            this.third_btn.UseVisualStyleBackColor = true;
            // 
            // second_btn
            // 
            this.second_btn.Location = new System.Drawing.Point(13, 56);
            this.second_btn.Name = "second_btn";
            this.second_btn.Size = new System.Drawing.Size(75, 23);
            this.second_btn.TabIndex = 1;
            this.second_btn.Text = "button2";
            this.second_btn.UseVisualStyleBackColor = true;
            // 
            // first_btn
            // 
            this.first_btn.Location = new System.Drawing.Point(13, 13);
            this.first_btn.Name = "first_btn";
            this.first_btn.Size = new System.Drawing.Size(75, 23);
            this.first_btn.TabIndex = 0;
            this.first_btn.Text = "button1";
            this.first_btn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 265);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.third_btn);
            this.Controls.Add(this.second_btn);
            this.Controls.Add(this.first_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Гонки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonCompare first_btn;
        private ButtonCompare second_btn;
        private ButtonCompare third_btn;

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

