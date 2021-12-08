using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021
{
    public class Day6
    {
        public List<int> DataToFish(string data)
        {
            List<string> stringFish = new List<string>(data.Split(","));
            List<int> fish = new List<int>();

            foreach (string s in stringFish) 
            {
                fish.Add(Int32.Parse(s));
            }

            return fish;
        }

        public int FirstTask(List<int> fish)
        {
            for(int i = 0; i < 80; i++)
            {
                for(int j = fish.Count - 1; j >= 0; j--)
                {
                    fish[j]--;
                    if(fish[j] < 0)
                    {
                        fish[j] = 6;
                        fish.Add(8);
                    }
                }
            }
            return fish.Count;
        }

        public long SecondTask(List<int> fish)
        {
            long[] fishNumbers = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach(int f in fish)
            {
                fishNumbers[f]++;
            }

            for (int i = 0; i < 256; i++)
            {
                long[] buffer = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int j = 0; j < 8; j++) 
                {
                    buffer[j] = fishNumbers[j + 1];
                }
                buffer[6] += fishNumbers[0];
                buffer[8] = fishNumbers[0];

                fishNumbers = buffer;
            }
            return fishNumbers[0] + fishNumbers[1] + fishNumbers[2] + fishNumbers[3] + fishNumbers[4] + fishNumbers[5] + fishNumbers[6] + fishNumbers[7] + fishNumbers[8];
        }
    }
}
