using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Lab_2.Data;

public class Artist
{
    public int ArtistId { get; set; }

    public string Name { get; set; }
}
