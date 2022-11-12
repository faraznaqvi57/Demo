using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Demo.Models
{
    public class CarDetails
    {
        [Key]
        public int id { get; set; }
        public Brand brand { get; set; }
        public Modal modal { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only characters allowed")]
        public string? carName { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Only number allowed")]
        public double Price { get; set; }

        public New newcar { get;set; }
        
    }
    public enum Brand
    {
        Audi,
        Maruti,
        BMW,
  

    }
    public enum Modal
    {
        X2010,
        X2015,

    }

    public enum New
    {
        yes=0,
        no=1
    }

}
