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

namespace QLBanHang_10_8_interface
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.51.101/apibanhang/api/sanpham/");
        }

        private async Task getAllData()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
