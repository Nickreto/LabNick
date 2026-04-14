namespace nickEnv
{
    class Checker
    {
    public static double EnterDouble()
    {
        double enteredDouble;
        Console.Write("Введите число:");
        while(!double.TryParse(Console.ReadLine(), out enteredDouble))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        Console.WriteLine(enteredDouble);
        return enteredDouble; 
    }

    public static int EnterInt()
    {
        int enteredInt;
        Console.Write("Введите число:");
        while(!int.TryParse(Console.ReadLine(), out enteredInt))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        Console.WriteLine(enteredInt);
        return enteredInt; 
    }

    }
}