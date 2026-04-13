

namespace nickEnv
{
    internal class Mark : Coordinate
    {
        private string _name;

        public Mark():base()
        {
            _name = "Mark";
        }

        public Mark(Mark obj):base(obj)
        {
            _name = obj._name;
        }

        public string Name
        {
            get{return _name;}
        }

        public static double CalculateDistance(Mark mark1, Mark mark2)
        {
            double dx = mark1.X - mark2.X;
            double dy = mark1.Y - mark2.Y;
            double dz = mark1.Z - mark2.Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public void Rename()
        {
            Console.WriteLine("Введите новое имя: ");
            _name = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Название метки={_name} {base.ToString()}";
        }


    }
}