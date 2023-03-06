using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class Type
{
    public int TypeId { get; set; }

    public string? Books { get; set; }

    public string? Magazines { get; set; }

    public string? Articles { get; set; }

    public string? Textbooks { get; set; }

    public string? Infographics { get; set; }

    public virtual Source? Source { get; set; }
}
