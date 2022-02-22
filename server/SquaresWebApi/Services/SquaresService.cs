using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Dtos.SquareDtos;
using System.Collections.Generic;

namespace SquaresWebApi.Services
{
    public class SquaresService
    {
        public void GetSquares(PointsCollectionSquaresDto collectionDto)
        {
            for(int a = 0; a < collectionDto.Points.Count; a++)
            {
                var A = collectionDto.Points[a];
                for(int b = 0; b < collectionDto.Points.Count; b++)
                {
                    if(b != a)
                    {
                        var B = collectionDto.Points[b];
                        for (int c = 0; c < collectionDto.Points.Count; c++)
                        {
                            if(c != a && c != b)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void GetVectorsAngle(Vector AB, Vector AC)
        {

        }
        
        private List<Vector> FormVectors(PointSquaresDto a, PointSquaresDto b, PointSquaresDto c)
        {
            Vector AB = new Vector()
            {
                Start = a,
                End = b
            };

            Vector AC = new Vector()
            {
                Start = a,
                End = c
            };

            return new List<Vector>() { AB, AC };
        }
    }
}
