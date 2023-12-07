using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Lab_2.Data;

public class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; }
}
