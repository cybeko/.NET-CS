using System;
using System.Collections.Generic;

namespace hw6;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Count { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
