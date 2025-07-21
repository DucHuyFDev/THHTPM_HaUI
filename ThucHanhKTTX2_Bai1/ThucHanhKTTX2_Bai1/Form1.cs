using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhKTTX2_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();

        private void DisplayData()
        {
            List<sanpham> ds = data.getAllData();
            dgvdata.DataSource = ds;
            dgvdata.Columns[0].Width = 50;
            dgvdata.Columns[1].Width = 150;
            dgvdata.Columns[2].Width = 100;
            dgvdata.Columns[3].Width = 100;
            dgvdata.Columns[4].Width = 100;
            lblTotalPrice.Text = "Tổng số tiền các đơn hàng là: " + data.TotalPrice().ToString() + " đồng";
        }
        private void btngetAllData_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvdata.ReadOnly = true;
            DisplayData();
        }

        private void btnaddsp_Click(object sender, EventArgs e)
        {
            sanpham new_sp = new sanpham();
            new_sp.masp = txtmasp.Text;
            new_sp.tensp = txttensp.Text;
            new_sp.loai = txtloai.Text;
            new_sp.soluong = txtsoluong.Text;
            new_sp.dongia = txtdongia.Text;
            if (data.addsp(new_sp))
            {
                MessageBox.Show("Đã thêm hàng thành công !", "Thông báo");
                Deleteform();
                DisplayData();
            }
            else MessageBox.Show("Không thêm được do trùng mã sản phẩm !", "Thông báo");
        }

        private void btndeletesp_Click(object sender, EventArgs e)
        {
            string delete_id = txtmasp.Text;
            if (data.xoasp(delete_id))
            {
                MessageBox.Show("Xóa hàng thành công !", "Thông báo");
                Deleteform();
                DisplayData();
            }
            else MessageBox.Show("Không xóa được do không tồn tại mã sản phẩm !", "Thông báo");
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            sanpham choose_sp = (sanpham)dgvdata.CurrentRow.DataBoundItem;
            txtmasp.Text = choose_sp.masp;
            txttensp.Text = choose_sp.tensp;
            txtsoluong.Text = choose_sp.soluong;
            txtloai.Text = choose_sp.loai;
            txtdongia.Text = choose_sp.dongia;
        }

        private void Deleteform()
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtloai.Text = "";
            txtdongia.Text = "";
        }
        private void btnXoaForm_Click(object sender, EventArgs e)
        {
            Deleteform();
        }

        private void btnupdatesp_Click(object sender, EventArgs e)
        {
            sanpham new_sp = new sanpham();
            new_sp.masp = txtmasp.Text;
            new_sp.tensp = txttensp.Text;
            new_sp.loai = txtloai.Text;
            new_sp.soluong = txtsoluong.Text;
            new_sp.dongia = txtdongia.Text;
            if (data.updatesp(new_sp))
            {
                MessageBox.Show("Đã sửa hàng thành công !", "Thông báo");
                Deleteform();
                DisplayData();
            }
            else MessageBox.Show("Không sửa được do không tìm thấy sản phẩm !", "Thông báo");
        }

       

        private void btnfindbyprice_Click(object sender, EventArgs e)
        {
            List<sanpham> lst_data_find = data.findWithPrice();
            if (lst_data_find.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào có đơn giá > 500000", "Thông báo !");
            }
            else
            {
                MessageBox.Show($"Có {lst_data_find.Count} sản phẩm  có đơn giá > 500000", "Thông báo !");
                dgvdata.DataSource = lst_data_find;
                dgvdata.Columns[0].Width = 50;
                dgvdata.Columns[1].Width = 150;
                dgvdata.Columns[2].Width = 100;
                dgvdata.Columns[3].Width = 100;
                dgvdata.Columns[4].Width = 100;
                lblTotalPrice.Text = "";
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnfindbytype_Click(object sender, EventArgs e)
        {
            Form2 form  = new Form2();  
            form.ShowDialog();
        }
    }
}
