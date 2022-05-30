using Core.DataAccess;
using Core.Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<User> GetUsers(User user);
        List<UserDetailsDto> GetUserDetails();
        List<UserDetailsDto> GetUserDetailsByUserId(int userId);
    }
}
