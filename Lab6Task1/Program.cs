using nickEnv;
internal class Program
{

    private static int EnterDigit()
    {
        int enteredDigit;
        Console.Write("Введите число:");
        while(!int.TryParse(Console.ReadLine(), out enteredDigit))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        Console.WriteLine(enteredDigit);
        return enteredDigit; 
    }

    private static void EnterCoords(Coordinate coordinate)
    {
        List<int> cords = new List<int>(3);
        for (int i=0; i<3;i++)
        {
            Console.WriteLine($"Произведите ввод {1+i} координаты");
            cords.Add(EnterDigit());
        }
        coordinate.X = cords[0];
        coordinate.Y = cords[1];
        coordinate.Z = cords[2];
    }

    private static void Main(string[] args)
    {
        var coordinate1 = new Coordinate();
        EnterCoords(coordinate1);
        var coordinate2 = new Coordinate(coordinate1);
        Console.WriteLine("Изменение поля X");
        coordinate2.X = EnterDigit();
        var coordinate3 = new Coordinate();

        Console.WriteLine(coordinate1);
        Console.WriteLine(coordinate2);
        Console.WriteLine(coordinate3);

        Console.WriteLine("Работа с дочерним классом");
        var mark1 = new Mark();
        mark1.Rename();
        Console.WriteLine($"Изменение поля X марки {mark1.Name}");
        mark1.X = EnterDigit();
        Console.WriteLine($"Изменение поля Y марки {mark1.Name}");
        mark1.Y = EnterDigit();
        var mark2 = new Mark(mark1);
        mark2.Rename();
        Console.WriteLine($"Изменение поля Z марки {mark2.Name}");
        mark2.Z = EnterDigit();
        Console.WriteLine($"Изменение поля Y марки {mark2.Name}");
        mark2.Y = EnterDigit();

        Console.WriteLine(mark1.ToString());
        Console.WriteLine(mark2.ToString());
        double r = Mark.CalculateDistance(mark1,mark2);
        Console.WriteLine("От точки "+mark1.Name+" до точки "+mark2.Name+" "+r);
    }

}
