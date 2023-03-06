using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class Source
{
    public int SourceId { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Note? Note { get; set; }

    public virtual Type Source1 { get; set; } = null!;

    public virtual SourcesAuthor SourceNavigation { get; set; } = null!;
}
