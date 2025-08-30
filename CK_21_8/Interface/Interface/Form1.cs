using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Interface
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.51.100/apick/");
        }

        private async Task getAllNV()
        {
            HttpResponseMessage response = await client.GetAsync("nhanvien/getnv");
            string js = await response.Content.ReadAsStringAsync();
            List<NhanVien> lst_data = JsonConvert.DeserializeObject<List<NhanVien>>(js);
            dgvdata.DataSource = lst_data;
            dgvdata.ReadOnly  = true;
            cbxphongban.DataSource = lst_data.Select(x => x.TenPB).Distinct().ToList();
            cbxtrinhdo.DataSource = lst_data.Select(x => x.TrinhDo).Distinct().ToList();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllNV();
        }

        private async void btnaddnv_Click(object sender, EventArgs e)
        {
            try
            {
                
                NhanVien new_nv = new NhanVien
                {
                    MaNV = txtmanv.Text,
                    HoTen = txttennv.Text,
                    Luong = double.Parse(txtluong.Text),
                    TenPB = cbxphongban.Text,
                    TrinhDo = cbxtrinhdo.Text,
                };
                if (new_nv.Luong < 0)
                {
                    MessageBox.Show("Lương không hợp lệ !");
                }
                else
                {
                    string js = JsonConvert.SerializeObject(new_nv, Formatting.Indented);
                    var send = new StringContent(js, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("nhanvien/postnv", send);
                    MessageBox.Show(await response.Content.ReadAsStringAsync());
                    await getAllNV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btngetdatanv_Click(object sender, EventArgs e)
        {
            await getAllNV();
        }

        private async Task getAllPB()
        {
            HttpResponseMessage response = await client.GetAsync("phongban/getpb");
            string js = await response.Content.ReadAsStringAsync();
            List<PhongBan> data_pb = JsonConvert.DeserializeObject<List<PhongBan>>(js);
            dgvdata.DataSource = data_pb;
        }

        private async void btngetdatapb_Click(object sender, EventArgs e)
        {
            await getAllPB();
        }

        private async void btnupdatenv_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien new_nv = new NhanVien
                {
                    MaNV = txtmanv.Text,
                    HoTen = txttennv.Text,
                    Luong = double.Parse(txtluong.Text),
                    TenPB = cbxphongban.Text,
                    TrinhDo = cbxtrinhdo.Text,
                };
                if (new_nv.Luong < 0)
                {
                    MessageBox.Show("Lương không hợp lệ !");
                }
                else
                {
                    string js = JsonConvert.SerializeObject(new_nv, Formatting.Indented);
                    var send = new StringContent(js, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync("nhanvien/putnv", send);
                    MessageBox.Show(await response.Content.ReadAsStringAsync());
                    await getAllNV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            NhanVien choose = (NhanVien)dgvdata.CurrentRow.DataBoundItem;
            txtmanv.Text = choose.MaNV;
            txttennv.Text = choose.HoTen;
            txtluong.Text = choose.Luong.ToString();
            cbxphongban.Text = choose.TenPB;
            cbxtrinhdo.Text = choose.TrinhDo;
        }

        private async void btndeletepb_Click(object sender, EventArgs e)
        {
            string tenpb = cbxphongban.Text;
            HttpResponseMessage response = await client.DeleteAsync($"phongban/deletepb/{tenpb}");
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            await getAllPB();
        }

        private void btndeleteform_Click(object sender, EventArgs e)
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            txtluong.Text = "";
        }
    }
}
