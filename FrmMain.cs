using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace UninstallSoftwareRemotely
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private static bool PingHost(string remoteIpAdress)
        {
            var pingable = false;
            var pinger = new Ping();

            try
            {
                var reply = pinger.Send(remoteIpAdress);
                if (reply != null) pingable = reply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }

            return pingable;
        }

        private static void AutoSizeColumnList(ListView listView)
        {
            listView.BeginUpdate();

            var columnSize = new Dictionary<int, int>();

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (ColumnHeader colHeader in listView.Columns)
                columnSize.Add(colHeader.Index, colHeader.Width);

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            foreach (ColumnHeader colHeader in listView.Columns)
                colHeader.Width = Math.Max(columnSize.TryGetValue(colHeader.Index, out var nColWidth) ? nColWidth : 50,
                    colHeader.Width);

            listView.EndUpdate();
        }

        private static bool DeleteProgram(string programName, string computerName)
        {
            try
            {
                var connection = new ConnectionOptions();

                var scope = new ManagementScope("\\\\" + computerName + "\\root\\cimv2", connection);

                scope.Connect();

                var query = new ObjectQuery("SELECT * FROM Win32_Product WHERE Name ='" + programName + "'");

                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (var o in searcher.Get())
                {
                    var queryObj = (ManagementObject) o;

                    try
                    {
                        if (queryObj["Name"].ToString() == programName)
                        {
                            var hr = queryObj.InvokeMethod("Uninstall", null);
                            return (bool) hr;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        //
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void ListPrograms(string computerName, ListView lv)
        {
            try
            {
                var connection = new ConnectionOptions();
                var scope = new ManagementScope("\\\\" + computerName + "\\root\\cimv2", connection);
                scope.Connect();
                var query = new ObjectQuery("SELECT * FROM Win32_Product WHERE (NOT Vendor LIKE '%Microsoft%')");
                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (var o in searcher.Get())
                {
                    var queryObj = (ManagementObject) o;

                    var item1 = new ListViewItem {Text = queryObj["Name"].ToString()};
                    item1.SubItems.Add(queryObj["Version"].ToString());
                    item1.SubItems.Add(queryObj["Vendor"].ToString());
                    lv.Items.Add(item1);
                }
            }
            catch (ManagementException me)
            {
                MessageBox.Show(@"Error: " + me, @"Warning!");
                throw;
            }
        }

        #region Search

        private void btn_search_Click(object sender, EventArgs e)
        {
            var ipAdress = tb_remoteIpAdress.Text.Trim();

            if (ipAdress == "")
            {
                MessageBox.Show(@"Ip Adress Not Null",@"Info");
            }

            else
            {
                if (PingHost(ipAdress))
                {
                    lv_programList.Items.Clear();

                    bw_search.RunWorkerAsync();
                    btn_search.Enabled = false;
                    tb_remoteIpAdress.Enabled = false;
                    lv_programList.Enabled = false;
                }
                else
                {
                    MessageBox.Show(@"Ping Error!" , @"Info");
                }
            }
        }

        private void bw_search_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate { });

            ListPrograms(tb_remoteIpAdress.Text.Trim(), lv_programList);
        }

        private void bw_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AutoSizeColumnList(lv_programList);
            btn_search.Enabled = true;
            tb_remoteIpAdress.Enabled = true;
            lv_programList.Enabled = true;
        }

        #endregion

        #region Delete

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ipAdress = tb_remoteIpAdress.Text.Trim();

            if (ipAdress == "")
            {
                MessageBox.Show(@"Ip Adress Not Null",@"Info");
            }

            else
            {
                if (PingHost(ipAdress))
                {
                    bw_delete.RunWorkerAsync();
                    btn_search.Enabled = false;
                    tb_remoteIpAdress.Enabled = false;
                    lv_programList.Enabled = false;
                }
                else
                {
                    MessageBox.Show(@"Ping Error!" , @"Info");
                }
            }
        }

        private void bw_delete_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate { });

            var programNameForDelete = lv_programList.SelectedItems[0].SubItems[0].Text;
            var ipAdressForDelete = tb_remoteIpAdress.Text.Trim();

            DeleteProgram(programNameForDelete, ipAdressForDelete);
        }

        private void bw_delete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(@"Program Deleted", @"Info");
            btn_search.Enabled = true;
            tb_remoteIpAdress.Enabled = true;
            lv_programList.Enabled = true;
        }

        #endregion
    }
}