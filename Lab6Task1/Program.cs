using nickEnv;
internal class Program
{
    private static void Main(string[] args)
    {
        Coordinate t1 = new Coordinate();
        Console.WriteLine("Введите X: ");
        t1.X = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите Y: ");
        t1.Y = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите Z: ");
        t1.Z = int.Parse(Console.ReadLine());
        Coordinate t2 = new Coordinate(5,15,10);
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
        Console.WriteLine("Минимум в t2:"+t2.Min());


        Mark m1 = new Mark();
        Mark m2 = new Mark(5,15,10,"Дом");
        Mark m3 = new Mark(m2);
        m3.Rename();
        m3.X = 12;
        Console.WriteLine(m1.ToString());
        Console.WriteLine(m2.ToString());
        Console.WriteLine(m3.ToString());
        Mark.Range(m1,m2);


    }

}
