using System;
using System.Collections.Generic;

namespace StudentManagement_MVC.Models.StuddentManagement_database;

public partial class Subject
{
    public string SubId { get; set; } = null!;

    public string Subname { get; set; } = null!;

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
