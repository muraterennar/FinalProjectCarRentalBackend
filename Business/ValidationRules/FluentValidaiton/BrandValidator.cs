using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandModel).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(3);
            RuleFor(b => b.BrandModel).MinimumLength(3);
        }
    }
}
