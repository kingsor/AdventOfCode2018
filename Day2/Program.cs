using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //PuzzleOne();
            PuzzleTwo();
        }

        static void PuzzleOne()
        {
            string[] lines = File.ReadAllLines("./input.txt");

            long twoTimes = 0;
            long threeTimes = 0;

            Dictionary<char, int> chars = new Dictionary<char, int>();

            foreach (string line in lines)
            {
                chars.Clear();

                foreach (char c in line)
                {
                    if(!chars.ContainsKey(c))
                    {
                        chars.Add(c, 1);
                    }
                    else
                    {
                        chars[c]++;
                    }
                }

                bool twoTimesFound = false;
                bool threeTimesFound = false;

                foreach (char c in chars.Keys)
                {
                    if (chars[c] == 2)
                    {
                        twoTimesFound = true;
                    }

                    if(chars[c] == 3)
                    {
                        threeTimesFound = true;
                    }
                }

                if(twoTimesFound)
                {
                    twoTimes++;
                }

                if(threeTimesFound)
                {
                    threeTimes++;
                }
            }

            long checksum = twoTimes * threeTimes;

            Console.WriteLine("Resulting checksum: {0}", checksum);

        }

        static void PuzzleTwo()
        {
            string[] lines = File.ReadAllLines("./input.txt");

            long times = 0;

            for(int idx=0; idx<lines.Length; idx++)
            {
                for(int next = idx+1; next<lines.Length; next++)
                {
                    var res = CompareCodes(lines[idx], lines[next]);
                    times++;
                }
                
            }

            Console.WriteLine("Resulting comparisons: {0}", times);

            Console.ReadLine();
        }

        static int CompareCodes(string codeOne, string codeTwo)
        {
            int res = 0;
            int pos = 0;

            for(int idx=0; idx<codeOne.Length; idx++)
            {
                if(codeOne[idx] != codeTwo[idx])
                {
                    pos = idx;
                    res++;
                }
            }

            if (res == 1)
            {
                Console.WriteLine("Strings with one difference: [{0}] [{1}]", codeOne, codeTwo);
                var commonLetters = codeTwo.Remove(pos, 1);
                Console.WriteLine("Resulting common letters: {0}", commonLetters);
            }

            return res;
        }
    }
}
