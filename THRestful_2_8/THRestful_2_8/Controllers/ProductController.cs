using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace THRestful_2_8.Controllers
{
    public class ProductController : ApiController
    {
        private ShopDBDataContext db;
        public ProductController()
        {
            string conn_str = ConfigurationManager.ConnectionStrings["ShopDBDataContext"].ConnectionString;
            db = new ShopDBDataContext(conn_str);
        }

        [HttpGet]
        public IEnumerable<ProductDTO> get()
        {
            return db.Products.Select(x => new ProductDTO
            {
                productID = x.ProductID,
                productName = x.ProductName,
                price = x.Price,
                categoryName = x.Category.CategoryName,
            });
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetProductbyId(int id)
        {
            return db.Products.Where(x => x.ProductID == id).Select(x => new ProductDTO
            {
                productID = x.ProductID,
                productName = x.ProductName,
                price = x.Price,
                categoryName = x.Category.CategoryName,
            });
        }
        [HttpPost]
        public IHttpActionResult PostProduct(ProductDTO p)
        {
            var dm = db.Categories.FirstOrDefault(x => x.CategoryName == p.categoryName);
            if (dm == null)
            {
                return BadRequest("Danh mục không hợp lệ !");
            }
            var check = db.Products.FirstOrDefault(x => x.ProductID == p.productID);
            if (check != null)
            {
                return BadRequest("Đã tồn tại mã sản phẩm này");
            }
            
            Product new_sp = new Product();
            new_sp.ProductID = p.productID;
            new_sp.ProductName = p.productName;
            new_sp.Price = p.price;
            new_sp.CategoryID = dm.CategoryID;
            db.Products.InsertOnSubmit(new_sp);
            db.SubmitChanges();
            return Ok("Đã thêm thành công !");
        }

        [HttpPut]
        public IHttpActionResult PutProduct (ProductDTO p)
        {
            var dm = db.Categories.FirstOrDefault(x => x.CategoryName == p.categoryName);
            if (dm == null)
            {
                return BadRequest("Danh mục không hợp lệ !");
            }
            var sp_old = db.Products.FirstOrDefault(x => x.ProductID == p.productID);
            if (sp_old == null)
            {
                return BadRequest("Không tồn tại mã sản phẩm này");
            }
            sp_old.ProductID = p.productID;
            sp_old.ProductName = p.productName;
            sp_old.Price = p.price;
            sp_old.CategoryID = dm.CategoryID;
            db.SubmitChanges();
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(ProductDTO p)
        {
            var sp = db.Products.FirstOrDefault(x => x.ProductID == p.productID);
            if (sp == null)
            {
                return BadRequest("Không tồn tại mã sản phẩm này");
            }
            db.Products.DeleteOnSubmit(sp);
            db.SubmitChanges();
            return Ok("Đã xóa thành công !");
        }
    }
}
