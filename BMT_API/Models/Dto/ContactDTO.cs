using System.ComponentModel.DataAnnotations;

namespace BMT_API.Models.Dto
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CompanyName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
