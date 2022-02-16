using FluentValidation;
using FluentValidation.Results;
using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Dtos.PointsCollectionDtos;

namespace SquaresWebApi.Validators
{
    public class PointsCollectionsValidator : ValidatorBase<PointsCollectionCreateDto>
    {
        public PointsCollectionsValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }

        public void RunCreateValidation(PointsCollectionCreateDto collectionsDto)
        {
            ValidateModel(collectionsDto);
        }
    }
}
