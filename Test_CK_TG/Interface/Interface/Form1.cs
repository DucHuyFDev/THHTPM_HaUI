using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public object Formating { get; private set; }

        public Form1()
        {
            client.BaseAddress = new Uri("http://localhost/apitt/thoitiet/");
            InitializeComponent();
        }

        private async Task getalldata()
        {
            HttpResponseMessage response = await client.GetAsync("get");
            var js = await response.Content.ReadAsStringAsync();
            List<ThongTinThoiTiet> data_get = JsonConvert.DeserializeObject<List<ThongTinThoiTiet>>(js);
            dgvData.DataSource = data_get;
            cbxmakv.DataSource = data_get.Select(x=>x.MaKhuVuc).Distinct().ToList();
            dtptime.Value = new DateTime(2025,1,1,0,0,0);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getalldata();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                ThongTinThoiTiet new_tt = new ThongTinThoiTiet
                {
                    MaKhuVuc = cbxmakv.Text,
                    Gio = dtptime.Value,
                    NhietDo = double.Parse(txtnhietdo.Text),
                    DoAm = double.Parse(txtdoam.Text),
                };
                if (new_tt.DoAm <= 0 || new_tt.DoAm > 100)
                {
                    MessageBox.Show("Độ ẩm không hợp lệ !", "Thông báo");
                }
                else
                {
                    var js = JsonConvert.SerializeObject(new_tt, Formatting.Indented);
                    var send_string = new StringContent(js, Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PostAsync("post", send_string);
                    MessageBox.Show(await res.Content.ReadAsStringAsync(), "Notification");
                    await getalldata();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errors: {ex.Message}");
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ThongTinThoiTiet choose = (ThongTinThoiTiet)dgvData.CurrentRow.DataBoundItem;
            txtdoam.Text = choose.DoAm.ToString();
            txtnhietdo.Text = choose.NhietDo.ToString();
            cbxmakv.Text = choose.MaKhuVuc;
            dtptime.Value = choose.Gio;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DateTime dt = dtptime.Value;
            string makv = cbxmakv.Text;
            DialogResult d = MessageBox.Show($"Bạn có chắc chắn muốn xóa thông tin thời tiết của thời điểm {dt}, khu vực {makv} không ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ( d == DialogResult.Yes)
            {
                string time = dtptime.Value.ToString("yyyy/MM/ddTHH:mm:ss");
                HttpResponseMessage response = await client.DeleteAsync($"delete?dt={time}&makv={makv}");
                MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo !");
                await getalldata();
            }
            
        }
    }
}
