using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Nhatkygc
{
    public string? Mankgc { get; set; }

    public string? Tenkhachhang { get; set; }

    public DateOnly? Ngaynhanhang { get; set; }

    public DateOnly? Ngaygiaohang { get; set; }

    public string? Ptgiaohang { get; set; }

    public string? Diachi { get; set; }

    public bool? Dathanhtoan { get; set; }
}
