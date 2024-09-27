using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.DataTransferObjects.AccountDTOs
{
    public class RegisterDTO    
    {
        [Required]
        public string? UserName {get; set;}
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}