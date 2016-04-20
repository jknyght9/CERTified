using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CERTified
{
    public partial class Form1 : Form
    {
        public SystemCertCheck _scc;
        public const int settimer1 = 60;        //for system check (1 minute)
        public const int settimer2 = 21600;     //for CTL / CRL update (6 hours)
        public int usetimer1 = settimer1;
        public int usetimer2 = settimer2;
        public List<string> filter = new List<string>();
        List<certstruct> certs;
        public DataTable previous;

        public Form1()
        {
            InitializeComponent();
            _scc = new SystemCertCheck();
            dataGridView1.DataSource = buildDataTable();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            toolTip1.SetToolTip(this.ctlCB, "Not on Microsoft Certificate Trust List");
            toolTip1.SetToolTip(this.crlCB, "On Certificate Revocation List");
            toolTip1.SetToolTip(this.invalidCB, "Invalid certificate chain");
            toolTip1.SetToolTip(this.expiredCB, "Expired certificate");
            toolTip1.SetToolTip(this.mismatchCB, "Hash mismatched");
        }

        public DataTable buildDataTable()
        {
            certs = _scc.verifyAllCerts();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Certificate Name", typeof(string)));
            dt.Columns.Add(new DataColumn("NoCTL", typeof(string)));
            dt.Columns.Add(new DataColumn("OnCRL", typeof(string)));
            dt.Columns.Add(new DataColumn("Invalid", typeof(string)));
            dt.Columns.Add(new DataColumn("Expired", typeof(string)));
            dt.Columns.Add(new DataColumn("HashMismatch", typeof(string)));

            foreach (var cert in certs)
            {
                string[] exes = new string[5];
                foreach (var flag in cert.stat)
                {
                    switch (flag)
                    {
                        case status.EXPIRED:
                            exes[3] = "X";
                            break;
                        case status.HASHMISMATCH:
                            exes[4] = "X";
                            break;
                        case status.INCRL:
                            exes[1] = "X";
                            break;
                        case status.INVALID:
                            exes[2] = "X";
                            break;
                        case status.NOTCTL:
                            exes[0] = "X";
                            break;
                    }
                }
                dt.Rows.Add(cert.simplename, exes[0], exes[1], exes[2], exes[3], exes[4]);
            }
            return dt;
        }

        private void forceCheckToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            timer1.Stop();
            updateView();
            usetimer1 = settimer1;
            timer1.Start();
        }

        private void forceUpdateToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            timer2.Stop();
            _scc.getCertVerifier().getWinCTL();
            _scc.getCertVerifier().getCRLs();
            usetimer2 = settimer2;
            timer2.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (usetimer1 > 0)
            {
                usetimer1 -= 1;
                timerStatus1.Text = " Updating system certificate data in " + usetimer1 + " seconds ";
            }
            else
            {
                updateView();
                usetimer1 = settimer1;
                timer1.Start();
            }
        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            if (usetimer2 > 0)
            {
                usetimer2 -= 1;
                timerStatus2.Text = " Updating CTL/CRL data in " + usetimer2 + " seconds ";
            }
            else
            {
                _scc.getCertVerifier().getWinCTL();
                _scc.getCertVerifier().getCRLs();
                usetimer2 = settimer2;
                timer2.Start();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ctlCB.Checked)
                filter.Add("NoCTL='X'");
            else
                filter.Remove("NoCTL='X'");
            updateView();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (crlCB.Checked)
                filter.Add("OnCRL='X'");
            else
                filter.Remove("OnCRL='X'");
            updateView();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (invalidCB.Checked)
                filter.Add("Invalid='X'");
            else
                filter.Remove("Invalid='X'");
            updateView();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (expiredCB.Checked)
                filter.Add("Expired='X'");
            else
                filter.Remove("Expired='X'");
            updateView();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (mismatchCB.Checked)
                filter.Add("HashMismatch='X'");
            else
                filter.Remove("HashMismatch='X'");
            updateView();
        }

        private void updateView()
        {
            formStatus.Text = "";
            string query = String.Empty;
            for (int a = 1; a <= filter.Count; a++)
            {
                if (a != filter.Count)
                    query += filter[a-1] + " AND ";
                else
                    query += filter[a-1];
            }
            DataRow[] result = buildDataTable().Select(query);
            if (result.Length == 0)
            {
                formStatus.ForeColor = System.Drawing.Color.DarkRed;
                formStatus.Text = " No results ";
            }
            else
                dataGridView1.DataSource = result.CopyToDataTable();
        }

        private void resetFilters()
        {
            ctlCB.Checked = false;
            crlCB.Checked = false;
            invalidCB.Checked = false;
            expiredCB.Checked = false;
            mismatchCB.Checked = false;
        }

        private void resetFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetFilters();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                certstruct cert = certs.Find(x => x.simplename == (string)row.Cells[0].Value);
                TreeNode node1 = new TreeNode("Cert Store: " + cert.storename);
                TreeNode node2 = new TreeNode("Serial Number: " + cert.serial);
                TreeNode node3 = new TreeNode("Thumbprint: " + cert.thumbprint);
                TreeNode node4 = new TreeNode("Algorithm: " + cert.algorithm);
                TreeNode node5 = new TreeNode("Expires: " + cert.expires);
                TreeNode[] array = new TreeNode[] { node1, node2, node3, node4, node5 };
                if (!String.IsNullOrEmpty(cert.friendlyname))
                    treeView1.Nodes.Add(new TreeNode(cert.friendlyname, array));
                else
                    treeView1.Nodes.Add(new TreeNode(cert.simplename, array));
                treeView1.ExpandAll();
            }
            catch(Exception ex) { ; }
        }
    }
}
