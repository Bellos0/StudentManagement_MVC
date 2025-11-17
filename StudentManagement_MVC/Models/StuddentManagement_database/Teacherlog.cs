using System;
using System.Collections.Generic;

namespace StudentManagement_MVC.Models.StuddentManagement_database;

public partial class Teacherlog
{
    public int Id { get; set; }

    public string? Uname { get; set; }

    public string? Pass { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
