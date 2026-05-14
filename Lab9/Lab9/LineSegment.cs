using System;

namespace Lab9
{
    public class LineSegment
    {
        private double _x;
        private double _y;

        public LineSegment()
        {
            X = 0;
            Y = 0;
        }

        public LineSegment(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X
        {
            get 
            {
                return _x;
            }
            set 
            {
               _x = value;
            }
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }

        public bool Contains(double number)
        {
            double min = Math.Min(_x, _y);
            double max = Math.Max(_x, _y);
            return number >= min && number <= max;
        }

        public static double operator !(LineSegment ls)
        {
            return Math.Abs(ls._y - ls._x);
        }

        public static LineSegment operator ++(LineSegment ls)
        {
            return new LineSegment(ls._x + 1, ls._y + 1);
        }

        public static explicit operator int(LineSegment ls)
        {
            return (int)ls._x;
        }

        public static implicit operator double(LineSegment ls)
        {
            return ls._y;
        }

        public static LineSegment operator +(LineSegment ls, int d)
        {
            return new LineSegment(ls._x + d, ls._y + d);
        }

        public static LineSegment operator +(int d, LineSegment ls)
        {
            return new LineSegment(ls._x + d, ls._y + d);
        }

        public static bool operator <(LineSegment ls, int d)
        {
            double min = Math.Min(ls._x, ls._y);
            double max = Math.Max(ls._x, ls._y);
            return d >= min && d <= max;
        }

        public static bool operator >(LineSegment ls, int d)
        {
            double min = Math.Min(ls._x, ls._y);
            double max = Math.Max(ls._x, ls._y);
            return d < min || d > max;
        }

        public override string ToString()
        {
            return $"[{_x}; {_y}]";
        }
    }
}