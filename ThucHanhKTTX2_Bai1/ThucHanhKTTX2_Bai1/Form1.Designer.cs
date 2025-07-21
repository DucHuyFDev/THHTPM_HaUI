namespace ThucHanhKTTX2_Bai1
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
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.txtloai = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.btngetAllData = new System.Windows.Forms.Button();
            this.btnaddsp = new System.Windows.Forms.Button();
            this.btndeletesp = new System.Windows.Forms.Button();
            this.btnXoaForm = new System.Windows.Forms.Button();
            this.btnupdatesp = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnfindbyprice = new System.Windows.Forms.Button();
            this.btnfindbytype = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KHO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sản phẩm: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Đơn giá: ";
            // 
            // txtmasp
            // 
            this.txtmasp.Location = new System.Drawing.Point(182, 52);
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.Size = new System.Drawing.Size(314, 22);
            this.txtmasp.TabIndex = 6;
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(182, 93);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(314, 22);
            this.txttensp.TabIndex = 7;
            // 
            // txtloai
            // 
            this.txtloai.Location = new System.Drawing.Point(182, 136);
            this.txtloai.Name = "txtloai";
            this.txtloai.Size = new System.Drawing.Size(314, 22);
            this.txtloai.TabIndex = 8;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(182, 176);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(314, 22);
            this.txtsoluong.TabIndex = 9;
            // 
            // txtdongia
            // 
            this.txtdongia.Location = new System.Drawing.Point(182, 219);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(314, 22);
            this.txtdongia.TabIndex = 10;
            // 
            // dgvdata
            // 
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Location = new System.Drawing.Point(79, 322);
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.RowHeadersWidth = 51;
            this.dgvdata.RowTemplate.Height = 24;
            this.dgvdata.Size = new System.Drawing.Size(720, 149);
            this.dgvdata.TabIndex = 11;
            this.dgvdata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CeilClick);
            // 
            // btngetAllData
            // 
            this.btngetAllData.Location = new System.Drawing.Point(520, 54);
            this.btngetAllData.Name = "btngetAllData";
            this.btngetAllData.Size = new System.Drawing.Size(121, 38);
            this.btngetAllData.TabIndex = 12;
            this.btngetAllData.Text = "Lấy data";
            this.btngetAllData.UseVisualStyleBackColor = true;
            this.btngetAllData.Click += new System.EventHandler(this.btngetAllData_Click);
            // 
            // btnaddsp
            // 
            this.btnaddsp.Location = new System.Drawing.Point(520, 98);
            this.btnaddsp.Name = "btnaddsp";
            this.btnaddsp.Size = new System.Drawing.Size(121, 38);
            this.btnaddsp.TabIndex = 13;
            this.btnaddsp.Text = "Thêm sản phẩm";
            this.btnaddsp.UseVisualStyleBackColor = true;
            this.btnaddsp.Click += new System.EventHandler(this.btnaddsp_Click);
            // 
            // btndeletesp
            // 
            this.btndeletesp.Location = new System.Drawing.Point(520, 142);
            this.btndeletesp.Name = "btndeletesp";
            this.btndeletesp.Size = new System.Drawing.Size(121, 38);
            this.btndeletesp.TabIndex = 14;
            this.btndeletesp.Text = "Xóa sản phẩm";
            this.btndeletesp.UseVisualStyleBackColor = true;
            this.btndeletesp.Click += new System.EventHandler(this.btndeletesp_Click);
            // 
            // btnXoaForm
            // 
            this.btnXoaForm.Location = new System.Drawing.Point(647, 54);
            this.btnXoaForm.Name = "btnXoaForm";
            this.btnXoaForm.Size = new System.Drawing.Size(134, 38);
            this.btnXoaForm.TabIndex = 15;
            this.btnXoaForm.Text = "Xóa form";
            this.btnXoaForm.UseVisualStyleBackColor = true;
            this.btnXoaForm.Click += new System.EventHandler(this.btnXoaForm_Click);
            // 
            // btnupdatesp
            // 
            this.btnupdatesp.Location = new System.Drawing.Point(520, 186);
            this.btnupdatesp.Name = "btnupdatesp";
            this.btnupdatesp.Size = new System.Drawing.Size(121, 38);
            this.btnupdatesp.TabIndex = 16;
            this.btnupdatesp.Text = "Sửa sản phẩm";
            this.btnupdatesp.UseVisualStyleBackColor = true;
            this.btnupdatesp.Click += new System.EventHandler(this.btnupdatesp_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(297, 279);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(164, 16);
            this.lblTotalPrice.TabIndex = 17;
            this.lblTotalPrice.Text = "Tổng giá trị các đơn hàng: ";
            // 
            // btnfindbyprice
            // 
            this.btnfindbyprice.Location = new System.Drawing.Point(647, 98);
            this.btnfindbyprice.Name = "btnfindbyprice";
            this.btnfindbyprice.Size = new System.Drawing.Size(134, 38);
            this.btnfindbyprice.TabIndex = 18;
            this.btnfindbyprice.Text = "Tìm SP theo giá";
            this.btnfindbyprice.UseVisualStyleBackColor = true;
            this.btnfindbyprice.Click += new System.EventHandler(this.btnfindbyprice_Click);
            // 
            // btnfindbytype
            // 
            this.btnfindbytype.Location = new System.Drawing.Point(647, 142);
            this.btnfindbytype.Name = "btnfindbytype";
            this.btnfindbytype.Size = new System.Drawing.Size(134, 38);
            this.btnfindbytype.TabIndex = 19;
            this.btnfindbytype.Text = "Tìm SP theo loại";
            this.btnfindbytype.UseVisualStyleBackColor = true;
            this.btnfindbytype.Click += new System.EventHandler(this.btnfindbytype_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(647, 186);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(134, 38);
            this.btnclose.TabIndex = 20;
            this.btnclose.Text = "Thoát";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 496);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnfindbytype);
            this.Controls.Add(this.btnfindbyprice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnupdatesp);
            this.Controls.Add(this.btnXoaForm);
            this.Controls.Add(this.btndeletesp);
            this.Controls.Add(this.btnaddsp);
            this.Controls.Add(this.btngetAllData);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.txtdongia);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.txtloai);
            this.Controls.Add(this.txttensp);
            this.Controls.Add(this.txtmasp);
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
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.TextBox txtloai;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Button btngetAllData;
        private System.Windows.Forms.Button btnaddsp;
        private System.Windows.Forms.Button btndeletesp;
        private System.Windows.Forms.Button btnXoaForm;
        private System.Windows.Forms.Button btnupdatesp;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnfindbyprice;
        private System.Windows.Forms.Button btnfindbytype;
        private System.Windows.Forms.Button btnclose;
    }
}

