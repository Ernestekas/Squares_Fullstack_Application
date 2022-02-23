using SquaresWebApi.Dtos.SquareDtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquaresWebApi.Services
{
    public class SquaresService
    {
        public List<SquareDto> GetSquares(PointsCollectionSquaresDto collectionDto)
        {
            List<SquareDto> squares = new List<SquareDto>();
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
                                var C = collectionDto.Points[c];
                                List<Vector> vectors = FormVectors(A, B, C);
                                double angle = GetVectorsAngle(vectors[0], vectors[1]);

                                if(angle == 90)
                                {
                                    SquareDto foundSquare = SearchForFourthCorner(collectionDto, vectors);
                                    if(foundSquare != null)
                                    {
                                        squares.Add(foundSquare);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return squares;
        }

        private double GetVectorsAngle(Vector AB, Vector AC)
        {
            double ABxAC = AB.X * AC.X + AB.Y * AC.Y;
            double magnitudeAB = Math.Sqrt(Math.Pow(AB.X, 2) + Math.Pow(AB.Y, 2));
            double magnitudeAC = Math.Sqrt(Math.Pow(AC.X, 2) + Math.Pow(AC.Y, 2));

            return Math.Round(Math.Acos((ABxAC)/(magnitudeAB * magnitudeAC)), 4);
        }
        
        private List<Vector> FormVectors(PointSquaresDto a, PointSquaresDto b, PointSquaresDto c)
        {
            Vector AB = new Vector()
            {
                Start = a,
                End = b
            };
            AB.X = AB.Start.X - AB.End.X;
            AB.Y = AB.Start.Y - AB.End.Y;

            Vector AC = new Vector()
            {
                Start = a,
                End = c
            };
            AC.X = AC.Start.X - AC.End.X;
            AC.Y = AC.Start.Y - AC.End.Y;

            return new List<Vector>() { AB, AC };
        }

        private SquareDto SearchForFourthCorner(PointsCollectionSquaresDto collectionDto, List<Vector> rightAngleVectors)
        {
            PointSquaresDto fourthPoint = new PointSquaresDto()
            {
                X = rightAngleVectors[0].End.X - rightAngleVectors[0].Start.X + rightAngleVectors[1].End.X - rightAngleVectors[1].Start.X,
                Y = rightAngleVectors[0].End.Y - rightAngleVectors[0].Start.Y + rightAngleVectors[1].End.Y - rightAngleVectors[1].End.Y
            };
            
            PointSquaresDto foundFourthPoint = collectionDto.Points.FirstOrDefault(p => p.X == fourthPoint.X && p.Y == fourthPoint.Y);
            if(foundFourthPoint != null)
            {
                return new SquareDto()
                {
                    A = rightAngleVectors[0].Start,
                    B = rightAngleVectors[0].End,
                    C = rightAngleVectors[1].End,
                    D = foundFourthPoint
                };
            }
            
            return null;
        }
    }
}
