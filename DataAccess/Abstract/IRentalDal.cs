using Core.DataAccess;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        List<RentalDetailDto> GetRentalDetailById(int rentalId);
        List<RentalDetailDto> GetRentalDetailByUserId(int userId);
        List<RentalDetailDto> GetRentalDetailByCarId(int carId);
    }
}
