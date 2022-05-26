using Core.Entities.Concreate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class AuthValidator:AbstractValidator<UserForLoginDto>
    {
        public AuthValidator()
        {
            RuleFor(a=>a.Email).NotEmpty();
            RuleFor(a=>a.Email).Must(Contains).WithMessage("'@' işarti bulunmalıdır.");
            RuleFor(a=>a.Password).NotEmpty();
        }

        bool Contains(string args)
        {
            return args.Contains("@");
        }
    }
}
