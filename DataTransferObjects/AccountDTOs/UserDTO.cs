using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.DataTransferObjects.AccountDTOS
{
    public class UserDTO
    {   
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Token { get; set; }
    }
}