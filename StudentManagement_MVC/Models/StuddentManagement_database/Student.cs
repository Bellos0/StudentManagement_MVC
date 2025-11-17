using System;
using System.Collections.Generic;

namespace StudentManagement_MVC.Models.StuddentManagement_database;

public partial class Student
{
    public int Id { get; set; }

    public string StuId { get; set; } = null!;

    public string? Fullname { get; set; }

    public DateOnly? DoB { get; set; }

    public string? Sex { get; set; }

    public string? Class { get; set; }

    public string? Address { get; set; }

    public string? ParentPhone { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
