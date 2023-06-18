namespace HocPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_CreateQR = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_so_loai = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_so_cot_bd = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_tenfilepdf = new System.Windows.Forms.TextBox();
            this.rb_export1file = new System.Windows.Forms.RadioButton();
            this.rb_ExportALLfile = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bt_mauQr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_CreateQR_LoadFile = new System.Windows.Forms.Button();
            this.lb_Template = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sttDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phongGDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTKNopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taikhoannopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thong_bao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_nop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mahsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenHocSinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noiDungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongSoTienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienNopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_edittemplates = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tb_CreateQR.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_so_loai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_so_cot_bd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienNopBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb_CreateQR);
            this.tabControl1.Controls.Add(this.tb_edittemplates);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.nud_so_loai);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.nud_so_cot_bd);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Số Loại";
            // 
            // nud_so_loai
            // 
            this.nud_so_loai.Location = new System.Drawing.Point(105, 66);
            this.nud_so_loai.Name = "nud_so_loai";
            this.nud_so_loai.Size = new System.Drawing.Size(39, 20);
            this.nud_so_loai.TabIndex = 47;
            this.nud_so_loai.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Số cột bắt đầu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nud_so_cot_bd
            // 
            this.nud_so_cot_bd.Location = new System.Drawing.Point(105, 38);
            this.nud_so_cot_bd.Name = "nud_so_cot_bd";
            this.nud_so_cot_bd.Size = new System.Drawing.Size(39, 20);
            this.nud_so_cot_bd.TabIndex = 45;
            this.nud_so_cot_bd.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(648, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.rb_export1file);
            this.groupBox3.Controls.Add(this.rb_ExportALLfile);
            this.groupBox3.Location = new System.Drawing.Point(322, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 91);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Xuất File";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tb_tenfilepdf);
            this.groupBox4.Location = new System.Drawing.Point(16, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 43);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tên File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên File";
            // 
            // tb_tenfilepdf
            // 
            this.tb_tenfilepdf.Location = new System.Drawing.Point(58, 17);
            this.tb_tenfilepdf.Name = "tb_tenfilepdf";
            this.tb_tenfilepdf.Size = new System.Drawing.Size(205, 20);
            this.tb_tenfilepdf.TabIndex = 0;
            // 
            // rb_export1file
            // 
            this.rb_export1file.AutoSize = true;
            this.rb_export1file.Checked = true;
            this.rb_export1file.Location = new System.Drawing.Point(116, 19);
            this.rb_export1file.Name = "rb_export1file";
            this.rb_export1file.Size = new System.Drawing.Size(72, 17);
            this.rb_export1file.TabIndex = 2;
            this.rb_export1file.TabStop = true;
            this.rb_export1file.Text = "Xuất 1 file";
            this.rb_export1file.UseVisualStyleBackColor = true;
            this.rb_export1file.CheckedChanged += new System.EventHandler(this.rb_export1file_CheckedChanged);
            // 
            // rb_ExportALLfile
            // 
            this.rb_ExportALLfile.AutoSize = true;
            this.rb_ExportALLfile.Location = new System.Drawing.Point(16, 19);
            this.rb_ExportALLfile.Name = "rb_ExportALLfile";
            this.rb_ExportALLfile.Size = new System.Drawing.Size(94, 17);
            this.rb_ExportALLfile.TabIndex = 1;
            this.rb_ExportALLfile.Text = "Xuất Từng File";
            this.rb_ExportALLfile.UseVisualStyleBackColor = true;
            this.rb_ExportALLfile.CheckedChanged += new System.EventHandler(this.rb_ExportALLfile_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bt_mauQr);
            this.groupBox6.Location = new System.Drawing.Point(203, 14);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(113, 77);
            this.groupBox6.TabIndex = 42;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Màu QRcode";
            // 
            // bt_mauQr
            // 
            this.bt_mauQr.BackColor = System.Drawing.Color.Transparent;
            this.bt_mauQr.Location = new System.Drawing.Point(21, 19);
            this.bt_mauQr.Name = "bt_mauQr";
            this.bt_mauQr.Size = new System.Drawing.Size(56, 43);
            this.bt_mauQr.TabIndex = 0;
            this.bt_mauQr.Text = "Màu QR";
            this.bt_mauQr.UseVisualStyleBackColor = false;
            this.bt_mauQr.Click += new System.EventHandler(this.bt_mauQr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tạo QR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sttDataGridViewTextBoxColumn,
            this.phongGDDataGridViewTextBoxColumn,
            this.tenTKNopDataGridViewTextBoxColumn,
            this.taikhoannopDataGridViewTextBoxColumn,
            this.Thong_bao,
            this.Ky_nop,
            this.mahsDataGridViewTextBoxColumn,
            this.hotenHocSinhDataGridViewTextBoxColumn,
            this.lopDataGridViewTextBoxColumn,
            this.noiDungDataGridViewTextBoxColumn,
            this.tongSoTienDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tienNopBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(786, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // sttDataGridViewTextBoxColumn
            // 
            this.sttDataGridViewTextBoxColumn.DataPropertyName = "Stt";
            this.sttDataGridViewTextBoxColumn.HeaderText = "Stt";
            this.sttDataGridViewTextBoxColumn.Name = "sttDataGridViewTextBoxColumn";
            this.sttDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phongGDDataGridViewTextBoxColumn
            // 
            this.phongGDDataGridViewTextBoxColumn.DataPropertyName = "Phong_GD";
            this.phongGDDataGridViewTextBoxColumn.HeaderText = "Phong_GD";
            this.phongGDDataGridViewTextBoxColumn.Name = "phongGDDataGridViewTextBoxColumn";
            this.phongGDDataGridViewTextBoxColumn.ReadOnly = true;
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
            // Thong_bao
            // 
            this.Thong_bao.DataPropertyName = "Thong_bao";
            this.Thong_bao.HeaderText = "Thong_bao";
            this.Thong_bao.Name = "Thong_bao";
            this.Thong_bao.ReadOnly = true;
            // 
            // Ky_nop
            // 
            this.Ky_nop.DataPropertyName = "Ky_nop";
            this.Ky_nop.HeaderText = "Ky_nop";
            this.Ky_nop.Name = "Ky_nop";
            this.Ky_nop.ReadOnly = true;
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
            // noiDungDataGridViewTextBoxColumn
            // 
            this.noiDungDataGridViewTextBoxColumn.DataPropertyName = "NoiDung";
            this.noiDungDataGridViewTextBoxColumn.HeaderText = "NoiDung";
            this.noiDungDataGridViewTextBoxColumn.Name = "noiDungDataGridViewTextBoxColumn";
            this.noiDungDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tongSoTienDataGridViewTextBoxColumn
            // 
            this.tongSoTienDataGridViewTextBoxColumn.DataPropertyName = "Tong_So_Tien";
            this.tongSoTienDataGridViewTextBoxColumn.HeaderText = "Tong_So_Tien";
            this.tongSoTienDataGridViewTextBoxColumn.Name = "tongSoTienDataGridViewTextBoxColumn";
            this.tongSoTienDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tienNopBindingSource
            // 
            this.tienNopBindingSource.DataSource = typeof(HocPhi.TienNop);
            // 
            // tb_edittemplates
            // 
            this.tb_edittemplates.Location = new System.Drawing.Point(4, 22);
            this.tb_edittemplates.Name = "tb_edittemplates";
            this.tb_edittemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tb_edittemplates.Size = new System.Drawing.Size(792, 424);
            this.tb_edittemplates.TabIndex = 1;
            this.tb_edittemplates.Text = "Edit Template";
            this.tb_edittemplates.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Học Phí - Tunn1@bidv.com.vn - Ver: ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tb_CreateQR.ResumeLayout(false);
            this.tb_CreateQR.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_so_loai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_so_cot_bd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tienNopBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_CreateQR;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bt_CreateQR_LoadFile;
        private System.Windows.Forms.LinkLabel lb_Template;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bt_mauQr;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.BindingSource tienNopBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_tenfilepdf;
        private System.Windows.Forms.RadioButton rb_export1file;
        private System.Windows.Forms.RadioButton rb_ExportALLfile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown nud_so_cot_bd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_so_loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phongGDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTKNopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taikhoannopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thong_bao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_nop;
        private System.Windows.Forms.DataGridViewTextBoxColumn mahsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenHocSinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noiDungDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongSoTienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiThuDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tb_edittemplates;
    }
}

