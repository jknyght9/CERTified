namespace CERTified
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timerStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.formStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ctlCB = new System.Windows.Forms.CheckBox();
            this.crlCB = new System.Windows.Forms.CheckBox();
            this.invalidCB = new System.Windows.Forms.CheckBox();
            this.expiredCB = new System.Windows.Forms.CheckBox();
            this.mismatchCB = new System.Windows.Forms.CheckBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.certstructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certstructBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceCheckToolStripMenuItem,
            this.forceUpdateToolStripMenuItem,
            this.resetFiltersToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // forceCheckToolStripMenuItem
            // 
            this.forceCheckToolStripMenuItem.Name = "forceCheckToolStripMenuItem";
            this.forceCheckToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.forceCheckToolStripMenuItem.Text = "Force Check";
            this.forceCheckToolStripMenuItem.Click += new System.EventHandler(this.forceCheckToolStripMenuItem_Click);
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.forceUpdateToolStripMenuItem.Text = "Force Update";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // resetFiltersToolStripMenuItem
            // 
            this.resetFiltersToolStripMenuItem.Name = "resetFiltersToolStripMenuItem";
            this.resetFiltersToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.resetFiltersToolStripMenuItem.Text = "Reset Filters";
            this.resetFiltersToolStripMenuItem.Click += new System.EventHandler(this.resetFiltersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 42;
            this.dataGridView1.Size = new System.Drawing.Size(699, 400);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerStatus1,
            this.timerStatus2,
            this.formStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1089, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timerStatus1
            // 
            this.timerStatus1.Name = "timerStatus1";
            this.timerStatus1.Size = new System.Drawing.Size(73, 17);
            this.timerStatus1.Text = "timerStatus1";
            // 
            // timerStatus2
            // 
            this.timerStatus2.Name = "timerStatus2";
            this.timerStatus2.Size = new System.Drawing.Size(73, 17);
            this.timerStatus2.Text = "timerStatus2";
            // 
            // formStatus
            // 
            this.formStatus.Name = "formStatus";
            this.formStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ctlCB
            // 
            this.ctlCB.AutoSize = true;
            this.ctlCB.Location = new System.Drawing.Point(13, 434);
            this.ctlCB.Name = "ctlCB";
            this.ctlCB.Size = new System.Drawing.Size(46, 17);
            this.ctlCB.TabIndex = 3;
            this.ctlCB.Text = "CTL";
            this.ctlCB.UseVisualStyleBackColor = true;
            this.ctlCB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // crlCB
            // 
            this.crlCB.AutoSize = true;
            this.crlCB.Location = new System.Drawing.Point(100, 434);
            this.crlCB.Name = "crlCB";
            this.crlCB.Size = new System.Drawing.Size(47, 17);
            this.crlCB.TabIndex = 4;
            this.crlCB.Text = "CRL";
            this.crlCB.UseVisualStyleBackColor = true;
            this.crlCB.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // invalidCB
            // 
            this.invalidCB.AutoSize = true;
            this.invalidCB.Location = new System.Drawing.Point(187, 434);
            this.invalidCB.Name = "invalidCB";
            this.invalidCB.Size = new System.Drawing.Size(57, 17);
            this.invalidCB.TabIndex = 5;
            this.invalidCB.Text = "Invalid";
            this.invalidCB.UseVisualStyleBackColor = true;
            this.invalidCB.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // expiredCB
            // 
            this.expiredCB.AutoSize = true;
            this.expiredCB.Location = new System.Drawing.Point(274, 434);
            this.expiredCB.Name = "expiredCB";
            this.expiredCB.Size = new System.Drawing.Size(61, 17);
            this.expiredCB.TabIndex = 6;
            this.expiredCB.Text = "Expired";
            this.expiredCB.UseVisualStyleBackColor = true;
            this.expiredCB.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // mismatchCB
            // 
            this.mismatchCB.AutoSize = true;
            this.mismatchCB.Location = new System.Drawing.Point(361, 434);
            this.mismatchCB.Name = "mismatchCB";
            this.mismatchCB.Size = new System.Drawing.Size(71, 17);
            this.mismatchCB.TabIndex = 7;
            this.mismatchCB.Text = "Mismatch";
            this.mismatchCB.UseVisualStyleBackColor = true;
            this.mismatchCB.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(705, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(383, 400);
            this.treeView1.TabIndex = 8;
            // 
            // certstructBindingSource
            // 
            this.certstructBindingSource.DataSource = typeof(CERTified.certstruct);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 481);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mismatchCB);
            this.Controls.Add(this.expiredCB);
            this.Controls.Add(this.invalidCB);
            this.Controls.Add(this.crlCB);
            this.Controls.Add(this.ctlCB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CERTified";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certstructBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource certstructBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timerStatus1;
        private System.Windows.Forms.ToolStripStatusLabel timerStatus2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox ctlCB;
        private System.Windows.Forms.CheckBox crlCB;
        private System.Windows.Forms.CheckBox invalidCB;
        private System.Windows.Forms.CheckBox expiredCB;
        private System.Windows.Forms.CheckBox mismatchCB;
        private System.Windows.Forms.ToolStripStatusLabel formStatus;
        private System.Windows.Forms.ToolStripMenuItem resetFiltersToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

