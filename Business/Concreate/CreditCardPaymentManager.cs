using Business.Abstract;
using Business.Constants;
using Core.Entities.Concreate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CreditCardPaymentManager : ICreditCardPaymetService
    {
        ICreditCardPaymentDal _creditCardPayment;

        public CreditCardPaymentManager(ICreditCardPaymentDal creditCardPayment)
        {
            _creditCardPayment = creditCardPayment;
        }

        public IResult AddPaymnet(CreditCard creditCard)
        {
            var results = _creditCardPayment.GetAll(c => c.UserId == creditCard.UserId);
            foreach (var result in results)
            {
                _creditCardPayment.Update(result);
            }

            _creditCardPayment.Add(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardPayment.Delete(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        public IDataResult<CreditCard> Get(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardPayment.Get(c => c.Id == id), Messages.CreditCardListed);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardPayment.GetAll(), Messages.ListedAllCreditCard);
        }

        public IDataResult<CreditCard> GetByUserId(int userId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardPayment.Get(c => c.UserId == userId), Messages.ListedCreditCardbyUserId);
        }

        public IResult NotAddPaymnet()
        {
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardPayment.Update(creditCard);
            return new SuccessResult(Messages.AddedCreditCardAndToPay);
        }
    }
}
