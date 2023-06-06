using System.Collections;
using System.Numerics;

namespace ReviewCollectionsAndLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reviewing Collections and LINQ!");
            // CollectionsReview.ReviewCollections();
            // CollectionsReview.ReviewDictionaries();
            // CollectionsReview.ReviewCountWords();
            CollectionsReview.ReviewQueuesAndStacks();
        }
    }

    internal class CollectionsReview
    {
        private CollectionsReview() { }

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