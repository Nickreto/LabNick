namespace nickEnv
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
            get{return this._z;}
            set{this._z = value;}
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
            this._name = "Mark";
        }

        public Mark(Mark obj):base(obj)
        {
            this._name = obj._name;
        }

        public string Name
        {
            get{return this._name;}
        }

        public static void Range(Mark mark1, Mark mark2)
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


}