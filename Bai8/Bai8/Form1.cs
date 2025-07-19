using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();
        private void ClearTextBox()
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            txtluong.Text = "";
            txttuoi.Text = "";
            txtxa.Text = "";
            txthuyen.Text = "";
            txttinh.Text = "";
            txtdienthoai.Text = "";
        }
        private void DisplayData()
        {
            List<NhanVien> lst_data = data.getAllNhanVien();
            dgvData.DataSource = lst_data;
            dgvData.ReadOnly = true;
            dgvData.Columns[0].Width = 50;
            dgvData.Columns[1].Width = 100;
            dgvData.Columns[2].Width = 100;
            dgvData.Columns[3].Width = 100;
            dgvData.Columns[4].Width = 100;
            dgvData.Columns[5].Width = 100;
            dgvData.Columns[6].Width = 100;
            dgvData.Columns[7].Width = 100;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        

        


        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien new_nv = new NhanVien();
            new_nv.manv = txtmanv.Text;
            new_nv.tennv = txttennv.Text;
            new_nv.tuoi = txttuoi.Text;
            new_nv.luong = txtluong.Text;
            new_nv.dienthoai = txtdienthoai.Text;
            new_nv.manv = txtmanv.Text;
            new_nv.xa = txtxa.Text;
            new_nv.huyen = txthuyen.Text;
            new_nv.tinh = txttinh.Text;
            if (data.AddNhanVien(new_nv))
            {
                MessageBox.Show("Đã thêm nhân viên thành công !", "Thông báo");
                DisplayData();
                ClearTextBox();
            }
            else
            {
                MessageBox.Show("Không thêm được nhân viên do trùng mã !");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien nv_choose = (NhanVien)dgvData.CurrentRow.DataBoundItem;
            txtmanv.Text = nv_choose.manv;
            txttennv.Text = nv_choose.tennv;
            txtluong.Text = nv_choose.luong;
            txttuoi.Text = nv_choose.tuoi;
            txtxa.Text = nv_choose.xa;
            txthuyen.Text = nv_choose.huyen;
            txttinh.Text = nv_choose.tinh;
            txtdienthoai.Text = nv_choose.dienthoai;

        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhanVien new_nv = new NhanVien();
            new_nv.manv = txtmanv.Text;
            new_nv.tennv = txttennv.Text;
            new_nv.tuoi = txttuoi.Text;
            new_nv.luong = txtluong.Text;
            new_nv.dienthoai = txtdienthoai.Text;
            new_nv.manv = txtmanv.Text;
            new_nv.xa = txtxa.Text;
            new_nv.huyen = txthuyen.Text;
            new_nv.tinh = txttinh.Text;
            if (data.SuaNV(new_nv))
            {
                MessageBox.Show("Đã sửa nhân viên thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Không tồn tại sinh viên có mã này !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ma_nv_delete = txtmanv.Text;
            if (data.XoaNV(ma_nv_delete))
            {
                DialogResult d = MessageBox.Show($"Bạn muốn xóa nhân viên có mã là {ma_nv_delete} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    MessageBox.Show("Đã xóa nhân viên thành công !");
                    DisplayData();
                }
            }
            else
            {
                MessageBox.Show("Không xóa được do không tồn tại sinh viên cần tìm !", "Thông báo");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<NhanVien> lst_find = data.findNhanVien();
            if (lst_find.Count > 0)
            {
                MessageBox.Show($"Đã tìm thấy {lst_find.Count} nhân viên !", "Thông báo");
                dgvData.DataSource = lst_find;
            }
            else
            {
                MessageBox.Show($"Không tìm thấy nhân viên !", "Thông báo");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form_search = new Form2();
            form_search.ShowDialog();
        }
    }
}
