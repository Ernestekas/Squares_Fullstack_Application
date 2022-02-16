using FluentValidation;
using FluentValidation.Results;
using SquaresWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        public void ValidateModel(T obj)
        {
            ValidationResult validation = Validate(obj);

            if (validation.Errors.Select(e => e.ErrorMessage).Any())
            {
                throw new ArgumentException(string.Join("; ", validation.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }
}
