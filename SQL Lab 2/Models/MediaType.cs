using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_Lab_2.Data;

public class MediaType
{
    public int MediaTypeId { get; set; }

    public string Name { get; set; }
}
