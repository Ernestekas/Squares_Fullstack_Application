using FluentValidation;
using SquaresWebApi.Dtos.PointDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Validators
{
    public class PointsValidator : ValidatorBase<PointDtoBase>
    {
        public PointsValidator()
        {
            RuleFor(p => p.X).NotEmpty();
            RuleFor(p => p.X).InclusiveBetween(-5000, 5000);
            
            RuleFor(p => p.Y).NotEmpty();
            RuleFor(p => p.X).InclusiveBetween(-5000, 5000);
        }
    }
}
