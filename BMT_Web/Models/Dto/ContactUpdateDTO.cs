using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BMT_Web.Models.Dto
{
    public class ContactUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(30)]
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
