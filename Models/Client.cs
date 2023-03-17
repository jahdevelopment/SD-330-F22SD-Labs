using System.ComponentModel.DataAnnotations;

namespace SD_330_F22SD_Labs.Models
{
    public class Client
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Must be between 3 and 25 characters in length")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Must be between 3 and 25 characters in length")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        // Phone number Validation retrieved from https://stackoverflow.com/questions/28904826/phone-number-validation-mvc/28905087#28905087
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
