namespace Interface
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
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.txtluong = new System.Windows.Forms.TextBox();
            this.cbxtrinhdo = new System.Windows.Forms.ComboBox();
            this.cbxphongban = new System.Windows.Forms.ComboBox();
            this.btnaddnv = new System.Windows.Forms.Button();
            this.btnupdatenv = new System.Windows.Forms.Button();
            this.btndeletepb = new System.Windows.Forms.Button();
            this.btngetdatapb = new System.Windows.Forms.Button();
            this.btndeleteform = new System.Windows.Forms.Button();
            this.btngetdatanv = new System.Windows.Forms.Button();
            this.btnquit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(456, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ DỰ ÁN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên nhân viên: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trình độ: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lương: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tên phòng ban: ";
            // 
            // dgvdata
            // 
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Location = new System.Drawing.Point(74, 350);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.RowTemplate.Height = 24;
            this.dgvdata.Size = new System.Drawing.Size(852, 210);
            this.dgvdata.TabIndex = 6;
            this.dgvdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CeilClick);
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(223, 75);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(364, 22);
            this.txtmanv.TabIndex = 7;
            // 
            // txttennv
            // 
            this.txttennv.Location = new System.Drawing.Point(223, 132);
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(364, 22);
            this.txttennv.TabIndex = 8;
            // 
            // txtluong
            // 
            this.txtluong.Location = new System.Drawing.Point(223, 242);
            this.txtluong.Name = "txtluong";
            this.txtluong.Size = new System.Drawing.Size(364, 22);
            this.txtluong.TabIndex = 9;
            // 
            // cbxtrinhdo
            // 
            this.cbxtrinhdo.FormattingEnabled = true;
            this.cbxtrinhdo.Location = new System.Drawing.Point(223, 187);
            this.cbxtrinhdo.Name = "cbxtrinhdo";
            this.cbxtrinhdo.Size = new System.Drawing.Size(168, 24);
            this.cbxtrinhdo.TabIndex = 10;
            // 
            // cbxphongban
            // 
            this.cbxphongban.FormattingEnabled = true;
            this.cbxphongban.Location = new System.Drawing.Point(223, 297);
            this.cbxphongban.Name = "cbxphongban";
            this.cbxphongban.Size = new System.Drawing.Size(168, 24);
            this.cbxphongban.TabIndex = 11;
            // 
            // btnaddnv
            // 
            this.btnaddnv.Location = new System.Drawing.Point(628, 76);
            this.btnaddnv.Name = "btnaddnv";
            this.btnaddnv.Size = new System.Drawing.Size(145, 36);
            this.btnaddnv.TabIndex = 12;
            this.btnaddnv.Text = "Thêm nhân viên";
            this.btnaddnv.UseVisualStyleBackColor = true;
            this.btnaddnv.Click += new System.EventHandler(this.btnaddnv_Click);
            // 
            // btnupdatenv
            // 
            this.btnupdatenv.Location = new System.Drawing.Point(779, 75);
            this.btnupdatenv.Name = "btnupdatenv";
            this.btnupdatenv.Size = new System.Drawing.Size(147, 36);
            this.btnupdatenv.TabIndex = 13;
            this.btnupdatenv.Text = "Sửa nhân viên";
            this.btnupdatenv.UseVisualStyleBackColor = true;
            this.btnupdatenv.Click += new System.EventHandler(this.btnupdatenv_Click);
            // 
            // btndeletepb
            // 
            this.btndeletepb.Location = new System.Drawing.Point(628, 132);
            this.btndeletepb.Name = "btndeletepb";
            this.btndeletepb.Size = new System.Drawing.Size(145, 36);
            this.btndeletepb.TabIndex = 14;
            this.btndeletepb.Text = "Xóa phòng ban";
            this.btndeletepb.UseVisualStyleBackColor = true;
            this.btndeletepb.Click += new System.EventHandler(this.btndeletepb_Click);
            // 
            // btngetdatapb
            // 
            this.btngetdatapb.Location = new System.Drawing.Point(779, 132);
            this.btngetdatapb.Name = "btngetdatapb";
            this.btngetdatapb.Size = new System.Drawing.Size(147, 36);
            this.btngetdatapb.TabIndex = 15;
            this.btngetdatapb.Text = "Lấy DS phòng ban";
            this.btngetdatapb.UseVisualStyleBackColor = true;
            this.btngetdatapb.Click += new System.EventHandler(this.btngetdatapb_Click);
            // 
            // btndeleteform
            // 
            this.btndeleteform.Location = new System.Drawing.Point(628, 187);
            this.btndeleteform.Name = "btndeleteform";
            this.btndeleteform.Size = new System.Drawing.Size(145, 36);
            this.btndeleteform.TabIndex = 16;
            this.btndeleteform.Text = "Xóa form";
            this.btndeleteform.UseVisualStyleBackColor = true;
            this.btndeleteform.Click += new System.EventHandler(this.btndeleteform_Click);
            // 
            // btngetdatanv
            // 
            this.btngetdatanv.Location = new System.Drawing.Point(779, 187);
            this.btngetdatanv.Name = "btngetdatanv";
            this.btngetdatanv.Size = new System.Drawing.Size(147, 36);
            this.btngetdatanv.TabIndex = 17;
            this.btngetdatanv.Text = "Lấy DS nhân viên";
            this.btngetdatanv.UseVisualStyleBackColor = true;
            this.btngetdatanv.Click += new System.EventHandler(this.btngetdatanv_Click);
            // 
            // btnquit
            // 
            this.btnquit.Location = new System.Drawing.Point(628, 242);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(298, 36);
            this.btnquit.TabIndex = 19;
            this.btnquit.Text = "Đóng phần mềm";
            this.btnquit.UseVisualStyleBackColor = true;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 596);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btngetdatanv);
            this.Controls.Add(this.btndeleteform);
            this.Controls.Add(this.btngetdatapb);
            this.Controls.Add(this.btndeletepb);
            this.Controls.Add(this.btnupdatenv);
            this.Controls.Add(this.btnaddnv);
            this.Controls.Add(this.cbxphongban);
            this.Controls.Add(this.cbxtrinhdo);
            this.Controls.Add(this.txtluong);
            this.Controls.Add(this.txttennv);
            this.Controls.Add(this.txtmanv);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.TextBox txtluong;
        private System.Windows.Forms.ComboBox cbxtrinhdo;
        private System.Windows.Forms.ComboBox cbxphongban;
        private System.Windows.Forms.Button btnaddnv;
        private System.Windows.Forms.Button btnupdatenv;
        private System.Windows.Forms.Button btndeletepb;
        private System.Windows.Forms.Button btngetdatapb;
        private System.Windows.Forms.Button btndeleteform;
        private System.Windows.Forms.Button btngetdatanv;
        private System.Windows.Forms.Button btnquit;
    }
}

