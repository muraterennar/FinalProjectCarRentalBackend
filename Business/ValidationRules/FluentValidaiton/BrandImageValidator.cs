using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class BrandImageValidator : AbstractValidator<BrandImage>
    {
        public BrandImageValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.BrandId).NotEmpty();
            RuleFor(b => b.ImagePath).NotEmpty();
        }
    }
}
