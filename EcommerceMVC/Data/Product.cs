using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Product
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }
}
