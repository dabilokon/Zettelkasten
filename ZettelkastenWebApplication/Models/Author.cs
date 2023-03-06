using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Source AuthorNavigation { get; set; } = null!;

    public virtual SourcesAuthor? SourcesAuthor { get; set; }
}
