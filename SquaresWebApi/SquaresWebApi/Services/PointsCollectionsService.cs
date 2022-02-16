using AutoMapper;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using SquaresWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquaresWebApi.Services
{
    public class PointsCollectionsService
    {
        private readonly PointsCollectionsRepository _pointsCollectionsRepository;
        private readonly PointsRepository _pointsRepository;
        private readonly IMapper _mapper;
        private readonly PointsCollectionsValidator _collectionsValidator;

        public PointsCollectionsService(
            PointsCollectionsRepository pointsCollectionsRepository, 
            PointsRepository pointsRepository, 
            IMapper mapper, 
            PointsCollectionsValidator validationRules)
        {
            _pointsCollectionsRepository = pointsCollectionsRepository;
            _pointsRepository = pointsRepository;
            _mapper = mapper;
            _collectionsValidator = validationRules;
        }

        public async Task<List<PointsCollectionGetDto>> GetAllAsync()
        {
            List<PointsCollection> collections = await _pointsCollectionsRepository.GetAllIncludedAsync();

            return _mapper.Map<List<PointsCollectionGetDto>>(collections);
        }

        public async Task CreateAsync(PointsCollectionCreateDto collectionDto)
        {
            _collectionsValidator.RunCreateValidation(collectionDto);

            PointsCollection collection = _mapper.Map<PointsCollection>(collectionDto);

            _pointsRepository.PrepareCreateRange(collection.Points);

            await _pointsCollectionsRepository.CreateAsync(collection);
        }

        public async Task DeleteAsync(int id)
        {
            PointsCollection collection = await _pointsCollectionsRepository.GetByIdIncluded(id);

            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _pointsRepository.PrepareRemoveRange(collection.Points);

            await _pointsCollectionsRepository.RemoveAsync(collection);
        }

        private async Task CheckIfNew(string collectionName)
        {
            List<PointsCollection> collections = await _pointsCollectionsRepository.GetAllAsync();
            
            if(collections.Select(c => c.Name == collectionName).Any())
            {
                // Update existing collection.
            }
            else
            {
                // Create new.
            }
        }
    }
}
