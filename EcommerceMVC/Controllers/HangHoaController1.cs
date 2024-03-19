using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Controllers
{
    public class HangHoaController1 : Controller
    {

        private readonly MasterContext db;
        

        public HangHoaController1(MasterContext context) => db = context;
 

        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
               hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
               
            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            }) ;

            return View(result);
        }
        public IActionResult Search(string? searchQuery) {
            // query
           
           
            var hangHoas = db.HangHoas.AsQueryable();
            if ( searchQuery != null )
            {
                hangHoas = hangHoas.Where(query =>query.TenHh.Contains(searchQuery));
            }
          
            
            var result = hangHoas.Select(hh => new HangHoaVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia ?? 0,
                Hinh = hh.Hinh ?? "",
                MoTaNgan = hh.MoTaDonVi ?? "",
                TenLoai = hh.MaLoaiNavigation.TenLoai
            });

           

            return View(result);
        
        }
        // detail
        public IActionResult  Detail(int id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(hh => hh.MaHh == id);
            if( data == null)
            {
                TempData["Message"] = $"Không thấy mã sản phẩm{id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHh = data.MaHh,
                TenHH = data.TenHh,
                DonGia = data.DonGia?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTaNgan = data.MoTaDonVi ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,
                DiemDanhGia = 5,

            };
            return View(result);
        }


    }
}
