using Organisation.Domain.Models;
using System.Threading.Tasks;

namespace Organisation.Domain.Services
{
    public interface IAccountService: IDataService<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);        
    }
    
}
