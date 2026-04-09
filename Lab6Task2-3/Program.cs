using nickEnv;
internal class Program
{
    private static void Main(string[] args)
    {
        RightTriangle triangle1 = new RightTriangle();
        Console.WriteLine("Введите X: ");
        triangle1.X = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите Y: ");
        triangle1.Y = double.Parse(Console.ReadLine());
        RightTriangle triangle2 = new RightTriangle(13.2,6.1);
        RightTriangle triangle3 = new RightTriangle(-12,3);
        Console.WriteLine(triangle2.Square());
        Console.WriteLine(triangle1.ToString());
        Console.WriteLine(triangle2.ToString());
        Console.WriteLine(triangle3.ToString());
        Console.WriteLine((++triangle2).ToString());
        Console.WriteLine((--triangle2).ToString());
        Console.WriteLine(triangle1<=triangle2);
        Console.WriteLine(triangle1>=triangle2);
        Console.WriteLine((double)triangle2);   
        if(triangle3)
        { 
            Console.WriteLine(triangle3);      
        }
        if(triangle2)
        { 
            Console.WriteLine(triangle2);      
        }          
    }

}