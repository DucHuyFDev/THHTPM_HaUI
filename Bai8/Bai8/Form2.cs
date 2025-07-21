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

namespace Bai8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();
        
        private void Form2_Load(object sender, EventArgs e)
        {
            List<NhanVien> lst_nv = data.getAllNhanVien();
            cboxtinh.DataSource = lst_nv.Select(x => x.tinh).Distinct().ToList();     
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tinh_search = cboxtinh.Text;
            List<NhanVien> lst_search = data.findNVwithtinh(tinh_search);
            dgvSearch.DataSource = lst_search;
            dgvSearch.ReadOnly = true;
            if (lst_search.Count > 0 )
            {
                dgvSearch.Columns[0].Width = 50;
                dgvSearch.Columns[1].Width = 100;
                dgvSearch.Columns[2].Width = 100;
                dgvSearch.Columns[3].Width = 100;
                dgvSearch.Columns[4].Width = 100;
                dgvSearch.Columns[5].Width = 100;
                dgvSearch.Columns[6].Width = 100;
                dgvSearch.Columns[7].Width = 100;
                MessageBox.Show($"Tìm thấy {lst_search.Count} nhân viên !", "Thông báo");
            }
            else
            {
                MessageBox.Show($"Không có nhân viên !", "Thông báo");
            }
            
        }
    }
}
