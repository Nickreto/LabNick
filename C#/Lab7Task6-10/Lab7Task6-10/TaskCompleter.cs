using System.Diagnostics;
using nickEnv;

namespace nickenv
{
    class TaskCompleter
    {
        
        public static List<char> CreateCharList(int i)
        {
            List<char> list = new List<char>();
            for (int j = 0; j < i; j++)
            {
                list.Add(Checker.EnterChar());
            }
            return list;
        }

        public static List<string> CreateStringList(int i)
        {
            List<string> list = new List<string>();
            for (int j = 0; j < i; j++)
            {
                list.Add(Checker.EnterString());
            }
            return list;
        }

        public static LinkedList<char> CreateCharLinkedList(int i)
        {
            var list = new LinkedList<char>();
            while(i>0)
            {
                list.AddLast(Checker.EnterChar());
                i--;
            }
            return list;
        }

        public static HashSet<string> CreateHashSet(List<string> list)
        {
            var hashlist = new HashSet<string>();
            foreach(string el in list)
            {
                hashlist.Add(el);
            }
            return hashlist;
        }

        public static void WriteList<T>(List<T> list)
        {
            foreach(T el in list)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine("");
        }

        public static void WriteList<T>(LinkedList<T> list)
        {
            int len = list.Count;
            var node = list.First;
            for(int i = 0; i< len; i++)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
            Console.WriteLine("");
        }

        public static List<HashSet<string>>TouristsCreate(List<string> countries, int count)
        {
            List<HashSet<string>> touristsHashSet = new List<HashSet<string>>();
            for (int i = 0; i < count; i++)
            {
                List<string> newCountries = new List<string>();
                foreach(string country in countries)
                {
                    Console.WriteLine($"Добавить страну {country} туристу {i}?");
                    Console.WriteLine("Введите 1 если да");
                    if (Checker.EnterInt() == 1)
                    {
                        newCountries.Add(country);
                    }

                }
                touristsHashSet.Add(CreateHashSet(newCountries));
            }
            return touristsHashSet;
        }


        public static void CheckCountries(List<HashSet<string>> touristsHashSet, List<string> countries)
        {
            List<int> touristsInCountry = new List<int>();
            List<string> everyone = new List<string>();
            List<string> someone = new List<string>();
            List<string> noone = new List<string>();
            
            foreach(string country in countries)
            {
                foreach(HashSet<string> tourist in touristsHashSet)
                {
                    if (true)
                    {
                        
                    }
                }
            }
        }

        public static List<char> RemoveElementAfterE(List<char> list, char E)
        {
            int len = list.Count;
            for (int i = 1; i < len; i++)
            {
                if (list[i-1] == E)
                {
                    if (list[i] != E)
                    {
                        list.RemoveAt(i);
                        len = len - 1;
                    }
                }
            }
            return list;
        }


        public static bool CircleCouples(LinkedList<char> list)
        {
            var node = list.First;
            int count = list.Count;
            var nextnode = node.Next;
            for (int i = 1; i < count; i++)
            {
                if (node.Value == nextnode.Value)
                {
                    return true;
                }
                node = nextnode;
                nextnode = nextnode.Next;
                
            }
            if (list.First.Value == node.Value)
            {
                return true;
            }

            return false;
        }

        public static void Countries()
        {
            string input;
            
        }

        
    }
}