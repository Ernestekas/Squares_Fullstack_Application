using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Models;
using System.Collections.Generic;

namespace SquaresWebApi.Dtos.PointsCollectionDtos
{
    public class PointsCollectionGetDto : PointsCollectionDtoBase
    {
        public int Id { get; set; }
        public List<PointGetDto> Points { get; set; }
    }
}
