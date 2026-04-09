using Lab1304;
internal class Program
{
    private static void Main(string[] args)
    {
        Coordinate t1 = new Coordinate();
        Coordinate t2 = new Coordinate(5,15,10);
        t1.X=3;
        Coordinate t3 = new Coordinate(t1);
        Console.WriteLine(t1.ToString());
        Console.WriteLine(t2.ToString());
        Console.WriteLine(t3.ToString());
        Console.WriteLine("Введите t2.Z:");
        t2.Z=int.Parse(Console.ReadLine());
        Console.WriteLine("t2.Z="+t2.Z);
        Console.WriteLine(t1.ToString());
        Console.WriteLine(t2.ToString());
        Console.WriteLine(t3.ToString());
        
    }

}
