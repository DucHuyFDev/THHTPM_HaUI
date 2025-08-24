using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SanPhamController : ApiController
    {
        QLSPEntities db = new QLSPEntities();
        [HttpGet]
        [Route("api/getall")]
        public IEnumerable<SanPhamDTO> get()
        {
            var result = db.SanPhams.Select(x => new SanPhamDTO
            {
                madm = x.MaDM,
                tensp = x.TenSP,
                dongia = x.DonGia,
                soluong = x.SoLuong,
                masp = x.MaSP,
            });
            return result;
        }

        [HttpGet]
        [Route("api/getbydm/{tendm}")]
        public IEnumerable<SanPhamDTO> getbydm(string madm)
        {
            var dmfind = db.DanhMucs.FirstOrDefault(x => x.MaDM == madm);
            if (dmfind == null)
            {
                return null;
            }
            var spfind = db.SanPhams.Where(x => x.MaDM == dmfind.MaDM).Select(x => new SanPhamDTO
            {
                madm = x.MaDM,
                tensp = x.TenSP,
                dongia = x.DonGia,
                soluong = x.SoLuong,
                masp = x.MaSP
            });
            return spfind;

        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult post (SanPhamDTO add_sp)
        {
            var dmfind = db.DanhMucs.FirstOrDefault(x => x.MaDM == add_sp.madm);
            if (dmfind == null)
            {
                return Ok("Không tìm thấy danh mục tương ứng");
            }
            var spcheck = db.SanPhams.FirstOrDefault(x => x.MaSP == add_sp.masp);
            if (spcheck != null)
            {
                return Ok("Mã sản phẩm đã tồn tại");
            }
            SanPham new_sp = new SanPham
            {
                MaSP = add_sp.masp,
                TenSP = add_sp.tensp,
                SoLuong = add_sp.soluong,
                MaDM = add_sp.madm,
                DonGia = add_sp.dongia
            };
            db.SanPhams.Add(new_sp);
            db.SaveChanges();
            return Ok("Thêm thành công !");
        }

        [HttpPut]
        [Route("api/put")]
        public IHttpActionResult put(SanPhamDTO update_sp)
        {
            var dmfind = db.DanhMucs.FirstOrDefault(x => x.MaDM == update_sp.madm);
            if (dmfind == null)
            {
                return Ok("Không tìm thấy danh mục tương ứng");
            }
            var spcheck = db.SanPhams.FirstOrDefault(x => x.MaSP == update_sp.masp);
            if (spcheck == null)
            {
                return Ok("Không có sản phẩm có mã đang tìm");
            }
            spcheck.TenSP = update_sp.tensp;
            spcheck.SoLuong = update_sp.soluong;
            spcheck.DonGia = update_sp.dongia;
            spcheck.MaDM = update_sp.madm;
            db.SaveChanges();
            return Ok("Cập nhật thành công !");
        }

        [HttpDelete]
        [Route("api/delete/{masp}")]
        public IHttpActionResult delete(string masp)
        {
            
            var spcheck = db.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (spcheck == null)
            {
                return Ok("Không có sản phẩm có mã đang tìm");
            }
            db.SanPhams.Remove(spcheck);
            db.SaveChanges();
            return Ok("Xoá thành công !");
        }
    }
}
