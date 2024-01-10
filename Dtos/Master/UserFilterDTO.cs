using System.ComponentModel.DataAnnotations;
namespace krodect.api.Dtos.Master;
public class UserFilterDTO
{
    [Required]
    public int id { get; set; }

    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string name { get; set; }

    [StringLength(20, ErrorMessage = "Username cannot be longer than 20 characters.")]
    public string username { get; set; }

    public bool is_active { get; set; }

    public bool send_reminder { get; set; }

    public bool wa_null { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "RegNoFactory must be greater than 0.")]
    public int regnofactory { get; set; }
}
