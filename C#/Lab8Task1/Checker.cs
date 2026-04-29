namespace nickEnv
{
    class Checker
    {
    public static double EnterDouble()
    {
        double enteredDouble;
        //Console.Write("Введите число:");
        while(!double.TryParse(Console.ReadLine(), out enteredDouble))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        //Console.WriteLine(enteredDouble);
        return enteredDouble; 
    }

    public static int EnterInt()
    {
        int enteredInt;
        //Console.Write("Введите число:");
        while(!int.TryParse(Console.ReadLine(), out enteredInt))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        //Console.WriteLine(enteredInt);
        return enteredInt; 
    }

    public static char EnterChar()
    {
        char enteredChar;
        //Console.Write("Введите символ:");
        while(!char.TryParse(Console.ReadLine(), out enteredChar))
        {
            Console.Write("Ввод некорректен, повторите ввод: ");
        }        
        //Console.WriteLine(enteredChar);
        return enteredChar; 
    }

    public static string EnterString()
    {
        string enteredString;
        enteredString = Console.ReadLine();
        return enteredString; 
    }

    }
}