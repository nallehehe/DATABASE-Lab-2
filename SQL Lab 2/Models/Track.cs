using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Lab_2.Data;

public class Track
{
    public int TrackID { get; set; }

    public string Name { get; set; }

    public string? Composer { get; set; }

    public int Milliseconds { get; set; }

    public int Bytes { get; set; }

    public double UnitPrice { get; set; }

    public int AlbumId { get; set; }

    public Album Album { get; set; }

    public int MediaTypeId { get; set; }

    public MediaType MediaType { get; set; }

    public int GenreId { get; set; }

    public Genre Genre { get; set; }
}
