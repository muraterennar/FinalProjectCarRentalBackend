using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);
        CustomerDetailDto GetCustomerDetailById(Expression<Func<Customer, bool>> filter);
        CustomerDetailDto GetCustomerDetailByEmail(Expression<Func<CustomerDetailDto, bool>> filter);
    }
}
