using Core.Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class CreditCardPaymentValidator : AbstractValidator<CreditCard>
    {
        public CreditCardPaymentValidator()
        {
            RuleFor(c => c.NameOfTheCardHolder).NotEmpty();
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.ExpirationMonth).NotEmpty();
            RuleFor(c => c.ExpirationYear).NotEmpty();
        }
    }
}
