using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetbyId(int id);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetailById(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetailByUserId(int userId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailByCarId(int carId);

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
