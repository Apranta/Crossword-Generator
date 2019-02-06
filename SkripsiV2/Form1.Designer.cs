namespace SkripsiV2
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.mendatar = new System.Windows.Forms.ListBox();
            this.Menurun = new System.Windows.Forms.ListBox();
            this.wordCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(291, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(681, 497);
            this.dataGridView1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mendatar
            // 
            this.mendatar.FormattingEnabled = true;
            this.mendatar.Items.AddRange(new object[] {
            "Horizontal :"});
            this.mendatar.Location = new System.Drawing.Point(13, 40);
            this.mendatar.Name = "mendatar";
            this.mendatar.Size = new System.Drawing.Size(272, 212);
            this.mendatar.TabIndex = 3;
            this.mendatar.SelectedIndexChanged += new System.EventHandler(this.Mendatar_SelectedIndexChanged);
            // 
            // Menurun
            // 
            this.Menurun.FormattingEnabled = true;
            this.Menurun.Items.AddRange(new object[] {
            "Vertical :"});
            this.Menurun.Location = new System.Drawing.Point(12, 258);
            this.Menurun.Name = "Menurun";
            this.Menurun.Size = new System.Drawing.Size(272, 225);
            this.Menurun.TabIndex = 4;
            // 
            // wordCount
            // 
            this.wordCount.AutoSize = true;
            this.wordCount.Location = new System.Drawing.Point(12, 499);
            this.wordCount.Name = "wordCount";
            this.wordCount.Size = new System.Drawing.Size(58, 13);
            this.wordCount.TabIndex = 5;
            this.wordCount.Text = "wordCount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.wordCount);
            this.Controls.Add(this.Menurun);
            this.Controls.Add(this.mendatar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ListBox mendatar;
        public System.Windows.Forms.ListBox Menurun;
        private System.Windows.Forms.Label wordCount;
    }
}

