using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;

namespace SquaresWebApi.Repositories
{
    public class PointsRepository : RepositoryBase<Point>
    {
        public PointsRepository(DataContext context) : base(context) { }
    }
}
