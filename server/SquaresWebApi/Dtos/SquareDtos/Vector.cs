using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Dtos.SquareDtos
{
    public class Vector
    {
        public PointSquaresDto Start { get; set; }
        public PointSquaresDto End { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
