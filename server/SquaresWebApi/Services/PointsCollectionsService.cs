using AutoMapper;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using SquaresWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Services
{
    public class PointsCollectionsService
    {
        private readonly PointsCollectionsRepository _pointsCollectionsRepository;
        private readonly PointsRepository _pointsRepository;
        private readonly IMapper _mapper;
        private readonly PointsCollectionsValidator _collectionsValidator;
        private readonly PointsValidator _pointsValidator;

        public PointsCollectionsService(
            PointsCollectionsRepository pointsCollectionsRepository,
            PointsRepository pointsRepository, 
            IMapper mapper, PointsCollectionsValidator collectionsValidator, 
            PointsValidator pointsValidator)
        {
            _pointsCollectionsRepository = pointsCollectionsRepository;
            _pointsRepository = pointsRepository;
            _mapper = mapper;
            _collectionsValidator = collectionsValidator;
            _pointsValidator = pointsValidator;
        }

        public async Task<List<PointsCollectionGetAllDto>> GetAllAsync()
        {
            List<PointsCollection> collections = await _pointsCollectionsRepository.GetAllAsync();

            List<PointsCollectionGetAllDto> collectionsDto = _mapper.Map<List<PointsCollectionGetAllDto>>(collections);
            foreach(var c in collectionsDto)
            {
                c.PointsCount = await _pointsRepository.GetPointsCountByCollectionIdAsync(c.Id);
            }

            return collectionsDto;
        }

        public async Task<PointsCollectionGetDto> GetByIdAsync(int id)
        {
            PointsCollection collection = await _pointsCollectionsRepository.GetByIdIncludedAsync(id);

            if(collection == null)
            {
                throw new ArgumentNullException("Selected list doesn't exist.");
            }

            return _mapper.Map<PointsCollectionGetDto>(collection);
        }

        public async Task CreateAsync(PointsCollectionCreateDto collectionDto)
        {
            _collectionsValidator.RunCreateValidation(collectionDto);

            if (collectionDto.Points != null)
            {
                _pointsValidator.RunCreateValidation(collectionDto.Points);
            }
            
            PointsCollection collection = _mapper.Map<PointsCollection>(collectionDto);

            if (await CheckNameUniqueAsync(collection))
            {
                await _pointsCollectionsRepository.CreateAsync(collection);
            }
            else
            {
                await UpdateAsync(collection);
            }
        }

        public async Task DeleteAsync(int id)
        {
            PointsCollection collection = await _pointsCollectionsRepository.GetByIdIncludedAsync(id);

            if(collection == null)
            {
                throw new ArgumentNullException("Specified list doesn't exist.");
            }

            _pointsRepository.PrepareRemoveRange(collection.Points);

            await _pointsCollectionsRepository.RemoveAsync(collection);
        }

        private async Task<bool> CheckNameUniqueAsync(PointsCollection collection)
        {
            PointsCollection collectionFromDb = await _pointsCollectionsRepository.GetByNameAsync(collection.Name);

            if(collectionFromDb != null)
            {
                return false;
            }
            
            return true;
        }

        private async Task UpdateAsync(PointsCollection collection)
        {
            PointsCollection collectionFromDb = await _pointsCollectionsRepository.GetByNameAsync(collection.Name);

            _pointsRepository.PrepareRemoveRange(collectionFromDb.Points);
            collectionFromDb.Points = collection.Points;
            await _pointsCollectionsRepository.UpdateAsync(collectionFromDb);
        }
    }
}
