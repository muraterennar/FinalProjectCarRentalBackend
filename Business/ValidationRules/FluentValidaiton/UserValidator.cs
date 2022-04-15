using Core.Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Address).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Birthdate).NotEmpty();
            RuleFor(u => u.CityName).NotEmpty();
            RuleFor(u => u.Gender).NotEmpty();

            RuleFor(u => u.FirstName).MinimumLength(5);
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Address).MinimumLength(10);
            RuleFor(u => u.Email).MinimumLength(8);
            RuleFor(u => u.CityName).MinimumLength(4);
            RuleFor(u => u.Gender).MaximumLength(3);
            RuleFor(u => u.Gender).MinimumLength(3);

            RuleFor(u => u.Email).Must(Contains).WithMessage("@ Karakteri bulunmalıdır");
        }

        bool Contains(string args)
        {
            return args.Contains("@");
        }
    }
}
