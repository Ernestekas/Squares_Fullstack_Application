using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;

namespace SquaresWebApi.Repositories
{
    public class PointsCollectionsRepository : RepositoryBase<PointsCollection>
    {
        public PointsCollectionsRepository(DataContext context) : base(context) { }
    }
}
