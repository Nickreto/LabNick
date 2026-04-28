using System.Text;
using System.Xml.Serialization;

namespace nickEnv
{

        [Serializable]
        public struct Buggage
        {
            public string name;
            public double weight;
        }

        [Serializable]
        public struct Passenger
        {
            public string name;
            public List<Buggage> buggage;
        }
        
    class FileOperator
    {


        private static bool OpenFile(string path, out StreamReader srout)
        {
            try 
            {
                srout = new StreamReader(path);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Неверный путь!");
                srout = null;
                return false;
            }
        }

        public static void ReadFile(string path)
        {

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        private static bool OpenBinFile(string path, out BinaryReader srout)
        {
            try 
            {
                srout = new BinaryReader(File.Open(path, FileMode.Open));
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Неверный путь!");
                srout = null;
                return false;
            }
        }

        private static bool OpenBinFile(string path, out BinaryWriter srin)
        {
            try 
            {
                srin = new BinaryWriter(File.Open(path, FileMode.Open));
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Неверный путь!");
                srin = null;
                return false;
            }
        }

        private static bool XmlSerialize(string path, out FileStream fs)
        {
            try
            {
                fs = new FileStream(path, FileMode.Create);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Путь указан неверно!");
                fs = null;
                return false;
            }

        }



        public static void Task1File(string path)
        {
            Random rand = new Random();
            int i = rand.Next(1,100);
            string line = "";
            while(i>0)
            {
                line = $"{line}{rand.Next(0,9)}\n";
                i--;
            }

            File.WriteAllText(path,line);
        }

        public static void Task2File(string path)//по несколько в строке
        {
            Random rand = new Random();
            int i = rand.Next(1,100);
            string line = "";
            while(i>0)
            {
                line = $"{line}{rand.Next(0,999)}\n";
                i--;
            }

            File.WriteAllText(path,line);
        }

        public static void Task3File(string path)
        {
            Random rand = new Random();
            int i = rand.Next(10,70);
            string line = "";
            while(i>0)
            {
                int j = rand.Next(5,20);
                while(j>0)
                {
                    line = $"{line}{(char)rand.Next(97,122)}";
                    j--;
                }
                i--;
                line = $"{line}\n";
            }

            File.WriteAllText(path,line);
        }

        public static void Task4File(string path)
        {
            Random rand = new Random();
            int i = rand.Next(10,30);
            int element = 0;
            OpenBinFile(path, out BinaryWriter bin);
            bin.Write(i);
            while(i>0)
            {
                
                Console.Write($"{element = rand.Next(-15,15)} ");
                bin.Write(element);
                i--;
            }
            Console.WriteLine();
            bin.Close();
        }

        public static void Task5File(string path)
        {
            Console.WriteLine("Введите число пассажиров");
            int i = Checker.EnterInt();
            while(i<0)
            {
                Console.WriteLine("Введено число меньше нуля!");
                i = Checker.EnterInt();
            }
            
            
            List<Passenger> passengers = new List<Passenger>();
            
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("Введите имя пассажира:");
                List<Buggage> buggages = new List<Buggage>();
                Passenger passenger = new Passenger();
                passenger.name = Checker.EnterString();
                passenger.buggage = buggages;
                passengers.Add(passenger);
                Console.WriteLine("Введите название багажа:");
                string nameBuggage = Console.ReadLine();
                double weight = 0.0;
                while (nameBuggage != "0")
                {
                    Console.WriteLine("Введите вес:");
                    weight = Checker.EnterDouble();
                    Buggage buggage = new Buggage();
                    buggage.name = nameBuggage;
                    buggage.weight = weight;
                    passengers[j].buggage.Add(buggage);
                    Console.WriteLine("Введите название следующего багажа или введите 0, чтобы закончить ввод:");
                    nameBuggage = Checker.EnterString();
                }

            }



            XmlSerializer serializerXml = new XmlSerializer(typeof(List<Passenger>));
            try 
            {
                FileStream writer = new FileStream(path, FileMode.Create);
                serializerXml.Serialize(writer, passengers);
                Console.WriteLine($"\nДанные успешно сохранены в {path}");
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении: " + ex.Message);
            }



        }

        public static void OutBuggage(string path)
        {
            
            if (!XmlSerialize(path,out FileStream fs)) return;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Passenger>));
            List<Passenger> passengers;

            passengers = (List<Passenger>)serializer.Deserialize(fs);

            Console.WriteLine("\nОтчет по багажу:");
            foreach (Passenger p in passengers)
            {
                double totalWeight = 0;
                Console.WriteLine($"Пассажир: {p.name}");
                
                foreach (Buggage item in p.buggage)
                {
                    Console.WriteLine($"  - {item.name}: {item.weight} кг");
                    totalWeight += item.weight;
                }
                Console.WriteLine($"  ИТОГО: {totalWeight} кг");
                Console.WriteLine("-------------------------");
            }
        }

        public static bool ZeroFounder(string path)
        {
            if (OpenFile(path,out StreamReader file))
            {
                string line = file.ReadToEnd();
                file.Close();
                return !line.Contains('0');
            }
            else
            {
                Console.WriteLine("Не получилось открыть файл!");
                return false;
            }
            
        }

        public static int MaxFounder(string path)
        {
            if (OpenFile(path,out StreamReader file))
            {
                int max = int.MinValue;
                string? line = "";
                while ((line = file.ReadLine())!=null)
                {
                    if (int.TryParse(line, out int num))
                    {
                        if (num > max)
                        {
                            max = num;
                        }
                    }
                }
                file.Close();
                return max;
            }
            else
            {
                Console.WriteLine("Не получилось открыть файл!");
                return int.MinValue;
            }
            
        }

        public static void SymbolFounder(string pathToRead, string pathToWrite, char symbolToFind)
        {
            string lineToWrite = "";
            if (OpenFile(pathToRead, out StreamReader file))
            {
                string? lineToRead = "";
                while ((lineToRead = file.ReadLine())!=null)
                {
                    if (lineToRead[^1] == symbolToFind)
                    {
                        lineToWrite = $"{lineToWrite}{lineToRead}\n";
                    }
                }
                File.WriteAllText(pathToWrite,lineToWrite);
            }
        }

        public static int BinEquals(string path)
        {
            if (OpenBinFile(path,out BinaryReader srout))
            {

                int k = srout.ReadInt16();
                List<int> list = new List<int>();
                while (k>0)
                {
                    list.Add(srout.ReadInt16());
                    k--;
                }

                int result = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] == -list[j])
                        {
                            list.RemoveAt(j);
                            list.RemoveAt(i);
                            result++;
                            i--; // Возвращаемся на один шаг
                            break;
                        }
                    }
                }
                return result;
            }
            else
            {
                return 0;
            }
        }

    }
}