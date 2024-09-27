using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }

}