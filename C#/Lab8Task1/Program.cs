using nickEnv;

internal class Program
{
    static string path = "/home/nick/Документы/4_sem/LP/LabNick/C#/Lab8Task1/menu.dat";
    static List<Dish> menu = new List<Dish>();
    private static void Main(string[] args)
    {
        int input = 0;
        menu = BinarWorker.LoadFromFile(path);
        Console.WriteLine(
            """
            --------------------------------------------------
            Добро пожаловать в CLI Menu
            Для выбора пункта впишите его номер
            Чтобы выйти из CLI введите 0
            """
        );
        do
        {
            Console.Write(
                """
                --------------------------------------------------
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
                    BinarWorker.AddDishMenu(menu,path);
                    break;
                case 2:
                    BinarWorker.DeleteDishMenu(menu,path);
                    break;
                case 3:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Вывод всего меню:");
                    BinarWorker.ListOut(menu);
                    break;
                case 4:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Вывод всего меню веганов:");
                    BinarWorker.ListOut(BinarWorker.GetVegan(menu));
                    break;
                case 5:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Введите минимальную цену:");
                    int min = Checker.EnterInt();
                    Console.WriteLine("Введите максимальную цену:");
                    int max = Checker.EnterInt();
                    
                    Console.WriteLine($"Вывод в диапазоне от {min} до {max}:");
                    BinarWorker.ListOut(BinarWorker.GetInRange(menu,min,max));
                    break;
                case 6:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Вывод вменю по рейтингу:");
                    BinarWorker.ListOut(BinarWorker.GetByRating(menu));
                    break;
                case 7:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Вывод меню по цене:");
                    BinarWorker.ListOut(BinarWorker.GetByCost(menu));
                    break;
                default:
                    break;
            }
        }while(input != 0);
    }


}