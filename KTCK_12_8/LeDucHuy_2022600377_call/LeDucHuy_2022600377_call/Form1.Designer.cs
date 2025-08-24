namespace LeDucHuy_2022600377_call
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.txttensv = new System.Windows.Forms.TextBox();
            this.txtdiem = new System.Windows.Forms.TextBox();
            this.cbxlop = new System.Windows.Forms.ComboBox();
            this.cbxday = new System.Windows.Forms.ComboBox();
            this.cbxmonth = new System.Windows.Forms.ComboBox();
            this.cbxyear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btngetall = new System.Windows.Forms.Button();
            this.btngetbyclass = new System.Windows.Forms.Button();
            this.btndeleteform = new System.Windows.Forms.Button();
            this.btnquit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(486, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sinh viên: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sinh viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lớp: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày sinh: ";
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(273, 98);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.Size = new System.Drawing.Size(427, 22);
            this.txtmasv.TabIndex = 6;
            // 
            // txttensv
            // 
            this.txttensv.Location = new System.Drawing.Point(273, 158);
            this.txttensv.Name = "txttensv";
            this.txttensv.Size = new System.Drawing.Size(427, 22);
            this.txttensv.TabIndex = 7;
            // 
            // txtdiem
            // 
            this.txtdiem.Location = new System.Drawing.Point(273, 270);
            this.txtdiem.Name = "txtdiem";
            this.txtdiem.Size = new System.Drawing.Size(427, 22);
            this.txtdiem.TabIndex = 8;
            // 
            // cbxlop
            // 
            this.cbxlop.FormattingEnabled = true;
            this.cbxlop.Location = new System.Drawing.Point(273, 210);
            this.cbxlop.Name = "cbxlop";
            this.cbxlop.Size = new System.Drawing.Size(133, 24);
            this.cbxlop.TabIndex = 9;
            // 
            // cbxday
            // 
            this.cbxday.FormattingEnabled = true;
            this.cbxday.Location = new System.Drawing.Point(273, 323);
            this.cbxday.Name = "cbxday";
            this.cbxday.Size = new System.Drawing.Size(133, 24);
            this.cbxday.TabIndex = 10;
            // 
            // cbxmonth
            // 
            this.cbxmonth.FormattingEnabled = true;
            this.cbxmonth.Location = new System.Drawing.Point(464, 323);
            this.cbxmonth.Name = "cbxmonth";
            this.cbxmonth.Size = new System.Drawing.Size(133, 24);
            this.cbxmonth.TabIndex = 11;
            // 
            // cbxyear
            // 
            this.cbxyear.FormattingEnabled = true;
            this.cbxyear.Location = new System.Drawing.Point(655, 322);
            this.cbxyear.Name = "cbxyear";
            this.cbxyear.Size = new System.Drawing.Size(133, 24);
            this.cbxyear.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(431, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(622, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "/";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(114, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(245, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "(Ngày tháng năm theo định dạng D/M/Y)";
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(119, 388);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(917, 228);
            this.dgvData.TabIndex = 16;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CeilClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(774, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 51);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(922, 94);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(125, 51);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(774, 158);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 51);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btngetall
            // 
            this.btngetall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetall.Location = new System.Drawing.Point(922, 158);
            this.btngetall.Name = "btngetall";
            this.btngetall.Size = new System.Drawing.Size(125, 51);
            this.btngetall.TabIndex = 20;
            this.btngetall.Text = "Lấy toàn bộ sinh viên";
            this.btngetall.UseVisualStyleBackColor = true;
            this.btngetall.Click += new System.EventHandler(this.btngetall_Click);
            // 
            // btngetbyclass
            // 
            this.btngetbyclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngetbyclass.Location = new System.Drawing.Point(774, 215);
            this.btngetbyclass.Name = "btngetbyclass";
            this.btngetbyclass.Size = new System.Drawing.Size(125, 51);
            this.btngetbyclass.TabIndex = 21;
            this.btngetbyclass.Text = "Lấy sinh viên theo lớp";
            this.btngetbyclass.UseVisualStyleBackColor = true;
            this.btngetbyclass.Click += new System.EventHandler(this.btngetbyclass_Click);
            // 
            // btndeleteform
            // 
            this.btndeleteform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeleteform.Location = new System.Drawing.Point(922, 215);
            this.btndeleteform.Name = "btndeleteform";
            this.btndeleteform.Size = new System.Drawing.Size(125, 51);
            this.btndeleteform.TabIndex = 22;
            this.btndeleteform.Text = "Xóa form";
            this.btndeleteform.UseVisualStyleBackColor = true;
            this.btndeleteform.Click += new System.EventHandler(this.btndeleteform_Click);
            // 
            // btnquit
            // 
            this.btnquit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquit.Location = new System.Drawing.Point(774, 272);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(273, 44);
            this.btnquit.TabIndex = 23;
            this.btnquit.Text = "Thoát";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 634);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btndeleteform);
            this.Controls.Add(this.btngetbyclass);
            this.Controls.Add(this.btngetall);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxyear);
            this.Controls.Add(this.cbxmonth);
            this.Controls.Add(this.cbxday);
            this.Controls.Add(this.cbxlop);
            this.Controls.Add(this.txtdiem);
            this.Controls.Add(this.txttensv);
            this.Controls.Add(this.txtmasv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.TextBox txttensv;
        private System.Windows.Forms.TextBox txtdiem;
        private System.Windows.Forms.ComboBox cbxlop;
        private System.Windows.Forms.ComboBox cbxday;
        private System.Windows.Forms.ComboBox cbxmonth;
        private System.Windows.Forms.ComboBox cbxyear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btngetall;
        private System.Windows.Forms.Button btngetbyclass;
        private System.Windows.Forms.Button btndeleteform;
        private System.Windows.Forms.Button btnquit;
    }
}

