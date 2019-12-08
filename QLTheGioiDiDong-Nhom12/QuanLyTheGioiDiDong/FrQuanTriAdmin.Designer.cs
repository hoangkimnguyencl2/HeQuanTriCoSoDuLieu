namespace QuanLyTheGioiDiDong
{
    partial class FrQuanTriAdmin
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbbSanPham = new System.Windows.Forms.ComboBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChayGiamGiaHomNay = new System.Windows.Forms.Timer(this.components);
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnaddUser = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(32, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 39);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xin chào Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quản Lý Sản Phẩm";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnRevenue);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cbbSanPham);
            this.panel1.Controls.Add(this.cbbNhanVien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(32, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 412);
            this.panel1.TabIndex = 4;
            // 
            // btnRevenue
            // 
            this.btnRevenue.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.revenue1;
            this.btnRevenue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRevenue.Location = new System.Drawing.Point(142, 368);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(94, 32);
            this.btnRevenue.TabIndex = 11;
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Visible = false;
            this.btnRevenue.Click += new System.EventHandler(this.BtnRevenue_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.Load;
            this.btnLoadData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadData.Location = new System.Drawing.Point(25, 368);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(94, 32);
            this.btnLoadData.TabIndex = 10;
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.BtnLoadData_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Location = new System.Drawing.Point(187, 298);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(58, 55);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.Delete;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(103, 298);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(58, 55);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.addbtn1;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(18, 298);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 55);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // cbbSanPham
            // 
            this.cbbSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSanPham.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cbbSanPham.FormattingEnabled = true;
            this.cbbSanPham.Items.AddRange(new object[] {
            "Quản Lý Sản Phẩm",
            "Quản Lý Nhóm Sản Phẩm",
            "Quản Lý Khách Hàng"});
            this.cbbSanPham.Location = new System.Drawing.Point(25, 205);
            this.cbbSanPham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbSanPham.Name = "cbbSanPham";
            this.cbbSanPham.Size = new System.Drawing.Size(221, 33);
            this.cbbSanPham.TabIndex = 6;
            this.cbbSanPham.SelectedIndexChanged += new System.EventHandler(this.CbbSanPham_SelectedIndexChanged);
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNhanVien.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Items.AddRange(new object[] {
            "Quản Lý Nhân Viên",
            "Quản Lý Group Nhân Viên",
            "Quản Lý Doanh Thu Nhân Viên"});
            this.cbbNhanVien.Location = new System.Drawing.Point(25, 68);
            this.cbbNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(221, 33);
            this.cbbNhanVien.TabIndex = 5;
            this.cbbNhanVien.SelectedIndexChanged += new System.EventHandler(this.CbbNhanVien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Nhân Sự";
            // 
            // ChayGiamGiaHomNay
            // 
            this.ChayGiamGiaHomNay.Tick += new System.EventHandler(this.ChayGiamGiaHomNay_Tick);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(296, 89);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.Size = new System.Drawing.Size(542, 412);
            this.dgvMain.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt2);
            this.panel2.Controls.Add(this.txt1);
            this.panel2.Location = new System.Drawing.Point(11, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 8);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(14, 44);
            this.txt2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(76, 20);
            this.txt2.TabIndex = 1;
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(14, 11);
            this.txt1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(76, 20);
            this.txt1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.logout;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOut.Location = new System.Drawing.Point(786, 1);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(46, 40);
            this.btnLogOut.TabIndex = 12;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // btnaddUser
            // 
            this.btnaddUser.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.adduser;
            this.btnaddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnaddUser.Location = new System.Drawing.Point(727, -1);
            this.btnaddUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnaddUser.Name = "btnaddUser";
            this.btnaddUser.Size = new System.Drawing.Size(46, 40);
            this.btnaddUser.TabIndex = 11;
            this.btnaddUser.UseVisualStyleBackColor = true;
            this.btnaddUser.Click += new System.EventHandler(this.BtnaddUser_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackgroundImage = global::QuanLyTheGioiDiDong.Properties.Resources.undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.Location = new System.Drawing.Point(672, -1);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(41, 41);
            this.btnUndo.TabIndex = 10;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // FrQuanTriAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 511);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnaddUser);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrQuanTriAdmin";
            this.Text = "FrQuanTriAdmin";
            this.Load += new System.EventHandler(this.FrQuanTriAdmin_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer ChayGiamGiaHomNay;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.ComboBox cbbSanPham;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnaddUser;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnRevenue;
    }
}