using nickEnv;
internal class Program
{

    private static void Main(string[] args)
    {
        RightTriangle triangle1 = new RightTriangle();
        Console.WriteLine("Введите X: ");
        triangle1.X = Checker.EnterDouble();
        Console.WriteLine("Введите Y: ");
        triangle1.Y = Checker.EnterDouble();
        Console.WriteLine("Введите X: ");
        double x = Checker.EnterDouble();
        Console.WriteLine("Введите Y: ");
        double y = Checker.EnterDouble();
        RightTriangle triangle2 = new RightTriangle(x,y);
        Console.WriteLine("Метод вычисления площади:");
        Console.WriteLine(triangle2.Square());
        Console.WriteLine("Перегрузка ToString:");
        Console.WriteLine(triangle1.ToString());
        Console.WriteLine(triangle2.ToString());
        Console.WriteLine("Перегрузка операторов '++' и '--':");
        Console.WriteLine((++triangle2).ToString());
        Console.WriteLine((--triangle2).ToString());
        Console.WriteLine("Перегрузка операторов '<=' и '>=':");
        Console.WriteLine(triangle1<=triangle2);
        Console.WriteLine(triangle1>=triangle2);
        Console.WriteLine("Преобразование типов явное и неявное:");
        Console.WriteLine((double)triangle2);   
        if(triangle2)
        { 
            Console.WriteLine(triangle2);      
        }          
    }

}