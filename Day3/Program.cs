using Day3.Extensions;
using System;
using System.IO;
using System.Text;

namespace Day3
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

            int dim = 1000;

            int[,] fabric = new int[dim, dim];

            for(int y=0; y<dim; y++)
            {
                for(int x=0; x< dim; x++)
                {
                    fabric[x, y] = 0;
                }
            }


            foreach(string line in lines)
            {
                // #1 @ 1,3: 4x4
                object[] result = line.Unformat("#{0} @ {1},{2}: {3}x{4}");

                int idClaim = Convert.ToInt32(result[0]);
                int left = Convert.ToInt32(result[1]);
                int top = Convert.ToInt32(result[2]);
                int wide = Convert.ToInt32(result[3]);
                int tall = Convert.ToInt32(result[4]);

                for (int x = left; x < left + wide; x++)
                {
                    for(int y = top; y < top + tall; y++)
                    {
                        if(fabric[x, y] == 0)
                        {
                            fabric[x, y] = idClaim;
                        }
                        else
                        {
                            fabric[x, y] = -1;
                        }
                    }
                }
            }

            int overlapped = 0;

            for (int y = 0; y < dim; y++)
            {
                //StringBuilder sb = new StringBuilder();

                for (int x = 0; x < dim; x++)
                {
                    //sb.AppendFormat("{0:0#;-#;00} ", fabric[x, y]);
                    if(fabric[x, y] == -1)
                    {
                        overlapped++;
                    }
                }

                //Console.WriteLine(sb.ToString());
            }

            Console.WriteLine("Overlapped square inches: {0}", overlapped);

            Console.ReadLine();

        }

        static void PuzzleTwo()
        {
            string[] lines = File.ReadAllLines("./input.txt");

            int[] claims = new int[lines.Length];

            for(int idx=0; idx<lines.Length; idx++)
            {
                claims[idx] = 1;
            }

            int dim = 1000;

            int[,] fabric = new int[dim, dim];

            for (int y = 0; y < dim; y++)
            {
                for (int x = 0; x < dim; x++)
                {
                    fabric[x, y] = 0;
                }
            }


            foreach (string line in lines)
            {
                // #1 @ 1,3: 4x4
                object[] result = line.Unformat("#{0} @ {1},{2}: {3}x{4}");

                int idClaim = Convert.ToInt32(result[0]);
                int left = Convert.ToInt32(result[1]);
                int top = Convert.ToInt32(result[2]);
                int wide = Convert.ToInt32(result[3]);
                int tall = Convert.ToInt32(result[4]);

                for (int x = left; x < left + wide; x++)
                {
                    for (int y = top; y < top + tall; y++)
                    {
                        if (fabric[x, y] == 0)
                        {
                            fabric[x, y] = idClaim;
                        }
                        else
                        {
                            int otherClaim = fabric[x, y];
                            fabric[x, y] = -1;
                            claims[idClaim - 1] = 0;
                            if(otherClaim != -1)
                            {
                                claims[otherClaim - 1] = 0;
                            }
                        }
                    }
                }
            }

            int notOverlapped = -1;

            for (int idx = 0; idx < lines.Length; idx++)
            {
                if(claims[idx] == 1)
                {
                    notOverlapped = idx+1;
                    //notOverlapped++;
                    break;
                }
            }

            Console.WriteLine("Not overlapped ID: {0}", notOverlapped);

            Console.ReadLine();
        }
    }
}
