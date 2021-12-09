using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var reader = new StreamReader("/Users/stefano/Projects/AoC/Day3/input.txt"))
            {
                string line;
                int[] ones = new int[12];
                int[] zeroes = new int[12];
                while((line = reader.ReadLine()) != null)
                {
                    for(int i = 0; i < 12; i++)
                    {
                        if (line[i] == '1')
                        {
                            ones[i]++;
                        }
                        else
                        {
                            zeroes[i]++;
                        }
                    }
                }
                string gamma = "";
                string epsilon = "";
                for(int j = 0; j < 12; j++)
                {
                    if (ones[j] > zeroes[j])
                    {
                        gamma += "1";
                        epsilon += "0";
                    }
                    else
                    {
                        gamma += "0";
                        epsilon += "1";
                    }
                }
            Console.WriteLine($"Gamma: {gamma}");
            Console.WriteLine($"Epsilon: {epsilon}");
            int gammaInt = ConvertBinaryToInt(gamma);
            int epsilonInt = ConvertBinaryToInt(epsilon);
            Console.WriteLine($"Result: {gammaInt*epsilonInt}");
            }
        }

        static int ConvertBinaryToInt(string binary)
        {
            int factor = 1;
            int result = 0;
            for(int i = 11; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    result += factor;
                }
                factor *= 2;
            }
            return result;
        }
    }
}
