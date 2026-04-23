using nickenv;
using nickEnv;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов списка");
        var list = TaskCompleter.CreateCharList(Checker.EnterInt());
        Console.WriteLine("Введите символ для удаления после него отличного символа: ");
        var E = Checker.EnterChar();
        Console.WriteLine("Вывод списка до преобразования: ");
        TaskCompleter.WriteList(list);
        list = TaskCompleter.RemoveElementAfterE(list,E);
        Console.WriteLine("Вывод списка после преобразования: ");
        TaskCompleter.WriteList(list);


        Console.WriteLine("Введите количество элементов списка");
        var linkedList = TaskCompleter.CreateCharLinkedList(Checker.EnterInt());
        Console.WriteLine("Вывод списка:");
        TaskCompleter.WriteList(linkedList);
        Console.Write("Ответ на задание 7:");
        Console.WriteLine(TaskCompleter.CircleCouples(linkedList));

        //хэш сеты сделать с помощью логических операций
        //объединение и тому подобное
    }

}