namespace _1113341_12_4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟舊檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顏色調整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰階ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.負片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.亮度調整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.調暗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.大小調整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.一半ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二倍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 23);
            this.toolStripStatusLabel1.Text = "Null";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(22, 23);
            this.toolStripStatusLabel2.Text = "()";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 30);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟舊檔ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.檔案ToolStripMenuItem.Text = "檔案";
            this.檔案ToolStripMenuItem.Click += new System.EventHandler(this.開啟舊檔ToolStripMenuItem_Click);
            // 
            // 開啟舊檔ToolStripMenuItem
            // 
            this.開啟舊檔ToolStripMenuItem.Name = "開啟舊檔ToolStripMenuItem";
            this.開啟舊檔ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.開啟舊檔ToolStripMenuItem.Text = "開啟舊檔";
            // 
            // 顏色調整ToolStripMenuItem
            // 
            this.顏色調整ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.灰階ToolStripMenuItem,
            this.負片ToolStripMenuItem});
            this.顏色調整ToolStripMenuItem.Name = "顏色調整ToolStripMenuItem";
            this.顏色調整ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.顏色調整ToolStripMenuItem.Text = "顏色調整";
            // 
            // 灰階ToolStripMenuItem
            // 
            this.灰階ToolStripMenuItem.Name = "灰階ToolStripMenuItem";
            this.灰階ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.灰階ToolStripMenuItem.Text = "灰階";
            this.灰階ToolStripMenuItem.Click += new System.EventHandler(this.灰階ToolStripMenuItem_Click);
            // 
            // 負片ToolStripMenuItem
            // 
            this.負片ToolStripMenuItem.Name = "負片ToolStripMenuItem";
            this.負片ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.負片ToolStripMenuItem.Text = "負片";
            this.負片ToolStripMenuItem.Click += new System.EventHandler(this.負片ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.顏色調整ToolStripMenuItem,
            this.亮度調整ToolStripMenuItem,
            this.大小調整ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 31);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 亮度調整ToolStripMenuItem
            // 
            this.亮度調整ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增量ToolStripMenuItem,
            this.調暗ToolStripMenuItem});
            this.亮度調整ToolStripMenuItem.Name = "亮度調整ToolStripMenuItem";
            this.亮度調整ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.亮度調整ToolStripMenuItem.Text = "亮度調整";
            // 
            // 增量ToolStripMenuItem
            // 
            this.增量ToolStripMenuItem.Name = "增量ToolStripMenuItem";
            this.增量ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.增量ToolStripMenuItem.Text = "增亮";
            this.增量ToolStripMenuItem.Click += new System.EventHandler(this.增亮ToolStripMenuItem_Click);
            // 
            // 調暗ToolStripMenuItem
            // 
            this.調暗ToolStripMenuItem.Name = "調暗ToolStripMenuItem";
            this.調暗ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.調暗ToolStripMenuItem.Text = "調暗";
            this.調暗ToolStripMenuItem.Click += new System.EventHandler(this.調暗ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 389);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // 大小調整ToolStripMenuItem
            // 
            this.大小調整ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.一半ToolStripMenuItem,
            this.二倍ToolStripMenuItem});
            this.大小調整ToolStripMenuItem.Name = "大小調整ToolStripMenuItem";
            this.大小調整ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.大小調整ToolStripMenuItem.Text = "大小調整";
            // 
            // 一半ToolStripMenuItem
            // 
            this.一半ToolStripMenuItem.Name = "一半ToolStripMenuItem";
            this.一半ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.一半ToolStripMenuItem.Text = "一半";
            this.一半ToolStripMenuItem.Click += new System.EventHandler(this.一半ToolStripMenuItem_Click);
            // 
            // 二倍ToolStripMenuItem
            // 
            this.二倍ToolStripMenuItem.Name = "二倍ToolStripMenuItem";
            this.二倍ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.二倍ToolStripMenuItem.Text = "二倍";
            this.二倍ToolStripMenuItem.Click += new System.EventHandler(this.二倍ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟舊檔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 顏色調整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰階ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 負片ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 亮度調整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 調暗ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大小調整ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 一半ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 二倍ToolStripMenuItem;
    }
}

