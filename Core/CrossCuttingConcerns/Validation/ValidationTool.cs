using FluentValidation;
using System;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, Object entity)
        {   
            var validationContext = new ValidationContext<object>(entity);            
            var Result = validator.Validate(validationContext);
            if (!Result.IsValid)
            {
                throw new ValidationException(Result.Errors);
            }
        }
    }
}
