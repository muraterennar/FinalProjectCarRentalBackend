using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        Type _validaitorType;

        public ValidationAspect(Type validaitorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validaitorType))
            {
                throw new System.Exception("This is not a validation class");
            }

            _validaitorType = validaitorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validaitorType);
            var entityType = _validaitorType.BaseType.GetGenericArguments()[0];
            var entites = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entites)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
