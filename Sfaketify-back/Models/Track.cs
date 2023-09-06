using System;
using System.Collections.Generic;

namespace Sfaketify.Models;

public partial class Track
{
    public long TrackId { get; set; }

    public string? Name { get; set; }

    public long? AlbumId { get; set; }

    public string? Composer { get; set; }

    public long? Milliseconds { get; set; }

    public long? Bytes { get; set; }

    public virtual Album? Album { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
