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

        public PointsCollectionsService(PointsCollectionsRepository pointsCollectionsRepository)
        {
            _pointsCollectionsRepository = pointsCollectionsRepository;
        }
    }
}
