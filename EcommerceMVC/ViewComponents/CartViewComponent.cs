using EcommerceMVC.Helper;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace EcommerceMVC.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(AppSetting.CART_KEY) ?? new List<CartItem>();
            CartModel newModel = new CartModel
            {
                Quantity = cart.Sum(p => p.SoLuong),
                Total = cart.Sum(p => p.ThanhTien),
            };
            return View("CartPanel", newModel);
        }

    }
}
