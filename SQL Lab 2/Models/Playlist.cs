using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Lab_2.Data;

public class Playlist
{
    public int PlaylistId { get; set; }

    public string Name { get; set; }

    public Collection<Track> Tracks { get; set; }

}
