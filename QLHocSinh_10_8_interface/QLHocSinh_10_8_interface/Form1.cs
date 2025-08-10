using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHocSinh_10_8_interface
{
    public partial class Form1 : Form
    {
        // Tạo 1 đối tượng HttpClient
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            // Đường dẫn gốc (lát nữa triệu gọi cái nào thì thêm đuôi của cái đó tương
            // ứng với proj web API đã tạo
            client.BaseAddress = new Uri("http://192.168.51.101/apihocsinh/api/");
            
        }
        private async Task GetAllHS()
        {
            // Đưa ra request cho web (sử dụng await vì quá trình này có thể đợi lâu)
            HttpResponseMessage response = await client.GetAsync("geths");
            // Đợi respond (nên để await vì đợi phản hồi có thể lâu)
            string json = await response.Content.ReadAsStringAsync();
            // Chuyển đổi chuỗi trả về (là chuỗi json) về đối tượng trong C#
            List<HocSinh> data = JsonConvert.DeserializeObject<List<HocSinh>>(json);
            // Gán data source
            dgvData.DataSource = data;
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetAllHS();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh
            {
                mahs = txtmahs.Text,
                tenhs = txttenhs.Text,
                quequan = txtquequan.Text,
                lop = txtlop.Text,

            };
            // Chuyển từ đối tượng C# -> File JSON, Formating Indented để
            // file JSON đẹp hơn, xuống dòng hợp lý
            var json = JsonConvert.SerializeObject(hs, Formatting.Indented);
            
            // Đóng gói file JSON thành 1 request HTTP nhằm mang đi
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Đợi và lấy request về
            var response = await client.PostAsync("posths", content);
            // Trả về kết quả request
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            // Hiển thị thồng tin các học sinh
            await GetAllHS();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh
            {
                mahs = txtmahs.Text,
                tenhs = txttenhs.Text,
                quequan = txtquequan.Text,
                lop = txtlop.Text,

            };
            // Chuyển từ đối tượng C# -> File JSON, Formating Indented để file JSON đẹp hơn, xuống dòng hợp lý
            var json = JsonConvert.SerializeObject(hs, Formatting.Indented);
            // Đóng gói file JSON thành 1 request HTTP nhằm mang đi
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            // Đợi và lấy request về
            var response = await client.PutAsync($"puths/{hs.mahs}", content);
            // Trả về kết quả request
            MessageBox.Show(await response.Content.ReadAsStringAsync());  
            await GetAllHS();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtmahs.Text;
            var response = await client.DeleteAsync($"deletehs/{id}");
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            await GetAllHS();
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            HocSinh choose = (HocSinh)dgvData.CurrentRow.DataBoundItem;
            txtmahs.Text = choose.mahs;
            txttenhs.Text = choose.tenhs;
            txtquequan.Text = choose.quequan;
            txtlop.Text = choose.lop;
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtmahs.Text;
            var response = await client.GetAsync($"geths/{id}");
            string json = await response.Content.ReadAsStringAsync();
            List<HocSinh> data = JsonConvert.DeserializeObject<List<HocSinh>>(json);
            if (data.Count != 0)
            {
                MessageBox.Show($"Đã tìm thấy học sinh có mã là {id}");
                dgvData.DataSource = data;
            }
            else
            {
                MessageBox.Show($"Không  tìm thấy học sinh có mã là {id}");
            }

        }
    }
}
