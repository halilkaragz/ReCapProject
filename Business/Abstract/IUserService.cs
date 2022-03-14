using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {       
        List<OperationClaim> GetClaims(User user);  
        User GetByMail(string email);       
    }
}
