namespace ReviewLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            LearnLINQ linq = LearnLINQ.SingletonFactoryLINQ();

            // linq.ReviewLinqArraySelection();
            // linq.ReviewLinqObjectCollection();
            // linq.ExerciseRemoveLetterDuplication();
            linq.ReviewLinqDuplicateRemoval();
        }
    }

    public class LearnLINQ
    {
        public void ExerciseRemoveLetterDuplication()
        {
            Console.Write("Please enter a statement: ");
            string strSentence = Console.ReadLine();
            List<string> listWords = new List<string>(strSentence.Split(" "));

            Console.WriteLine("\nDistinct words!");
            var filteredWords = from strWord in (from strWord in listWords select strWord.ToLower()).Distinct() orderby strWord descending select strWord;
            PrintCollection(filteredWords);

            Console.WriteLine("\n");
            var filteredLetters = from strLetter in strSentence.ToUpper().Distinct() 
                                   select strLetter;
            PrintCollection(filteredLetters);
        }

        public void ReviewLinqDuplicateRemoval()
        {
            const int ARR_LENGTH = 30;
            Random random = new Random();
            int[] arrNumbers = new int[ARR_LENGTH];

            for(int i = 0; i < ARR_LENGTH; i++)
            {
                arrNumbers[i] = random.Next(1, 10);
            }
            Console.Write("Unfiltered array: ");
            foreach(int i in arrNumbers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            var filteredArray = from number in arrNumbers.Distinct() orderby number ascending select number;
            Console.Write("Filtered array: ");
            foreach (int i in filteredArray)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            /*   string[] words = { "Hello", "There", "Ah", "General", "Kenobi" };

               var shortSwords = from word in words where word.Length < 6 && word.Length > 2 select word;
               PrintCollection(shortSwords);

               shortSwords = from word in words where word.Length >= 6 || word.Length <= 2 select word;
               PrintCollection(shortSwords);*/
        }

        public void ReviewLinqObjectCollection()
        {
            List<Employee> listEmployees = new List<Employee>
            {
                new Employee("Jason", "Red", 5000M),
                new Employee("Ashley", "Green", 7600M),
                new Employee("Matthew", "Indigo", 3585.50M),
                new Employee("James", "Indigo", 4700.77M), 
                new Employee("Luke", "Indigo", 6200M),
                new Employee("Jason", "Blue", 3200M),
                new Employee("Wendy", "Brown", 4236.40M)
        };

            var listMidSalaryEmployees = from emp in listEmployees.Distinct()
                                         where emp.MonthlySalary >= 3500
                                         && emp.MonthlySalary <= 6000
                                         orderby emp.LastName, emp.FirstName descending
                                         select emp;

            var lengthLongestName = (from length in (from emp in listEmployees.Distinct()
                                                    let lengthName = emp.LastName.Length + emp.FirstName.Length
                                                    orderby lengthName descending
                                                    select lengthName).Take(1)
                                    select length).First();
            Console.WriteLine($"The longest name was: {lengthLongestName}");


            if (listMidSalaryEmployees.Any())
            {
                Console.WriteLine($"The first employee found was : {listMidSalaryEmployees.First()}");
                PrintCollection(listMidSalaryEmployees);
            }
            else
            {
                Console.WriteLine("No employees found with conditions.");
            }

            var names = from emp in listEmployees
                        select new { emp.FirstName, emp.LastName };
            foreach(var name in names)
            {
                Console.WriteLine($"{name}: {name.GetType()}");
            }
            PrintCollection(names);

        }

        public void ReviewLinqArraySelection()
        {

            int[] arrNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Console.WriteLine("Printing high Numbers");
            var arrHighNumbers = from number in arrNumbers
                                   where number > 3
                                   select number;

            PrintCollection(arrHighNumbers);

            Console.WriteLine("Printing Descending Numbers");
            var arrDescNumbers = from number in arrNumbers
                                 orderby number descending
                                 select number;
            PrintCollection(arrDescNumbers);

            List<string> listColors = new List<string>();
            listColors.Add("Blue");
            listColors.Add("Green");
            listColors.Add("Red");
            listColors.Add("Purple");

            var uppercaseColors = from color in listColors
                                  let uppercaseColor = color.ToUpper()
                                  where uppercaseColor.StartsWith('B') || uppercaseColor.EndsWith('D')
                                  select uppercaseColor;

            // LINQ uses deferred execution, runs queries only when result is requested.
            listColors.Add("BINGO");
            PrintCollection(uppercaseColors);
        }


        private static LearnLINQ? linq;
        private LearnLINQ() { }

        public static LearnLINQ SingletonFactoryLINQ()
        {
            if (linq == null) 
            {
                linq = new LearnLINQ();
            }
            return linq;
        }

        void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var value in collection)
            {
                Console.WriteLine(value);
            }
        }


        public void PrintSomething()
        {
            Console.WriteLine("Well, we did it.");
        }
    }
    internal class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal MonthlySalary { get; set; }

        public Employee(string firstName, string lastName, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            MonthlySalary = salary;
        }

        public override string ToString()
        {
            return $"{FirstName, -10} {LastName, -10} {MonthlySalary.ToString("C")}";
        }
    }
}