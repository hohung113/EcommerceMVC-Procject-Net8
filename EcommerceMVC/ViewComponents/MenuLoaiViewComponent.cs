using EcommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.ViewModels;

namespace EcommerceMVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly MasterContext db;
        
        public MenuLoaiViewComponent(MasterContext context) => db = context; 

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai= lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p=> p.TenLoai);
            return View(data); // Default.cshtml
        }
    }
}
