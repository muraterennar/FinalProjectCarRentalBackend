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
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetbyId(int id);

        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int id);

        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
