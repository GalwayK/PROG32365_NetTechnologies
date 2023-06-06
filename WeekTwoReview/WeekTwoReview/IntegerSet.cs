using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoReview
{
    public class IntegerSet
    {
        private int[] _integerSet = new int[5];
        static Random random = new Random();

        public int[] IntSet
        {
            get { return _integerSet; }
            private set { _integerSet = value; }
        }

        public IntegerSet() 
        {
            PopulateSet();
        }

        public IntegerSet(int[] intSet)
        {
            IntSet = intSet;
        }

        private IntegerSet(int setLength)
        {
            IntSet = new int[setLength];
        }

        public IntegerSet PopulateSet()
        {
            void FillSet(int setLength)
            {
                if (setLength > 0) 
                {
                    FillSet(setLength - 1);
                }
                IntSet[setLength] = random.Next(1, 10);
            }
            FillSet(IntSet.Length - 1);
            return this;
        }

        public IntegerSet PrintSet()
        {
            void PrintElement(int setLength)
            {
                if (setLength > 0)
                {
                    PrintElement(setLength - 1);
                }
                Console.WriteLine(IntSet[setLength]);
            }
            PrintElement(IntSet.Length - 1);
            return this;
        }

        public IntegerSet CursedUnion(IntegerSet set)
        {
            void IterateSets(int numSets, IntegerSet combinedSet, IntegerSet[] sets, ref int numElements)
            {
                Console.WriteLine($"On Set {numSets}");
                if (numSets > 0)
                {
                    Console.WriteLine("Recursion!");
                    IterateSets(numSets - 1, combinedSet, sets, ref numElements);
                }

                Console.WriteLine("Num Sets: " + numSets);

                void PopulateSet(int setLength, ref int numElements)
                {
                    if (setLength > 0)
                    {
                        PopulateSet(setLength - 1, ref numElements);
                    }

                    Console.WriteLine($"Set contains {sets[numSets].IntSet[setLength]}: " + !combinedSet.IntSet.Contains(sets[numSets].IntSet[setLength]));

                    if (!combinedSet.IntSet.Contains(sets[numSets].IntSet[setLength]))
                    {
                        Console.WriteLine($"Adding {sets[numSets].IntSet[setLength]} to set.");
                        combinedSet.IntSet[numElements] = sets[numSets].IntSet[setLength];
                        numElements++;
                    }
                }
                Console.WriteLine($"{numSets}. " + sets[numSets]);
                PopulateSet(sets[numSets].IntSet.Length - 1, ref numElements);
            }

            int combinedSetLength = this.IntSet.Length + set.IntSet.Length;
            IntegerSet combinedSet = new IntegerSet(combinedSetLength);

            IntegerSet[] sets = { this, set };
            int numElements = 0;
            IterateSets(2 - 1, combinedSet, sets, ref numElements);
            return combinedSet;
        }

        public IntegerSet Union(IntegerSet secondSet)
        {
            HashSet<int> intSet = new HashSet<int>();



            IntegerSet[] sets = { this, secondSet };

            foreach (IntegerSet set in sets) 
            {
                foreach (int num in set.IntSet)
                {
                    intSet.Add(num);
                }
            }

            int[] intArr = new int[intSet.Count];

            intSet.CopyTo(intArr);

            return new IntegerSet(intArr);
        }

        public IntegerSet Intersection(IntegerSet secondSet)
        {
            HashSet<int> intSet = new HashSet<int>(); 
            foreach(int i in secondSet.IntSet)
            {
                if (this.IntSet.Contains(i))
                { 
                    intSet.Add(i); 
                }
            }
            return new IntegerSet(intSet.ToArray());
        }
    }
}
