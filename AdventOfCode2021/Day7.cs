using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day7
    {
        public List<int> DataToCrab(string data)
        {
            List<string> stringCrab = new List<string>(data.Split(","));
            List<int> crab = new List<int>();

            foreach (string s in stringCrab)
            {
                crab.Add(Int32.Parse(s));
            }

            return crab;
        }

        public int FirstTask(List<int> crab)
        {
            int currentFuel;
            int minFuel = int.MaxValue;
       
            for (int i = 0; i <= crab.Max(); i++)
            {
                currentFuel = 0;
                foreach (int c in crab)
                {
                    currentFuel += Math.Abs(c - i);
                }
                if (minFuel > currentFuel) minFuel = currentFuel;
            }

            return minFuel;
        }

        public int SecondTask(List<int> crab)
        {
            int currentFuel;
            int minFuel = int.MaxValue;

            for (int i = 0; i <= crab.Max(); i++)
            {
                currentFuel = 0;
                foreach (int c in crab)
                {
                    for(int j = Math.Abs(c - i); j >= 0; j--)
                    {
                        currentFuel += j;
                    }
                }
                if (minFuel > currentFuel) minFuel = currentFuel;
            }

            return minFuel;
        }
    }
}
