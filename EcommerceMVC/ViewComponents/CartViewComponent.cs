using EcommerceMVC.Helper;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke()
        {

            var cart = HttpContext.Session.Get<List<CartItem>>
                      (MyString.CART_KEY) ?? new List<CartItem>();



            return View("CartPanel", new CartModel

            {
                Quantity = cart.Sum(p => p.SoLuong),
                Total = cart.Sum(p => p.ThanhTien)
            });

        }
    }
}
