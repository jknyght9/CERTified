using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace CERTified
{
    public partial class Form : System.Windows.Forms.Form
    {
        private SystemCertCheck _scc;
        private readonly int _settimer1 = 60;        //for system check (1 minute)
        private readonly int _settimer2 = 21600;     //for CTL / CRL update (6 hours)
        private int _usetimer1 = 0;
        private int _usetimer2 = 0;
        private readonly List<string> _filter = new List<string>();
        private List<CertStruct> _certs = new List<CertStruct>();

        public Form()
        {
            InitializeComponent();
            _usetimer1 = _settimer1;
            _usetimer2 = _settimer2;
            Thread t = new Thread(() =>
            {
                formStatus.Text = @"Collecting Certificate Trust List and CRLs...";
                _scc = new SystemCertCheck();
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.DataSource = BuildDataTable(); }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; }));
                formStatus.Text = "";
                UpdateNew();
            });
            t.Start();

            toolTip1.SetToolTip(ctlCB, "Not on Microsoft Certificate Trust List");
            toolTip1.SetToolTip(crlCB, "On Certificate Revocation List");
            toolTip1.SetToolTip(invalidCB, "Invalid certificate chain");
            toolTip1.SetToolTip(expiredCB, "Expired certificate");
        }

        public DataTable BuildDataTable(bool isFiltered = false)
        {
            if (!isFiltered)
            {
                ChangedStruct newCerts = _scc.VerifyAllCerts(_certs);
                _certs = newCerts.certs;
                if (newCerts.ischanged)
                    certs_CollectionChanged();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Certificate Name", typeof(string)));
            dt.Columns.Add(new DataColumn("NoCTL", typeof(string)));
            dt.Columns.Add(new DataColumn("OnCRL", typeof(string)));
            dt.Columns.Add(new DataColumn("Invalid", typeof(string)));
            dt.Columns.Add(new DataColumn("Expired", typeof(string)));

            foreach (var cert in _certs)
            {
                string[] exes = new string[dt.Columns.Count];
                foreach (var flag in cert.stat)
                {
                    switch (flag)
                    {
                        case Status.EXPIRED:
                            exes[3] = "X";
                            break;
                        case Status.INCRL:
                            exes[1] = "X";
                            break;
                        case Status.INVALID:
                            exes[2] = "X";
                            break;
                        case Status.NOTCTL:
                            exes[0] = "X";
                            break;
                    }
                }
                dt.Rows.Add((String.IsNullOrEmpty(cert.simplename)) ? cert.friendlyname : cert.simplename, exes[0], exes[1], exes[2], exes[3]);
            }
            return dt;
        }

        private void forceCheckToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            timer1.Stop();
            Thread t = new Thread(() =>
            {
                this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Blue; }));
                this.Invoke(new MethodInvoker(delegate { formStatus.Text =  @" Updating certificate information... "; }));
                UpdateView();
                this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Black; }));
                this.Invoke(new MethodInvoker(delegate { formStatus.Text = @""; }));
            });
            t.Start();
            timer1.Start();
        }

        private void forceUpdateToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            formStatus.Text = @" Updating CTL and CRL list...";
            timer2.Stop();
            _scc.GetCertVerifier().GetWinCTL();
            _scc.GetCertVerifier().GetCRLs();
            _usetimer2 = _settimer2;
            timer2.Start();
            formStatus.Text = "";
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (_usetimer1 > 0)
            {
                _usetimer1 -= 1;
                timerStatus1.Text = @" Updating system certificate data in " + _usetimer1 + @" seconds ";
            }
            else
            {
                Thread t = new Thread(() =>
                {
                    this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Blue; }));
                    this.Invoke(new MethodInvoker(delegate { formStatus.Text = @" Updating certificate information..."; }));
                    UpdateView();
                    this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Black; }));
                    this.Invoke(new MethodInvoker(delegate { formStatus.Text = ""; }));
                });
                t.Start();
                _usetimer1 = _settimer1;
                timer1.Start();
            }
        }

        private void timer2_Tick(object sender, System.EventArgs e)
        {
            if (_usetimer2 > 0)
            {
                _usetimer2 -= 1;
                timerStatus2.Text = @" Updating CTL/CRL data in " + _usetimer2 + @" seconds ";
            }
            else
            {
                Thread t = new Thread(() =>
                {
                    this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Blue; }));
                    this.Invoke(new MethodInvoker(delegate { formStatus.Text = @" Updating CTL / CRL... "; }));
                    _scc.GetCertVerifier().GetWinCTL();
                    _scc.GetCertVerifier().GetCRLs();
                    this.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = System.Drawing.Color.Black; }));
                    this.Invoke(new MethodInvoker(delegate { formStatus.Text = @""; }));
                });
                t.Start();
                _usetimer2 = _settimer2;
                timer2.Start();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ctl_CheckedChanged(object sender, EventArgs e)
        {
            if (ctlCB.Checked)
                _filter.Add("NoCTL='X'");
            else
                _filter.Remove("NoCTL='X'");
            Thread t = new Thread(() => { UpdateView(true); });
            t.Start();
        }

        private void crl_CheckedChanged(object sender, EventArgs e)
        {
            if (crlCB.Checked)
                _filter.Add("OnCRL='X'");
            else
                _filter.Remove("OnCRL='X'");
            Thread t = new Thread(() => { UpdateView(true); });
            t.Start();
        }

        private void invalid_CheckedChanged(object sender, EventArgs e)
        {
            if (invalidCB.Checked)
                _filter.Add("Invalid='X'");
            else
                _filter.Remove("Invalid='X'");
            Thread t = new Thread(() => { UpdateView(true); });
            t.Start();
        }

        private void expired_CheckedChanged(object sender, EventArgs e)
        {
            if (expiredCB.Checked)
                _filter.Add("Expired='X'");
            else
                _filter.Remove("Expired='X'");
            Thread t = new Thread(() => { UpdateView(true); });
            t.Start();
        }

        private void UpdateNew()
        {
            for (int z = 0; z < certDataGridView.RowCount; z++)
            {
                certDataGridView.Rows[z].Cells[0].Style.ForeColor = Color.Black;
            }
            foreach (var cert in _certs)
            {
                if (cert.isNew)
                {
                    for (int a = 0; a < certDataGridView.RowCount; a++)
                    {
                        if (certDataGridView.Rows[a].Cells[0].Value.Equals(cert.friendlyname))
                        {
                            certDataGridView.Rows[a].Cells[0].Style.ForeColor = Color.DarkRed;
                        }
                        if (certDataGridView.Rows[a].Cells[0].Value.Equals(cert.simplename))
                        {
                            certDataGridView.Rows[a].Cells[0].Style.ForeColor = Color.DarkRed;
                        }
                    }
                }
                if (cert.isCA)
                {
                    for (int a = 0; a < certDataGridView.RowCount; a++)
                    {
                        if (certDataGridView.Rows[a].Cells[0].Value.Equals(cert.friendlyname))
                        {
                            certDataGridView.Rows[a].Cells[0].Style.ForeColor = Color.Blue;
                        }
                        if (certDataGridView.Rows[a].Cells[0].Value.Equals(cert.simplename))
                        {
                            certDataGridView.Rows[a].Cells[0].Style.ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }

        private void UpdateView(bool isFiltered = false)
        {
            string query = String.Empty;
            for (int a = 1; a <= _filter.Count; a++)
            {
                if (a != _filter.Count)
                    query += _filter[a - 1] + " AND ";
                else
                    query += _filter[a - 1];
            }
            DataRow[] result = BuildDataTable(isFiltered).Select(query);
            if (result.Length == 0)
            {
                certDataGridView.Invoke(new MethodInvoker(delegate { formStatus.ForeColor = Color.DarkRed; }));
                certDataGridView.Invoke(new MethodInvoker(delegate { formStatus.Text = @" No results "; }));
                Thread.Sleep(5000);
                certDataGridView.Invoke(new MethodInvoker(delegate { formStatus.Text = @""; }));
            }
            else
                certDataGridView.Invoke(new MethodInvoker(delegate { certDataGridView.DataSource = result.CopyToDataTable(); }));
            UpdateNew();
        }

        private void ResetFilters()
        {
            ctlCB.Checked = false;
            crlCB.Checked = false;
            invalidCB.Checked = false;
            expiredCB.Checked = false;
        }

        private void resetFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CertStruct cert = _certs[e.RowIndex];
                TreeNode node1;
                switch (cert.storename)
                {
                    case "My":
                        node1 = new TreeNode("Cert Store: Personal");
                        break;
                    case "AddressBook":
                        node1 = new TreeNode("Cert Store: Other People");
                        break;
                    case "Root":
                        node1 = new TreeNode("Cert Store: Trusted Root Cert. Authorities");
                        break;
                    case "AuthRoot":
                        node1 = new TreeNode("Cert Store: Third Party Root Cert. Authorities");
                        break;
                    case "CA":
                        node1 = new TreeNode("Cert Store: Intermediate Cert. Authorities");
                        break;
                    case "Trust":
                        node1 = new TreeNode("Cert Store: Enterprise Trust");
                        break;
                    case "Efs":
                        node1 = new TreeNode("Cert Store: Windows Encrypted File System");
                        break;
                    default:
                        node1 = new TreeNode("Cert Store: " + cert.storename);
                        break;
                }
                TreeNode node2 = new TreeNode("Store Location: " + cert.storeloc);
                TreeNode node3 = new TreeNode("Serial Number: " + cert.serial);
                TreeNode node4 = new TreeNode("Thumbprint: " + cert.thumbprint);
                TreeNode node5 = new TreeNode("Algorithm: " + cert.algorithm);
                TreeNode node6 = new TreeNode("Expires: " + cert.expires);
                TreeNode[] array = new TreeNode[] { node1, node2, node3, node4, node5, node6 };
                if (!String.IsNullOrEmpty(cert.friendlyname))
                    certdetailsTreeView.Nodes.Add(new TreeNode(cert.friendlyname, array));
                else
                    certdetailsTreeView.Nodes.Add(new TreeNode(cert.simplename, array));
                certdetailsTreeView.ExpandAll();
            }
            catch (Exception ex) { ; }
        }

        private void certDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
            if (!timer2.Enabled)
                timer2.Enabled = true;
        }

        private void certs_CollectionChanged()
        {
            notifyIcon1.BalloonTipTitle = @"CERTified";
            notifyIcon1.BalloonTipText = @"A change in the certificate store has been detected";
            notifyIcon1.ShowBalloonTip(1000);
            notifyIcon1.BalloonTipClicked += notifyIcon1_Click;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
                Show();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
