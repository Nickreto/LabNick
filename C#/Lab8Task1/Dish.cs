using System.Net.Quic;

namespace nickEnv
{
    internal class Dish
    {

        private int _id;
        private string _dishName;
        private int _cost;
        private double _rating;
        private bool _isVegan;
        private bool _isAvailable;


        public Dish(int id, string dishName, int cost, double rating, bool isVegan, bool isAvailable)
        {
            
            _id = id;
            DishName = dishName;
            Cost = cost;
            Rating = rating;
            IsVegan = isVegan;
            IsAvailable = isAvailable;
            
        }



        public int Id
        {
            get 
            {
                return _id;
            }
        }

        public string DishName
        {
            get 
            {
                return _dishName;
            }
            set 
            {
                _dishName = value;
            }
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
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
            }
        }

        public bool IsVegan
        {
            get
            {
                return _isVegan;
            }
            set
            {
                _isVegan = value;
            }
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