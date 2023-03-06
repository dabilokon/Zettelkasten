using System;
using System.Collections.Generic;

namespace ZettelkastenWebApplication.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public int NoteId { get; set; }

    public string Text { get; set; } = null!;

    public virtual Note TagNavigation { get; set; } = null!;
}
