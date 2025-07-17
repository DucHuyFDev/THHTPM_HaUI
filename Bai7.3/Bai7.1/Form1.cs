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

        private void getATK()
        {
            TaiKhoan data_click = (TaiKhoan)dgvTaiKhoan.CurrentRow.DataBoundItem;
            txtSTK.Text = data_click.stk;
            txtTenTK.Text = data_click.tentk;
            txtDiaChi.Text = data_click.diachi;
            txtSDT.Text = data_click.dienthoai;
            txtSoTien.Text = data_click.sotien;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoan update_tk = new TaiKhoan();
            update_tk.stk = txtSTK.Text;
            update_tk.tentk = txtTenTK.Text;
            update_tk.diachi = txtDiaChi.Text;
            update_tk.dienthoai = txtSDT.Text;
            update_tk.sotien = txtSoTien.Text;
            if (data.UpdateTK(update_tk))
            {
                MessageBox.Show("Đã cập nhật thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Không cập nhật được !");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            getATK();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaiKhoan tk_delete = new TaiKhoan();
            tk_delete.stk = txtSTK.Text;
            tk_delete.tentk = txtTenTK.Text;
            tk_delete.diachi = txtDiaChi.Text;
            tk_delete.dienthoai = txtSDT.Text;
            tk_delete.sotien = txtSoTien.Text;
            if (data.Delete_TK(tk_delete))
            {
                MessageBox.Show("Xoá thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Không xóa được !", "Cảnh báo");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string stk_search = txtSTK.Text;
            List<TaiKhoan> lst_search = data.Search_TK(stk_search);
            if (lst_search.Count > 0)
            {
                MessageBox.Show("Đã tìm thấy tài khoản cần tìm !", "Thông báo");
                dgvTaiKhoan.DataSource = lst_search;
            }
            else
            {
                dgvTaiKhoan.DataSource=null;
                MessageBox.Show("Không có tài khoản cần tìm !", "Thông báo");
            }
        }
    }
}
