using System;
using programNM;
internal class Program
{
    private static void Main(string[] args)
    {
        int x = 20;
        int y = 15;
        Summa pr = new Summa();
        int sum = pr.Sum(x,y);
        Console.WriteLine(sum);
    }

}
