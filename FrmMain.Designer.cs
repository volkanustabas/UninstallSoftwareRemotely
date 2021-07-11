
namespace UninstallSoftwareRemotely
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tb_remoteIpAdress = new System.Windows.Forms.TextBox();
            this.lbl_info_remoteIpAdress = new System.Windows.Forms.Label();
            this.lv_programList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cms_delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_search = new System.Windows.Forms.Button();
            this.bw_search = new System.ComponentModel.BackgroundWorker();
            this.bw_delete = new System.ComponentModel.BackgroundWorker();
            this.cms_delete.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_remoteIpAdress
            // 
            this.tb_remoteIpAdress.Location = new System.Drawing.Point(16, 29);
            this.tb_remoteIpAdress.Name = "tb_remoteIpAdress";
            this.tb_remoteIpAdress.Size = new System.Drawing.Size(156, 20);
            this.tb_remoteIpAdress.TabIndex = 0;
            // 
            // lbl_info_remoteIpAdress
            // 
            this.lbl_info_remoteIpAdress.AutoSize = true;
            this.lbl_info_remoteIpAdress.Location = new System.Drawing.Point(13, 13);
            this.lbl_info_remoteIpAdress.Name = "lbl_info_remoteIpAdress";
            this.lbl_info_remoteIpAdress.Size = new System.Drawing.Size(91, 13);
            this.lbl_info_remoteIpAdress.TabIndex = 1;
            this.lbl_info_remoteIpAdress.Text = "Remote Ip Adress";
            // 
            // lv_programList
            // 
            this.lv_programList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_programList.ContextMenuStrip = this.cms_delete;
            this.lv_programList.FullRowSelect = true;
            this.lv_programList.HideSelection = false;
            this.lv_programList.Location = new System.Drawing.Point(188, 29);
            this.lv_programList.Name = "lv_programList";
            this.lv_programList.Size = new System.Drawing.Size(716, 498);
            this.lv_programList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_programList.TabIndex = 2;
            this.lv_programList.UseCompatibleStateImageBehavior = false;
            this.lv_programList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Version";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Vendor";
            this.columnHeader3.Width = 150;
            // 
            // cms_delete
            // 
            this.cms_delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cms_delete.Name = "cms_delete";
            this.cms_delete.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(16, 56);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(156, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // bw_search
            // 
            this.bw_search.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_search_DoWork);
            this.bw_search.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_search_RunWorkerCompleted);
            // 
            // bw_delete
            // 
            this.bw_delete.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_delete_DoWork);
            this.bw_delete.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_delete_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 539);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.lv_programList);
            this.Controls.Add(this.lbl_info_remoteIpAdress);
            this.Controls.Add(this.tb_remoteIpAdress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Uninstall Software Remotely";
            this.cms_delete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_remoteIpAdress;
        private System.Windows.Forms.Label lbl_info_remoteIpAdress;
        private System.Windows.Forms.ListView lv_programList;
        private System.Windows.Forms.Button btn_search;
        private System.ComponentModel.BackgroundWorker bw_search;
        private System.Windows.Forms.ContextMenuStrip cms_delete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bw_delete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

