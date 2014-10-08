namespace CrosswordSolver
{
    partial class CrosswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrosswordForm));
            this.lblAnagram = new System.Windows.Forms.Label();
            this.txtAnagram = new System.Windows.Forms.TextBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.lblPattern = new System.Windows.Forms.Label();
            this.txtWordSize = new System.Windows.Forms.TextBox();
            this.lblWordSizes = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAnagram
            // 
            this.lblAnagram.AutoSize = true;
            this.lblAnagram.Location = new System.Drawing.Point(13, 13);
            this.lblAnagram.Name = "lblAnagram";
            this.lblAnagram.Size = new System.Drawing.Size(49, 13);
            this.lblAnagram.TabIndex = 0;
            this.lblAnagram.Text = "Anagram";
            // 
            // txtAnagram
            // 
            this.txtAnagram.Location = new System.Drawing.Point(16, 29);
            this.txtAnagram.Name = "txtAnagram";
            this.txtAnagram.Size = new System.Drawing.Size(264, 20);
            this.txtAnagram.TabIndex = 1;
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(16, 79);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(264, 20);
            this.txtPattern.TabIndex = 3;
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Location = new System.Drawing.Point(13, 63);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(41, 13);
            this.lblPattern.TabIndex = 2;
            this.lblPattern.Text = "Pattern";
            // 
            // txtWordSize
            // 
            this.txtWordSize.Location = new System.Drawing.Point(16, 127);
            this.txtWordSize.Name = "txtWordSize";
            this.txtWordSize.Size = new System.Drawing.Size(116, 20);
            this.txtWordSize.TabIndex = 5;
            // 
            // lblWordSizes
            // 
            this.lblWordSizes.AutoSize = true;
            this.lblWordSizes.Location = new System.Drawing.Point(13, 111);
            this.lblWordSizes.Name = "lblWordSizes";
            this.lblWordSizes.Size = new System.Drawing.Size(59, 13);
            this.lblWordSizes.TabIndex = 4;
            this.lblWordSizes.Text = "Word sizes";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(182, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 201);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(264, 236);
            this.textBox2.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(293, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel1.Text = "Crossword Solver by Mina Asad";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CrosswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtWordSize);
            this.Controls.Add(this.lblWordSizes);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.txtAnagram);
            this.Controls.Add(this.lblAnagram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CrosswordForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Crossword Solver";
            this.Load += new System.EventHandler(this.CrosswordForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnagram;
        private System.Windows.Forms.TextBox txtAnagram;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label lblPattern;
        private System.Windows.Forms.TextBox txtWordSize;
        private System.Windows.Forms.Label lblWordSizes;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button1;
    }
}

