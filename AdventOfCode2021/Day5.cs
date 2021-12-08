using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode2021
{
    public class Point
    {
        public int x;
        public int y;
        public int overlaps;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            overlaps = 1;
        }
    }

    public class Day5
    {
        public List<Point> DataToPoints(List<string> data)
        {
            char[] delimiterChars = { ' ', ',', '-'};

            List<Point> points = new List<Point>();
            foreach(string line in data)
            {
                var numbers = Regex.Split(line, @"\D+");
                for(int i = 0; i < numbers.Length; i+=2)
                {
                    points.Add(new Point(Int32.Parse(numbers[i]), Int32.Parse(numbers[i + 1])));
                }
            }
            return points;
        }

        public int FirstTask(List<Point> points)
        {
            List<Point> overlapingPoints = new List<Point>();
            List<Point> lines = new List<Point>(GetLines(points));
            bool isAdded = false;

            for(int i = 0; i < lines.Count; i++)
            {
                for(int j = 0; j < overlapingPoints.Count; j++)
                {
                    if(lines[i].x == overlapingPoints[j].x && lines[i].y == overlapingPoints[j].y)
                    {
                        overlapingPoints[j].overlaps++;
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded)
                {
                    overlapingPoints.Add(new Point(lines[i].x, lines[i].y));
                }
                isAdded = false;
            }
            return CountOverlaps(overlapingPoints);
        }

        private List<Point> GetLines(List<Point> points)
        {
            List<Point> lines = new List<Point>();
            for(int i = 0; i < points.Count; i += 2)
            {
                if(points[i].x == points[i + 1].x)
                {
                    for(int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        if(points[i].y > points[i + 1].y)
                        {
                            lines.Add(new Point(points[i].x, points[i].y - j));
                        }
                        else
                        {
                            lines.Add(new Point(points[i].x, points[i].y + j));
                        }
                    }
                }
                else if (points[i].y == points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].x - points[i + 1].x); j++)
                    {
                        if (points[i].x > points[i + 1].x)
                        {
                            lines.Add(new Point(points[i].x - j, points[i].y));
                        }
                        else
                        {
                            lines.Add(new Point(points[i].x + j, points[i].y));
                        }
                    }
                }
            }
            return lines;
        }

        private int CountOverlaps(List<Point> points)
        {
            int count = 0;
            foreach(Point point in points)
            {
                if (point.overlaps > 1) count++;
            }
            return count;
        }

        public int SecondTask(List<Point> points)
        {
            List<Point> overlapingPoints = new List<Point>();
            List<Point> lines = new List<Point>(GetLinesWithDiagonal(points));
            bool isAdded = false;

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < overlapingPoints.Count; j++)
                {
                    if (lines[i].x == overlapingPoints[j].x && lines[i].y == overlapingPoints[j].y)
                    {
                        overlapingPoints[j].overlaps++;
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded)
                {
                    overlapingPoints.Add(new Point(lines[i].x, lines[i].y));
                }
                isAdded = false;
            }
            return CountOverlaps(overlapingPoints);
        }

        private List<Point> GetLinesWithDiagonal(List<Point> points)
        {
            List<Point> lines = new List<Point>();
            for (int i = 0; i < points.Count; i += 2)
            {
                if (points[i].x == points[i + 1].x)
                {
                    for (int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        if (points[i].y > points[i + 1].y)
                        {
                            lines.Add(new Point(points[i].x, points[i].y - j));
                        }
                        else
                        {
                            lines.Add(new Point(points[i].x, points[i].y + j));
                        }
                    }
                }
                else if (points[i].y == points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].x - points[i + 1].x); j++)
                    {
                        if (points[i].x > points[i + 1].x)
                        {
                            lines.Add(new Point(points[i].x - j, points[i].y));
                        }
                        else
                        {
                            lines.Add(new Point(points[i].x + j, points[i].y));
                        }
                    }
                }
                else if (points[i].x > points[i + 1].x && points[i].y > points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        lines.Add(new Point(points[i].x - j, points[i].y - j));
                    }
                }
                else if (points[i].x > points[i + 1].x && points[i].y < points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        lines.Add(new Point(points[i].x - j, points[i].y + j));
                    }
                }
                else if (points[i].x < points[i + 1].x && points[i].y > points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        lines.Add(new Point(points[i].x + j, points[i].y - j));
                    }
                }
                else if (points[i].x < points[i + 1].x && points[i].y < points[i + 1].y)
                {
                    for (int j = 0; j <= Math.Abs(points[i].y - points[i + 1].y); j++)
                    {
                        lines.Add(new Point(points[i].x + j, points[i].y + j));
                    }
                }
            }
            return lines;
        }
    }
}
