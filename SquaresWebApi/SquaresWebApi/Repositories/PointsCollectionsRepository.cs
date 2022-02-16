using Microsoft.EntityFrameworkCore;
using School_WebAPI_BE.Repositories;
using SquaresWebApi.Data;
using SquaresWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Repositories
{
    public class PointsCollectionsRepository : RepositoryBase<PointsCollection>
    {
        public PointsCollectionsRepository(DataContext context) : base(context) { }

        public async Task<List<PointsCollection>> GetAllIncludedAsync()
        {
            return await _context.PointsCollections.Include(p => p.Points).ToListAsync();
        }

        public async Task<PointsCollection> GetByIdIncluded(int id)
        {
            return await _context.PointsCollections.Include(p => p.Points).FirstOrDefaultAsync();
        }

        public async Task<PointsCollection> GetByName(string name)
        {
            return await _context.PointsCollections.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}