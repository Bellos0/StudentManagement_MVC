using System;
using System.Collections.Generic;

namespace StudentManagement_MVC.Models.StuddentManagement_database;

public partial class Score
{
    public int Id { get; set; }

    public string? StuId { get; set; }

    public string? Stuname { get; set; }

    public double? AvgScore { get; set; }

    public double? Score15 { get; set; }

    public double? Score60 { get; set; }

    public string? SubId { get; set; }

    public virtual Student? Stu { get; set; }

    public virtual Subject? Sub { get; set; }
}
