using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class SourcesAuthor
{
    public int SourceAuthorId { get; set; }

    public int AuthorId { get; set; }

    public int SourceId { get; set; }

    public string? Info { get; set; }

    public virtual Source? Source { get; set; }

    public virtual Author SourceAuthor { get; set; } = null!;
}
