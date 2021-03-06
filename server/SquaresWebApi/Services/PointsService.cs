using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using System.Collections.Generic;

namespace SquaresWebApi.Services
{
    public class PointsService
    {
        private readonly PointsRepository _pointsRepository;

        public PointsService(PointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }

        public void PrepareCreateRange(List<Point> points)
        {
            _pointsRepository.PrepareCreateRange(points);
        }

        public void PrepareRemoveRange(List<Point> points)
        {
            _pointsRepository.PrepareRemoveRange(points);
        }
    }
}
