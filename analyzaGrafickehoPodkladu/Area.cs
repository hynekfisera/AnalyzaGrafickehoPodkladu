using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analyzaGrafickehoPodkladu
{
    public class Area
    {
        public int Id { get; set; }
        public List<Point> Points { get; set; }
        public Area(int id)
        {
            Id = id;
            Points = new List<Point>();
        }
        public override string ToString()
        {
            return $"Oblast {Id}";
        }
        public double GetPerimeter()
        {
            double result = 0;
            for (int i = 0; i < Points.Count; i++)
            {
                Point a = Points[i];
                Point b = i == Points.Count - 1 ? Points[0] : Points[i + 1];
                double x = Math.Abs(a.X - b.X);
                double y = Math.Abs(a.Y - b.Y);
                double distance = Math.Sqrt(x * x + y * y);
                result += distance;
            }
            return result;
        }
        public double GetArea()
        {
            var allPoints = new Point[Points.Count + 1];
            for (int i = 0; i < Points.Count; i++)
            {
                allPoints[i] = Points[i];
            }
            allPoints[allPoints.Length - 1] = Points[0];
            double temp = 0;
            for (int i = 0; i < allPoints.Length - 1; i++)
            {
                temp += allPoints[i].X * allPoints[i + 1].Y - allPoints[i + 1].X * allPoints[i].Y;
            }
            return Math.Abs(temp) / 2;
        }
    }
}
