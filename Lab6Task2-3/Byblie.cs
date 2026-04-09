namespace nickEnv
{
    internal class RightTriangle
    {
        private double _x;
        private double _y;

        public RightTriangle()
        {
            
        }

        public RightTriangle(double _x, double _y)
        {
            this._x = _x;
            this._y = _y;
        }

        public double X
        {
            get{return this._x;}
            set{this._x=value;}
        }
        public double Y
        {
            get{return this._y;}
            set{this._y=value;}
        }


        public double Square()
        {
            return Math.Abs(this._x*this._y/2);
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
            return (triangle1.Square()>=triangle2.Square());
        }

        public static bool operator <=(RightTriangle triangle1, RightTriangle triangle2)
        {
            return (triangle1.Square()<=triangle2.Square());
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