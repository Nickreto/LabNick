namespace nickEnv
{
    internal class Coordinate
    {
        private int _x;
        private int _y;
        private int _z;

        public Coordinate()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public Coordinate(int _x,int _y, int _z)
        {
            this._x = _x;
            this._y = _y;
            this._z = _z;
        }

        public Coordinate(Coordinate obj)
        {
            _x = obj._x;
            _y = obj._y;
            _z = obj._z;
        }

        public int X
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

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public int Min()
        {
            int m;
            if (_x < _y)
            {
                m = _x;
            }
            else
            {
                m = _y;
            }
            if (_z < m)
            {
                m = _z;
            }
            return m;
            
        }

        public override string ToString()
        {
            return $"x={_x} y={_y} z={_z}";
        }

    }


}