using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace SQL_Lab_2.Data;

public class Album
{
    public int AlbumId { get; set; }

    public string Title { get; set; }

    public int ArtistId { get; set; }

    public Artist Artist { get; set; }
}
