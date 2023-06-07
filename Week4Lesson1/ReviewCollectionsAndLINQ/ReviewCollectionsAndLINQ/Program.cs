using System.Collections;
using System.Numerics;

namespace ReviewCollectionsAndGenerics
{
    internal class Program
    {
        public static string ReadInput(string strPrompt)
        {
            Console.Write(strPrompt);
            string varInput = Console.ReadLine();
            return varInput;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Reviewing Collections and Generics!");
            // CollectionsReview.ReviewCollections();
            // CollectionsReview.ReviewDictionaries();
            // CollectionsReview.ReviewCountWords();
            // CollectionsReview.ReviewQueuesAndStacks();
            //CollectionsReview.ReviewStackReverseWord();
            //CollectionsReview.ReviewConvertDecimalToBinary();
            //CollectionsReview.ReviewTicketsQueue();

            // GenericsReview.ReviewGenericsComparison();
            // GenericsReview.ExercisePrintArray();
            GenericsReview.ExerciseSearchArray();
        }
    }

    internal class GenericsReview
    { 
        private GenericsReview() { }

        public static void ExerciseSearchArray()
        {
            int SearchArray<T>(T[] arrValues, T valueSearch)
            {
                int numIndex = 0;
                foreach(T valueCurrent in arrValues)
                {
                    if (valueCurrent.Equals(valueSearch))
                    {
                        return numIndex;
                    }
                    ++numIndex;
                }
                return -1;
            }

            int[] arrNumbers = { 1, 2, 3, 4, 5 };
            int numIndex = SearchArray(arrNumbers, 5);
            Console.WriteLine($"The index of {5} is {numIndex}");
        }

        public static void ExercisePrintArray()
        {
            void PrintArray<L>(L[] arrValues)
            {
                void PrintValue<L>(L value)
                {
                    Console.WriteLine(value);
                }

                foreach(L value in arrValues)
                {
                    PrintValue(value);
                }
            }

            int[] arrNumbers = { 1, 2, 3, 4, 5};
            string[] arrStrings = { "Hello", "Goodbye", "Whatever"};
            PrintArray(arrNumbers);
            PrintArray(arrStrings);
        }

        public static void ReviewGenericsComparison()
        {
            bool CompareTwoValues<T, V>(T valueOne, T valueTwo, V statement)
            {
                Console.WriteLine(statement);
                return valueOne.Equals(valueTwo);
            }

            Console.WriteLine($"1 == 2: {CompareTwoValues(1, 2, "Comparing integers!")}");
            Console.WriteLine($"\"Hello\" == \"Hello\": {CompareTwoValues<string, int>("Hello", "Hello", 1)}");

            // Console.WriteLine($"Cannot do this: 1 == \"Hello \": {CompareTwoValues("Hello", 1)}");
        }

    }

    internal class CollectionsReview
    {
        private CollectionsReview() { }

        public static void ReviewTicketsQueue()
        {
            const int INT_MAX_TICKETS = 3;
            Queue<KeyValuePair<int, string>> queueTickets = new Queue<KeyValuePair<int, string>>();
            int intTicketNum = 1;

            void HandoutTickets(ref int intTicketNum)
            {
                Console.Write("Weclome, enter your name: ");
                string strCustName = Console.ReadLine();
                Console.WriteLine($"Welcome {strCustName}, your ticket number is #{intTicketNum}");
                KeyValuePair<int, string> mapCustomer = new KeyValuePair<int, string>(intTicketNum, strCustName);
                queueTickets.Enqueue(mapCustomer);

                if (intTicketNum++ >= INT_MAX_TICKETS)
                {
                    Console.WriteLine("All tickets booked, departing!");
                }
                else
                {
                    Console.WriteLine("Next customer!");

                    HandoutTickets(ref intTicketNum);
                }
            }

            void PrintTickets()
            {
                KeyValuePair<int, string> mapCustomer = queueTickets.Dequeue();
                Console.WriteLine($"#{mapCustomer.Key}: {mapCustomer.Value}");
                
                if (queueTickets.Count > 0)
                {
                    PrintTickets();
                }
            }

            HandoutTickets(ref intTicketNum);
            PrintTickets();
        }

        public static void ReviewDictionaries()
        {
            Dictionary<int, object> intDict = new Dictionary<int, object>();

            intDict[1] = "Hello";

            if (intDict.ContainsKey(1))
            {
                Console.WriteLine(intDict[1]);
            }

            intDict.Add(2, " ");
            intDict.Add(3, "World!");
            foreach(var entry in intDict)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            foreach(KeyValuePair<int, object> entry in intDict)
            {
                Console.Write(entry.Value);
            }
            Console.WriteLine();
        }

        public static void ReviewConvertDecimalToBinary()
        {
            int ReadInput()
            {
                int numInput;
                try
                {
                    numInput = Convert.ToInt32(Program.ReadInput("Please enter a positive integer: "));
                    if (numInput < 0)
                    {
                        throw new Exception("Invalid input, please try again!");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    numInput = ReadInput();
                }
                return numInput;
            }

            void PrintStack(ref Stack<int> stackBinary)
            {
                int numElements = stackBinary.Count;
                for (int i = 0; i < numElements; i++) 
                {
                    Console.Write($"{stackBinary.Pop()}");

                }
                Console.WriteLine();
            }

            void ConvertToBinary(int numDecimal, ref Stack<int> stackBinary)
            {
                int numRemainder = numDecimal % 2;
                int numDividend = numDecimal / 2;

                stackBinary.Push(numRemainder);

                if (numDividend != 0)
                {
                    ConvertToBinary(numDividend, ref stackBinary);
                }
            }

            int numInput = ReadInput();
            Console.WriteLine(numInput);
            Stack<int> stackBinary = new Stack<int>();
            ConvertToBinary(numInput, ref stackBinary);
            Console.Write($"Printing!\nDecimal Number: {numInput}\nBinary Number: ");
            PrintStack(ref stackBinary);
            
        }

        public static void ReviewStackReverseWord()
        {

            Console.Write("Please enter a statement: ");
            string strSentence = Console.ReadLine();

            Stack<char> stackChars = new Stack<char>();

            foreach(char letter in strSentence)
            {
                stackChars.Push(letter);
            }

            Console.Write("Reversed statement: ");
            foreach(char letter in stackChars)
            {
                Console.Write(letter);
            }
        }

        public static void ReviewCountWords()
        {
            string strSentence = "The apple never falls far from the apple tree";
            Dictionary<string, int> dictWordCounts = new Dictionary<string, int>();

            int numEndIndex;
            int[] listEndIndex = { -1};
            do
            {
                numEndIndex = strSentence.IndexOf(" ");
                if (listEndIndex.Contains(numEndIndex))
                {
                    break;
                }

                string strWord = strSentence.Substring(0, numEndIndex);

                if (dictWordCounts.ContainsKey(strWord))
                {
                    dictWordCounts[strWord]++;
                }
                else
                {
                    dictWordCounts.Add(strWord, 1);
                }

                strSentence = strSentence.Substring(numEndIndex + 1);
                Console.WriteLine($"Word: \"{strWord}\"");
                Console.WriteLine($"Sentence: [{strSentence}]");

            } while (true);

            foreach(KeyValuePair<string, int> wordCount in dictWordCounts)
            {
                Console.WriteLine($"Word: \"{wordCount.Key}\" Count: {wordCount.Value}");
            }

            Console.WriteLine(@"Look at me print a backslash: \n");

        }

        public static void ReviewQueuesAndStacks()
        {
            string strPrompt = "EASY*QUEUES*AND*STACKS*";

            Stack<char> stackString = new Stack<char>();
            Queue<char> queueString = new Queue<char>();
            string strStack = "";
            string strQueue = "";
            foreach(char character in strPrompt)
            {
                if (character == '*')
                {
                    strStack += stackString.Pop();
                    strQueue += queueString.Dequeue();
                }
                else
                {
                    stackString.Push(character);
                    queueString.Enqueue(character);
                }
            }
            Console.WriteLine($"Stack String: {strStack}");
            Console.WriteLine($"Queue String: {strQueue}\n");

            stackString = new Stack<char>();
            queueString = new Queue<char>();
            strStack = "";
            strQueue = "";
            foreach (char character in strPrompt)
            {
                stackString.Push(character);
                queueString.Enqueue(character);
            }
            foreach (char character in strPrompt)
            {
                strStack += stackString.Pop();
                strQueue += queueString.Dequeue();
            }
            Console.WriteLine(strStack);
            Console.WriteLine(strQueue);
                
        }



        public static void ReviewCollections()
        {
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(10);
            myArrayList.Add("Hello");
            int i = 1;
            foreach (var item in myArrayList) 
            {
                Console.WriteLine(item.GetType());
                Console.WriteLine($"{i++}. {item}");
            }

            // Store object of type System.Int32, must be converted to primitive value
            Object numObject = myArrayList[0];
            Console.WriteLine(numObject);

            List<int> listNumbers = new List<int>();
            listNumbers.Add(32);
            listNumbers.Add(2);
            int numInteger;

            numInteger = listNumbers[0];
            Console.WriteLine(numInteger);

            listNumbers[1] = 33;
            Console.WriteLine(listNumbers[1]);

            listNumbers.Add(34);

            listNumbers.Capacity = 10;

            foreach(var intNumber in listNumbers)
            {
                Console.WriteLine(intNumber);
            }

            int[] arrNumbers = new int[10];
            for (i = 0; i < listNumbers.Capacity; i++)
            {
                Console.WriteLine(arrNumbers[i]);
            }

            void PrintNumbers(int number)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Printing numbers!");
            listNumbers.ForEach(PrintNumbers);
        }
    }
}