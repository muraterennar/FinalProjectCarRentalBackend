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
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailByCustomerDto> GetRentalDetailByCustomer(Expression<Func<Rental, bool>> filter);
        List<RentalDetailByCustomerDto> GetRentalDetailByCar(Expression<Func<Rental, bool>> filter);
    }
}
