using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BMT_API.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}
