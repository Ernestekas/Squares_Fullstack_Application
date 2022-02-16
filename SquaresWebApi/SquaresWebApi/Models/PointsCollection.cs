using System.Collections.Generic;

namespace SquaresWebApi.Models
{
    public class PointsCollection : Entity
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
    }
}
