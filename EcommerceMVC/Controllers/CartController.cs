using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helper;
namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {

        private readonly MasterContext _db;

        public CartController(MasterContext context) {
            _db = context;
        }

        const string CART_KEY = "MYCART";
        public List<CartItem> Cart =>
            HttpContext.Session.Get<List<CartItem>>
            (CART_KEY) ?? new List<CartItem>(); 

        public IActionResult Index()
        {


            return View(Cart);
        }


        public IActionResult AddToCart(int id, int quantity = 1)
        {

            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.Mahh == id);
            // chưa có thì tạo mới
            if (item == null)
            {
                var hangHoa = _db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {

                    Mahh = hangHoa.MaHh,
                    TenHH = hangHoa.TenHh,
                    DonGia = hangHoa.DonGia ?? 0,
                    Hinh = hangHoa.Hinh ?? string.Empty,
                    SoLuong = quantity


                };
                gioHang.Add(item);

            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(CART_KEY,gioHang);


            return RedirectToAction("Index");
        }
    }
}
