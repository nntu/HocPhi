﻿namespace HocPhi
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_CreateQR = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_Template = new System.Windows.Forms.LinkLabel();
            this.bt_CreateQR_LoadFile = new System.Windows.Forms.Button();
            this.tienNopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sttDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTKNopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taikhoannopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mahsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenHocSinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiPhiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sotienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tb_CreateQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienNopBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb_CreateQR);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tb_CreateQR
            // 
            this.tb_CreateQR.Controls.Add(this.statusStrip1);
            this.tb_CreateQR.Controls.Add(this.splitContainer1);
            this.tb_CreateQR.Location = new System.Drawing.Point(4, 22);
            this.tb_CreateQR.Name = "tb_CreateQR";
            this.tb_CreateQR.Padding = new System.Windows.Forms.Padding(3);
            this.tb_CreateQR.Size = new System.Drawing.Size(792, 424);
            this.tb_CreateQR.TabIndex = 0;
            this.tb_CreateQR.Text = "CreateQR";
            this.tb_CreateQR.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.bt_CreateQR_LoadFile);
            this.splitContainer1.Panel1.Controls.Add(this.lb_Template);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(786, 418);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sttDataGridViewTextBoxColumn,
            this.tenTKNopDataGridViewTextBoxColumn,
            this.taikhoannopDataGridViewTextBoxColumn,
            this.mahsDataGridViewTextBoxColumn,
            this.hotenHocSinhDataGridViewTextBoxColumn,
            this.lopDataGridViewTextBoxColumn,
            this.loaiPhiDataGridViewTextBoxColumn,
            this.sotienDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tienNopBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(786, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // lb_Template
            // 
            this.lb_Template.AutoSize = true;
            this.lb_Template.Location = new System.Drawing.Point(18, 14);
            this.lb_Template.Name = "lb_Template";
            this.lb_Template.Size = new System.Drawing.Size(67, 13);
            this.lb_Template.TabIndex = 0;
            this.lb_Template.TabStop = true;
            this.lb_Template.Text = "Lấy File Mẫu";
            this.lb_Template.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_Template_LinkClicked);
            // 
            // bt_CreateQR_LoadFile
            // 
            this.bt_CreateQR_LoadFile.Location = new System.Drawing.Point(91, 9);
            this.bt_CreateQR_LoadFile.Name = "bt_CreateQR_LoadFile";
            this.bt_CreateQR_LoadFile.Size = new System.Drawing.Size(75, 23);
            this.bt_CreateQR_LoadFile.TabIndex = 1;
            this.bt_CreateQR_LoadFile.Text = "Đọc File";
            this.bt_CreateQR_LoadFile.UseVisualStyleBackColor = true;
            this.bt_CreateQR_LoadFile.Click += new System.EventHandler(this.bt_CreateQR_LoadFile_Click);
            // 
            // tienNopBindingSource
            // 
            this.tienNopBindingSource.DataSource = typeof(HocPhi.DataModel.TienNop);
            // 
            // sttDataGridViewTextBoxColumn
            // 
            this.sttDataGridViewTextBoxColumn.DataPropertyName = "Stt";
            this.sttDataGridViewTextBoxColumn.HeaderText = "Stt";
            this.sttDataGridViewTextBoxColumn.Name = "sttDataGridViewTextBoxColumn";
            this.sttDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tenTKNopDataGridViewTextBoxColumn
            // 
            this.tenTKNopDataGridViewTextBoxColumn.DataPropertyName = "TenTK_Nop";
            this.tenTKNopDataGridViewTextBoxColumn.HeaderText = "TenTK_Nop";
            this.tenTKNopDataGridViewTextBoxColumn.Name = "tenTKNopDataGridViewTextBoxColumn";
            this.tenTKNopDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taikhoannopDataGridViewTextBoxColumn
            // 
            this.taikhoannopDataGridViewTextBoxColumn.DataPropertyName = "Tai_khoan_nop";
            this.taikhoannopDataGridViewTextBoxColumn.HeaderText = "Tai_khoan_nop";
            this.taikhoannopDataGridViewTextBoxColumn.Name = "taikhoannopDataGridViewTextBoxColumn";
            this.taikhoannopDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mahsDataGridViewTextBoxColumn
            // 
            this.mahsDataGridViewTextBoxColumn.DataPropertyName = "ma_hs";
            this.mahsDataGridViewTextBoxColumn.HeaderText = "ma_hs";
            this.mahsDataGridViewTextBoxColumn.Name = "mahsDataGridViewTextBoxColumn";
            this.mahsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hotenHocSinhDataGridViewTextBoxColumn
            // 
            this.hotenHocSinhDataGridViewTextBoxColumn.DataPropertyName = "Hoten_HocSinh";
            this.hotenHocSinhDataGridViewTextBoxColumn.HeaderText = "Hoten_HocSinh";
            this.hotenHocSinhDataGridViewTextBoxColumn.Name = "hotenHocSinhDataGridViewTextBoxColumn";
            this.hotenHocSinhDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lopDataGridViewTextBoxColumn
            // 
            this.lopDataGridViewTextBoxColumn.DataPropertyName = "Lop";
            this.lopDataGridViewTextBoxColumn.HeaderText = "Lop";
            this.lopDataGridViewTextBoxColumn.Name = "lopDataGridViewTextBoxColumn";
            this.lopDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loaiPhiDataGridViewTextBoxColumn
            // 
            this.loaiPhiDataGridViewTextBoxColumn.DataPropertyName = "LoaiPhi";
            this.loaiPhiDataGridViewTextBoxColumn.HeaderText = "LoaiPhi";
            this.loaiPhiDataGridViewTextBoxColumn.Name = "loaiPhiDataGridViewTextBoxColumn";
            this.loaiPhiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sotienDataGridViewTextBoxColumn
            // 
            this.sotienDataGridViewTextBoxColumn.DataPropertyName = "So_tien";
            this.sotienDataGridViewTextBoxColumn.HeaderText = "So_tien";
            this.sotienDataGridViewTextBoxColumn.Name = "sotienDataGridViewTextBoxColumn";
            this.sotienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 1;
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tạo QR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tb_CreateQR.ResumeLayout(false);
            this.tb_CreateQR.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienNopBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_CreateQR;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bt_CreateQR_LoadFile;
        private System.Windows.Forms.LinkLabel lb_Template;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTKNopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taikhoannopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenHocSinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiPhiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sotienDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tienNopBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

