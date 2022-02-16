using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SquaresWebApi.Repositories
{
    public class PointsRepository : RepositoryBase<Point>
    {
        public PointsRepository(DataContext context) : base(context) { }

        public List<Point> GetAllByCollectionId(int collectionId)
        {
            return _context.Points.Where(p => p.PointsCollectionId == collectionId).ToList();
        }
    }
}
