namespace SquaresWebApi.Models
{
    public class Point : Entity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PointsCollectionId { get; set; }
        public PointsCollection PointsCollection { get; set; }
    }
}
