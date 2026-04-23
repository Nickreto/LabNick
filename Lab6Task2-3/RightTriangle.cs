namespace nickEnv
{
    internal class RightTriangle
    {
        private double _x;
        private double _y;

        public RightTriangle()
        {
            this._x = 0;
            this._y = 0;
        }

        public RightTriangle(double _x, double _y)
        {
            this.X = _x;
            this.Y = _y;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (value > 0)
                {
                    _x=value;
                }
                else
                {
                    Console.WriteLine("Сторона должна быть больше нуля");
                    _x =0;
                }
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (value > 0)
                {
                    _y=value;
                }
                else
                {
                    Console.WriteLine("Сторона должна быть больше нуля");
                    _y=0;
                }
            }
        }


        public double Square()
        {
            return Math.Abs(_x*_y/2);
        }

        public static RightTriangle operator ++(RightTriangle triangle)
        {
            return new RightTriangle(2.0*triangle._x, 2.0*triangle._y);
        }

        public static RightTriangle operator --(RightTriangle triangle)
        {
            return new RightTriangle(triangle._x/2.0, triangle._y/2.0);
        }



        public static bool operator >=(RightTriangle triangle1, RightTriangle triangle2)
        {
            return triangle1.Square()>=triangle2.Square();
        }

        public static bool operator <=(RightTriangle triangle1, RightTriangle triangle2)
        {
            return triangle1.Square()<=triangle2.Square();
        }

        public static explicit operator double(RightTriangle triangle)
        {
            if ((bool)triangle)
            {
                return triangle.Square();
            }
            else
            {
                return -1.0;
            }
        }

        public static implicit operator bool(RightTriangle triangle)
        {
            if (triangle._x>0 & triangle._y>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "x="+this._x+" y="+this._y;
        }
    }
}