using System.Net.Quic;

namespace nickEnv
{
    internal class Dish
    {
        private static int _count;
        private int _id;
        private string _dishName;
        private int _cost;
        private double _rating;
        private bool _isVegan;
        private bool _isAvailable;

        static Dish()
        {
            _count = 0;
        }

        private Dish(int id, string dishName, int cost, double rating, bool iSvegan, bool isAvailable)
        {
            
            _id = id;
            _dishName = this.DishName;
            _cost = this.Cost;
            _rating = this.Rating;
            _isVegan = this.IsVegan;
            _isAvailable = this.IsAvailable;
            
        }

        public Dish(string dishName, int cost, double rating, bool iSvegan, bool isAvailable)
        {
            
            _id = _count;
            _count++;
            _dishName = this.DishName;
            _cost = this.Cost;
            _rating = this.Rating;
            _isVegan = this.IsVegan;
            _isAvailable = this.IsAvailable;
            
        }

        public int Id
        {
            get {return _id;}
        }

        public string DishName
        {
            get {return _dishName;}
            set {_dishName = value;}
        }

        public int Cost
        {
            get {return _cost;}
            set
            {
                if (value >= 0)
                {
                    _cost = value;
                }
                else
                {
                    Console.WriteLine("Цена не может быть отрицательной!");
                    _cost = 0;
                }
            }
        }

        public double Rating
        {
            get {return _rating;}
            set
            {
                if (value >= 0 && value <=10)
                {
                    _rating = value;
                }
                else
                {
                    Console.WriteLine("Рейтинг должен быть в диапазоне от 0 до 10!");
                    _rating = 0;
                }
            }
        }

        public bool IsAvailable
        {
            get{return _isAvailable;}
            set{_isAvailable = value;}
        }

        public bool IsVegan
        {
            get{return _isVegan;}
            set{_isVegan = value;}
        }

        public static void SaveToFile(string path, List<Dish> dishes)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var dish in dishes)
                {
                    writer.Write(dish.Id);
                    writer.Write(dish.DishName);
                    writer.Write(dish.Cost);
                    writer.Write(dish.Rating);
                    writer.Write(dish.IsVegan);
                    writer.Write(dish.IsAvailable);
                }
            }
        }

        public static List<Dish> LoadFromFile(string path)
        {
            var list = new List<Dish>();
            if (!File.Exists(path)) return list;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1) // Пока файл не закончился
                {
                    list.Add(new Dish(
                        reader.ReadInt16(),
                        reader.ReadString(),
                        reader.ReadInt16(),
                        reader.ReadDouble(),
                        reader.ReadBoolean(),
                        reader.ReadBoolean()
                    ));
                }
            }
            return list;
        }


        public static List<Dish> GetVegan(List<Dish> dishes)
        {
            var query =
                from d in dishes
                where d.IsVegan == true
                select d;
            return query.ToList();
        }

        public static List<Dish> GetInRange(List<Dish> dishes, int min, int max)
        {
            var query = 
                from d in dishes
                where d.Cost >= min && d.Cost <= max
                select d;
            return query.ToList();
        }
        
        public static List<Dish> GetByRating(List<Dish> dishes)
        {
            var query = dishes.OrderByDescending(d => d.Rating);
            return query.ToList();            
        }

        public static List<Dish> GetByCost(List<Dish> dishes)
        {
            var query = dishes.OrderBy(d => d.Cost);
            return query.ToList();            
        }

        public static void ListOut(List<Dish> dishes)
        {
            foreach (var d in dishes)
            {
                Console.WriteLine(d.ToString());
            }
        }

        public static bool RemoveById(List<Dish> dishes, int id)
        {
            var item = dishes.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                dishes.Remove(item);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string vegan = "";
            string available = "";
            if (_isVegan)
            {
                vegan = "веганское";
            }
            else
            {
                vegan = "";
            }
            if (_isAvailable)
            {
                available = "в наличии";
            }
            else
            {
                available = "закончилось";
            }
            return $"id={_id} | блюдо {_dishName} {Math.Round(_rating,1)} звёзд, {_cost} руб. {vegan} {available}";
        }

    }
}