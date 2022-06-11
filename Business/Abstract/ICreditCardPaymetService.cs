using Core.Entities.Concreate;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardPaymetService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> Get(int id);
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);

        IResult AddPaymnet(CreditCard creditCard);
        IResult NotAddPaymnet();
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);

    }
}
