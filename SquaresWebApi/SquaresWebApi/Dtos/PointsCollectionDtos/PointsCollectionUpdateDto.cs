using SquaresWebApi.Dtos.PointDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Dtos.PointsCollectionDtos
{
    public class PointsCollectionUpdateDto
    {
        public List<PointUpdateDto> Points { get; set; }
    }
}
