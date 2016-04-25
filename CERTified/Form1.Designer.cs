namespace CERTified
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certDataGridView = new System.Windows.Forms.DataGridView();
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
            this.certdetailsTreeView = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.nofifyContextMenu = new System.Windows.Forms.ContextMenu();
            this.newCertLabel = new System.Windows.Forms.Label();
            this.certAuthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.refreshRateUpDown = new System.Windows.Forms.NumericUpDown();
            this.certstructBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).BeginInit();
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
            this.forceCheckToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.forceCheckToolStripMenuItem.Text = "Force Check";
            this.forceCheckToolStripMenuItem.Click += new System.EventHandler(this.forceCheckToolStripMenuItem_Click);
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.forceUpdateToolStripMenuItem.Text = "Force Update";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // resetFiltersToolStripMenuItem
            // 
            this.resetFiltersToolStripMenuItem.Name = "resetFiltersToolStripMenuItem";
            this.resetFiltersToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.resetFiltersToolStripMenuItem.Text = "Reset Filters";
            this.resetFiltersToolStripMenuItem.Click += new System.EventHandler(this.resetFiltersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Close Application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // certDataGridView
            // 
            this.certDataGridView.AllowUserToAddRows = false;
            this.certDataGridView.AllowUserToDeleteRows = false;
            this.certDataGridView.AllowUserToResizeRows = false;
            this.certDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.certDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.certDataGridView.Location = new System.Drawing.Point(0, 27);
            this.certDataGridView.Name = "certDataGridView";
            this.certDataGridView.ReadOnly = true;
            this.certDataGridView.RowHeadersWidth = 42;
            this.certDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.certDataGridView.Size = new System.Drawing.Size(699, 400);
            this.certDataGridView.TabIndex = 1;
            this.certDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.certDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.certDataGridView_RowsAdded);
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
            this.timerStatus1.Size = new System.Drawing.Size(0, 17);
            // 
            // timerStatus2
            // 
            this.timerStatus2.Name = "timerStatus2";
            this.timerStatus2.Size = new System.Drawing.Size(0, 17);
            // 
            // formStatus
            // 
            this.formStatus.Name = "formStatus";
            this.formStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ctlCB
            // 
            this.ctlCB.AutoSize = true;
            this.ctlCB.Location = new System.Drawing.Point(55, 436);
            this.ctlCB.Name = "ctlCB";
            this.ctlCB.Size = new System.Drawing.Size(46, 17);
            this.ctlCB.TabIndex = 3;
            this.ctlCB.Text = "CTL";
            this.ctlCB.UseVisualStyleBackColor = true;
            this.ctlCB.CheckedChanged += new System.EventHandler(this.ctl_CheckedChanged);
            // 
            // crlCB
            // 
            this.crlCB.AutoSize = true;
            this.crlCB.Location = new System.Drawing.Point(107, 436);
            this.crlCB.Name = "crlCB";
            this.crlCB.Size = new System.Drawing.Size(47, 17);
            this.crlCB.TabIndex = 4;
            this.crlCB.Text = "CRL";
            this.crlCB.UseVisualStyleBackColor = true;
            this.crlCB.CheckedChanged += new System.EventHandler(this.crl_CheckedChanged);
            // 
            // invalidCB
            // 
            this.invalidCB.AutoSize = true;
            this.invalidCB.Location = new System.Drawing.Point(160, 436);
            this.invalidCB.Name = "invalidCB";
            this.invalidCB.Size = new System.Drawing.Size(57, 17);
            this.invalidCB.TabIndex = 5;
            this.invalidCB.Text = "Invalid";
            this.invalidCB.UseVisualStyleBackColor = true;
            this.invalidCB.CheckedChanged += new System.EventHandler(this.invalid_CheckedChanged);
            // 
            // expiredCB
            // 
            this.expiredCB.AutoSize = true;
            this.expiredCB.Location = new System.Drawing.Point(223, 436);
            this.expiredCB.Name = "expiredCB";
            this.expiredCB.Size = new System.Drawing.Size(61, 17);
            this.expiredCB.TabIndex = 6;
            this.expiredCB.Text = "Expired";
            this.expiredCB.UseVisualStyleBackColor = true;
            this.expiredCB.CheckedChanged += new System.EventHandler(this.expired_CheckedChanged);
            // 
            // certdetailsTreeView
            // 
            this.certdetailsTreeView.Location = new System.Drawing.Point(705, 27);
            this.certdetailsTreeView.Name = "certdetailsTreeView";
            this.certdetailsTreeView.Size = new System.Drawing.Size(383, 400);
            this.certdetailsTreeView.TabIndex = 8;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.nofifyContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CERTified";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // newCertLabel
            // 
            this.newCertLabel.AutoSize = true;
            this.newCertLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.newCertLabel.Location = new System.Drawing.Point(620, 435);
            this.newCertLabel.Name = "newCertLabel";
            this.newCertLabel.Size = new System.Drawing.Size(79, 13);
            this.newCertLabel.TabIndex = 9;
            this.newCertLabel.Text = "New Certificate";
            // 
            // certAuthLabel
            // 
            this.certAuthLabel.AutoSize = true;
            this.certAuthLabel.ForeColor = System.Drawing.Color.Blue;
            this.certAuthLabel.Location = new System.Drawing.Point(516, 435);
            this.certAuthLabel.Name = "certAuthLabel";
            this.certAuthLabel.Size = new System.Drawing.Size(98, 13);
            this.certAuthLabel.TabIndex = 10;
            this.certAuthLabel.Text = "Certificate Authority";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(702, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "History:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Refresh Rate (in seconds)";
            // 
            // refreshRateUpDown
            // 
            this.refreshRateUpDown.Location = new System.Drawing.Point(576, 4);
            this.refreshRateUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.refreshRateUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.refreshRateUpDown.Name = "refreshRateUpDown";
            this.refreshRateUpDown.Size = new System.Drawing.Size(120, 20);
            this.refreshRateUpDown.TabIndex = 15;
            this.refreshRateUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.refreshRateUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // certstructBindingSource
            // 
            this.certstructBindingSource.DataSource = typeof(CERTified.CertStruct);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 481);
            this.Controls.Add(this.refreshRateUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.certAuthLabel);
            this.Controls.Add(this.newCertLabel);
            this.Controls.Add(this.certdetailsTreeView);
            this.Controls.Add(this.expiredCB);
            this.Controls.Add(this.invalidCB);
            this.Controls.Add(this.crlCB);
            this.Controls.Add(this.ctlCB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.certDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.Text = "CERTified";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.certDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).EndInit();
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
        private System.Windows.Forms.DataGridView certDataGridView;
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
        private System.Windows.Forms.ToolStripStatusLabel formStatus;
        private System.Windows.Forms.ToolStripMenuItem resetFiltersToolStripMenuItem;
        private System.Windows.Forms.TreeView certdetailsTreeView;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu nofifyContextMenu;
        private System.Windows.Forms.Label newCertLabel;
        private System.Windows.Forms.Label certAuthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown refreshRateUpDown;
    }
}

