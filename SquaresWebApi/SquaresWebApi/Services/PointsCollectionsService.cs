using AutoMapper;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Services
{
    public class PointsCollectionsService
    {
        private readonly PointsCollectionsRepository _pointsCollectionsRepository;
        private readonly IMapper _mapper;

        public PointsCollectionsService(PointsCollectionsRepository pointsCollectionsRepository, IMapper mapper)
        {
            _pointsCollectionsRepository = pointsCollectionsRepository;
            _mapper = mapper;
        }

        public async Task<List<PointsCollectionGetDto>> GetAllAsync()
        {
            List<PointsCollection> collections = await _pointsCollectionsRepository.GetAllIncludedAsync();

            return _mapper.Map<List<PointsCollectionGetDto>>(collections);
        }
    }
}
