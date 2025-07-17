using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Bai7._1
{
    public partial class Form1 : Form
    {
        DataUtil data = new DataUtil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.ReadOnly = true;
            DisplayData();
        }

        private void DisplayData()
        {
            dgvTaiKhoan.DataSource = data.GetAllData();
            dgvTaiKhoan.Columns[0].Width = 70;
            dgvTaiKhoan.Columns[1].Width = 150;
            dgvTaiKhoan.Columns[2].Width = 120;
            dgvTaiKhoan.Columns[3].Width = 100;
            dgvTaiKhoan.Columns[4].Width = 100;
            dgvTaiKhoan.Columns[0].HeaderText = "Số TK";
            dgvTaiKhoan.Columns[1].HeaderText = "Tên TK";
            dgvTaiKhoan.Columns[2].HeaderText = "Địa chỉ";
            dgvTaiKhoan.Columns[3].HeaderText = "Điện thoại";
            dgvTaiKhoan.Columns[4].HeaderText = "Số tiền";
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaiKhoan new_tk = new TaiKhoan();
            new_tk.stk = txtSTK.Text;
            new_tk.tentk = txtTenTK.Text;
            new_tk.diachi = txtDiaChi.Text;
            new_tk.dienthoai = txtSDT.Text;
            new_tk.sotien = txtSoTien.Text;
            if (data.AddTK(new_tk))
            {
                DisplayData();
                MessageBox.Show("Thêm thành công!", "Thong báo");
            }
            else
            {
                MessageBox.Show("Đã có số tài khoản này. Vui lòng xem lại số tài khoản !", "Cảnh báo");
            }
        }
    }
}
