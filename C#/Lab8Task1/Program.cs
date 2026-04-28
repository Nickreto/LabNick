using nickEnv;

internal class Program
{
    static string path = "/home/nick/Документы/4_sem/LP/LabNick/C#/menu.dat";
    static List<Dish> menu = new List<Dish>();
    private static void Main(string[] args)
    {
        int input = 0;
        menu = Dish.LoadFromFile(path);
        Console.WriteLine(
            """
            Добро пожаловать в CLI Menu
            Для выбора пункта впишите его номер
            Чтобы выйти из CLI введите 0
            """
        );
        do
        {
            Console.Write(
                """
                Доступные команды:
                1. Добавление блюда в меню
                2. Удаление блюда из меню
                3. Вывод всего меню
                4. Вывести список веганских блюд
                5. Вывести блюда в ценовом диапазоне
                6. Вывести блюда по убыванию рейтинга
                7. Вывести блюда по возрастанию цены
                Ввод команды:
                """
                );
            input = Checker.EnterInt();
            switch (input)
            {
                case 1:
                    AddDishMenu();
                    break;
                case 2:
                    DeleteDishMenu();
                    break;
                case 3:
                    Console.WriteLine("Вывод всего меню:");
                    Dish.ListOut(menu);
                    break;
                case 4:
                    Console.WriteLine("Вывод всего меню веганов:");
                    Dish.ListOut(Dish.GetVegan(menu));
                    break;
                case 5:
                    Console.WriteLine("Введите минимальную цену:");
                    int min = Checker.EnterInt();
                    Console.WriteLine("Введите максимальную цену:");
                    int max = Checker.EnterInt();
                    
                    Console.WriteLine($"Вывод в диапазоне от {min} до {max}:");
                    Dish.ListOut(Dish.GetInRange(menu,min,max));
                    break;
                case 6:
                    Console.WriteLine("Вывод вменю по рейтингу:");
                    Dish.ListOut(Dish.GetByRating(menu));
                    break;
                case 7:
                    Console.WriteLine("Вывод меню по цене:");
                    Dish.ListOut(Dish.GetByCost(menu));
                    break;
                default:
                    break;
            }
        }while(input != 0);
    }

    static void AddDishMenu()
    {
        Console.Write("Название: "); string name = Console.ReadLine();
        Console.Write("Цена: "); int cost = Checker.EnterInt();
        Console.Write("Рейтинг (0-10): "); double rate = Checker.EnterDouble();
        Console.Write("Веганское? (1-да, 0-нет): "); bool vegan = Console.ReadLine() == "1";
        Console.Write("В наличии? (1-да, 0-нет): "); bool available = Console.ReadLine() == "1";
        menu.Add(new Dish(name, cost, rate, vegan, available));
        Dish.SaveToFile(path,menu);
        Console.WriteLine("Добавлено!");
    }
    static void DeleteDishMenu()
    {
        Console.Write("Введите ID для удаления: ");
        int id = int.Parse(Console.ReadLine());
        if (Dish.RemoveById(menu, id))
        {
            Dish.SaveToFile(path,menu);
            Console.WriteLine("Удалено.");
        }
        else 
        {
            Console.WriteLine("Объект не найден.");
        }
    }
}