using System;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    public class Day1
    {
        public List<int> ParseMeasurmentsToInt(List<string> input)
        {
            List<int> measurements = new List<int>();

            foreach (string i in input)
            {
                measurements.Add(Int32.Parse(i));
            }

            return measurements;
        }

        public int FirstTask(List<int> measurements)
        {
            int increased = 0;

            for (int i = 1; i < measurements.Count; i++)
            {
                if (measurements[i] > measurements[i - 1]) increased++;
            }

            return increased;
        }

        public int SecondTask(List<int> measurements)
        {
            int increased = 0;

            for (int i = 1; i < measurements.Count - 2; i++)
            {
                if (measurements[i] + measurements[i+1] + measurements[i+2] > measurements[i - 1] + measurements[i] + measurements[i+1]) increased++;
            }

            return increased;
        }
    }
}
