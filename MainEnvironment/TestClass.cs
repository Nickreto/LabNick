namespace nickEnvironment
{
    internal class Car
    {
        // поля
        private string mark;
        private string model;
        private int year;
        // конструкторы
        // по умолчанию
        public Car()
        {
            this.mark = "Lada";
            this.model = "Granta";
            this.year = 2018;
        }
        // с параметрами
        public Car(string mark,string model,int year)
        {
            this.mark = mark;
            this.model = model;
            this.Year = year;
        }

        public Car(int year)
        {
            this.mark = "BMW";
            this.model = "X5";
            this.Year = year;
        }
        // копирования
        public Car(Car car)
        {
            this.mark = car.mark;
            this.model = car.model;
            this.Year = car.year;
        }
        // свойства
        public string Mark
        {
            get {return mark;}
            set {mark = value;}
        }
        public string Model
        {
            get {return model;}
            set {model = value;}
        }
        public int Year
        {
            get {return year;}
            set
            {
                if (value < 1900 & value > 2026)
                {
                    // Ошибка!!
                }
                else
                {
                    this.year = value;                
                }
            }
        }
        // методы
        // Сначала собственные
        public void Print()
        {
            Console.WriteLine($"{mark} {model}");
        }
        // Потом перегруженные
        public override string ToString()
        {
            return $"{mark} {model} {year} г.";
        }


    }


    internal class Student
    {
        private string name;
        private string group;
        private int course;
        private bool debt;

        public Student()
        {
            this.name = "Иван";
            this.group = "БАС";
            this.course = 1;
            this.debt = false;
        }
        public Student(string name,string group,int course, bool debt)
        {
            this.name = name;
            this.group = group;
            this.Course = course;
            this.debt = debt;
        }

        public Student(Student student)
        {
            this.name = student.name;
            this.group = student.group;
            this.course = student.course;
            this.debt = student.debt;
        }     

        public int Course
        {
            set
            {
                if (value>0 & value <6)
                {
                    this.course = value;
                }
                else
                {
                    Console.WriteLine("Неверно введён курс!!!");
                    Console.WriteLine("Введите значение от 1 до 6, иначе курс будет выставлен по умолчанию");
                    value = int.Parse(Console.ReadLine());
                    if (value>0 & value <6)
                    {
                        this.course = value;
                    }
                    else
                    {
                        this.course = 1;
                    }
                }
            }
            get {return course;}
        }   

        public string Name
        {
            get {return name;}
        }
        public string Group
        {
            set {group = value;}
            get {return group;}
        }
        
        public bool Debt
        {
            set {debt = value;}
            get {return debt;}
        }

        public void SendDown()
        {
            if (this.debt == true)
            {
                Console.WriteLine("Студент отчислен!");
            }
            else
            {
                Console.WriteLine("Студента нельзя отчислить без долгов(");
            }
        }

        public override string ToString()
        {
            return $"{name} {group}-{course}";
        }

    }
    internal class Test
    {
        private int _x;
        private int _y;

        public Test()
        {
            _x = 0;
            _y = 0;
        }
        public Test(int _x, int _y)
        {
            this._x = _x;
            this._y = _y;
        }

        

        public static Test operator ++(Test test)
        {
            return new Test(++test._x, ++test._y);
        }

        public static Test operator --(Test test)
        {
            return new Test(--test._x, --test._y);
        }

        public static Test operator !(Test test)
        {
            return new Test();
        }

        public static Test operator +(Test t1, Test t2)
        {
            return new Test(t1._x+t2._x, t2._y+t1._y);
        }

        public static Test operator +(Test t1, int a)
        {
            return new Test(t1._x+a, t1._y+a);
        }

        public static Test operator +(int a,Test t1)
        {
            return t1+a;
        }

        public static bool operator ==(Test t1, Test t2)
        {
            return ((t1._x==t2._x)&(t1._y==t2._y));
        }

        public static bool operator !=(Test t1, Test t2)
        {
            return !(t1==t2);
        }

        public static bool operator >(Test t1, Test t2)
        {
            return ((t1._x+t1._y>t2._x+t2._y));
        }

        public static bool operator <(Test t1, Test t2)
        {
            return ((t1._x+t1._y<t2._x+t2._y));
        }

        public static bool operator >=(Test t1, Test t2)
        {
            return ((t1._x+t1._y>=t2._x+t2._y));
        }

        public static bool operator <=(Test t1, Test t2)
        {
            return ((t1._x+t1._y<=t2._x+t2._y));
        }

        public static Test operator -(Test t1, Test t2)
        {
            return new Test(t1._x-t2._x, t2._y-t1._y);
        }


        //Преобразование типов
        //неявное
        public static implicit operator int(Test t1)
        {
            return (t1._x+t1._y);
        }

        //явное
        public static explicit operator double(Test t1)
        {
            return t1._x/t1._y;
        }
        public override string ToString()
        {
            return "x= " + _x + " y= " + _y;
        }

        

    }

    internal class Test2
    {
        private int x;
        private int y;
        private static int count;

        public Test2()
        {
            x = 0;
            y = 0;
            count++;
        }

        static Test2()
        {
            count = 0;
            Console.WriteLine("Статический конструктор отработал!");
        }

        public static int Count
        {
            get{return count;}
        }
    }

    internal class Lecture
    {
        public static void Summ (int x, int y, out int ans)
        {
            ans = x + y;
        }
    }
}