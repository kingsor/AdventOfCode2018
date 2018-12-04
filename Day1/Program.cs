using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
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

            long frequency = 0;

            foreach(string line in lines)
            {
                frequency += Convert.ToInt32(line);
            }

            Console.WriteLine("Resulting frequency: {0}", frequency);

            Console.ReadLine();
        }

        static void PuzzleTwo()
        {
            string[] lines = File.ReadAllLines("./input.txt");

            Dictionary<long, int> frequencies = new Dictionary<long, int>();

            long frequency = 0;
            long idx = 0;
            long times = 0;

            if(!frequencies.ContainsKey(frequency))
            {
                frequencies.Add(frequency, 1);
            }

            while(true)
            {
                var change = Convert.ToInt64(lines[idx]);

                frequency += change;

                if(!frequencies.ContainsKey(frequency))
                {
                    frequencies.Add(frequency, 1);
                }
                else
                {
                    Console.WriteLine("The first frequency reached twice is: {0}", frequency);
                    break;
                }

                idx++;

                if (idx == lines.Length)
                {
                    idx = 0;
                    times++;
                    Console.WriteLine("Times: {0}", times);
                }

                //Console.WriteLine("Current frequency: {0}, change of: {1}, resulting frequency: {2}", frequency, change, (frequency += change));
            }

            Console.WriteLine("Resulting frequency: {0}", frequency);

            Console.ReadLine();
        }
    }
}
