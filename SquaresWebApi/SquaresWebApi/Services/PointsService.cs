using SquaresWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Services
{
    public class PointsService
    {
        private readonly PointsRepository _pointsRepository;

        public PointsService(PointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }
    }
}
