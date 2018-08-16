using System.ComponentModel.DataAnnotations;

namespace AcmeCorporation.Draw.WebApi.Model
{
    public class SubmitDrawRequest
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string SerialNumber { get; set; }
    }
}