using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Email).Must(Contains).WithMessage("@ Karakteri bulunmalıdır"); ;
            RuleFor(r => r.PhoneNumber).NotEmpty();
            RuleFor(r => r.PhoneNumber).MinimumLength(10).MaximumLength(10).WithMessage("'0' girmeden deneyin");
            RuleFor(r => r.Password).NotEmpty();
        }

        bool Contains(string args)
        {
            return args.Contains("@");
        }
    }
}
