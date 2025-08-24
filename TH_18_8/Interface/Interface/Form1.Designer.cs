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
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.cbxtendm = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFindByDM = new System.Windows.Forms.Button();
            this.btnDeleteForm = new System.Windows.Forms.Button();
            this.btnGetAllData = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn giá: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên danh mục: ";
            // 
            // txtmasp
            // 
            this.txtmasp.Location = new System.Drawing.Point(260, 24);
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.Size = new System.Drawing.Size(354, 22);
            this.txtmasp.TabIndex = 5;
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(260, 74);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(354, 22);
            this.txttensp.TabIndex = 6;
            // 
            // txtdongia
            // 
            this.txtdongia.Location = new System.Drawing.Point(260, 124);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(354, 22);
            this.txtdongia.TabIndex = 7;
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(260, 174);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(354, 22);
            this.txtsoluong.TabIndex = 8;
            // 
            // cbxtendm
            // 
            this.cbxtendm.FormattingEnabled = true;
            this.cbxtendm.Location = new System.Drawing.Point(260, 224);
            this.cbxtendm.Name = "cbxtendm";
            this.cbxtendm.Size = new System.Drawing.Size(122, 24);
            this.cbxtendm.TabIndex = 9;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(127, 278);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(837, 174);
            this.dgvData.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(657, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 50);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Thêm sản phẩm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(834, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 50);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Sửa sản phẩm";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(657, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 50);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa sản phẩm";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnFindByDM
            // 
            this.btnFindByDM.Location = new System.Drawing.Point(834, 91);
            this.btnFindByDM.Name = "btnFindByDM";
            this.btnFindByDM.Size = new System.Drawing.Size(130, 50);
            this.btnFindByDM.TabIndex = 14;
            this.btnFindByDM.Text = "Tìm sản phẩm theo danh mục";
            this.btnFindByDM.UseVisualStyleBackColor = true;
            // 
            // btnDeleteForm
            // 
            this.btnDeleteForm.Location = new System.Drawing.Point(657, 157);
            this.btnDeleteForm.Name = "btnDeleteForm";
            this.btnDeleteForm.Size = new System.Drawing.Size(130, 50);
            this.btnDeleteForm.TabIndex = 15;
            this.btnDeleteForm.Text = "Xóa form";
            this.btnDeleteForm.UseVisualStyleBackColor = true;
            // 
            // btnGetAllData
            // 
            this.btnGetAllData.Location = new System.Drawing.Point(834, 157);
            this.btnGetAllData.Name = "btnGetAllData";
            this.btnGetAllData.Size = new System.Drawing.Size(130, 50);
            this.btnGetAllData.TabIndex = 16;
            this.btnGetAllData.Text = "Lấy data gốc";
            this.btnGetAllData.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(657, 217);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(307, 31);
            this.btnQuit.TabIndex = 17;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 519);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnGetAllData);
            this.Controls.Add(this.btnDeleteForm);
            this.Controls.Add(this.btnFindByDM);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.cbxtendm);
            this.Controls.Add(this.txtsoluong);
            this.Controls.Add(this.txtdongia);
            this.Controls.Add(this.txttensp);
            this.Controls.Add(this.txtmasp);
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
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.ComboBox cbxtendm;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFindByDM;
        private System.Windows.Forms.Button btnDeleteForm;
        private System.Windows.Forms.Button btnGetAllData;
        private System.Windows.Forms.Button btnQuit;
    }
}

