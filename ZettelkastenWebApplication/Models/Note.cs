using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class Note
{
    public int NoteId { get; set; }

    public string Name { get; set; } = null!;

    public int SourceId { get; set; }

    public string? Text { get; set; }

    public virtual Source NoteNavigation { get; set; } = null!;

    public virtual Tag? Tag { get; set; }
}
