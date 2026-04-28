using nickEnv;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Task1:");
        FileOperator.Task1File("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task1");
        Console.WriteLine(FileOperator.ZeroFounder("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task1"));
        Console.WriteLine("Task2:");
        FileOperator.Task2File("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task2");
        Console.WriteLine(FileOperator.MaxFounder("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task2"));
        Console.WriteLine("Task3:");
        FileOperator.Task3File("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task3");
        Console.WriteLine("Необходим символ, который нужно искать в файле");
        FileOperator.SymbolFounder("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task3","/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task3-new",Checker.EnterChar());
        Console.WriteLine("Task4:");
        FileOperator.Task4File("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task4");
        Console.WriteLine(FileOperator.BinEquals("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task4"));
        FileOperator.Task5File("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task5.xml");
        FileOperator.OutBuggage("/home/nick/Документы/4_sem/LP/LabNick/C#/Lab7Task1-5/task5.xml");
    }
}