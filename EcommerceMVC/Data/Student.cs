using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public bool? Gender { get; set; }

    public DateOnly? Dob { get; set; }
}
