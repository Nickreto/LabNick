namespace Lab1304
{
    internal class Coordinate
    {
        private int _x;
        private int _y;
        private int _z;

        public Coordinate()
        {
            this._x = 0;
            this._y = 0;
            this._z = 0;
        }

        public Coordinate(int _x,int _y, int _z)
        {
            this._x = _x;
            this._y = _y;
            this._z = _z;
        }

        public Coordinate(Coordinate obj)
        {
            this._x = obj._x;
            this._y = obj._y;
            this._z = obj._z;
        }

        public int X
        {
            get{return this._x;}
            set{this._x = value;}
        }

        public int Y
        {
            get{return this._y;}
            set{this._y = value;}
        }

        public int Z
        {
            get{return this._y;}
            set{this._y = value;}
        }

        public int Min()
        {
            int m;
            if (this._x < this._y)
            {
                m = this._x;
            }
            else
            {
                m = this._y;
            }
            if (this._z < m)
            {
                m = this._z;
            }
            return m;
            
        }

        public override string ToString()
        {
            return "x="+this._x+" y="+this._y+" z="+this._z;
        }

    }

    internal class Mark : Coordinate
    {
        private string _name;

        public Mark(int _x,int _y, int _z, string _name):base(_x,_y,_z)
        {
            this._name = _name;     
        }

        public Mark():base()
        {
            
        }

        public Mark(Mark obj):base(obj)
        {
            this._name = obj._name;
        }

        public string Name
        {
            get{return this._name;}
        }

        public void Range(Mark mark1, Mark mark2)
        {
            double r1 = Math.Sqrt((mark1.X-mark2.X)*(mark1.X-mark2.X)+(mark1.Y-mark2.Y)*(mark1.Y-mark2.Y)+(mark1.Z-mark2.Z)*(mark1.Z-mark2.Z));
            Console.WriteLine("От точки "+mark1._name+" до точки "+mark2._name+" "+r1);
        }

        public void Rename()
        {
            Console.WriteLine("Введите новое имя: ");
            this._name = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Название метки="+this._name+" "+base.ToString();
        }


    }

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

        public static implicit operator double(RightTriangle triangle)
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

        public static explicit operator bool(RightTriangle triangle)
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
    }
}