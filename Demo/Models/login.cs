using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class login
    {
        [Key]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? emailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
