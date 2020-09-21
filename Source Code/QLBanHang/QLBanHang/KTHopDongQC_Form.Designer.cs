namespace QLBanHang
{
    partial class KTHopDongQC_Form
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
            this.dtgv_DSHD = new System.Windows.Forms.DataGridView();
            this.label1_DSHD_848 = new System.Windows.Forms.Label();
            this.cb_HDHetHan = new System.Windows.Forms.CheckBox();
            this.bt_XemHD = new System.Windows.Forms.Button();
            this.bt_thoat = new System.Windows.Forms.Button();
            this.cbb_MaDoiTac = new System.Windows.Forms.ComboBox();
            this.dOITACQUANGCAOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2_GHHD_848 = new System.Windows.Forms.Label();
            this.label3_MAdt_848 = new System.Windows.Forms.Label();
            this.dtp_NgayGiaHan = new System.Windows.Forms.DateTimePicker();
            this.label4_GH_848 = new System.Windows.Forms.Label();
            this.bt_GiaHanHD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOITACQUANGCAOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_DSHD
            // 
            this.dtgv_DSHD.AllowUserToAddRows = false;
            this.dtgv_DSHD.AllowUserToDeleteRows = false;
            this.dtgv_DSHD.AllowUserToOrderColumns = true;
            this.dtgv_DSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_DSHD.Location = new System.Drawing.Point(4, 53);
            this.dtgv_DSHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgv_DSHD.Name = "dtgv_DSHD";
            this.dtgv_DSHD.ReadOnly = true;
            this.dtgv_DSHD.Size = new System.Drawing.Size(723, 196);
            this.dtgv_DSHD.TabIndex = 7;
            // 
            // label1_DSHD_848
            // 
            this.label1_DSHD_848.AutoSize = true;
            this.label1_DSHD_848.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_DSHD_848.ForeColor = System.Drawing.Color.Red;
            this.label1_DSHD_848.Location = new System.Drawing.Point(16, 11);
            this.label1_DSHD_848.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1_DSHD_848.Name = "label1_DSHD_848";
            this.label1_DSHD_848.Size = new System.Drawing.Size(244, 29);
            this.label1_DSHD_848.TabIndex = 6;
            this.label1_DSHD_848.Text = "Danh Sách Hợp Đồng";
            // 
            // cb_HDHetHan
            // 
            this.cb_HDHetHan.AutoSize = true;
            this.cb_HDHetHan.Location = new System.Drawing.Point(735, 53);
            this.cb_HDHetHan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_HDHetHan.Name = "cb_HDHetHan";
            this.cb_HDHetHan.Size = new System.Drawing.Size(144, 21);
            this.cb_HDHetHan.TabIndex = 8;
            this.cb_HDHetHan.Text = "Hợp đồng hết hạn";
            this.cb_HDHetHan.UseVisualStyleBackColor = true;
            // 
            // bt_XemHD
            // 
            this.bt_XemHD.Location = new System.Drawing.Point(735, 81);
            this.bt_XemHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_XemHD.Name = "bt_XemHD";
            this.bt_XemHD.Size = new System.Drawing.Size(223, 46);
            this.bt_XemHD.TabIndex = 9;
            this.bt_XemHD.Text = "Xem hợp đồng";
            this.bt_XemHD.UseVisualStyleBackColor = true;
            this.bt_XemHD.Click += new System.EventHandler(this.bt_XemHD_Click);
            // 
            // bt_thoat
            // 
            this.bt_thoat.Location = new System.Drawing.Point(857, 348);
            this.bt_thoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_thoat.Name = "bt_thoat";
            this.bt_thoat.Size = new System.Drawing.Size(100, 28);
            this.bt_thoat.TabIndex = 10;
            this.bt_thoat.Text = "Thoát";
            this.bt_thoat.UseVisualStyleBackColor = true;
            this.bt_thoat.Click += new System.EventHandler(this.bt_thoat_Click);
            // 
            // cbb_MaDoiTac
            // 
            this.cbb_MaDoiTac.DataSource = this.dOITACQUANGCAOBindingSource;
            this.cbb_MaDoiTac.DisplayMember = "MaDTQC";
            this.cbb_MaDoiTac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_MaDoiTac.FormattingEnabled = true;
            this.cbb_MaDoiTac.Location = new System.Drawing.Point(120, 314);
            this.cbb_MaDoiTac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbb_MaDoiTac.Name = "cbb_MaDoiTac";
            this.cbb_MaDoiTac.Size = new System.Drawing.Size(215, 24);
            this.cbb_MaDoiTac.TabIndex = 11;
            this.cbb_MaDoiTac.ValueMember = "MaDTQC";
            // 
            // dOITACQUANGCAOBindingSource
            // 
            this.dOITACQUANGCAOBindingSource.DataMember = "DOITACQUANGCAO";
            // 
            // label2_GHHD_848
            // 
            this.label2_GHHD_848.AutoSize = true;
            this.label2_GHHD_848.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_GHHD_848.ForeColor = System.Drawing.Color.Red;
            this.label2_GHHD_848.Location = new System.Drawing.Point(16, 265);
            this.label2_GHHD_848.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2_GHHD_848.Name = "label2_GHHD_848";
            this.label2_GHHD_848.Size = new System.Drawing.Size(214, 29);
            this.label2_GHHD_848.TabIndex = 6;
            this.label2_GHHD_848.Text = "Gia Hạn Hợp Đồng";
            // 
            // label3_MAdt_848
            // 
            this.label3_MAdt_848.AutoSize = true;
            this.label3_MAdt_848.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_MAdt_848.Location = new System.Drawing.Point(16, 314);
            this.label3_MAdt_848.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3_MAdt_848.Name = "label3_MAdt_848";
            this.label3_MAdt_848.Size = new System.Drawing.Size(73, 17);
            this.label3_MAdt_848.TabIndex = 12;
            this.label3_MAdt_848.Text = "Mã đối tác";
            // 
            // dtp_NgayGiaHan
            // 
            this.dtp_NgayGiaHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayGiaHan.Location = new System.Drawing.Point(120, 347);
            this.dtp_NgayGiaHan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_NgayGiaHan.Name = "dtp_NgayGiaHan";
            this.dtp_NgayGiaHan.Size = new System.Drawing.Size(215, 22);
            this.dtp_NgayGiaHan.TabIndex = 13;
            // 
            // label4_GH_848
            // 
            this.label4_GH_848.AutoSize = true;
            this.label4_GH_848.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_GH_848.Location = new System.Drawing.Point(16, 347);
            this.label4_GH_848.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4_GH_848.Name = "label4_GH_848";
            this.label4_GH_848.Size = new System.Drawing.Size(86, 17);
            this.label4_GH_848.TabIndex = 12;
            this.label4_GH_848.Text = "Gia hạn đến";
            // 
            // bt_GiaHanHD
            // 
            this.bt_GiaHanHD.Location = new System.Drawing.Point(369, 314);
            this.bt_GiaHanHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_GiaHanHD.Name = "bt_GiaHanHD";
            this.bt_GiaHanHD.Size = new System.Drawing.Size(357, 58);
            this.bt_GiaHanHD.TabIndex = 14;
            this.bt_GiaHanHD.Text = "Gia hạn hợp đồng";
            this.bt_GiaHanHD.UseVisualStyleBackColor = true;
            this.bt_GiaHanHD.Click += new System.EventHandler(this.bt_GiaHanHD_Click);
            // 
            // KTHopDongQC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 384);
            this.Controls.Add(this.bt_GiaHanHD);
            this.Controls.Add(this.dtp_NgayGiaHan);
            this.Controls.Add(this.label4_GH_848);
            this.Controls.Add(this.label3_MAdt_848);
            this.Controls.Add(this.cbb_MaDoiTac);
            this.Controls.Add(this.bt_thoat);
            this.Controls.Add(this.bt_XemHD);
            this.Controls.Add(this.cb_HDHetHan);
            this.Controls.Add(this.dtgv_DSHD);
            this.Controls.Add(this.label2_GHHD_848);
            this.Controls.Add(this.label1_DSHD_848);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KTHopDongQC_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KTHopDongQC_Form";
            this.Load += new System.EventHandler(this.KTHopDongQC_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DSHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOITACQUANGCAOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_DSHD;
        private System.Windows.Forms.Label label1_DSHD_848;
        private System.Windows.Forms.CheckBox cb_HDHetHan;
        private System.Windows.Forms.Button bt_XemHD;
        private System.Windows.Forms.Button bt_thoat;
        private System.Windows.Forms.ComboBox cbb_MaDoiTac;
        private System.Windows.Forms.Label label2_GHHD_848;
        private System.Windows.Forms.Label label3_MAdt_848;
        private System.Windows.Forms.DateTimePicker dtp_NgayGiaHan;
        private System.Windows.Forms.Label label4_GH_848;
        private System.Windows.Forms.BindingSource dOITACQUANGCAOBindingSource;
        private System.Windows.Forms.Button bt_GiaHanHD;
    }
}