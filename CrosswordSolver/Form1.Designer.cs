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
            this.txtResults = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMaxLetters = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.txtAnagram.Text = "heandnedgotfree";
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(16, 79);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(264, 20);
            this.txtPattern.TabIndex = 3;
            this.txtPattern.Text = "_H__A_D___F_D_N";
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
            this.txtWordSize.Text = "3,6,2,4";
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
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(16, 153);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(264, 234);
            this.txtResults.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
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
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 393);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(264, 22);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimer);
            this.groupBox1.Location = new System.Drawing.Point(199, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(81, 37);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stopwatch";
            // 
            // lblTimer
            // 
            this.lblTimer.Location = new System.Drawing.Point(16, 16);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(48, 20);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "0 ms";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMaxLetters);
            this.groupBox2.Location = new System.Drawing.Point(142, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(51, 37);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chars";
            // 
            // lblMaxLetters
            // 
            this.lblMaxLetters.Location = new System.Drawing.Point(19, 16);
            this.lblMaxLetters.Name = "lblMaxLetters";
            this.lblMaxLetters.Size = new System.Drawing.Size(48, 20);
            this.lblMaxLetters.TabIndex = 0;
            this.lblMaxLetters.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblWords);
            this.groupBox3.Location = new System.Drawing.Point(81, 426);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(55, 37);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Words";
            // 
            // lblWords
            // 
            this.lblWords.Location = new System.Drawing.Point(17, 16);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(23, 20);
            this.lblWords.TabIndex = 0;
            this.lblWords.Text = "0";
            // 
            // CrosswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtWordSize);
            this.Controls.Add(this.lblWordSizes);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.txtAnagram);
            this.Controls.Add(this.lblAnagram);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CrosswordForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Crossword Solver";
            this.Load += new System.EventHandler(this.CrosswordForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMaxLetters;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblWords;
    }
}

