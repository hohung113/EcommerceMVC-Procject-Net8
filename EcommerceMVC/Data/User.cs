﻿using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? UserRole { get; set; }
}
