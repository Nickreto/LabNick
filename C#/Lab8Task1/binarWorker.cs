namespace nickEnv
{
    class BinarWorker
    {


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
                        reader.ReadInt32(),
                        reader.ReadString(),
                        reader.ReadInt32(),
                        reader.ReadDouble(),
                        reader.ReadBoolean(),
                        reader.ReadBoolean()
                    ));
                }
            }
            return list;
        }

        public static void AddDishMenu(List<Dish> menu, string path)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Название: "); string name = Console.ReadLine();
            Console.Write("Цена: "); int cost = Checker.EnterInt();
            Console.Write("Рейтинг (0-10): "); double rate = Checker.EnterDouble();
            Console.Write("Веганское? (1-да, 0-нет): "); bool vegan = Console.ReadLine() == "1";
            Console.Write("В наличии? (1-да, 0-нет): "); bool available = Console.ReadLine() == "1";
            if (menu.Count != 0)
            {
                menu.Add(new Dish(menu[^1].Id+1,name, cost, rate, vegan, available));
            }
            else
            {
                menu.Add(new Dish(0,name, cost, rate, vegan, available));
            }
            BinarWorker.SaveToFile(path,menu);
            Console.WriteLine("Добавлено!");
        }
        public static void DeleteDishMenu(List<Dish> menu, string path)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Введите ID для удаления: ");
            int id = int.Parse(Console.ReadLine());
            if (BinarWorker.RemoveById(menu, id))
            {
                BinarWorker.SaveToFile(path,menu);
                Console.WriteLine("Удалено.");
            }
            else 
            {
                Console.WriteLine("Объект не найден.");
            }
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


    }

}