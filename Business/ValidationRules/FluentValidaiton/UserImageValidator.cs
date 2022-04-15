using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidaiton
{
    public class UserImageValidator : AbstractValidator<UserImage>
    {
        public UserImageValidator()
        {
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.ImagePath).NotEmpty();
        }
    }
}
