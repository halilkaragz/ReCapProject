using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Securty.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
